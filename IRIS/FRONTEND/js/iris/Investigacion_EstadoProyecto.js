var DataTableInvestigacion_EstadoProyecto = null;

$(document).ready(function () {
    LoadDataTableInvestigacion_EstadoProyecto(); 
        
});

function LoadDataTableInvestigacion_EstadoProyecto() {
    DataTableInvestigacion_EstadoProyecto = $('#tblInvestigacion_EstadoProyecto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_EstadoProyecto/GetDataTableInvestigacion_EstadoProyecto"
        },      
        "columns": [                    
            { "data": "nmestado", "orderable": true },

            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Estado" onclick="ValidarEliminarInvestigacion_EstadoProyecto(' + row.id_estado + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            /*{ "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.descripcionprogramapgd + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.estrategiaprogramapgd + '">' + data : data;} 
            }*/
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableInvestigacion_EstadoProyecto() {
    DataTableInvestigacion_EstadoProyecto.ajax.reload(null, false);
}

function ValidarEliminarInvestigacion_EstadoProyecto(idestado) {
    ShowDialogConfirmacion('','Seguro de eliminar el Estado seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarInvestigacion_EstadoProyecto(idestado);
            }
        });
}

function EliminarInvestigacion_EstadoProyecto(idestado) {
    let urlEliminar = urlController + "Investigacion_EstadoProyecto/DeleteInvestigacion_EstadoProyecto?id_estado=" + idestado;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableInvestigacion_EstadoProyecto();
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

function CrearInvestigacion_EstadoProyecto() {
    $("#spanIdInvestigacion_EstadoProyecto")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvInvestigacion_EstadoProyectoDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Investigacion_EstadoProyectoDetalle.html', 'dvInvestigacion_EstadoProyectoDetalle');
    }
    else {
        CrearInvestigacion_EstadoProyectoform();
    }
}

function EditarInvestigacion_EstadoProyecto(idestado) {
    $("#spanIdInvestigacion_EstadoProyecto")[0].innerText = idestado;
    
    if (!ExisteDivEdicionDatos('dvInvestigacion_EstadoProyectoDetalle')) {
        CrearDivEdicionDatos('/Pages/Investigacion/Investigacion_EstadoProyectoDetalle.html', 'dvInvestigacion_EstadoProyectoDetalle');
    }
    else {
        EditarInvestigacion_EstadoProyectoform(idestado);
    }

}