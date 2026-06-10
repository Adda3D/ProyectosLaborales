var DataTablePersona_TituloAlto = null;

$(document).ready(function () {
    LoadDataTablePersona_TituloAlto(); 
     
});


function LoadDataTablePersona_TituloAlto() {
    DataTablePersona_TituloAlto = $('#tblPersona_TituloAlto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Persona_TituloAlto/GetDataTablePersona_TituloAlto"
        },      
        "columns": [            
            { "data": "nmtituloalto", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPersona_TituloAlto(' + row.id_tituloalto + ')" data-bs-toggle="modal" data-bs-target="#ModalPersona_TituloAlto" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPersona_TituloAlto(' + row.id_tituloalto + ',`' + row.nmtituloalto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTablePersona_TituloAlto() {
    DataTablePersona_TituloAlto.ajax.reload(null, false);
}

function CrearPersona_TituloAlto() {
    $("#txtCdPersonaTituloAlto" ).val('');
    $("#spanIdPersona_TituloAlto")[0].innerText = '';

    removeValidationFormByForm('formPersona_TituloAlto');
}

function EditarPersona_TituloAlto(idtituloalto) {   
    removeValidationFormByForm('formPersona_TituloAlto'); 
    let urlEditar = urlController + "Persona_TituloAlto/GetPersona_TituloAltoDetails?id_tituloalto=" + idtituloalto;
    isUpdatePersona_TituloAlto = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtCdPersonaTituloAlto" ).val(datos.nmtituloalto);
            $("#spanIdPersona_TituloAlto")[0].innerText = datos.id_tituloalto;
                
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

function ValidarEliminarPersona_TituloAlto(idtituloalto, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaPersona_TituloAlto(idtituloalto);
            }
        });

}

function EliminarPropuestaPersona_TituloAlto(idtituloalto) {
    let urlEliminar = urlController + "Persona_TituloAlto/DeletePersona_TituloAlto?id_tituloalto=" + idtituloalto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTablePersona_TituloAlto();
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

function ValidatePostUpdatePersona_TituloAlto(formF, botonClose) {
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
                AddUpdatePersona_TituloAlto(botonClose);
            }
        }
    }
}

function AddUpdatePersona_TituloAlto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Persona_TituloAlto/UpdatePersona_TituloAlto";

	objData.id_tituloalto = ($("#spanIdPersona_TituloAlto")[0].innerText == '') ? undefined : $("#spanIdPersona_TituloAlto")[0].innerText;
	objData.nmtituloalto = $("#txtCdPersonaTituloAlto").val();

    if (objData.id_tituloalto == undefined) {
        urlUpdate = urlController + "Persona_TituloAlto/InsertPersona_TituloAlto";        
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

                RefreshDataTableDataTablePersona_TituloAlto();
            }
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        ShowModalDialog(jqXHR.responseJSON.MessageDetail, false, 'error', '', 0);
    });
}


