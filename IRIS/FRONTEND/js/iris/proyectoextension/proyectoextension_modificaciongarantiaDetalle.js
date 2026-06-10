var ObjModelPropuesta_ModificacionGarantia = null;


$(document).ready(function () {

  ObjModelPropuesta_ModificacionGarantia = new Propuesta_ModificacionGarantia();

    if ($("#spanId_modificacionGarantiaProyectoExtension")[0].innerText == '') {
        CrearPropuesta_ModificacionGarantiaform();
    }
    else {
        EditarPropuesta_ModificacionGarantiaform($("#spanId_modificacionGarantiaProyectoExtension")[0].innerText);
    }

});

function VolverTablaModificacionGarantiaDesdeEdicion() {
    DestruirCamposSelect_Model(ObjModelPropuesta_ModificacionGarantia);
    
    $("#dvProyectoExtensionModificacionGarantiaDetalle").addClass("ocultar");    
    //$("#dvProyectoExtensionModificacionGarantiaTable").removeClass("ocultar");

    $("#dvVolverTablaProyectoExtensionDesdeModificaGarantia").removeClass("ocultar");
    $("#tableDynamicProyectoExtensionModificacionGarantia").removeClass("ocultar");
        
}

function CrearPropuesta_ModificacionGarantiaform() {
debugger;
    CreateHTMLFromModel(ObjModelPropuesta_ModificacionGarantia)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelPropuesta_ModificacionGarantia)
            .then(datospreparados => {
                if (datospreparados) { 
                    debugger;
                    $("#txtid_modificacionGarantia_Propuesta_ModificacionGarantia").val('');   
                    $("#txtid_propuesta_Propuesta_ModificacionGarantia").val($("#spanid_propuestaProyectoExtension")[0].innerText);
                    $("#txtid_suscripciongarantia_Propuesta_ModificacionGarantia").val($("#spanId_suscripciongarantiaProyectoExtension")[0].innerText);
                    FinalizeLoader();
    
                    //$("#dvProyectoExtensionModificacionGarantiaTable").addClass("ocultar"); 
                    $("#dvVolverTablaProyectoExtensionDesdeModificaGarantia").addClass("ocultar");
                    $("#tableDynamicProyectoExtensionModificacionGarantia").addClass("ocultar");
                   
                    $("#dvProyectoExtensionModificacionGarantiaDetalle").removeClass("ocultar");      
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

function EditarPropuesta_ModificacionGarantiaform(id_modificaciongarantia) {

    CreateHTMLFromModel(ObjModelPropuesta_ModificacionGarantia)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPropuesta_ModificacionGarantia, id_modificaciongarantia)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvVolverTablaProyectoExtensionDesdeModificaGarantia").addClass("ocultar");
                    $("#tableDynamicProyectoExtensionModificacionGarantia").addClass("ocultar");
                   
                    $("#dvProyectoExtensionModificacionGarantiaDetalle").removeClass("ocultar");      
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

function ValidatePostUpdateProyectoExtension_ModificacionGarantiaForm(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelPropuesta_ModificacionGarantia)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      //ShowModalDialog('Datos del distribuidor Guardados', false, 'success', '', 0);  
      RefreshDataTableProyectoExtensionModificacionGarantia();
      VolverTablaModificacionGarantiaDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

