var isUpdatePublicaciones_ImpresionEncuadernacion = false;
var DataTablePublicaciones_ImpresionEncuadernacion = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_ImpresionEncuadernacion();
});

function LoadDataTablePublicaciones_ImpresionEncuadernacion() {
    DataTablePublicaciones_ImpresionEncuadernacion = $('#tblPublicaciones_ImpresionEncuadernacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_ImpresionEncuadernacion/GetDataTablePublicaciones_ImpresionEncuadernacion"
        },      
        "columns": [
            { "data": "nmencuadernacion", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_ImpresionEncuadernacion(' + row.id_encuadernacion + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_ImpresionEncuadernacion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_ImpresionEncuadernacion(' + row.id_encuadernacion + ',`' + row.nmencuadernacion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_ImpresionEncuadernacion() {
    DataTablePublicaciones_ImpresionEncuadernacion.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_ImpresionEncuadernacion(formF, botonClose) {
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
                if (!isUpdatePublicaciones_ImpresionEncuadernacion) {                                          
                    ExistePublicaciones_ImpresionEncuadernacion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_ImpresionEncuadernacion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_ImpresionEncuadernacion(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_ImpresionEncuadernacion() {    
    let nmencuadernacion = $("#txtCdPublicacionesImpresionEncuadernacion").val();   
    let urlValidar = urlController + "Publicaciones_ImpresionEncuadernacion/GetPublicaciones_ImpresionEncuadernacionNombre?cd_nmencuadernacion=" + nmencuadernacion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmencuadernacion + " ya está registrado.";
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

function AddUpdatePublicaciones_ImpresionEncuadernacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_ImpresionEncuadernacion/UpdatePublicaciones_ImpresionEncuadernacion";

    objData.id_encuadernacion = ($("#spanIdPublicaciones_ImpresionEncuadernacion")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_ImpresionEncuadernacion")[0].innerText;
    objData.nmencuadernacion = $("#txtCdPublicacionesImpresionEncuadernacion").val();
    objData.observaciones = $("#txtPublicaciones_ImpresionEncuadernacion").val();

    if (objData.id_encuadernacion == undefined) {
        urlUpdate = urlController + "Publicaciones_ImpresionEncuadernacion/InsertPublicaciones_ImpresionEncuadernacion";        
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

            RefreshDataTablePublicaciones_ImpresionEncuadernacion();
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

function CrearPublicaciones_ImpresionEncuadernacion() {
    $( "#txtCdPublicacionesImpresionEncuadernacion" ).prop( "disabled", false );
    $("#spanIdPublicaciones_ImpresionEncuadernacion")[0].innerText = '';
    $("#txtCdPublicacionesImpresionEncuadernacion").val('');
    $("#txtPublicaciones_ImpresionEncuadernacion").val('');
    isUpdatePublicaciones_ImpresionEncuadernacion = false;

    removeValidationFormByForm('formPublicaciones_ImpresionEncuadernacion');
}

function EditarPublicaciones_ImpresionEncuadernacion(idencuadernacion) {   
    removeValidationFormByForm('formPublicaciones_ImpresionEncuadernacion'); 
    let urlEditar = urlController + "Publicaciones_ImpresionEncuadernacion/GetPublicaciones_ImpresionEncuadernacionDetails?id_encuadernacion=" + idencuadernacion;
    isUpdatePublicaciones_ImpresionEncuadernacion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_ImpresionEncuadernacion")[0].innerText = datos.id_encuadernacion;
            $("#txtCdPublicacionesImpresionEncuadernacion").val(datos.nmencuadernacion);
            $("#txtPublicaciones_ImpresionEncuadernacion").val(datos.observaciones);
            $( "#txtCdPublicacionesImpresionEncuadernacion" ).prop( "disabled", false );            
            isUpdatePublicaciones_ImpresionEncuadernacion = true;
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

function ValidarEliminarPublicaciones_ImpresionEncuadernacion(idencuadernacion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_ImpresionEncuadernacion(idencuadernacion);
            }
        });

}

function EliminarPublicaciones_ImpresionEncuadernacion(idencuadernacion) {
    let urlEliminar = urlController + "Publicaciones_ImpresionEncuadernacion/DeletePublicaciones_ImpresionEncuadernacion?id_encuadernacion=" + idencuadernacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_ImpresionEncuadernacion();
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
