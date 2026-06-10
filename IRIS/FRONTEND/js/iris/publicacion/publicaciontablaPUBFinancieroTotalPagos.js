var DataTablePublicacionFinancieroListaPagos = null;

$(document).ready(function () {    
    InicializaFinancieroPublicacionListaPagosform();

});


function InicializaFinancieroPublicacionListaPagosform() {    
    if (DataTablePublicacionFinancieroListaPagos != null) {
        DataTablePublicacionFinancieroListaPagos.destroy();
    }

    LoadDataTablePublicacionFinancieroListaPagos(); 

}

function LoadDataTablePublicacionFinancieroListaPagos() {
    DataTablePublicacionFinancieroListaPagos = $('#tblPublicacionListaPagos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicacion_Aplicarpago/GetDataTablePublicacion_AplicarpagoByPublicacion", 
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }            
            }
        },      
        "columns": [                    
            { "data": "fechapago", "orderable": true, render: function (data, type, row, meta) {return row.fechapago.slice(0,10)} },
            { "data": "ObjGasto.NombrePersona", "orderable": false },            
            { "data": "ObjGasto.NombreRubro", "orderable": false },
            { "data": "ObjGasto.NombreConcepto", "orderable": false },
            { "data": "orpa", "orderable": true },
            { "data": "cp_egr", "orderable": true },
            { "data": "valorneto", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Pago" onclick="ValidarEliminarPagoRealizadoPublicacion(' + row.id_publicacionpago + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 6,
                className: 'dt-body-right',
               render: DataTable.render.number(',', '.', 0, '$ ') 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicacionFinancieroListaPagos() {
    DataTablePublicacionFinancieroListaPagos.ajax.reload(null, false);
}

function ValidarEliminarPagoRealizadoPublicacion(id_publicacionpago) {
    ShowDialogConfirmacion('','Seguro de eliminar pago realizado ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPagoGastoPublicacion(id_publicacionpago);
            }
        });

}

function EliminarPagoGastoPublicacion(id_publicacionpago) {
    let urlEliminar = urlController + "Publicacion_Aplicarpago/DeletePublicacion_Aplicarpago?id_publicacionpago=" + id_publicacionpago;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicacionFinancieroListaPagos();
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
