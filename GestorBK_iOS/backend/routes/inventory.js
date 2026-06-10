'use strict'
const express = require('express')
const crypto  = require('crypto')
const bcrypt  = require('bcryptjs')

const router   = express.Router()
let   db

// In-memory sessions: token → { userId, role, expiresAt }
const sessions = new Map()

function setDb (database) { db = database }

// ── SQLite promise helpers ─────────────────────────────────────────────────
const run = (sql, p = []) =>
  new Promise((res, rej) =>
    db.run(sql, p, function (err) { err ? rej(err) : res({ lastID: this.lastID, changes: this.changes }) })
  )
const get = (sql, p = []) =>
  new Promise((res, rej) =>
    db.get(sql, p, (err, row) => { err ? rej(err) : res(row) })
  )
const all = (sql, p = []) =>
  new Promise((res, rej) =>
    db.all(sql, p, (err, rows) => { err ? rej(err) : res(rows) })
  )

// ── Auth middleware ────────────────────────────────────────────────────────
function auth (req, res, next) {
  const token = req.headers['x-auth-token']
  if (!token) return res.status(401).json({ error: 'No autenticado' })
  const sess = sessions.get(token)
  if (!sess || sess.expiresAt < Date.now()) {
    sessions.delete(token)
    return res.status(401).json({ error: 'Sesión inválida o expirada' })
  }
  req.userId   = sess.userId
  req.userRole = sess.role
  next()
}

// ── AUTH ───────────────────────────────────────────────────────────────────

/**
 * POST /api/inv/login
 * Body: { username, password }
 * Returns: { token, role, username }
 */
