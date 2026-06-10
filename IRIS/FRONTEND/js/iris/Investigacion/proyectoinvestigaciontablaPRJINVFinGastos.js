var DataTableProyectoInvestigacionFinancieroGastosPersonal = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoInvestigacionGastosPersonalform();

});


function InicializaFinancieroProyectoInvestigacionGastosPersonalform() {    
    if (DataTableProyectoInvestigacionFinancieroGastosPersonal != null) {
        DataTableProyectoInvestigacionFinancieroGastosPersonal.destroy();
    }

    LoadDataTableProyectoInvestigacionFinancieroGastosPersonal(); 

}

// function LoadDataTableProyectoInvestigacionFinancieroGastosPersonal() {
//     DataTableProyectoInvestigacionFinancieroGastosPersonal = $('#tblProyectoInvestigacionGastosPersonal').DataTable({
//         "language": {
//             "url": "/lib/dataTables/Language.json"
//         },
//         serverSide: true,
//         processing: true,
//         "search": {
//             "caseInsensitive": true
//         },
//         "ajax": {
//             "url": urlController + "Investigacion_Gasto/GetDataTableInvestigacion_GastoByProyecto", //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText + "&id_partida=1"
//             "data": {
//                 "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText } ,
//                 "id_partida": function() { return 1 } 
//             }
//         },      
//         "columns": [                    
//             { "data": "nombregasto", "orderable": true },
//             { "data": "NombreConcepto", "orderable": false },   
//             { "data": "Identificacion", "orderable": false },         
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
//                     return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Aplicar Pago" onclick="GenerarPagoGastoPersonalProyectoInvestigacion(' + row.id_asignacionproyecto + ',' + row.id_investigaciongasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
//                            '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarGastoPersonalProyectoInvestigacion(' + row.id_investigaciongasto + ')" /> ' + 
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
//             },    
//             { "targets": 11,
//             className: 'dt-body-right',
//            render: DataTable.render.number(',', '.', 0, '$ ') 
//         }              
//         ],               
//         dom: 'lBfrtip',
//         "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
//     });

// }
function LoadDataTableProyectoInvestigacionFinancieroGastosPersonal() {
    DataTableProyectoInvestigacionFinancieroGastosPersonal = $('#tblProyectoInvestigacionGastosPersonal').DataTable({
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
                "id_partida": function() { return 1 }
            }
        },      
        "columns": [                    
            { "data": "nombregasto", "orderable": true },
            { "data": "NombreConcepto", "orderable": false },   
            { "data": "Identificacion", "orderable": false },         
            { "data": "fechalegalizacionorden", "orderable": false, render: function (data, type, row, meta) { return row.fechalegalizacionorden.slice(0,10); } },
            { "data": "tipo", "orderable": true },
            { "data": "numorden", "orderable": true },
            { "data": "fechainicio", "orderable": false, render: function (data, type, row, meta) { return row.fechainicio.slice(0,10); } },
            { "data": "fechafinal", "orderable": false, render: function (data, type, row, meta) { return row.fechafinal.slice(0,10); } },
            { "data": "estado", "orderable": true },
            { "data": "valortotal", "orderable": false },
            { "data": "Total4mil", "orderable": false },
            { "data": "TotalPagado", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Aplicar Pago" onclick="GenerarPagoGastoPersonalProyectoInvestigacion(' + row.id_asignacionproyecto + ',' + row.id_investigaciongasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
                           '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarGastoPersonalProyectoInvestigacion(' + row.id_investigaciongasto + ')" /> ' + 
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Gasto" onclick="ValidarEliminarGastoProyectoInvestigacion(' + row.id_investigaciongasto + ',1)" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 8,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            },
            { "targets": 9,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            },
            { "targets": 10,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            },    
            { "targets": 11,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
        
        // Aquí agregamos la función createdRow para aplicar los colores
        "createdRow": function(row, data, dataIndex) {
            let valorPagado = data.TotalPagado || 0;
            let valorTotal = data.valortotal || 0;

            if (valorPagado === 0) {
                $(row).css('background-color', '#f8d7da'); // Rojo
            } else if (valorPagado < valorTotal) {
                $(row).css('background-color', '#fff3cd'); // Amarillo
            } else if (valorPagado >= valorTotal) {
                $(row).css('background-color', '#d4edda'); // Verde
            }
        }
    });
}


function RefreshDataTableProyectoInvestigacionFinancieroGastosPersonal() {
    DataTableProyectoInvestigacionFinancieroGastosPersonal.ajax.reload(null, false);
}

function CrearGastoPersonalProyectoInvestigacion() {
    CrearGasto_ProyectoInvestigacion(1);
}

function EditarGastoPersonalProyectoInvestigacion(id_investigaciongasto) {
    EditarGasto_ProyectoInvestigacion(id_investigaciongasto, 1);
}

function GenerarPagoGastoPersonalProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripcion, prestador ) {
    GenerarPagoGastoProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripcion, prestador, 'Gastos de Personal', 1 );
}