var isUpdatePublicaciones_EstadoConcepto = false;
var DataTablePublicaciones_EstadoConcepto = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EstadoConcepto();
});

function LoadDataTablePublicaciones_EstadoConcepto() {
    DataTablePublicaciones_EstadoConcepto = $('#tblPublicaciones_EstadoConcepto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EstadoConcepto/GetDataTablePublicaciones_EstadoConcepto"
        },      
        "columns": [
            { "data": "nmestadoconcepto", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EstadoConcepto(' + row.id_estadoconcepto + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EstadoConcepto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EstadoConcepto(' + row.id_estadoconcepto + ',`' + row.nmestadoconcepto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EstadoConcepto() {
    DataTablePublicaciones_EstadoConcepto.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EstadoConcepto(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EstadoConcepto) {                                          
                    ExistePublicaciones_EstadoConcepto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EstadoConcepto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EstadoConcepto(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EstadoConcepto() {    
    let nmestadoconcepto = $("#txtCdPublicacionesEstadoConcepto").val();   
    let urlValidar = urlController + "Publicaciones_EstadoConcepto/GetPublicaciones_EstadoConceptoNombre?cd_nmestadoconcepto=" + nmestadoconcepto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadoconcepto + " ya está registrado.";
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

function AddUpdatePublicaciones_EstadoConcepto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EstadoConcepto/UpdatePublicaciones_EstadoConcepto";

    objData.id_estadoconcepto = ($("#spanIdPublicaciones_EstadoConcepto")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EstadoConcepto")[0].innerText;
    objData.nmestadoconcepto = $("#txtCdPublicacionesEstadoConcepto").val();
   // objData.observaciones = $("#txtPublicaciones_EstadoConcepto").val();

    if (objData.id_estadoconcepto == undefined) {
        urlUpdate = urlController + "Publicaciones_EstadoConcepto/InsertPublicaciones_EstadoConcepto";        
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

            RefreshDataTablePublicaciones_EstadoConcepto();
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

function CrearPublicaciones_EstadoConcepto() {
    $( "#txtCdPublicacionesEstadoConcepto" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EstadoConcepto")[0].innerText = '';
    $("#txtCdPublicacionesEstadoConcepto").val('');
    $("#txtPublicaciones_EstadoConcepto").val('');
    isUpdatePublicaciones_EstadoConcepto = false;

    removeValidationFormByForm('formPublicaciones_EstadoConcepto');
}

function EditarPublicaciones_EstadoConcepto(idestadoconcepto) {   
    removeValidationFormByForm('formPublicaciones_EstadoConcepto'); 
    let urlEditar = urlController + "Publicaciones_EstadoConcepto/GetPublicaciones_EstadoConceptoDetails?id_estadoconcepto=" + idestadoconcepto;
    isUpdatePublicaciones_EstadoConcepto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EstadoConcepto")[0].innerText = datos.id_estadoconcepto;
            $("#txtCdPublicacionesEstadoConcepto").val(datos.nmestadoconcepto);
   //         $("#txtPublicaciones_EstadoConcepto").val(datos.observaciones);
            $( "#txtCdPublicacionesEstadoConcepto" ).prop( "disabled", false );            
            isUpdatePublicaciones_EstadoConcepto = true;
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

function ValidarEliminarPublicaciones_EstadoConcepto(idestadoconcepto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EstadoConcepto(idestadoconcepto);
            }
        });

}

function EliminarPublicaciones_EstadoConcepto(idestadoconcepto) {
    let urlEliminar = urlController + "Publicaciones_EstadoConcepto/DeletePublicaciones_EstadoConcepto?id_estadoconcepto=" + idestadoconcepto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EstadoConcepto();
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
