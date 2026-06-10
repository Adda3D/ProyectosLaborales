var isUpdateDecVie_AlcanceSolicitud = false;
var DataTableDecVie_AlcanceSolicitud = null;

$(document).ready(function () {
    LoadDataTableDecVie_AlcanceSolicitud();
});

function LoadDataTableDecVie_AlcanceSolicitud() {
    DataTableDecVie_AlcanceSolicitud = $('#tblDecVie_AlcanceSolicitud').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_AlcanceSolicitud/GetDataTableDecVie_AlcanceSolicitud"
        },      
        "columns": [
            { "data": "nmalcancesolicitud", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_AlcanceSolicitud(' + row.id_alcancesolicitud + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_AlcanceSolicitud" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_AlcanceSolicitud(' + row.id_alcancesolicitud + ',`' + row.nmalcancesolicitud + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_AlcanceSolicitud() {
    DataTableDecVie_AlcanceSolicitud.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_AlcanceSolicitud(formF, botonClose) {
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
                if (!isUpdateDecVie_AlcanceSolicitud) {                                          
                    ExisteDecVie_AlcanceSolicitud()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_AlcanceSolicitud(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_AlcanceSolicitud(botonClose);
                }              
            }
        }
    }
}

function ExisteDecVie_AlcanceSolicitud() {    
    let nmalcancesolicitud = $("#txtCdDecVieAlcanceSolicitud").val();   
    let urlValidar = urlController + "DecVie_AlcanceSolicitud/GetDecVie_AlcanceSolicitudNombre?cd_nmalcancesolicitud=" + nmalcancesolicitud;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmalcancesolicitud + " ya está registrado.";
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

function AddUpdateDecVie_AlcanceSolicitud(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_AlcanceSolicitud/UpdateDecVie_AlcanceSolicitud";

    objData.id_alcancesolicitud = ($("#spanIdDecVie_AlcanceSolicitud")[0].innerText == '') ? undefined : $("#spanIdDecVie_AlcanceSolicitud")[0].innerText;
    objData.nmalcancesolicitud = $("#txtCdDecVieAlcanceSolicitud").val();
    objData.observaciones = $("#txtDecVie_AlcanceSolicitud").val();

    if (objData.id_alcancesolicitud == undefined) {
        urlUpdate = urlController + "DecVie_AlcanceSolicitud/InsertDecVie_AlcanceSolicitud";        
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

            RefreshDataTableDecVie_AlcanceSolicitud();
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

function CrearDecVie_AlcanceSolicitud() {
    $( "#txtCdDecVieAlcanceSolicitud" ).prop( "disabled", false );
    $("#spanIdDecVie_AlcanceSolicitud")[0].innerText = '';
    $("#txtCdDecVieAlcanceSolicitud").val('');
    $("#txtDecVie_AlcanceSolicitud").val('');
    isUpdateDecVie_AlcanceSolicitud = false;

    removeValidationFormByForm('formDecVie_AlcanceSolicitud');
}

function EditarDecVie_AlcanceSolicitud(idalcancesolicitud) {   
    removeValidationFormByForm('formDecVie_AlcanceSolicitud'); 
    let urlEditar = urlController + "DecVie_AlcanceSolicitud/GetDecVie_AlcanceSolicitudDetails?id_alcancesolicitud=" + idalcancesolicitud;
    isUpdateDecVie_AlcanceSolicitud = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_AlcanceSolicitud")[0].innerText = datos.id_alcancesolicitud;
            $("#txtCdDecVieAlcanceSolicitud").val(datos.nmalcancesolicitud);
            $("#txtDecVie_AlcanceSolicitud").val(datos.observaciones);
            $( "#txtCdDecVieAlcanceSolicitud" ).prop( "disabled", false );            
            isUpdateDecVie_AlcanceSolicitud = true;
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

function ValidarEliminarDecVie_AlcanceSolicitud(idalcancesolicitud, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_AlcanceSolicitud(idalcancesolicitud);
            }
        });

}

function EliminarDecVie_AlcanceSolicitud(idalcancesolicitud) {
    let urlEliminar = urlController + "DecVie_AlcanceSolicitud/DeleteDecVie_AlcanceSolicitud?id_alcancesolicitud=" + idalcancesolicitud;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_AlcanceSolicitud();
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
