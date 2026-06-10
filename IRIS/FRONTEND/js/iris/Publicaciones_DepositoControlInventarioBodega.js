var isUpdatePublicaciones_DepositoControlInventarioBodega = false;
var DataTablePublicaciones_DepositoControlInventarioBodega = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_DepositoControlInventarioBodega();
});

function LoadDataTablePublicaciones_DepositoControlInventarioBodega() {
    DataTablePublicaciones_DepositoControlInventarioBodega = $('#tblPublicaciones_DepositoControlInventarioBodega').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DepositoControlInventarioBodega/GetDataTablePublicaciones_DepositoControlInventarioBodega"
        },      
        "columns": [
            { "data": "nmbodega", "orderable": true },
            { "data": "descripcion", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_DepositoControlInventarioBodega(' + row.id_bodega + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DepositoControlInventarioBodega" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_DepositoControlInventarioBodega(' + row.id_bodega + ',`' + row.nmbodega + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_DepositoControlInventarioBodega() {
    DataTablePublicaciones_DepositoControlInventarioBodega.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_DepositoControlInventarioBodega(formF, botonClose) {
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
                if (!isUpdatePublicaciones_DepositoControlInventarioBodega) {                                          
                    ExistePublicaciones_DepositoControlInventarioBodega()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_DepositoControlInventarioBodega(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_DepositoControlInventarioBodega(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_DepositoControlInventarioBodega() {    
    let nmbodega = $("#txtCdPublicacionesDepositoControlInventarioBodega").val();   
    let urlValidar = urlController + "Publicaciones_DepositoControlInventarioBodega/GetPublicaciones_DepositoControlInventarioBodegaNombre?cd_nmbodega=" + nmbodega;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmbodega + " ya está registrado.";
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

function AddUpdatePublicaciones_DepositoControlInventarioBodega(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_DepositoControlInventarioBodega/UpdatePublicaciones_DepositoControlInventarioBodega";

    objData.id_bodega = ($("#spanIdPublicaciones_DepositoControlInventarioBodega")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_DepositoControlInventarioBodega")[0].innerText;
    objData.nmbodega = $("#txtCdPublicacionesDepositoControlInventarioBodega").val();
    objData.descripcion = $("#txtPublicaciones_DepositoControlInventarioBodega").val();

    if (objData.id_bodega == undefined) {
        urlUpdate = urlController + "Publicaciones_DepositoControlInventarioBodega/InsertPublicaciones_DepositoControlInventarioBodega";        
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

            RefreshDataTablePublicaciones_DepositoControlInventarioBodega();
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

function CrearPublicaciones_DepositoControlInventarioBodega() {
    $( "#txtCdPublicacionesDepositoControlInventarioBodega" ).prop( "disabled", false );
    $("#spanIdPublicaciones_DepositoControlInventarioBodega")[0].innerText = '';
    $("#txtCdPublicacionesDepositoControlInventarioBodega").val('');
    $("#txtPublicaciones_DepositoControlInventarioBodega").val('');
    isUpdatePublicaciones_DepositoControlInventarioBodega = false;

    removeValidationFormByForm('formPublicaciones_DepositoControlInventarioBodega');
}

function EditarPublicaciones_DepositoControlInventarioBodega(idbodega) {   
    removeValidationFormByForm('formPublicaciones_DepositoControlInventarioBodega'); 
    let urlEditar = urlController + "Publicaciones_DepositoControlInventarioBodega/GetPublicaciones_DepositoControlInventarioBodegaDetails?id_bodega=" + idbodega;
    isUpdatePublicaciones_DepositoControlInventarioBodega = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_DepositoControlInventarioBodega")[0].innerText = datos.id_bodega;
            $("#txtCdPublicacionesDepositoControlInventarioBodega").val(datos.nmbodega);
            $("#txtPublicaciones_DepositoControlInventarioBodega").val(datos.descripcion);
            $( "#txtCdPublicacionesDepositoControlInventarioBodega" ).prop( "disabled", false );            
            isUpdatePublicaciones_DepositoControlInventarioBodega = true;
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

function ValidarEliminarPublicaciones_DepositoControlInventarioBodega(idbodega, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoControlInventarioBodega(idbodega);
            }
        });

}

function EliminarPublicaciones_DepositoControlInventarioBodega(idbodega) {
    let urlEliminar = urlController + "Publicaciones_DepositoControlInventarioBodega/DeletePublicaciones_DepositoControlInventarioBodega?id_bodega=" + idbodega;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_DepositoControlInventarioBodega();
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
