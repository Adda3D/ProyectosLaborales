var isUpdatePublicaciones_DivulgacionMedios = false;
var DataTablePublicaciones_DivulgacionMedios = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_DivulgacionMedios();
});

function LoadDataTablePublicaciones_DivulgacionMedios() {
    DataTablePublicaciones_DivulgacionMedios = $('#tblPublicaciones_DivulgacionMedios').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DivulgacionMedios/GetDataTablePublicaciones_DivulgacionMedios"
        },      
        "columns": [
            { "data": "nommedio", "orderable": true },          
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_DivulgacionMedios(' + row.id_medio + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DivulgacionMedios" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_DivulgacionMedios(' + row.id_medio + ',`' + row.nommedio + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_DivulgacionMedios() {
    DataTablePublicaciones_DivulgacionMedios.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_DivulgacionMedios(formF, botonClose) {
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
                if (!isUpdatePublicaciones_DivulgacionMedios) {                                          
                    ExistePublicaciones_DivulgacionMedios()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_DivulgacionMedios(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_DivulgacionMedios(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_DivulgacionMedios() {    
    let nommedio = $("#txtMedioPublicaciones_DivulgacionMedios").val();   
    let urlValidar = urlController + "Publicaciones_DivulgacionMedios/GetPublicaciones_DivulgacionMediosNombre?cd_nommedio=" + nommedio;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nommedio + " ya está registrado.";
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

function AddUpdatePublicaciones_DivulgacionMedios(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_DivulgacionMedios/UpdatePublicaciones_DivulgacionMedios";

    objData.id_medio = ($("#spanIdPublicaciones_DivulgacionMedios")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_DivulgacionMedios")[0].innerText;
    objData.nommedio = $("#txtMedioPublicaciones_DivulgacionMedios").val();

    if (objData.id_medio == undefined) {
        urlUpdate = urlController + "Publicaciones_DivulgacionMedios/InsertPublicaciones_DivulgacionMedios";        
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

            RefreshDataTablePublicaciones_DivulgacionMedios();
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

function CrearPublicaciones_DivulgacionMedios() {
    $( "#txtMedioPublicaciones_DivulgacionMedios" ).prop( "disabled", false );
    $("#spanIdPublicaciones_DivulgacionMedios")[0].innerText = '';
    $("#txtMedioPublicaciones_DivulgacionMedios").val('');
    isUpdatePublicaciones_DivulgacionMedios = false;

    removeValidationFormByForm('formPublicaciones_DivulgacionMedios');
}

function EditarPublicaciones_DivulgacionMedios(idmedio) {   
    removeValidationFormByForm('formPublicaciones_DivulgacionMedios'); 
    let urlEditar = urlController + "Publicaciones_DivulgacionMedios/GetPublicaciones_DivulgacionMediosDetails?id_medio=" + idmedio;
    isUpdatePublicaciones_DivulgacionMedios = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_DivulgacionMedios")[0].innerText = datos.id_medio;
            $("#txtMedioPublicaciones_DivulgacionMedios").val(datos.nommedio);    
            $( "#txtMedioPublicaciones_DivulgacionMedios" ).prop( "disabled", false );            
            isUpdatePublicaciones_DivulgacionMedios = true;
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

function ValidarEliminarPublicaciones_DivulgacionMedios(idmedio, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DivulgacionMedios(idmedio);
            }
        });

}

function EliminarPublicaciones_DivulgacionMedios(idmedio) {
    let urlEliminar = urlController + "Publicaciones_DivulgacionMedios/DeletePublicaciones_DivulgacionMedios?id_medio=" + idmedio;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_DivulgacionMedios();
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
