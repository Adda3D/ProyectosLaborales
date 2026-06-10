'use strict'

// ── Product catalogue ─────────────────────────────────────────────────────
// u1 / u2: { l: label, f: factor }   u2 = null → no second container unit
const PRODUCTS = [
  { key: 'pan_brioche',    name: 'Pan Brioche Krispper',   u1: { l: 'Gaveta',   f: 35  }, u2: null                     },
  { key: 'pan_grande_h2',  name: 'Pan Grande H2',          u1: { l: 'Gaveta',   f: 28  }, u2: null                     },
  { key: 'pan_largo_h3',   name: 'Pan Largo H3',           u1: { l: 'Gaveta',   f: 32  }, u2: null                     },
  { key: 'pan_pequeno_h0', name: 'Pan Pequeño H0',         u1: { l: 'Gaveta',   f: 48  }, u2: null                     },
  { key: 'alitas_pollo',   name: 'Alitas De Pollo',        u1: { l: 'Caja',     f: 285 }, u2: { l: 'Paquete', f: 57  } },
  { key: 'carne_burger',   name: 'Carne Burger',           u1: { l: 'Caja',     f: 320 }, u2: null                     },
  { key: 'carne_whopper',  name: 'Carne Whopper',          u1: { l: 'Caja',     f: 148 }, u2: null                     },
  { key: 'crispy_chicken', name: 'Crispy Chicken',         u1: { l: 'Caja',     f: 320 }, u2: { l: 'Bolsa',   f: 17  } },
  { key: 'premium_crispy', name: 'Premium Crispy Chicken', u1: { l: 'Caja',     f: 80  }, u2: { l: 'Bolsa',   f: 10  } },
  { key: 'patatas',        name: 'Patatas',                u1: { l: 'Caja',     f: 12.5}, u2: { l: 'Bolsa',   f: 2.5 } },
  { key: 'patatas_sup',    name: 'Patatas Supreme',        u1: { l: 'Caja',     f: 10  }, u2: { l: 'Bolsa',   f: 2.5 } },
  { key: 'mix_vainilla',   name: 'Mix Vainilla',           u1: { l: 'Caja',     f: 320 }, u2: null                     },
  { key: 'cebolla_5',      name: 'Cebolla (Caja 5)',       u1: { l: 'Caja',     f: 5   }, u2: null                     },
  { key: 'cebolla_10',     name: 'Cebolla (Caja 10)',      u1: { l: 'Caja',     f: 10  }, u2: null                     },
  { key: 'lechuga',        name: 'Lechuga',                u1: { l: 'Caja',     f: 6   }, u2: { l: 'Bolsa',   f: 1   } },
  { key: 'tomate_natural', name: 'Tomate Natural',         u1: { l: 'Caja',     f: 6   }, u2: null                     },
]

// ── State ─────────────────────────────────────────────────────────────────
const S = {
  token:    localStorage.getItem('inv_token'),
  role:     localStorage.getItem('inv_role'),
  username: localStorage.getItem('inv_username'),
  prevScreen: null,
}

// ── Screen map ────────────────────────────────────────────────────────────
const screens = {
  login:  document.getElementById('screen-login'),
  home:   document.getElementById('screen-home'),
  add:    document.getElementById('screen-add'),
  search: document.getElementById('screen-search'),
  detail: document.getElementById('screen-detail'),
}

function showScreen (name) {
  S.prevScreen = Object.keys(screens).find(k => screens[k].classList.contains('active')) || null
  Object.values(screens).forEach(s => s.classList.remove('active'))
  screens[name].classList.add('active')
  window.scrollTo(0, 0)
}

// ── API helpers ───────────────────────────────────────────────────────────
const BASE = '/api/inv'

