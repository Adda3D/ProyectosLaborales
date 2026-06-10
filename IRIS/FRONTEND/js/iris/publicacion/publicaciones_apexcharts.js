// publicaciones_apexcharts.js
// Gráficas de publicaciones con ApexCharts.
// Reemplaza los gráficos del iframe (IrisGraficos) y de Chart.js.

(function () {
  var _charts = {}; // instancias activas para poder destruir y re-renderizar

  var _palette = [
    '#4f46e5', '#0ea5e9', '#10b981', '#f59e0b',
    '#ef4444', '#8b5cf6', '#ec4899', '#14b8a6', '#f97316',
  ];

  function _render(id, options) {
    if (_charts[id]) { _charts[id].destroy(); }
    _charts[id] = new ApexCharts(document.getElementById(id), options);
    _charts[id].render();
  }

  // ── 1. Manuscritos por Año ────────────────────────────────────────────────
  function cargarManuscritosPorAnio() {
    fetch(urlController + 'Publicaciones_DashBoard/RegistrosPorFechaManuscritoPublicado', {
      headers: { Authorization: 'Bearer ' + TokenIRIS },
    })
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data.Ok || !data.Data || !data.Data.length) return;
        var sorted = data.Data.slice().sort(function (a, b) {
          return a.anopublicacion - b.anopublicacion;
        });
        _render('apx-manuscritos-anio', {
          chart: { type: 'bar', height: 320, toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Manuscritos Publicados por Año', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          plotOptions: { bar: { borderRadius: 6, columnWidth: '55%', dataLabels: { position: 'top' } } },
          colors: ['#4f46e5'],
          fill: { type: 'gradient', gradient: { shade: 'light', type: 'vertical', shadeIntensity: 0.4, gradientToColors: ['#818cf8'], stops: [0, 100] } },
          dataLabels: { enabled: true, offsetY: -8, style: { fontSize: '12px', colors: ['#333'] } },
          series: [{ name: 'Manuscritos', data: sorted.map(function (d) { return parseInt(d.cantidad, 10) || 0; }) }],
          xaxis: { categories: sorted.map(function (d) { return String(d.anopublicacion || 'S/A'); }), title: { text: 'Año de Publicación' } },
          yaxis: { title: { text: 'Cantidad' }, min: 0 },
          tooltip: { theme: 'dark', y: { formatter: function (v) { return v + ' manuscritos'; } } },
          noData: { text: 'Sin datos disponibles' },
        });
      })
      .catch(function (e) { console.error('apx manuscritos/año:', e); });
  }

  // ── 2. Por Área Curricular (requiere rango de años) ───────────────────────
  function cargarPorArea(rango1, rango2) {
    fetch(urlController + 'Publicaciones_DashBoard/RegistrosPorAreaPublicado?rango1=' + rango1 + '&rango2=' + rango2, {
      headers: { Authorization: 'Bearer ' + TokenIRIS },
    })
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data.Ok || !data.Data || !data.Data.length) {
          ShowModalDialog('No hay datos para el rango indicado', false, 'warning', '', 0);
          return;
        }
        var d = data.Data;
        _render('apx-por-area', {
          chart: { type: 'bar', height: Math.max(300, d.length * 36), toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Total Manuscritos por Área Curricular (' + rango1 + '–' + rango2 + ')', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          plotOptions: { bar: { horizontal: true, borderRadius: 4, dataLabels: { position: 'top' } } },
          colors: ['#0ea5e9'],
          dataLabels: { enabled: true, offsetX: 8, style: { fontSize: '11px', colors: ['#333'] } },
          series: [{ name: 'Cantidad', data: d.map(function (e) { return e.cantidad; }) }],
          xaxis: { categories: d.map(function (e) { return e.nmaacad + ' [' + e.anopublicacion + ']'; }), title: { text: 'Cantidad' } },
          tooltip: { theme: 'dark' },
          noData: { text: 'Sin datos disponibles' },
        });
      })
      .catch(function (e) { console.error('apx área:', e); });
  }

  // ── 3. Por Colección ──────────────────────────────────────────────────────
  function cargarPorColeccion() {
    fetch(urlController + 'Publicaciones_DashBoard/RegistrosPublicacionesPorColeccion', {
      headers: { Authorization: 'Bearer ' + TokenIRIS },
    })
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data.Ok || !data.Data || !data.Data.length) return;
        var d = data.Data;
        _render('apx-por-coleccion', {
          chart: { type: 'bar', height: Math.max(300, d.length * 36), toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Total Manuscritos por Colección', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          plotOptions: { bar: { horizontal: true, borderRadius: 4 } },
          colors: ['#10b981'],
          dataLabels: { enabled: true, offsetX: 8, style: { fontSize: '11px', colors: ['#333'] } },
          series: [{ name: 'Cantidad', data: d.map(function (e) { return e.count; }) }],
          xaxis: { categories: d.map(function (e) { return e['colección'] + ' [' + e['año'] + ']'; }), title: { text: 'Cantidad' } },
          tooltip: { theme: 'dark' },
          noData: { text: 'Sin datos disponibles' },
        });
      })
      .catch(function (e) { console.error('apx colección:', e); });
  }

  // ── 4. Por Estado ─────────────────────────────────────────────────────────
  function cargarPorEstado() {
    fetch(urlController + 'Publicaciones_DashBoard/RegistrosPublicacionesPorEstado', {
      headers: { Authorization: 'Bearer ' + TokenIRIS },
    })
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data.Ok || !data.Data || !data.Data.length) return;
        var d = data.Data;
        _render('apx-por-estado', {
          chart: { type: 'bar', height: 320, toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Total Manuscritos por Estado', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          plotOptions: { bar: { borderRadius: 6, columnWidth: '55%', distributed: true, dataLabels: { position: 'top' } } },
          colors: _palette,
          dataLabels: { enabled: true, offsetY: -8, style: { fontSize: '11px', colors: ['#333'] } },
          series: [{ name: 'Cantidad', data: d.map(function (e) { return e.cantidad; }) }],
          xaxis: { categories: d.map(function (e) { return e.estadomanuscrito; }), title: { text: 'Estado' } },
          yaxis: { title: { text: 'Cantidad' }, min: 0 },
          legend: { show: false },
          tooltip: { theme: 'dark' },
          noData: { text: 'Sin datos disponibles' },
        });
      })
      .catch(function (e) { console.error('apx estado:', e); });
  }

  // ── 5. Reporte Presupuestal ───────────────────────────────────────────────
  function cargarPresupuestal() {
    fetch(urlController + 'Publicaciones_DashBoard/ReportePresupuestalPublicacionesSemestre', {
      headers: { Authorization: 'Bearer ' + TokenIRIS },
    })
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data.Ok || !data.Data || !data.Data.length) return;
        var d = data.Data;
        var valorProyectado = d[0].valorproyectado;
        var labels = d.map(function (e) { return e.estadomanuscrito; });
        var valores = d.map(function (e) { return e.totalservicioeditorial; });
        labels.push('Valor Proyectado');
        valores.push(valorProyectado);
        _render('apx-presupuestal', {
          chart: { type: 'donut', height: 400, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Reporte Presupuestal', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          series: valores,
          labels: labels,
          colors: _palette,
          dataLabels: {
            enabled: true,
            formatter: function (val, opts) {
              var v = opts.w.globals.series[opts.seriesIndex];
              return ((v * 100) / valorProyectado).toFixed(1) + '%';
            },
          },
          legend: { position: 'bottom' },
          tooltip: {
            y: {
              formatter: function (val) {
                return '$ ' + val.toLocaleString('es-CO') + ' (' + ((val * 100) / valorProyectado).toFixed(1) + '%)';
              },
            },
          },
          noData: { text: 'Sin datos disponibles' },
        });
      })
      .catch(function (e) { console.error('apx presupuestal:', e); });
  }

  // ── 6. Estado Evaluaciones (requiere año) ─────────────────────────────────
  function cargarEvaluaciones(anio) {
    fetch(urlController + 'Publicaciones_DashBoard/EstadoEvaluaciones?anio=' + anio, {
      headers: { Authorization: 'Bearer ' + TokenIRIS },
    })
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data.Ok || !data.Data || !data.Data.length) {
          ShowModalDialog('No hay datos para el año indicado', false, 'warning', '', 0);
          return;
        }
        var d = data.Data;
        _render('apx-evaluaciones', {
          chart: { type: 'bar', height: Math.max(300, d.length * 40), toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
          title: { text: 'Estado Evaluaciones ' + anio, align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
          plotOptions: { bar: { horizontal: true, borderRadius: 4 } },
          colors: ['#8b5cf6'],
          dataLabels: { enabled: true, offsetX: 8, style: { fontSize: '11px', colors: ['#333'] } },
          series: [{ name: 'Cantidad', data: d.map(function (e) { return e.count; }) }],
          xaxis: { categories: d.map(function (e) { return e.nmconcepto; }), title: { text: 'Cantidad' } },
          tooltip: { theme: 'dark' },
          noData: { text: 'Sin datos disponibles' },
        });
      })
      .catch(function (e) { console.error('apx evaluaciones:', e); });
  }

  // ── Funciones expuestas para los onclick del HTML ─────────────────────────
  window.apxPub = {
    cargarArea: function () {
      var r1 = document.getElementById('apx-area-rango1').value;
      var r2 = document.getElementById('apx-area-rango2').value;
      if (!r1 || !r2) {
        ShowModalDialog('Ingrese ambos rangos de año', false, 'warning', '', 0);
        return;
      }
      cargarPorArea(r1, r2);
    },
    cargarEvaluaciones: function () {
      var anio = document.getElementById('apx-eval-anio').value;
      if (!anio) {
        ShowModalDialog('Ingrese el año de evaluación', false, 'warning', '', 0);
        return;
      }
      cargarEvaluaciones(anio);
    },
  };

  // ── Carga automática al iniciar ───────────────────────────────────────────
  // No usar DOMContentLoaded: esta página se carga vía jQuery .load() en el
  // shell de Inspinia, donde ese evento ya disparó en el documento padre.
  cargarManuscritosPorAnio();
  cargarPorColeccion();
  cargarPorEstado();
  cargarPresupuestal();
})();
