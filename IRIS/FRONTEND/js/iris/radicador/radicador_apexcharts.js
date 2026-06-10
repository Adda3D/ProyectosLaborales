// radicador_apexcharts.js
// Dashboard de radicados: tabla + 3 gráficos ApexCharts.
// Consume /node/api/radicados (IrisGraficos — JSON puro, sin HTML).

(function () {
  var _charts = {};
  var _datosFiltrados = [];

  var _palette = [
    '#4f46e5', '#0ea5e9', '#10b981', '#f59e0b',
    '#ef4444', '#8b5cf6', '#ec4899', '#14b8a6', '#f97316',
  ];

  function _render(id, options) {
    if (_charts[id]) { _charts[id].destroy(); }
    _charts[id] = new ApexCharts(document.getElementById(id), options);
    _charts[id].render();
  }

  // ── Tabla ─────────────────────────────────────────────────────────────────
  function _renderTabla(data) {
    var html = '<table class="table table-striped table-hover table-sm" id="tablaRadicados">' +
      '<thead><tr>' +
      '<th>Radicado</th><th>Asunto</th><th>Responsable</th>' +
      '<th>Estado</th><th>Fecha Creación</th><th>Dependencia Destino</th><th>Fecha Vencimiento</th>' +
      '</tr></thead><tbody>';
    data.forEach(function (row) {
      html += '<tr>' +
        '<td>' + (row.numradicadortec || '') + '</td>' +
        '<td>' + (row.asunto || '') + '</td>' +
        '<td>' + (row.funcionario_nombre || '') + '</td>' +
        '<td>' + (row.id_decviemacroproceso || '') + '</td>' +
        '<td>' + (row.fecha ? row.fecha.substring(0, 10) : '') + '</td>' +
        '<td>' + (row.dependencia_nombre || '') + '</td>' +
        '<td>' + (row.fecha_vencimiento ? row.fecha_vencimiento.substring(0, 10) : '') + '</td>' +
        '</tr>';
    });
    html += '</tbody></table>';
    document.getElementById('rad-tabla').innerHTML = html;
  }

  // ── Gráficos ──────────────────────────────────────────────────────────────
  function _renderGraficos(data) {
    // 1. Por Estado
    var estados = {};
    data.forEach(function (row) {
      var k = row.id_decviemacroproceso || 'Sin estado';
      estados[k] = (estados[k] || 0) + 1;
    });
    _render('rad-estados', {
      chart: { type: 'bar', height: 320, toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
      title: { text: 'Radicados por Estado', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
      plotOptions: { bar: { borderRadius: 5, columnWidth: '55%', distributed: true, dataLabels: { position: 'top' } } },
      colors: _palette,
      dataLabels: { enabled: true, offsetY: -8, style: { fontSize: '11px', colors: ['#333'] } },
      series: [{ name: 'Total', data: Object.values(estados) }],
      xaxis: { categories: Object.keys(estados), title: { text: 'Estado' } },
      legend: { show: false },
      tooltip: { theme: 'dark' },
    });

    // 2. Por Dependencia (top 15)
    var deps = {};
    data.forEach(function (row) {
      var k = row.dependencia_nombre || 'Sin dependencia';
      deps[k] = (deps[k] || 0) + 1;
    });
    var depEntries = Object.entries(deps).sort(function (a, b) { return b[1] - a[1]; }).slice(0, 15);
    _render('rad-dependencias', {
      chart: { type: 'bar', height: Math.max(300, depEntries.length * 36), toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
      title: { text: 'Radicados por Dependencia (top 15)', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
      plotOptions: { bar: { horizontal: true, borderRadius: 4 } },
      colors: ['#0ea5e9'],
      dataLabels: { enabled: true, offsetX: 8, style: { fontSize: '11px', colors: ['#333'] } },
      series: [{ name: 'Total', data: depEntries.map(function (e) { return e[1]; }) }],
      xaxis: { categories: depEntries.map(function (e) { return e[0]; }), title: { text: 'Cantidad' } },
      tooltip: { theme: 'dark' },
    });

    // 3. Por Responsable (top 15)
    var funcs = {};
    data.forEach(function (row) {
      var k = row.funcionario_nombre || 'Sin responsable';
      funcs[k] = (funcs[k] || 0) + 1;
    });
    var funcEntries = Object.entries(funcs).sort(function (a, b) { return b[1] - a[1]; }).slice(0, 15);
    _render('rad-responsables', {
      chart: { type: 'bar', height: Math.max(300, funcEntries.length * 36), toolbar: { show: true }, fontFamily: 'Segoe UI, sans-serif' },
      title: { text: 'Radicados por Responsable (top 15)', align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
      plotOptions: { bar: { horizontal: true, borderRadius: 4 } },
      colors: ['#10b981'],
      dataLabels: { enabled: true, offsetX: 8, style: { fontSize: '11px', colors: ['#333'] } },
      series: [{ name: 'Total', data: funcEntries.map(function (e) { return e[1]; }) }],
      xaxis: { categories: funcEntries.map(function (e) { return e[0]; }), title: { text: 'Cantidad' } },
      tooltip: { theme: 'dark' },
    });
  }

  // ── Consulta ──────────────────────────────────────────────────────────────
  function _consultar() {
    var tipofecha = document.getElementById('rad-tipofecha').value;
    var inicio = document.getElementById('rad-inicio').value;
    var fin = document.getElementById('rad-fin').value;
    if (!inicio || !fin) {
      ShowModalDialog('Seleccione el rango de fechas', false, 'warning', '', 0);
      return;
    }
    StartLoader();
    fetch('/node/api/radicados?tipofecha=' + tipofecha + '&inicio=' + inicio + '&fin=' + fin)
      .then(function (r) {
        if (!r.ok) throw new Error('Error al obtener los datos');
        return r.json();
      })
      .then(function (data) {
        FinalizeLoader();
        _datosFiltrados = data;
        document.getElementById('rad-resumen').textContent = data.length + ' registros encontrados';
        _renderTabla(data);
        _renderGraficos(data);
      })
      .catch(function (e) {
        FinalizeLoader();
        console.error('radicados:', e);
        ShowModalDialog('Error al obtener los datos', false, 'error', '', 0);
      });
  }

  // ── Excel ─────────────────────────────────────────────────────────────────
  function _exportarExcel() {
    var table = document.getElementById('tablaRadicados');
    if (!table) {
      ShowModalDialog('Primero consulte los datos', false, 'warning', '', 0);
      return;
    }
    var wb = XLSX.utils.table_to_book(table, { sheet: 'Radicados' });
    XLSX.writeFile(wb, 'radicados.xlsx');
  }

  // ── Exponer para onclick ──────────────────────────────────────────────────
  window.radDash = {
    consultar: _consultar,
    exportarExcel: _exportarExcel,
  };

  // No usar DOMContentLoaded: página cargada vía jQuery .load() en Inspinia.
})();
