var ObjModelPublicaciones_Distribuidor = null;


$(document).ready(function () {

  ObjModelPublicaciones_Distribuidor = new Publicaciones_Distribuidor();

    if ($("#spanIddistribuidorPublicaciones_Distribuidor")[0].innerText == '') {
        CrearPublicaciones_Distribuidorform();
    }
    else {
        EditarPublicaciones_Distribuidorform($("#spanIddistribuidorPublicaciones_Distribuidor")[0].innerText);
    }

});

function CerrarPublicaciones_DistribuidorDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelPublicaciones_Distribuidor);
    
    $("#dvPublicaciones_DistribuidorDetalle").addClass("ocultar");    
    $("#dvPublicaciones_DistribuidorTable").removeClass("ocultar");

}

function CrearPublicaciones_Distribuidorform() {

    CreateHTMLFromModel(ObjModelPublicaciones_Distribuidor)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPublicaciones_Distribuidor)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtiddistribuidor_Publicaciones_Distribuidor").val('');   
                    FinalizeLoader();
    
                    $("#dvPublicaciones_DistribuidorTable").addClass("ocultar");    
                    $("#dvPublicaciones_DistribuidorDetalle").removeClass("ocultar");            
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

function EditarPublicaciones_Distribuidorform(idprefijoconsecutivo) {

    CreateHTMLFromModel(ObjModelPublicaciones_Distribuidor)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_Distribuidor, idprefijoconsecutivo)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvPublicaciones_DistribuidorTable").addClass("ocultar");    
                    $("#dvPublicaciones_DistribuidorDetalle").removeClass("ocultar");            
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

function ValidatePostUpdatePublicaciones_DistribuidorForm(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_Distribuidor)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del distribuidor Guardados', false, 'success', '', 0);  
      RefreshDataTablePublicaciones_Distribuidor();
      CerrarPublicaciones_DistribuidorDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

