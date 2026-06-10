document.addEventListener('DOMContentLoaded', function () {
    // Gráfico de Inscritos por Semestre y Programa
    fetch('/node/inscritos-semestre-programa')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const programas = [...new Set(data.map(item => item.nmprogramapostgrado))];
            const semestres = [...new Set(data.map(item => item.nmsemestre))];
            const series = semestres.map(semestre => ({
                name: semestre,
                data: programas.map(programa => {
                    const item = data.find(d => d.nmprogramapostgrado === programa && d.nmsemestre === semestre);
                    return item ? parseInt(item.inscritos, 10) : 0;
                })
            }));

            Highcharts.chart('inscritos-semestre-programa', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Total de Inscritos por Semestre y Programa',
                    align: 'left'
                },
                xAxis: {
                    categories: programas,
                    title: {
                        text: 'Programas'
                    },
                    gridLineWidth: 1,
                    lineWidth: 0
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Número de Inscritos',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    },
                    gridLineWidth: 0
                },
                tooltip: {
                    valueSuffix: ' inscritos',
                    shared: true,
                    useHTML: true,
                    headerFormat: '<small>{point.key}</small><table>',
                    pointFormat: '<tr><td style="color: {series.color}">{series.name}: </td>' +
                                 '<td style="text-align: right"><b>{point.y}</b></td></tr>',
                    footerFormat: '</table>'
                },
                plotOptions: {
                    bar: {
                        stacking: 'normal',
                        borderRadius: 5,
                        dataLabels: {
                            enabled: true
                        },
                        groupPadding: 0.1
                    }
                },
                credits: {
                    enabled: false
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -40,
                    y: 80,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor:
                        Highcharts.defaultOptions.legend.backgroundColor || '#FFFFFF',
                    shadow: true
                },
                series: series
            });
        })
        .catch(error => {
            console.error('Error al obtener los datos:', error);
        });

    // Gráfico de Matriculados por Semestre y Programa
    fetch('/node/matriculados-semestre-programa')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const programas = [...new Set(data.map(item => item.nmprogramapostgrado))];
            const semestres = [...new Set(data.map(item => item.nmsemestre))];
            const series = semestres.map(semestre => ({
                name: semestre,
                data: programas.map(programa => {
                    const item = data.find(d => d.nmprogramapostgrado === programa && d.nmsemestre === semestre);
                    return item ? parseInt(item.matriculados, 10) : 0;
                })
            }));

            Highcharts.chart('matriculados-semestre-programa', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Total de Matriculados por Semestre y Programa',
                    align: 'left'
                },
                xAxis: {
                    categories: programas,
                    title: {
                        text: 'Programas'
                    },
                    gridLineWidth: 1,
                    lineWidth: 0
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Número de Matriculados',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    },
                    gridLineWidth: 0
                },
                tooltip: {
                    valueSuffix: ' matriculados',
                    shared: true,
                    useHTML: true,
                    headerFormat: '<small>{point.key}</small><table>',
                    pointFormat: '<tr><td style="color: {series.color}">{series.name}: </td>' +
                                 '<td style="text-align: right"><b>{point.y}</b></td></tr>',
                    footerFormat: '</table>'
                },
                plotOptions: {
                    bar: {
                        stacking: 'normal',
                        borderRadius: 5,
                        dataLabels: {
                            enabled: true
                        },
                        groupPadding: 0.1
                    }
                },
                credits: {
                    enabled: false
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -40,
                    y: 80,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor:
                        Highcharts.defaultOptions.legend.backgroundColor || '#FFFFFF',
                    shadow: true
                },
                series: series
            });
        })
        .catch(error => {
            console.error('Error al obtener los datos:', error);
        });

    // Gráfico de Costo del Programa por Semestre y Programa
    fetch('/node/costo-semestre-programa')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const programas = [...new Set(data.map(item => item.nmprogramapostgrado))];
            const semestres = [...new Set(data.map(item => item.nmsemestre))];
            const series = semestres.map(semestre => ({
                name: semestre,
                data: programas.map(programa => {
                    const item = data.find(d => d.nmprogramapostgrado === programa && d.nmsemestre === semestre);
                    return item ? parseFloat(item.costosemprog) : 0;
                })
            }));

            Highcharts.chart('costo-semestre-programa', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Costo del Programa por Semestre y Programa',
                    align: 'left'
                },
                xAxis: {
                    categories: programas,
                    title: {
                        text: 'Programas'
                    },
                    gridLineWidth: 1,
                    lineWidth: 0
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Costo del Programa',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    },
                    gridLineWidth: 0
                },
                tooltip: {
                    valueSuffix: ' costo',
                    shared: true,
                    useHTML: true,
                    headerFormat: '<small>{point.key}</small><table>',
                    pointFormat: '<tr><td style="color: {series.color}">{series.name}: </td>' +
                                 '<td style="text-align: right"><b>{point.y}</b></td></tr>',
                    footerFormat: '</table>'
                },
                plotOptions: {
                    bar: {
                        stacking: 'normal',
                        borderRadius: 5,
                        dataLabels: {
                            enabled: true
                        },
                        groupPadding: 0.1
                    }
                },
                credits: {
                    enabled: false
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -40,
                    y: 80,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor:
                        Highcharts.defaultOptions.legend.backgroundColor || '#FFFFFF',
                    shadow: true
                },
                series: series
            });
        })
        .catch(error => {
            console.error('Error al obtener los datos:', error);
        });
});
