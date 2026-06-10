var isUpdatePublicaciones_EstadoCubierta = false;
var DataTablePublicaciones_EstadoCubierta = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EstadoCubierta();
});

function LoadDataTablePublicaciones_EstadoCubierta() {
    DataTablePublicaciones_EstadoCubierta = $('#tblPublicaciones_EstadoCubierta').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EstadoCubierta/GetDataTablePublicaciones_EstadoCubierta"
        },      
        "columns": [
            { "data": "nmestadocubierta", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EstadoCubierta(' + row.id_estadocubierta + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EstadoCubierta" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EstadoCubierta(' + row.id_estadocubierta + ',`' + row.nmestadocubierta + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EstadoCubierta() {
    DataTablePublicaciones_EstadoCubierta.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EstadoCubierta(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EstadoCubierta) {                                          
                    ExistePublicaciones_EstadoCubierta()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EstadoCubierta(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EstadoCubierta(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EstadoCubierta() {    
    let nmestadocubierta = $("#txtCdPublicacionesEstadoCubierta").val();   
    let urlValidar = urlController + "Publicaciones_EstadoCubierta/GetPublicaciones_EstadoCubiertaNombre?cd_nmestadocubierta=" + nmestadocubierta;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadocubierta + " ya está registrado.";
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

function AddUpdatePublicaciones_EstadoCubierta(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EstadoCubierta/UpdatePublicaciones_EstadoCubierta";

    objData.id_estadocubierta = ($("#spanIdPublicaciones_EstadoCubierta")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EstadoCubierta")[0].innerText;
    objData.nmestadocubierta = $("#txtCdPublicacionesEstadoCubierta").val();
   // objData.observaciones = $("#txtPublicaciones_EstadoCubierta").val();

    if (objData.id_estadocubierta == undefined) {
        urlUpdate = urlController + "Publicaciones_EstadoCubierta/InsertPublicaciones_EstadoCubierta";        
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

            RefreshDataTablePublicaciones_EstadoCubierta();
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

function CrearPublicaciones_EstadoCubierta() {
    $( "#txtCdPublicacionesEstadoCubierta" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EstadoCubierta")[0].innerText = '';
    $("#txtCdPublicacionesEstadoCubierta").val('');
    $("#txtPublicaciones_EstadoCubierta").val('');
    isUpdatePublicaciones_EstadoCubierta = false;

    removeValidationFormByForm('formPublicaciones_EstadoCubierta');
}

function EditarPublicaciones_EstadoCubierta(idestadocubierta) {   
    removeValidationFormByForm('formPublicaciones_EstadoCubierta'); 
    let urlEditar = urlController + "Publicaciones_EstadoCubierta/GetPublicaciones_EstadoCubiertaDetails?id_estadocubierta=" + idestadocubierta;
    isUpdatePublicaciones_EstadoCubierta = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EstadoCubierta")[0].innerText = datos.id_estadocubierta;
            $("#txtCdPublicacionesEstadoCubierta").val(datos.nmestadocubierta);
   //         $("#txtPublicaciones_EstadoCubierta").val(datos.observaciones);
            $( "#txtCdPublicacionesEstadoCubierta" ).prop( "disabled", false );            
            isUpdatePublicaciones_EstadoCubierta = true;
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

function ValidarEliminarPublicaciones_EstadoCubierta(idestadocubierta, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EstadoCubierta(idestadocubierta);
            }
        });

}

function EliminarPublicaciones_EstadoCubierta(idestadocubierta) {
    let urlEliminar = urlController + "Publicaciones_EstadoCubierta/DeletePublicaciones_EstadoCubierta?id_estadocubierta=" + idestadocubierta;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EstadoCubierta();
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
