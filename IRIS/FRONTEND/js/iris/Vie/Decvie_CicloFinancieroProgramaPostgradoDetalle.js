var ObjModelDecvie_CicloFinancieroProgramaPostgrado= null;


$(document).ready(function () {

  ObjModelDecvie_CicloFinancieroProgramaPostgrado = new Decvie_CicloFinancieroProgramaPostgrado();

    if ($("#spanIdDecvie_CicloFinancieroProgramaPostgrado")[0].innerText == '') {
        CrearDecvie_CicloFinancieroProgramaPostgradoform();
    }
    else {
        EditarDecvie_CicloFinancieroProgramaPostgradoform($("#spanIdDecvie_CicloFinancieroProgramaPostgrado")[0].innerText);
    }

});

function CerrarDecvie_CicloFinancieroProgramaPostgradoDesdeProgramas() {
  DestruirCamposSelect_Model(ObjModelDecvie_CicloFinancieroProgramaPostgrado);
    
    $("#dvDecvie_CicloFinancieroProgramaPostgradoDetalle").addClass("ocultar");    
    $("#dvDecvie_CicloFinancieroProgramaPostgradoTable").removeClass("ocultar");

}

function CrearDecvie_CicloFinancieroProgramaPostgradoform() {

    CreateHTMLFromModel(ObjModelDecvie_CicloFinancieroProgramaPostgrado)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_CicloFinancieroProgramaPostgrado)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_programapostgrado_Decvie_CicloFinancieroProgramaPostgrado").val('');  
                    //***** */
                    FinalizeLoader();
    
                    $("#dvDecvie_CicloFinancieroProgramaPostgradoTable").addClass("ocultar");    
                    $("#dvDecvie_CicloFinancieroProgramaPostgradoDetalle").removeClass("ocultar");            
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

function EditarDecvie_CicloFinancieroProgramaPostgradoform(idprogramapostgrado) {

    CreateHTMLFromModel(ObjModelDecvie_CicloFinancieroProgramaPostgrado)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecvie_CicloFinancieroProgramaPostgrado, idprogramapostgrado)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecvie_CicloFinancieroProgramaPostgradoTable").addClass("ocultar");    
                    $("#dvDecvie_CicloFinancieroProgramaPostgradoDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecvie_CicloFinancieroProgramaPostgrado(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_CicloFinancieroProgramaPostgrado)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Programa Guardados', false, 'success', '', 0);  
      RefreshDataTableDecvie_CicloFinancieroProgramaPostgrado();
      CerrarDecvie_CicloFinancieroProgramaPostgradoDesdeProgramas();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

