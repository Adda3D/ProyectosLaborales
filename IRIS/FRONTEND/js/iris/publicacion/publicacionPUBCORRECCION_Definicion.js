var ObjModelPublicaciones_TipoCorreccion = null;

$(document).ready(function () {

    ObjModelPublicaciones_TipoCorreccion = new Publicaciones_TipoCorreccion();
   
    EditarPublicaciones_TipoCorreccionForm();
  
});

function EditarPublicaciones_TipoCorreccionForm() {
    debugger;
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      $('#txtid_crearpublicacion_Publicaciones_TipoCorreccion').val($("#spanIdPublicacion")[0].innerText);
      $('#txtid_tipocorreccion_Publicaciones_TipoCorreccion').val('');      

      CreateHTMLFromModel(ObjModelPublicaciones_TipoCorreccion)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicaciones_TipoCorreccion, idPublicacion)
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
                   // $("#dvPublicacionesTable").addClass("ocultar");    
                   // $("#dvPublicacionCesionDerechos").removeClass("ocultar");    
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
  
function ValidatePostUpdatePublicacionCorreccionDefinicionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_TipoCorreccion)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos definición corrección guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  