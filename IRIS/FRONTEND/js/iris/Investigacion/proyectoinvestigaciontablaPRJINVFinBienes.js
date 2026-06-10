var DataTableProyectoInvestigacionFinancieroGastosBienes = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoInvestigacionGastosBienesform();

});


function InicializaFinancieroProyectoInvestigacionGastosBienesform() {    
    if (DataTableProyectoInvestigacionFinancieroGastosBienes != null) {
        DataTableProyectoInvestigacionFinancieroGastosBienes.destroy();
    }

    LoadDataTableProyectoInvestigacionFinancieroGastosBienes(); 

}

function LoadDataTableProyectoInvestigacionFinancieroGastosBienes() {
    DataTableProyectoInvestigacionFinancieroGastosBienes = $('#tblProyectoInvestigacionGastosBienes').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Gasto/GetDataTableInvestigacion_GastoByProyecto", //?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText + "&id_partida=2"
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText },
                "id_partida": function() { return 2 } 
            }
        },      
        "columns": [                    
            { "data": "nombregasto", "orderable": true },
            { "data": "NombreConcepto", "orderable": false },            
            { "data": "fechalegalizacionorden", "orderable": false, render: function (data, type, row, meta) {return row.fechalegalizacionorden.slice(0,10)} },
            { "data": "tipo", "orderable": true },
            { "data": "numorden", "orderable": true },
            { "data": "fechainicio", "orderable": false, render: function (data, type, row, meta) {return row.fechainicio.slice(0,10)} },
            { "data": "fechafinal", "orderable": false, render: function (data, type, row, meta) {return row.fechafinal.slice(0,10)} },
            { "data": "estado", "orderable": true },
            { "data": "valortotal", "orderable": false },
            { "data": "Total4mil", "orderable": false },
            { "data": "TotalPagado", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Aplicar Pago" onclick="GenerarPagoGastoBienesProyectoInvestigacion(' + row.id_asignacionproyecto + ',' + row.id_investigaciongasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
                           '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarGastoBienesProyectoInvestigacion(' + row.id_investigaciongasto + ')" /> ' + 
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
            }            
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoInvestigacionFinancieroGastosBienes() {
    DataTableProyectoInvestigacionFinancieroGastosBienes.ajax.reload(null, false);
}

function CrearGastoBienesProyectoInvestigacion() {
    CrearGasto_ProyectoInvestigacion(2);
}

function EditarGastoBienesProyectoInvestigacion(id_investigaciongasto) {
    EditarGasto_ProyectoInvestigacion(id_investigaciongasto, 2);
}

function GenerarPagoGastoBienesProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripcion, prestador ) {
    GenerarPagoGastoProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripcion, prestador, 'Gastos Adquisición Bienes', 2 );
}