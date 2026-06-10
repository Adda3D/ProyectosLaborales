// postgrados_apexcharts.js
// Dashboard de postgrados: 3 gráficos de barras apiladas con ApexCharts.
// Consume endpoints de IrisGraficos (JSON puro, sin HTML):
//   /node/inscritos-semestre-programa
//   /node/matriculados-semestre-programa
//   /node/costo-semestre-programa

(function () {
  var _charts = {};

  function _render(id, options) {
    if (_charts[id]) { _charts[id].destroy(); }
    _charts[id] = new ApexCharts(document.getElementById(id), options);
    _charts[id].render();
  }

  // Transforma array plano en series apiladas por semestre.
  // dataKey: nombre del campo de valor ('inscritos' | 'matriculados' | 'costosemprog')
  function _transformar(data, dataKey) {
    var programas = [];
    var semestresSet = {};
    data.forEach(function (d) {
      if (programas.indexOf(d.nmprogramapostgrado) === -1) { programas.push(d.nmprogramapostgrado); }
      semestresSet[d.nmsemestre] = true;
    });
    var semestres = Object.keys(semestresSet).sort();
    var series = semestres.map(function (sem) {
      return {
        name: sem,
        data: programas.map(function (prog) {
          var item = data.find(function (d) {
            return d.nmprogramapostgrado === prog && d.nmsemestre === sem;
          });
          return item ? (parseFloat(item[dataKey]) || 0) : 0;
        }),
      };
    });
    return { programas: programas, series: series };
  }

  function _opcionesBase(title, programas, series, suffix, isCurrency) {
    return {
      chart: {
        type: 'bar',
        stacked: true,
        height: Math.max(360, programas.length * 32),
        toolbar: { show: true },
        fontFamily: 'Segoe UI, sans-serif',
      },
      title: { text: title, align: 'left', style: { fontSize: '14px', fontWeight: '600', color: '#333' } },
      plotOptions: { bar: { horizontal: true, borderRadius: 3 } },
      dataLabels: { enabled: false },
      series: series,
      xaxis: { categories: programas, title: { text: suffix } },
      tooltip: {
        theme: 'dark',
        y: {
          formatter: isCurrency
            ? function (v) { return '$ ' + v.toLocaleString('es-CO'); }
            : function (v) { return v + ' ' + suffix; },
        },
      },
      legend: { position: 'top' },
      noData: { text: 'Sin datos disponibles' },
    };
  }

  // ── 1. Inscritos ──────────────────────────────────────────────────────────
  function cargarInscritos() {
    fetch('/node/inscritos-semestre-programa')
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data || !data.length) return;
        var t = _transformar(data, 'inscritos');
        _render('pg-inscritos', _opcionesBase(
          'Total de Inscritos por Semestre y Programa',
          t.programas, t.series, 'inscritos', false
        ));
      })
      .catch(function (e) { console.error('pg inscritos:', e); });
  }

  // ── 2. Matriculados ───────────────────────────────────────────────────────
  function cargarMatriculados() {
    fetch('/node/matriculados-semestre-programa')
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data || !data.length) return;
        var t = _transformar(data, 'matriculados');
        _render('pg-matriculados', _opcionesBase(
          'Total de Matriculados por Semestre y Programa',
          t.programas, t.series, 'matriculados', false
        ));
      })
      .catch(function (e) { console.error('pg matriculados:', e); });
  }

  // ── 3. Costo ──────────────────────────────────────────────────────────────
  function cargarCosto() {
    fetch('/node/costo-semestre-programa')
      .then(function (r) { return r.json(); })
      .then(function (data) {
        if (!data || !data.length) return;
        var t = _transformar(data, 'costosemprog');
        _render('pg-costo', _opcionesBase(
          'Costo del Programa por Semestre y Programa',
          t.programas, t.series, 'COP', true
        ));
      })
      .catch(function (e) { console.error('pg costo:', e); });
  }

  // ── Carga inicial ─────────────────────────────────────────────────────────
  // No usar DOMContentLoaded: página cargada vía jQuery .load() en Inspinia.
  cargarInscritos();
  cargarMatriculados();
  cargarCosto();
})();
