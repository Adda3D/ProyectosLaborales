var ObjModelPublicaciones_EstadoCorParam1_5 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam1_5 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam1_5Form();
  
});

function EditarPublicaciones_EstadoCorParam1_5Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam1_5.SufijoNombreControl = '1_5';
      ObjModelPublicaciones_EstadoCorParam1_5.FormEdicion = 'formPublicacionCorreccionEstilo1_5';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam1_5)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam1_5').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam1_5').val('1_5');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam1_5').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam1_5, idPublicacion, '1_5')
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam1_5Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam1_5)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Primera corrección de estilo guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  