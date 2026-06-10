var ObjModelDecvie_CicloFinanciero= null;


$(document).ready(function () {

  ObjModelDecvie_CicloFinanciero = new Decvie_CicloFinanciero();

    if ($("#spanIdDecvie_CicloFinanciero")[0].innerText == '') {
        CrearDecvie_CicloFinancieroform();
    }
    else {
        EditarDecvie_CicloFinanciero($("#spanIdDecvie_CicloFinanciero")[0].innerText);
    }

});

function CerrarDecvie_CicloFinancieroDesdeCicloFinanciero() {
  DestruirCamposSelect_Model(ObjModelDecvie_CicloFinanciero);
    
    $("#dvDecvie_CicloFinancieroDetalle").addClass("ocultar");    
    $("#dvDecvie_CicloFinancieroTable").removeClass("ocultar");

}

function CrearDecvie_CicloFinancieroform() {

    CreateHTMLFromModel(ObjModelDecvie_CicloFinanciero)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_CicloFinanciero)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_ciclofinanciero_Decvie_CicloFinanciero").val('');
                    $("#txtid_semestre_Decvie_CicloFinanciero").val(spanIDSemestreDecvie_CicloFinanciero);                                       
                    FinalizeLoader();
    
                    $("#dvDecvie_CicloFinancieroTable").addClass("ocultar");    
                    $("#dvDecvie_CicloFinancieroDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecvie_CicloFinanciero(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_CicloFinanciero)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Ciclo Financiero Guardados', false, 'success', '', 0);  
      RefreshDataTableDecvie_CicloFinanciero();
      CerrarDecvie_CicloFinancieroDesdeCicloFinanciero();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}


