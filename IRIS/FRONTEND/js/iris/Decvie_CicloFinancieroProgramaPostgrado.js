var DataTableDecvie_CicloFinancieroProgramaPostgrado = null;

$(document).ready(function () {
    LoadDataTableDecvie_CicloFinancieroProgramaPostgrado(); 
    var spanElement = $("#spanIdDecvie_CicloFinancieroProgramaPostgrado")[0];
    if (spanElement) {
        console.log("El span existe:", spanElement);
    } else {
        console.error("El span #spanIdDecvie_CicloFinancieroProgramaPostgrado no existe");
    }
        
});

function LoadDataTableDecvie_CicloFinancieroProgramaPostgrado() {
    DataTableDecvie_CicloFinancieroProgramaPostgrado = $('#tblDecvie_CicloFinancieroProgramaPostgrado').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Decvie_CicloFinancieroProgramaPostgrado/GetDataTableDecvie_CicloFinancieroProgramaPostgrado"
        },      
        "columns": [                    
            { "data": "tipoprograma", "orderable": true },
            { "data": "nmprogramapostgrado", "orderable": false },            
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecvie_CicloFinancieroProgramaPostgrado(' + row.id_programapostgrado + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecvie_CicloFinancieroProgramaPostgrado(' + row.id_programapostgrado + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.tipoprograma + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nmprogramapostgrado + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecvie_CicloFinancieroProgramaPostgrado() {
    DataTableDecvie_CicloFinancieroProgramaPostgrado.ajax.reload(null, false);
}

function ValidarEliminarDecvie_CicloFinancieroProgramaPostgrado(idprogramapostgrado) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecvie_CicloFinancieroProgramaPostgrado(idprogramapostgrado);
            }
        });
}

function EliminarDecvie_CicloFinancieroProgramaPostgrado(idprogramapostgrado) {
    let urlEliminar = urlController + "Decvie_CicloFinancieroProgramaPostgrado/DeleteDecvie_CicloFinancieroProgramaPostgrado?id_programapostgrado=" + idprogramapostgrado;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecvie_CicloFinancieroProgramaPostgrado();
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

function CrearDecvie_CicloFinancieroProgramaPostgrado() {
    $("#spanIdDecvie_CicloFinancieroProgramaPostgrado")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecvie_CicloFinancieroProgramaPostgradoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_CicloFinancieroProgramaPostgradoDetalle.html', 'dvDecvie_CicloFinancieroProgramaPostgradoDetalle');
    }
    else {
        CrearDecvie_CicloFinancieroProgramaPostgradoform();
    }
}

function EditarDecvie_CicloFinancieroProgramaPostgrado(idprogramapostgrado) {
    $("#spanIdDecvie_CicloFinancieroProgramaPostgrado")[0].innerText = idprogramapostgrado;
    
    if (!ExisteDivEdicionDatos('dvDecvie_CicloFinancieroProgramaPostgradoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/Decvie_CicloFinancieroProgramaPostgradoDetalle.html', 'dvDecvie_CicloFinancieroProgramaPostgradoDetalle');
    }
    else {
        EditarDecvie_CicloFinancieroProgramaPostgradoform(idprogramapostgrado);
    }

}
