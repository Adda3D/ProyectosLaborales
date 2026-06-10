var DataTableDecVie_PlanAccionAlcanceAnno = null;

$(document).ready(function () {
    LoadDataTableDecVie_PlanAccionAlcanceAnno(); 
        
});

function LoadDataTableDecVie_PlanAccionAlcanceAnno() {
    DataTableDecVie_PlanAccionAlcanceAnno = $('#tblDecVie_PlanAccionAlcanceAnno').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_PlanAccionAlcanceAnno/GetDataTableDecVie_PlanAccionAlcanceAnno"
        },      
        "columns": [                    
            { "data": "id_alcanceanno", "orderable": true },
            { "data": "nmalcanceanno", "orderable": true },
            //{ "data": "prefijo", "orderable": true },
           // { "data": "NombreDependencia", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_PlanAccionAlcanceAnno(' + row.id_alcanceanno + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_PlanAccionAlcanceAnno(' + row.id_alcanceanno + ',`' + row.nmalcanceanno + '`);" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nmalcanceanno + '">' + data : data;} 
            }
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_PlanAccionAlcanceAnno() {
    DataTableDecVie_PlanAccionAlcanceAnno.ajax.reload(null, false);
}

function ValidarEliminarDecVie_PlanAccionAlcanceAnno(idalcanceanno, nmalcanceanno) {
    ShowDialogConfirmacion('','Seguro de eliminar el Prefijo ' + nmalcanceanno + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_PlanAccionAlcanceAnno(idalcanceanno);
            }
        });
}

function EliminarDecVie_PlanAccionAlcanceAnno(idalcanceanno) {
    let urlEliminar = urlController + "DecVie_PlanAccionAlcanceAnno/DeleteDecVie_PlanAccionAlcanceAnno?id_alcanceanno=" + idalcanceanno;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_PlanAccionAlcanceAnno();
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

function CrearDecVie_PlanAccionAlcanceAnno() {
    $("#spanIdDecVie_PlanAccionAlcanceAnno")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionAlcanceAnnoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionAlcanceAnnoDetalle.html', 'dvDecVie_PlanAccionAlcanceAnnoDetalle');
    }
    else {
        CrearDecVie_PlanAccionAlcanceAnnoform();
    }
}

function EditarDecVie_PlanAccionAlcanceAnno(idalcanceanno) {
    $("#spanIdDecVie_PlanAccionAlcanceAnno")[0].innerText = idalcanceanno;
    
    if (!ExisteDivEdicionDatos('dvDecVie_PlanAccionAlcanceAnnoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_PlanAccionAlcanceAnnoDetalle.html', 'dvDecVie_PlanAccionAlcanceAnnoDetalle');
    }
    else {
        EditarDecVie_PlanAccionAlcanceAnnoform(idalcanceanno);
    }

}
