var DataTableProyectoExtensionFinancieroGastoAdquisicionBienes = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoExtensionGastoAdquisicionBienesform($("#spanIdProyectoExtension")[0].innerText);

});


function InicializaFinancieroProyectoExtensionGastoAdquisicionBienesform(id_asignacionproyecto) {
    $("#spanIdProyectoExtensionFinanciero")[0].innerText = id_asignacionproyecto; 

    
    if (DataTableProyectoExtensionFinancieroGastoAdquisicionBienes != null) {
        DataTableProyectoExtensionFinancieroGastoAdquisicionBienes.destroy();
    }

    LoadDataTableProyectoExtensionFinancieroGastoAdquisicionBienes(); 

}

function LoadDataTableProyectoExtensionFinancieroGastoAdquisicionBienes() {
    DataTableProyectoExtensionFinancieroGastoAdquisicionBienes = $('#tblProyectoExtensionGastoAdquisicionBienes').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Seguimiento_CrearGasto/GetDataTableProyectoGastosByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionFinanciero")[0].innerText + "&id_partida=2"
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionFinanciero")[0].innerText },
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
                    return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Generar Pago" onclick="GenerarPagoAdquisicionBienesProyectoExtension(' + row.id_asignacionproyecto + ',' + row.id_creargasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
                           '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarAdquisicionBienesProyectoExtension(' + row.id_creargasto + ')" /> ' + 
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Gasto" onclick="ValidarEliminarGastoProyectoExtension(' + row.id_creargasto + ',2)" /> ';
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

function RefreshDataTableProyectoExtensionFinancieroGastoAdquisicionBienes() {
    DataTableProyectoExtensionFinancieroGastoAdquisicionBienes.ajax.reload(null, false);
}

function CrearGastoAdquisicionBienesProyectoExtension() {
    CrearProyectoExtensionCrearGasto(2);
}

function EditarAdquisicionBienesProyectoExtension(id_creargasto) {
    EditarProyectoExtensionCrearGasto(id_creargasto, 2);
}

function GenerarPagoAdquisicionBienesProyectoExtension(idproyecto, id_creargasto, rubro, descripcion, prestador ) {
    GenerarPagoGastoProyectoExtension(idproyecto, id_creargasto, rubro, descripcion, prestador, 'Adquisición de bienes', 2 );
}