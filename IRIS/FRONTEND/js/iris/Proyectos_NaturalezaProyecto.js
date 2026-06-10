var isUpdateProyectos_NaturalezaProyecto = false;
var DataTableProyectos_NaturalezaProyecto = null;

$(document).ready(function () {
    LoadDataTableProyectos_NaturalezaProyecto();
});

function LoadDataTableProyectos_NaturalezaProyecto() {
    DataTableProyectos_NaturalezaProyecto = $('#tblProyectos_NaturalezaProyecto').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyectos_NaturalezaProyecto/GetDataTableProyectos_NaturalezaProyecto"
        },      
        "columns": [
            { "data": "naturalezaproyecto", "orderable": true },
            { "data": "detalles", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar" onclick="EditarProyectos_NaturalezaProyecto(' + row.id_naturalezaproyecto + ')" data-bs-toggle="modal" data-bs-target="#ModalProyectos_NaturalezaProyecto" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar" onclick="ValidarEliminarProyectos_NaturalezaProyecto(' + row.id_naturalezaproyecto + ',`' + row.naturalezaproyecto + '`);" />';
                },
                "className": "text-center", "orderable": false
            }
        ],  
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectos_NaturalezaProyecto() {
    DataTableProyectos_NaturalezaProyecto.ajax.reload(null, false);    
}

function ValidatePostUpdateProyectos_NaturalezaProyecto(formF, botonClose) {
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
                if ($("#spanIdProyectos_NaturalezaProyecto")[0].innerText == '') {
                    ExisteProyectos_NaturalezaProyecto()
                            .then(existe => {
                                if (!existe) {                                    
                                    AddUpdateProyectos_NaturalezaProyecto(botonClose);
                                }
                            }) 
                }
                else {
                    AddUpdateProyectos_NaturalezaProyecto(botonClose);
                }                                                                                                                                                                        
            }
        }
    }
}

function ExisteProyectos_NaturalezaProyecto() {    
    let naturalezaproyecto = $("#txtCdProyectosNaturalezaProyecto").val();   
    let urlValidar = urlController + "Proyectos_NaturalezaProyecto/GetProyectos_NaturalezaProyectoNaturaleza?cd_naturalezaproyecto=" + naturalezaproyecto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El nombre " + naturalezaproyecto + " ya está registrado.";
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

function AddUpdateProyectos_NaturalezaProyecto(botonCerrar) {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Proyectos_NaturalezaProyecto/UpdateProyectos_NaturalezaProyecto";

    objData.id_naturalezaproyecto = ($("#spanIdProyectos_NaturalezaProyecto")[0].innerText == '') ? undefined : $("#spanIdProyectos_NaturalezaProyecto")[0].innerText;
    objData.naturalezaproyecto = $("#txtCdProyectosNaturalezaProyecto").val();
    objData.detalles = $("#txtProyectos_NaturalezaProyecto").val();

    if (objData.id_naturalezaproyecto == undefined) {
        urlUpdate = urlController + "Proyectos_NaturalezaProyecto/InsertProyectos_NaturalezaProyecto";        
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

            RefreshDataTableProyectos_NaturalezaProyecto();
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

function CrearProyectos_NaturalezaProyecto() {
    $( "#txtCdProyectosNaturalezaProyecto" ).prop( "disabled", false );
    $("#spanIdProyectos_NaturalezaProyecto")[0].innerText = '';
    $("#txtCdProyectosNaturalezaProyecto").val('');
    $("#txtProyectos_NaturalezaProyecto").val('');
    isUpdateProyectos_NaturalezaProyecto = false;

    removeValidationFormByForm('formProyectos_NaturalezaProyecto');
}

function EditarProyectos_NaturalezaProyecto(idnaturalezaproyecto) {   
    removeValidationFormByForm('formProyectos_NaturalezaProyecto'); 
    let urlEditar = urlController + "Proyectos_NaturalezaProyecto/GetProyectos_NaturalezaProyectoDetails?id_naturalezaproyecto=" + idnaturalezaproyecto;
    isUpdateProyectos_NaturalezaProyecto = false;
    StartLoader();


    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let datos = data.Data;
            $("#spanIdProyectos_NaturalezaProyecto")[0].innerText = datos.id_naturalezaproyecto;
            $("#txtCdProyectosNaturalezaProyecto").val(datos.naturalezaproyecto);
            $("#txtProyectos_NaturalezaProyecto").val(datos.detalles);
            $( "#txtCdProyectosNaturalezaProyecto" ).prop( "disabled", false );            
            isUpdateProyectos_NaturalezaProyecto = true;
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

function ValidarEliminarProyectos_NaturalezaProyecto(idnaturalezaproyecto, Naturalezacompleto) {
    ShowDialogConfirmacion('','Seguro de eliminar ' + Naturalezacompleto + '?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProyectos_NaturalezaProyecto(idnaturalezaproyecto);
            }
        });

}

function EliminarProyectos_NaturalezaProyecto(idnaturalezaproyecto) {
    let urlEliminar = urlController + "Proyectos_NaturalezaProyecto/DeleteProyectos_NaturalezaProyecto?id_naturalezaproyecto=" + idnaturalezaproyecto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectos_NaturalezaProyecto();
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
