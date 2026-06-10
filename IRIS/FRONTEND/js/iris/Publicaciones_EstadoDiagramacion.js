var isUpdatePublicaciones_EstadoDiagramacion = false;
var DataTablePublicaciones_EstadoDiagramacion = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EstadoDiagramacion();
});

function LoadDataTablePublicaciones_EstadoDiagramacion() {
    DataTablePublicaciones_EstadoDiagramacion = $('#tblPublicaciones_EstadoDiagramacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EstadoDiagramacion/GetDataTablePublicaciones_EstadoDiagramacion"
        },      
        "columns": [
            { "data": "nmestadodiagramacion", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EstadoDiagramacion(' + row.id_estadodiagramacion + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EstadoDiagramacion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EstadoDiagramacion(' + row.id_estadodiagramacion + ',`' + row.nmestadodiagramacion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EstadoDiagramacion() {
    DataTablePublicaciones_EstadoDiagramacion.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EstadoDiagramacion(formF, botonClose) {
    debugger;
    validateTextXSSLastButtonByForm(formF);

    var formV = $("#" + formF);
    if (formV[0].checkValidity() == false) {
        $(formV).addClass('was-validated');
    } else {
        if (checkValidityXSS == false) {
            $(formV).addClass('was-validated');
        } else {
            if (checkValiditySelect == false) {
                $(formV).addClass('was-validated');
            } else {
                if (!isUpdatePublicaciones_EstadoDiagramacion) {                                          
                    ExistePublicaciones_EstadoDiagramacion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EstadoDiagramacion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EstadoDiagramacion(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EstadoDiagramacion() {    
    let nmestadodiagramacion = $("#txtCdPublicacionesEstadoDiagramacion").val();   
    let urlValidar = urlController + "Publicaciones_EstadoDiagramacion/GetPublicaciones_EstadoDiagramacionNombre?cd_nmestadodiagramacion=" + nmestadodiagramacion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadodiagramacion + " ya está registrado.";
                ShowModalDialog(message, false, 'warning', '', 0);
                return true;
            }
            else {
                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });
}

function AddUpdatePublicaciones_EstadoDiagramacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EstadoDiagramacion/UpdatePublicaciones_EstadoDiagramacion";

    objData.id_estadodiagramacion = ($("#spanIdPublicaciones_EstadoDiagramacion")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EstadoDiagramacion")[0].innerText;
    objData.nmestadodiagramacion = $("#txtCdPublicacionesEstadoDiagramacion").val();
   // objData.observaciones = $("#txtPublicaciones_EstadoDiagramacion").val();

    if (objData.id_estadodiagramacion == undefined) {
        urlUpdate = urlController + "Publicaciones_EstadoDiagramacion/InsertPublicaciones_EstadoDiagramacion";        
    }

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            
            for (var i = 0; i < 2; i++) {
                $('#' + botonCerrar).click();
            }

            RefreshDataTablePublicaciones_EstadoDiagramacion();
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );          
}

function CrearPublicaciones_EstadoDiagramacion() {
    $( "#txtCdPublicacionesEstadoDiagramacion" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EstadoDiagramacion")[0].innerText = '';
    $("#txtCdPublicacionesEstadoDiagramacion").val('');
    $("#txtPublicaciones_EstadoDiagramacion").val('');
    isUpdatePublicaciones_EstadoDiagramacion = false;

    removeValidationFormByForm('formPublicaciones_EstadoDiagramacion');
}

function EditarPublicaciones_EstadoDiagramacion(idestadodiagramacion) {   
    removeValidationFormByForm('formPublicaciones_EstadoDiagramacion'); 
    let urlEditar = urlController + "Publicaciones_EstadoDiagramacion/GetPublicaciones_EstadoDiagramacionDetails?id_estadodiagramacion=" + idestadodiagramacion;
    isUpdatePublicaciones_EstadoDiagramacion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EstadoDiagramacion")[0].innerText = datos.id_estadodiagramacion;
            $("#txtCdPublicacionesEstadoDiagramacion").val(datos.nmestadodiagramacion);
   //         $("#txtPublicaciones_EstadoDiagramacion").val(datos.observaciones);
            $( "#txtCdPublicacionesEstadoDiagramacion" ).prop( "disabled", false );            
            isUpdatePublicaciones_EstadoDiagramacion = true;
            FinalizeLoader();
            return;
        }
        else {
            ShowModalDialog(data.Message, false, 'warning', '', 0);
            FinalizeLoader();
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}

function ValidarEliminarPublicaciones_EstadoDiagramacion(idestadodiagramacion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EstadoDiagramacion(idestadodiagramacion);
            }
        });

}

function EliminarPublicaciones_EstadoDiagramacion(idestadodiagramacion) {
    let urlEliminar = urlController + "Publicaciones_EstadoDiagramacion/DeletePublicaciones_EstadoDiagramacion?id_estadodiagramacion=" + idestadodiagramacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EstadoDiagramacion();
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
