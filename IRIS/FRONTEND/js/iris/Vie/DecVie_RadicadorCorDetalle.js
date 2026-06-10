var ObjModelDecVie_RadicadorCor = null;


$(document).ready(function () {

  ObjModelDecVie_RadicadorCor = new DecVie_RadicadorCor();

    if ($("#spanIdDecVie_RadicadorCor")[0].innerText == '') {
        CrearDecVie_RadicadorCorform();
    }
    else {
        EditarDecVie_RadicadorCorform($("#spanIdDecVie_RadicadorCor")[0].innerText);
    }

});

function CerrarDecVie_RadicadorCorDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_RadicadorCor);
    
    $("#dvDecVie_RadicadorCorDetalle").addClass("ocultar");    
    $("#dvDecVie_RadicadorCorTable").removeClass("ocultar");

}

function CrearDecVie_RadicadorCorform() {
    $("#spanIdDecVie_RadicadorCor")[0].innerText = '';
    $("#txtid_radicadorcor_DecVie_RadicadorCor").val('');   

    NewData_ToModel(ObjModelDecVie_RadicadorCor)
        .then(datospreparados => {
            if (datospreparados) { 
                FinalizeLoader();

                $("#dvDecVie_RadicadorCorTable").addClass("ocultar");    
                $("#dvDecVie_RadicadorCorDetalle").removeClass("ocultar");            
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  

}

function EditarDecVie_RadicadorCorform(idradicadorcor) {
    $("#spanIdDecVie_RadicadorCorForm")[0].innerText = idradicadorcor;
    $("#txtid_radicadorcor_DecVie_RadicadorCor").val(idradicadorcor);

    LoadData_ToModel(ObjModelDecVie_RadicadorCor, idradicadorcor)
        .then(datoscargados => {
            if (datoscargados) { 
                FinalizeLoader();

                $("#dvDecVie_RadicadorCorTable").addClass("ocultar");    
                $("#dvDecVie_RadicadorCorDetalle").removeClass("ocultar");            
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  

}

function ValidatePostUpdateDecVie_RadicadorCor(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_RadicadorCor)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos Consecutivo Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_RadicadorCor();
      CerrarDecVie_RadicadorCorDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

