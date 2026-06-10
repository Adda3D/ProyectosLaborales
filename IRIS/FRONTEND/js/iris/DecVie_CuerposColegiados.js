var DataTableDecVie_CuerposColegiados = null;

$(document).ready(function () {
    LoadDataTableDecVie_CuerposColegiados(); 
        
});

function LoadDataTableDecVie_CuerposColegiados() {
    DataTableDecVie_CuerposColegiados = $('#tblDecVie_CuerposColegiados').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_CuerposColegiados/GetDataTableDecVie_CuerposColegiados"
        },      
        "columns": [                    
            { "data": "id_cuerposcolegiados", "orderable": true },
            { "data": "ano", "orderable": false, render: function (data, type, row, meta) {return row.ano.slice(0,4)} },
            { "data": "fecha", "orderable": false, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "numacta", "orderable": true },
            { "data": "NombreColegiado", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_CuerposColegiados(' + row.id_cuerposcolegiados + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_CuerposColegiados(' + row.id_cuerposcolegiados + ',`' + row.numacta + '`);" /> ';
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

function RefreshDataTableDecVie_CuerposColegiados() {
    DataTableDecVie_CuerposColegiados.ajax.reload(null, false);
}

function ValidarEliminarDecVie_CuerposColegiados(idcuerposcolegiados, numacta) {
    ShowDialogConfirmacion('','Seguro de eliminar el Acta ' + numacta + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_CuerposColegiados(idcuerposcolegiados);
            }
        });
}

function EliminarDecVie_CuerposColegiados(idcuerposcolegiados) {
    let urlEliminar = urlController + "DecVie_CuerposColegiados/DeleteDecVie_CuerposColegiados?id_cuerposcolegiados=" + idcuerposcolegiados;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_CuerposColegiados();
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

function CrearDecVie_CuerposColegiados() {
    $("#spanIdDecVie_CuerposColegiados")[0].innerText = '';
    StartLoader();

    if (!ExisteDivEdicionDatos('dvDecVie_CuerposColegiadosDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_CuerposColegiadosDetalle.html', 'dvDecVie_CuerposColegiadosDetalle');
    }
    else {
        CrearDecVie_CuerposColegiadosform();
    }
}

function EditarDecVie_CuerposColegiados(idcuerposcolegiados) {
    $("#spanIdDecVie_CuerposColegiados")[0].innerText = idcuerposcolegiados;
    StartLoader();
    
    if (!ExisteDivEdicionDatos('dvDecVie_CuerposColegiadosDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_CuerposColegiadosDetalle.html', 'dvDecVie_CuerposColegiadosDetalle');
    }
    else {
        EditarDecVie_CuerposColegiadosform(idcuerposcolegiados);
    }

}
