var isUpdateDecVie_EstadoPreAval = false;
var DataTableDecVie_EstadoPreAval = null;

$(document).ready(function () {
    LoadDataTableDecVie_EstadoPreAval();
});

function LoadDataTableDecVie_EstadoPreAval() {
    DataTableDecVie_EstadoPreAval = $('#tblDecVie_EstadoPreAval').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_EstadoPreAval/GetDataTableDecVie_EstadoPreAval"
        },      
        "columns": [
            { "data": "nmestadopreaval", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_EstadoPreAval(' + row.id_estadopreaval + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_EstadoPreAval" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_EstadoPreAval(' + row.id_estadopreaval + ',`' + row.nmestadopreaval + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_EstadoPreAval() {
    DataTableDecVie_EstadoPreAval.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_EstadoPreAval(formF, botonClose) {
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
                if (!isUpdateDecVie_EstadoPreAval) {                                          
                    ExisteDecVie_EstadoPreAval()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_EstadoPreAval(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_EstadoPreAval(botonClose);
                }                            
            }
        }
    }
}

function ExisteDecVie_EstadoPreAval() {    
    let nmestadopreaval = $("#txtCdDecVieEstadoPreAval").val();   
    let urlValidar = urlController + "DecVie_EstadoPreAval/GetDecVie_EstadoPreAvalNombre?cd_nmestadopreaval=" + nmestadopreaval;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadopreaval + " ya está registrado.";
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

function AddUpdateDecVie_EstadoPreAval(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_EstadoPreAval/UpdateDecVie_EstadoPreAval";

    objData.id_estadopreaval = ($("#spanIdDecVie_EstadoPreAval")[0].innerText == '') ? undefined : $("#spanIdDecVie_EstadoPreAval")[0].innerText;
    objData.nmestadopreaval = $("#txtCdDecVieEstadoPreAval").val();
    objData.observaciones = $("#txtDecVie_EstadoPreAval").val();

    if (objData.id_estadopreaval == undefined) {
        urlUpdate = urlController + "DecVie_EstadoPreAval/InsertDecVie_EstadoPreAval";        
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

            RefreshDataTableDecVie_EstadoPreAval();
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

function CrearDecVie_EstadoPreAval() {
    $( "#txtCdDecVieEstadoPreAval" ).prop( "disabled", false );
    $("#spanIdDecVie_EstadoPreAval")[0].innerText = '';
    $("#txtCdDecVieEstadoPreAval").val('');
    $("#txtDecVie_EstadoPreAval").val('');
    isUpdateDecVie_EstadoPreAval = false;

    removeValidationFormByForm('formDecVie_EstadoPreAval');
}

function EditarDecVie_EstadoPreAval(idestadopreaval) {   
    removeValidationFormByForm('formDecVie_EstadoPreAval'); 
    let urlEditar = urlController + "DecVie_EstadoPreAval/GetDecVie_EstadoPreAvalDetails?id_estadopreaval=" + idestadopreaval;
    isUpdateDecVie_EstadoPreAval = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_EstadoPreAval")[0].innerText = datos.id_estadopreaval;
            $("#txtCdDecVieEstadoPreAval").val(datos.nmestadopreaval);
            $("#txtDecVie_EstadoPreAval").val(datos.observaciones);
            $( "#txtCdDecVieEstadoPreAval" ).prop( "disabled", false );            
            isUpdateDecVie_EstadoPreAval = true;
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

function ValidarEliminarDecVie_EstadoPreAval(idestadopreaval, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_EstadoPreAval(idestadopreaval);
            }
        });

}

function EliminarDecVie_EstadoPreAval(idestadopreaval) {
    let urlEliminar = urlController + "DecVie_EstadoPreAval/DeleteDecVie_EstadoPreAval?id_estadopreaval=" + idestadopreaval;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_EstadoPreAval();
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
