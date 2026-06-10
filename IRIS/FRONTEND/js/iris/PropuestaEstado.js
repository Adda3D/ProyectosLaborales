var isUpdatePropuestaEstado = false;
var DataTablePropuestaEstado = null;

$(document).ready(function () {
    LoadDataTablePropuestaEstado(); 
     
});


function LoadDataTablePropuestaEstado() {
    DataTablePropuestaEstado = $('#tblPropuestaEstado').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_EstadoPropuesta/GetDataTablePropuestaEstado"
        },      
        "columns": [            
            { "data": "nmestadopropuesta", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaPropuestaEstado(' + row.id_estadopropuesta + ')" data-bs-toggle="modal" data-bs-target="#ModalPropuestaEstado" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPropuestaEstado(' + row.id_estadopropuesta + ',`' + row.nmestadopropuesta + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTablePropuestaEstado() {
    DataTablePropuestaEstado.ajax.reload(null, false);
}

function CrearPropuestaEstado() {
    $("#txtnmestadopropuesta" ).val('');
    $("#spanIdPropuestaEstado")[0].innerText = '';
    
    isUpdatePropuestaEstado = false;

    removeValidationFormByForm('formPropuestaEstado');
}

function EditarPropuestaPropuestaEstado(idPropuestaEstado) {   
    removeValidationFormByForm('formPropuestaEstado'); 
    let urlEditar = urlController + "Propuesta_EstadoPropuesta/GetPropuesta_EstadoPropuestaDetails?id_estadopropuesta=" + idPropuestaEstado;
    isUpdatePropuestaEstado = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtnmestadopropuesta" ).val(datos.nmestadopropuesta);
            $("#spanIdPropuestaEstado")[0].innerText = datos.id_estadopropuesta;
        
            isUpdatePropuestaEstado = true;
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

function ValidarEliminarPropuestaEstado(idPropuestaEstado, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaPropuestaEstado(idPropuestaEstado);
            }
        });

}

function EliminarPropuestaPropuestaEstado(idPropuestaEstado) {
    let urlEliminar = urlController + "Propuesta_EstadoPropuesta/DeletePropuesta_EstadoPropuesta?id_estadopropuesta=" + idPropuestaEstado;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTablePropuestaEstado();
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

function ValidatePostUpdatePropuestaEstado(formF, botonClose) {
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
                if (!isUpdatePropuestaEstado) {                                          
                    AddUpdatePropuestaEstado(botonClose);
                }
                else {
                    AddUpdatePropuestaEstado(botonClose);
                }            
            }
        }
    }
}

function AddUpdatePropuestaEstado(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_EstadoPropuesta/UpdatePropuesta_EstadoPropuesta";

	objData.id_estadopropuesta = ($("#spanIdPropuestaEstado")[0].innerText == '') ? undefined : $("#spanIdPropuestaEstado")[0].innerText;
	objData.nmestadopropuesta = $("#txtnmestadopropuesta").val();

    if (objData.id_estadopropuesta == undefined) {
        urlUpdate = urlController + "Propuesta_EstadoPropuesta/InsertPropuesta_EstadoPropuesta";        
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

            RefreshDataTableDataTablePropuestaEstado();
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


