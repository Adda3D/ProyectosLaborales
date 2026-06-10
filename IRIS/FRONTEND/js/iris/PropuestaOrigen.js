var isUpdatePropuestaOrigen = false;
var DataTablePropuestaOrigen = null;

$(document).ready(function () {
    LoadDataTablePropuestaOrigen(); 
     
});


function LoadDataTablePropuestaOrigen() {
    DataTablePropuestaOrigen = $('#tblPropuestaOrigen').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_OrigenPropuesta/GetDataTablePropuestaOrigen"
        },      
        "columns": [            
            { "data": "nmorigenpropuesta", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaOrigen(' + row.id_origenpropuesta + ')" data-bs-toggle="modal" data-bs-target="#ModalPropuestaOrigen" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPropuestaOrigen(' + row.id_origenpropuesta + ',`' + row.nmorigenpropuesta + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTablePropuestaOrigen() {
    DataTablePropuestaOrigen.ajax.reload(null, false);
}

function CrearPropuestaOrigen() {
    $("#txtnmorigenpropuesta" ).val('');
    $("#spanIdPropuestaOrigen")[0].innerText = '';
    
    isUpdatePropuestaOrigen = false;

    removeValidationFormByForm('formPropuestaOrigen');
}

function EditarPropuestaOrigen(idPropuestaOrigen) {   
    removeValidationFormByForm('formPropuestaOrigen'); 
    let urlEditar = urlController + "Propuesta_OrigenPropuesta/GetPropuesta_OrigenPropuestaDetails?id_origenpropuesta=" + idPropuestaOrigen;
    isUpdatePropuestaOrigen = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtnmorigenpropuesta" ).val(datos.nmorigenpropuesta);
            $("#spanIdPropuestaOrigen")[0].innerText = datos.id_origenpropuesta;
        
            isUpdatePropuestaOrigen = true;
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

function ValidarEliminarPropuestaOrigen(idPropuestaOrigen, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaPropuestaOrigen(idPropuestaOrigen);
            }
        });

}

function EliminarPropuestaPropuestaOrigen(idPropuestaOrigen) {
    let urlEliminar = urlController + "Propuesta_OrigenPropuesta/DeletePropuesta_OrigenPropuesta?id_origenpropuesta=" + idPropuestaOrigen;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTablePropuestaOrigen();
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

function ValidatePostUpdatePropuestaOrigen(formF, botonClose) {
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
                if (!isUpdatePropuestaOrigen) {                                          
                    AddUpdatePropuestaOrigen(botonClose);
                }
                else {
                    AddUpdatePropuestaOrigen(botonClose);
                }            
            }
        }
    }
}

function AddUpdatePropuestaOrigen(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_OrigenPropuesta/UpdatePropuesta_OrigenPropuesta";

	objData.id_origenpropuesta = ($("#spanIdPropuestaOrigen")[0].innerText == '') ? undefined : $("#spanIdPropuestaOrigen")[0].innerText;
	objData.nmorigenpropuesta = $("#txtnmorigenpropuesta").val();

    if (objData.id_origenpropuesta == undefined) {
        urlUpdate = urlController + "Propuesta_OrigenPropuesta/InsertPropuesta_OrigenPropuesta";        
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

            RefreshDataTableDataTablePropuestaOrigen();
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


