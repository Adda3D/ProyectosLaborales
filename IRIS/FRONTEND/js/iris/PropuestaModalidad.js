var isUpdatePropuestaModalidad = false;
var DataTablePropuestaModalidad = null;

$(document).ready(function () {
    LoadDataTablePropuestaModalidad(); 
     
});


function LoadDataTablePropuestaModalidad() {
    DataTablePropuestaModalidad = $('#tblPropuestaModalidad').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_Modalidad/GetDataTablePropuestaModalidad"
        },      
        "columns": [            
            { "data": "nmmodalidad", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaPropuestaModalidad(' + row.id_modalidad + ')" data-bs-toggle="modal" data-bs-target="#ModalPropuestaModalidad" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPropuestaModalidad(' + row.id_modalidad + ',`' + row.nmmodalidad + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTablePropuestaModalidad() {
    DataTablePropuestaModalidad.ajax.reload(null, false);
}

function CrearPropuestaModalidad() {
    $("#txtnmmodalidad" ).val('');
    $("#spanIdPropuestaModalidad")[0].innerText = '';
    
    isUpdatePropuestaModalidad = false;

    removeValidationFormByForm('formPropuestaModalidad');
}

function EditarPropuestaPropuestaModalidad(idPropuestaModalidad) {   
    removeValidationFormByForm('formPropuestaModalidad'); 
    let urlEditar = urlController + "Propuesta_Modalidad/GetPropuesta_ModalidadDetails?id_modalidad=" + idPropuestaModalidad;
    isUpdatePropuestaModalidad = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtnmmodalidad" ).val(datos.nmmodalidad);
            $("#spanIdPropuestaModalidad")[0].innerText = datos.id_modalidad;
        
            isUpdatePropuestaModalidad = true;
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

function ValidarEliminarPropuestaModalidad(idPropuestaModalidad, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaPropuestaModalidad(idPropuestaModalidad);
            }
        });

}

function EliminarPropuestaPropuestaModalidad(idPropuestaModalidad) {
    let urlEliminar = urlController + "Propuesta_Modalidad/DeletePropuesta_Modalidad?id_modalidad=" + idPropuestaModalidad;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTablePropuestaModalidad();
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

function ValidatePostUpdatePropuestaModalidad(formF, botonClose) {
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
                if (!isUpdatePropuestaModalidad) {                                          
                    AddUpdatePropuestaModalidad(botonClose);
                }
                else {
                    AddUpdatePropuestaModalidad(botonClose);
                }            
            }
        }
    }
}

function AddUpdatePropuestaModalidad(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_Modalidad/UpdatePropuesta_Modalidad";

	objData.id_modalidad = ($("#spanIdPropuestaModalidad")[0].innerText == '') ? undefined : $("#spanIdPropuestaModalidad")[0].innerText;
	objData.nmmodalidad = $("#txtnmmodalidad").val();

    if (objData.id_modalidad == undefined) {
        urlUpdate = urlController + "Propuesta_Modalidad/InsertPropuesta_Modalidad";        
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

            RefreshDataTableDataTablePropuestaModalidad();
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


