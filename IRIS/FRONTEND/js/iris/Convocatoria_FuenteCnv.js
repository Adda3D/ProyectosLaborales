var DataTableConvocatoria_FuenteCnv = null;

$(document).ready(function () {
    debugger;
    LoadDataTableConvocatoria_FuenteCnv(); 
        
});

function LoadDataTableConvocatoria_FuenteCnv() {
    DataTableConvocatoria_FuenteCnv = $('#tblConvocatoria_FuenteCnv').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Convocatoria_FuenteCnv/GetDataTableConvocatoria_FuenteCnv"
        },      
        "columns": [
            { "data": "nmfuentecnv", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarConvocatoria_FuenteCnv(' + row.id_fuentecnv + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarConvocatoria_FuenteCnv(' + row.id_fuentecnv + ');" /> ';
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

function RefreshDataTableConvocatoria_FuenteCnv() {
    DataTableConvocatoria_FuenteCnv.ajax.reload(null, false);
}

function ValidarEliminarConvocatoria_FuenteCnv(idfuentecnv) {
    ShowDialogConfirmacion('','Seguro de eliminar la Fuente seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria_FuenteCnv(idfuentecnv);
            }
        });
}

function EliminarConvocatoria_FuenteCnv(idfuentecnv) {
    let urlEliminar = urlController + "Convocatoria_FuenteCnv/DeleteConvocatoria_FuenteCnv?id_fuentecnv=" + idfuentecnv;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria_FuenteCnv();
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

function CrearConvocatoria_FuenteCnv() {
    $("#spanIdConvocatoria_FuenteCnv")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvConvocatoria_FuenteCnvDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_FuenteCnvDetalle.html', 'dvConvocatoria_FuenteCnvDetalle');
    }
    else {
        CrearConvocatoria_FuenteCnvform();
    }
}

function EditarConvocatoria_FuenteCnv(idfuentecnv) {
    $("#spanIdConvocatoria_FuenteCnv")[0].innerText = idfuentecnv;
    
    if (!ExisteDivEdicionDatos('dvConvocatoria_FuenteCnvDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_FuenteCnvDetalle.html', 'dvConvocatoria_FuenteCnvDetalle');
    }
    else {
        EditarConvocatoria_FuenteCnvform(idfuentecnv);
    }

}


