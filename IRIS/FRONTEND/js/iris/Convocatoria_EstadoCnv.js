var DataTableConvocatoria_EstadoCnv = null;

$(document).ready(function () {
    debugger;
    LoadDataTableConvocatoria_EstadoCnv(); 
        
});

function LoadDataTableConvocatoria_EstadoCnv() {
    DataTableConvocatoria_EstadoCnv = $('#tblConvocatoria_EstadoCnv').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Convocatoria_EstadoCnv/GetDataTableConvocatoria_EstadoCnv"
        },      
        "columns": [
            { "data": "nmestadocnv", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarConvocatoria_EstadoCnv(' + row.id_estadocnv + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarConvocatoria_EstadoCnv(' + row.id_estadocnv + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
           /* { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nmalcance + '">' + data : data;} 
            },*/
            /*{ "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }*/
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableConvocatoria_EstadoCnv() {
    DataTableConvocatoria_EstadoCnv.ajax.reload(null, false);
}

function ValidarEliminarConvocatoria_EstadoCnv(idestadocnv) {
    ShowDialogConfirmacion('','Seguro de eliminar el Estado seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria_EstadoCnv(idestadocnv);
            }
        });
}

function EliminarConvocatoria_EstadoCnv(idestadocnv) {
    let urlEliminar = urlController + "Convocatoria_EstadoCnv/DeleteConvocatoria_EstadoCnv?id_estadocnv=" + idestadocnv;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria_EstadoCnv();
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

function CrearConvocatoria_EstadoCnv() {
    $("#spanIdConvocatoria_EstadoCnv")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvConvocatoria_EstadoCnvDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_EstadoCnvDetalle.html', 'dvConvocatoria_EstadoCnvDetalle');
    }
    else {
        CrearConvocatoria_EstadoCnvform();
    }
}

function EditarConvocatoria_EstadoCnv(idestadocnv) {
    $("#spanIdConvocatoria_EstadoCnv")[0].innerText = idestadocnv;
    
    if (!ExisteDivEdicionDatos('dvConvocatoria_EstadoCnvDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_EstadoCnvDetalle.html', 'dvConvocatoria_EstadoCnvDetalle');
    }
    else {
        EditarConvocatoria_EstadoCnvform(idestadocnv);
    }

}


