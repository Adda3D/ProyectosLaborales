var ObjModelDecVie_PlanAccionEjeEstrategico= null;


$(document).ready(function () {

  ObjModelDecVie_PlanAccionEjeEstrategico = new DecVie_PlanAccionEjeEstrategico();

    if ($("#spanIdDecVie_PlanAccionEjeEstrategico")[0].innerText == '') {
        CrearDecVie_PlanAccionEjeEstrategicoform();
    }
    else {
        EditarDecVie_PlanAccionEjeEstrategicoform($("#spanIdDecVie_PlanAccionEjeEstrategico")[0].innerText);
    }

});

function CerrarDecVie_PlanAccionEjeEstrategicoDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PlanAccionEjeEstrategico);
    
    $("#dvDecVie_PlanAccionEjeEstrategicoDetalle").addClass("ocultar");    
    $("#dvDecVie_PlanAccionEjeEstrategicoTable").removeClass("ocultar");

}

function CrearDecVie_PlanAccionEjeEstrategicoform() {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionEjeEstrategico)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PlanAccionEjeEstrategico)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_ejeestrategico_DecVie_PlanAccionEjeEstrategico").val('');  
                    $("#txtid_depend_DecVie_PlanAccionEjeEstrategico").val('2'); 
                    //***** */
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionEjeEstrategicoTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionEjeEstrategicoDetalle").removeClass("ocultar");            
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

function EditarDecVie_PlanAccionEjeEstrategicoform(idejeestrategico) {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionEjeEstrategico)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PlanAccionEjeEstrategico, idejeestrategico)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionEjeEstrategicoTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionEjeEstrategicoDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PlanAccionEjeEstrategico(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PlanAccionEjeEstrategico)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Eje Estratégico Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PlanAccionEjeEstrategico();
      CerrarDecVie_PlanAccionEjeEstrategicoDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

