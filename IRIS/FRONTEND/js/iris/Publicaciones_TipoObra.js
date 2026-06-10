var isUpdatePublicaciones_TipoObra = false;
var DataTablePublicaciones_TipoObra = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_TipoObra();
});

function LoadDataTablePublicaciones_TipoObra() {
    DataTablePublicaciones_TipoObra = $('#tblPublicaciones_TipoObra').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_TipoObra/GetDataTablePublicaciones_TipoObra"
        },      
        "columns": [
            { "data": "nmtipoobra", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_TipoObra(' + row.id_tipoobra + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_TipoObra" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_TipoObra(' + row.id_tipoobra + ',`' + row.nmtipoobra + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_TipoObra() {
    DataTablePublicaciones_TipoObra.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_TipoObra(formF, botonClose) {
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
                if (!isUpdatePublicaciones_TipoObra) {                                          
                    ExistePublicaciones_TipoObra()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_TipoObra(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_TipoObra(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_TipoObra() {    
    let nmtipoobra = $("#txtCdPublicacionesTipoObra").val();   
    let urlValidar = urlController + "Publicaciones_TipoObra/GetPublicaciones_TipoObraNombre?cd_nmtipoobra=" + nmtipoobra;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipoobra + " ya está registrado.";
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

function AddUpdatePublicaciones_TipoObra(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_TipoObra/UpdatePublicaciones_TipoObra";

    objData.id_tipoobra = ($("#spanIdPublicaciones_TipoObra")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_TipoObra")[0].innerText;
    objData.nmtipoobra = $("#txtCdPublicacionesTipoObra").val();
    objData.observaciones = $("#txtPublicaciones_TipoObra").val();

    if (objData.id_tipoobra == undefined) {
        urlUpdate = urlController + "Publicaciones_TipoObra/InsertPublicaciones_TipoObra";        
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

            RefreshDataTablePublicaciones_TipoObra();
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

function CrearPublicaciones_TipoObra() {
    $( "#txtCdPublicacionesTipoObra" ).prop( "disabled", false );
    $("#spanIdPublicaciones_TipoObra")[0].innerText = '';
    $("#txtCdPublicacionesTipoObra").val('');
    $("#txtPublicaciones_TipoObra").val('');
    isUpdatePublicaciones_TipoObra = false;

    removeValidationFormByForm('formPublicaciones_TipoObra');
}

function EditarPublicaciones_TipoObra(idtipoobra) {   
    removeValidationFormByForm('formPublicaciones_TipoObra'); 
    let urlEditar = urlController + "Publicaciones_TipoObra/GetPublicaciones_TipoObraDetails?id_tipoobra=" + idtipoobra;
    isUpdatePublicaciones_TipoObra = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_TipoObra")[0].innerText = datos.id_tipoobra;
            $("#txtCdPublicacionesTipoObra").val(datos.nmtipoobra);
            $("#txtPublicaciones_TipoObra").val(datos.observaciones);
            $( "#txtCdPublicacionesTipoObra" ).prop( "disabled", false );            
            isUpdatePublicaciones_TipoObra = true;
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

function ValidarEliminarPublicaciones_TipoObra(idtipoobra, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_TipoObra(idtipoobra);
            }
        });

}

function EliminarPublicaciones_TipoObra(idtipoobra) {
    let urlEliminar = urlController + "Publicaciones_TipoObra/DeletePublicaciones_TipoObra?id_tipoobra=" + idtipoobra;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_TipoObra();
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