async function api (method, path, body) {
  const opts = {
    method,
    headers: { 'Content-Type': 'application/json' },
  }
  if (S.token) opts.headers['x-auth-token'] = S.token
  if (body)    opts.body = JSON.stringify(body)
  const res  = await fetch(BASE + path, opts)
  const data = await res.json().catch(() => ({}))
  if (res.status === 401) {
    // Session expired or server restarted — force re-login
    S.token = S.role = S.username = null
    localStorage.removeItem('inv_token')
    localStorage.removeItem('inv_role')
    localStorage.removeItem('inv_username')
    showScreen('login')
    toast('Sesión expirada. Inicia sesión de nuevo.', 'error')
    throw new Error('Sesión expirada')
  }
  if (!res.ok) throw new Error(data.error || `Error ${res.status}`)
  return data
}

// ── Toast ─────────────────────────────────────────────────────────────────
let _toastTimer = null
function toast (msg, type = 'success') {
  const el = document.getElementById('toast')
  el.textContent = msg
  el.className   = `toast toast--${type}`
  el.hidden      = false
  clearTimeout(_toastTimer)
  _toastTimer = setTimeout(() => { el.hidden = true }, 3000)
}

// ── Date helper (Europe/Madrid) ───────────────────────────────────────────
function todayMadrid () {
  return new Date().toLocaleDateString('sv-SE', { timeZone: 'Europe/Madrid' })
}
function fmtDate (iso) {
  if (!iso) return ''
  const [y, m, d] = iso.split('-')
  return `${d}/${m}/${y}`
}
function fmtMoment (m) {
  return m === 'apertura' ? 'Apertura' : 'Cierre'
}

// ── Loading state for buttons ─────────────────────────────────────────────
function setLoading (btn, loading) {
  if (loading) {
    btn.dataset.orig = btn.innerHTML
    btn.innerHTML    = '<span class="spinner"></span>'
    btn.disabled     = true
  } else {
    btn.innerHTML = btn.dataset.orig || btn.innerHTML
    btn.disabled  = false
  }
}

// ══════════════════════════════════════════════════════════════════════════
// LOGIN
// ══════════════════════════════════════════════════════════════════════════
document.getElementById('form-login').addEventListener('submit', async e => {
  e.preventDefault()
  const errEl = document.getElementById('login-error')
  const btn   = document.getElementById('btn-login')
  errEl.hidden = true
  setLoading(btn, true)

  try {
    const username = document.getElementById('login-username').value.trim()
    const password = document.getElementById('login-password').value
    const data = await api('POST', '/login', { username, password })
    S.token    = data.token
    S.role     = data.role
    S.username = data.username
    localStorage.setItem('inv_token',    S.token)
    localStorage.setItem('inv_role',     S.role)
    localStorage.setItem('inv_username', S.username)
    goHome()
  } catch (err) {
    errEl.textContent = err.message
    errEl.hidden = false
  } finally {
    setLoading(btn, false)
  }
})

// ══════════════════════════════════════════════════════════════════════════
// HOME
// ══════════════════════════════════════════════════════════════════════════
function goHome () {
  document.getElementById('home-username').textContent = S.username || ''
  // Hide search button for operators
  const searchCard = document.getElementById('btn-go-search')
  searchCard.style.display = (S.role === 'operator') ? 'none' : ''
  showScreen('home')
}

document.getElementById('btn-logout').addEventListener('click', () => {
  api('POST', '/logout').catch(() => {})
  S.token = S.role = S.username = null
  localStorage.removeItem('inv_token')
  localStorage.removeItem('inv_role')
  localStorage.removeItem('inv_username')
  // Clear login form
  document.getElementById('login-username').value = ''
  document.getElementById('login-password').value = ''
  document.getElementById('login-error').hidden = true
  showScreen('login')
})

document.getElementById('btn-go-add').addEventListener('click', () => goAdd())
document.getElementById('btn-go-search').addEventListener('click', () => goSearch())

// ══════════════════════════════════════════════════════════════════════════
// ADD — Inventory form
// ══════════════════════════════════════════════════════════════════════════
let selectedMoment = 'cierre'

