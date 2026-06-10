var DataTablePropuestas_cobertura = null;

$(document).ready(function () {
    LoadDataTablePropuestas_cobertura(); 
        
});

function LoadDataTablePropuestas_cobertura() {
    DataTablePropuestas_cobertura = $('#tblPropuestas_cobertura').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_Cobertura/GetDataTablePropuestaCobertura"
        },      
        "columns": [                    
            { "data": "nmcobertura", "orderable": true },

            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Cobertura" onclick="ValidarEliminarPropuestas_cobertura(' + row.id_cobertura + ')" /> ';
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

function RefreshDataTablePropuestas_cobertura() {
    DataTablePropuestas_cobertura.ajax.reload(null, false);
}

function ValidarEliminarPropuestas_cobertura(idcobertura) {
    ShowDialogConfirmacion('','Seguro de eliminar la cobertura seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestas_cobertura(idcobertura);
            }
        });
}

function EliminarPropuestas_cobertura(idcobertura) {
    let urlEliminar = urlController + "Propuesta_Cobertura/DeletePropuesta_Cobertura?id_cobertura=" + idcobertura;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePropuestas_cobertura();
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

function CrearPropuestas_cobertura() {
    $("#spanIdPropuestas_cobertura")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvPropuestas_coberturaDetalle')) {
        CrearDivEdicionDatos('/Pages/proyectoextension/Propuestas_coberturaDetalle.html', 'dvPropuestas_coberturaDetalle');
    }
    else {
        CrearPropuestas_coberturaform();
    }
}

function EditarPropuestas_cobertura(idcobertura) {
    $("#spanIdPropuestas_cobertura")[0].innerText = idcobertura;
    
    if (!ExisteDivEdicionDatos('dvPropuestas_coberturaDetalle')) {
        CrearDivEdicionDatos('/Pages/proyectoextension/Propuestas_coberturaDetalle.html', 'dvPropuestas_coberturaDetalle');
    }
    else {
        EditarPropuestas_coberturaform(idcobertura);
    }

}