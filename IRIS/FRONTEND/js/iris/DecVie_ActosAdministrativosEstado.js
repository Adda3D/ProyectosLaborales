var isUpdateDecVie_ActosAdministrativosEstado = false;
var DataTableDecVie_ActosAdministrativosEstado = null;

$(document).ready(function () {
    LoadDataTableDecVie_ActosAdministrativosEstado();
});

function LoadDataTableDecVie_ActosAdministrativosEstado() {
    DataTableDecVie_ActosAdministrativosEstado = $('#tblDecVie_ActosAdministrativosEstado').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_ActosAdministrativosEstado/GetDataTableDecVie_ActosAdministrativosEstado"
        },      
        "columns": [
            { "data": "nmestadoactoadministrativo", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="Editarnmestadoactoadministrativo(' + row.id_estadoactoadministrativo + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_ActosAdministrativosEstado" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_ActosAdministrativosEstado(' + row.id_estadoactoadministrativo + ',`' + row.nmestadoactoadministrativo + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_ActosAdministrativosEstado() {
    DataTableDecVie_ActosAdministrativosEstado.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_ActosAdministrativosEstado(formF, botonClose) {
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
                if ($("#spanIdEstadoActosAdministrativos")[0].innerText == '') {
                    ExisteDecVie_ActosAdministrativosEstado()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_ActosAdministrativosEstado(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_ActosAdministrativosEstado(botonClose);
                }
            }
        }
    }
}

function ExisteDecVie_ActosAdministrativosEstado() {    
    let nmestadoactoadministrativo = $("#txtEstadoActosAdministrativos").val();   
    let urlValidar = urlController + "DecVie_ActosAdministrativosEstado/GetDecVie_ActosAdministrativosEstadoNombre?cd_nmestadoactoadministrativo=" + nmestadoactoadministrativo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El estado " + nmestadoactoadministrativo + " ya está registrado.";
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

function AddUpdateDecVie_ActosAdministrativosEstado(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_ActosAdministrativosEstado/UpdateDecVie_ActosAdministrativosEstado";

    objData.id_estadoactoadministrativo = ($("#spanIdEstadoActosAdministrativos")[0].innerText == '') ? undefined : $("#spanIdEstadoActosAdministrativos")[0].innerText;
    objData.nmestadoactoadministrativo = $("#txtEstadoActosAdministrativos").val();    

    if (objData.id_estadoactoadministrativo == undefined) {
        urlUpdate = urlController + "DecVie_ActosAdministrativosEstado/InsertDecVie_ActosAdministrativosEstado";        
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

            RefreshDataTableDecVie_ActosAdministrativosEstado();
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

function CrearDecVie_ActosAdministrativosEstado() {
    $( "#txtEstadoActosAdministrativos" ).prop( "disabled", false );
    $("#spanIdEstadoActosAdministrativos")[0].innerText = '';   
    $("#txtEstadoActosAdministrativos").val('');
    isUpdateDecVie_ActosAdministrativosEstado = false;

    removeValidationFormByForm('formDecVie_ActosAdministrativosEstado');
}

function Editarnmestadoactoadministrativo(idestadoactoadministrativo) {   
    removeValidationFormByForm('formDecVie_ActosAdministrativosEstado'); 
    let urlEditar = urlController + "DecVie_ActosAdministrativosEstado/GetDecVie_ActosAdministrativosEstadoDetails?id_estadoactoadministrativo=" + idestadoactoadministrativo;
    isUpdateDecVie_ActosAdministrativosEstado = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdEstadoActosAdministrativos")[0].innerText = datos.id_estadoactoadministrativo;
            $("#txtEstadoActosAdministrativos").val(datos.nmestadoactoadministrativo);         
            isUpdateDecVie_ActosAdministrativosEstado = true;
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

function ValidarEliminarDecVie_ActosAdministrativosEstado(id_estadoactoadministrativo, nmestadoactoadministrativo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nmestadoactoadministrativo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_ActosAdministrativosEstado(id_estadoactoadministrativo);
            }
        });

}

function EliminarDecVie_ActosAdministrativosEstado(idestadoactoadministrativo) {
    let urlEliminar = urlController + "DecVie_ActosAdministrativosEstado/DeleteDecVie_ActosAdministrativosEstado?id_estadoactoadministrativo=" + idestadoactoadministrativo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_ActosAdministrativosEstado();
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
