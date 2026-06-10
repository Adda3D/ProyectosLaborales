var DataTableDecVie_PlanAccionMatryoshka = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionMatryoshka(); 
        
});

function LoadDataTableDecVie_PlanAccionMatryoshka() {
    DataTableDecVie_PlanAccionMatryoshka = $('#tblDecVie_PlanAccionMatryoshka').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionMatryoshka/GetDataTableDecVie_PlanAccionMatryoshka"
        },      
        "columns": [                    
            { "data": "id_matryoshka", "orderable": true },
            { "data": "NombreLineapolitica", "orderable": false },
            { "data": "NombreEjeEstrategico", "orderable": false },
            { "data": "NombreObjetivoEstrategico", "orderable": false },
            { "data": "NombreProgramaPGD", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_PlanAccionMatryoshka(' + row.id_matryoshka + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_PlanAccionMatryoshka(' + row.id_matryoshka + ');" /> ';
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

function RefreshDataTableDecVie_PlanAccionMatryoshka() {
    DataTableDecVie_PlanAccionMatryoshka.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PlanAccionMatryoshka(idmatryoshka) {
    ShowDialogConfirmacion('','Seguro de eliminar la Matryoshka seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionMatryoshka(idmatryoshka);
            }
        });
}

function EliminarDecVie_PlanAccionMatryoshka(idmatryoshka) {
    let urlEliminar = urlController + "DecVie_PlanAccionMatryoshka/DeleteDecVie_PlanAccionMatryoshka?id_matryoshka=" + idmatryoshka;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionMatryoshka();
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

function CrearDecVie_PlanAccionMatryoshka() {
    $("#spanIdDecVie_PlanAccionMatryoshka")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionMatryoshkaDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionMatryoshkaDetalle.html', 'dvDecVie_PlanAccionMatryoshkaDetalle');
    }
    else {
        CrearDecVie_PlanAccionMatryoshkaform();
    }
}

function EditarDecVie_PlanAccionMatryoshka(idmatryoshka) {
    $("#spanIdDecVie_PlanAccionMatryoshka")[0].innerText = idmatryoshka;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionMatryoshkaDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionMatryoshkaDetalle.html', 'dvDecVie_PlanAccionMatryoshkaDetalle');
    }
    else {
        EditarDecVie_PlanAccionMatryoshkaform(idmatryoshka);
    }

}
