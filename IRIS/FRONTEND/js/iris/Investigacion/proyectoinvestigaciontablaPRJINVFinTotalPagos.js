var DataTableProyectoInvestigacionFinancieroListaPagos = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoInvestigacionListaPagosform();

});


function InicializaFinancieroProyectoInvestigacionListaPagosform() {    
    if (DataTableProyectoInvestigacionFinancieroListaPagos != null) {
        DataTableProyectoInvestigacionFinancieroListaPagos.destroy();
    }

    LoadDataTableProyectoInvestigacionFinancieroListaPagos(); 

}

// function LoadDataTableProyectoInvestigacionFinancieroListaPagos() {
//     DataTableProyectoInvestigacionFinancieroListaPagos = $('#tblProyectoInvestigacionListaPagos').DataTable({
//         "language": {
//             "url": "/lib/dataTables/Language.json"
//         },
//         serverSide: true,
//         processing: true,
//         "search": {
//             "caseInsensitive": true
//         },
//         "ajax": {
//             "url": urlController + "Investigacion_Aplicarpago/GetDataTableInvestigacion_AplicarpagoByProyecto", 
//             "data": {
//                 "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText }            
//             }
//         },      
//         "columns": [                    
//             { "data": "fechapago", "orderable": true, render: function (data, type, row, meta) {return row.fechapago.slice(0,10)} },
//             { "data": "ObjGasto.NombrePersona", "orderable": false },            
//             { "data": "ObjGasto.NombreRubro", "orderable": false },
//             { "data": "ObjGasto.NombreConcepto", "orderable": false },
//             { "data": "orpa", "orderable": true },
//             { "data": "cp_egr", "orderable": true },
//             { "data": "valorneto", "orderable": false },
//             {
//                 render: function (data, type, row, meta) {
//                     return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Pago" onclick="ValidarEliminarPagoRealizadoProyectoInvestigacion(' + row.id_investigacionpago + ')" /> ';
//                 },
//                 "className": "text-center", "orderable": false
//             }
//         ],  
//         "columnDefs": [
//             { "targets": 6,
//                 className: 'dt-body-right',
//                render: DataTable.render.number(',', '.', 0, '$ ') 
//             }
//         ],               
//         dom: 'lBfrtip',
//         "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
//     });

// }

function LoadDataTableProyectoInvestigacionFinancieroListaPagos() {
    DataTableProyectoInvestigacionFinancieroListaPagos = $('#tblProyectoInvestigacionListaPagos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_Aplicarpago/GetDataTableInvestigacion_AplicarpagoByProyecto",
            "data": {
                "id_crearproyecto": function() { return $("#spanIdProyectoInvestigacion")[0].innerText }
            }
        },
        "columns": [
            { "data": "fechapago", "orderable": true, render: function (data, type, row, meta) { return row.fechapago.slice(0, 10) } },
            { "data": "ObjGasto.NombrePersona", "orderable": false },
            { "data": "ObjGasto.NombreRubro", "orderable": false },
            { "data": "ObjGasto.NombreConcepto", "orderable": false },
            { "data": "orpa", "orderable": true },
            { "data": "cp_egr", "orderable": true },
            { "data": "valorneto", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Pago" onclick="ValidarEliminarPagoRealizadoProyectoInvestigacion(' + row.id_investigacionpago + ')" /> ';
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
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]]
    });
}


function RefreshDataTableProyectoInvestigacionFinancieroListaPagos() {
    DataTableProyectoInvestigacionFinancieroListaPagos.ajax.reload(null, false);
}

function ValidarEliminarPagoRealizadoProyectoInvestigacion(id_investigacionpago) {
    ShowDialogConfirmacion('','Seguro de eliminar pago realizado ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPagoGastoProyectoInvestigacion(id_investigacionpago);
            }
        });

}

function EliminarPagoGastoProyectoInvestigacion(id_investigacionpago) {
    let urlEliminar = urlController + "Investigacion_Aplicarpago/DeleteInvestigacion_Aplicarpago?id_investigacionpago=" + id_investigacionpago;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionFinancieroListaPagos();
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