router.post('/login', async (req, res) => {
  try {
    const { username, password } = req.body || {}
    if (!username || !password)
      return res.status(400).json({ error: 'Usuario y contraseña requeridos' })
    const user = await get('SELECT * FROM inv_users WHERE username = ? AND active = 1', [username])
    if (!user || !(await bcrypt.compare(password, user.password)))
      return res.status(401).json({ error: 'Credenciales inválidas' })
    const token   = crypto.randomBytes(32).toString('hex')
    const expires = Date.now() + 24 * 3600 * 1000   // 24 h
    sessions.set(token, { userId: user.id, role: user.role, expiresAt: expires })
    res.json({ token, role: user.role, username: user.username })
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * POST /api/inv/logout
 * Header: x-auth-token
 */
router.post('/logout', (req, res) => {
  const token = req.headers['x-auth-token']
  if (token) sessions.delete(token)
  res.json({ ok: true })
})

// ── USERS ──────────────────────────────────────────────────────────────────

/**
 * GET /api/inv/users
 * Returns all users (no passwords). Requires auth.
 */
router.get('/users', auth, async (req, res) => {
  try {
    res.json(await all('SELECT id, username, role, active, created_at FROM inv_users ORDER BY username'))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * POST /api/inv/users
 * Body: { username, password, role }   role = "operator" | "manager"
 * Creates a new app user. No auth required (for initial iOS setup).
 */
router.post('/users', async (req, res) => {
  try {
    const { username, password, role = 'operator' } = req.body || {}
    if (!username || !password)
      return res.status(400).json({ error: 'username y password requeridos' })
    if (!['operator', 'manager'].includes(role))
      return res.status(400).json({ error: "role debe ser 'operator' o 'manager'" })
    const hash = await bcrypt.hash(password, 10)
    const { lastID } = await run(
      'INSERT INTO inv_users (username, password, role) VALUES (?, ?, ?)',
      [username, hash, role]
    )
    res.status(201).json(
      await get('SELECT id, username, role, active, created_at FROM inv_users WHERE id = ?', [lastID])
    )
  } catch (err) {
    if (err.message.includes('UNIQUE'))
      return res.status(409).json({ error: 'El usuario ya existe' })
    res.status(500).json({ error: err.message })
  }
})

/**
 * PUT /api/inv/users/:id
 * Body (all optional): { username, password, role, active }
 * Updates a user. No auth required (for iOS management).
 */
router.put('/users/:id', async (req, res) => {
  try {
    const { username, password, role, active } = req.body || {}
    const u = await get('SELECT id FROM inv_users WHERE id = ?', [req.params.id])
    if (!u) return res.status(404).json({ error: 'Usuario no encontrado' })
    const sets = []; const p = []
    if (username !== undefined) { sets.push('username = ?'); p.push(username) }
    if (password !== undefined) { sets.push('password = ?'); p.push(await bcrypt.hash(password, 10)) }
    if (role     !== undefined) { sets.push('role = ?');     p.push(role) }
    if (active   !== undefined) { sets.push('active = ?');   p.push(active ? 1 : 0) }
    if (!sets.length) return res.status(400).json({ error: 'Nada que actualizar' })
    p.push(req.params.id)
    await run(`UPDATE inv_users SET ${sets.join(', ')} WHERE id = ?`, p)
    res.json(
      await get('SELECT id, username, role, active, created_at FROM inv_users WHERE id = ?', [req.params.id])
    )
  } catch (err) {
    if (err.message.includes('UNIQUE'))
      return res.status(409).json({ error: 'El usuario ya existe' })
    res.status(500).json({ error: err.message })
  }
})

/**
 * DELETE /api/inv/users/:id
 * Deletes a user. No auth required (for iOS management).
 */
router.delete('/users/:id', async (req, res) => {
  try {
    const { changes } = await run('DELETE FROM inv_users WHERE id = ?', [req.params.id])
    if (!changes) return res.status(404).json({ error: 'Usuario no encontrado' })
    res.sendStatus(204)
  } catch (err) { res.status(500).json({ error: err.message }) }
})

// ── OPERATORS (Nombres) ────────────────────────────────────────────────────

/**
 * GET /api/inv/operators
 * Returns active operators. No auth required (used by the form dropdown).
 */
router.get('/operators', async (req, res) => {
  try {
    res.json(await all('SELECT * FROM inv_operators WHERE active = 1 ORDER BY name'))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * GET /api/inv/operators/all
 * Returns ALL operators including inactive. No auth required.
 */
router.get('/operators/all', async (req, res) => {
  try {
    res.json(await all('SELECT * FROM inv_operators ORDER BY name'))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * POST /api/inv/operators
 * Body: { name }
 * Creates an operator. No auth required (for iOS management).
 */
router.post('/operators', async (req, res) => {
  try {
    const { name } = req.body || {}
    if (!name) return res.status(400).json({ error: 'name requerido' })
    const { lastID } = await run('INSERT INTO inv_operators (name) VALUES (?)', [name.trim()])
    res.status(201).json(await get('SELECT * FROM inv_operators WHERE id = ?', [lastID]))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * PUT /api/inv/operators/:id
 * Body (all optional): { name, active }
 * Updates an operator. No auth required.
 */
router.put('/operators/:id', async (req, res) => {
  try {
    const { name, active } = req.body || {}
    const op = await get('SELECT id FROM inv_operators WHERE id = ?', [req.params.id])
    if (!op) return res.status(404).json({ error: 'Operador no encontrado' })
    const sets = []; const p = []
    if (name   !== undefined) { sets.push('name = ?');   p.push(name.trim()) }
    if (active !== undefined) { sets.push('active = ?'); p.push(active ? 1 : 0) }
    if (sets.length) { p.push(req.params.id); await run(`UPDATE inv_operators SET ${sets.join(', ')} WHERE id = ?`, p) }
    res.json(await get('SELECT * FROM inv_operators WHERE id = ?', [req.params.id]))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * DELETE /api/inv/operators/:id
 * Deletes an operator. No auth required.
 */
router.delete('/operators/:id', async (req, res) => {
  try {
    const { changes } = await run('DELETE FROM inv_operators WHERE id = ?', [req.params.id])
    if (!changes) return res.status(404).json({ error: 'Operador no encontrado' })
    res.sendStatus(204)
  } catch (err) { res.status(500).json({ error: err.message }) }
})

// ── INVENTORY ENTRIES ──────────────────────────────────────────────────────

/**
 * GET /api/inv/entries
 * Query params (all optional): date (YYYY-MM-DD), moment (apertura|cierre),
 *   operator_id, limit (default 50), offset (default 0)
 * Requires auth.
 */
router.get('/entries', auth, async (req, res) => {
  try {
    const { date, moment, operator_id, limit = 50, offset = 0 } = req.query
    let sql = `
      SELECT e.*, o.name AS operator_name, u.username AS submitted_by
      FROM inv_entries e
      LEFT JOIN inv_operators o ON e.operator_id = o.id
      LEFT JOIN inv_users     u ON e.user_id     = u.id
      WHERE 1=1
    `
    const p = []
    if (date)        { sql += ' AND e.entry_date = ?';  p.push(date) }
    if (moment)      { sql += ' AND e.moment = ?';      p.push(moment) }
    if (operator_id) { sql += ' AND e.operator_id = ?'; p.push(Number(operator_id)) }
    sql += ' ORDER BY e.entry_date DESC, e.submitted_at DESC LIMIT ? OFFSET ?'
    p.push(Number(limit), Number(offset))
    res.json(await all(sql, p))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * GET /api/inv/entries/:id
 * Returns entry with all items. Requires auth.
 */
router.get('/entries/:id', auth, async (req, res) => {
  try {
    const entry = await get(`
      SELECT e.*, o.name AS operator_name, u.username AS submitted_by
      FROM inv_entries e
      LEFT JOIN inv_operators o ON e.operator_id = o.id
      LEFT JOIN inv_users     u ON e.user_id     = u.id
      WHERE e.id = ?
    `, [req.params.id])
    if (!entry) return res.status(404).json({ error: 'Registro no encontrado' })
    entry.items = await all('SELECT * FROM inv_items WHERE entry_id = ? ORDER BY id', [req.params.id])
    res.json(entry)
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * POST /api/inv/entries
 * Body: { operator_id, moment, entry_date, items }
 *   items: [{ product_key, unit1_count, unit2_count, loose_count }]
 * Requires auth.
 */
router.post('/entries', auth, async (req, res) => {
  try {
    const { operator_id, moment, entry_date, items } = req.body || {}
    if (!moment || !entry_date || !Array.isArray(items) || !items.length)
      return res.status(400).json({ error: 'moment, entry_date e items[] requeridos' })
    if (!['apertura', 'cierre'].includes(moment))
      return res.status(400).json({ error: "moment debe ser 'apertura' o 'cierre'" })

    const { lastID } = await run(
      'INSERT INTO inv_entries (operator_id, user_id, moment, entry_date) VALUES (?, ?, ?, ?)',
      [operator_id || null, req.userId, moment, entry_date]
    )
    for (const item of items) {
      await run(
        'INSERT INTO inv_items (entry_id, product_key, unit1_count, unit2_count, loose_count) VALUES (?, ?, ?, ?, ?)',
        [lastID, item.product_key, item.unit1_count || 0, item.unit2_count || 0, item.loose_count || 0]
      )
    }
    const entry = await get(`
      SELECT e.*, o.name AS operator_name, u.username AS submitted_by
      FROM inv_entries e
      LEFT JOIN inv_operators o ON e.operator_id = o.id
      LEFT JOIN inv_users     u ON e.user_id     = u.id
      WHERE e.id = ?
    `, [lastID])
    entry.items = await all('SELECT * FROM inv_items WHERE entry_id = ?', [lastID])
    res.status(201).json(entry)
  } catch (err) { res.status(500).json({ error: err.message }) }
})

/**
 * DELETE /api/inv/entries/:id
 * Deletes an entry and all its items. Requires auth.
 */
router.delete('/entries/:id', auth, async (req, res) => {
  try {
    const { changes } = await run('DELETE FROM inv_entries WHERE id = ?', [req.params.id])
    if (!changes) return res.status(404).json({ error: 'Registro no encontrado' })
    res.sendStatus(204)
  } catch (err) { res.status(500).json({ error: err.message }) }
})

module.exports = { router, setDb }
