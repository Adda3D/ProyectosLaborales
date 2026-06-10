var DataTableProyectoExtensionProfesores = null;

$(document).ready(function () {    
    InicializaProfesoresProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText, $("#spanConsecutivoProyectoExtension")[0].innerText,
                                                $("#spanContratoProyectoExtension")[0].innerText, $("#spanNombreProyectoExtension")[0].innerText);

});


function LoadDataTableProyectoExtensionProfesores() {
    DataTableProyectoExtensionProfesores = $('#tblProyectoExtensionProfesores').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Proyecto_Persona/GetDataTableProyectos_PersonaByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionProfesores")[0].innerText + "&id_tipoproyecto=1"
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionProfesores")[0].innerText },
                "id_tipoproyecto": function() { return 1 }
            }
        },      
        "columns": [                    
            { "data": "nombrepersona", "orderable": true },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Retirar Profesor" onclick="ValidarEliminarProfesorProyectoExtension(' + row.id_proyectopersona + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionProfesores() {
    DataTableProyectoExtensionProfesores.ajax.reload(null, false);
}

function VolverTablaProyectoExtensionDesdeProfesores() {
    $("#dvProyectoExtensionTablaProfesores").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaProfesoresProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionProfesores")[0].innerText = id_asignacionproyecto; 

    $("#txtConsProyectoExtensionProfesor").val(consecutivo);
    $("#txtContratoProyectoExtensionProfesor").val(contrato);
    $("#txtNombreProyectoExtensionProfesor").val(nombreproyecto);
    
    if (DataTableProyectoExtensionProfesores != null) {
        DataTableProyectoExtensionProfesores.destroy();
    }

    LoadDataTableProyectoExtensionProfesores(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaProfesores").removeClass("ocultar");
}

function EditarProfesoresProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionProfesores")[0].innerText = id_asignacionproyecto;

    if (DataTableProyectoExtensionProfesores != null) {
        DataTableProyectoExtensionProfesores.destroy();
    }
    
    LoadDataTableProyectoExtensionProfesores();

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaProfesores").removeClass("ocultar");

}

function CrearProfesorProyectoExtension() {
    $("#spanProyectoExtensionIdProfesor")[0].innerText = '';

    LoadPrestadorServicio('cboProfesorProyectoExtension', true);          

    $('#cboProfesorProyectoExtension').select2({
        dropdownParent: $('#ModalProyectoExtensionProfesor'),
        placeholder: "Seleccione",        
        width: 'resolve'
    });
    
    removeValidationFormByForm('formProyectoExtensionProfesorDatos');    
}

function ValidatePostUpdateProyectoExtensionProfesor(formF, botonCerrar) {
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
                ExisteProfesorProyectoExtension()
                    .then(existe => {
                        if (!existe) {                                    
                            AddUpdateProyectoExtensionProfesor(botonCerrar);
                        }
                    })                 
            }
        }
    }    
}

function ExisteProfesorProyectoExtension() {
    let idproyecto = $("#spanIdProyectoExtensionProfesores")[0].innerText;
    let codigoProfesor = $("#cboProfesorProyectoExtension").val();   
    let urlValidar = urlController + "Proyecto_Persona/GetProyecto_PersonaByProyectoTipoPersona?id_proyecto=" + idproyecto + "&id_tipo=1&id_persona=" + codigoProfesor;

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El profesor ya está registrado para el proyecto.";
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

function AddUpdateProyectoExtensionProfesor(botonCerrar) {
    var objData = new Object();
    let urlUpdate = urlController + "Proyecto_Persona/UpdateProyecto_Persona";

    objData.id_asignacionproyecto = $("#spanIdProyectoExtensionProfesores")[0].innerText;
	objData.id_proyectopersona = ($("#spanProyectoExtensionIdProfesor")[0].innerText == '') ? undefined : $("#spanProyectoExtensionIdProfesor")[0].innerText;
    objData.id_tipoproyecto = 1;
    objData.id_persona = $("#cboProfesorProyectoExtension").val();
    
    if (objData.id_nuevoproducto == undefined) {
        urlUpdate = urlController + "Proyecto_Persona/InsertProyecto_Persona";        
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

            RefreshDataTableProyectoExtensionProfesores();
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

function CerrarModalProyectoExtensionProfesor() {
    if ($('#cboProfesorProyectoExtension').data('select2')) {
        $('#cboProfesorProyectoExtension').select2('destroy');        
      }    

}

function ValidarEliminarProfesorProyectoExtension(id_profesor) {
    ShowDialogConfirmacion('','Seguro de eliminar profesor', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarProfesorProyectoExtension(id_profesor);
            }
        });
}

function EliminarProfesorProyectoExtension(id_profesor) {
    let urlEliminar = urlController + "Proyecto_Persona/DeleteProyecto_Persona?id_proyectopersona=" + id_profesor;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionProfesores();
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