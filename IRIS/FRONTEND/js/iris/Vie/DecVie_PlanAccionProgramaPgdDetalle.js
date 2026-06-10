var ObjModelDecVie_PlanAccionProgramaPgd= null;


$(document).ready(function () {

  ObjModelDecVie_PlanAccionProgramaPgd = new DecVie_PlanAccionProgramaPgd();

    if ($("#spanIdDecVie_PlanAccionProgramaPgd")[0].innerText == '') {
        CrearDecVie_PlanAccionProgramaPgdform();
    }
    else {
        EditarDecVie_PlanAccionProgramaPgdform($("#spanIdDecVie_PlanAccionProgramaPgd")[0].innerText);
    }

});

function CerrarDecVie_PlanAccionProgramaPgdDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PlanAccionProgramaPgd);
    
    $("#dvDecVie_PlanAccionProgramaPgdDetalle").addClass("ocultar");    
    $("#dvDecVie_PlanAccionProgramaPgdTable").removeClass("ocultar");

}

function CrearDecVie_PlanAccionProgramaPgdform() {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionProgramaPgd)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PlanAccionProgramaPgd)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_programapgd_DecVie_PlanAccionProgramaPgd").val('');
                    $("#txtid_depend_DecVie_PlanAccionProgramaPgd").val('2');     
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionProgramaPgdTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionProgramaPgdDetalle").removeClass("ocultar");            
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

function EditarDecVie_PlanAccionProgramaPgdform(idprogramapgd) {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionProgramaPgd)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PlanAccionProgramaPgd, idprogramapgd)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionProgramaPgdTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionProgramaPgdDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PlanAccionProgramaPgd(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PlanAccionProgramaPgd)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Programa PGD Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PlanAccionProgramaPgd();
      CerrarDecVie_PlanAccionProgramaPgdDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

