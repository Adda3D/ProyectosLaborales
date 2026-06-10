var ObjModelPublicaciones_EstadoCorParam1_4 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam1_4 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam1_4Form();
  
});

function EditarPublicaciones_EstadoCorParam1_4Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam1_4.SufijoNombreControl = '1_4';
      ObjModelPublicaciones_EstadoCorParam1_4.FormEdicion = 'formPublicacionCorreccionEstilo1_4';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam1_4)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam1_4').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam1_4').val('1_4');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam1_4').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam1_4, idPublicacion, '1_4')
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam1_4Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam1_4)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión de comentarios del autor. (inserción de cambios) (corrector) guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  