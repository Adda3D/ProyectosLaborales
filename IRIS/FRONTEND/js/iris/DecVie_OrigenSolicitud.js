var isUpdateDecVie_OrigenSolicitud = false;
var DataTableDecVie_OrigenSolicitud = null;

$(document).ready(function () {
    LoadDataTableDecVie_OrigenSolicitud();
});

function LoadDataTableDecVie_OrigenSolicitud() {
    DataTableDecVie_OrigenSolicitud = $('#tblDecVie_OrigenSolicitud').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_OrigenSolicitud/GetDataTableDecVie_OrigenSolicitud"
        },      
        "columns": [
            { "data": "nmorigensolicitud", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_OrigenSolicitud(' + row.id_origensolicitud + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_OrigenSolicitud" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_OrigenSolicitud(' + row.id_origensolicitud + ',`' + row.nmorigensolicitud + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_OrigenSolicitud() {
    DataTableDecVie_OrigenSolicitud.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_OrigenSolicitud(formF, botonClose) {
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
                if (!isUpdateDecVie_OrigenSolicitud) {                                          
                    ExisteDecVie_OrigenSolicitud()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_OrigenSolicitud(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_OrigenSolicitud(botonClose);
                }              
            }
        }
    }
}

function ExisteDecVie_OrigenSolicitud() {    
    let nmorigensolicitud = $("#txtCdDecVieOrigenSolicitud").val();   
    let urlValidar = urlController + "DecVie_OrigenSolicitud/GetDecVie_OrigenSolicitudNombre?cd_nmorigensolicitud=" + nmorigensolicitud;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmorigensolicitud + " ya está registrado.";
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

function AddUpdateDecVie_OrigenSolicitud(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_OrigenSolicitud/UpdateDecVie_OrigenSolicitud";

    objData.id_origensolicitud = ($("#spanIdDecVie_OrigenSolicitud")[0].innerText == '') ? undefined : $("#spanIdDecVie_OrigenSolicitud")[0].innerText;
    objData.nmorigensolicitud = $("#txtCdDecVieOrigenSolicitud").val();
    objData.observaciones = $("#txtDecVie_OrigenSolicitud").val();

    if (objData.id_origensolicitud == undefined) {
        urlUpdate = urlController + "DecVie_OrigenSolicitud/InsertDecVie_OrigenSolicitud";        
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

            RefreshDataTableDecVie_OrigenSolicitud();
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

function CrearDecVie_OrigenSolicitud() {
    $( "#txtCdDecVieOrigenSolicitud" ).prop( "disabled", false );
    $("#spanIdDecVie_OrigenSolicitud")[0].innerText = '';
    $("#txtCdDecVieOrigenSolicitud").val('');
    $("#txtDecVie_OrigenSolicitud").val('');
    isUpdateDecVie_OrigenSolicitud = false;

    removeValidationFormByForm('formDecVie_OrigenSolicitud');
}

function EditarDecVie_OrigenSolicitud(idorigensolicitud) {   
    removeValidationFormByForm('formDecVie_OrigenSolicitud'); 
    let urlEditar = urlController + "DecVie_OrigenSolicitud/GetDecVie_OrigenSolicitudDetails?id_origensolicitud=" + idorigensolicitud;
    isUpdateDecVie_OrigenSolicitud = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_OrigenSolicitud")[0].innerText = datos.id_origensolicitud;
            $("#txtCdDecVieOrigenSolicitud").val(datos.nmorigensolicitud);
            $("#txtDecVie_OrigenSolicitud").val(datos.observaciones);
            $( "#txtCdDecVieOrigenSolicitud" ).prop( "disabled", false );            
            isUpdateDecVie_OrigenSolicitud = true;
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

function ValidarEliminarDecVie_OrigenSolicitud(idorigensolicitud, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_OrigenSolicitud(idorigensolicitud);
            }
        });

}

function EliminarDecVie_OrigenSolicitud(idorigensolicitud) {
    let urlEliminar = urlController + "DecVie_OrigenSolicitud/DeleteDecVie_OrigenSolicitud?id_origensolicitud=" + idorigensolicitud;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_OrigenSolicitud();
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
