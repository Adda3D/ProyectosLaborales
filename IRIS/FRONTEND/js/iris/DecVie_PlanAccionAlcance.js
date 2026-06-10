var DataTableDecVie_PlanAccionAlcance = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionAlcance(); 
        
});

function LoadDataTableDecVie_PlanAccionAlcance() {
    DataTableDecVie_PlanAccionAlcance = $('#tblDecVie_PlanAccionAlcance').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionAlcance/GetDataTableDecVie_PlanAccionAlcance"
        },      
        "columns": [                    
            { "data": "id_planaccionalcance", "orderable": true },
            { "data": "NombreAlcanceanno", "orderable": false },
            { "data": "descripcionalcance", "orderable": true },
            { "data": "observaciones", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_PlanAccionAlcance(' + row.id_planaccionalcance + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_PlanAccionAlcance(' + row.id_planaccionalcance + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.descripcionalcance + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionAlcance() {
    DataTableDecVie_PlanAccionAlcance.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PlanAccionAlcance(idplanaccionalcance) {
    ShowDialogConfirmacion('','Seguro de eliminar el Programa seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionAlcance(idplanaccionalcance);
            }
        });
}

function EliminarDecVie_PlanAccionAlcance(idplanaccionalcance) {
    let urlEliminar = urlController + "DecVie_PlanAccionAlcance/DeleteDecVie_PlanAccionAlcance?id_planaccionalcance=" + idplanaccionalcance;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionAlcance();
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

function CrearDecVie_PlanAccionAlcance() {
    $("#spanIdDecVie_PlanAccionAlcance")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionAlcanceDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionAlcanceDetalle.html', 'dvDecVie_PlanAccionAlcanceDetalle');
    }
    else {
        CrearDecVie_PlanAccionAlcanceform();
    }
}

function EditarDecVie_PlanAccionAlcance(idplanaccionalcance) {
    $("#spanIdDecVie_PlanAccionAlcance")[0].innerText = idplanaccionalcance;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionAlcanceDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionAlcanceDetalle.html', 'dvDecVie_PlanAccionAlcanceDetalle');
    }
    else {
        EditarDecVie_PlanAccionAlcanceform(idplanaccionalcance);
    }

}
