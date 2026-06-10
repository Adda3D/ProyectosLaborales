var DataTableDecVie_Consecutivo = null;

$(document).ready(function () {
    LoadDataTableDecVie_Consecutivo(); 
        
});

function LoadDataTableDecVie_Consecutivo() {
    DataTableDecVie_Consecutivo = $('#tblDecVie_Consecutivo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Consecutivo/GetDataTableDecVie_Consecutivo"
        },      
        "columns": [                    
            { "data": "id_decvieconsecutivo", "orderable": true },
            { "data": "fecha", "orderable": false, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "numconsecutivo", "orderable": true },
            { "data": "asunto", "orderable": true },
            { "data": "DependenciaEmite", "orderable": false },
            { "data": "NombreResponsable", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_Consecutivo(' + row.id_decvieconsecutivo + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_Consecutivo(' + row.id_decvieconsecutivo + ',`' + row.numconsecutivo + '`);" /> ';
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

function RefreshDataTableDecVie_Consecutivo() {
    DataTableDecVie_Consecutivo.ajax.reload(null, false);
}

function ValidarEliminarDecVie_Consecutivo(iddecvieconsecutivo, numconsecutivo) {
    ShowDialogConfirmacion('','Seguro de eliminar el consecutivo ' + numconsecutivo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_Consecutivo(iddecvieconsecutivo);
            }
        });
}

function EliminarDecVie_Consecutivo(iddecvieconsecutivo) {
    let urlEliminar = urlController + "DecVie_Consecutivo/DeleteDecVie_Consecutivo?id_decvieconsecutivo=" + iddecvieconsecutivo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_Consecutivo();
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

function CrearDecVie_Consecutivo() {
    $("#spanIdDecVie_Consecutivo")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_ConsecutivoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_ConsecutivoDetalle.html', 'dvDecVie_ConsecutivoDetalle');
    }
    else {
        CrearDecVie_Consecutivoform();
        //Cambio ADDAVARGAS 18/04/2024
        console.log("Se activo en el DecVie_Consecutivo linea 95")
    }
}

function EditarDecVie_Consecutivo(iddecvieconsecutivo) {
    $("#spanIdDecVie_Consecutivo")[0].innerText = iddecvieconsecutivo;
    
    if (!ExisteDivEdicionDatos('dvDecVie_ConsecutivoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_ConsecutivoDetalle.html', 'dvDecVie_ConsecutivoDetalle');
    }
    else {
        EditarDecVie_Consecutivoform(iddecvieconsecutivo);
    }

}
