const express = require('express')
const router = express.Router()
let db
function setDb(database) { db = database }

const run = (sql, p = []) => new Promise((res, rej) => db.run(sql, p, function (err) { err ? rej(err) : res({ lastID: this.lastID, changes: this.changes }) }))
const get = (sql, p = []) => new Promise((res, rej) => db.get(sql, p, (err, row) => { err ? rej(err) : res(row) }))
const all = (sql, p = []) => new Promise((res, rej) => db.all(sql, p, (err, rows) => { err ? rej(err) : res(rows) }))

function toOrder(row) {
  if (!row) return null;
  return {
    id: row.id,
    supplierID: row.supplier_id,
    recurringDays: JSON.parse(row.recurring_days || '[]'),
    hour: row.hour,
    minute: row.minute,
    isActive: row.is_active === 1,
    confirmedDates: JSON.parse(row.confirmed_dates || '[]'),
    notificationBaseID: row.notification_base_id
  }
}

router.get('/', async (req, res) => {
  try {
    const rows = await all('SELECT * FROM orders')
    res.json(rows.map(toOrder))
  } catch (e) { res.status(500).json({error: e.message}) }
})

router.post('/', async (req, res) => {
  try {
    const r = req.body
    await run(`
      INSERT INTO orders (id, supplier_id, recurring_days, hour, minute, is_active, confirmed_dates, notification_base_id)
      VALUES (?, ?, ?, ?, ?, ?, ?, ?)
    `, [
      r.id, r.supplierID, JSON.stringify(r.recurringDays || []),
      r.hour, r.minute, r.isActive === false ? 0 : 1,
      JSON.stringify(r.confirmedDates || []), r.notificationBaseID || ''
    ])
    res.status(201).json(toOrder(await get('SELECT * FROM orders WHERE id = ?', [r.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.put('/:id', async (req, res) => {
  try {
    const r = req.body
    await run(`
      UPDATE orders SET supplier_id=?, recurring_days=?, hour=?, minute=?, is_active=?, confirmed_dates=?, notification_base_id=?
      WHERE id=?
    `, [
      r.supplierID, JSON.stringify(r.recurringDays || []),
      r.hour, r.minute, r.isActive === false ? 0 : 1,
      JSON.stringify(r.confirmedDates || []), r.notificationBaseID || '',
      req.params.id
    ])
    res.json(toOrder(await get('SELECT * FROM orders WHERE id = ?', [req.params.id])))
  } catch(e) { res.status(500).json({ error: e.message }) }
})

router.delete('/:id', async (req, res) => {
  try {
    await run('DELETE FROM orders WHERE id = ?', [req.params.id])
    res.status(204).end()
  } catch(e) { res.status(500).json({ error: e.message }) }
})

module.exports = { router, setDb }
