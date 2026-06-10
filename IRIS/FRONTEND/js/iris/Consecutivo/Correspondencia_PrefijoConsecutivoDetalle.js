var ObjModelCorrespondencia_PrefijoConsecutivo= null;


$(document).ready(function () {

  ObjModelCorrespondencia_PrefijoConsecutivo = new Correspondencia_PrefijoConsecutivo();

    if ($("#spanIdCorrespondencia_PrefijoConsecutivo")[0].innerText == '') {
        CrearCorrespondencia_PrefijoConsecutivoform();
    }
    else {
        EditarCorrespondencia_PrefijoConsecutivoform($("#spanIdCorrespondencia_PrefijoConsecutivo")[0].innerText);
    }

});

function CerrarCorrespondencia_PrefijoConsecutivoDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelCorrespondencia_PrefijoConsecutivo);
    
    $("#dvCorrespondencia_PrefijoConsecutivoDetalle").addClass("ocultar");    
    $("#dvCorrespondencia_PrefijoConsecutivoTable").removeClass("ocultar");

}

function CrearCorrespondencia_PrefijoConsecutivoform() {

    CreateHTMLFromModel(ObjModelCorrespondencia_PrefijoConsecutivo)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelCorrespondencia_PrefijoConsecutivo)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_prefijoconsecutivo_Correspondencia_PrefijoConsecutivo").val('');   
                    FinalizeLoader();
    
                    $("#dvCorrespondencia_PrefijoConsecutivoTable").addClass("ocultar");    
                    $("#dvCorrespondencia_PrefijoConsecutivoDetalle").removeClass("ocultar");            
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

function EditarCorrespondencia_PrefijoConsecutivoform(idprefijoconsecutivo) {

    CreateHTMLFromModel(ObjModelCorrespondencia_PrefijoConsecutivo)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelCorrespondencia_PrefijoConsecutivo, idprefijoconsecutivo)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvCorrespondencia_PrefijoConsecutivoTable").addClass("ocultar");    
                    $("#dvCorrespondencia_PrefijoConsecutivoDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateCorrespondencia_PrefijoConsecutivo(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelCorrespondencia_PrefijoConsecutivo)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Prefijo Guardados', false, 'success', '', 0);  
      RefreshDataTableCorrespondencia_PrefijoConsecutivo();
      CerrarCorrespondencia_PrefijoConsecutivoDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

