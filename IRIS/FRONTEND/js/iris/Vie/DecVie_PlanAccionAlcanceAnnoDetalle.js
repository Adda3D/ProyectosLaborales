var ObjModelDecVie_PlanAccionAlcanceAnno= null;


$(document).ready(function () {

  ObjModelDecVie_PlanAccionAlcanceAnno = new DecVie_PlanAccionAlcanceAnno();

    if ($("#spanIdDecVie_PlanAccionAlcanceAnno")[0].innerText == '') {
        CrearDecVie_PlanAccionAlcanceAnnoform();
    }
    else {
        EditarDecVie_PlanAccionAlcanceAnnoform($("#spanIdDecVie_PlanAccionAlcanceAnno")[0].innerText);
    }

});

function CerrarDecVie_PlanAccionAlcanceAnnoDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PlanAccionAlcanceAnno);
    
    $("#dvDecVie_PlanAccionAlcanceAnnoDetalle").addClass("ocultar");    
    $("#dvDecVie_PlanAccionAlcanceAnnoTable").removeClass("ocultar");

}

function CrearDecVie_PlanAccionAlcanceAnnoform() {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionAlcanceAnno)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PlanAccionAlcanceAnno)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_alcanceanno_DecVie_PlanAccionAlcanceAnno").val('');   
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionAlcanceAnnoTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionAlcanceAnnoDetalle").removeClass("ocultar");            
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

function EditarDecVie_PlanAccionAlcanceAnnoform(idalcanceanno) {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionAlcanceAnno)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PlanAccionAlcanceAnno, idalcanceanno)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionAlcanceAnnoTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionAlcanceAnnoDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PlanAccionAlcanceAnno(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PlanAccionAlcanceAnno)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Prefijo Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PlanAccionAlcanceAnno();
      CerrarDecVie_PlanAccionAlcanceAnnoDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

