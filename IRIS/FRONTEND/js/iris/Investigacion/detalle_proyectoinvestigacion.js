var ObjModelInvestigacion_CrearProyecto = null;

$(document).ready(function () {
debugger;
  ObjModelInvestigacion_CrearProyecto = new Investigacion_CrearProyecto();

    if ($("#spanIdProyectoInvestigacion")[0].innerText == '') {
        CrearInvestigacion_CrearProyectoform();
    }
    else {
        EditarInvestigacion_CrearProyectoform();
    }

});

function CerrarProyecto_InvestigacionDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelInvestigacion_CrearProyecto);
    
    $("#dvProyectoInvestigacionDetalle").addClass("ocultar");     
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");

}

function CrearInvestigacion_CrearProyectoform() {

    CreateHTMLFromModel(ObjModelInvestigacion_CrearProyecto)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelInvestigacion_CrearProyecto)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_crearproyecto_Investigacion_CrearProyecto").val('');
                    $("#txtvalortotalproyecto_Investigacion_CrearProyecto").removeClass("iris-number");
                    $("#txtvalortotalproyecto_Investigacion_CrearProyecto").addClass("iris-number");
                    TotalesValorPRJINV();
                    FinalizeLoader();
    
                    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
                    $("#dvProyectoInvestigacionDetalle").removeClass("ocultar");            
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

function EditarInvestigacion_CrearProyectoform() {
    let idproyecto = $("#spanIdProyectoInvestigacion")[0].innerText;

    CreateHTMLFromModel(ObjModelInvestigacion_CrearProyecto)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelInvestigacion_CrearProyecto, idproyecto)
            .then(datoscargados => {
                if (datoscargados) { 
                    $("#txtvalortotalproyecto_Investigacion_CrearProyecto").removeClass("iris-number");
                    $("#txtvalortotalproyecto_Investigacion_CrearProyecto").addClass("iris-number");
                    TotalesValorPRJINV();

                    FinalizeLoader();
    
                    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
                    $("#dvProyectoInvestigacionDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateProyecto_InvestigacionForm(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelInvestigacion_CrearProyecto)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del proyecto Guardados', false, 'success', '', 0);  
      RefreshDataTableProyectoInvestigacion();
      CerrarProyecto_InvestigacionDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

