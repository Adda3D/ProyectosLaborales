var ObjModelMatrizFinanciera= null;


$(document).ready(function () {

  ObjModelMatrizFinanciera = new MatrizFinanciera();

    if ($("#spanIdMatrizFinanciera")[0].innerText == '') {
        CrearMatrizFinancieraform();
    }
    else {
        EditarMatrizFinancieraform($("#spanIdMatrizFinanciera")[0].innerText);
    }

});

function CerrarMatrizFinancieraDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelMatrizFinanciera);
    
    $("#dvMatrizFinancieraDetalle").addClass("ocultar");    
    $("#dvMatrizFinancieraTable").removeClass("ocultar");

}

function CrearMatrizFinancieraform() {

    CreateHTMLFromModel(ObjModelMatrizFinanciera)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelMatrizFinanciera)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matrizfinanciera_MatrizFinanciera").val('');
                    $("#txtid_depend_MatrizFinanciera").val(IdDependenciaUsuarioLogueado);                                       
                    FinalizeLoader();
    
                    $("#dvMatrizFinancieraTable").addClass("ocultar");    
                    $("#dvMatrizFinancieraDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateMatrizFinanciera(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelMatrizFinanciera)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la MatrizFinanciera Guardados', false, 'success', '', 0);  
      RefreshDataTableMatrizFinanciera();
      CerrarMatrizFinancieraDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

function EditarMatrizFinancieraform(id_matrizfinanciera) {

    CreateHTMLFromModel(ObjModelMatrizFinanciera)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelMatrizFinanciera, id_matrizfinanciera)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvMatrizFinancieraTable").addClass("ocultar");    
                    $("#dvMatrizFinancieraDetalle").removeClass("ocultar"); 
                    RefreshDataTableMatrizFinanciera();           
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
