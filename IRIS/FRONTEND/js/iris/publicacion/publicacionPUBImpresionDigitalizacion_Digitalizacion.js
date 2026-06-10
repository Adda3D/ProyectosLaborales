var ObjModelPublicaciones_Digitalizacion = null;

$(document).ready(function () {

    ObjModelPublicaciones_Digitalizacion = new Publicaciones_Digitalizacion();
   
    EditarPublicaciones_DigitalizacionForm();
  
});

function EditarPublicaciones_DigitalizacionForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_Digitalizacion)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_Digitalizacion').val(idPublicacion);
            $('#txtid_digitalizacion_Publicaciones_Digitalizacion').val('');         
            
            LoadData_ToModel(ObjModelPublicaciones_Digitalizacion, idPublicacion)
            .then(datoscargados => {
                if (datoscargados) {                     
                    FinalizeLoader();
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
  
function ValidatePostUpdatePublicacionDetalleDigitalizacionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_Digitalizacion)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos digitalización guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  