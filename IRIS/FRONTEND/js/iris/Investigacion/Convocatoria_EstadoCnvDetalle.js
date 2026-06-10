var ObjModelConvocatoria_EstadoCnv= null;


$(document).ready(function () {

  ObjModelConvocatoria_EstadoCnv = new Convocatoria_EstadoCnv();

    if ($("#spanIdConvocatoria_EstadoCnv")[0].innerText == '') {
        CrearConvocatoria_EstadoCnvform();
    }
    else {
        EditarConvocatoria_EstadoCnvform($("#spanIdConvocatoria_EstadoCnv")[0].innerText);
    }

});

function CerrarConvocatoria_EstadoCnvDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelConvocatoria_EstadoCnv);
    
    $("#dvConvocatoria_EstadoCnvDetalle").addClass("ocultar");    
    $("#dvConvocatoria_EstadoCnvTable").removeClass("ocultar");

}

function CrearConvocatoria_EstadoCnvform() {

    CreateHTMLFromModel(ObjModelConvocatoria_EstadoCnv)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria_EstadoCnv)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_estadocnv_Convocatoria_EstadoCnv").val('');                         
                    FinalizeLoader();
    
                    $("#dvConvocatoria_EstadoCnvTable").addClass("ocultar");    
                    $("#dvConvocatoria_EstadoCnvDetalle").removeClass("ocultar");            
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

function EditarConvocatoria_EstadoCnvform(idestadocnv) {

    CreateHTMLFromModel(ObjModelConvocatoria_EstadoCnv)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelConvocatoria_EstadoCnv, idestadocnv)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvConvocatoria_EstadoCnvTable").addClass("ocultar");    
                    $("#dvConvocatoria_EstadoCnvDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateConvocatoria_EstadoCnv(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria_EstadoCnv)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos del Estado Guardados', false, 'success', '', 0);  
      RefreshDataTableConvocatoria_EstadoCnv();
      CerrarConvocatoria_EstadoCnvDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

