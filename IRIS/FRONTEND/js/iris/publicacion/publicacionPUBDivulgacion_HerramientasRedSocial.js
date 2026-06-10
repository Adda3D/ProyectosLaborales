var DataTablePublicaciones_DivulgacionHerramientasRedSocial = null;
var ObjModelPublicaciones_DivulgacionHerramientasRedSocial = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionHerramientasRedSocial = new Publicaciones_DivulgacionHerramientaRedSocial();

    LoadPublicaciones_DivulgacionHerramientasRedSocial();
});

function LoadPublicaciones_DivulgacionHerramientasRedSocial() {
    debugger;
    if (DataTablePublicaciones_DivulgacionHerramientasRedSocial != null) {
        DataTablePublicaciones_DivulgacionHerramientasRedSocial.destroy();
    }

    DataTablePublicaciones_DivulgacionHerramientasRedSocial = $('#tblPublicaciones_DivulgacionHerramientasRedSocial').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionHerramienta/GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText + "&id_tipomedio=1"
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText },
                "id_tipomedio": function() { return 1 }
            }
        },      
        "columns": [
            { "data": "nombre", "orderable": true },
            { "data": "enlace", "orderable": true },
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "Observacionesdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionHerramientasRedSocial(' + row.id_herramienta + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionHerramientasRedSocial" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Publicación" onclick="ValidarEliminarPublicaciones_DivulgacionHerramientasRedSocial(' + row.id_herramienta + ',`' + row.nombre + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 3,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionHerramientasRedSocial() {
    DataTablePublicaciones_DivulgacionHerramientasRedSocial.ajax.reload(null, false);    
}
  
function CrearPublicaciones_DivulgacionHerramientasRedSocial() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasRedSocial)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasRedSocial)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_herramienta_Publicaciones_DivulgacionHerramientaRedSocial").val('');
                    $("#txtid_tipomedio_Publicaciones_DivulgacionHerramientaRedSocial").val('1');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionHerramientaRedSocial").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DivulgacionHerramientasRedSocial(id_herramienta) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionHerramientasRedSocial)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionHerramientasRedSocial, id_herramienta)
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


function ValidatePostUpdatePublicaciones_DivulgacionHerramientasRedSocialForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionHerramientasRedSocial)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionHerramientasRedSocial();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionHerramientasRedSocial(id_herramienta, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar publicación en ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionHerramientasRedSocial(id_herramienta);
            }
        });

}

function EliminarPublicaciones_DivulgacionHerramientasRedSocial(id_herramienta) {
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
            RefreshPublicaciones_DivulgacionHerramientasRedSocial();
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
