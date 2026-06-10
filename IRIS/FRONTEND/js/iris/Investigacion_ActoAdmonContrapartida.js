var isUpdateInvestigacion_ActoAdmonContrapartida = false;
var DataTableInvestigacion_ActoAdmonContrapartida = null;

$(document).ready(function () {
    LoadDataTableInvestigacion_ActoAdmonContrapartida();
});

function LoadDataTableInvestigacion_ActoAdmonContrapartida() {
    DataTableInvestigacion_ActoAdmonContrapartida = $('#tblInvestigacion_ActoAdmonContrapartida').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Investigacion_ActoAdmonContrapartida/GetDataTableInvestigacion_ActoAdmonContrapartida"
        },      
        "columns": [
            { "data": "codigohermes", "orderable": true },
            { "data": "actoadministrativo", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarInvestigacion_ActoAdmonContrapartida(' + row.id_actoadmoncontrapartida + ')" data-bs-toggle="modal" data-bs-target="#ModalInvestigacion_ActoAdmonContrapartida" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarInvestigacion_ActoAdmonContrapartida(' + row.id_actoadmoncontrapartida + ',`' + row.codigohermes + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableInvestigacion_ActoAdmonContrapartida() {
    DataTableInvestigacion_ActoAdmonContrapartida.ajax.reload(null, false);    
}

function ValidatePostUpdateInvestigacion_ActoAdmonContrapartida(formF, botonClose) {
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
                if (!isUpdateInvestigacion_ActoAdmonContrapartida) {                                          
                    ExisteInvestigacion_ActoAdmonContrapartida()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateInvestigacion_ActoAdmonContrapartida(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateInvestigacion_ActoAdmonContrapartida(botonClose);
                }                            
            }
        }
    }
}

function ExisteInvestigacion_ActoAdmonContrapartida() {    
    let codigohermes = $("#txtCdInvestigacionActoAdmonContrapartida").val();   
    let urlValidar = urlController + "Investigacion_ActoAdmonContrapartida/GetInvestigacion_ActoAdmonContrapartidaCodigo?cd_codigohermes=" + codigohermes;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + codigohermes + " ya está registrado.";
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

function AddUpdateInvestigacion_ActoAdmonContrapartida(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Investigacion_ActoAdmonContrapartida/UpdateInvestigacion_ActoAdmonContrapartida";

    objData.id_actoadmoncontrapartida = ($("#spanIdInvestigacion_ActoAdmonContrapartida")[0].innerText == '') ? undefined : $("#spanIdInvestigacion_ActoAdmonContrapartida")[0].innerText;
    objData.codigohermes = $("#txtCdInvestigacionActoAdmonContrapartida").val();
    objData.actoadministrativo = $("#txtInvestigacion_ActoAdmonContrapartida").val();

    if (objData.id_actoadmoncontrapartida == undefined) {
        urlUpdate = urlController + "Investigacion_ActoAdmonContrapartida/InsertInvestigacion_ActoAdmonContrapartida";        
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

            RefreshDataTableInvestigacion_ActoAdmonContrapartida();
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

function CrearInvestigacion_ActoAdmonContrapartida() {
    $( "#txtCdInvestigacionActoAdmonContrapartida" ).prop( "disabled", false );
    $("#spanIdInvestigacion_ActoAdmonContrapartida")[0].innerText = '';
    $("#txtCdInvestigacionActoAdmonContrapartida").val('');
    $("#txtInvestigacion_ActoAdmonContrapartida").val('');
    isUpdateInvestigacion_ActoAdmonContrapartida = false;

    removeValidationFormByForm('formInvestigacion_ActoAdmonContrapartida');
}

function EditarInvestigacion_ActoAdmonContrapartida(idactoadmoncontrapartida) {   
    removeValidationFormByForm('formInvestigacion_ActoAdmonContrapartida'); 
    let urlEditar = urlController + "Investigacion_ActoAdmonContrapartida/GetInvestigacion_ActoAdmonContrapartidaDetails?id_actoadmoncontrapartida=" + idactoadmoncontrapartida;
    isUpdateInvestigacion_ActoAdmonContrapartida = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdInvestigacion_ActoAdmonContrapartida")[0].innerText = datos.id_actoadmoncontrapartida;
            $("#txtCdInvestigacionActoAdmonContrapartida").val(datos.codigohermes);
            $("#txtInvestigacion_ActoAdmonContrapartida").val(datos.actoadministrativo);
            $( "#txtCdInvestigacionActoAdmonContrapartida" ).prop( "disabled", false );            
            isUpdateInvestigacion_ActoAdmonContrapartida = true;
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

function ValidarEliminarInvestigacion_ActoAdmonContrapartida(idactoadmoncontrapartida, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarInvestigacion_ActoAdmonContrapartida(idactoadmoncontrapartida);
            }
        });

}

function EliminarInvestigacion_ActoAdmonContrapartida(idactoadmoncontrapartida) {
    let urlEliminar = urlController + "Investigacion_ActoAdmonContrapartida/DeleteInvestigacion_ActoAdmonContrapartida?id_actoadmoncontrapartida=" + idactoadmoncontrapartida;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableInvestigacion_ActoAdmonContrapartida();
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
