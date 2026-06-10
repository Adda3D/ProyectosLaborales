var isUpdatePublicaciones_EstadoCorab = false;
var DataTablePublicaciones_EstadoCorab = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EstadoCorab();
});

function LoadDataTablePublicaciones_EstadoCorab() {
    DataTablePublicaciones_EstadoCorab = $('#tblPublicaciones_EstadoCorab').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EstadoCorab/GetDataTablePublicaciones_EstadoCorab"
        },      
        "columns": [
            { "data": "nmestadocorab", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EstadoCorab(' + row.id_estadocorab + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EstadoCorab" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EstadoCorab(' + row.id_estadocorab + ',`' + row.nmestadocorab + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EstadoCorab() {
    DataTablePublicaciones_EstadoCorab.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EstadoCorab(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EstadoCorab) {                                          
                    ExistePublicaciones_EstadoCorab()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EstadoCorab(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EstadoCorab(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EstadoCorab() {    
    let nmestadocorab = $("#txtCdPublicacionesEstadoCorab").val();   
    let urlValidar = urlController + "Publicaciones_EstadoCorab/GetPublicaciones_EstadoCorabNombre?cd_nmestadocorab=" + nmestadocorab;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadocorab + " ya está registrado.";
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

function AddUpdatePublicaciones_EstadoCorab(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EstadoCorab/UpdatePublicaciones_EstadoCorab";

    objData.id_estadocorab = ($("#spanIdPublicaciones_EstadoCorab")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EstadoCorab")[0].innerText;
    objData.nmestadocorab = $("#txtCdPublicacionesEstadoCorab").val();
   // objData.observaciones = $("#txtPublicaciones_EstadoCorab").val();

    if (objData.id_estadocorab == undefined) {
        urlUpdate = urlController + "Publicaciones_EstadoCorab/InsertPublicaciones_EstadoCorab";        
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

            RefreshDataTablePublicaciones_EstadoCorab();
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

function CrearPublicaciones_EstadoCorab() {
    $( "#txtCdPublicacionesEstadoCorab" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EstadoCorab")[0].innerText = '';
    $("#txtCdPublicacionesEstadoCorab").val('');
    $("#txtPublicaciones_EstadoCorab").val('');
    isUpdatePublicaciones_EstadoCorab = false;

    removeValidationFormByForm('formPublicaciones_EstadoCorab');
}

function EditarPublicaciones_EstadoCorab(idestadocorab) {   
    removeValidationFormByForm('formPublicaciones_EstadoCorab'); 
    let urlEditar = urlController + "Publicaciones_EstadoCorab/GetPublicaciones_EstadoCorabDetails?id_estadocorab=" + idestadocorab;
    isUpdatePublicaciones_EstadoCorab = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EstadoCorab")[0].innerText = datos.id_estadocorab;
            $("#txtCdPublicacionesEstadoCorab").val(datos.nmestadocorab);
   //         $("#txtPublicaciones_EstadoCorab").val(datos.observaciones);
            $( "#txtCdPublicacionesEstadoCorab" ).prop( "disabled", false );            
            isUpdatePublicaciones_EstadoCorab = true;
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

function ValidarEliminarPublicaciones_EstadoCorab(idestadocorab, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EstadoCorab(idestadocorab);
            }
        });

}

function EliminarPublicaciones_EstadoCorab(idestadocorab) {
    let urlEliminar = urlController + "Publicaciones_EstadoCorab/DeletePublicaciones_EstadoCorab?id_estadocorab=" + idestadocorab;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EstadoCorab();
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