async function goAdd () {
  // Reset form state
  selectedMoment = 'cierre'
  document.querySelectorAll('.toggle-btn').forEach(b => {
    b.classList.toggle('active', b.dataset.moment === 'cierre')
  })
  setAperturaNotice('hidden')
  document.getElementById('add-date').value = todayMadrid()
  document.getElementById('add-error').hidden = true
  document.getElementById('add-user-name').textContent = S.username || ''

  // Render products
  renderProductForm()

  showScreen('add')
}

function renderProductForm () {
  const container = document.getElementById('products-list')
  container.innerHTML = ''

  PRODUCTS.forEach(prod => {
    const card = document.createElement('div')
    card.className   = 'product-card'
    card.dataset.key = prod.key

    const u1Label = `${prod.u1.l} ×${prod.u1.f}`
    const u2Label = prod.u2 ? `${prod.u2.l} ×${prod.u2.f}` : null

    card.innerHTML = `
      <div class="product-name">${prod.name}</div>
      <div class="product-inputs">
        <div class="input-cell">
          <label title="${u1Label}">${u1Label}</label>
          <input type="number" inputmode="numeric" pattern="[0-9]*"
                 name="unit1" min="0" max="100" step="1" value="0"
                 aria-label="${prod.name} - ${u1Label}">
        </div>
        <div class="input-cell${prod.u2 ? '' : ' input-cell--na'}">
          <label title="${u2Label || '—'}">${u2Label || '—'}</label>
          <input type="number" inputmode="numeric" pattern="[0-9]*"
                 name="unit2" min="0" max="100" step="1" value="0"
                 ${prod.u2 ? '' : 'disabled'}
                 aria-label="${prod.name} - ${u2Label || 'no aplica'}">
        </div>
        <div class="input-cell">
          <label>Sueltas</label>
          <input type="number" inputmode="numeric" pattern="[0-9]*"
                 name="loose" min="0" max="100" step="1" value="0"
                 aria-label="${prod.name} - Unidades sueltas">
        </div>
      </div>
    `
    container.appendChild(card)
  })
}

// ── Apertura notice helper ────────────────────────────────────────────────
function setAperturaNotice (state, msg) {
  const el = document.getElementById('apertura-notice')
  el.hidden    = (state === 'hidden')
  el.className = `apertura-notice notice--${state}`
  el.innerHTML = msg || ''
}

// ── Load Cierre values into the form when Apertura is selected ────────────
async function loadCierreValues (date) {
  if (!date) return
  setAperturaNotice('loading',
    '<span class="spinner" style="width:14px;height:14px;border-color:rgba(58,91,204,.3);border-top-color:#3A5BCC"></span> Buscando Cierre del ' + fmtDate(date) + '...'
  )
  // Clear prefilled state first
  document.querySelectorAll('#products-list .input-cell').forEach(c => c.classList.remove('input-cell--prefilled'))

  try {
    const list = await api('GET', `/entries?date=${date}&moment=cierre&limit=1`)
    if (!list.length) {
      setAperturaNotice('empty', 'No se encontró un Cierre para el ' + fmtDate(date) + '. Ingresa los valores manualmente.')
      return
    }
    const entry = await api('GET', `/entries/${list[0].id}`)
    const itemMap = {}
    entry.items.forEach(i => { itemMap[i.product_key] = i })

    // Pre-fill product inputs
    document.querySelectorAll('#products-list .product-card').forEach(card => {
      const item   = itemMap[card.dataset.key]
      if (!item) return
      const inputs = card.querySelectorAll('input')
      const cells  = card.querySelectorAll('.input-cell')
      inputs[0].value = item.unit1_count
      inputs[1].value = item.unit2_count
      inputs[2].value = item.loose_count
      cells.forEach(c => {
        if (!c.querySelector('input[disabled]')) c.classList.add('input-cell--prefilled')
      })
    })

    setAperturaNotice('found',
      '&#10003; Valores del Cierre del ' + fmtDate(date) + ' cargados — revisa y ajusta si encuentras alguna incongruencia.'
    )
  } catch (err) {
    if (err.message !== 'Sesión expirada')
      setAperturaNotice('empty', 'No se pudo cargar el Cierre: ' + err.message)
  }
}

