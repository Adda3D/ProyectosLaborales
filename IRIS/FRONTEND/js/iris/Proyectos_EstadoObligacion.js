var isUpdateProyectos_EstadoObligacion = false;
var DataTableProyectos_EstadoObligacion = null;

$(document).ready(function () {
    LoadDataTableProyectos_EstadoObligacion();
});

function LoadDataTableProyectos_EstadoObligacion() {
    DataTableProyectos_EstadoObligacion = $('#tblProyectos_EstadoObligacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_EstadoObligacion/GetDataTableProyectos_EstadoObligacion"
        },      
        "columns": [
            { "data": "estadoobligacion", "orderable": true },
            { "data": "detalles", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_EstadoObligacion(' + row.id_estadoobligacion + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_EstadoObligacion" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_EstadoObligacion(' + row.id_estadoobligacion + ',`' + row.estadoobligacion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_EstadoObligacion() {
    DataTableProyectos_EstadoObligacion.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_EstadoObligacion(formF, botonClose) {
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
                if ($("#spanIdProyectos_EstadoObligacion")[0].innerText == '') {
                    ExisteProyectos_EstadoObligacion()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_EstadoObligacion(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_EstadoObligacion(botonClose);
                }
            }
        }
    }
}

function ExisteProyectos_EstadoObligacion() {    
    let estadoobligacion = $("#txtCdProyectosEstadoObligacion").val();   
    let urlValidar = urlController + "Proyectos_EstadoObligacion/GetProyectos_EstadoObligacionEstado?cd_estadoobligacion=" + estadoobligacion;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + estadoobligacion + " ya está registrado.";
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

function AddUpdateProyectos_EstadoObligacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_EstadoObligacion/UpdateProyectos_EstadoObligacion";

    objData.id_estadoobligacion = ($("#spanIdProyectos_EstadoObligacion")[0].innerText == '') ? undefined : $("#spanIdProyectos_EstadoObligacion")[0].innerText;
    objData.estadoobligacion = $("#txtCdProyectosEstadoObligacion").val();
    objData.detalles = $("#txtProyectos_EstadoObligacion").val();

    if (objData.id_estadoobligacion == undefined) {
        urlUpdate = urlController + "Proyectos_EstadoObligacion/InsertProyectos_EstadoObligacion";        
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

            RefreshDataTableProyectos_EstadoObligacion();
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

function CrearProyectos_EstadoObligacion() {
    $( "#txtCdProyectosEstadoObligacion" ).prop( "disabled", false );
    $("#spanIdProyectos_EstadoObligacion")[0].innerText = '';
    $("#txtCdProyectosEstadoObligacion").val('');
    $("#txtProyectos_EstadoObligacion").val('');
    isUpdateProyectos_EstadoObligacion = false;

    removeValidationFormByForm('formProyectos_EstadoObligacion');
}

function EditarProyectos_EstadoObligacion(idestadoobligacion) {   
    removeValidationFormByForm('formProyectos_EstadoObligacion'); 
    let urlEditar = urlController + "Proyectos_EstadoObligacion/GetProyectos_EstadoObligacionDetails?id_estadoobligacion=" + idestadoobligacion;
    isUpdateProyectos_EstadoObligacion = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_EstadoObligacion")[0].innerText = datos.id_estadoobligacion;
            $("#txtCdProyectosEstadoObligacion").val(datos.estadoobligacion);
            $("#txtProyectos_EstadoObligacion").val(datos.detalles);
            $( "#txtCdProyectosEstadoObligacion" ).prop( "disabled", false );            
            isUpdateProyectos_EstadoObligacion = true;
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

function ValidarEliminarProyectos_EstadoObligacion(idestadoobligacion, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_EstadoObligacion(idestadoobligacion);
            }
        });

}

function EliminarProyectos_EstadoObligacion(idestadoobligacion) {
    let urlEliminar = urlController + "Proyectos_EstadoObligacion/DeleteProyectos_EstadoObligacion?id_estadoobligacion=" + idestadoobligacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_EstadoObligacion();
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
