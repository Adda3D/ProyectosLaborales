var isUpdatePersona_TipoServicio = false;
var DataTablePersona_TipoServicio = null;

$(document).ready(function () {
    LoadDataTablePersona_TipoServicio();
});

function LoadDataTablePersona_TipoServicio() {
    DataTablePersona_TipoServicio = $('#tblPersona_TipoServicio').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Persona_TipoServicio/GetDataTablePersona_TipoServicio"
        },      
        "columns": [
            { "data": "nmtiposerv", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPersona_TipoServicio(' + row.id_tiposervicio + ')" data-bs-toggle="modal" data-bs-target="#ModalPersona_TipoServicio" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPersona_TipoServicio(' + row.id_tiposervicio + ',`' + row.nmtiposerv + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePersona_TipoServicio() {
    DataTablePersona_TipoServicio.ajax.reload(null, false);    
}

function ValidatePostUpdatePersona_TipoServicio(formF, botonClose) {
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
                if ($("#spanIdPersona_TipoServicio")[0].innerText == '') {
                    ExistePersona_TipoServicio()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePersona_TipoServicio(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePersona_TipoServicio(botonClose);
                }
            }
        }
    }
}

function ExistePersona_TipoServicio() {    
    let nmtiposerv = $("#txtCdPersonaTipoServicio").val();   
    let urlValidar = urlController + "Persona_TipoServicio/GetPersona_TipoServicioNombre?cd_nmtiposerv=" + nmtiposerv;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmtiposerv + " ya está registrado.";
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

function AddUpdatePersona_TipoServicio(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Persona_TipoServicio/UpdatePersona_TipoServicio";

    objData.id_tiposervicio = ($("#spanIdPersona_TipoServicio")[0].innerText == '') ? undefined : $("#spanIdPersona_TipoServicio")[0].innerText;
    objData.nmtiposerv = $("#txtCdPersonaTipoServicio").val();    

    if (objData.id_tiposervicio == undefined) {
        urlUpdate = urlController + "Persona_TipoServicio/InsertPersona_TipoServicio";        
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

            RefreshDataTablePersona_TipoServicio();
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

function CrearPersona_TipoServicio() {
    $( "#txtCdPersonaTipoServicio" ).prop( "disabled", false );
    $("#spanIdPersona_TipoServicio")[0].innerText = '';
    $("#txtCdPersonaTipoServicio").val('');
    $("#txtPersona_TipoServicio").val('');
    isUpdatePersona_TipoServicio = false;

    removeValidationFormByForm('formPersona_TipoServicio');
}

function EditarPersona_TipoServicio(idtiposervicio) {   
    removeValidationFormByForm('formPersona_TipoServicio'); 
    let urlEditar = urlController + "Persona_TipoServicio/GetPersona_TipoServicioDetails?id_tiposervicio=" + idtiposervicio;
    isUpdatePersona_TipoServicio = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPersona_TipoServicio")[0].innerText = datos.id_tiposervicio;
            $("#txtCdPersonaTipoServicio").val(datos.nmtiposerv);
            $("#txtPersona_TipoServicio").val(datos.detalles);
            $( "#txtCdPersonaTipoServicio" ).prop( "disabled", false );            
            isUpdatePersona_TipoServicio = true;
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

function ValidarEliminarPersona_TipoServicio(idtiposervicio, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPersona_TipoServicio(idtiposervicio);
            }
        });

}

function EliminarPersona_TipoServicio(idtiposervicio) {
    let urlEliminar = urlController + "Persona_TipoServicio/DeletePersona_TipoServicio?id_tiposervicio=" + idtiposervicio;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePersona_TipoServicio();
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
