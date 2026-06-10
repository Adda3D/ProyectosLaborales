var ObjModelDecVie_PlanAccionAlcance= null;


$(document).ready(function () {

  ObjModelDecVie_PlanAccionAlcance = new DecVie_PlanAccionAlcance();

    if ($("#spanIdDecVie_PlanAccionAlcance")[0].innerText == '') {
        CrearDecVie_PlanAccionAlcanceform();
    }
    else {
        EditarDecVie_PlanAccionAlcanceform($("#spanIdDecVie_PlanAccionAlcance")[0].innerText);
    }

});

function CerrarDecVie_PlanAccionAlcanceDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PlanAccionAlcance);
    
    $("#dvDecVie_PlanAccionAlcanceDetalle").addClass("ocultar");    
    $("#dvDecVie_PlanAccionAlcanceTable").removeClass("ocultar");

}

function CrearDecVie_PlanAccionAlcanceform() {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionAlcance)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PlanAccionAlcance)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_planaccionalcance_DecVie_PlanAccionAlcance").val('');
                    $("#txtid_depend_DecVie_PlanAccionAlcance").val('2');     
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionAlcanceTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionAlcanceDetalle").removeClass("ocultar");            
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

function EditarDecVie_PlanAccionAlcanceform(idplanaccionalcance) {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionAlcance)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PlanAccionAlcance, idplanaccionalcance)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionAlcanceTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionAlcanceDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PlanAccionAlcance(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PlanAccionAlcance)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Alcance Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PlanAccionAlcance();
      CerrarDecVie_PlanAccionAlcanceDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

