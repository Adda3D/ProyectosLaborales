var ObjModelPublicacionCesionDerechos = null;

$(document).ready(function () {

    ObjModelPublicacionCesionDerechos = new Publicaciones_CesionDerechos();

    EditarPublicacionEdicionesCesionDerechosForm();
  
});

function VolverTablaPublicacionesDesdeCesionDerechos() {
    if ($('#cboPublicacionEditLicRepro').data('select2')) {
        $('#cboPublicacionEditLicRepro').select2('destroy');        
    }    

    $("#dvPublicacionCesionDerechos").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");    
}
  

function EditarPublicacionEdicionesCesionDerechosForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      $('#txtid_crearpublicacion_Publicaciones_CesionDerechos').val($("#spanIdPublicacion")[0].innerText);
      $('#txtid_cesionderechos_Publicaciones_CesionDerechos').val('');
      $("#spanPublicacionEdicionIdCesionDerechos")[0].innerText = '';
            
    LoadData_ToModel(ObjModelPublicacionCesionDerechos, idPublicacion)
        .then(datoscargados => {
            if (datoscargados) { 
                FinalizeLoader();
                $("#dvPublicacionesTable").addClass("ocultar");    
                $("#dvPublicacionCesionDerechos").removeClass("ocultar");    
            }
        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  

}
  
function ValidatePostUpdatePublicacionEdicionCesionDerechosForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionCesionDerechos)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Publicación cesión derechos, guardado', false, 'success', '', 0);                    
        VolverTablaPublicacionesDesdeCesionDerechos();
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  