var isUpdateTipoContratante = false;
var DataTableTipoContratante = null;

$(document).ready(function () {
    LoadDataTableTipoContratante(); 
     
});


function LoadDataTableTipoContratante() {
    DataTableTipoContratante = $('#tblTipoContratante').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Propuesta_TipoUsuario/GetDatataTablePropuestaTipoUsuario"
        },      
        "columns": [            
            { "data": "nmpropuestatipousuario", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPropuestaTipoContratante(' + row.id_propuestatipousuario + ')" data-bs-toggle="modal" data-bs-target="#ModalTipoContratante" />' + 
                    '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarTipoContratante(' + row.id_propuestatipousuario + ',`' + row.nmpropuestatipousuario + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[15, 30, 50, 100], [15, 30, 50, 100]],
    });

}

function RefreshDataTableDataTableTipoContratante() {
    DataTableTipoContratante.ajax.reload(null, false);
}

function CrearTipoContratante() {
    $("#txtNmTipoContratante" ).val('');
    $("#spanIdTipoContratante")[0].innerText = '';
    
    isUpdateTipoContratante = false;

    removeValidationFormByForm('formTipoContratante');
}

function EditarPropuestaTipoContratante(idTipoContratante) {   
    removeValidationFormByForm('formTipoContratante'); 
    let urlEditar = urlController + "Propuesta_TipoUsuario/GetPropuesta_TipoUsuarioDetails?id_propuestatipousuario=" + idTipoContratante;
    isUpdateTipoContratante = false;
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;

            $("#txtNmTipoContratante" ).val(datos.nmpropuestatipousuario);
            $("#spanIdTipoContratante")[0].innerText = datos.id_propuestatipousuario;
        
            isUpdateTipoContratante = true;
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

function ValidarEliminarTipoContratante(idTipoContratante, nombretipo) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombretipo + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPropuestaTipoContratante(idTipoContratante);
            }
        });

}

function EliminarPropuestaTipoContratante(idTipoContratante) {
    let urlEliminar = urlController + "Propuesta_TipoUsuario/DeletePropuesta_TipoUsuario?id_propuestatipousuario=" + idTipoContratante;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableDataTableTipoContratante();
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

function ValidatePostUpdateTipoContratante(formF, botonClose) {
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
                if (!isUpdateTipoContratante) {                                          
                    AddUpdateTipoContratante(botonClose);
                }
                else {
                    AddUpdateTipoContratante(botonClose);
                }            
            }
        }
    }
}

function AddUpdateTipoContratante(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Propuesta_TipoUsuario/UpdatePropuesta_TipoUsuario";

	objData.id_propuestatipousuario = ($("#spanIdTipoContratante")[0].innerText == '') ? undefined : $("#spanIdTipoContratante")[0].innerText;
	objData.nmpropuestatipousuario = $("#txtNmTipoContratante").val();

    if (objData.id_propuestatipousuario == undefined) {
        urlUpdate = urlController + "Propuesta_TipoUsuario/InsertPropuesta_TipoUsuario";        
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

            RefreshDataTableDataTableTipoContratante();
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


