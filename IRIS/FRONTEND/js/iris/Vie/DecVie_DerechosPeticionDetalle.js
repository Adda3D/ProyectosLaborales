var ObjModelDecVie_DerechosPeticion= null;


$(document).ready(function () {

  ObjModelDecVie_DerechosPeticion = new DecVie_DerechosPeticion();

    if ($("#spanIdDecVie_DerechosPeticion")[0].innerText == '') {
        CrearDecVie_DerechosPeticionform();
    }
    else {
        EditarDecVie_DerechosPeticionform($("#spanIdDecVie_DerechosPeticion")[0].innerText);
    }

});

function CerrarDecVie_DerechosPeticionDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_DerechosPeticion);
    
    $("#dvDecVie_DerechosPeticionDetalle").addClass("ocultar");    
    $("#dvDecVie_DerechosPeticionTable").removeClass("ocultar");

}

function CrearDecVie_DerechosPeticionform() {

    CreateHTMLFromModel(ObjModelDecVie_DerechosPeticion)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_DerechosPeticion)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_derechopeticion_DecVie_DerechosPeticion").val('');   
                    FinalizeLoader();
    
                    $("#dvDecVie_DerechosPeticionTable").addClass("ocultar");    
                    $("#dvDecVie_DerechosPeticionDetalle").removeClass("ocultar");            
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

function EditarDecVie_DerechosPeticionform(idderechopeticion) {

    CreateHTMLFromModel(ObjModelDecVie_DerechosPeticion)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_DerechosPeticion, idderechopeticion)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_DerechosPeticionTable").addClass("ocultar");    
                    $("#dvDecVie_DerechosPeticionDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_DerechosPeticion(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_DerechosPeticion)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos derecho petición Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_DerechosPeticion();
      CerrarDecVie_DerechosPeticionDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

