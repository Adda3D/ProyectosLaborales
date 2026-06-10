var DataTableConvocatoria_Alcance = null;

$(document).ready(function () {
    debugger;
    LoadDataTableConvocatoria_Alcance(); 
        
});

function LoadDataTableConvocatoria_Alcance() {
    DataTableConvocatoria_Alcance = $('#tblConvocatoria_Alcance').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Convocatoria_Alcance/GetDataTableConvocatoria_Alcance"
        },      
        "columns": [
            { "data": "nmalcance", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarConvocatoria_Alcance(' + row.id_alcance + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarConvocatoria_Alcance(' + row.id_alcance + ');" /> ';
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

function RefreshDataTableConvocatoria_Alcance() {
    DataTableConvocatoria_Alcance.ajax.reload(null, false);
}

function ValidarEliminarConvocatoria_Alcance(idalcance) {
    ShowDialogConfirmacion('','Seguro de eliminar el Alcance seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarConvocatoria_Alcance(idalcance);
            }
        });
}

function EliminarConvocatoria_Alcance(idalcance) {
    let urlEliminar = urlController + "Convocatoria_Alcance/DeleteConvocatoria_Alcance?id_alcance=" + idalcance;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableConvocatoria_Alcance();
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

function CrearConvocatoria_Alcance() {
    $("#spanIdConvocatoria_Alcance")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvConvocatoria_AlcanceDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_AlcanceDetalle.html', 'dvConvocatoria_AlcanceDetalle');
    }
    else {
        CrearConvocatoria_Alcanceform();
    }
}

function EditarConvocatoria_Alcance(idalcance) {
    
    $("#spanIdConvocatoria_Alcance")[0].innerText = idalcance;
    
    if (!ExisteDivEdicionDatos('dvConvocatoria_AlcanceDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Convocatoria_AlcanceDetalle.html', 'dvConvocatoria_AlcanceDetalle');
    }
    else {
        EditarConvocatoria_Alcanceform(idalcance);
    }

}


