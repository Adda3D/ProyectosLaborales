const express = require('express')
const router = express.Router()
let db
function setDb(database) { db = database }

const run = (sql, p = []) => new Promise((res, rej) => db.run(sql, p, function (err) { err ? rej(err) : res({ lastID: this.lastID, changes: this.changes }) }))
const get = (sql, p = []) => new Promise((res, rej) => db.get(sql, p, (err, row) => { err ? rej(err) : res(row) }))
const all = (sql, p = []) => new Promise((res, rej) => db.all(sql, p, (err, rows) => { err ? rej(err) : res(rows) }))

router.get('/', async (req, res) => {
  try {
    const rows = await all('SELECT * FROM suppliers')
    res.json(rows)
  } catch (e) { res.status(500).json({error: e.message}) }
})

router.post('/', async (req, res) => {
  try {
    const r = req.body
    await run('INSERT INTO suppliers (id, name) VALUES (?, ?)', [r.id, r.name])
    res.status(201).json(await get('SELECT * FROM suppliers WHERE id = ?', [r.id]))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.put('/:id', async (req, res) => {
  try {
    const r = req.body
    await run('UPDATE suppliers SET name=? WHERE id=?', [r.name, req.params.id])
    res.json(await get('SELECT * FROM suppliers WHERE id = ?', [req.params.id]))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.delete('/:id', async (req, res) => {
  try {
    await run('DELETE FROM suppliers WHERE id = ?', [req.params.id])
    res.status(204).end()
  } catch(e) { res.status(500).json({ error: e.message }) }
})

module.exports = { router, setDb }
