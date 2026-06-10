const express  = require('express')
const { Client, LocalAuth } = require('whatsapp-web.js')
const QRCode   = require('qrcode')
const cron     = require('node-cron')
const { v4: uuidv4 } = require('uuid')
const fs       = require('fs')
const path     = require('path')
const sqlite3  = require('sqlite3').verbose()
const bcrypt   = require('bcryptjs')
const { router: invRouter, setDb: setInvDb } = require('./routes/inventory')
const { router: remRouter, setDb: setRemDb } = require('./routes/reminders')
const { router: mainRouter, setDb: setMainDb } = require('./routes/maintenance')
const { router: supRouter, setDb: setSupDb } = require('./routes/suppliers')
const { router: ordRouter, setDb: setOrdDb } = require('./routes/orders')
const { router: waRouter, setDb: setWaDb } = require('./routes/wa-contacts')

const DATA_DIR  = path.join(__dirname, 'data')
const MSGS_FILE = path.join(DATA_DIR, 'messages.json')

fs.mkdirSync(DATA_DIR, { recursive: true })

function loadMessages() {
  try { return JSON.parse(fs.readFileSync(MSGS_FILE, 'utf8')) } catch { return [] }
}
function saveMessages(msgs) {
  fs.writeFileSync(MSGS_FILE, JSON.stringify(msgs, null, 2))
}

let waStatus  = 'DISCONNECTED'
let currentQR = null

const client = new Client({
  authStrategy: new LocalAuth({ dataPath: path.join(DATA_DIR, 'session') }),
  puppeteer: {
    args: ['--no-sandbox', '--disable-setuid-sandbox'],
    headless: true,
    executablePath: process.env.CHROMIUM_PATH || '/usr/bin/google-chrome-stable'
  }
})

client.on('qr', async (qr) => {
  currentQR = await QRCode.toDataURL(qr)
  waStatus   = 'QR_READY'
  console.log('[WA] QR generado — abre /api/status para verlo')
})

client.on('authenticated', () => { waStatus = 'AUTHENTICATED'; currentQR = null; console.log('[WA] Autenticado') })
client.on('ready',         () => { waStatus = 'READY';         currentQR = null; console.log('[WA] Listo para enviar mensajes') })

client.on('disconnected', (reason) => {
  waStatus = 'DISCONNECTED'; currentQR = null
  console.log('[WA] Desconectado:', reason, '— reiniciando en 5s...')
  setTimeout(() => client.initialize().catch(e => console.error('[WA] Error al reiniciar:', e.message)), 5000)
})

client.initialize()

// Cron: evalúa hora en zona Europe/Madrid (servidor puede estar en cualquier zona)
cron.schedule('* * * * *', async () => {
  if (waStatus !== 'READY') return

  const now      = new Date(new Date().toLocaleString('en-US', { timeZone: 'Europe/Madrid' }))
  const jsDay    = now.getDay()
  const timeStr  = `${String(now.getHours()).padStart(2,'0')}:${String(now.getMinutes()).padStart(2,'0')}`
  const todayISO = now.toISOString().slice(0, 10)

  const msgs = loadMessages()
  let changed = false

  for (const msg of msgs) {
    if (!msg.isActive) continue
    if (!msg.schedule.days.includes(jsDay)) continue
    if (msg.schedule.time !== timeStr) continue
    if (msg.lastSentAt && msg.lastSentAt.startsWith(`${todayISO}T${timeStr}`)) continue

    console.log(`[CRON] Enviando "${msg.name}" a ${msg.recipients.length} destinatario(s)`)

    for (const r of msg.recipients) {
      try {
        await client.sendMessage(r.id, msg.message)
        console.log(`  ✓ Enviado a ${r.name}`)
      } catch (err) {
        if (err.message.includes('detached Frame')) {
          await new Promise(res => setTimeout(res, 3000))
          try { await client.sendMessage(r.id, msg.message); console.log(`  ✓ Enviado a ${r.name} (reintento)`) }
          catch (e2) { console.error(`  ✗ Error con ${r.name}:`, e2.message) }
        } else { console.error(`  ✗ Error con ${r.name}:`, err.message) }
      }
    }
    msg.lastSentAt = now.toISOString()
    changed = true
  }

  if (changed) saveMessages(msgs)
})

const app = express()
app.use(express.json())

