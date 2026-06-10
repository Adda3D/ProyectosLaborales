# API Inventario GestorBK — Documentación para app iOS

## Contexto del sistema

He cambiado el tema del drive por una una aplicación web (accesible desde el navegador del móvil) que los empleados usan para registrar el inventario del local. La app iOS es la herramienta de **gestión y consulta** de esos datos: permite administrar quién puede entrar a la web, y leer los registros guardados.

El servidor corre en Node.js + Express. La base de datos es SQLite (archivo `data/inventory.db`).

---

## URL base

```
http://204.48.16.192:3000/api/inv
```

Todos los endpoints de inventario usan este prefijo.

---

## Autenticación

Las rutas de **lectura de registros** requieren un token en el header:

```
x-auth-token: <token>
```

El token se obtiene llamando a `POST /login`. Dura **24 horas**.

Las rutas de **gestión de usuarios y operadores** (crear, editar, borrar) **no requieren token** — están pensadas para que la app iOS las llame directamente sin login previo.

---

## 1. Login (para consultar registros desde iOS)

### `POST /api/inv/login`

**Body:**
```json
{
  "username": "admin",
  "password": "admin123"
}
```

**Respuesta exitosa `200`:**
```json
{
  "token": "a3f9c2...",
  "role": "manager",
  "username": "admin"
}
```

**Roles posibles:**
- `operator` → solo puede añadir inventario en la web
- `manager` → puede añadir y también buscar/ver registros

---

## 2. Gestión de usuarios

Los **usuarios** son las personas que inician sesión en la app web para registrar el inventario. Su `username` es el **Nombre** que queda guardado en cada registro.

### `GET /api/inv/users`
*(Requiere token)*
Lista todos los usuarios.

**Respuesta:**
```json
[
  {
    "id": 1,
    "username": "admin",
    "role": "manager",
    "active": 1,
    "created_at": "2026-04-08 10:00:00"
  }
]
```

---

### `POST /api/inv/users`
*(Sin token — para crear desde iOS)*

Crea un nuevo usuario.

**Body:**
```json
{
  "username": "juan",
  "password": "mipassword",
  "role": "operator"
}
```

- `role`: `"operator"` (solo añadir) o `"manager"` (añadir + buscar)

**Respuesta `201`:**
```json
{
  "id": 2,
  "username": "juan",
  "role": "operator",
  "active": 1,
  "created_at": "2026-04-08 11:00:00"
}
```

**Error si el usuario ya existe `409`:**
```json
{ "error": "El usuario ya existe" }
```

---

### `PUT /api/inv/users/:id`
*(Sin token — para editar desde iOS)*

Edita un usuario existente. Todos los campos son opcionales.

**Body (cualquier combinación):**
```json
{
  "username": "juan_nuevo",
  "password": "nuevapassword",
  "role": "manager",
  "active": 0
}
```

- `active: 0` desactiva al usuario (no puede iniciar sesión en la web)
- `active: 1` lo reactiva

**Respuesta `200`:** el usuario actualizado (mismo formato que POST).

---

### `DELETE /api/inv/users/:id`
*(Sin token)*

Elimina un usuario permanentemente.

**Respuesta `204`:** sin contenido.

---

## 3. Gestión de operadores *(tabla auxiliar, uso opcional)*

Existe una tabla `inv_operators` que originalmente se usaba para el campo "Nombre" del formulario. Ya no se usa en la app web (el nombre proviene del usuario logueado), pero la tabla sigue disponible por si se necesita para otro propósito.

### `GET /api/inv/operators` — Lista operadores activos
### `GET /api/inv/operators/all` — Lista todos (incluyendo inactivos)
### `POST /api/inv/operators` — `{ "name": "Nombre" }`
### `PUT /api/inv/operators/:id` — `{ "name": "...", "active": 0 }`
### `DELETE /api/inv/operators/:id`

---

## 4. Registros de inventario

### `GET /api/inv/entries`
*(Requiere token)*

Busca registros con filtros opcionales.

**Query params:**
| Param | Tipo | Descripción |
|-------|------|-------------|
| `date` | `YYYY-MM-DD` | Fecha exacta del registro |
| `moment` | `apertura` \| `cierre` | Momento del inventario |
| `operator_id` | número | Filtrar por operador (tabla auxiliar) |
| `limit` | número | Máximo resultados (default: 50) |
| `offset` | número | Para paginación (default: 0) |

**Ejemplo:**
```
GET /api/inv/entries?date=2026-04-08&moment=cierre
```

**Respuesta `200`:**
```json
[
  {
    "id": 1,
    "operator_id": null,
    "user_id": 2,
    "moment": "cierre",
    "entry_date": "2026-04-08",
    "submitted_at": "2026-04-08 01:05:33",
    "operator_name": null,
    "submitted_by": "juan"
  }
]
```

> ⚠️ Esta respuesta **no incluye los ítems de productos**. Para verlos usar el endpoint de detalle.

---

### `GET /api/inv/entries/:id`
*(Requiere token)*

Devuelve un registro completo con todos los productos.

