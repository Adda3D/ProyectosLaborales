var ObjModelDecVie_PlanAccionMatryoshka= null;


$(document).ready(function () {

  ObjModelDecVie_PlanAccionMatryoshka = new DecVie_PlanAccionMatryoshka();

    if ($("#spanIdDecVie_PlanAccionMatryoshka")[0].innerText == '') {
        CrearDecVie_PlanAccionMatryoshkaform();
    }
    else {
        EditarDecVie_PlanAccionMatryoshkaform($("#spanIdDecVie_PlanAccionMatryoshka")[0].innerText);
    }

});

function CerrarDecVie_PlanAccionMatryoshkaDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PlanAccionMatryoshka);
    
    $("#dvDecVie_PlanAccionMatryoshkaDetalle").addClass("ocultar");    
    $("#dvDecVie_PlanAccionMatryoshkaTable").removeClass("ocultar");

}

function CrearDecVie_PlanAccionMatryoshkaform() {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionMatryoshka)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PlanAccionMatryoshka)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshka_DecVie_PlanAccionMatryoshka").val('');
                    $("#txtid_depend_DecVie_PlanAccionMatryoshka").val('2');
                    $('#cboid_objetivopgdvrisede_DecVie_PlanAccionMatryoshka').select2({multiple: true});
                    $('#cboid_objetivodependencia_DecVie_PlanAccionMatryoshka').select2({multiple: true});
                    $('#cboid_meta_DecVie_PlanAccionMatryoshka').select2({multiple: true});
                    $('#cboid_indicadoresestrategicos_DecVie_PlanAccionMatryoshka').select2({multiple: true});
                    $('#cboid_nuevosindicadores_DecVie_PlanAccionMatryoshka').select2({multiple: true});
                    $('#cboid_tipoindicador_DecVie_PlanAccionMatryoshka').select2({multiple: true});
                    $('#cboid_planaccionalcance_DecVie_PlanAccionMatryoshka').select2({multiple: true});                    
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionMatryoshkaTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionMatryoshkaDetalle").removeClass("ocultar");            
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

function EditarDecVie_PlanAccionMatryoshkaform(idmatryoshka) {

    CreateHTMLFromModel(ObjModelDecVie_PlanAccionMatryoshka)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PlanAccionMatryoshka, idmatryoshka)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PlanAccionMatryoshkaTable").addClass("ocultar");    
                    $("#dvDecVie_PlanAccionMatryoshkaDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PlanAccionMatryoshka(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PlanAccionMatryoshka)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos Inventario Gestión del Conocimiento Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PlanAccionMatryoshka();
      CerrarDecVie_PlanAccionMatryoshkaDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}


