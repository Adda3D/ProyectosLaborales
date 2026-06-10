var ObjModelMatrizFinanciera_Vigencia= null;


$(document).ready(function () {

  ObjModelMatrizFinanciera_Vigencia = new MatrizFinanciera_Vigencia();

    if ($("#spanIdMatrizFinanciera_Vigencia")[0].innerText == '') {
        CrearMatrizFinanciera_Vigenciaform();
    }
    else {
        EditarMatrizFinanciera_Vigenciaform($("#spanIdMatrizFinanciera_Vigencia")[0].innerText);
    }

});

function CerrarMatrizFinanciera_VigenciaDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelMatrizFinanciera_Vigencia);
    
    $("#dvMatrizFinanciera_VigenciaDetalle").addClass("ocultar");    
    $("#dvMatrizFinanciera_VigenciaTable").removeClass("ocultar");

}

function CrearMatrizFinanciera_Vigenciaform() {

    CreateHTMLFromModel(ObjModelMatrizFinanciera_Vigencia)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelMatrizFinanciera_Vigencia)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_vigencia_MatrizFinanciera_Vigencia").val('');
                      
                    FinalizeLoader();
    
                    $("#dvMatrizFinanciera_VigenciaTable").addClass("ocultar");    
                    $("#dvMatrizFinanciera_VigenciaDetalle").removeClass("ocultar");            
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

function EditarMatrizFinanciera_Vigenciaform(id_vigencia) {

    CreateHTMLFromModel(ObjModelMatrizFinanciera_Vigencia)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelMatrizFinanciera_Vigencia, id_vigencia)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvMatrizFinanciera_VigenciaTable").addClass("ocultar");    
                    $("#dvMatrizFinanciera_VigenciaDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateMatrizFinanciera_Vigencia(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelMatrizFinanciera_Vigencia)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la Vigencia Guardados', false, 'success', '', 0);  
      RefreshDataTableMatrizFinanciera_Vigencia();
      CerrarMatrizFinanciera_VigenciaDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

