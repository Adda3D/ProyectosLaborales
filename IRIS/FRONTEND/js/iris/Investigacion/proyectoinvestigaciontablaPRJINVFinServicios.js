var DataTableProyectoInvestigacionFinancieroGastosServicios = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoInvestigacionGastosServiciosform();

});


function InicializaFinancieroProyectoInvestigacionGastosServiciosform() {    
    if (DataTableProyectoInvestigacionFinancieroGastosServicios != null) {
        DataTableProyectoInvestigacionFinancieroGastosServicios.destroy();
    }

    LoadDataTableProyectoInvestigacionFinancieroGastosServicios(); 

}

// function LoadDataTableProyectoInvestigacionFinancieroGastosServicios() {
//     DataTableProyectoInvestigacionFinancieroGastosServicios = $('#tblProyectoInvestigacionGastosServicios').DataTable({
//         "language": {
//             "url": "/lib/dataTables/Language.json"
//         },
//         serverSide: true,
//         processing: true,
//         "search": {
//             "caseInsensitive": true
//         },
//         "ajax": {
//             "url": urlController + "Investigacion_Gasto/GetDataTableInvestigacion_GastoByProyecto", //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText + "&id_partida=3"
//             "data": {
//                 "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText } ,
//                 "id_partida": function() { return 3 } 
//             }
//         },      
//         "columns": [                    
//             { "data": "nombregasto", "orderable": true },
//             { "data": "NombreConcepto", "orderable": false },            
//             { "data": "fechalegalizacionorden", "orderable": false, render: function (data, type, row, meta) {return row.fechalegalizacionorden.slice(0,10)} },
//             { "data": "tipo", "orderable": true },
//             { "data": "numorden", "orderable": true },
//             { "data": "fechainicio", "orderable": false, render: function (data, type, row, meta) {return row.fechainicio.slice(0,10)} },
//             { "data": "fechafinal", "orderable": false, render: function (data, type, row, meta) {return row.fechafinal.slice(0,10)} },
//             { "data": "estado", "orderable": true },
//             { "data": "valortotal", "orderable": false },
//             { "data": "Total4mil", "orderable": false },
//             { "data": "TotalPagado", "orderable": false },
//             {
//                 render: function (data, type, row, meta) {
//                     return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Aplicar Pago" onclick="GenerarPagoGastoServiciosProyectoInvestigacion(' + row.id_asignacionproyecto + ',' + row.id_investigaciongasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
//                            '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarGastoServiciosProyectoInvestigacion(' + row.id_investigaciongasto + ')" /> ' + 
//                            '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Gasto" onclick="ValidarEliminarGastoProyectoInvestigacion(' + row.id_investigaciongasto + ',1)" /> ';
//                 },
//                 "className": "text-center", "orderable": false
//             }
//         ],  
//         "columnDefs": [
//             { "targets": 8,
//                 className: 'dt-body-right',
//                render: DataTable.render.number(',', '.', 0, '$ ') 
//             },
//             { "targets": 9,
//                 className: 'dt-body-right',
//                render: DataTable.render.number(',', '.', 0, '$ ') 
//             },
//             { "targets": 10,
//                 className: 'dt-body-right',
//                render: DataTable.render.number(',', '.', 0, '$ ') 
//             }            
//         ],               
//         dom: 'lBfrtip',
//         "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],

//         "createdRow": function(row, data, dataIndex) {
//             let valorPagado = parseFloat(data.TotalPagado) || 0;
//             let valorTotal = parseFloat(data.valortotal) || 0;
            
//             console.log("Valor Pagado:", valorPagado, "Valor Total:", valorTotal);  // Verifica los valores

//             if (valorPagado === 0) {
//                 $(row).css('background-color', '#f8d7da'); // Rojo
//             } else if (valorPagado < valorTotal) {
//                 $(row).css('background-color', '#fff3cd'); // Amarillo
//             } else if (valorPagado >= valorTotal) {
//                 $(row).css('background-color', '#d4edda'); // Verde
//             }
//         }


//     });

// }

