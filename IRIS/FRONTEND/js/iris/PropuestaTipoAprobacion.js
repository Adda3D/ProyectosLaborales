var isUpdatePropuestaTipoAprobacion = false;
var DataTablePropuestaTipoAprobacion = null;

$(document).ready(function () {
    LoadDataTablePropuestaTipoAprobacion(); 
     
});


function LoadDataTablePropuestaTipoAprobacion() {
    DataTablePropuestaTipoAprobacion = $('#tblPropuestaTipoAprobacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_AprobacionConsejoFacultad/GetDataTablePropuestaTipoAprobacion"
        },      
        "columns": [            
            { "data": "nmaprconfac", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaPropuestaTipoAprobacion(' + row.id_aprobacionconsejofacultad + ')" data-bs-toggle="modal" data-bs-target="#ModalPropuestaTipoAprobacion" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPropuestaTipoAprobacion(' + row.id_aprobacionconsejofacultad + ',`' + row.nmaprconfac + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTablePropuestaTipoAprobacion() {
    DataTablePropuestaTipoAprobacion.ajax.reload(null, false);
}

function CrearPropuestaTipoAprobacion() {
    $("#txtnmaprconfac" ).val('');
    $("#spanIdPropuestaTipoAprobacion")[0].innerText = '';
    
    isUpdatePropuestaTipoAprobacion = false;

    removeValidationFormByForm('formPropuestaTipoAprobacion');
}

function EditarPropuestaPropuestaTipoAprobacion(idPropuestaTipoAprobacion) {   
    removeValidationFormByForm('formPropuestaTipoAprobacion'); 
    let urlEditar = urlController + "Propuesta_AprobacionConsejoFacultad/GetPropuesta_AprobacionConsejoFacultadDetails?id_aprobacionconsejofacultad=" + idPropuestaTipoAprobacion;
    isUpdatePropuestaTipoAprobacion = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtnmaprconfac" ).val(datos.nmaprconfac);
            $("#spanIdPropuestaTipoAprobacion")[0].innerText = datos.id_aprobacionconsejofacultad;
        
            isUpdatePropuestaTipoAprobacion = true;
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

function ValidarEliminarPropuestaTipoAprobacion(idPropuestaTipoAprobacion, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaPropuestaTipoAprobacion(idPropuestaTipoAprobacion);
            }
        });

}

function EliminarPropuestaPropuestaTipoAprobacion(idPropuestaTipoAprobacion) {
    let urlEliminar = urlController + "Propuesta_AprobacionConsejoFacultad/DeletePropuesta_AprobacionConsejoFacultad?id_aprobacionconsejofacultad=" + idPropuestaTipoAprobacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTablePropuestaTipoAprobacion();
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

function ValidatePostUpdatePropuestaTipoAprobacion(formF, botonClose) {
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
                if (!isUpdatePropuestaTipoAprobacion) {                                          
                    AddUpdatePropuestaTipoAprobacion(botonClose);
                }
                else {
                    AddUpdatePropuestaTipoAprobacion(botonClose);
                }            
            }
        }
    }
}

function AddUpdatePropuestaTipoAprobacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_AprobacionConsejoFacultad/UpdatePropuesta_AprobacionConsejoFacultad";

	objData.id_aprobacionconsejofacultad = ($("#spanIdPropuestaTipoAprobacion")[0].innerText == '') ? undefined : $("#spanIdPropuestaTipoAprobacion")[0].innerText;
	objData.nmaprconfac = $("#txtnmaprconfac").val();

    if (objData.id_aprobacionconsejofacultad == undefined) {
        urlUpdate = urlController + "Propuesta_AprobacionConsejoFacultad/InsertPropuesta_AprobacionConsejoFacultad";        
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

            RefreshDataTableDataTablePropuestaTipoAprobacion();
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


