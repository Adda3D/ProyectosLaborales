var isUpdatePublicaciones_Coleccion = false;
var DataTablePublicaciones_Coleccion = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_Coleccion();
});

function LoadDataTablePublicaciones_Coleccion() {
    DataTablePublicaciones_Coleccion = $('#tblPublicaciones_Coleccion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Coleccion/GetDataTablePublicaciones_Coleccion"
        },      
        "columns": [
            { "data": "nmcoleccion", "orderable": true },
            { "data": "observaciones", "orderable": true },
            { "data": "consecutivo", "orderable": false },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_Coleccion(' + row.id_coleccion + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_Coleccion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_Coleccion(' + row.id_coleccion + ',`' + row.nmcoleccion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_Coleccion() {
    DataTablePublicaciones_Coleccion.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_Coleccion(formF, botonClose) {
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
                if (!isUpdatePublicaciones_Coleccion) {                                          
                    ExistePublicaciones_Coleccion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_Coleccion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_Coleccion(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_Coleccion() {    
    let nmcoleccion = $("#txtCdPublicacionesColeccion").val();   
    let urlValidar = urlController + "Publicaciones_Coleccion/GetPublicaciones_ColeccionNombre?cd_nmcoleccion=" + nmcoleccion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmcoleccion + " ya está registrado.";
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

function AddUpdatePublicaciones_Coleccion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Coleccion/UpdatePublicaciones_Coleccion";

    objData.id_coleccion = ($("#spanIdPublicaciones_Coleccion")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_Coleccion")[0].innerText;
    objData.nmcoleccion = $("#txtCdPublicacionesColeccion").val();
    objData.consecutivo = $("#nmConsecutivoColeccion").val();
    objData.observaciones = $("#txtPublicaciones_Coleccion").val();

    if (objData.id_coleccion == undefined) {
        urlUpdate = urlController + "Publicaciones_Coleccion/InsertPublicaciones_Coleccion";        
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

            RefreshDataTablePublicaciones_Coleccion();
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

function CrearPublicaciones_Coleccion() {
    $( "#txtCdPublicacionesColeccion" ).prop( "disabled", false );
    $("#spanIdPublicaciones_Coleccion")[0].innerText = '';
    $("#txtCdPublicacionesColeccion").val('');
    $("#txtPublicaciones_Coleccion").val('');
    $("#nmConsecutivoColeccion").val('1');
    isUpdatePublicaciones_Coleccion = false;

    removeValidationFormByForm('formPublicaciones_Coleccion');
}

function EditarPublicaciones_Coleccion(idcoleccion) {   
    removeValidationFormByForm('formPublicaciones_Coleccion'); 
    let urlEditar = urlController + "Publicaciones_Coleccion/GetPublicaciones_ColeccionDetails?id_coleccion=" + idcoleccion;
    isUpdatePublicaciones_Coleccion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_Coleccion")[0].innerText = datos.id_coleccion;
            $("#txtCdPublicacionesColeccion").val(datos.nmcoleccion);
            $("#txtPublicaciones_Coleccion").val(datos.observaciones);
            $("#nmConsecutivoColeccion").val(datos.consecutivo);
            $("#txtCdPublicacionesColeccion" ).prop( "disabled", false );            
            isUpdatePublicaciones_Coleccion = true;
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

function ValidarEliminarPublicaciones_Coleccion(idcoleccion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_Coleccion(idcoleccion);
            }
        });

}

function EliminarPublicaciones_Coleccion(idcoleccion) {
    let urlEliminar = urlController + "Publicaciones_Coleccion/DeletePublicaciones_Coleccion?id_coleccion=" + idcoleccion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_Coleccion();
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
