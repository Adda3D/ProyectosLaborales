# GestorBK — Guía de implementación de API y base de datos

## Contexto

GestorBK es una app iOS de gestión de restaurante/negocio. Tiene un servidor Node.js ya existente que gestiona mensajes de WhatsApp y expone una API en `/api/messages` y `/api/status`. La base de datos es la que ya usa ese servidor.

Esta guía describe todas las nuevas tablas y endpoints que hay que añadir al **mismo servidor Node.js** para persistir los módulos de Recordatorios, Pedidos, Mantenimiento y los Contactos guardados de WhatsApp.

---

## 1. Tablas de base de datos a crear

### 1.1 `reminders` — Recordatorios

```sql
CREATE TABLE IF NOT EXISTS reminders (
  id               TEXT PRIMARY KEY,          -- UUID generado por el cliente iOS (ej: "550e8400-e29b-41d4-a716-446655440000")
  title            TEXT NOT NULL,
  notes            TEXT NOT NULL DEFAULT '',
  date             TEXT NOT NULL,             -- ISO 8601: "2024-05-15T10:30:00.000Z"
  category         TEXT NOT NULL,             -- "Empleados" | "Administrativos" | "Gestión"
  advance_minutes  INTEGER NOT NULL DEFAULT 10,
  is_completed     INTEGER NOT NULL DEFAULT 0, -- 0 = false, 1 = true
  notification_id  TEXT NOT NULL DEFAULT '',
  created_at       TEXT NOT NULL DEFAULT (datetime('now'))
);
```

**Campos JSON que envía la app iOS** (campo Swift → campo JSON):
- `id` (UUID como string)
- `title` (string)
- `notes` (string)
- `date` (ISO 8601 string)
- `category` (string: "Empleados", "Administrativos" o "Gestión")
- `advanceMinutes` (integer)
- `isCompleted` (boolean)
- `notificationID` (string)

---

### 1.2 `maintenance_items` — Mantenimiento

```sql
CREATE TABLE IF NOT EXISTS maintenance_items (
  id               TEXT PRIMARY KEY,          -- UUID del cliente
  description_text TEXT NOT NULL,
  status           TEXT NOT NULL DEFAULT 'Pendiente', -- "Pendiente" | "Solucionado"
  created_at       TEXT NOT NULL,             -- ISO 8601
  resolved_at      TEXT,                      -- ISO 8601 o NULL
  is_archived      INTEGER NOT NULL DEFAULT 0
);
```

**Campos JSON**:
- `id` (UUID string)
- `descriptionText` (string)
- `status` (string: "Pendiente" o "Solucionado")
- `createdAt` (ISO 8601)
- `resolvedAt` (ISO 8601 o null)
- `isArchived` (boolean)

---

### 1.3 `suppliers` — Proveedores

```sql
CREATE TABLE IF NOT EXISTS suppliers (
  id         TEXT PRIMARY KEY,   -- UUID del cliente
  name       TEXT NOT NULL
);
```

**Campos JSON**:
- `id` (UUID string)
- `name` (string)

---

### 1.4 `orders` — Pedidos recurrentes

```sql
CREATE TABLE IF NOT EXISTS orders (
  id                   TEXT PRIMARY KEY,   -- UUID del cliente
  supplier_id          TEXT NOT NULL,      -- UUID que referencia suppliers.id
  recurring_days       TEXT NOT NULL,      -- JSON array de enteros: [1,2,3] (1=Domingo...7=Sábado)
  hour                 INTEGER NOT NULL,
  minute               INTEGER NOT NULL,
  is_active            INTEGER NOT NULL DEFAULT 1,
  confirmed_dates      TEXT NOT NULL DEFAULT '[]', -- JSON array de strings "yyyy-MM-dd"
  notification_base_id TEXT NOT NULL DEFAULT ''
);
```

**Campos JSON**:
- `id` (UUID string)
- `supplierID` (UUID string)
- `recurringDays` (array de integers: [1,2,3,4,5,6,7])
- `hour` (integer 0-23)
- `minute` (integer 0-59)
- `isActive` (boolean)
- `confirmedDates` (array de strings "yyyy-MM-dd")
- `notificationBaseID` (string)

> **Nota SQLite**: Los campos `recurring_days` y `confirmed_dates` se almacenan como texto JSON. Al leer, parsear con `JSON.parse()`.

---

### 1.5 `wa_contacts` — Contactos y grupos guardados de WhatsApp

```sql
CREATE TABLE IF NOT EXISTS wa_contacts (
  id      TEXT PRIMARY KEY DEFAULT (lower(hex(randomblob(16)))), -- UUID generado por el servidor
  wa_id   TEXT NOT NULL UNIQUE,  -- WhatsApp ID: "521XXXXXXXXXX@c.us" o "XXXX@g.us"
  name    TEXT NOT NULL,
  type    TEXT NOT NULL          -- "contact" | "group"
);
```

**Campos JSON que retorna el servidor**:
- `id` (string UUID — generado por el servidor)
- `waId` (string)
- `name` (string)
- `type` (string: "contact" o "group")

