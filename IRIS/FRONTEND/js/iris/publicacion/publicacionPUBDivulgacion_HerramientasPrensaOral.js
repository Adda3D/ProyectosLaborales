var DataTablePublicaciones_DivulgacionHerramientasPrensaOral = null;
var ObjModelPublicaciones_DivulgacionHerramientasPrensaOral = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionHerramientasPrensaOral = new Publicaciones_DivulgacionHerramientaPrensaOral();

    LoadPublicaciones_DivulgacionHerramientasPrensaOral();
});

function LoadPublicaciones_DivulgacionHerramientasPrensaOral() {
    debugger;
    if (DataTablePublicaciones_DivulgacionHerramientasPrensaOral != null) {
        DataTablePublicaciones_DivulgacionHerramientasPrensaOral.destroy();
    }

    DataTablePublicaciones_DivulgacionHerramientasPrensaOral = $('#tblPublicaciones_DivulgacionHerramientasPrensaOral').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        searching: false,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DivulgacionHerramienta/GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText + "&id_tipomedio=3"
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText },
                "id_tipomedio": function() { return 3 }
            }
        },      
        "columns": [
            { "data": "nombre", "orderable": true },
            { "data": "lugar", "orderable": true },            
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "enlace", "orderable": true },
            { "data": "Observacionesdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionHerramientasPrensaOral(' + row.id_herramienta + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionHerramientasPrensaOral" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Publicación" onclick="ValidarEliminarPublicaciones_DivulgacionHerramientasPrensaOral(' + row.id_herramienta + ',`' + row.nombre + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 4,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionHerramientasPrensaOral() {
    DataTablePublicaciones_DivulgacionHerramientasPrensaOral.ajax.reload(null, false);    
}
  
function CrearPublicaciones_DivulgacionHerramientasPrensaOral() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaOral)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaOral)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_herramienta_Publicaciones_DivulgacionHerramientaPrensaOral").val('');
                    $("#txtid_tipomedio_Publicaciones_DivulgacionHerramientaPrensaOral").val('3');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionHerramientaPrensaOral").val($("#spanIdPublicacion")[0].innerText);
                    FinalizeLoader();    
                }
            })
            .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
            })      
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })      
}

function EditarPublicaciones_DivulgacionHerramientasPrensaOral(id_herramienta) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaOral)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasPrensaOral, id_herramienta)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
                }
            })
            .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
            })      
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })      

}


function ValidatePostUpdatePublicaciones_DivulgacionHerramientasPrensaOralForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionHerramientasPrensaOral)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionHerramientasPrensaOral();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionHerramientasPrensaOral(id_herramienta, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar publicación en ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionHerramientasPrensaOral(id_herramienta);
            }
        });

}

function EliminarPublicaciones_DivulgacionHerramientasPrensaOral(id_herramienta) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionHerramienta/DeletePublicaciones_DivulgacionHerramienta?id_herramienta=" + id_herramienta;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DivulgacionHerramientasPrensaOral();
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
