var DataTableDecVie_PlanAccionProgramaFdcps = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionProgramaFdcps(); 
        
});

function LoadDataTableDecVie_PlanAccionProgramaFdcps() {
    DataTableDecVie_PlanAccionProgramaFdcps = $('#tblDecVie_PlanAccionProgramaFdcps').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionProgramaFdcps/GetDataTableDecVie_PlanAccionProgramaFdcps"
        },      
        "columns": [                    
            { "data": "id_programafdcps", "orderable": true },
            { "data": "programafacultad", "orderable": false },
            { "data": "descripcionprogramafacultad", "orderable": true },
            //{ "data": "estrategiaprogramapgd", "orderable": true },
            //{ "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_PlanAccionProgramaFdcps(' + row.id_programafdcps + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_PlanAccionProgramaFdcps(' + row.id_programafdcps + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nombreproyecto + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionProgramaFdcps() {
    DataTableDecVie_PlanAccionProgramaFdcps.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PlanAccionProgramaFdcps(idprogramafdcps) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionProgramaFdcps(idprogramafdcps);
            }
        });
}

function EliminarDecVie_PlanAccionProgramaFdcps(idprogramafdcps) {
    let urlEliminar = urlController + "DecVie_PlanAccionProgramaFdcps/DeleteDecVie_PlanAccionProgramaFdcps?id_programafdcps=" + idprogramafdcps;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionProgramaFdcps();
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

function CrearDecVie_PlanAccionProgramaFdcps() {
    $("#spanIdDecVie_PlanAccionProgramaFdcps")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionProgramaFdcpsDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionProgramaFdcpsDetalle.html', 'dvDecVie_PlanAccionProgramaFdcpsDetalle');
    }
    else {
        CrearDecVie_PlanAccionProgramaFdcpsform();
    }
}

function EditarDecVie_PlanAccionProgramaFdcps(idprogramafdcps) {
    $("#spanIdDecVie_PlanAccionProgramaFdcps")[0].innerText = idprogramafdcps;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionProgramaFdcpsDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionProgramaFdcpsDetalle.html', 'dvDecVie_PlanAccionProgramaFdcpsDetalle');
    }
    else {
        EditarDecVie_PlanAccionProgramaFdcpsform(idprogramafdcps);
    }

}