---

## 2. Endpoints a implementar

### Base URL
Todos los endpoints se añaden al servidor Node.js existente. No requieren autenticación (igual que `/api/messages`).

---

### 2.1 Recordatorios — `/api/reminders`

#### `GET /api/reminders`
Retorna todos los recordatorios.

**Response 200:**
```json
[
  {
    "id": "550e8400-e29b-41d4-a716-446655440000",
    "title": "Pagar factura de luz",
    "notes": "Ver correo de proveedor",
    "date": "2024-05-15T10:30:00.000Z",
    "category": "Administrativos",
    "advanceMinutes": 60,
    "isCompleted": false,
    "notificationID": "abc-123"
  }
]
```

#### `POST /api/reminders`
Crea un recordatorio. El cliente envía el `id` (UUID generado en iOS).

**Body:**
```json
{
  "id": "550e8400-...",
  "title": "Pagar factura",
  "notes": "",
  "date": "2024-05-15T10:30:00.000Z",
  "category": "Administrativos",
  "advanceMinutes": 60,
  "isCompleted": false,
  "notificationID": "abc-123"
}
```

**Response 201:** el objeto creado completo.

#### `PUT /api/reminders/:id`
Actualiza un recordatorio existente. Body igual al POST.

**Response 200:** el objeto actualizado.

#### `DELETE /api/reminders/:id`
Elimina un recordatorio.

**Response 204:** sin body.

---

### 2.2 Mantenimiento — `/api/maintenance`

#### `GET /api/maintenance`
Retorna todos los items.

**Response 200:**
```json
[
  {
    "id": "uuid-aqui",
    "descriptionText": "Nevera hace ruido extraño",
    "status": "Pendiente",
    "createdAt": "2024-05-01T08:00:00.000Z",
    "resolvedAt": null,
    "isArchived": false
  }
]
```

#### `POST /api/maintenance`
Crea un item. Body = objeto completo con `id` del cliente.

**Response 201:** objeto creado.

#### `PUT /api/maintenance/:id`
Actualiza. Body = objeto completo.

**Response 200:** objeto actualizado.

#### `DELETE /api/maintenance/:id`
**Response 204.**

---

### 2.3 Proveedores — `/api/suppliers`

#### `GET /api/suppliers`
**Response 200:** `[{ "id": "uuid", "name": "Pan" }]`

#### `POST /api/suppliers`
Body: `{ "id": "uuid-del-cliente", "name": "Nombre" }`
**Response 201:** objeto creado.

#### `PUT /api/suppliers/:id`
**Response 200:** objeto actualizado.

#### `DELETE /api/suppliers/:id`
**Response 204.**

---

### 2.4 Pedidos — `/api/orders`

#### `GET /api/orders`
**Response 200:**
```json
[
  {
    "id": "uuid",
    "supplierID": "uuid-proveedor",
    "recurringDays": [2, 4, 6],
    "hour": 8,
    "minute": 30,
    "isActive": true,
    "confirmedDates": ["2024-05-15"],
    "notificationBaseID": "some-uuid"
  }
]
```

> **Importante**: Los campos `recurringDays` y `confirmedDates` se guardan como JSON string en SQLite pero se deben retornar como arrays JSON en la respuesta.

#### `POST /api/orders`
Body = objeto completo con `id` del cliente.
**Response 201:** objeto creado.

#### `PUT /api/orders/:id`
**Response 200:** objeto actualizado.

#### `DELETE /api/orders/:id`
**Response 204.**

---

### 2.5 Contactos de WhatsApp — `/api/wa/contacts`

#### `GET /api/wa/contacts`
**Response 200:**
```json
[
  {
    "id": "server-generated-uuid",
    "waId": "521XXXXXXXXXX@c.us",
    "name": "Proveedor Pan",
    "type": "contact"
  },
  {
    "id": "another-uuid",
    "waId": "120363XXXXXXXXX@g.us",
    "name": "Grupo empleados",
    "type": "group"
  }
]
```

#### `POST /api/wa/contacts`
El `id` lo genera el **servidor** (no el cliente).

**Body:**
```json
{
  "waId": "521XXXXXXXXXX@c.us",
  "name": "Proveedor Pan",
  "type": "contact"
}
```

**Response 201:** objeto completo incluyendo el `id` generado por el servidor:
```json
{
  "id": "abc-server-uuid",
  "waId": "521XXXXXXXXXX@c.us",
  "name": "Proveedor Pan",
  "type": "contact"
}
```

#### `PUT /api/wa/contacts/:id`
El `:id` es el UUID del servidor.

**Body:**
```json
{
  "id": "abc-server-uuid",
  "waId": "521XXXXXXXXXX@c.us",
  "name": "Proveedor Pan actualizado",
  "type": "contact"
}
```

**Response 200:** objeto actualizado.

#### `DELETE /api/wa/contacts/:id`
**Response 204.**

---

## 3. Notas de implementación

### Serialización de booleanos (SQLite)
SQLite no tiene tipo booleano nativo. Guarda `0`/`1` y convierte al leer:
```js
// Al leer de SQLite:
row.is_completed = row.is_completed === 1
row.is_active = row.is_active === 1
row.is_archived = row.is_archived === 1
```