**Respuesta `200`:**
```json
{
  "id": 1,
  "moment": "cierre",
  "entry_date": "2026-04-08",
  "submitted_at": "2026-04-08 01:05:33",
  "submitted_by": "juan",
  "operator_name": null,
  "items": [
    {
      "id": 1,
      "entry_id": 1,
      "product_key": "pan_brioche",
      "unit1_count": 3,
      "unit2_count": 0,
      "loose_count": 12
    },
    {
      "id": 2,
      "entry_id": 1,
      "product_key": "alitas_pollo",
      "unit1_count": 1,
      "unit2_count": 2,
      "loose_count": 5
    }
  ]
}
```

---

### `DELETE /api/inv/entries/:id`
*(Requiere token)*

Elimina un registro y todos sus ítems.

**Respuesta `204`:** sin contenido.

---

## 5. Tabla de productos (referencia fija)

Los productos están definidos en el frontend (no en la DB). Al leer los `items` de un registro, el `product_key` corresponde a esta tabla:

| `product_key` | Nombre | Unidad 1 | Factor U1 | Unidad 2 | Factor U2 |
|---------------|--------|----------|-----------|----------|-----------|
| `pan_brioche` | Pan Brioche Krispper | Gaveta | 35 | — | — |
| `pan_grande_h2` | Pan Grande H2 | Gaveta | 28 | — | — |
| `pan_largo_h3` | Pan Largo H3 | Gaveta | 32 | — | — |
| `pan_pequeno_h0` | Pan Pequeño H0 | Gaveta | 48 | — | — |
| `alitas_pollo` | Alitas De Pollo | Caja | 285 | Paquete | 57 |
| `carne_burger` | Carne Burger | Caja | 320 | — | — |
| `carne_whopper` | Carne Whopper | Caja | 148 | — | — |
| `crispy_chicken` | Crispy Chicken | Caja | 320 | Bolsa | 17 |
| `premium_crispy` | Premium Crispy Chicken | Caja | 80 | Bolsa | 10 |
| `patatas` | Patatas | Caja | 12.5 | Bolsa | 2.5 |
| `patatas_sup` | Patatas Supreme | Caja | 10 | Bolsa | 2.5 |
| `mix_vainilla` | Mix Vainilla | Caja | 320 | — | — |
| `cebolla_5` | Cebolla (Caja 5) | Caja | 5 | — | — |
| `cebolla_10` | Cebolla (Caja 10) | Caja | 10 | — | — |
| `lechuga` | Lechuga | Caja | 6 | Bolsa | 1 |
| `tomate_natural` | Tomate Natural | Caja | 6 | — | — |

**Importante — los valores en la DB son conteos crudos, no se multiplican:**
La DB guarda exactamente el número que escribió el empleado. Si el empleado puso `4` en "Gaveta ×35", la DB tiene `unit1_count = 4`. La app iOS debe mostrar `4` directamente. Los factores (35, 57, etc.) son solo referencia informativa para saber la capacidad de cada unidad — no se usan para ningún cálculo en la app.

---

## 6. Lógica de negocio importante (para mostrar bien los datos en iOS)

### Relación Cierre → Apertura

- Los **cierres** se hacen normalmente a la **1:00 AM**
- Las **aperturas** se hacen a las **10:00 AM** del **mismo día**
- Cuando un empleado va a registrar la Apertura, la app web le carga automáticamente los valores del Cierre del mismo día para que los verifique

Esto significa que al leer los datos desde iOS, **un Cierre y una Apertura del mismo día deben mostrarse juntos** como el ciclo completo de ese día.

Lo importante es saber si en la apertura coincidio con el cierre, quiero ver el comparativo entre los 3 valores. Aunque la apertura finalmente es el importante y saber que persona lo lleno. 

### Estructura recomendada para mostrar en iOS

Agrupar por **fecha**, y dentro de cada fecha mostrar:
- Cierre (ej: registrado a la 1:05 AM por "juan")
- Apertura (ej: registrado a las 10:12 AM por "maria")

### Momentos
- `apertura` → se muestra como **"Apertura"**
- `cierre` → se muestra como **"Cierre"**

---

## 7. Qué debe hacer la app iOS  en una nueva seccion de configracion

### Pantalla: Gestión de usuarios
- Listar todos los usuarios (`GET /users`)
- Crear usuario nuevo (`POST /users`) — pedir nombre, contraseña, rol
- Editar usuario (`PUT /users/:id`) — cambiar nombre, contraseña, rol o desactivarlo
- Eliminar usuario (`DELETE /users/:id`)

> Esto reemplaza el hecho de tener que editar un archivo de configuración. Los usuarios son quienes inician sesión en la app web y su username es el nombre que aparece en los registros.

### Pantalla: Consulta de inventario
- Selector de fecha
- Mostrar el Cierre y la Apertura de esa fecha (si existen)
- Al tocar un registro → detalle con los 16 productos y sus tres conteos crudos (`unit1_count`, `unit2_count`, `loose_count`) — sin multiplicar, sin totales

### Pantalla: Historial
- Lista de fechas con registros (usando `GET /entries?limit=30`)
- Indicador visual de si el día tiene solo Cierre, solo Apertura, o ambos

---

## 8. Errores comunes

| Código | Significado |
|--------|-------------|
| `400` | Falta un campo obligatorio en el body |
| `401` | Token inválido o expirado — volver a hacer login |
| `404` | El recurso (usuario, registro) no existe |
| `409` | Conflicto — el username ya existe |
| `500` | Error interno del servidor |

Todos los errores devuelven:
```json
{ "error": "descripción del error" }
```
