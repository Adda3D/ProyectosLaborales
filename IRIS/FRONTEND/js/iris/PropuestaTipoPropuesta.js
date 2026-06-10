var isUpdateTipoPropuesta = false;
var DataTableTipoPropuesta = null;

$(document).ready(function () {
    LoadDataTableTipoPropuesta(); 
     
});


function LoadDataTableTipoPropuesta() {
    DataTableTipoPropuesta = $('#tblTipoPropuesta').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_TipoPropuesta/GetDataTableTipoPropuesta"
        },      
        "columns": [            
            { "data": "nmtipopropuesta", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaTipoPropuesta(' + row.id_tipopropuesta + ')" data-bs-toggle="modal" data-bs-target="#ModalTipoPropuesta" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarTipoPropuesta(' + row.id_tipopropuesta + ',`' + row.nmtipopropuesta + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTableTipoPropuesta() {
    DataTableTipoPropuesta.ajax.reload(null, false);
}

function CrearTipoPropuesta() {
    $("#txtnmtipopropuesta" ).val('');
    $("#spanIdTipoPropuesta")[0].innerText = '';
    
    isUpdateTipoPropuesta = false;

    removeValidationFormByForm('formTipoPropuesta');
}

function EditarPropuestaTipoPropuesta(idTipoPropuesta) {   
    removeValidationFormByForm('formTipoPropuesta'); 
    let urlEditar = urlController + "Propuesta_TipoPropuesta/GetPropuesta_TipoPropuestaDetails?id_tipopropuesta=" + idTipoPropuesta;
    isUpdateTipoPropuesta = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtnmtipopropuesta" ).val(datos.nmtipopropuesta);
            $("#spanIdTipoPropuesta")[0].innerText = datos.id_tipopropuesta;
        
            isUpdateTipoPropuesta = true;
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

function ValidarEliminarTipoPropuesta(idTipoPropuesta, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaTipoPropuesta(idTipoPropuesta);
            }
        });

}

function EliminarPropuestaTipoPropuesta(idTipoPropuesta) {
    let urlEliminar = urlController + "Propuesta_TipoPropuesta/DeletePropuesta_TipoPropuesta?id_tipopropuesta=" + idTipoPropuesta;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableTipoPropuesta();
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

function ValidatePostUpdateTipoPropuesta(formF, botonClose) {
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
                if (!isUpdateTipoPropuesta) {                                          
                    AddUpdateTipoPropuesta(botonClose);
                }
                else {
                    AddUpdateTipoPropuesta(botonClose);
                }            
            }
        }
    }
}

function AddUpdateTipoPropuesta(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_TipoPropuesta/UpdatePropuesta_TipoPropuesta";

	objData.id_tipopropuesta = ($("#spanIdTipoPropuesta")[0].innerText == '') ? undefined : $("#spanIdTipoPropuesta")[0].innerText;
	objData.nmtipopropuesta = $("#txtnmtipopropuesta").val();

    if (objData.id_tipopropuesta == undefined) {
        urlUpdate = urlController + "Propuesta_TipoPropuesta/InsertPropuesta_TipoPropuesta";        
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

            RefreshDataTableDataTableTipoPropuesta();
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


