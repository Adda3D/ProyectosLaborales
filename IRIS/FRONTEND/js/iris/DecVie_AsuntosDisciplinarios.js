var isUpdateDecVie_AsuntosDisciplinarios = false;
var DataTableDecVie_AsuntosDisciplinarios = null;

$(document).ready(function () {
    LoadDataTableDecVie_AsuntosDisciplinarios();
});

function LoadDataTableDecVie_AsuntosDisciplinarios() {
    DataTableDecVie_AsuntosDisciplinarios = $('#tblDecVie_AsuntosDisciplinarios').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_AsuntosDisciplinarios/GetDataTableDecVie_AsuntosDisciplinarios"
        },      
        "columns": [
            { "data": "nmasuntosdisciplinarios", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_AsuntosDisciplinarios(' + row.id_asuntosdisciplinarios + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_AsuntosDisciplinarios" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_AsuntosDisciplinarios(' + row.id_asuntosdisciplinarios + ',`' + row.nmasuntosdisciplinarios + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_AsuntosDisciplinarios() {
    DataTableDecVie_AsuntosDisciplinarios.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_AsuntosDisciplinarios(formF, botonClose) {
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
                if (!isUpdateDecVie_AsuntosDisciplinarios) {                                          
                    ExisteDecVie_AsuntosDisciplinarios()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_AsuntosDisciplinarios(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_AsuntosDisciplinarios(botonClose);
                }             
            }
        }
    }
}

function ExisteDecVie_AsuntosDisciplinarios() {    
    let nmasuntosdisciplinarios = $("#txtCdDecVieAsuntosDisciplinarios").val();   
    let urlValidar = urlController + "DecVie_AsuntosDisciplinarios/GetDecVie_AsuntosDisciplinariosNombre?cd_nmasuntosdisciplinarios=" + nmasuntosdisciplinarios;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmasuntosdisciplinarios + " ya está registrado.";
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

function AddUpdateDecVie_AsuntosDisciplinarios(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_AsuntosDisciplinarios/UpdateDecVie_AsuntosDisciplinarios";

    objData.id_asuntosdisciplinarios = ($("#spanIdDecVie_AsuntosDisciplinarios")[0].innerText == '') ? undefined : $("#spanIdDecVie_AsuntosDisciplinarios")[0].innerText;
    objData.nmasuntosdisciplinarios = $("#txtCdDecVieAsuntosDisciplinarios").val();
    objData.observaciones = $("#txtDecVie_AsuntosDisciplinarios").val();

    if (objData.id_asuntosdisciplinarios == undefined) {
        urlUpdate = urlController + "DecVie_AsuntosDisciplinarios/InsertDecVie_AsuntosDisciplinarios";        
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

            RefreshDataTableDecVie_AsuntosDisciplinarios();
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

function CrearDecVie_AsuntosDisciplinarios() {
    $( "#txtCdDecVieAsuntosDisciplinarios" ).prop( "disabled", false );
    $("#spanIdDecVie_AsuntosDisciplinarios")[0].innerText = '';
    $("#txtCdDecVieAsuntosDisciplinarios").val('');
    $("#txtDecVie_AsuntosDisciplinarios").val('');
    isUpdateDecVie_AsuntosDisciplinarios = false;

    removeValidationFormByForm('formDecVie_AsuntosDisciplinarios');
}

function EditarDecVie_AsuntosDisciplinarios(idasuntosdisciplinarios) {   
    removeValidationFormByForm('formDecVie_AsuntosDisciplinarios'); 
    let urlEditar = urlController + "DecVie_AsuntosDisciplinarios/GetDecVie_AsuntosDisciplinariosDetails?id_asuntosdisciplinarios=" + idasuntosdisciplinarios;
    isUpdateDecVie_AsuntosDisciplinarios = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_AsuntosDisciplinarios")[0].innerText = datos.id_asuntosdisciplinarios;
            $("#txtCdDecVieAsuntosDisciplinarios").val(datos.nmasuntosdisciplinarios);
            $("#txtDecVie_AsuntosDisciplinarios").val(datos.observaciones);
            $( "#txtCdDecVieAsuntosDisciplinarios" ).prop( "disabled", false );            
            isUpdateDecVie_AsuntosDisciplinarios = true;
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

function ValidarEliminarDecVie_AsuntosDisciplinarios(idasuntosdisciplinarios, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_AsuntosDisciplinarios(idasuntosdisciplinarios);
            }
        });

}

function EliminarDecVie_AsuntosDisciplinarios(idasuntosdisciplinarios) {
    let urlEliminar = urlController + "DecVie_AsuntosDisciplinarios/DeleteDecVie_AsuntosDisciplinarios?id_asuntosdisciplinarios=" + idasuntosdisciplinarios;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_AsuntosDisciplinarios();
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
