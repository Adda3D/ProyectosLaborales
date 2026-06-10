var DataTableDecVie_RadicadorCor = null;

$(document).ready(function () {
    LoadDataTableDecVie_RadicadorCor(); 
        
});

function LoadDataTableDecVie_RadicadorCor() {
    DataTableDecVie_RadicadorCor = $('#tblDecVie_RadicadorCor').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_RadicadorCor/GetDataTableDecVie_RadicadorCor"
        },      
        "columns": [                    
            { "data": "id_radicadorcor", "orderable": true },
            { "data": "fecradicacion", "orderable": true, render: function (data, type, row, meta) {return row.fecradicacion.slice(0,10)} },
            { "data": "ogdchasqui", "orderable": true },
            { "data": "numerodocumento", "orderable": true },
            { "data": "NombreAlcanceSolicitud", "orderable": false },
            { "data": "EstadoSolicitud", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_RadicadorCor(' + row.id_radicadorcor + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_RadicadorCor(' + row.id_radicadorcor + ',`' + row.numerodocumento + '`);" /> ';
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

function RefreshDataTableDecVie_RadicadorCor() {
    DataTableDecVie_RadicadorCor.ajax.reload(null, false);
}

function ValidarEliminarDecVie_RadicadorCor(idradicadorcor, numerodocumento) {
    ShowDialogConfirmacion('','Seguro de eliminar el Radicado ' + numerodocumento + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_RadicadorCor(idradicadorcor);
            }
        });
}

function EliminarDecVie_RadicadorCor(idradicadorcor) {
    let urlEliminar = urlController + "DecVie_RadicadorCor/DeleteDecVie_RadicadorCor?id_radicadorcor=" + idradicadorcor;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_RadicadorCor();
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

function CrearDecVie_RadicadorCor() {
    $("#spanIdDecVie_RadicadorCor")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_RadicadorCorDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_RadicadorCorDetalle.html', 'dvDecVie_RadicadorCorDetalle');
    }
    else {
        CrearDecVie_RadicadorCorform();
    }
}

function EditarDecVie_RadicadorCor(idradicadorcor) {
    $("#spanIdDecVie_RadicadorCor")[0].innerText = idradicadorcor;
    
    if (!ExisteDivEdicionDatos('dvDecVie_RadicadorCorDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_RadicadorCorDetalle.html', 'dvDecVie_RadicadorCorDetalle');
    }
    else {
        EditarDecVie_RadicadorCorform(idradicadorcor);
    }

}
