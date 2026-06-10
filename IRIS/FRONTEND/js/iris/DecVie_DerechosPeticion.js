var DataTableDecVie_DerechosPeticion = null;

$(document).ready(function () {
    LoadDataTableDecVie_DerechosPeticion(); 
        
});

function LoadDataTableDecVie_DerechosPeticion() {
    DataTableDecVie_DerechosPeticion = $('#tblDecVie_DerechosPeticion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_DerechosPeticion/GetDataTableDecVie_DerechosPeticion"
        },      
        "columns": [                    
            { "data": "id_derechopeticion", "orderable": true },
            { "data": "fecha", "orderable": false, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "numradicacion", "orderable": true },
            { "data": "solicitud", "orderable": true },
            { "data": "NombreDependencia", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_DerechosPeticion(' + row.id_derechopeticion + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_DerechosPeticion(' + row.id_derechopeticion + ',`' + row.numradicacion + '`);" /> ';
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

function RefreshDataTableDecVie_DerechosPeticion() {
    DataTableDecVie_DerechosPeticion.ajax.reload(null, false);
}

function ValidarEliminarDecVie_DerechosPeticion(idderechopeticion, numradicacion) {
    ShowDialogConfirmacion('','Seguro de eliminar el número de radicación ' + numradicacion + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_DerechosPeticion(idderechopeticion);
            }
        });
}

function EliminarDecVie_DerechosPeticion(idderechopeticion) {
    let urlEliminar = urlController + "DecVie_DerechosPeticion/DeleteDecVie_DerechosPeticion?id_derechopeticion=" + idderechopeticion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_DerechosPeticion();
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

function CrearDecVie_DerechosPeticion() {
    $("#spanIdDecVie_DerechosPeticion")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_DerechosPeticionDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_DerechosPeticionDetalle.html', 'dvDecVie_DerechosPeticionDetalle');
    }
    else {
        CrearDecVie_DerechosPeticionform();
    }
}

function EditarDecVie_DerechosPeticion(idderechopeticion) {
    $("#spanIdDecVie_DerechosPeticion")[0].innerText = idderechopeticion;
    
    if (!ExisteDivEdicionDatos('dvDecVie_DerechosPeticionDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_DerechosPeticionDetalle.html', 'dvDecVie_DerechosPeticionDetalle');
    }
    else {
        EditarDecVie_DerechosPeticionform(idderechopeticion);
    }

}
