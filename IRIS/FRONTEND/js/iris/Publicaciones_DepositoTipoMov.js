var isUpdatePublicaciones_DepositoTipoMov = false;
var DataTablePublicaciones_DepositoTipoMov = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_DepositoTipoMov();
});

function LoadDataTablePublicaciones_DepositoTipoMov() {
    DataTablePublicaciones_DepositoTipoMov = $('#tblPublicaciones_DepositoTipoMov').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_DepositoTipoMov/GetDataTablePublicaciones_DepositoTipoMov"
        },      
        "columns": [
            { "data": "nmtipomov", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_DepositoTipoMov(' + row.id_tipomov + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_DepositoTipoMov" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_DepositoTipoMov(' + row.id_tipomov + ',`' + row.nmtipomov + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_DepositoTipoMov() {
    DataTablePublicaciones_DepositoTipoMov.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_DepositoTipoMov(formF, botonClose) {
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
                if (!isUpdatePublicaciones_DepositoTipoMov) {                                          
                    ExistePublicaciones_DepositoTipoMov()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_DepositoTipoMov(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_DepositoTipoMov(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_DepositoTipoMov() {    
    let nmtipomov = $("#txtCdPublicacionesDepositoTipoMov").val();   
    let urlValidar = urlController + "Publicaciones_DepositoTipoMov/GetPublicaciones_DepositoTipoMovNombre?cd_nmtipomov=" + nmtipomov;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipomov + " ya está registrado.";
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

function AddUpdatePublicaciones_DepositoTipoMov(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_DepositoTipoMov/UpdatePublicaciones_DepositoTipoMov";

    objData.id_tipomov = ($("#spanIdPublicaciones_DepositoTipoMov")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_DepositoTipoMov")[0].innerText;
    objData.nmtipomov = $("#txtCdPublicacionesDepositoTipoMov").val();
    objData.observaciones = $("#txtPublicaciones_DepositoTipoMov").val();

    if (objData.id_tipomov == undefined) {
        urlUpdate = urlController + "Publicaciones_DepositoTipoMov/InsertPublicaciones_DepositoTipoMov";        
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

            RefreshDataTablePublicaciones_DepositoTipoMov();
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

function CrearPublicaciones_DepositoTipoMov() {
    $( "#txtCdPublicacionesDepositoTipoMov" ).prop( "disabled", false );
    $("#spanIdPublicaciones_DepositoTipoMov")[0].innerText = '';
    $("#txtCdPublicacionesDepositoTipoMov").val('');
    $("#txtPublicaciones_DepositoTipoMov").val('');
    isUpdatePublicaciones_DepositoTipoMov = false;

    removeValidationFormByForm('formPublicaciones_DepositoTipoMov');
}

function EditarPublicaciones_DepositoTipoMov(idtipomov) {   
    removeValidationFormByForm('formPublicaciones_DepositoTipoMov'); 
    let urlEditar = urlController + "Publicaciones_DepositoTipoMov/GetPublicaciones_DepositoTipoMovDetails?id_tipomov=" + idtipomov;
    isUpdatePublicaciones_DepositoTipoMov = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_DepositoTipoMov")[0].innerText = datos.id_tipomov;
            $("#txtCdPublicacionesDepositoTipoMov").val(datos.nmtipomov);
            $("#txtPublicaciones_DepositoTipoMov").val(datos.observaciones);
            $( "#txtCdPublicacionesDepositoTipoMov" ).prop( "disabled", false );            
            isUpdatePublicaciones_DepositoTipoMov = true;
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

function ValidarEliminarPublicaciones_DepositoTipoMov(idtipomov, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_DepositoTipoMov(idtipomov);
            }
        });

}

function EliminarPublicaciones_DepositoTipoMov(idtipomov) {
    let urlEliminar = urlController + "Publicaciones_DepositoTipoMov/DeletePublicaciones_DepositoTipoMov?id_tipomov=" + idtipomov;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_DepositoTipoMov();
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
