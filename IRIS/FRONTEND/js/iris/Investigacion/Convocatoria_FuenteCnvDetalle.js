var ObjModelConvocatoria_FuenteCnv= null;


$(document).ready(function () {

  ObjModelConvocatoria_FuenteCnv = new Convocatoria_FuenteCnv();

    if ($("#spanIdConvocatoria_FuenteCnv")[0].innerText == '') {
        CrearConvocatoria_FuenteCnvform();
    }
    else {
        EditarConvocatoria_FuenteCnvform($("#spanIdConvocatoria_FuenteCnv")[0].innerText);
    }

});

function CerrarConvocatoria_FuenteCnvDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelConvocatoria_FuenteCnv);
    
    $("#dvConvocatoria_FuenteCnvDetalle").addClass("ocultar");    
    $("#dvConvocatoria_FuenteCnvTable").removeClass("ocultar");

}

function CrearConvocatoria_FuenteCnvform() {

    CreateHTMLFromModel(ObjModelConvocatoria_FuenteCnv)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria_FuenteCnv)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_fuentecnv_Convocatoria_FuenteCnv").val('');                         
                    FinalizeLoader();
    
                    $("#dvConvocatoria_FuenteCnvTable").addClass("ocultar");    
                    $("#dvConvocatoria_FuenteCnvDetalle").removeClass("ocultar");            
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

function EditarConvocatoria_FuenteCnvform(idalcance) {

    CreateHTMLFromModel(ObjModelConvocatoria_FuenteCnv)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelConvocatoria_FuenteCnv, idalcance)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvConvocatoria_FuenteCnvTable").addClass("ocultar");    
                    $("#dvConvocatoria_FuenteCnvDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateConvocatoria_FuenteCnv(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria_FuenteCnv)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la fuente Guardados', false, 'success', '', 0);  
      RefreshDataTableConvocatoria_FuenteCnv();
      CerrarConvocatoria_FuenteCnvDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