// Moment toggle
document.querySelectorAll('.toggle-btn').forEach(btn => {
  btn.addEventListener('click', () => {
    document.querySelectorAll('.toggle-btn').forEach(b => b.classList.remove('active'))
    btn.classList.add('active')
    selectedMoment = btn.dataset.moment
    if (selectedMoment === 'apertura') {
      loadCierreValues(document.getElementById('add-date').value)
    } else {
      // Back to Cierre: clear pre-filled state and notice
      setAperturaNotice('hidden')
      document.querySelectorAll('#products-list .input-cell').forEach(c => c.classList.remove('input-cell--prefilled'))
      // Reset inputs to 0
      document.querySelectorAll('#products-list input:not([disabled])').forEach(i => { i.value = 0 })
    }
  })
})

// Re-load Cierre when date changes and Apertura is active
document.getElementById('add-date').addEventListener('change', () => {
  if (selectedMoment === 'apertura') {
    loadCierreValues(document.getElementById('add-date').value)
  }
})

// Back from add
document.getElementById('btn-back-add').addEventListener('click', () => showScreen('home'))

// Submit
document.getElementById('btn-submit-add').addEventListener('click', async () => {
  const errEl = document.getElementById('add-error')
  const btn   = document.getElementById('btn-submit-add')
  const date  = document.getElementById('add-date').value

  errEl.hidden = true

  if (!date) {
    errEl.textContent = 'Selecciona una fecha.'
    errEl.hidden = false
    return
  }

  // Collect product values
  const items = []
  document.querySelectorAll('#products-list .product-card').forEach(card => {
    const key    = card.dataset.key
    const inputs = card.querySelectorAll('input')
    const clamp  = v => Math.max(0, Math.min(100, parseInt(v) || 0))
    items.push({
      product_key: key,
      unit1_count: clamp(inputs[0].value),
      unit2_count: clamp(inputs[1].value),
      loose_count: clamp(inputs[2].value),
    })
  })

  setLoading(btn, true)
  try {
    await api('POST', '/entries', {
      moment:     selectedMoment,
      entry_date: date,
      items,
    })
    toast('Inventario guardado correctamente')
    showScreen('home')
  } catch (err) {
    errEl.textContent = err.message
    errEl.hidden = false
  } finally {
    setLoading(btn, false)
  }
})

// ══════════════════════════════════════════════════════════════════════════
// SEARCH
// ══════════════════════════════════════════════════════════════════════════
function goSearch () {
  document.getElementById('search-date').value   = todayMadrid()
  document.getElementById('search-moment').value = ''
  document.getElementById('search-results').innerHTML = ''
  showScreen('search')
}

document.getElementById('btn-back-search').addEventListener('click', () => showScreen('home'))

document.getElementById('btn-search').addEventListener('click', async () => {
  const btn       = document.getElementById('btn-search')
  const date      = document.getElementById('search-date').value
  const moment    = document.getElementById('search-moment').value
  const resultsEl = document.getElementById('search-results')

  const params = new URLSearchParams()
  if (date)   params.set('date',   date)
  if (moment) params.set('moment', moment)
  params.set('limit', '100')

  setLoading(btn, true)
  resultsEl.innerHTML = ''

  try {
    const entries = await api('GET', '/entries?' + params.toString())
    if (!entries.length) {
      resultsEl.innerHTML = '<div class="result-empty">No se encontraron registros para los filtros seleccionados.</div>'
    } else {
      entries.forEach(entry => {
        resultsEl.appendChild(buildEntryCard(entry))
      })
    }
  } catch (err) {
    toast(err.message, 'error')
  } finally {
    setLoading(btn, false)
  }
})

