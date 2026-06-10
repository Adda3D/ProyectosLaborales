var isUpdateTipoModificacion = false;
var DataTableTipoModificacion = null;

$(document).ready(function () {
    LoadDataTableTipoModificacion(); 
     
});


function LoadDataTableTipoModificacion() {
    DataTableTipoModificacion = $('#tblTipoModificacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_TipoModificacion/GetDataTablePropuestaTipoModificacion"
        },      
        "columns": [            
            { "data": "nmtipomodificacion", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaTipoModificacion(' + row.id_tipomodificacion + ')" data-bs-toggle="modal" data-bs-target="#ModalTipoModificacion" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarTipoModificacion(' + row.id_tipomodificacion + ',`' + row.nmtipomodificacion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTableTipoModificacion() {
    DataTableTipoModificacion.ajax.reload(null, false);
}

function CrearTipoModificacion() {
    $("#txtNmTipoModificacion" ).val('');
    $("#spanIdTipoModificacion")[0].innerText = '';
    
    isUpdateTipoModificacion = false;

    removeValidationFormByForm('formTipoModificacion');
}

function EditarPropuestaTipoModificacion(idTipoModificacion) {   
    removeValidationFormByForm('formTipoModificacion'); 
    let urlEditar = urlController + "Propuesta_TipoModificacion/GetPropuesta_TipoModificacionDetails?id_tipomodificacion=" + idTipoModificacion;
    isUpdateTipoModificacion = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtNmTipoModificacion" ).val(datos.nmtipomodificacion);
            $("#spanIdTipoModificacion")[0].innerText = datos.id_tipomodificacion;
        
            isUpdateTipoModificacion = true;
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

function ValidarEliminarTipoModificacion(idTipoModificacion, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaTipoModificacion(idTipoModificacion);
            }
        });

}

function EliminarPropuestaTipoModificacion(idTipoModificacion) {
    let urlEliminar = urlController + "Propuesta_TipoModificacion/DeletePropuesta_TipoModificacion?id_tipomodificacion=" + idTipoModificacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableTipoModificacion();
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

function ValidatePostUpdateTipoModificacion(formF, botonClose) {
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
                if (!isUpdateTipoModificacion) {                                          
                    AddUpdateTipoModificacion(botonClose);
                }
                else {
                    AddUpdateTipoModificacion(botonClose);
                }            
            }
        }
    }
}

function AddUpdateTipoModificacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_TipoModificacion/UpdatePropuesta_TipoModificacion";

	objData.id_tipomodificacion = ($("#spanIdTipoModificacion")[0].innerText == '') ? undefined : $("#spanIdTipoModificacion")[0].innerText;
	objData.nmtipomodificacion = $("#txtNmTipoModificacion").val();

    if (objData.id_tipomodificacion == undefined) {
        urlUpdate = urlController + "Propuesta_TipoModificacion/InsertPropuesta_TipoModificacion";        
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

            RefreshDataTableDataTableTipoModificacion();

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


