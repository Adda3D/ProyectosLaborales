var isUpdatePublicaciones_EstadoEvaluador = false;
var DataTablePublicaciones_EstadoEvaluador = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_EstadoEvaluador();
});

function LoadDataTablePublicaciones_EstadoEvaluador() {
    DataTablePublicaciones_EstadoEvaluador = $('#tblPublicaciones_EstadoEvaluador').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_EstadoEvaluador/GetDataTablePublicaciones_EstadoEvaluador"
        },      
        "columns": [
            { "data": "nmestadoevaluador", "orderable": true },
   //         { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_EstadoEvaluador(' + row.id_estadoevaluador + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_EstadoEvaluador" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_EstadoEvaluador(' + row.id_estadoevaluador + ',`' + row.nmestadoevaluador + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_EstadoEvaluador() {
    DataTablePublicaciones_EstadoEvaluador.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_EstadoEvaluador(formF, botonClose) {
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
                if (!isUpdatePublicaciones_EstadoEvaluador) {                                          
                    ExistePublicaciones_EstadoEvaluador()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_EstadoEvaluador(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_EstadoEvaluador(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_EstadoEvaluador() {    
    let nmestadoevaluador = $("#txtCdPublicacionesEstadoEvaluador").val();   
    let urlValidar = urlController + "Publicaciones_EstadoEvaluador/GetPublicaciones_EstadoEvaluadorNombre?cd_nmestadoevaluador=" + nmestadoevaluador;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmestadoevaluador + " ya está registrado.";
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

function AddUpdatePublicaciones_EstadoEvaluador(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EstadoEvaluador/UpdatePublicaciones_EstadoEvaluador";

    objData.id_estadoevaluador = ($("#spanIdPublicaciones_EstadoEvaluador")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_EstadoEvaluador")[0].innerText;
    objData.nmestadoevaluador = $("#txtCdPublicacionesEstadoEvaluador").val();
   // objData.observaciones = $("#txtPublicaciones_EstadoEvaluador").val();

    if (objData.id_estadoevaluador == undefined) {
        urlUpdate = urlController + "Publicaciones_EstadoEvaluador/InsertPublicaciones_EstadoEvaluador";        
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

            RefreshDataTablePublicaciones_EstadoEvaluador();
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

function CrearPublicaciones_EstadoEvaluador() {
    $( "#txtCdPublicacionesEstadoEvaluador" ).prop( "disabled", false );
    $("#spanIdPublicaciones_EstadoEvaluador")[0].innerText = '';
    $("#txtCdPublicacionesEstadoEvaluador").val('');
    $("#txtPublicaciones_EstadoEvaluador").val('');
    isUpdatePublicaciones_EstadoEvaluador = false;

    removeValidationFormByForm('formPublicaciones_EstadoEvaluador');
}

function EditarPublicaciones_EstadoEvaluador(idestadoevaluador) {   
    removeValidationFormByForm('formPublicaciones_EstadoEvaluador'); 
    let urlEditar = urlController + "Publicaciones_EstadoEvaluador/GetPublicaciones_EstadoEvaluadorDetails?id_estadoevaluador=" + idestadoevaluador;
    isUpdatePublicaciones_EstadoEvaluador = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_EstadoEvaluador")[0].innerText = datos.id_estadoevaluador;
            $("#txtCdPublicacionesEstadoEvaluador").val(datos.nmestadoevaluador);
   //         $("#txtPublicaciones_EstadoEvaluador").val(datos.observaciones);
            $( "#txtCdPublicacionesEstadoEvaluador" ).prop( "disabled", false );            
            isUpdatePublicaciones_EstadoEvaluador = true;
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

function ValidarEliminarPublicaciones_EstadoEvaluador(idestadoevaluador, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_EstadoEvaluador(idestadoevaluador);
            }
        });

}

function EliminarPublicaciones_EstadoEvaluador(idestadoevaluador) {
    let urlEliminar = urlController + "Publicaciones_EstadoEvaluador/DeletePublicaciones_EstadoEvaluador?id_estadoevaluador=" + idestadoevaluador;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_EstadoEvaluador();
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
