var ObjModelPropuestas_cobertura= null;


$(document).ready(function () {

  ObjModelPropuestas_cobertura = new Propuestas_cobertura();

    if ($("#spanIdPropuestas_cobertura")[0].innerText == '') {
        CrearPropuestas_coberturaform();
    }
    else {
        EditarPropuestas_coberturaform($("#spanIdPropuestas_cobertura")[0].innerText);
    }

});

function CerrarPropuestas_cobertura() {
    debugger;
  DestruirCamposSelect_Model(ObjModelPropuestas_cobertura);
    
    $("#dvPropuestas_coberturaDetalle").addClass("ocultar");    
    $("#dvPropuestas_coberturaTable").removeClass("ocultar");

}

function CrearPropuestas_coberturaform() {

    CreateHTMLFromModel(ObjModelPropuestas_cobertura)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPropuestas_cobertura)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_cobertura_Propuestas_cobertura").val('');                         
                    FinalizeLoader();
    
                    $("#dvPropuestas_coberturaTable").addClass("ocultar");    
                    $("#dvPropuestas_coberturaDetalle").removeClass("ocultar");            
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

function EditarPropuestas_coberturaform(idcobertura) {

    CreateHTMLFromModel(ObjModelPropuestas_cobertura)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPropuestas_cobertura, idcobertura)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvPropuestas_coberturaTable").addClass("ocultar");    
                    $("#dvPropuestas_coberturaDetalle").removeClass("ocultar");            
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

function ValidatePostUpdatePropuestas_cobertura(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelPropuestas_cobertura)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la Cobertura Guardados', false, 'success', '', 0);  
      RefreshDataTablePropuestas_cobertura();
      CerrarPropuestas_cobertura();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}