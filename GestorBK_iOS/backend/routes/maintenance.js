const express = require('express')
const router = express.Router()
let db
function setDb(database) { db = database }

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

function toItem(row) {
  if (!row) return null;
  return {
    id: row.id,
    descriptionText: row.description_text,
    status: row.status,
    createdAt: row.created_at,
    resolvedAt: row.resolved_at,
    isArchived: row.is_archived === 1
  }
}

router.get('/', async (req, res) => {
  try {
    const rows = await all('SELECT * FROM maintenance_items')
    res.json(rows.map(toItem))
  } catch (e) { res.status(500).json({error: e.message}) }
})

router.post('/', async (req, res) => {
  try {
    const r = req.body
    await run(`
      INSERT INTO maintenance_items (id, description_text, status, created_at, resolved_at, is_archived)
      VALUES (?, ?, ?, ?, ?, ?)
    `, [r.id, r.descriptionText, r.status || 'Pendiente', r.createdAt, r.resolvedAt || null, r.isArchived ? 1 : 0])
    res.status(201).json(toItem(await get('SELECT * FROM maintenance_items WHERE id = ?', [r.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.put('/:id', async (req, res) => {
  try {
    const r = req.body
    await run(`
      UPDATE maintenance_items SET description_text=?, status=?, created_at=?, resolved_at=?, is_archived=?
      WHERE id=?
    `, [r.descriptionText, r.status, r.createdAt, r.resolvedAt || null, r.isArchived ? 1 : 0, req.params.id])
    res.json(toItem(await get('SELECT * FROM maintenance_items WHERE id = ?', [req.params.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.delete('/:id', async (req, res) => {
  try {
    await run('DELETE FROM maintenance_items WHERE id = ?', [req.params.id])
    res.status(204).end()
  } catch(e) { res.status(500).json({ error: e.message }) }
})

module.exports = { router, setDb }
