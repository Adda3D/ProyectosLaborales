var ObjModelPublicaciones_EstadoCorParam2_1 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam2_1 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam2_1Form();
  
});

function EditarPublicaciones_EstadoCorParam2_1Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam2_1.SufijoNombreControl = '2_1';
      ObjModelPublicaciones_EstadoCorParam2_1.FormEdicion = 'formPublicacionCorreccionOrtotipografica2_1';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam2_1)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam2_1').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam2_1').val('2_1');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam2_1').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam2_1, idPublicacion, '2_1')
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam2_1Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam2_1)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos única lectura con aplicación de pauta guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  