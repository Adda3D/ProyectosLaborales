var DataTableDecVie_Instancias = null;

$(document).ready(function () {
    LoadDataTableDecVie_Instancias(); 
        
});

function LoadDataTableDecVie_Instancias() {
    DataTableDecVie_Instancias = $('#tblDecVie_Instancias').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Instancias/GetDataTableDecVie_Instancias"
        },      
        "columns": [
            { "data": "nminstancia", "orderable": true },
            { "data": "identificacioninstancia", "orderable": true },
            { "data": "responsable", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarDecVie_Instancias(' + row.id_instancia + ')" /> ' +                           
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Instancia" onclick="ValidarEliminarDecVie_Instancias(' + row.id_instancia + ');" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        "columnDefs": [/*
            { "targets": 2,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.descripcionprogramapgd + '">' + data : data;} 
            },
            { "targets": 3,
               render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.estrategiaprogramapgd + '">' + data : data;} 
            }
        */],
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_Instancias() {
    DataTableDecVie_Instancias.ajax.reload(null, false);
}

function ValidarEliminarDecVie_Instancias(idinstancia) {
    ShowDialogConfirmacion('','Seguro de eliminar la Instancia seleccionado ' + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_Instancias(idinstancia);
            }
        });
}

function EliminarDecVie_Instancias(idinstancia) {
    let urlEliminar = urlController + "DecVie_Instancias/DeleteDecVie_Instancias?id_instancia=" + idinstancia;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_Instancias();
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

function CrearDecVie_Instancias() {
    $("#spanIdDecVie_Instancias")[0].innerText = '';

    if (!ExisteDivEdicionDatos('dvDecVie_InstanciasDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_InstanciasDetalle.html', 'dvDecVie_InstanciasDetalle');
    }
    else {
        CrearDecVie_Instanciasform();
    }
}

function EditarDecVie_Instancias(idinstancia) {
    $("#spanIdDecVie_Instancias")[0].innerText = idinstancia;
    
    if (!ExisteDivEdicionDatos('dvDecVie_InstanciasDetalle')) {
        CrearDivEdicionDatos('/Pages/Vie/DecVie_InstanciasDetalle.html', 'dvDecVie_InstanciasDetalle');
    }
    else {
        EditarDecVie_Instanciasform(idinstancia);
    }

}