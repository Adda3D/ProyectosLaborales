var DataTableDecVie_InventarioGestionConocimiento = null;

$(document).ready(function () {
    LoadDataTableDecVie_InventarioGestionConocimiento(); 
        
});

function LoadDataTableDecVie_InventarioGestionConocimiento() {
    DataTableDecVie_InventarioGestionConocimiento = $('#tblDecVie_InventarioGestionConocimiento').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_InventarioGestionConocimiento/GetDataTableDecVie_InventarioGestionConocimiento"
        },      
        "columns": [                    
            { "data": "id_invgesconocimiento", "orderable": true },
            { "data": "NombreSoporte", "orderable": false },
            { "data": "vigencia", "orderable": true },
            { "data": "NombreEntidad", "orderable": false },
            { "data": "beneficiarios", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_InventarioGestionConocimiento(' + row.id_invgesconocimiento + ')" /> ' +
                           '<img src="../images/iris/excel.png" class="cambiarMouse" title="Exportar Excel" onclick="DecVie_InventarioGestionConocimientoExcel(' + row.id_invgesconocimiento + ')" /> ' +                         
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Propuesta" onclick="ValidarEliminarDecVie_InventarioGestionConocimiento(' + row.id_invgesconocimiento + ');" /> ';
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

function RefreshDataTableDecVie_InventarioGestionConocimiento() {
    DataTableDecVie_InventarioGestionConocimiento.ajax.reload(null, false);
}

function ValidarEliminarDecVie_InventarioGestionConocimiento(idinvgesconocimiento) {
    ShowDialogConfirmacion('','Seguro de eliminar el Inventario seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_InventarioGestionConocimiento(idinvgesconocimiento);
            }
        });
}

function EliminarDecVie_InventarioGestionConocimiento(idinvgesconocimiento) {
    let urlEliminar = urlController + "DecVie_InventarioGestionConocimiento/DeleteDecVie_InventarioGestionConocimiento?id_invgesconocimiento=" + idinvgesconocimiento;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_InventarioGestionConocimiento();
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

function CrearDecVie_InventarioGestionConocimiento() {
    $("#spanIdDecVie_InventarioGestionConocimiento")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_InventarioGestionConocimientoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_InventarioGestionConocimientoDetalle.html', 'dvDecVie_InventarioGestionConocimientoDetalle');
    }
    else {
        CrearDecVie_InventarioGestionConocimientoform();
    }
}

function EditarDecVie_InventarioGestionConocimiento(idinvgesconocimiento) {
    $("#spanIdDecVie_InventarioGestionConocimiento")[0].innerText = idinvgesconocimiento;
    
    if (!ExisteDivEdicionDatos('dvDecVie_InventarioGestionConocimientoDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_InventarioGestionConocimientoDetalle.html', 'dvDecVie_InventarioGestionConocimientoDetalle');
    }
    else {
        EditarDecVie_InventarioGestionConocimientoform(idinvgesconocimiento);
    }

}

function DecVie_InventarioGestionConocimientoExcel(idinvgesconocimiento,) {
    debugger;
    $("#spanIdDecVie_InventarioGestionConocimiento")[0].innerText = idinvgesconocimiento;   

    let urlExcel = urlController + "DecVie_InventarioGestionConocimiento/ExcelDecVie_InventarioGestionConocimiento?id_invgesconocimiento=" + idinvgesconocimiento;
    StartLoader();

    fetch(urlExcel, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {      
            debugger;                 
            FinalizeLoader();
            location.href = urlDownload + data.Data;
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