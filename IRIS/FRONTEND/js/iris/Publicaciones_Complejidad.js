var isUpdatePublicaciones_Complejidad = false;
var DataTablePublicaciones_Complejidad = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_Complejidad();
});

function LoadDataTablePublicaciones_Complejidad() {
    DataTablePublicaciones_Complejidad = $('#tblPublicaciones_Complejidad').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_Complejidad/GetDataTablePublicaciones_Complejidad"
        },      
        "columns": [
            { "data": "nmcomplejidad", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_Complejidad(' + row.id_complejidad + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_Complejidad" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_Complejidad(' + row.id_complejidad + ',`' + row.nmcomplejidad + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_Complejidad() {
    DataTablePublicaciones_Complejidad.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_Complejidad(formF, botonClose) {
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
                if (!isUpdatePublicaciones_Complejidad) {                                          
                    ExistePublicaciones_Complejidad()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_Complejidad(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_Complejidad(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_Complejidad() {    
    let nmcomplejidad = $("#txtCdPublicacionesComplejidad").val();   
    let urlValidar = urlController + "Publicaciones_Complejidad/GetPublicaciones_ComplejidadNombre?cd_nmcomplejidad=" + nmcomplejidad;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmcomplejidad + " ya está registrado.";
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

function AddUpdatePublicaciones_Complejidad(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Complejidad/UpdatePublicaciones_Complejidad";

    objData.id_complejidad = ($("#spanIdPublicaciones_Complejidad")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_Complejidad")[0].innerText;
    objData.nmcomplejidad = $("#txtCdPublicacionesComplejidad").val();
    objData.observaciones = $("#txtPublicaciones_Complejidad").val();

    if (objData.id_complejidad == undefined) {
        urlUpdate = urlController + "Publicaciones_Complejidad/InsertPublicaciones_Complejidad";        
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

            RefreshDataTablePublicaciones_Complejidad();
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

function CrearPublicaciones_Complejidad() {
    $( "#txtCdPublicacionesComplejidad" ).prop( "disabled", false );
    $("#spanIdPublicaciones_Complejidad")[0].innerText = '';
    $("#txtCdPublicacionesComplejidad").val('');
    $("#txtPublicaciones_Complejidad").val('');
    isUpdatePublicaciones_Complejidad = false;

    removeValidationFormByForm('formPublicaciones_Complejidad');
}

function EditarPublicaciones_Complejidad(idcomplejidad) {   
    removeValidationFormByForm('formPublicaciones_Complejidad'); 
    let urlEditar = urlController + "Publicaciones_Complejidad/GetPublicaciones_ComplejidadDetails?id_complejidad=" + idcomplejidad;
    isUpdatePublicaciones_Complejidad = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_Complejidad")[0].innerText = datos.id_complejidad;
            $("#txtCdPublicacionesComplejidad").val(datos.nmcomplejidad);
            $("#txtPublicaciones_Complejidad").val(datos.observaciones);
            $( "#txtCdPublicacionesComplejidad" ).prop( "disabled", false );            
            isUpdatePublicaciones_Complejidad = true;
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

function ValidarEliminarPublicaciones_Complejidad(idcomplejidad, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_Complejidad(idcomplejidad);
            }
        });

}

function EliminarPublicaciones_Complejidad(idcomplejidad) {
    let urlEliminar = urlController + "Publicaciones_Complejidad/DeletePublicaciones_Complejidad?id_complejidad=" + idcomplejidad;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_Complejidad();
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
