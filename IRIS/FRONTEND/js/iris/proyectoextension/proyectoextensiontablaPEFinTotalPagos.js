var DataTableProyectoExtensionFinancieroListaPagos = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoExtensionListaPagosform();

});


function InicializaFinancieroProyectoExtensionListaPagosform() {    
    if (DataTableProyectoExtensionFinancieroListaPagos != null) {
        DataTableProyectoExtensionFinancieroListaPagos.destroy();
    }

    LoadDataTableProyectoExtensionFinancieroListaPagos(); 

}

function LoadDataTableProyectoExtensionFinancieroListaPagos() {
    DataTableProyectoExtensionFinancieroListaPagos = $('#tblProyectoExtensionListaPagos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Seguimiento_AplicarPago/GetDataTablePagosByProyecto", 
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtension")[0].innerText }            
            }
        },      
        "columns": [                    
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "ObjGasto.NombrePersona", "orderable": false },            
            { "data": "ObjGasto.NombreRubro", "orderable": false },
            { "data": "ObjGasto.NombreConcepto", "orderable": false },
            { "data": "ObjGasto.tipo", "orderable": false },
            { "data": "ObjGasto.numorden", "orderable": false },
            { "data": "orpa", "orderable": true },
            { "data": "cp_egr", "orderable": true },
            { "data": "valorneto", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Pago" onclick="ValidarEliminarPagoRealizadoProyectoExtension(' + row.id_aplicarpago + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 8,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ')
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionFinancieroListaPagos() {
    DataTableProyectoExtensionFinancieroListaPagos.ajax.reload(null, false);
}

function ValidarEliminarPagoRealizadoProyectoExtension(id_aplicarpago) {
    ShowDialogConfirmacion('','Seguro de eliminar pago realizado ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPagoGastoProyectoExtension(id_aplicarpago);
            }
        });

}

function EliminarPagoGastoProyectoExtension(id_aplicarpago) {
    let urlEliminar = urlController + "Seguimiento_AplicarPago/DeleteSeguimiento_AplicarPago?id_aplicarpago=" + id_aplicarpago;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionFinancieroListaPagos();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}
