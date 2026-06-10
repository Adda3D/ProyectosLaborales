var isUpdateProyectos_AlcanceProyecto = false;
var DataTableProyectos_AlcanceProyecto = null;

$(document).ready(function () {
    LoadDataTableProyectos_AlcanceProyecto();
});

function LoadDataTableProyectos_AlcanceProyecto() {
    DataTableProyectos_AlcanceProyecto = $('#tblProyectos_AlcanceProyecto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_AlcanceProyecto/GetDataTableProyectos_AlcanceProyecto"
        },      
        "columns": [
            { "data": "alcanceproyecto", "orderable": true },
            { "data": "detalles", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_AlcanceProyecto(' + row.id_alcanceproyecto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_AlcanceProyecto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_AlcanceProyecto(' + row.id_alcanceproyecto + ',`' + row.alcanceproyecto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_AlcanceProyecto() {
    DataTableProyectos_AlcanceProyecto.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_AlcanceProyecto(formF, botonClose) {
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
                if ($("#spanIdProyectos_AlcanceProyecto")[0].innerText == '') {
                    ExisteProyectos_AlcanceProyecto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_AlcanceProyecto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_AlcanceProyecto(botonClose);
                }
                                                        
                            
            }
        }
    }
}

function ExisteProyectos_AlcanceProyecto() {    
    let alcanceproyecto = $("#txtCdProyectosAlcanceProyecto").val();   
    let urlValidar = urlController + "Proyectos_AlcanceProyecto/GetProyectos_AlcanceProyectoAlcance?cd_alcanceproyecto=" + alcanceproyecto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El alcance " + alcanceproyecto + " ya está registrado.";
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

function AddUpdateProyectos_AlcanceProyecto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_AlcanceProyecto/UpdateProyectos_AlcanceProyecto";

    objData.id_alcanceproyecto = ($("#spanIdProyectos_AlcanceProyecto")[0].innerText == '') ? undefined : $("#spanIdProyectos_AlcanceProyecto")[0].innerText;
    objData.alcanceproyecto = $("#txtCdProyectosAlcanceProyecto").val();
    objData.detalles = $("#txtProyectos_AlcanceProyecto").val();

    if (objData.id_alcanceproyecto == undefined) {
        urlUpdate = urlController + "Proyectos_AlcanceProyecto/InsertProyectos_AlcanceProyecto";        
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

            RefreshDataTableProyectos_AlcanceProyecto();
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

function CrearProyectos_AlcanceProyecto() {
    $("#spanIdProyectos_AlcanceProyecto")[0].innerText = '';
    $("#txtCdProyectosAlcanceProyecto").val('');
    $("#txtProyectos_AlcanceProyecto").val('');
    isUpdateProyectos_AlcanceProyecto = false;

    removeValidationFormByForm('formProyectos_AlcanceProyecto');
}

function EditarProyectos_AlcanceProyecto(idalcanceproyecto) {   
    removeValidationFormByForm('formProyectos_AlcanceProyecto'); 
    let urlEditar = urlController + "Proyectos_AlcanceProyecto/GetProyectos_AlcanceProyectoDetails?id_alcanceproyecto=" + idalcanceproyecto;
    isUpdateProyectos_AlcanceProyecto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_AlcanceProyecto")[0].innerText = datos.id_alcanceproyecto;
            $("#txtCdProyectosAlcanceProyecto").val(datos.alcanceproyecto);
            $("#txtProyectos_AlcanceProyecto").val(datos.detalles);            
            isUpdateProyectos_AlcanceProyecto = true;
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

function ValidarEliminarProyectos_AlcanceProyecto(idalcanceproyecto, alcancecompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + alcancecompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_AlcanceProyecto(idalcanceproyecto);
            }
        });

}

function EliminarProyectos_AlcanceProyecto(idalcanceproyecto) {
    let urlEliminar = urlController + "Proyectos_AlcanceProyecto/DeleteProyectos_AlcanceProyecto?id_alcanceproyecto=" + idalcanceproyecto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_AlcanceProyecto();
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