### Serialización de arrays (SQLite)
`recurringDays` y `confirmedDates` en la tabla `orders`:
```js
// Al guardar:
recurring_days: JSON.stringify(body.recurringDays)
confirmed_dates: JSON.stringify(body.confirmedDates)

// Al leer:
recurringDays: JSON.parse(row.recurring_days || '[]')
confirmedDates: JSON.parse(row.confirmed_dates || '[]')
```

### Nombres de campos (camelCase ↔ snake_case)
La app iOS usa `camelCase`. Las tablas usan `snake_case`. El servidor debe convertir:

| JSON (iOS)         | Columna SQL          |
|--------------------|----------------------|
| `advanceMinutes`   | `advance_minutes`    |
| `isCompleted`      | `is_completed`       |
| `notificationID`   | `notification_id`    |
| `descriptionText`  | `description_text`   |
| `resolvedAt`       | `resolved_at`        |
| `createdAt`        | `created_at`         |
| `isArchived`       | `is_archived`        |
| `supplierID`       | `supplier_id`        |
| `recurringDays`    | `recurring_days`     |
| `isActive`         | `is_active`          |
| `confirmedDates`   | `confirmed_dates`    |
| `notificationBaseID` | `notification_base_id` |
| `waId`             | `wa_id`              |

### ID en `wa_contacts`
El servidor genera el `id`. Ejemplo con SQLite + `crypto`:
```js
const { randomUUID } = require('crypto')
const id = randomUUID()
```

### CORS
Si el servidor ya tiene CORS configurado para los endpoints de mensajes, los nuevos endpoints heredan la misma configuración.

### Orden de creación de rutas sugerido
Añadir en el archivo de rutas principal (o en módulos separados):
1. `routes/reminders.js`
2. `routes/maintenance.js`
3. `routes/suppliers.js`
4. `routes/orders.js`
5. `routes/wa-contacts.js` (dentro de la ruta `/api/wa/contacts`)

---

## 4. Ejemplo de estructura Express mínima (referencia)

```js
// routes/reminders.js
const express = require('express')
const router = express.Router()
const db = require('../db') // tu instancia de better-sqlite3 o sqlite3

router.get('/', (req, res) => {
  const rows = db.prepare('SELECT * FROM reminders').all()
  res.json(rows.map(toReminder))
})

router.post('/', (req, res) => {
  const r = req.body
  db.prepare(`
    INSERT INTO reminders (id, title, notes, date, category, advance_minutes, is_completed, notification_id)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?)
  `).run(r.id, r.title, r.notes || '', r.date, r.category, r.advanceMinutes, r.isCompleted ? 1 : 0, r.notificationID || '')
  res.status(201).json(toReminder(db.prepare('SELECT * FROM reminders WHERE id = ?').get(r.id)))
})

router.put('/:id', (req, res) => {
  const r = req.body
  db.prepare(`
    UPDATE reminders SET title=?, notes=?, date=?, category=?, advance_minutes=?, is_completed=?, notification_id=?
    WHERE id=?
  `).run(r.title, r.notes || '', r.date, r.category, r.advanceMinutes, r.isCompleted ? 1 : 0, r.notificationID || '', req.params.id)
  res.json(toReminder(db.prepare('SELECT * FROM reminders WHERE id = ?').get(req.params.id)))
})

router.delete('/:id', (req, res) => {
  db.prepare('DELETE FROM reminders WHERE id = ?').run(req.params.id)
  res.status(204).end()
})

function toReminder(row) {
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

module.exports = router
```

Registrar en el servidor principal:
```js
app.use('/api/reminders', require('./routes/reminders'))
app.use('/api/maintenance', require('./routes/maintenance'))
app.use('/api/suppliers', require('./routes/suppliers'))
app.use('/api/orders', require('./routes/orders'))
app.use('/api/wa/contacts', require('./routes/wa-contacts'))
```

---

## 5. Checklist de implementación

- [ ] Crear tabla `reminders`
- [ ] Implementar rutas `GET/POST/PUT/DELETE /api/reminders`
- [ ] Crear tabla `maintenance_items`
- [ ] Implementar rutas `GET/POST/PUT/DELETE /api/maintenance`
- [ ] Crear tabla `suppliers`
- [ ] Implementar rutas `GET/POST/PUT/DELETE /api/suppliers`
- [ ] Crear tabla `orders`
- [ ] Implementar rutas `GET/POST/PUT/DELETE /api/orders`
- [ ] Crear tabla `wa_contacts`
- [ ] Implementar rutas `GET/POST/PUT/DELETE /api/wa/contacts`
- [ ] Verificar que los booleanos se convierten correctamente (0/1 ↔ true/false)
- [ ] Verificar que los arrays de `orders` se parsean/serializan como JSON
- [ ] Verificar que las fechas ISO 8601 se almacenan y retornan como strings sin modificación
- [ ] Probar desde la app iOS que los datos persisten al cerrar y abrir la app