app.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', '*')
  res.setHeader('Access-Control-Allow-Methods', 'GET,POST,PUT,DELETE,OPTIONS')
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type')
  if (req.method === 'OPTIONS') return res.sendStatus(204)
  next()
})

app.get('/api/status', (req, res) => res.json({ status: waStatus, qr: currentQR }))

app.get('/api/contacts', async (req, res) => {
  if (waStatus !== 'READY') return res.status(503).json({ error: 'WhatsApp no está listo' })
  try {
    const contacts = await client.getContacts()
    res.json(contacts
      .filter(c => !c.isGroup && c.id.server === 'c.us')
      .map(c => ({ id: c.id._serialized, name: c.pushname || c.name || c.number || c.id.user, type: 'contact' }))
      .filter(c => c.name)
      .sort((a, b) => a.name.localeCompare(b.name)))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

app.get('/api/groups', async (req, res) => {
  if (waStatus !== 'READY') return res.status(503).json({ error: 'WhatsApp no está listo' })
  try {
    const chats = await client.getChats()
    res.json(chats.filter(c => c.isGroup)
      .map(c => ({ id: c.id._serialized, name: c.name, type: 'group' }))
      .sort((a, b) => a.name.localeCompare(b.name)))
  } catch (err) { res.status(500).json({ error: err.message }) }
})

app.get('/api/messages', (req, res) => res.json(loadMessages()))

app.post('/api/messages', (req, res) => {
  const { name, recipients, message, schedule, isActive } = req.body
  if (!name || !message || !schedule || !recipients)
    return res.status(400).json({ error: 'Faltan campos obligatorios' })
  const newMsg = {
    id: uuidv4(), name, recipients, message, schedule,
    isActive: isActive !== false, lastSentAt: null, createdAt: new Date().toISOString()
  }
  const msgs = loadMessages(); msgs.push(newMsg); saveMessages(msgs)
  res.status(201).json(newMsg)
})

app.put('/api/messages/:id', (req, res) => {
  const msgs = loadMessages()
  const idx  = msgs.findIndex(m => m.id === req.params.id)
  if (idx === -1) return res.status(404).json({ error: 'Mensaje no encontrado' })
  for (const key of ['name','recipients','message','schedule','isActive'])
    if (req.body[key] !== undefined) msgs[idx][key] = req.body[key]
  saveMessages(msgs); res.json(msgs[idx])
})

app.delete('/api/messages/:id', (req, res) => {
  const msgs    = loadMessages()
  const updated = msgs.filter(m => m.id !== req.params.id)
  if (updated.length === msgs.length) return res.status(404).json({ error: 'Mensaje no encontrado' })
  saveMessages(updated); res.sendStatus(204)
})

app.post('/api/messages/:id/send', async (req, res) => {
  if (waStatus !== 'READY') return res.status(503).json({ error: 'WhatsApp no está listo' })
  const msgs = loadMessages()
  const idx  = msgs.findIndex(m => m.id === req.params.id)
  if (idx === -1) return res.status(404).json({ error: 'Mensaje no encontrado' })
  const errors = []
  for (const r of msgs[idx].recipients) {
    try { await client.sendMessage(r.id, msgs[idx].message) }
    catch (err) { errors.push({ recipient: r.name, error: err.message }) }
  }
  msgs[idx].lastSentAt = new Date().toISOString()
  saveMessages(msgs)
  res.json({ sent: true, sentAt: msgs[idx].lastSentAt, errors })
})

// ── Inventory SQLite DB ────────────────────────────────────────────────────
const DB_PATH = path.join(DATA_DIR, 'inventory.db')
const db = new sqlite3.Database(DB_PATH, err => {
  if (err) console.error('[INV] Error abriendo DB:', err.message)
  else     console.log('[INV] Base de datos en', DB_PATH)
})

db.serialize(() => {
  db.run('PRAGMA foreign_keys = ON')
  db.run('PRAGMA journal_mode = WAL')

  db.run(`CREATE TABLE IF NOT EXISTS inv_users (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    username   TEXT    UNIQUE NOT NULL,
    password   TEXT    NOT NULL,
    role       TEXT    NOT NULL DEFAULT 'operator',
    active     INTEGER NOT NULL DEFAULT 1,
    created_at TEXT    NOT NULL DEFAULT (datetime('now'))
  )`)

  db.run(`CREATE TABLE IF NOT EXISTS inv_operators (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    name       TEXT    NOT NULL,
    active     INTEGER NOT NULL DEFAULT 1,
    created_at TEXT    NOT NULL DEFAULT (datetime('now'))
  )`)

  db.run(`CREATE TABLE IF NOT EXISTS inv_entries (
    id           INTEGER PRIMARY KEY AUTOINCREMENT,
    operator_id  INTEGER,
    user_id      INTEGER,
    moment       TEXT    NOT NULL,
    entry_date   TEXT    NOT NULL,
    submitted_at TEXT    NOT NULL DEFAULT (datetime('now')),
    FOREIGN KEY (operator_id) REFERENCES inv_operators(id),
    FOREIGN KEY (user_id)     REFERENCES inv_users(id)
  )`)

  db.run(`CREATE TABLE IF NOT EXISTS inv_items (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    entry_id    INTEGER NOT NULL,
    product_key TEXT    NOT NULL,
    unit1_count INTEGER NOT NULL DEFAULT 0,
    unit2_count INTEGER NOT NULL DEFAULT 0,
    loose_count INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY (entry_id) REFERENCES inv_entries(id) ON DELETE CASCADE
  )`)

  // Seed default manager user if table is empty
  db.get('SELECT id FROM inv_users LIMIT 1', [], async (err, row) => {
    if (err || row) return
    const hash = await bcrypt.hash('admin123', 10)
    db.run("INSERT INTO inv_users (username, password, role) VALUES ('admin', ?, 'manager')", [hash], e => {
      if (!e) console.log('[INV] Usuario inicial creado → admin / admin123  (cambia la contraseña desde la app iOS)')
    })
  })

  // Nuevas tablas iOS
  db.run(`CREATE TABLE IF NOT EXISTS reminders (
    id               TEXT PRIMARY KEY,
    title            TEXT NOT NULL,
    notes            TEXT NOT NULL DEFAULT '',
    date             TEXT NOT NULL,
    category         TEXT NOT NULL,
    advance_minutes  INTEGER NOT NULL DEFAULT 10,
    is_completed     INTEGER NOT NULL DEFAULT 0,
    notification_id  TEXT NOT NULL DEFAULT '',
    created_at       TEXT NOT NULL DEFAULT (datetime('now'))
  )`)
  db.run(`CREATE TABLE IF NOT EXISTS maintenance_items (
    id               TEXT PRIMARY KEY,
    description_text TEXT NOT NULL,
    status           TEXT NOT NULL DEFAULT 'Pendiente',
    created_at       TEXT NOT NULL,
    resolved_at      TEXT,
    is_archived      INTEGER NOT NULL DEFAULT 0
  )`)
  db.run(`CREATE TABLE IF NOT EXISTS suppliers (
    id         TEXT PRIMARY KEY,
    name       TEXT NOT NULL
  )`)
  db.run(`CREATE TABLE IF NOT EXISTS orders (
    id                   TEXT PRIMARY KEY,
    supplier_id          TEXT NOT NULL,
    recurring_days       TEXT NOT NULL,
    hour                 INTEGER NOT NULL,
    minute               INTEGER NOT NULL,
    is_active            INTEGER NOT NULL DEFAULT 1,
    confirmed_dates      TEXT NOT NULL DEFAULT '[]',
    notification_base_id TEXT NOT NULL DEFAULT ''
  )`)
  db.run(`CREATE TABLE IF NOT EXISTS wa_contacts (
    id      TEXT PRIMARY KEY DEFAULT (lower(hex(randomblob(16)))),
    wa_id   TEXT NOT NULL UNIQUE,
    name    TEXT NOT NULL,
    type    TEXT NOT NULL
  )`)
})

setInvDb(db)
setRemDb(db)
setMainDb(db)
setSupDb(db)
setOrdDb(db)
setWaDb(db)

// ── Inventory API + UI ─────────────────────────────────────────────────────
app.use('/api/inv', invRouter)
app.use('/api/reminders', remRouter)
app.use('/api/maintenance', mainRouter)
app.use('/api/suppliers', supRouter)
app.use('/api/orders', ordRouter)
app.use('/api/wa/contacts', waRouter)
app.use(express.static(path.join(__dirname, 'public')))

const PORT = process.env.PORT || 3000
app.listen(PORT, '0.0.0.0', () => {
  console.log(`\n GestorBK WhatsApp backend en http://0.0.0.0:${PORT}`)
})
