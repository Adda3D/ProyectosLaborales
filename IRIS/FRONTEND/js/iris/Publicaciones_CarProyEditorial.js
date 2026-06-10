var isUpdatePublicaciones_CarProyEditorial = false;
var DataTablePublicaciones_CarProyEditorial = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_CarProyEditorial();
});

function LoadDataTablePublicaciones_CarProyEditorial() {
    DataTablePublicaciones_CarProyEditorial = $('#tblPublicaciones_CarProyEditorial').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_CarProyEditorial/GetDataTablePublicaciones_CarProyEditorial"
        },      
        "columns": [
            { "data": "nmcarproyeditorial", "orderable": true },
            { "data": "observaciones", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_CarProyEditorial(' + row.id_carproyeditorial + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_CarProyEditorial" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_CarProyEditorial(' + row.id_carproyeditorial + ',`' + row.nmcarproyeditorial + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_CarProyEditorial() {
    DataTablePublicaciones_CarProyEditorial.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_CarProyEditorial(formF, botonClose) {
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
                if (!isUpdatePublicaciones_CarProyEditorial) {                                          
                    ExistePublicaciones_CarProyEditorial()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_CarProyEditorial(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_CarProyEditorial(botonClose);
                }                            
            }
        }
    }
}

function ExistePublicaciones_CarProyEditorial() {    
    let nmcarproyeditorial = $("#txtCdPublicacionesCarProyEditorial").val();   
    let urlValidar = urlController + "Publicaciones_CarProyEditorial/GetPublicaciones_CarProyEditorialNombre?cd_nmcarproyeditorial=" + nmcarproyeditorial;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nmcarproyeditorial + " ya está registrado.";
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

function AddUpdatePublicaciones_CarProyEditorial(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_CarProyEditorial/UpdatePublicaciones_CarProyEditorial";

    objData.id_carproyeditorial = ($("#spanIdPublicaciones_CarProyEditorial")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_CarProyEditorial")[0].innerText;
    objData.nmcarproyeditorial = $("#txtCdPublicacionesCarProyEditorial").val();
    objData.observaciones = $("#txtPublicaciones_CarProyEditorial").val();

    if (objData.id_carproyeditorial == undefined) {
        urlUpdate = urlController + "Publicaciones_CarProyEditorial/InsertPublicaciones_CarProyEditorial";        
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

            RefreshDataTablePublicaciones_CarProyEditorial();
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

function CrearPublicaciones_CarProyEditorial() {
    $( "#txtCdPublicacionesCarProyEditorial" ).prop( "disabled", false );
    $("#spanIdPublicaciones_CarProyEditorial")[0].innerText = '';
    $("#txtCdPublicacionesCarProyEditorial").val('');
    $("#txtPublicaciones_CarProyEditorial").val('');
    isUpdatePublicaciones_CarProyEditorial = false;

    removeValidationFormByForm('formPublicaciones_CarProyEditorial');
}

function EditarPublicaciones_CarProyEditorial(idcarproyeditorial) {   
    removeValidationFormByForm('formPublicaciones_CarProyEditorial'); 
    let urlEditar = urlController + "Publicaciones_CarProyEditorial/GetPublicaciones_CarProyEditorialDetails?id_carproyeditorial=" + idcarproyeditorial;
    isUpdatePublicaciones_CarProyEditorial = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_CarProyEditorial")[0].innerText = datos.id_carproyeditorial;
            $("#txtCdPublicacionesCarProyEditorial").val(datos.nmcarproyeditorial);
            $("#txtPublicaciones_CarProyEditorial").val(datos.observaciones);
            $( "#txtCdPublicacionesCarProyEditorial" ).prop( "disabled", false );            
            isUpdatePublicaciones_CarProyEditorial = true;
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

function ValidarEliminarPublicaciones_CarProyEditorial(idcarproyeditorial, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_CarProyEditorial(idcarproyeditorial);
            }
        });

}

function EliminarPublicaciones_CarProyEditorial(idcarproyeditorial) {
    let urlEliminar = urlController + "Publicaciones_CarProyEditorial/DeletePublicaciones_CarProyEditorial?id_carproyeditorial=" + idcarproyeditorial;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_CarProyEditorial();
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
