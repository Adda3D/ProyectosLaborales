var DataTableDecVie_PlanAccionProgramaPgd = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionProgramaPgd(); 
        
});

function LoadDataTableDecVie_PlanAccionProgramaPgd() {
    DataTableDecVie_PlanAccionProgramaPgd = $('#tblDecVie_PlanAccionProgramaPgd').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionProgramaPgd/GetDataTableDecVie_PlanAccionProgramaPgd"
        },      
        "columns": [                    
            { "data": "id_programapgd", "orderable": true },
            { "data": "nmprogramapgd", "orderable": true },
            { "data": "descripcionprogramapgd", "orderable": true },
            { "data": "estrategiaprogramapgd", "orderable": true },
            //{ "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_PlanAccionProgramaPgd(' + row.id_programapgd + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_PlanAccionProgramaPgd(' + row.id_programapgd + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.descripcionprogramapgd + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.estrategiaprogramapgd + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionProgramaPgd() {
    DataTableDecVie_PlanAccionProgramaPgd.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PlanAccionProgramaPgd(idprogramapgd) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionProgramaPgd(idprogramapgd);
            }
        });
}

function EliminarDecVie_PlanAccionProgramaPgd(idprogramapgd) {
    let urlEliminar = urlController + "DecVie_PlanAccionProgramaPgd/DeleteDecVie_PlanAccionProgramaPgd?id_programapgd=" + idprogramapgd;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionProgramaPgd();
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

function CrearDecVie_PlanAccionProgramaPgd() {
    $("#spanIdDecVie_PlanAccionProgramaPgd")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionProgramaPgdDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionProgramaPgdDetalle.html', 'dvDecVie_PlanAccionProgramaPgdDetalle');
    }
    else {
        CrearDecVie_PlanAccionProgramaPgdform();
    }
}

function EditarDecVie_PlanAccionProgramaPgd(idprogramapgd) {
    $("#spanIdDecVie_PlanAccionProgramaPgd")[0].innerText = idprogramapgd;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionProgramaPgdDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionProgramaPgdDetalle.html', 'dvDecVie_PlanAccionProgramaPgdDetalle');
    }
    else {
        EditarDecVie_PlanAccionProgramaPgdform(idprogramapgd);
    }

}
