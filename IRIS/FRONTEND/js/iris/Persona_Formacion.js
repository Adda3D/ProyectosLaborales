var DataTablePersona_Formacion = null;

$(document).ready(function () {
    LoadDataTablePersona_Formacion(); 
     
});


function LoadDataTablePersona_Formacion() {
    DataTablePersona_Formacion = $('#tblPersona_Formacion').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Persona_Formacion/GetDataTablePersona_Formacion"
        },      
        "columns": [            
            { "data": "nmformacion", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPersona_Formacion(' + row.id_formacion + ')" data-bs-toggle="modal" data-bs-target="#ModalPersona_Formacion" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPersona_Formacion(' + row.id_formacion + ',`' + row.nmformacion + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTablePersona_Formacion() {
    DataTablePersona_Formacion.ajax.reload(null, false);
}

function CrearPersona_Formacion() {
    $("#txtCdPersonaFormacion" ).val('');
    $("#spanIdPersona_Formacion")[0].innerText = '';

    removeValidationFormByForm('formPersona_Formacion');
}

function EditarPersona_Formacion(idformacion) {   
    removeValidationFormByForm('formPersona_Formacion'); 
    let urlEditar = urlController + "Persona_Formacion/GetPersona_FormacionDetails?id_formacion=" + idformacion;
    isUpdatePersona_Formacion = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtCdPersonaFormacion" ).val(datos.nmformacion);
            $("#spanIdPersona_Formacion")[0].innerText = datos.id_formacion;
                
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

function ValidarEliminarPersona_Formacion(idformacion, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaPersona_Formacion(idformacion);
            }
        });

}

function EliminarPropuestaPersona_Formacion(idformacion) {
    let urlEliminar = urlController + "Persona_Formacion/DeletePersona_Formacion?id_formacion=" + idformacion;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTablePersona_Formacion();
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

function ValidatePostUpdatePersona_Formacion(formF, botonClose) {
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
                AddUpdatePersona_Formacion(botonClose);
            }
        }
    }
}

function AddUpdatePersona_Formacion(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Persona_Formacion/UpdatePersona_Formacion";

	objData.id_formacion = ($("#spanIdPersona_Formacion")[0].innerText == '') ? undefined : $("#spanIdPersona_Formacion")[0].innerText;
	objData.nmformacion = $("#txtCdPersonaFormacion").val();

    if (objData.id_formacion == undefined) {
        urlUpdate = urlController + "Persona_Formacion/InsertPersona_Formacion";        
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        url: urlUpdate,
        headers: { 'Authorization': 'Bearer ' + TokenIRIS },
        data: objData,
        success: function (data) {
            if (!data.Ok) {                
                FinalizeLoader();
                ShowModalDialog(data.Message, false, 'warning', '', 0);                
            } else {
                FinalizeLoader();
                for (var i = 0; i < 2; i++) {
                    $('#' + botonCerrar).click();
                }

                RefreshDataTableDataTablePersona_Formacion();
            }
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        ShowModalDialog(jqXHR.responseJSON.MessageDetail, false, 'error', '', 0);
    });
}


