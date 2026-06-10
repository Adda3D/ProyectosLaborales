var isUpdatePublicaciones_DepositoTipoPub = false;
var DataTablePublicaciones_DepositoTipoPub = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_DepositoTipoPub();
});

function LoadDataTablePublicaciones_DepositoTipoPub() {
    DataTablePublicaciones_DepositoTipoPub = $('#tblPublicaciones_DepositoTipoPub').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DepositoTipoPub/GetDataTablePublicaciones_DepositoTipoPub"
        },      
        "columns": [
            { "data": "nmtipopub", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_DepositoTipoPub(' + row.id_tipopub + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DepositoTipoPub" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_DepositoTipoPub(' + row.id_tipopub + ',`' + row.nmtipopub + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_DepositoTipoPub() {
    DataTablePublicaciones_DepositoTipoPub.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_DepositoTipoPub(formF, botonClose) {
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
                if (!isUpdatePublicaciones_DepositoTipoPub) {                                          
                    ExistePublicaciones_DepositoTipoPub()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_DepositoTipoPub(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_DepositoTipoPub(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_DepositoTipoPub() {    
    let nmtipopub = $("#txtCdPublicacionesDepositoTipoPub").val();   
    let urlValidar = urlController + "Publicaciones_DepositoTipoPub/GetPublicaciones_DepositoTipoPubNombre?cd_nmtipopub=" + nmtipopub;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipopub + " ya está registrado.";
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

function AddUpdatePublicaciones_DepositoTipoPub(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_DepositoTipoPub/UpdatePublicaciones_DepositoTipoPub";

    objData.id_tipopub = ($("#spanIdPublicaciones_DepositoTipoPub")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_DepositoTipoPub")[0].innerText;
    objData.nmtipopub = $("#txtCdPublicacionesDepositoTipoPub").val();
    objData.observaciones = $("#txtPublicaciones_DepositoTipoPub").val();

    if (objData.id_tipopub == undefined) {
        urlUpdate = urlController + "Publicaciones_DepositoTipoPub/InsertPublicaciones_DepositoTipoPub";        
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

            RefreshDataTablePublicaciones_DepositoTipoPub();
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

function CrearPublicaciones_DepositoTipoPub() {
    $( "#txtCdPublicacionesDepositoTipoPub" ).prop( "disabled", false );
    $("#spanIdPublicaciones_DepositoTipoPub")[0].innerText = '';
    $("#txtCdPublicacionesDepositoTipoPub").val('');
    $("#txtPublicaciones_DepositoTipoPub").val('');
    isUpdatePublicaciones_DepositoTipoPub = false;

    removeValidationFormByForm('formPublicaciones_DepositoTipoPub');
}

function EditarPublicaciones_DepositoTipoPub(idtipopub) {   
    removeValidationFormByForm('formPublicaciones_DepositoTipoPub'); 
    let urlEditar = urlController + "Publicaciones_DepositoTipoPub/GetPublicaciones_DepositoTipoPubDetails?id_tipopub=" + idtipopub;
    isUpdatePublicaciones_DepositoTipoPub = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_DepositoTipoPub")[0].innerText = datos.id_tipopub;
            $("#txtCdPublicacionesDepositoTipoPub").val(datos.nmtipopub);
            $("#txtPublicaciones_DepositoTipoPub").val(datos.observaciones);
            $( "#txtCdPublicacionesDepositoTipoPub" ).prop( "disabled", false );            
            isUpdatePublicaciones_DepositoTipoPub = true;
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

function ValidarEliminarPublicaciones_DepositoTipoPub(idtipopub, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoTipoPub(idtipopub);
            }
        });

}

function EliminarPublicaciones_DepositoTipoPub(idtipopub) {
    let urlEliminar = urlController + "Publicaciones_DepositoTipoPub/DeletePublicaciones_DepositoTipoPub?id_tipopub=" + idtipopub;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_DepositoTipoPub();
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
