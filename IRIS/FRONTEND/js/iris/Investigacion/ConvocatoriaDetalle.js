var ObjModelConvocatoria= null;


$(document).ready(function () {

  ObjModelConvocatoria = new Convocatoria();

    if ($("#spanIdConvocatoria")[0].innerText == '') {
        CrearConvocatoriaform();
    }
    else {
        EditarConvocatoriaform($("#spanIdConvocatoria")[0].innerText);
    }

});

function CerrarConvocatoriaDesdeEdicion() {
  DestruirCamposSelect_Model(ObjModelConvocatoria);
    
    $("#dvConvocatoriaDetalle").addClass("ocultar");    
    $("#dvConvocatoriaTable").removeClass("ocultar");

}

function CrearConvocatoriaform() {

    CreateHTMLFromModel(ObjModelConvocatoria)
        .then(htmlcreado => {
            NewData_ToModel(ObjModelConvocatoria)
            .then(datospreparados => {
                if (datospreparados) { 
                    $("#txtid_convocatoria_Convocatoria").val('');
                 //   $("#txtid_depend_Convocatoria").val(IdDependenciaUsuarioLogueado);                                       
                    FinalizeLoader();
    
                    $("#dvConvocatoriaTable").addClass("ocultar");    
                    $("#dvConvocatoriaDetalle").removeClass("ocultar");            
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

function ValidatePostUpdateConvocatoria(formF) {

  ValidatePostUpdateModel_EdicionForm(ObjModelConvocatoria)
  .then(datosGuardados => {
    if (datosGuardados) {
      FinalizeLoader();
      ShowModalDialog('Datos de la Convocatoria Guardados', false, 'success', '', 0);  
      RefreshDataTableConvocatoria();
      CerrarConvocatoriaDesdeEdicion();                        
    }
  })
  .catch(err => {
      FinalizeLoader();
      ShowModalDialog(err, false, 'error', '', 0);
  })

}

function EditarConvocatoriaform(idconvocatoria) {

    CreateHTMLFromModel(ObjModelConvocatoria)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelConvocatoria, idconvocatoria)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
    
                    $("#dvConvocatoriaTable").addClass("ocultar");    
                    $("#dvConvocatoriaDetalle").removeClass("ocultar"); 
                    RefreshDataTableConvocatoria();           
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
