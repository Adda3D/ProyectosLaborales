var ObjModelProyectos_AsignacionProyectoPropuesta = null;

$(document).ready(function () {

    ObjModelProyectos_AsignacionProyectoPropuesta = new Proyectos_AsignacionProyecto();

    CrearProyectos_AsignacionProyectoDesdePropuestaForm();
  
});
/*
function EditarPublicaciones_EstadoCorParam1_1Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam1_1.SufijoNombreControl = '1_1';
      ObjModelPublicaciones_EstadoCorParam1_1.FormEdicion = 'formPublicacionCorreccionEstilo1_1';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam1_1)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam1_1').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam1_1').val('1_1');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam1_1').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam1_1, idPublicacion, '1_1')
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
                }
            })    
            .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
            })      
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  
}
*/

function CrearProyectos_AsignacionProyectoDesdePropuestaForm() {
    if (ObjModelProyectos_AsignacionProyectoPropuesta == null){
        ObjModelProyectos_AsignacionProyectoPropuesta = new Proyectos_AsignacionProyecto();
    }

    ObjModelProyectos_AsignacionProyectoPropuesta.SufijoNombreControl = 'PROPUESTA';

    CreateHTMLFromModel(ObjModelProyectos_AsignacionProyectoPropuesta)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelProyectos_AsignacionProyectoPropuesta)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_asignacionproyecto_Proyectos_AsignacionProyectoPROPUESTA").val('');   
                    $("#txtid_propuesta_Proyectos_AsignacionProyectoPROPUESTA").val($("#spanIdPropuestaGeneral")[0].innerText);   
                    $("#txtconsecutivo_Proyectos_AsignacionProyectoPROPUESTA").val($("#spanConsecutivoPropuestaGeneral")[0].innerText);
                    $("#dtyearsuscripcion_Proyectos_AsignacionProyectoPROPUESTA").val($("#spanFechaSuscMinutPropuestaGeneral")[0].innerText);
                    $("#txtidpropuesta_entidad_Proyectos_AsignacionProyectoPROPUESTA").val($("#spanidpropuesta_entidadPropuestaGeneral")[0].innerText);
                    $("#txtid_tipopropuesta_Proyectos_AsignacionProyectoPROPUESTA").val($("#spanIdTipoPropuestaGeneral")[0].innerText);
                    $("#txtpropuesta_entidad_Proyectos_AsignacionProyectoPROPUESTA").val($("#spanpropuesta_entidadPropuestaGeneral")[0].innerText);
                    $("#txttipopropuesta_Proyectos_AsignacionProyectoPROPUESTA").val($("#spantipopropuestaPropuestaGeneral")[0].innerText);
        
                    $( "#txtconsecutivo_Proyectos_AsignacionProyectoPROPUESTA" ).prop( "disabled", true );
                    $( "#dtyearsuscripcion_Proyectos_AsignacionProyectoPROPUESTA" ).prop( "disabled", true );
                    $( "#txtvalortotal_Proyectos_AsignacionProyectoPROPUESTA" ).prop( "disabled", true );
                    $("#txtvalortotal_Proyectos_AsignacionProyectoPROPUESTA").removeClass("iris-number");
                    $("#txtvalortotal_Proyectos_AsignacionProyectoPROPUESTA").addClass("iris-number");

                    document.getElementById("nmvalinicialaporteentidad_Proyectos_AsignacionProyectoPROPUESTA").onchange = function() {CalculaValorTotalProyectoExtensionPropuestaCrear()};
                    document.getElementById("nmadiciondisminucion_Proyectos_AsignacionProyectoPROPUESTA").onchange = function() {CalculaValorTotalProyectoExtensionPropuestaCrear()};
                    document.getElementById("nmcontrapartida_Proyectos_AsignacionProyectoPROPUESTA").onchange = function() {CalculaValorTotalProyectoExtensionPropuestaCrear()};
                    CalculaValorTotalProyectoExtensionPropuestaCrear();

                    FinalizeLoader();    

                    $("#dvPropuestaExtensionTable").addClass("ocultar");    
                    $("#dvProyectoExtensionDetallePropuesta").removeClass("ocultar");
                
                }
            })
            .catch (err => {
                FinalizeLoader();
                ShowModalDialog(err, false, 'error', '', 0);
            })      
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })      
}

  
function ValidatePostUpdateProyectos_AsignacionProyectoPropuestaForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelProyectos_AsignacionProyectoPropuesta)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Proyecto Creado', false, 'success', '', 0);     
        
        VolverTablaPropuestasDesdeProyectoExtensionsCrear();
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

function VolverTablaPropuestasDesdeProyectoExtensionsCrear() {
    DestruirCamposSelect_Model(ObjModelProyectos_AsignacionProyectoPropuesta);

    $("#dvProyectoExtensionDetallePropuesta").addClass("ocultar");    
    $("#dvPropuestaExtensionTable").removeClass("ocultar");

}
  
function CalculaValorTotalProyectoExtensionPropuestaCrear() {
    let svalorinicial = $('#nmvalinicialaporteentidad_Proyectos_AsignacionProyectoPROPUESTA').val();
    let scambio = $('#nmadiciondisminucion_Proyectos_AsignacionProyectoPROPUESTA').val();
    let scontrapartida = $('#nmcontrapartida_Proyectos_AsignacionProyectoPROPUESTA').val();
    nvalorinicial = Number(svalorinicial);
    ncambio = Number(scambio);
    ncontrapartida = Number(scontrapartida);

    let nvalortotal = nvalorinicial + ncambio + ncontrapartida;
    let svalortotal = nvalortotal.toLocaleString('en-US');
    
    $('#txtvalortotal_Proyectos_AsignacionProyectoPROPUESTA').val(svalortotal);
}