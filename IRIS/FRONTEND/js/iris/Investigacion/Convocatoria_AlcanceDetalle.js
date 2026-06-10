var ObjModelConvocatoria_Alcance= null;


$(document).ready(function () {

  ObjModelConvocatoria_Alcance = new Convocatoria_Alcance();

    if ($("#spanIdConvocatoria_Alcance")[0].innerText == '') {
        CrearConvocatoria_Alcanceform();
    }
    else {
        EditarConvocatoria_Alcanceform($("#spanIdConvocatoria_Alcance")[0].innerText);
    }

});

function CerrarConvocatoria_AlcanceDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelConvocatoria_Alcance);
    
    $("#dvConvocatoria_AlcanceDetalle").addClass("ocultar");    
    $("#dvConvocatoria_AlcanceTable").removeClass("ocultar");

}

function CrearConvocatoria_Alcanceform() {

    CreateHTMLFromModel(ObjModelConvocatoria_Alcance)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria_Alcance)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_alcance_Convocatoria_Alcance").val('');                         
                    FinalizeLoader();
    
                    $("#dvConvocatoria_AlcanceTable").addClass("ocultar");    
                    $("#dvConvocatoria_AlcanceDetalle").removeClass("ocultar");            
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

function EditarConvocatoria_Alcanceform(idalcance) {
debugger;
    CreateHTMLFromModel(ObjModelConvocatoria_Alcance)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelConvocatoria_Alcance, idalcance)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvConvocatoria_AlcanceTable").addClass("ocultar");    
                    $("#dvConvocatoria_AlcanceDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateConvocatoria_Alcance(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria_Alcance)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Alcance Guardados', false, 'success', '', 0);  
      RefreshDataTableConvocatoria_Alcance();
      CerrarConvocatoria_AlcanceDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

