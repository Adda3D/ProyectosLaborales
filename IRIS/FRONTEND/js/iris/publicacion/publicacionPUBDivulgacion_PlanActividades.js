var DataTablePublicaciones_DivulgacionPlanActividad = null;
var ObjModelPublicaciones_DivulgacionPlanActividad = null;

$(document).ready(function () {
    ObjModelPublicaciones_DivulgacionPlanActividad = new Publicaciones_DivulgacionPlanActividad();

    LoadPublicaciones_DivulgacionPlanActividad();
});

function LoadPublicaciones_DivulgacionPlanActividad() {
    if (DataTablePublicaciones_DivulgacionPlanActividad != null) {
        DataTablePublicaciones_DivulgacionPlanActividad.destroy();
    }

    DataTablePublicaciones_DivulgacionPlanActividad = $('#tblPublicaciones_DivulgacionPlanActividades').DataTable({
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
            "url": urlController + "Publicaciones_DivulgacionPlanActividad/GetDataTablePublicaciones_DivulgacionPlanActividadByPublicacion",  //?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText
            "data": {
                "id_crearpublicacion": function() { return $("#spanIdPublicacion")[0].innerText }                
            }                        
        },      
        "columns": [
            { "data": "actividad", "orderable": true },
            { "data": "fecha", "orderable": true, render: function (data, type, row, meta) {return row.fecha.slice(0,10)} },
            { "data": "Observacionesdt", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarPublicaciones_DivulgacionPlanActividades(' + row.iddivulgacionplanactividad + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionPlanActividades" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Actividad" onclick="ValidarEliminarPublicaciones_DivulgacionPlanActividad(' + row.iddivulgacionplanactividad + ',`' + row.actividad + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        "columnDefs": [
            { "targets": 2,                
                render: function (data, type, full, meta) {return type === 'display'? '<div title="' + full.observaciones + '">' + data : data;} 
            }
        ],               
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshPublicaciones_DivulgacionPlanActividad() {
    DataTablePublicaciones_DivulgacionPlanActividad.ajax.reload(null, false);    
}

function CerrarPublicaciones_DivulgacionPlanActividadesDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPublicaciones_DivulgacionPlanActividad);  
}
  
function CrearPublicaciones_DivulgacionPlanActividades() {

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionPlanActividad)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_DivulgacionPlanActividad)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtiddivulgacionplanactividad_Publicaciones_DivulgacionPlanActividad").val('');
                    $("#txtid_crearpublicacion_Publicaciones_DivulgacionPlanActividad").val($("#spanIdPublicacion")[0].innerText);
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

function EditarPublicaciones_DivulgacionPlanActividades(iddivulgacionplanactividad) {   

    CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionPlanActividad)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_DivulgacionPlanActividad, iddivulgacionplanactividad)
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


function ValidatePostUpdatePublicaciones_DivulgacionPlanActividadesForm(formF, botonClose) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionPlanActividad)
    .then(datosGuardados => {
      if (datosGuardados) {
        FinalizeLoader();
       // ShowModalDialog('Datos Disposición Legal Guardados', false, 'success', '', 0);  

        for (var i = 0; i < 2; i++) {
            $('#' + botonClose).click();
        }

        RefreshPublicaciones_DivulgacionPlanActividad();

      }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function ValidarEliminarPublicaciones_DivulgacionPlanActividad(iddivulgacionplanactividad, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar actividad ' + nombrecompleto + ' ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionPlanActividad(iddivulgacionplanactividad);
            }
        });

}

function EliminarPublicaciones_DivulgacionPlanActividad(iddivulgacionplanactividad) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionPlanActividad/DeletePublicaciones_DivulgacionPlanActividad?iddivulgacionplanactividad=" + iddivulgacionplanactividad;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshPublicaciones_DivulgacionPlanActividad();
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
