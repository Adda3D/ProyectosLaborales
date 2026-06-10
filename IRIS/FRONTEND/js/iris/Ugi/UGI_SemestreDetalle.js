var ObjModelUGI_Semestre= null;


$(document).ready(function () {

  ObjModelUGI_Semestre = new UGI_Semestre();

    if ($("#spanIdUGI_Semestre")[0].innerText == '') {
        CrearUGI_Semestreform();
    }
    else {
        EditarUGI_Semestreform($("#spanIdUGI_Semestre")[0].innerText);
    }

});

function CerrarUGI_SemestreDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelUGI_Semestre);
    
    $("#dvUGI_SemestreDetalle").addClass("ocultar");    
    $("#dvUGI_SemestreTable").removeClass("ocultar");

}

function CrearUGI_Semestreform() {

    CreateHTMLFromModel(ObjModelUGI_Semestre)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelUGI_Semestre)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_ugisemestre_UGI_Semestre").val('');   
                    FinalizeLoader();
    
                    $("#dvUGI_SemestreTable").addClass("ocultar");    
                    $("#dvUGI_SemestreDetalle").removeClass("ocultar");            
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

function EditarUGI_Semestreform(idugisemestre) {

    CreateHTMLFromModel(ObjModelUGI_Semestre)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelUGI_Semestre, idugisemestre)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvUGI_SemestreTable").addClass("ocultar");    
                    $("#dvUGI_SemestreDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateUGI_Semestre(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelUGI_Semestre)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos Ejecución Semestre Guardados', false, 'success', '', 0);  
      RefreshDataTableUGI_Semestre();
      CerrarUGI_SemestreDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}


