var isUpdateDecVie_DerechosPeticionEstado = false;
var DataTableDecVie_DerechosPeticionEstado = null;

$(document).ready(function () {
    LoadDataTableDecVie_DerechosPeticionEstado();
});

function LoadDataTableDecVie_DerechosPeticionEstado() {
    DataTableDecVie_DerechosPeticionEstado = $('#tblDecVie_DerechosPeticionEstado').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_DerechosPeticionEstado/GetDataTableDecVie_DerechosPeticionEstado"
        },      
        "columns": [
            { "data": "nmestadoderpet", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_DerechosPeticionEstado(' + row.id_estadoderpet + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_DerechosPeticionEstado" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_DerechosPeticionEstado(' + row.id_estadoderpet + ',`' + row.nmestadoderpet + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_DerechosPeticionEstado() {
    DataTableDecVie_DerechosPeticionEstado.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_DerechosPeticionEstado(formF, botonClose) {
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
                if (!isUpdateDecVie_DerechosPeticionEstado) {                                          
                    ExisteDecVie_DerechosPeticionEstado()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_DerechosPeticionEstado(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_DerechosPeticionEstado(botonClose);
                }           
            }
        }
    }
}

function ExisteDecVie_DerechosPeticionEstado() {    
    let nmestadoderpet = $("#txtCdDecVieDerechosPeticionEstado").val();   
    let urlValidar = urlController + "DecVie_DerechosPeticionEstado/GetDecVie_DerechosPeticionEstadoNombre?cd_nmestadoderpet=" + nmestadoderpet;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadoderpet + " ya está registrado.";
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

function AddUpdateDecVie_DerechosPeticionEstado(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_DerechosPeticionEstado/UpdateDecVie_DerechosPeticionEstado";

    objData.id_estadoderpet = ($("#spanIdDecVie_DerechosPeticionEstado")[0].innerText == '') ? undefined : $("#spanIdDecVie_DerechosPeticionEstado")[0].innerText;
    objData.nmestadoderpet = $("#txtCdDecVieDerechosPeticionEstado").val();
    objData.observaciones = $("#txtDecVie_DerechosPeticionEstado").val();

    if (objData.id_estadoderpet == undefined) {
        urlUpdate = urlController + "DecVie_DerechosPeticionEstado/InsertDecVie_DerechosPeticionEstado";        
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

            RefreshDataTableDecVie_DerechosPeticionEstado();
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

function CrearDecVie_DerechosPeticionEstado() {
    $( "#txtCdDecVieDerechosPeticionEstado" ).prop( "disabled", false );
    $("#spanIdDecVie_DerechosPeticionEstado")[0].innerText = '';
    $("#txtCdDecVieDerechosPeticionEstado").val('');
    $("#txtDecVie_DerechosPeticionEstado").val('');
    isUpdateDecVie_DerechosPeticionEstado = false;

    removeValidationFormByForm('formDecVie_DerechosPeticionEstado');
}

function EditarDecVie_DerechosPeticionEstado(idestadoderpet) {   
    removeValidationFormByForm('formDecVie_DerechosPeticionEstado'); 
    let urlEditar = urlController + "DecVie_DerechosPeticionEstado/GetDecVie_DerechosPeticionEstadoDetails?id_estadoderpet=" + idestadoderpet;
    isUpdateDecVie_DerechosPeticionEstado = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_DerechosPeticionEstado")[0].innerText = datos.id_estadoderpet;
            $("#txtCdDecVieDerechosPeticionEstado").val(datos.nmestadoderpet);
            $("#txtDecVie_DerechosPeticionEstado").val(datos.observaciones);
            $( "#txtCdDecVieDerechosPeticionEstado" ).prop( "disabled", false );            
            isUpdateDecVie_DerechosPeticionEstado = true;
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

function ValidarEliminarDecVie_DerechosPeticionEstado(idestadoderpet, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_DerechosPeticionEstado(idestadoderpet);
            }
        });

}

function EliminarDecVie_DerechosPeticionEstado(idestadoderpet) {
    let urlEliminar = urlController + "DecVie_DerechosPeticionEstado/DeleteDecVie_DerechosPeticionEstado?id_estadoderpet=" + idestadoderpet;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_DerechosPeticionEstado();
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
