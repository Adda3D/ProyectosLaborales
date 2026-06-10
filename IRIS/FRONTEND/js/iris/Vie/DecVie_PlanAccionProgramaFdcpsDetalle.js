var ObjModelDecVie_PlanAccionProgramaFdcps= null;


$(document).ready(function () {

  ObjModelDecVie_PlanAccionProgramaFdcps = new DecVie_PlanAccionProgramaFdcps();

    if ($("#spanIdDecVie_PlanAccionProgramaFdcps")[0].innerText == '') {
        CrearDecVie_PlanAccionProgramaFdcpsform();
    }
    else {
        EditarDecVie_PlanAccionProgramaFdcpsform($("#spanIdDecVie_PlanAccionProgramaFdcps")[0].innerText);
    }

});

function CerrarDecVie_PlanAccionProgramaFdcpsDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PlanAccionProgramaFdcps);
    
    $("#dvDecVie_PlanAccionProgramaFdcpsDetalle").addClass("ocultar");    
    $("#dvDecVie_PlanAccionProgramaFdcpsTable").removeClass("ocultar");

}

function CrearDecVie_PlanAccionProgramaFdcpsform() {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionProgramaFdcps)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PlanAccionProgramaFdcps)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_programafdcps_DecVie_PlanAccionProgramaFdcps").val('');
                    $("#txtid_depend_DecVie_PlanAccionProgramaFdcps").val('2');     
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionProgramaFdcpsTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionProgramaFdcpsDetalle").removeClass("ocultar");            
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

function EditarDecVie_PlanAccionProgramaFdcpsform(idprogramafdcps) {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionProgramaFdcps)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PlanAccionProgramaFdcps, idprogramafdcps)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionProgramaFdcpsTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionProgramaFdcpsDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PlanAccionProgramaFdcps(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PlanAccionProgramaFdcps)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Programa FDCPS Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PlanAccionProgramaFdcps();
      CerrarDecVie_PlanAccionProgramaFdcpsDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

