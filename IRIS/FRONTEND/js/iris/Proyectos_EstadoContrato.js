var isUpdateProyectos_EstadoContrato = false;
var DataTableProyectos_EstadoContrato = null;

$(document).ready(function () {
    LoadDataTableProyectos_EstadoContrato();
});

function LoadDataTableProyectos_EstadoContrato() {
    DataTableProyectos_EstadoContrato = $('#tblProyectos_EstadoContrato').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_EstadoContrato/GetDataTableProyectos_EstadoContrato"
        },      
        "columns": [
            { "data": "estadocontrato", "orderable": true },
            { "data": "detalles", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_EstadoContrato(' + row.id_estadocontrato + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_EstadoContrato" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_EstadoContrato(' + row.id_estadocontrato + ',`' + row.estadocontrato + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_EstadoContrato() {
    DataTableProyectos_EstadoContrato.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_EstadoContrato(formF, botonClose) {
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
                if ($("#spanIdProyectos_EstadoContrato")[0].innerText == '') {
                    ExisteProyectos_EstadoContrato()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_EstadoContrato(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_EstadoContrato(botonClose);
                }                                                                                    
            }
        }
    }
}

function ExisteProyectos_EstadoContrato() {    
    let estadocontrato = $("#txtCdProyectosEstadoContrato").val();   
    let urlValidar = urlController + "Proyectos_EstadoContrato/GetProyectos_EstadoContratoEstado?cd_estadocontrato=" + estadocontrato;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El Estado " + estadocontrato + " ya está registrado.";
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

function AddUpdateProyectos_EstadoContrato(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_EstadoContrato/UpdateProyectos_EstadoContrato";

    objData.id_estadocontrato = ($("#spanIdProyectos_EstadoContrato")[0].innerText == '') ? undefined : $("#spanIdProyectos_EstadoContrato")[0].innerText;
    objData.estadocontrato = $("#txtCdProyectosEstadoContrato").val();
    objData.detalles = $("#txtProyectos_EstadoContrato").val();

    if (objData.id_estadocontrato == undefined) {
        urlUpdate = urlController + "Proyectos_EstadoContrato/InsertProyectos_EstadoContrato";        
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

            RefreshDataTableProyectos_EstadoContrato();
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

function CrearProyectos_EstadoContrato() {    
    $("#spanIdProyectos_EstadoContrato")[0].innerText = '';
    $("#txtCdProyectosEstadoContrato").val('');
    $("#txtProyectos_EstadoContrato").val('');
    isUpdateProyectos_EstadoContrato = false;

    removeValidationFormByForm('formProyectos_EstadoContrato');
}

function EditarProyectos_EstadoContrato(idestadocontrato) {   
    removeValidationFormByForm('formProyectos_EstadoContrato'); 
    let urlEditar = urlController + "Proyectos_EstadoContrato/GetProyectos_EstadoContratoDetails?id_estadocontrato=" + idestadocontrato;
    isUpdateProyectos_EstadoContrato = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_EstadoContrato")[0].innerText = datos.id_estadocontrato;
            $("#txtCdProyectosEstadoContrato").val(datos.estadocontrato);
            $("#txtProyectos_EstadoContrato").val(datos.detalles);            
            isUpdateProyectos_EstadoContrato = true;
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

function ValidarEliminarProyectos_EstadoContrato(idestadocontrato, Estadocompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + Estadocompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_EstadoContrato(idestadocontrato);
            }
        });

}

function EliminarProyectos_EstadoContrato(idestadocontrato) {
    let urlEliminar = urlController + "Proyectos_EstadoContrato/DeleteProyectos_EstadoContrato?id_estadocontrato=" + idestadocontrato;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_EstadoContrato();
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
