var ObjModelDecvie_Matryoshka= null;


$(document).ready(function () {

  ObjModelDecvie_Matryoshka = new Decvie_Matryoshka();

    if ($("#spanIdDecvie_Matryoshka")[0].innerText == '') {
        CrearDecvie_Matryoshkaform();
    }
    else {
        EditarDecvie_Matryoshkaform($("#spanIdDecvie_Matryoshka")[0].innerText);
    }

});

function CerrarDecvie_MatryoshkaDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecvie_Matryoshka);
    
    $("#dvDecvie_MatryoshkaDetalle").addClass("ocultar");    
    $("#dvDecvie_MatryoshkaTable").removeClass("ocultar");

}

function CrearDecvie_Matryoshkaform() {

    CreateHTMLFromModel(ObjModelDecvie_Matryoshka)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecvie_Matryoshka)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_matryoshka_Decvie_Matryoshka").val('');
                    $("#txtid_depend_Decvie_Matryoshka").val(IdFiltroDependenciaUsuarioMatryoshka);                                       
                    FinalizeLoader();
    
                    $("#dvDecvie_MatryoshkaTable").addClass("ocultar");    
                    $("#dvDecvie_MatryoshkaDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecvie_Matryoshka(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecvie_Matryoshka)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la Matryoshka Guardados', false, 'success', '', 0);  
      RefreshDataTableDecvie_Matryoshka();
      CerrarDecvie_MatryoshkaDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}


