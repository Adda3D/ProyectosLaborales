var ObjModelDecVie_PreAval= null;


$(document).ready(function () {

  ObjModelDecVie_PreAval = new DecVie_PreAval();

    if ($("#spanIdDecVie_PreAval")[0].innerText == '') {
        CrearDecVie_PreAvalform();
    }
    else {
        EditarDecVie_PreAvalform($("#spanIdDecVie_PreAval")[0].innerText);
    }

});

function CerrarDecVie_PreAvalDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_PreAval);
    
    $("#dvDecVie_PreAvalDetalle").addClass("ocultar");    
    $("#dvDecVie_PreAvalTable").removeClass("ocultar");

}

function CrearDecVie_PreAvalform() {

    CreateHTMLFromModel(ObjModelDecVie_PreAval)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_PreAval)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_preaval_DecVie_PreAval").val('');   
                    FinalizeLoader();
    
                    $("#dvDecVie_PreAvalTable").addClass("ocultar");    
                    $("#dvDecVie_PreAvalDetalle").removeClass("ocultar");            
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

function EditarDecVie_PreAvalform(idpreaval) {

    CreateHTMLFromModel(ObjModelDecVie_PreAval)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_PreAval, idpreaval)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_PreAvalTable").addClass("ocultar");    
                    $("#dvDecVie_PreAvalDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_PreAval(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_PreAval)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos PreAval Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_PreAval();
      CerrarDecVie_PreAvalDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}


