var isUpdatePublicaciones_EstadoCorreccion = false;
var DataTablePublicaciones_EstadoCorreccion = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EstadoCorreccion();
});

function LoadDataTablePublicaciones_EstadoCorreccion() {
    DataTablePublicaciones_EstadoCorreccion = $('#tblPublicaciones_EstadoCorreccion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EstadoCorreccion/GetDataTablePublicaciones_EstadoCorreccion"
        },      
        "columns": [
            { "data": "nmestadocorreccion", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EstadoCorreccion(' + row.id_estadocorreccion + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EstadoCorreccion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EstadoCorreccion(' + row.id_estadocorreccion + ',`' + row.nmestadocorreccion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EstadoCorreccion() {
    DataTablePublicaciones_EstadoCorreccion.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EstadoCorreccion(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EstadoCorreccion) {                                          
                    ExistePublicaciones_EstadoCorreccion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EstadoCorreccion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EstadoCorreccion(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EstadoCorreccion() {    
    let nmestadocorreccion = $("#txtCdPublicacionesEstadoCorreccion").val();   
    let urlValidar = urlController + "Publicaciones_EstadoCorreccion/GetPublicaciones_EstadoCorreccionNombre?cd_nmestadocorreccion=" + nmestadocorreccion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadocorreccion + " ya está registrado.";
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

function AddUpdatePublicaciones_EstadoCorreccion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EstadoCorreccion/UpdatePublicaciones_EstadoCorreccion";

    objData.id_estadocorreccion = ($("#spanIdPublicaciones_EstadoCorreccion")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EstadoCorreccion")[0].innerText;
    objData.nmestadocorreccion = $("#txtCdPublicacionesEstadoCorreccion").val();
   // objData.observaciones = $("#txtPublicaciones_EstadoCorreccion").val();

    if (objData.id_estadocorreccion == undefined) {
        urlUpdate = urlController + "Publicaciones_EstadoCorreccion/InsertPublicaciones_EstadoCorreccion";        
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

            RefreshDataTablePublicaciones_EstadoCorreccion();
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

function CrearPublicaciones_EstadoCorreccion() {
    $( "#txtCdPublicacionesEstadoCorreccion" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EstadoCorreccion")[0].innerText = '';
    $("#txtCdPublicacionesEstadoCorreccion").val('');
    $("#txtPublicaciones_EstadoCorreccion").val('');
    isUpdatePublicaciones_EstadoCorreccion = false;

    removeValidationFormByForm('formPublicaciones_EstadoCorreccion');
}

function EditarPublicaciones_EstadoCorreccion(idestadocorreccion) {   
    removeValidationFormByForm('formPublicaciones_EstadoCorreccion'); 
    let urlEditar = urlController + "Publicaciones_EstadoCorreccion/GetPublicaciones_EstadoCorreccionDetails?id_estadocorreccion=" + idestadocorreccion;
    isUpdatePublicaciones_EstadoCorreccion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EstadoCorreccion")[0].innerText = datos.id_estadocorreccion;
            $("#txtCdPublicacionesEstadoCorreccion").val(datos.nmestadocorreccion);
   //         $("#txtPublicaciones_EstadoCorreccion").val(datos.observaciones);
            $( "#txtCdPublicacionesEstadoCorreccion" ).prop( "disabled", false );            
            isUpdatePublicaciones_EstadoCorreccion = true;
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

function ValidarEliminarPublicaciones_EstadoCorreccion(idestadocorreccion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EstadoCorreccion(idestadocorreccion);
            }
        });

}

function EliminarPublicaciones_EstadoCorreccion(idestadocorreccion) {
    let urlEliminar = urlController + "Publicaciones_EstadoCorreccion/DeletePublicaciones_EstadoCorreccion?id_estadocorreccion=" + idestadocorreccion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EstadoCorreccion();
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
