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

function toReminder(row) {
  if (!row) return null;
  return {
    id: row.id,
    title: row.title,
    notes: row.notes,
    date: row.date,
    category: row.category,
    advanceMinutes: row.advance_minutes,
    isCompleted: row.is_completed === 1,
    notificationID: row.notification_id
  }
}

router.get('/', async (req, res) => {
  try {
    const rows = await all('SELECT * FROM reminders')
    res.json(rows.map(toReminder))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.post('/', async (req, res) => {
  try {
    const r = req.body
    await run(`
      INSERT INTO reminders (id, title, notes, date, category, advance_minutes, is_completed, notification_id)
      VALUES (?, ?, ?, ?, ?, ?, ?, ?)
    `, [
      r.id, r.title, r.notes || '', r.date, r.category, 
      r.advanceMinutes, r.isCompleted ? 1 : 0, r.notificationID || ''
    ])
    res.status(201).json(toReminder(await get('SELECT * FROM reminders WHERE id = ?', [r.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.put('/:id', async (req, res) => {
  try {
    const r = req.body
    await run(`
      UPDATE reminders SET title=?, notes=?, date=?, category=?, advance_minutes=?, is_completed=?, notification_id=?
      WHERE id=?
    `, [
      r.title, r.notes || '', r.date, r.category, 
      r.advanceMinutes, r.isCompleted ? 1 : 0, r.notificationID || '', 
      req.params.id
    ])
    res.json(toReminder(await get('SELECT * FROM reminders WHERE id = ?', [req.params.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.delete('/:id', async (req, res) => {
  try {
    await run('DELETE FROM reminders WHERE id = ?', [req.params.id])
    res.status(204).end()
  } catch(e) { res.status(500).json({ error: e.message }) }
})

module.exports = { router, setDb }
