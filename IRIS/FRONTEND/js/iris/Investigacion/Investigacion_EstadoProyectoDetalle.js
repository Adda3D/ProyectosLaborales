var ObjModelInvestigacion_EstadoProyecto= null;


$(document).ready(function () {

  ObjModelInvestigacion_EstadoProyecto = new Investigacion_EstadoProyecto();

    if ($("#spanIdInvestigacion_EstadoProyecto")[0].innerText == '') {
        CrearInvestigacion_EstadoProyectoform();
    }
    else {
        EditarInvestigacion_EstadoProyectoform($("#spanIdInvestigacion_EstadoProyecto")[0].innerText);
    }

});

function CerrarInvestigacion_EstadoProyectoDesdeEstado() {
  DestruirCamposSelect_Model(ObjModelInvestigacion_EstadoProyecto);
    
    $("#dvInvestigacion_EstadoProyectoDetalle").addClass("ocultar");    
    $("#dvInvestigacion_EstadoProyectoTable").removeClass("ocultar");

}

function CrearInvestigacion_EstadoProyectoform() {

    CreateHTMLFromModel(ObjModelInvestigacion_EstadoProyecto)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelInvestigacion_EstadoProyecto)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_estado_Investigacion_EstadoProyecto").val('');                         
                    FinalizeLoader();
    
                    $("#dvInvestigacion_EstadoProyectoTable").addClass("ocultar");    
                    $("#dvInvestigacion_EstadoProyectoDetalle").removeClass("ocultar");            
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

function EditarInvestigacion_EstadoProyectoform(idestado) {

    CreateHTMLFromModel(ObjModelInvestigacion_EstadoProyecto)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelInvestigacion_EstadoProyecto, idestado)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvInvestigacion_EstadoProyectoTable").addClass("ocultar");    
                    $("#dvInvestigacion_EstadoProyectoDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateInvestigacion_EstadoProyecto(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelInvestigacion_EstadoProyecto)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Estado Guardados', false, 'success', '', 0);  
      RefreshDataTableInvestigacion_EstadoProyecto();
      CerrarInvestigacion_EstadoProyectoDesdeEstado();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}