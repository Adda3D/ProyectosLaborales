var DataTableProyectoExtensionAcuerdos = null;

$(document).ready(function () {    
    InicializaAcuerdosProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText, $("#spanConsecutivoProyectoExtension")[0].innerText,
                                                $("#spanContratoProyectoExtension")[0].innerText, $("#spanNombreProyectoExtension")[0].innerText);

});


function LoadDataTableProyectoExtensionAcuerdos() {
    DataTableProyectoExtensionAcuerdos = $('#tblProyectoExtensionAcuerdos').DataTable({
        "language": {
            "url": "/lib/dataTables/Language.json"
        },
        serverSide: true,
        processing: true,
        "search": {
            "caseInsensitive": true
        },
        "ajax": {
            "url": urlController + "Seguimiento_Acuerdo/GetDataTableSeguimiento_AcuerdoByProyecto",  //?id_asignacionproyecto=" + $("#spanIdProyectoExtensionAcuerdos")[0].innerText
            "data": {
                "id_asignacionproyecto": function() { return $("#spanIdProyectoExtensionAcuerdos")[0].innerText }                 
            }
        },      
        "columns": [                    
            { "data": "nroacuerdo", "orderable": true },
            { "data": "sedeacuerdo", "orderable": true },
            { "data": "facultadacuerdo", "orderable": true },
            { "data": "nombreacuerdo", "orderable": true },
            { "data": "iniciaacuerdo", "orderable": false, render: function (data, type, row, meta) {return row.iniciaacuerdo.slice(0,10)} },
            { "data": "finalizaacuerdo", "orderable": false, render: function (data, type, row, meta) {return row.finalizaacuerdo.slice(0,10)} },
            {
                render: function (data, type, row, meta) {
                    return '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Editar Datos" onclick="EditarAcuerdoProyectoExtension(' + row.idacuerdo + ')" /> ' +
                           '<img src="../images/iris/Eliminar.png" class="cambiarMouse" title="Eliminar Acuerdo" onclick="ValidarEliminarAcuerdoProyectoExtension(' + row.idacuerdo + ')" /> ';
                },
                "className": "text-center", "orderable": false
            }
        ],         
        dom: 'lBfrtip',
        "lengthMenu": [[10, 20, 30, 50], [10, 20, 30, 50]],
    });

}

function RefreshDataTableProyectoExtensionAcuerdos() {
    DataTableProyectoExtensionAcuerdos.ajax.reload(null, false);
}

function VolverTablaProyectoExtensionDesdeAcuerdos() {
    $("#dvProyectoExtensionTablaAcuerdos").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaAcuerdosProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionAcuerdos")[0].innerText = id_asignacionproyecto; 

    $("#txtConsProyectoExtensionAcuerdo").val(consecutivo);
    $("#txtContratoProyectoExtensionAcuerdo").val(contrato);
    $("#txtNombreProyectoExtensionAcuerdo").val(nombreproyecto);
    
    if (DataTableProyectoExtensionAcuerdos != null) {
        DataTableProyectoExtensionAcuerdos.destroy();
    }

    LoadDataTableProyectoExtensionAcuerdos(); 

    $("#dvProyectoExtensionTable").addClass("ocultar");        
    $("#dvProyectoExtensionTablaAcuerdos").removeClass("ocultar");
}

function EditarAcuerdosProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionAcuerdos")[0].innerText = id_asignacionproyecto;

    if (DataTableProyectoExtensionAcuerdos != null) {
        DataTableProyectoExtensionAcuerdos.destroy();
    }
    
    LoadDataTableProyectoExtensionAcuerdos();

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaAcuerdos").removeClass("ocultar");

}

function CrearAcuerdoProyectoExtension() {
    $("#spanProyectoExtensionIdAcuerdo")[0].innerText = '';

    $("#txtProyectoExtensionNroAcuerdo" ).prop( "disabled", false );
    $("#txtProyectoExtensionNroAcuerdo").val('');
    $("#txtProyectoExtensionSedeAcuerdo").val('');
    $("#txtProyectoExtensionFacultadAcuerdo").val('');
    $("#txtProyectoExtensionNombreAcuerdo").val('');
    $("#dtProyectoExtensionIniciaAcuerdo").val(getFechaActual());
    $("#dtProyectoExtensionFinAcuerdo").val(getFechaActual());
    $("#txtProyectoExtensionDuracionAcuerdo").val('');
    $("#txtProyectoExtensionObjetoAcuerdo").val('');
    $("#txtProyectoExtensionJustificacionAcuerdo").val('');
    $("#nmProyectoExtensionValorAcuerdo").val('0');
    $("#txtProyectoExtensionBenefAcuerdo").val('');
    $("#txtProyectoExtensionDificultadAcuerdo").val('');
    
    removeValidationFormByForm('formProyectoExtensionAcuerdoDatos'); 
    
    $("#tableProyectoExtensionAcuerdos").addClass("ocultar");
    $("#dvVolverTablaProyectoExtensionDesdeAcuerdos").addClass("ocultar");
    $("#dvProyectoExtensionAcuerdoDatos").removeClass("ocultar");                
}

