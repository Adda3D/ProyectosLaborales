var isUpdateDecVie_Estado = false;
var DataTableDecVie_Estado = null;

$(document).ready(function () {
    LoadDataTableDecVie_Estado();
});

function LoadDataTableDecVie_Estado() {
    DataTableDecVie_Estado = $('#tblDecVie_Estado').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_Estado/GetDataTableDecVie_Estado"
        },      
        "columns": [
            { "data": "nmdecvieestado", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_Estado(' + row.id_decvieestado + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_Estado" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_Estado(' + row.id_decvieestado + ',`' + row.nmdecvieestado + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_Estado() {
    DataTableDecVie_Estado.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_Estado(formF, botonClose) {
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
                if (!isUpdateDecVie_Estado) {                                          
                    ExisteDecVie_Estado()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_Estado(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_Estado(botonClose);
                }           
            }
        }
    }
}

function ExisteDecVie_Estado() {    
    let nmdecvieestado = $("#txtCdDecVieEstado").val();   
    let urlValidar = urlController + "DecVie_Estado/GetDecVie_EstadoNombre?cd_nmdecvieestado=" + nmdecvieestado;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmdecvieestado + " ya está registrado.";
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

function AddUpdateDecVie_Estado(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_Estado/UpdateDecVie_Estado";

    objData.id_decvieestado = ($("#spanIdDecVie_Estado")[0].innerText == '') ? undefined : $("#spanIdDecVie_Estado")[0].innerText;
    objData.nmdecvieestado = $("#txtCdDecVieEstado").val();
    objData.observaciones = $("#txtDecVie_Estado").val();

    if (objData.id_decvieestado == undefined) {
        urlUpdate = urlController + "DecVie_Estado/InsertDecVie_Estado";        
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

            RefreshDataTableDecVie_Estado();
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

function CrearDecVie_Estado() {
    $( "#txtCdDecVieEstado" ).prop( "disabled", false );
    $("#spanIdDecVie_Estado")[0].innerText = '';
    $("#txtCdDecVieEstado").val('');
    $("#txtDecVie_Estado").val('');
    isUpdateDecVie_Estado = false;

    removeValidationFormByForm('formDecVie_Estado');
}

function EditarDecVie_Estado(iddecvieestado) {   
    removeValidationFormByForm('formDecVie_Estado'); 
    let urlEditar = urlController + "DecVie_Estado/GetDecVie_EstadoDetails?id_decvieestado=" + iddecvieestado;
    isUpdateDecVie_Estado = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_Estado")[0].innerText = datos.id_decvieestado;
            $("#txtCdDecVieEstado").val(datos.nmdecvieestado);
            $("#txtDecVie_Estado").val(datos.observaciones);
            $( "#txtCdDecVieEstado" ).prop( "disabled", false );            
            isUpdateDecVie_Estado = true;
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

function ValidarEliminarDecVie_Estado(iddecvieestado, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_Estado(iddecvieestado);
            }
        });

}

function EliminarDecVie_Estado(iddecvieestado) {
    let urlEliminar = urlController + "DecVie_Estado/DeleteDecVie_Estado?id_decvieestado=" + iddecvieestado;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_Estado();
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
