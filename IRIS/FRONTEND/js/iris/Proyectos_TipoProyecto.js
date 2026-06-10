var isUpdateProyectos_TipoProyecto = false;
var DataTableProyectos_TipoProyecto = null;

$(document).ready(function () {
    LoadDataTableProyectos_TipoProyecto();
});

function LoadDataTableProyectos_TipoProyecto() {
    DataTableProyectos_TipoProyecto = $('#tblProyectos_TipoProyecto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_TipoProyecto/GetDataTableProyectos_TipoProyecto"
        },      
        "columns": [
            { "data": "tipoproyecto", "orderable": true },
            { "data": "detalles", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_TipoProyecto(' + row.id_tipoproyecto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_TipoProyecto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_TipoProyecto(' + row.id_tipoproyecto + ',`' + row.tipoproyecto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_TipoProyecto() {
    DataTableProyectos_TipoProyecto.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_TipoProyecto(formF, botonClose) {
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
                if ($("#spanIdProyectos_TipoProyecto")[0].innerText == '') {
                    ExisteProyectos_TipoProyecto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_TipoProyecto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_TipoProyecto(botonClose);
                }                                                                                                                                                                                                                                                            
            }
        }
    }
}

function ExisteProyectos_TipoProyecto() {    
    let tipoproyecto = $("#txtCdProyectosTipoProyecto").val();   
    let urlValidar = urlController + "Proyectos_TipoProyecto/GetProyectos_TipoProyectoTipo?cd_tipoproyecto=" + tipoproyecto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + tipoproyecto + " ya está registrado.";
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

function AddUpdateProyectos_TipoProyecto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_TipoProyecto/UpdateProyectos_TipoProyecto";

    objData.id_tipoproyecto = ($("#spanIdProyectos_TipoProyecto")[0].innerText == '') ? undefined : $("#spanIdProyectos_TipoProyecto")[0].innerText;
    objData.tipoproyecto = $("#txtCdProyectosTipoProyecto").val();
    objData.detalles = $("#txtProyectos_TipoProyecto").val();

    if (objData.id_tipoproyecto == undefined) {
        urlUpdate = urlController + "Proyectos_TipoProyecto/InsertProyectos_TipoProyecto";        
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

            RefreshDataTableProyectos_TipoProyecto();
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

function CrearProyectos_TipoProyecto() {
    $( "#txtCdProyectosTipoProyecto" ).prop( "disabled", false );
    $("#spanIdProyectos_TipoProyecto")[0].innerText = '';
    $("#txtCdProyectosTipoProyecto").val('');
    $("#txtProyectos_TipoProyecto").val('');
    isUpdateProyectos_TipoProyecto = false;

    removeValidationFormByForm('formProyectos_TipoProyecto');
}

function EditarProyectos_TipoProyecto(idtipoproyecto) {   
    removeValidationFormByForm('formProyectos_TipoProyecto'); 
    let urlEditar = urlController + "Proyectos_TipoProyecto/GetProyectos_TipoProyectoDetails?id_tipoproyecto=" + idtipoproyecto;
    isUpdateProyectos_TipoProyecto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_TipoProyecto")[0].innerText = datos.id_tipoproyecto;
            $("#txtCdProyectosTipoProyecto").val(datos.tipoproyecto);
            $("#txtProyectos_TipoProyecto").val(datos.detalles);
            $( "#txtCdProyectosTipoProyecto" ).prop( "disabled", false );            
            isUpdateProyectos_TipoProyecto = true;
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

function ValidarEliminarProyectos_TipoProyecto(idtipoproyecto, nombrecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + nombrecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_TipoProyecto(idtipoproyecto);
            }
        });

}

function EliminarProyectos_TipoProyecto(idtipoproyecto) {
    let urlEliminar = urlController + "Proyectos_TipoProyecto/DeleteProyectos_TipoProyecto?id_tipoproyecto=" + idtipoproyecto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_TipoProyecto();
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