function EditarAcuerdoProyectoExtension(idacuerdo) {
    removeValidationFormByForm('formProyectoExtensionAcuerdoDatos'); 

    $("#spanProyectoExtensionIdAcuerdo")[0].innerText = idacuerdo;
    let urlEditar = urlController + "Seguimiento_Acuerdo/GetSeguimiento_AcuerdoDetails?idacuerdo=" + idacuerdo;    
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            let objdatos = data.Data;

            $("#txtProyectoExtensionNroAcuerdo" ).prop( "disabled", true );
            $("#txtProyectoExtensionNroAcuerdo").val(objdatos.nroacuerdo);
            $("#txtProyectoExtensionSedeAcuerdo").val(objdatos.sedeacuerdo);
            $("#txtProyectoExtensionFacultadAcuerdo").val(objdatos.facultadacuerdo);
            $("#txtProyectoExtensionNombreAcuerdo").val(objdatos.nombreacuerdo);
            $("#dtProyectoExtensionIniciaAcuerdo").val(objdatos.iniciaacuerdo.slice(0,10));
            $("#dtProyectoExtensionFinAcuerdo").val(objdatos.finalizaacuerdo.slice(0,10));
            $("#txtProyectoExtensionDuracionAcuerdo").val(objdatos.duracionacuerdo);
            $("#txtProyectoExtensionObjetoAcuerdo").val(objdatos.objetoacuerdo);
            $("#txtProyectoExtensionJustificacionAcuerdo").val(objdatos.justificacionacuerdo);
            $("#nmProyectoExtensionValorAcuerdo").val(objdatos.valoracuerdo);
            $("#txtProyectoExtensionBenefAcuerdo").val(objdatos.beneficioacuerdo);
            $("#txtProyectoExtensionDificultadAcuerdo").val(objdatos.dificultadesacuerdo);
        
            $("#tableProyectoExtensionAcuerdos").addClass("ocultar");
            $("#dvVolverTablaProyectoExtensionDesdeAcuerdos").addClass("ocultar");
            $("#dvProyectoExtensionAcuerdoDatos").removeClass("ocultar");                
        
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
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        return;
      } );      
}

function ValidatePostUpdateProyectoExtensionAcuerdo(formF) {
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
                if ($("#spanProyectoExtensionIdAcuerdo")[0].innerText == '') {
                    ExisteProyectoExtensionNroAcuerdo()
                    .then(existe => {
                        if (!existe) {                                    
                            AddUpdateProyectoExtensionAcuerdo();
                        }
                    })                 
                }
                else {
                    AddUpdateProyectoExtensionAcuerdo();
                }
            }
        }
    }    
}

function ExisteProyectoExtensionNroAcuerdo() {    
    let numero = $("#txtProyectoExtensionNroAcuerdo").val();   
    let urlValidar = urlController + "Seguimiento_Acuerdo/GetSeguimiento_AcuerdoNroAcuerdo?nroacuerdo=" + numero;

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "El número de acuerdo ya está registrado para el proyecto.";
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

function AddUpdateProyectoExtensionAcuerdo() {
    var objData = new Object();
    let urlUpdate = urlController + "Seguimiento_Acuerdo/UpdateSeguimiento_Acuerdo";

    objData.id_asignacionproyecto = $("#spanIdProyectoExtensionAcuerdos")[0].innerText;
	objData.idacuerdo = ($("#spanProyectoExtensionIdAcuerdo")[0].innerText == '') ? undefined : $("#spanProyectoExtensionIdAcuerdo")[0].innerText;

    objData.nroacuerdo = $("#txtProyectoExtensionNroAcuerdo").val();
    objData.sedeacuerdo = $("#txtProyectoExtensionSedeAcuerdo").val();
    objData.facultadacuerdo = $("#txtProyectoExtensionFacultadAcuerdo").val();
    objData.nombreacuerdo = $("#txtProyectoExtensionNombreAcuerdo").val();
    objData.iniciaacuerdo = $("#dtProyectoExtensionIniciaAcuerdo").val();
    objData.finalizaacuerdo = $("#dtProyectoExtensionFinAcuerdo").val();
    objData.duracionacuerdo = $("#txtProyectoExtensionDuracionAcuerdo").val();
    objData.objetoacuerdo = $("#txtProyectoExtensionObjetoAcuerdo").val();
    objData.justificacionacuerdo = $("#txtProyectoExtensionJustificacionAcuerdo").val();
    objData.valoracuerdo = $("#nmProyectoExtensionValorAcuerdo").val();
    objData.beneficioacuerdo = $("#txtProyectoExtensionBenefAcuerdo").val();
    objData.dificultadesacuerdo = $("#txtProyectoExtensionDificultadAcuerdo").val();
    
    if (objData.idacuerdo == undefined) {
        urlUpdate = urlController + "Seguimiento_Acuerdo/InsertSeguimiento_Acuerdo";        
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
            
            RefreshDataTableProyectoExtensionAcuerdos();

            VolverTablaAcuerdosProyectoExtensionDesdeEdicion();

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

function VolverTablaAcuerdosProyectoExtensionDesdeEdicion() {            
    $("#dvProyectoExtensionAcuerdoDatos").addClass("ocultar");
    $("#tableProyectoExtensionAcuerdos").removeClass("ocultar");  
    $("#dvVolverTablaProyectoExtensionDesdeAcuerdos").removeClass("ocultar");  
}

function ValidarEliminarAcuerdoProyectoExtension(idacuerdo) {
    ShowDialogConfirmacion('','Seguro de eliminar acuerdo ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarAcuerdoProyectoExtension(idacuerdo);
            }
        });
}

function EliminarAcuerdoProyectoExtension(idacuerdo) {
    let urlEliminar = urlController + "Seguimiento_Acuerdo/DeleteSeguimiento_Acuerdo?idacuerdo=" + idacuerdo;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionAcuerdos();
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
