document.addEventListener("DOMContentLoaded", function () {
    const selectResolucion = document.getElementById("selectResolucion");
    const selectLiteral = document.getElementById("selectLiteral");
    const faltaPorComprometerDiv = document.getElementById("faltaPorComprometer");

    // // Función para actualizar la tarjeta
    // function updateCard(resolucion, literal) {
        // fetch(`/node/api/falta-comprometer/${resolucion}/${literal}`)
            // .then(response => response.json())
            // .then(data => {
                // const totalLiteral = parseFloat(data.total_literal) || 0;
                // const totalAsignado = parseFloat(data.total_asignado) || 0;
                // const faltaPorComprometer = totalLiteral - totalAsignado;

                // faltaPorComprometerDiv.innerHTML = `
                    // <p><strong>Total Literal:</strong> ${totalLiteral.toLocaleString('es-CO', {
                        // style: 'currency',
                        // currency: 'COP',
                    // })}</p>
                    // <p><strong>Total Asignado:</strong> ${totalAsignado.toLocaleString('es-CO', {
                        // style: 'currency',
                        // currency: 'COP',
                    // })}</p>
                    // <p><strong>Falta por Comprometer:</strong> ${faltaPorComprometer.toLocaleString('es-CO', {
                        // style: 'currency',
                        // currency: 'COP',
                    // })}</p>
                // `;
            // })
            // .catch(error => console.error("Error al obtener falta por comprometer:", error));
    // }
	
function updateCard(resolucion, literal) {
    fetch(`/node/api/falta-comprometer/${resolucion}/${literal}`)
        .then(response => response.json())
        .then(data => {
            const formatCurrency = (value) => {
				const num = typeof value === 'string' ? parseFloat(value) : Number(value);
				return new Intl.NumberFormat('es-CO', {
					style: 'currency',
					currency: 'COP',
					currencyDisplay: 'symbol',
					minimumFractionDigits: 0,
					maximumFractionDigits: 0
				}).format(num || 0);
			};

            // Eliminar el título "Falta por Comprometer" y mostrar tres tarjetas
            faltaPorComprometerDiv.innerHTML = `
                <div class="row">
                    <!-- Primera tarjeta: Total Resolución -->
                    <div class="col-md-4">
                        <div class="card text-white bg-dark mb-3">
                            <div class="card-header">
                                <strong>TOTAL RESOLUCIÓN ${resolucion}</strong>
                            </div>
                            <div class="card-body">
                                <p class="card-text">${formatCurrency(data.total_resolucion)}</p>
                            </div>
                        </div>
                    </div>
                    
                    <!-- Segunda tarjeta: Presupuesto del Literal -->
                    <div class="col-md-4">
                        <div class="card text-white bg-primary mb-3">
                            <div class="card-header">
                                <strong>LITERAL ${literal}</strong>
                            </div>
                            <div class="card-body">
                                <p><small>Presupuesto:</small> ${formatCurrency(data.total_literal)}</p>
                                <p><small>Asignado:</small> ${formatCurrency(data.total_asignado)}</p>
                                <p><small>Falta asignar:</small> ${formatCurrency(data.falta_por_asignar)}</p>
                            </div>
                        </div>
                    </div>
                    
                    <!-- Tercera tarjeta: Ejecución -->
                    <div class="col-md-4">
                        <div class="card text-white bg-success mb-3">
                            <div class="card-header">
                                <strong>EJECUCIÓN</strong>
                            </div>
                            <div class="card-body">
                                <p><small>Pagado:</small> ${formatCurrency(data.total_pagado)}</p>
                                <p><small>Por comprometer:</small> ${formatCurrency(data.por_comprometer)}</p>
                            </div>
                        </div>
                    </div>
                </div>
            `;
        })
        .catch(error => {
            console.error("Error al obtener datos:", error);
            faltaPorComprometerDiv.innerHTML = `
                <div class="alert alert-danger">
                    Error al cargar los datos. Por favor intente nuevamente.
                </div>
            `;
        });
}

    // Función para actualizar los gráficos
    function updateCharts(resolucion, literal) {
        // Gráfico de Torta
        fetch(`/node/api/conceptos-torta/${resolucion}/${literal}`)
			.then(response => response.json())
			.then(data => {
				const conceptos = data.map(d => d.nombre_concepto.trim());
				const valores = data.map(d => parseFloat(d.valor_total_concepto) || 0);

				console.log("Datos para gráfico de torta:", { conceptos, valores });

				if (conceptos.length === 0 || valores.length === 0) {
					console.error("No hay datos para el gráfico de torta.");
					return;
				}

				Highcharts.chart("graficoTorta", {
					chart: {
						type: 'pie',
					},
					title: {
						text: 'Distribución por Conceptos',
					},
					tooltip: {
						pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b><br/>Valor: {point.y:,.0f} COP',
					},
					plotOptions: {
						pie: {
							allowPointSelect: true,
							cursor: 'pointer',
							dataLabels: {
								enabled: true,
								format: '<b>{point.name}</b><br/>{point.percentage:.1f}%<br/>{point.y:,.0f} COP',
								distance: 30, // Ubicación externa de los datos
								style: {
									fontSize: '12px',
									fontWeight: 'bold',
								},
							},
						},
					},
					series: [
						{
							name: 'Valor',
							colorByPoint: true,
							data: conceptos.map((concepto, i) => ({
								name: concepto,
								y: valores[i],
							})),
						},
					],
				});
			})
			.catch(error => console.error("Error al generar gráfico de torta:", error));


        // Gráfico de Barras Apiladas
        fetch(`/node/api/conceptos-barras/${resolucion}/${literal}`)
            .then(response => response.json())
            .then(data => {
                const conceptos = data.map(d => d.nombre_concepto.trim());
                const asignados = data.map(d => parseFloat(d.total_asignado) || 0);
                const pagados = data.map(d => parseFloat(d.total_pagado) || 0);
                const porComprometer = conceptos.map((_, i) => asignados[i] - pagados[i]);

                console.log("Datos para gráfico de barras:", { conceptos, asignados, pagados, porComprometer });

                Highcharts.chart("graficoBarras", {
                    chart: {
                        type: 'bar',
                    },
                    title: {
                        text: 'Total Asignado, Pagado y Por Comprometer por Concepto',
                    },
                    xAxis: {
                        categories: conceptos,
                    },
                    yAxis: {
                        title: {
                            text: 'Cantidad (COP)',
                        },
                    },
                    plotOptions: {
                        series: {
                            stacking: 'normal',
                            dataLabels: {
                                enabled: true,
                                format: '{point.y:,.0f} COP',
                            },
                        },
                    },
                    series: [
                        { name: 'Total Asignado', data: asignados, color: '#7cb5ec' },
                        { name: 'Total Pagado', data: pagados, color: '#90ed7d' },
                        { name: 'Por Comprometer', data: porComprometer, color: '#f7a35c' },
                    ],
                });
            })
            .catch(error => console.error("Error al generar gráfico de barras:", error));
    }

    // Listeners para cambios en los filtros
    function handleFiltersChange() {
        const resolucion = selectResolucion.value;
        const literal = selectLiteral.value;

        if (!resolucion || !literal) return;

        updateCard(resolucion, literal);
        updateCharts(resolucion, literal);
    }

    selectResolucion.addEventListener("change", handleFiltersChange);
    selectLiteral.addEventListener("change", handleFiltersChange);

    // Inicialización
    function loadFilters() {
        fetch('/node/api/resoluciones')
            .then(response => response.json())
            .then(data => {
                selectResolucion.innerHTML = '<option value="">Seleccione una Resolución</option>';
                data.forEach(res => {
                    const option = document.createElement("option");
                    option.value = res.numero_resolucion;
                    option.textContent = `Resolución ${res.numero_resolucion}`;
                    selectResolucion.appendChild(option);
                });
            });

        fetch('/node/api/literales')
            .then(response => response.json())
            .then(data => {
                selectLiteral.innerHTML = '<option value="">Seleccione un Literal</option>';
                data.forEach(literal => {
                    const option = document.createElement("option");
                    option.value = literal.nmliteral;
                    option.textContent = `Literal ${literal.nmliteral}`;
                    selectLiteral.appendChild(option);
                });
            });
    }

    loadFilters();
});
