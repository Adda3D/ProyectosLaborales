var DataTableTipo_Persona = null;

$(document).ready(function () {
    LoadDataTableTipo_Persona(); 
     
});


function LoadDataTableTipo_Persona() {
    DataTableTipo_Persona = $('#tblTipo_Persona').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Tipo_Persona/GetDataTableTipo_Persona"
        },      
        "columns": [            
            { "data": "nmtipoper", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarTipo_Persona(' + row.id_tipopersona + ')" data-bs-toggle="modal" data-bs-target="#ModalTipo_Persona" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarTipo_Persona(' + row.id_tipopersona + ',`' + row.nmtipoper + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTableTipo_Persona() {
    DataTableTipo_Persona.ajax.reload(null, false);
}

function CrearTipo_Persona() {
    $("#txtCdTipoPersona" ).val('');
    $("#spanIdTipo_Persona")[0].innerText = '';

    removeValidationFormByForm('formTipo_Persona');
}

function EditarTipo_Persona(idtipopersona) {   
    removeValidationFormByForm('formTipo_Persona'); 
    let urlEditar = urlController + "Tipo_Persona/GetTipo_PersonaDetails?id_tipopersona=" + idtipopersona;
    isUpdateTipo_Persona = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtCdTipoPersona" ).val(datos.nmtipoper);
            $("#spanIdTipo_Persona")[0].innerText = datos.id_tipopersona;
                
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

function ValidarEliminarTipo_Persona(idtipopersona, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaTipo_Persona(idtipopersona);
            }
        });

}

function EliminarPropuestaTipo_Persona(idtipopersona) {
    let urlEliminar = urlController + "Tipo_Persona/DeleteTipo_Persona?id_tipopersona=" + idtipopersona;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableTipo_Persona();
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

function ValidatePostUpdateTipo_Persona(formF, botonClose) {
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
                AddUpdateTipo_Persona(botonClose);
            }
        }
    }
}

function AddUpdateTipo_Persona(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Tipo_Persona/UpdateTipo_Persona";

	objData.id_tipopersona = ($("#spanIdTipo_Persona")[0].innerText == '') ? undefined : $("#spanIdTipo_Persona")[0].innerText;
	objData.nmtipoper = $("#txtCdTipoPersona").val();

    if (objData.id_tipopersona == undefined) {
        urlUpdate = urlController + "Tipo_Persona/InsertTipo_Persona";        
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

                RefreshDataTableDataTableTipo_Persona();
            }
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        ShowModalDialog(jqXHR.responseJSON.MessageDetail, false, 'error', '', 0);
    });
}


