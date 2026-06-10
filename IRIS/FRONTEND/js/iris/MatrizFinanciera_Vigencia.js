var DataTableMatrizFinanciera_Vigencia = null;

$(document).ready(function () {
    LoadDataTableMatrizFinanciera_Vigencia(); 
        
});

function LoadDataTableMatrizFinanciera_Vigencia() {
    DataTableMatrizFinanciera_Vigencia = $('#tblMatrizFinanciera_Vigencia').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "MatrizFinanciera_Vigencia/GetDataTableMatrizFinanciera_Vigencia"
        },      
        "columns": [                   
            
            { "data": "codvigencia", "orderable": true },
            { "data": "nmvigencia", "orderable": true },
            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarMatrizFinanciera_Vigencia(' + row.id_vigencia + ')" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Vigencia" onclick="ValidarEliminarMatrizFinanciera_Vigencia(' + row.id_vigencia + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [
            /*{ "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.codvigencia + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.nmvigencia + '">' + data : data;} 
            }*/
        ],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableMatrizFinanciera_Vigencia() {
    DataTableMatrizFinanciera_Vigencia.ajax.reload(null, false);
}

function ValidarEliminarMatrizFinanciera_Vigencia(idvigencia) {
    ShowDialogConfirmacion('','Seguro de eliminar la Vigencia seleccionada ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarMatrizFinanciera_Vigencia(idvigencia);
            }
        });
}

function EliminarMatrizFinanciera_Vigencia(idvigencia) {
    let urlEliminar = urlController + "MatrizFinanciera_Vigencia/DeleteMatrizFinanciera_Vigencia?id_vigencia=" + idvigencia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableMatrizFinanciera_Vigencia();
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

function CrearMatrizFinanciera_Vigencia() {
    debugger;
    $("#spanIdMatrizFinanciera_Vigencia")[0].innerText = '';
   
    if (!ExisteDivEdicionDatos('dvMatrizFinanciera_VigenciaDetalle')) {
        CrearDivEdicionDatos('/Pages/Decanatura/MatrizFinanciera_VigenciaDetalle.html', 'dvMatrizFinanciera_VigenciaDetalle');
    }
    else {
        CrearMatrizFinanciera_Vigenciaform();
    }
}

function EditarMatrizFinanciera_Vigencia(id_vigencia) {
    $("#spanIdMatrizFinanciera_Vigencia")[0].innerText = id_vigencia;
    
    if (!ExisteDivEdicionDatos('dvMatrizFinanciera_VigenciaDetalle')) {
        CrearDivEdicionDatos('/Pages/Decanatura/MatrizFinanciera_VigenciaDetalle.html', 'dvMatrizFinanciera_VigenciaDetalle');
    }
    else {
        EditarMatrizFinanciera_Vigenciaform(id_vigencia);
    }

}