function LoadDataTableProyectoInvestigacionFinancieroGastosServicios() {
    DataTableProyectoInvestigacionFinancieroGastosServicios = $('#tblProyectoInvestigacionGastosServicios').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Gasto/GetDataTableInvestigacion_GastoByProyecto", 
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText },
                "id_partida": function() { return 3 }  // Gastos de Servicios
            }
        },
        "columns": [                    
            { "data": "nombregasto", "orderable": true },
            { "data": "NombreConcepto", "orderable": false },            
            { "data": "fechalegalizacionorden", "orderable": false, render: function (data, type, row, meta) { return row.fechalegalizacionorden.slice(0,10)} },
            { "data": "tipo", "orderable": true },
            { "data": "numorden", "orderable": true },
            { "data": "fechainicio", "orderable": false, render: function (data, type, row, meta) { return row.fechainicio.slice(0,10)} },
            { "data": "fechafinal", "orderable": false, render: function (data, type, row, meta) { return row.fechafinal.slice(0,10)} },
            { "data": "estado", "orderable": true },
            { "data": "valortotal", "orderable": false },
            { "data": "Total4mil", "orderable": false },
            { "data": "TotalPagado", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Aplicar Pago" onclick="GenerarPagoGastoServiciosProyectoInvestigacion(' + row.id_asignacionproyecto + ',' + row.id_investigaciongasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
                           '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarGastoServiciosProyectoInvestigacion(' + row.id_investigaciongasto + ')" /> ' + 
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Gasto" onclick="ValidarEliminarGastoProyectoInvestigacion(' + row.id_investigaciongasto + ',1)" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 8, className: 'dt-body-right', render: DataTable.render.number(',', '.', 0, '$ ') },
            { "targets": 9, className: 'dt-body-right', render: DataTable.render.number(',', '.', 0, '$ ') },
            { "targets": 10, className: 'dt-body-right', render: DataTable.render.number(',', '.', 0, '$ ') }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
        
        // Aplicamos colores después de que la tabla se haya cargado completamente
        "createdRow": function(row, data, dataIndex) {
            // Usamos atributos data-* como respaldo
            const valorPagado = parseFloat(data.TotalPagado) || 0;
            const valorTotal = parseFloat(data.valortotal) || 0;
            
            $(row)
                .attr('data-pagado', valorPagado)
                .attr('data-total', valorTotal)
                .addClass('fila-protegida'); // Clase especial para identificarla
                
            aplicarEstiloDefinitivo(row, valorPagado, valorTotal);
        },
        
        "drawCallback": function(settings) {
            // Reforzamos los estilos después de cada redibujado
            this.api().rows().every(function() {
                const row = this.node();
                if ($(row).hasClass('fila-protegida')) {
                    const pagado = parseFloat($(row).attr('data-pagado')) || 0;
                    const total = parseFloat($(row).attr('data-total')) || 0;
                    aplicarEstiloDefinitivo(row, pagado, total);
                }
            });
        }
    });

    // Función de máxima prioridad para aplicar estilos
    function aplicarEstiloDefinitivo(row, pagado, total) {
        const color = pagado === 0 ? '#f8d7da' : 
                     pagado < total ? '#fff3cd' : '#d4edda';
        
        // Cuatro métodos diferentes para asegurar el color
        $(row).css('background-color', color);
        $(row).attr('data-color', color);
        $(row).addClass('fila-color-' + (pagado === 0 ? 'roja' : 
                       pagado < total ? 'amarilla' : 'verde'));
        
        // Estilo directo en el elemento como última instancia
        row.style.setProperty('background-color', color, 'important');
    }

    // Nuclear: Verificación periódica (solo para diagnóstico)
    setInterval(function() {
        $('#tblProyectoInvestigacionGastosServicios tr.fila-protegida').each(function() {
            const currentColor = $(this).css('background-color');
            const expectedColor = $(this).attr('data-color');
            
            if (currentColor !== expectedColor && expectedColor) {
                console.error('¡Sobrescritura detectada en fila!', {
                    element: this,
                    expected: expectedColor,
                    actual: currentColor
                });
                $(this).css('background-color', expectedColor);
            }
        });
    }, 1000);
}


function RefreshDataTableProyectoInvestigacionFinancieroGastosServicios() {
    DataTableProyectoInvestigacionFinancieroGastosServicios.ajax.reload(null, false);
}

function CrearGastoServiciosProyectoInvestigacion() {
    CrearGasto_ProyectoInvestigacion(3);
}

function EditarGastoServiciosProyectoInvestigacion(id_investigaciongasto) {
    EditarGasto_ProyectoInvestigacion(id_investigaciongasto, 3);
}

function GenerarPagoGastoServiciosProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripcion, prestador ) {
    GenerarPagoGastoProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripcion, prestador, 'Gastos Adquisición Servicios', 3 );
}