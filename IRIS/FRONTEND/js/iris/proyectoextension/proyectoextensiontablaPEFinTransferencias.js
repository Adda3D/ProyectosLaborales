var DataTableProyectoExtensionFinancieroTransferencias = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoExtensionTransferenciasform($("#spanIdProyectoExtension")[0].innerText);

});


function InicializaFinancieroProyectoExtensionTransferenciasform(id_asignacionproyecto) {
    $("#spanIdProyectoExtensionFinanciero")[0].innerText = id_asignacionproyecto; 

    
    if (DataTableProyectoExtensionFinancieroTransferencias != null) {
        DataTableProyectoExtensionFinancieroTransferencias.destroy();
    }

    LoadDataTableProyectoExtensionFinancieroTransferencias(); 

}

function LoadDataTableProyectoExtensionFinancieroTransferencias() {
    DataTableProyectoExtensionFinancieroTransferencias = $('#tblProyectoExtensionTransferencias').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Seguimiento_CrearGasto/GetDataTableProyectoGastosByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionFinanciero")[0].innerText + "&id_partida=5"
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionFinanciero")[0].innerText },
                "id_partida": function() { return 5 } 
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
                    return '<img src="../images/iris/pagos.png" class="cambiarMouse" title="Generar Pago" onclick="GenerarPagoTransferenciasProyectoExtension(' + row.id_asignacionproyecto + ',' + row.id_creargasto + ',`' + row.NombreRubro + '`,`' + row.nombregasto + '`,`' + row.NombrePersona + '`);" /> ' +
                           '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos Gasto" onclick="EditarTransferenciasProyectoExtension(' + row.id_creargasto + ')" /> ' + 
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Gasto" onclick="ValidarEliminarGastoProyectoExtension(' + row.id_creargasto + ',5)" /> ';
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

function RefreshDataTableProyectoExtensionFinancieroTransferencias() {
    DataTableProyectoExtensionFinancieroTransferencias.ajax.reload(null, false);
}

function CrearTransferenciasProyectoExtension() {
    CrearProyectoExtensionCrearGasto(5);
}

function EditarTransferenciasProyectoExtension(id_creargasto) {
    EditarProyectoExtensionCrearGasto(id_creargasto, 5);
}

function GenerarPagoTransferenciasProyectoExtension(idproyecto, id_creargasto, rubro, descripcion, prestador ) {
    GenerarPagoGastoProyectoExtension(idproyecto, id_creargasto, rubro, descripcion, prestador, 'Transferencias entre fondos', 5 );
}