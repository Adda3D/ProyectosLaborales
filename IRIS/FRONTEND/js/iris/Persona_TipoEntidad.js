var isUpdatePersona_TipoEntidad = false;
var DataTablePersona_TipoEntidad = null;

$(document).ready(function () {
    LoadDataTablePersona_TipoEntidad();
});

function LoadDataTablePersona_TipoEntidad() {
    DataTablePersona_TipoEntidad = $('#tblPersona_TipoEntidad').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Persona_TipoEntidad/GetDataTablePersona_TipoEntidad"
        },      
        "columns": [
            { "data": "nmtipoent", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPersona_TipoEntidad(' + row.id_tipoentidad + ')" data-bs-toggle="modal" data-bs-target="#ModalPersona_TipoEntidad" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPersona_TipoEntidad(' + row.id_tipoentidad + ',`' + row.nmtipoent + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePersona_TipoEntidad() {
    DataTablePersona_TipoEntidad.ajax.reload(null, false);    
}

function ValidatePostUpdatePersona_TipoEntidad(formF, botonClose) {
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
                if ($("#spanIdPersona_TipoEntidad")[0].innerText == '') {
                    ExistePersona_TipoEntidad()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePersona_TipoEntidad(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePersona_TipoEntidad(botonClose);
                }
            }
        }
    }
}

function ExistePersona_TipoEntidad() {    
    let nmtipoent = $("#txtCdPersonaTipoEntidad").val();   
    let urlValidar = urlController + "Persona_TipoEntidad/GetPersona_TipoEntidadNombre?cd_nmtipoent=" + nmtipoent;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtipoent + " ya está registrado.";
                ShowModalDialog(message, false, 'warning', '', 0);
                return true;
            }
            else {
                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      });
}

function AddUpdatePersona_TipoEntidad(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Persona_TipoEntidad/UpdatePersona_TipoEntidad";

    objData.id_tipoentidad = ($("#spanIdPersona_TipoEntidad")[0].innerText == '') ? undefined : $("#spanIdPersona_TipoEntidad")[0].innerText;
    objData.nmtipoent = $("#txtCdPersonaTipoEntidad").val();    

    if (objData.id_tipoentidad == undefined) {
        urlUpdate = urlController + "Persona_TipoEntidad/InsertPersona_TipoEntidad";        
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

            RefreshDataTablePersona_TipoEntidad();
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

function CrearPersona_TipoEntidad() {
    $( "#txtCdPersonaTipoEntidad" ).prop( "disabled", false );
    $("#spanIdPersona_TipoEntidad")[0].innerText = '';
    $("#txtCdPersonaTipoEntidad").val('');
    $("#txtPersona_TipoEntidad").val('');
    isUpdatePersona_TipoEntidad = false;

    removeValidationFormByForm('formPersona_TipoEntidad');
}

function EditarPersona_TipoEntidad(idtipoentidad) {   
    removeValidationFormByForm('formPersona_TipoEntidad'); 
    let urlEditar = urlController + "Persona_TipoEntidad/GetPersona_TipoEntidadDetails?id_tipoentidad=" + idtipoentidad;
    isUpdatePersona_TipoEntidad = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPersona_TipoEntidad")[0].innerText = datos.id_tipoentidad;
            $("#txtCdPersonaTipoEntidad").val(datos.nmtipoent);
            $("#txtPersona_TipoEntidad").val(datos.detalles);
            $( "#txtCdPersonaTipoEntidad" ).prop( "disabled", false );            
            isUpdatePersona_TipoEntidad = true;
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

function ValidarEliminarPersona_TipoEntidad(idtipoentidad, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPersona_TipoEntidad(idtipoentidad);
            }
        });

}

function EliminarPersona_TipoEntidad(idtipoentidad) {
    let urlEliminar = urlController + "Persona_TipoEntidad/DeletePersona_TipoEntidad?id_tipoentidad=" + idtipoentidad;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePersona_TipoEntidad();
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
