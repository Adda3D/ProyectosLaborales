var isUpdatePublicaciones_CostosServicioEditorial = false;
var DataTablePublicaciones_CostosServicioEditorial = null;

$(document).ready(function () {
    LoadDataTablePublicaciones_CostosServicioEditorial();
});

function LoadDataTablePublicaciones_CostosServicioEditorial() {
    DataTablePublicaciones_CostosServicioEditorial = $('#tblPublicaciones_CostosServicioEditorial').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Publicaciones_CostosServicioEditorial/GetDataTablePublicaciones_CostosServicioEditorial"
        },      
        "columns": [
            { "data": "nomservicioeditorial", "orderable": true },            
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarPublicaciones_CostosServicioEditorial(' + row.id_servicioeditorial + ')" data-bs-toggle="modal" data-bs-target="#ModalPublicaciones_CostosServicioEditorial" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarPublicaciones_CostosServicioEditorial(' + row.id_servicioeditorial + ',`' + row.nomservicioeditorial + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTablePublicaciones_CostosServicioEditorial() {
    DataTablePublicaciones_CostosServicioEditorial.ajax.reload(null, false);    
}

function ValidatePostUpdatePublicaciones_CostosServicioEditorial(formF, botonClose) {
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
                if ($("#spanIdPublicaciones_CostosServicioEditorial")[0].innerText == '') {
                    ExistePublicaciones_CostosServicioEditorial()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdatePublicaciones_CostosServicioEditorial(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdatePublicaciones_CostosServicioEditorial(botonClose);
                }
            }
        }
    }
}

function ExistePublicaciones_CostosServicioEditorial() {    
    let nomservicioeditorial = $("#txtCdPublicacionesCostosServicioEditorial").val();   
    let urlValidar = urlController + "Publicaciones_CostosServicioEditorial/GetPublicaciones_CostosServicioEditorialNombre?cd_nomservicioeditorial=" + nomservicioeditorial;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + nomservicioeditorial + " ya está registrado.";
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

function AddUpdatePublicaciones_CostosServicioEditorial(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_CostosServicioEditorial/UpdatePublicaciones_CostosServicioEditorial";

    objData.id_servicioeditorial = ($("#spanIdPublicaciones_CostosServicioEditorial")[0].innerText == '') ? undefined : $("#spanIdPublicaciones_CostosServicioEditorial")[0].innerText;
    objData.nomservicioeditorial = $("#txtCdPublicacionesCostosServicioEditorial").val();    

    if (objData.id_servicioeditorial == undefined) {
        urlUpdate = urlController + "Publicaciones_CostosServicioEditorial/InsertPublicaciones_CostosServicioEditorial";        
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

            RefreshDataTablePublicaciones_CostosServicioEditorial();
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

function CrearPublicaciones_CostosServicioEditorial() {
    $( "#txtCdPublicacionesCostosServicioEditorial" ).prop( "disabled", false );
    $("#spanIdPublicaciones_CostosServicioEditorial")[0].innerText = '';   
    $("#txtPublicaciones_CostosServicioEditorial").val('');
    isUpdatePublicaciones_CostosServicioEditorial = false;

    removeValidationFormByForm('formPublicaciones_CostosServicioEditorial');
}

function EditarPublicaciones_CostosServicioEditorial(idservicioeditorial) {   
    removeValidationFormByForm('formPublicaciones_CostosServicioEditorial'); 
    let urlEditar = urlController + "Publicaciones_CostosServicioEditorial/GetPublicaciones_CostosServicioEditorialDetails?id_servicioeditorial=" + idservicioeditorial;
    isUpdatePublicaciones_CostosServicioEditorial = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdPublicaciones_CostosServicioEditorial")[0].innerText = datos.id_servicioeditorial;
            $("#txtCdPublicacionesCostosServicioEditorial").val(datos.nomservicioeditorial);           
            $( "#txtCdPublicacionesCostosServicioEditorial" ).prop( "disabled", false );            
            isUpdatePublicaciones_CostosServicioEditorial = true;
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

function ValidarEliminarPublicaciones_CostosServicioEditorial(idservicioeditorial, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarPublicaciones_CostosServicioEditorial(idservicioeditorial);
            }
        });

}

function EliminarPublicaciones_CostosServicioEditorial(idservicioeditorial) {
    let urlEliminar = urlController + "Publicaciones_CostosServicioEditorial/DeletePublicaciones_CostosServicioEditorial?id_servicioeditorial=" + idservicioeditorial;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicaciones_CostosServicioEditorial();
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
