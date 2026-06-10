var isUpdateDecVie_ActosAdministrativosTipo = false;
var DataTableDecVie_ActosAdministrativosTipo = null;

$(document).ready(function () {
    LoadDataTableDecVie_ActosAdministrativosTipo();
});

function LoadDataTableDecVie_ActosAdministrativosTipo() {
    DataTableDecVie_ActosAdministrativosTipo = $('#tblDecVie_ActosAdministrativosTipo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_ActosAdministrativosTipo/GetDataTableDecVie_ActosAdministrativosTipo"
        },      
        "columns": [
            { "data": "nmidtipoactoadministrativo", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="Editarnmidtipoactoadministrativo(' + row.id_tipoactoadministrativo + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_ActosAdministrativosTipo" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_ActosAdministrativosTipo(' + row.id_tipoactoadministrativo + ',`' + row.nmidtipoactoadministrativo + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_ActosAdministrativosTipo() {
    DataTableDecVie_ActosAdministrativosTipo.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_ActosAdministrativosTipo(formF, botonClose) {
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
                if ($("#spanIdTipoActoAdministrativo")[0].innerText == '') {
                    ExisteDecVie_ActosAdministrativosTipo()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_ActosAdministrativosTipo(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_ActosAdministrativosTipo(botonClose);
                }
            }
        }
    }
}

function ExisteDecVie_ActosAdministrativosTipo() {    
    let nmidtipoactoadministrativo = $("#txtTipoActoAdministrativo").val();   
    let urlValidar = urlController + "DecVie_ActosAdministrativosTipo/GetDecVie_ActosAdministrativosTipoNombre?cd_nmidtipoactoadministrativo=" + nmidtipoactoadministrativo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmidtipoactoadministrativo + " ya está registrado.";
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

function AddUpdateDecVie_ActosAdministrativosTipo(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_ActosAdministrativosTipo/UpdateDecVie_ActosAdministrativosTipo";

    objData.id_tipoactoadministrativo = ($("#spanIdTipoActoAdministrativo")[0].innerText == '') ? undefined : $("#spanIdTipoActoAdministrativo")[0].innerText;
    objData.nmidtipoactoadministrativo = $("#txtTipoActoAdministrativo").val();    

    if (objData.id_tipoactoadministrativo == undefined) {
        urlUpdate = urlController + "DecVie_ActosAdministrativosTipo/InsertDecVie_ActosAdministrativosTipo";        
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

            RefreshDataTableDecVie_ActosAdministrativosTipo();
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

function CrearDecVie_ActosAdministrativosTipo() {
    $( "#txtTipoActoAdministrativo" ).prop( "disabled", false );
    $("#spanIdTipoActoAdministrativo")[0].innerText = '';   
    $("#txtTipoActoAdministrativo").val('');
    isUpdateDecVie_ActosAdministrativosTipo = false;

    removeValidationFormByForm('formDecVie_ActosAdministrativosTipo');
}

function Editarnmidtipoactoadministrativo(idtipoactoadministrativo) {   
    removeValidationFormByForm('formDecVie_ActosAdministrativosTipo'); 
    let urlEditar = urlController + "DecVie_ActosAdministrativosTipo/GetDecVie_ActosAdministrativosTipoDetails?id_tipoactoadministrativo=" + idtipoactoadministrativo;
    isUpdateDecVie_ActosAdministrativosTipo = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdTipoActoAdministrativo")[0].innerText = datos.id_tipoactoadministrativo;
            $("#txtTipoActoAdministrativo").val(datos.nmidtipoactoadministrativo);         
            isUpdateDecVie_ActosAdministrativosTipo = true;
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

function ValidarEliminarDecVie_ActosAdministrativosTipo(id_tipoactoadministrativo, nmidtipoactoadministrativo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nmidtipoactoadministrativo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_ActosAdministrativosTipo(id_tipoactoadministrativo);
            }
        });

}

function EliminarDecVie_ActosAdministrativosTipo(idtipoactoadministrativo) {
    let urlEliminar = urlController + "DecVie_ActosAdministrativosTipo/DeleteDecVie_ActosAdministrativosTipo?id_tipoactoadministrativo=" + idtipoactoadministrativo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_ActosAdministrativosTipo();
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
