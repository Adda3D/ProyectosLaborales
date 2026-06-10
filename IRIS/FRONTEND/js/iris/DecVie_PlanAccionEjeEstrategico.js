var DataTableDecVie_PlanAccionEjeEstrategico = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionEjeEstrategico(); 
        
});

function LoadDataTableDecVie_PlanAccionEjeEstrategico() {
    DataTableDecVie_PlanAccionEjeEstrategico = $('#tblDecVie_PlanAccionEjeEstrategico').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionEjeEstrategico/GetDataTableDecVie_PlanAccionEjeEstrategico"
        },      
        "columns": [                    
            { "data": "id_ejeestrategico", "orderable": true },
            { "data": "ejeestrategico", "orderable": false },
            { "data": "descripcionejeestrategicodt", "orderable": true},
            { "data": "planaccionesestrategicadt", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_PlanAccionEjeEstrategico(' + row.id_ejeestrategico + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_PlanAccionEjeEstrategico(' + row.id_ejeestrategico + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.descripcionejeestrategico + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.planaccionesestrategica + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionEjeEstrategico() {
    DataTableDecVie_PlanAccionEjeEstrategico.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PlanAccionEjeEstrategico(idejeestrategico) {
    ShowDialogConfirmacion('','Seguro de eliminar el Eje seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionEjeEstrategico(idejeestrategico);
            }
        });
}

function EliminarDecVie_PlanAccionEjeEstrategico(idejeestrategico) {
    let urlEliminar = urlController + "DecVie_PlanAccionEjeEstrategico/DeleteDecVie_PlanAccionEjeEstrategico?id_ejeestrategico=" + idejeestrategico;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionEjeEstrategico();
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

function CrearDecVie_PlanAccionEjeEstrategico() {
    $("#spanIdDecVie_PlanAccionEjeEstrategico")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionEjeEstrategicoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionEjeEstrategicoDetalle.html', 'dvDecVie_PlanAccionEjeEstrategicoDetalle');
    }
    else {
        CrearDecVie_PlanAccionEjeEstrategicoform();
    }
}

function EditarDecVie_PlanAccionEjeEstrategico(idejeestrategico) {
    $("#spanIdDecVie_PlanAccionEjeEstrategico")[0].innerText = idejeestrategico;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionEjeEstrategicoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionEjeEstrategicoDetalle.html', 'dvDecVie_PlanAccionEjeEstrategicoDetalle');
    }
    else {
        EditarDecVie_PlanAccionEjeEstrategicoform(idejeestrategico);
    }

}
