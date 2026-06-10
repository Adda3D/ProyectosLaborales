// investigacion_ugi_apexcharts.js
// Dashboard presupuestal UGI: selects de resolución/literal,
// tarjetas de resumen y 2 gráficos (torta + barras apiladas).
// Consume endpoints de IrisGraficos (JSON puro):
//   /node/api/resoluciones
//   /node/api/literales
//   /node/api/falta-comprometer/:resolucion/:literal
//   /node/api/conceptos-torta/:resolucion/:literal
//   /node/api/conceptos-barras/:resolucion/:literal

(function () {
  var _charts = {};

  function _render(id, options) {
    if (_charts[id]) { _charts[id].destroy(); }
    _charts[id] = new ApexCharts(document.getElementById(id), options);
    _charts[id].render();
  }

  var _cop = new Intl.NumberFormat('es-CO', { style: 'currency', currency: 'COP', minimumFractionDigits: 0, maximumFractionDigits: 0 });
  function _fmt(v) { return _cop.format(parseFloat(v) || 0); }

  // ── Filtros ───────────────────────────────────────────────────────────────
  function _cargarFiltros() {
    fetch('/node/api/resoluciones')
      .then(function (r) { return r.json(); })
      .then(function (data) {
        var sel = document.getElementById('ugi-resolucion');
        sel.innerHTML = '<option value="">Seleccione una Resolución</option>';
        data.forEach(function (res) {
          var opt = document.createElement('option');
          opt.value = res.numero_resolucion;
          opt.textContent = 'Resolución ' + res.numero_resolucion;
          sel.appendChild(opt);
        });
      })
      .catch(function (e) { console.error('ugi resoluciones:', e); });

    fetch('/node/api/literales')
      .then(function (r) { return r.json(); })
      .then(function (data) {
        var sel = document.getElementById('ugi-literal');
        sel.innerHTML = '<option value="">Seleccione un Literal</option>';
        data.forEach(function (item) {
          var opt = document.createElement('option');
          opt.value = item.nmliteral;
          opt.textContent = 'Literal ' + item.nmliteral;
          sel.appendChild(opt);
        });
      })
      .catch(function (e) { console.error('ugi literales:', e); });
  }

  // ── Tarjetas ──────────────────────────────────────────────────────────────
  function _cargarTarjetas(resolucion, literal) {
    fetch('/node/api/falta-comprometer/' + resolucion + '/' + literal)
      .then(function (r) { return r.json(); })
      .then(function (data) {
        document.getElementById('ugi-cards').innerHTML =
          '<div class="row">' +
          '<div class="col-md-4">' +
            '<div class="card text-white bg-dark mb-3">' +
              '<div class="card-header"><strong>TOTAL RESOLUCIÓN ' + resolucion + '</strong></div>' +
              '<div class="card-body"><p class="card-text">' + _fmt(data.total_resolucion) + '</p></div>' +
            '</div>' +
          '</div>' +
          '<div class="col-md-4">' +
            '<div class="card text-white bg-primary mb-3">' +
              '<div class="card-header"><strong>LITERAL ' + literal + '</strong></div>' +
              '<div class="card-body">' +
                '<p><small>Presupuesto:</small> ' + _fmt(data.total_literal) + '</p>' +
                '<p><small>Asignado:</small> ' + _fmt(data.total_asignado) + '</p>' +
                '<p><small>Falta asignar:</small> ' + _fmt(data.falta_por_asignar) + '</p>' +
              '</div>' +
            '</div>' +
          '</div>' +
          '<div class="col-md-4">' +
            '<div class="card text-white bg-success mb-3">' +
              '<div class="card-header"><strong>EJECUCIÓN</strong></div>' +
              '<div class="card-body">' +
                '<p><small>Pagado:</small> ' + _fmt(data.total_pagado) + '</p>' +
                '<p><small>Por comprometer:</small> ' + _fmt(data.por_comprometer) + '</p>' +
              '</div>' +
            '</div>' +
          '</div>' +
          '</div>';
      })
      .catch(function (e) {
        console.error('ugi falta-comprometer:', e);
        document.getElementById('ugi-cards').innerHTML =
          '<div class="alert alert-danger">Error al cargar los datos.</div>';
      });
  }

  // ── Gráfico torta ─────────────────────────────────────────────────────────
  function _cargarTorta(resolucion, literal) {
    fetch('/node/api/conceptos-torta/' + resolucion + '/' + literal)
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data || !data.length) return;
        var conceptos = data.map(function (d) { return d.nombre_concepto.trim(); });
        var valores = data.map(function (d) { return parseFloat(d.valor_total_concepto) || 0; });
        _render('ugi-torta', {
          chart: { type: 'donut', height: 400, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Distribución por Conceptos', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          series: valores,
          labels: conceptos,
          dataLabels: {
            enabled: true,
            formatter: function (val, opts) {
              return opts.w.globals.labels[opts.seriesIndex] + '\n' + val.toFixed(1) + '%';
            },
          },
          tooltip: {
            y: { formatter: function (v) { return _fmt(v) + ' (' + ((v * 100) / valores.reduce(function (a, b) { return a + b; }, 0)).toFixed(1) + '%)'; } },
          },
          legend: { position: 'bottom' },
          noData: { text: 'Sin datos' },
        });
      })
      .catch(function (e) { console.error('ugi torta:', e); });
  }

  // ── Gráfico barras apiladas ───────────────────────────────────────────────
  function _cargarBarras(resolucion, literal) {
    fetch('/node/api/conceptos-barras/' + resolucion + '/' + literal)
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data || !data.length) return;
        var conceptos = data.map(function (d) { return d.nombre_concepto.trim(); });
        var asignados = data.map(function (d) { return parseFloat(d.total_asignado) || 0; });
        var pagados = data.map(function (d) { return parseFloat(d.total_pagado) || 0; });
        var porComprometer = asignados.map(function (a, i) { return Math.max(0, a - pagados[i]); });
        _render('ugi-barras', {
          chart: { type: 'bar', stacked: true, height: Math.max(300, conceptos.length * 40), toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Asignado / Pagado / Por Comprometer por Concepto', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          plotOptions: { bar: { horizontal: true, borderRadius: 3 } },
          dataLabels: { enabled: false },
          series: [
            { name: 'Total Asignado', data: asignados, color: '#4f46e5' },
            { name: 'Total Pagado', data: pagados, color: '#10b981' },
            { name: 'Por Comprometer', data: porComprometer, color: '#f59e0b' },
          ],
          xaxis: { categories: conceptos, title: { text: 'COP' } },
          tooltip: { theme: 'dark', y: { formatter: function (v) { return _fmt(v); } } },
          legend: { position: 'top' },
          noData: { text: 'Sin datos' },
        });
      })
      .catch(function (e) { console.error('ugi barras:', e); });
  }

  // ── Handler de cambio de filtro ───────────────────────────────────────────
  function _onFiltroChange() {
    var resolucion = document.getElementById('ugi-resolucion').value;
    var literal = document.getElementById('ugi-literal').value;
    if (!resolucion || !literal) return;
    _cargarTarjetas(resolucion, literal);
    _cargarTorta(resolucion, literal);
    _cargarBarras(resolucion, literal);
  }

  // ── Exponer para onclick / onchange ──────────────────────────────────────
  window.ugiDash = { onFiltroChange: _onFiltroChange };

  // ── Inicio ────────────────────────────────────────────────────────────────
  // No usar DOMContentLoaded: página cargada vía jQuery .load() en Inspinia.
  _cargarFiltros();
})();
