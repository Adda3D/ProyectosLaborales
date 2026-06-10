var DataTablePublicaciones_Distribuidor = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_Distribuidor(); 
        
});

function LoadDataTablePublicaciones_Distribuidor() {
    DataTablePublicaciones_Distribuidor = $('#tblPublicaciones_Distribuidor').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Distribuidor/GetDataTablePublicaciones_Distribuidor"
        },      
        "columns": [                    
            { "data": "distribuidor", "orderable": true },
            { "data": "direccion", "orderable": true },
            { "data": "telefono", "orderable": true },
            { "data": "correo", "orderable": false },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_Distribuidor(' + row.iddistribuidor + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Distribuidor" onclick="ValidarEliminarPublicaciones_Distribuidor(' + row.iddistribuidor + ',`' + row.distribuidor + '`);" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_Distribuidor() {
    DataTablePublicaciones_Distribuidor.ajax.reload(null, false);
}

function ValidarEliminarPublicaciones_Distribuidor(iddistribuidor, nmdistribuidor) {
    ShowDialogConfirmacion('','Seguro de eliminar distribuidor ' + nmdistribuidor + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_Distribuidor(iddistribuidor);
            }
        });
}

function EliminarPublicaciones_Distribuidor(iddistribuidor) {
    let urlEliminar = urlController + "Publicaciones_Distribuidor/DeletePublicaciones_Distribuidor?iddistribuidor=" + iddistribuidor;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_Distribuidor();
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

function CrearPublicaciones_Distribuidor() {
    $("#spanIddistribuidorPublicaciones_Distribuidor")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvPublicaciones_DistribuidorDetalle')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_distribuidorcomercialdetalle.html', 'dvPublicaciones_DistribuidorDetalle');
    }
    else {
        CrearPublicaciones_Distribuidorform();
    }
}

function EditarPublicaciones_Distribuidor(iddistribuidor) {
    $("#spanIddistribuidorPublicaciones_Distribuidor")[0].innerText = iddistribuidor;
    
    if (!ExisteDivEdicionDatos('dvPublicaciones_DistribuidorDetalle')) {
        CrearDivEdicionDatos('/Pages/publicacion/publicaciones_distribuidorcomercialdetalle.html', 'dvPublicaciones_DistribuidorDetalle');
    }
    else {
        EditarPublicaciones_Distribuidorform(iddistribuidor);
    }

}
