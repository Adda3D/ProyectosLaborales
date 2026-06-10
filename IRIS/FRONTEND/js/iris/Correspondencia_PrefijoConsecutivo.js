//"../js/iris/Correspondencia_PrefijoConsecutivo.js"
var DataTableCorrespondencia_PrefijoConsecutivo = null;

$(document).ready(function () {
    LoadDataTableCorrespondencia_PrefijoConsecutivo(); 
        
});

function LoadDataTableCorrespondencia_PrefijoConsecutivo() {
    DataTableCorrespondencia_PrefijoConsecutivo = $('#tblCorrespondencia_PrefijoConsecutivo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Correspondencia_PrefijoConsecutivo/GetDataTableCorrespondencia_PrefijoConsecutivo"
        },      
        "columns": [                    
            { "data": "id_prefijoconsecutivo", "orderable": true },
            { "data": "nmprefijo", "orderable": true },
            { "data": "prefijo", "orderable": true },
            { "data": "NombreDependencia", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarCorrespondencia_PrefijoConsecutivo(' + row.id_prefijoconsecutivo + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarCorrespondencia_PrefijoConsecutivo(' + row.id_prefijoconsecutivo + ',`' + row.nmprefijo + '`);" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nmprefijo + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableCorrespondencia_PrefijoConsecutivo() {
    DataTableCorrespondencia_PrefijoConsecutivo.ajax.reload(null, false);
}

function ValidarEliminarCorrespondencia_PrefijoConsecutivo(idprefijoconsecutivo, nmprefijo) {
    ShowDialogConfirmacion('','Seguro de eliminar el Prefijo ' + nmprefijo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarCorrespondencia_PrefijoConsecutivo(idprefijoconsecutivo);
            }
        });
}

function EliminarCorrespondencia_PrefijoConsecutivo(idprefijoconsecutivo) {
    let urlEliminar = urlController + "Correspondencia_PrefijoConsecutivo/DeleteCorrespondencia_PrefijoConsecutivo?id_prefijoconsecutivo=" + idprefijoconsecutivo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableCorrespondencia_PrefijoConsecutivo();
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

function CrearCorrespondencia_PrefijoConsecutivo() {
    $("#spanIdCorrespondencia_PrefijoConsecutivo")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvCorrespondencia_PrefijoConsecutivoDetalle')) {
        CrearDivEdicionDatos('/Pages/Consecutivo/Correspondencia_PrefijoConsecutivoDetalle.html', 'dvCorrespondencia_PrefijoConsecutivoDetalle');
    }
    else {
        CrearCorrespondencia_PrefijoConsecutivoform();
    }
}

function EditarCorrespondencia_PrefijoConsecutivo(idprefijoconsecutivo) {
    $("#spanIdCorrespondencia_PrefijoConsecutivo")[0].innerText = idprefijoconsecutivo;
    
    if (!ExisteDivEdicionDatos('dvCorrespondencia_PrefijoConsecutivoDetalle')) {
        CrearDivEdicionDatos('/Pages/Consecutivo/Correspondencia_PrefijoConsecutivoDetalle.html', 'dvCorrespondencia_PrefijoConsecutivoDetalle');
    }
    else {
        EditarCorrespondencia_PrefijoConsecutivoform(idprefijoconsecutivo);
    }

}
