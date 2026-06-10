var isUpdatePublicaciones_TipoDiagramacion = false;
var DataTablePublicaciones_TipoDiagramacion = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_TipoDiagramacion();
});

function LoadDataTablePublicaciones_TipoDiagramacion() {
    DataTablePublicaciones_TipoDiagramacion = $('#tblPublicaciones_TipoDiagramacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_TipoDiagramacion/GetDataTablePublicaciones_TipoDiagramacion"
        },      
        "columns": [
            { "data": "nmtipodiagramacion", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_TipoDiagramacion(' + row.id_tipodiagramacion + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_TipoDiagramacion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_TipoDiagramacion(' + row.id_tipodiagramacion + ',`' + row.nmtipodiagramacion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_TipoDiagramacion() {
    DataTablePublicaciones_TipoDiagramacion.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_TipoDiagramacion(formF, botonClose) {
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
                if (!isUpdatePublicaciones_TipoDiagramacion) {                                          
                    ExistePublicaciones_TipoDiagramacion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_TipoDiagramacion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_TipoDiagramacion(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_TipoDiagramacion() {    
    let nmtipodiagramacion = $("#txtCdPublicacionesTipoDiagramacion").val();   
    let urlValidar = urlController + "Publicaciones_TipoDiagramacion/GetPublicaciones_TipoDiagramacionNombre?cd_nmtipodiagramacion=" + nmtipodiagramacion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipodiagramacion + " ya está registrado.";
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

function AddUpdatePublicaciones_TipoDiagramacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_TipoDiagramacion/UpdatePublicaciones_TipoDiagramacion";

    objData.id_tipodiagramacion = ($("#spanIdPublicaciones_TipoDiagramacion")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_TipoDiagramacion")[0].innerText;
    objData.nmtipodiagramacion = $("#txtCdPublicacionesTipoDiagramacion").val();
   // objData.observaciones = $("#txtPublicaciones_TipoDiagramacion").val();

    if (objData.id_tipodiagramacion == undefined) {
        urlUpdate = urlController + "Publicaciones_TipoDiagramacion/InsertPublicaciones_TipoDiagramacion";        
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

            RefreshDataTablePublicaciones_TipoDiagramacion();
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

function CrearPublicaciones_TipoDiagramacion() {
    $( "#txtCdPublicacionesTipoDiagramacion" ).prop( "disabled", false );
    $("#spanIdPublicaciones_TipoDiagramacion")[0].innerText = '';
    $("#txtCdPublicacionesTipoDiagramacion").val('');
    $("#txtPublicaciones_TipoDiagramacion").val('');
    isUpdatePublicaciones_TipoDiagramacion = false;

    removeValidationFormByForm('formPublicaciones_TipoDiagramacion');
}

function EditarPublicaciones_TipoDiagramacion(idtipodiagramacion) {   
    removeValidationFormByForm('formPublicaciones_TipoDiagramacion'); 
    let urlEditar = urlController + "Publicaciones_TipoDiagramacion/GetPublicaciones_TipoDiagramacionDetails?id_tipodiagramacion=" + idtipodiagramacion;
    isUpdatePublicaciones_TipoDiagramacion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_TipoDiagramacion")[0].innerText = datos.id_tipodiagramacion;
            $("#txtCdPublicacionesTipoDiagramacion").val(datos.nmtipodiagramacion);
   //         $("#txtPublicaciones_TipoDiagramacion").val(datos.observaciones);
            $( "#txtCdPublicacionesTipoDiagramacion" ).prop( "disabled", false );            
            isUpdatePublicaciones_TipoDiagramacion = true;
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

function ValidarEliminarPublicaciones_TipoDiagramacion(idtipodiagramacion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_TipoDiagramacion(idtipodiagramacion);
            }
        });

}

function EliminarPublicaciones_TipoDiagramacion(idtipodiagramacion) {
    let urlEliminar = urlController + "Publicaciones_TipoDiagramacion/DeletePublicaciones_TipoDiagramacion?id_tipodiagramacion=" + idtipodiagramacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_TipoDiagramacion();
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
