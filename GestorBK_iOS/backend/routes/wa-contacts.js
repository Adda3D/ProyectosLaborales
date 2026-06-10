const express = require('express')
const router = express.Router()
const { randomUUID } = require('crypto')
let db
function setDb(database) { db = database }

const run = (sql, p = []) => new Promise((res, rej) => db.run(sql, p, function (err) { err ? rej(err) : res({ lastID: this.lastID, changes: this.changes }) }))
const get = (sql, p = []) => new Promise((res, rej) => db.get(sql, p, (err, row) => { err ? rej(err) : res(row) }))
const all = (sql, p = []) => new Promise((res, rej) => db.all(sql, p, (err, rows) => { err ? rej(err) : res(rows) }))

function toContact(row) {
  if (!row) return null;
  return {
    id: row.id,
    waId: row.wa_id,
    name: row.name,
    type: row.type
  }
}

router.get('/', async (req, res) => {
  try {
    const rows = await all('SELECT * FROM wa_contacts')
    res.json(rows.map(toContact))
  } catch (e) { res.status(500).json({error: e.message}) }
})

router.post('/', async (req, res) => {
  try {
    const r = req.body
    const newId = randomUUID()
    await run(`
      INSERT INTO wa_contacts (id, wa_id, name, type)
      VALUES (?, ?, ?, ?)
    `, [newId, r.waId, r.name, r.type])
    res.status(201).json(toContact(await get('SELECT * FROM wa_contacts WHERE id = ?', [newId])))
  } catch(e) { 
    if (e.message.includes('UNIQUE')) return res.status(409).json({ error: 'WhatsApp ID ya existe' })
    res.status(500).json({ error: e.message }) 
  }
})

router.put('/:id', async (req, res) => {
  try {
    const r = req.body
    await run(`
      UPDATE wa_contacts SET wa_id=?, name=?, type=?
      WHERE id=?
    `, [r.waId, r.name, r.type, req.params.id])
    res.json(toContact(await get('SELECT * FROM wa_contacts WHERE id = ?', [req.params.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.delete('/:id', async (req, res) => {
  try {
    await run('DELETE FROM wa_contacts WHERE id = ?', [req.params.id])
    res.status(204).end()
  } catch(e) { res.status(500).json({ error: e.message }) }
})

module.exports = { router, setDb }
