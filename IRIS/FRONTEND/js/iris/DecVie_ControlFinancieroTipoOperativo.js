var isUpdateDecVie_ControlFinancieroTipoOperativo = false;
var DataTableDecVie_ControlFinancieroTipoOperativo = null;

$(document).ready(function () {
    LoadDataTableDecVie_ControlFinancieroTipoOperativo();
});

function LoadDataTableDecVie_ControlFinancieroTipoOperativo() {
    DataTableDecVie_ControlFinancieroTipoOperativo = $('#tblDecVie_ControlFinancieroTipoOperativo').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "DecVie_ControlFinancieroTipoOperativo/GetDataTableDecVie_ControlFinancieroTipoOperativo"
        },      
        "columns": [
            { "data": "nmtipooperativo", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarDecVie_ControlFinancieroTipoOperativo(' + row.id_tipooperativo + ')" data-bs-toggle="modal" data-bs-target="#ModalDecVie_ControlFinancieroTipoOperativo" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarDecVie_ControlFinancieroTipoOperativo(' + row.id_tipooperativo + ',`' + row.nmtipooperativo + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableDecVie_ControlFinancieroTipoOperativo() {
    DataTableDecVie_ControlFinancieroTipoOperativo.ajax.reload(null, false);    
}

function ValidatePostUpdateDecVie_ControlFinancieroTipoOperativo(formF, botonClose) {
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
                if (!isUpdateDecVie_ControlFinancieroTipoOperativo) {                                          
                    ExisteDecVie_ControlFinancieroTipoOperativo()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateDecVie_ControlFinancieroTipoOperativo(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateDecVie_ControlFinancieroTipoOperativo(botonClose);
                }               
            }
        }
    }
}

function ExisteDecVie_ControlFinancieroTipoOperativo() {    
    let nmtipooperativo = $("#txtCdDecVieControlFinancieroTipoOperativo").val();   
    let urlValidar = urlController + "DecVie_ControlFinancieroTipoOperativo/GetDecVie_ControlFinancieroTipoOperativoNombre?cd_nmtipooperativo=" + nmtipooperativo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipooperativo + " ya está registrado.";
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

function AddUpdateDecVie_ControlFinancieroTipoOperativo(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "DecVie_ControlFinancieroTipoOperativo/UpdateDecVie_ControlFinancieroTipoOperativo";

    objData.id_tipooperativo = ($("#spanIdDecVie_ControlFinancieroTipoOperativo")[0].innerText == '') ? undefined : $("#spanIdDecVie_ControlFinancieroTipoOperativo")[0].innerText;
    objData.nmtipooperativo = $("#txtCdDecVieControlFinancieroTipoOperativo").val();
    objData.observaciones = $("#txtDecVie_ControlFinancieroTipoOperativo").val();

    if (objData.id_tipooperativo == undefined) {
        urlUpdate = urlController + "DecVie_ControlFinancieroTipoOperativo/InsertDecVie_ControlFinancieroTipoOperativo";        
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

            RefreshDataTableDecVie_ControlFinancieroTipoOperativo();
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

function CrearDecVie_ControlFinancieroTipoOperativo() {
    $( "#txtCdDecVieControlFinancieroTipoOperativo" ).prop( "disabled", false );
    $("#spanIdDecVie_ControlFinancieroTipoOperativo")[0].innerText = '';
    $("#txtCdDecVieControlFinancieroTipoOperativo").val('');
    $("#txtDecVie_ControlFinancieroTipoOperativo").val('');
    isUpdateDecVie_ControlFinancieroTipoOperativo = false;

    removeValidationFormByForm('formDecVie_ControlFinancieroTipoOperativo');
}

function EditarDecVie_ControlFinancieroTipoOperativo(idtipooperativo) {   
    removeValidationFormByForm('formDecVie_ControlFinancieroTipoOperativo'); 
    let urlEditar = urlController + "DecVie_ControlFinancieroTipoOperativo/GetDecVie_ControlFinancieroTipoOperativoDetails?id_tipooperativo=" + idtipooperativo;
    isUpdateDecVie_ControlFinancieroTipoOperativo = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdDecVie_ControlFinancieroTipoOperativo")[0].innerText = datos.id_tipooperativo;
            $("#txtCdDecVieControlFinancieroTipoOperativo").val(datos.nmtipooperativo);
            $("#txtDecVie_ControlFinancieroTipoOperativo").val(datos.observaciones);
            $( "#txtCdDecVieControlFinancieroTipoOperativo" ).prop( "disabled", false );            
            isUpdateDecVie_ControlFinancieroTipoOperativo = true;
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

function ValidarEliminarDecVie_ControlFinancieroTipoOperativo(idtipooperativo, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarDecVie_ControlFinancieroTipoOperativo(idtipooperativo);
            }
        });

}

function EliminarDecVie_ControlFinancieroTipoOperativo(idtipooperativo) {
    let urlEliminar = urlController + "DecVie_ControlFinancieroTipoOperativo/DeleteDecVie_ControlFinancieroTipoOperativo?id_tipooperativo=" + idtipooperativo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDecVie_ControlFinancieroTipoOperativo();
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
