document.addEventListener('DOMContentLoaded', function () {
    // Elementos del DOM
    const selectTipoFecha = document.getElementById('selectTipoFecha');
    const inputFechaInicio = document.getElementById('inputFechaInicio');
    const inputFechaFin = document.getElementById('inputFechaFin');
    const btnFiltrar = document.getElementById('btnFiltrar');
    const btnExportarExcel = document.getElementById('btnExportarExcel');
    const contenedorTabla = document.getElementById('contenedorTabla');

    // Variables para exportar
    let datosFiltrados = [];

    // Evento para filtrar y mostrar todo
    btnFiltrar.addEventListener('click', function () {
        const tipofecha = selectTipoFecha.value;
        const inicio = inputFechaInicio.value;
        const fin = inputFechaFin.value;
        if (!inicio || !fin) {
            alert('Debes seleccionar el rango de fechas');
            return;
        }
        fetch(`/node/api/radicados?tipofecha=${tipofecha}&inicio=${inicio}&fin=${fin}`)
            .then(response => {
                if (!response.ok) throw new Error('Error al obtener los datos');
                return response.json();
            })
            .then(data => {
                datosFiltrados = data;
                renderTabla(data);
                renderGraficos(data);
            })
            .catch(error => {
                contenedorTabla.innerHTML = `<div class="alert alert-danger">Error al obtener los datos.</div>`;
                // Si quieres, también puedes limpiar los gráficos aquí
            });
    });

    // Evento para exportar a Excel
    btnExportarExcel.addEventListener('click', function () {
        const table = document.querySelector('#contenedorTabla table');
        if (!table) return;
        let wb = XLSX.utils.table_to_book(table, { sheet: "Radicados" });
        XLSX.writeFile(wb, "radicados.xlsx");
    });

    // Renderiza la tabla de radicados
    function renderTabla(data) {
        let html = `<table class="table table-striped"><thead><tr>
            <th>Radicado</th>
            <th>Asunto</th>
            <th>Responsable</th>
            <th>Estado</th>
            <th>Fecha Creación</th>
            <th>Dependencia Destino</th>
            <th>Fecha Vencimiento</th>
        </tr></thead><tbody>`;
        data.forEach(row => {
            html += `<tr>
                <td>${row.numradicadortec || ''}</td>
                <td>${row.asunto || ''}</td>
                <td>${row.funcionario_nombre || ''}</td>
                <td>${row.id_decviemacroproceso || ''}</td>
                <td>${row.fecha ? row.fecha.substring(0,10) : ''}</td>
                <td>${row.dependencia_nombre || ''}</td>
                <td>${row.fecha_vencimiento ? row.fecha_vencimiento.substring(0,10) : ''}</td>
            </tr>`;
        });
        html += `</tbody></table>`;
        contenedorTabla.innerHTML = html;
    }

    // Renderiza los tres gráficos de resumen
    function renderGraficos(data) {
        // 1. Gráfico por Estado (id_decviemacroproceso)
        const estados = {};
        data.forEach(row => {
            const key = row.id_decviemacroproceso || 'Sin estado';
            estados[key] = (estados[key] || 0) + 1;
        });
        Highcharts.chart('graficoEstados', {
            chart: { type: 'column' },
            title: { text: 'Radicados por Estado' },
            xAxis: { categories: Object.keys(estados), title: { text: 'Estado' } },
            yAxis: { min: 0, title: { text: 'Cantidad' } },
            series: [{ name: 'Total', data: Object.values(estados) }],
            credits: { enabled: false }
        });

        // 2. Gráfico por Dependencia Destino
        const deps = {};
        data.forEach(row => {
            const nombre = row.dependencia_nombre || 'Sin dependencia';
            deps[nombre] = (deps[nombre] || 0) + 1;
        });
        Highcharts.chart('graficoDependencias', {
            chart: { type: 'bar' },
            title: { text: 'Radicados por Dependencia' },
            xAxis: { categories: Object.keys(deps), title: { text: 'Dependencia' } },
            yAxis: { min: 0, title: { text: 'Cantidad' } },
            series: [{ name: 'Total', data: Object.values(deps) }],
            credits: { enabled: false }
        });

        // 3. Gráfico por Responsable
        const funcs = {};
        data.forEach(row => {
            const nombre = row.funcionario_nombre || 'Sin responsable';
            funcs[nombre] = (funcs[nombre] || 0) + 1;
        });
        Highcharts.chart('graficoResponsables', {
            chart: { type: 'bar' },
            title: { text: 'Radicados por Responsable' },
            xAxis: { categories: Object.keys(funcs), title: { text: 'Responsable' } },
            yAxis: { min: 0, title: { text: 'Cantidad' } },
            series: [{ name: 'Total', data: Object.values(funcs) }],
            credits: { enabled: false }
        });
    }

    // Opcional: inicialización automática, por ejemplo, con el mes actual
    // btnFiltrar.click();
});
