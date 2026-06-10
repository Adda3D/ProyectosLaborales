var ObjModelDecVie_InventarioGestionConocimiento= null;


$(document).ready(function () {

  ObjModelDecVie_InventarioGestionConocimiento = new DecVie_InventarioGestionConocimiento();

    if ($("#spanIdDecVie_InventarioGestionConocimiento")[0].innerText == '') {
        CrearDecVie_InventarioGestionConocimientoform();
    }
    else {
        EditarDecVie_InventarioGestionConocimientoform($("#spanIdDecVie_InventarioGestionConocimiento")[0].innerText);
    }

});

function CerrarDecVie_InventarioGestionConocimientoDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelDecVie_InventarioGestionConocimiento);
    
    $("#dvDecVie_InventarioGestionConocimientoDetalle").addClass("ocultar");    
    $("#dvDecVie_InventarioGestionConocimientoTable").removeClass("ocultar");

}

function CrearDecVie_InventarioGestionConocimientoform() {

    CreateHTMLFromModel(ObjModelDecVie_InventarioGestionConocimiento)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelDecVie_InventarioGestionConocimiento)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_invgesconocimiento_DecVie_InventarioGestionConocimiento").val('');   
                    FinalizeLoader();
    
                    $("#dvDecVie_InventarioGestionConocimientoTable").addClass("ocultar");    
                    $("#dvDecVie_InventarioGestionConocimientoDetalle").removeClass("ocultar");            
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

function EditarDecVie_InventarioGestionConocimientoform(idinvgesconocimiento) {

    CreateHTMLFromModel(ObjModelDecVie_InventarioGestionConocimiento)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelDecVie_InventarioGestionConocimiento, idinvgesconocimiento)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvDecVie_InventarioGestionConocimientoTable").addClass("ocultar");    
                    $("#dvDecVie_InventarioGestionConocimientoDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateDecVie_InventarioGestionConocimiento(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelDecVie_InventarioGestionConocimiento)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos Inventario Gestión del Conocimiento Guardados', false, 'success', '', 0);  
      RefreshDataTableDecVie_InventarioGestionConocimiento();
      CerrarDecVie_InventarioGestionConocimientoDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}


