var DataTablePublicaciones_DivulgacionActividadFeriaEvento = null;
var ObjModelPublicaciones_DivulgacionActividadFeriaEvento = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionActividadFeriaEvento = new Publicaciones_DivulgacionActividadFeriaEvento();

    LoadPublicaciones_DivulgacionActividadFeriaEvento();
});

function LoadPublicaciones_DivulgacionActividadFeriaEvento() {
    if (DataTablePublicaciones_DivulgacionActividadFeriaEvento != null) {
        DataTablePublicaciones_DivulgacionActividadFeriaEvento.destroy();
    }

    DataTablePublicaciones_DivulgacionActividadFeriaEvento = $('#tblPublicaciones_DivulgacionActividadFeriaEvento').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionActividadFeriaEvento/GetDataTablePublicaciones_DivulgacionActividadFeriaEventoByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText },
            }
        },      
        "columns": [
            { "data": "tipo", "orderable": true },
            { "data": "nombre", "orderable": true },
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "Observacionesdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionActividadFeriaEvento(' + row.idferiaevento + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionActividadFeriaEvento" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Actividad" onclick="ValidarEliminarPublicaciones_DivulgacionActividadFeriaEvento(' + row.idferiaevento + ',`' + row.nombre + '`);" />';
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

function RefreshPublicaciones_DivulgacionActividadFeriaEvento() {
    DataTablePublicaciones_DivulgacionActividadFeriaEvento.ajax.reload(null, false);    
}

function CerrarPublicaciones_DivulgacionActividadFeriaEventoDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DivulgacionActividadFeriaEvento);  
}
  
function CrearPublicaciones_DivulgacionActividadFeriaEvento() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionActividadFeriaEvento)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionActividadFeriaEvento)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtidferiaevento_Publicaciones_DivulgacionActividadFeriaEvento").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionActividadFeriaEvento").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DivulgacionActividadFeriaEvento(idferiaevento) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionActividadFeriaEvento)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionActividadFeriaEvento, idferiaevento)
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


function ValidatePostUpdatePublicaciones_DivulgacionActividadFeriaEventoForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionActividadFeriaEvento)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionActividadFeriaEvento();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionActividadFeriaEvento(idferiaevento, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar actividad ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionActividadFeriaEvento(idferiaevento);
            }
        });

}

function EliminarPublicaciones_DivulgacionActividadFeriaEvento(idferiaevento) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionActividadFeriaEvento/DeletePublicaciones_DivulgacionActividadFeriaEvento?idferiaevento=" + idferiaevento;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DivulgacionActividadFeriaEvento();
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
