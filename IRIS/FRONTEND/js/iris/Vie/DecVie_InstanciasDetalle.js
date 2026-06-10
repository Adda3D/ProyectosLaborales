var ObjModelDecVie_Instancias= null;


$(document).ready(function () {

  ObjModelDecVie_Instancias = new DecVie_Instancias();

    if ($("#spanIdDecVie_Instancias")[0].innerText == '') {
        CrearDecVie_Instanciasform();
    }
    else {
        EditarDecVie_Instanciasform($("#spanIdDecVie_Instancias")[0].innerText);
    }

});

function CerrarDecVie_InstanciasDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_Instancias);
    
    $("#dvDecVie_InstanciasDetalle").addClass("ocultar");    
    $("#dvDecVie_InstanciasTable").removeClass("ocultar");

}

function CrearDecVie_Instanciasform() {

    CreateHTMLFromModel(ObjModelDecVie_Instancias)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_Instancias)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_instancia_DecVie_Instancias").val('');
                    FinalizeLoader();
    
                    $("#dvDecVie_InstanciasTable").addClass("ocultar");    
                    $("#dvDecVie_InstanciasDetalle").removeClass("ocultar");            
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

function EditarDecVie_Instanciasform(idinstancia) {

    CreateHTMLFromModel(ObjModelDecVie_Instancias)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_Instancias, idinstancia)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_InstanciasTable").addClass("ocultar");    
                    $("#dvDecVie_InstanciasDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_Instancias(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_Instancias)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la Instancia Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_Instancias();
      CerrarDecVie_InstanciasDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}