function buildEntryCard (entry) {
  const card = document.createElement('div')
  card.className = 'entry-card'

  const momentLabel = fmtMoment(entry.moment)
  const cls         = entry.moment === 'apertura' ? 'entry-badge--apertura' : 'entry-badge--cierre'
  const shortMoment = entry.moment === 'apertura' ? 'APE' : 'CIE'

  card.innerHTML = `
    <div class="entry-badge ${cls}">${shortMoment}</div>
    <div class="entry-info">
      <div class="entry-title">${entry.submitted_by || '—'}</div>
      <div class="entry-meta">${fmtDate(entry.entry_date)} · ${momentLabel}</div>
    </div>
    <div class="entry-chevron">
      <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5"><polyline points="9 18 15 12 9 6"/></svg>
    </div>
  `
  card.addEventListener('click', () => goDetail(entry.id))
  return card
}

// ══════════════════════════════════════════════════════════════════════════
// DETAIL
// ══════════════════════════════════════════════════════════════════════════
document.getElementById('btn-back-detail').addEventListener('click', () => showScreen('search'))

async function goDetail (id) {
  const content = document.getElementById('detail-content')
  const subtitle = document.getElementById('detail-subtitle')
  content.innerHTML = '<div class="result-empty"><span class="spinner" style="border-color:rgba(0,0,0,.2);border-top-color:var(--primary)"></span></div>'
  showScreen('detail')

  try {
    const entry = await api('GET', `/entries/${id}`)
    subtitle.textContent = `${fmtDate(entry.entry_date)} · ${fmtMoment(entry.moment)}`

    // Build product map for quick lookup
    const itemMap = {}
    entry.items.forEach(item => { itemMap[item.product_key] = item })

    // Detail header
    const headerHTML = `
      <div class="detail-header-card">
        <div class="detail-meta-row">
          <span class="detail-chip detail-chip--${entry.moment}">${fmtMoment(entry.moment)}</span>
        </div>
        <div class="detail-info">
          <strong>Nombre:</strong> ${entry.submitted_by || '—'}<br>
          <strong>Fecha:</strong> ${fmtDate(entry.entry_date)}<br>
          <strong>Registrado:</strong> ${new Date(entry.submitted_at).toLocaleString('es-ES', { timeZone: 'Europe/Madrid' })}
        </div>
      </div>
    `

    // Build product cards (read-only, same layout as the form)
    let cardsHTML = ''
    PRODUCTS.forEach(prod => {
      const item    = itemMap[prod.key] || { unit1_count: 0, unit2_count: 0, loose_count: 0 }
      const u1Label = `${prod.u1.l} ×${prod.u1.f}`
      const u2Label = prod.u2 ? `${prod.u2.l} ×${prod.u2.f}` : null

      cardsHTML += `
        <div class="product-card">
          <div class="product-name">${prod.name}</div>
          <div class="product-inputs">
            <div class="input-cell">
              <label title="${u1Label}">${u1Label}</label>
              <div class="count-value">${item.unit1_count}</div>
            </div>
            <div class="input-cell${prod.u2 ? '' : ' input-cell--na'}">
              <label title="${u2Label || '—'}">${u2Label || '—'}</label>
              <div class="count-value${prod.u2 ? '' : ' count-value--na'}">${prod.u2 ? item.unit2_count : '—'}</div>
            </div>
            <div class="input-cell">
              <label>Sueltas</label>
              <div class="count-value">${item.loose_count}</div>
            </div>
          </div>
        </div>
      `
    })

    content.innerHTML = headerHTML + cardsHTML
  } catch (err) {
    content.innerHTML = `<div class="result-empty">${err.message}</div>`
  }
}

// ══════════════════════════════════════════════════════════════════════════
// Init
// ══════════════════════════════════════════════════════════════════════════
if (S.token) {
  goHome()
} else {
  showScreen('login')
}
