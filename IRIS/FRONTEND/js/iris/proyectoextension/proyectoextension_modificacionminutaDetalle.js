var ObjModelPropuesta_ModificacionMinuta = null;


$(document).ready(function () {

  ObjModelPropuesta_ModificacionMinuta = new Propuesta_ModificacionMinuta();

    if ($("#spanId_modificacionminutaProyectoExtension")[0].innerText == '') {
        CrearPropuesta_ModificacionMinutaform();
    }
    else {
        EditarPropuesta_ModificacionMinutaform($("#spanId_modificacionminutaProyectoExtension")[0].innerText);
    }

});

function VolverTablaModificacionMinutaDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPropuesta_ModificacionMinuta);
    
    $("#dvProyectoExtensionModificacionMinutaDetalle").addClass("ocultar");    
    //$("#dvProyectoExtensionModificacionMinutaTable").removeClass("ocultar");

    $("#dvVolverTablaProyectoExtensionDesdeModificaMinuta").removeClass("ocultar");
    $("#tableDynamicProyectoExtensionModificacionMinuta").removeClass("ocultar");
        
}

function CrearPropuesta_ModificacionMinutaform() {
debugger;
    CreateHTMLFromModel(ObjModelPropuesta_ModificacionMinuta)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPropuesta_ModificacionMinuta)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_modificacionminuta_Propuesta_ModificacionMinuta").val('');   
                    $("#txtid_propuesta_Propuesta_ModificacionMinuta").val($("#spanid_propuestaProyectoExtension")[0].innerText);
                    $("#txtid_suscripcionminuta_Propuesta_ModificacionMinuta").val($("#spanId_suscripcionminutaProyectoExtension")[0].innerText);
                    FinalizeLoader();
    
                    //$("#dvProyectoExtensionModificacionMinutaTable").addClass("ocultar"); 
                    $("#dvVolverTablaProyectoExtensionDesdeModificaMinuta").addClass("ocultar");
                    $("#tableDynamicProyectoExtensionModificacionMinuta").addClass("ocultar");
                   
                    $("#dvProyectoExtensionModificacionMinutaDetalle").removeClass("ocultar");      
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

function EditarPropuesta_ModificacionMinutaform(id_modificacionminuta) {

    CreateHTMLFromModel(ObjModelPropuesta_ModificacionMinuta)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPropuesta_ModificacionMinuta, id_modificacionminuta)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvVolverTablaProyectoExtensionDesdeModificaMinuta").addClass("ocultar");
                    $("#tableDynamicProyectoExtensionModificacionMinuta").addClass("ocultar");
                   
                    $("#dvProyectoExtensionModificacionMinutaDetalle").removeClass("ocultar");      
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

function ValidatePostUpdateProyectoExtension_ModificacionminutaForm(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelPropuesta_ModificacionMinuta)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      //ShowModalDialog('Datos del distribuidor Guardados', false, 'success', '', 0);  
      RefreshDataTableProyectoExtensionModificaMinuta();
      VolverTablaModificacionMinutaDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

