var isUpdatePublicaciones_ImpresionTintasTaco = false;
var DataTablePublicaciones_ImpresionTintasTaco = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_ImpresionTintasTaco();
});

function LoadDataTablePublicaciones_ImpresionTintasTaco() {
    DataTablePublicaciones_ImpresionTintasTaco = $('#tblPublicaciones_ImpresionTintasTaco').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_ImpresionTintasTaco/GetDataTablePublicaciones_ImpresionTintasTaco"
        },      
        "columns": [
            { "data": "nmtintastaco", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_ImpresionTintasTaco(' + row.id_tintastaco + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_ImpresionTintasTaco" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_ImpresionTintasTaco(' + row.id_tintastaco + ',`' + row.nmtintastaco + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_ImpresionTintasTaco() {
    DataTablePublicaciones_ImpresionTintasTaco.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_ImpresionTintasTaco(formF, botonClose) {
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
                if (!isUpdatePublicaciones_ImpresionTintasTaco) {                                          
                    ExistePublicaciones_ImpresionTintasTaco()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_ImpresionTintasTaco(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_ImpresionTintasTaco(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_ImpresionTintasTaco() {    
    let nmtintastaco = $("#txtCdPublicacionesImpresionTintasTaco").val();   
    let urlValidar = urlController + "Publicaciones_ImpresionTintasTaco/GetPublicaciones_ImpresionTintasTacoNombre?cd_nmtintastaco=" + nmtintastaco;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtintastaco + " ya está registrado.";
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

function AddUpdatePublicaciones_ImpresionTintasTaco(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_ImpresionTintasTaco/UpdatePublicaciones_ImpresionTintasTaco";

    objData.id_tintastaco = ($("#spanIdPublicaciones_ImpresionTintasTaco")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_ImpresionTintasTaco")[0].innerText;
    objData.nmtintastaco = $("#txtCdPublicacionesImpresionTintasTaco").val();
    objData.observaciones = $("#txtPublicaciones_ImpresionTintasTaco").val();

    if (objData.id_tintastaco == undefined) {
        urlUpdate = urlController + "Publicaciones_ImpresionTintasTaco/InsertPublicaciones_ImpresionTintasTaco";        
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

            RefreshDataTablePublicaciones_ImpresionTintasTaco();
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

function CrearPublicaciones_ImpresionTintasTaco() {
    $( "#txtCdPublicacionesImpresionTintasTaco" ).prop( "disabled", false );
    $("#spanIdPublicaciones_ImpresionTintasTaco")[0].innerText = '';
    $("#txtCdPublicacionesImpresionTintasTaco").val('');
    $("#txtPublicaciones_ImpresionTintasTaco").val('');
    isUpdatePublicaciones_ImpresionTintasTaco = false;

    removeValidationFormByForm('formPublicaciones_ImpresionTintasTaco');
}

function EditarPublicaciones_ImpresionTintasTaco(idtintastaco) {   
    removeValidationFormByForm('formPublicaciones_ImpresionTintasTaco'); 
    let urlEditar = urlController + "Publicaciones_ImpresionTintasTaco/GetPublicaciones_ImpresionTintasTacoDetails?id_tintastaco=" + idtintastaco;
    isUpdatePublicaciones_ImpresionTintasTaco = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_ImpresionTintasTaco")[0].innerText = datos.id_tintastaco;
            $("#txtCdPublicacionesImpresionTintasTaco").val(datos.nmtintastaco);
            $("#txtPublicaciones_ImpresionTintasTaco").val(datos.observaciones);
            $( "#txtCdPublicacionesImpresionTintasTaco" ).prop( "disabled", false );            
            isUpdatePublicaciones_ImpresionTintasTaco = true;
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

function ValidarEliminarPublicaciones_ImpresionTintasTaco(idtintastaco, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_ImpresionTintasTaco(idtintastaco);
            }
        });

}

function EliminarPublicaciones_ImpresionTintasTaco(idtintastaco) {
    let urlEliminar = urlController + "Publicaciones_ImpresionTintasTaco/DeletePublicaciones_ImpresionTintasTaco?id_tintastaco=" + idtintastaco;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_ImpresionTintasTaco();
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
