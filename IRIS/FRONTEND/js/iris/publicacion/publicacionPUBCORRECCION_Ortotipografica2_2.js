var ObjModelPublicaciones_EstadoCorParam2_2 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam2_2 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam2_2Form();
  
});

function EditarPublicaciones_EstadoCorParam2_2Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam2_2.SufijoNombreControl = '2_2';
      ObjModelPublicaciones_EstadoCorParam2_2.FormEdicion = 'formPublicacionCorreccionOrtotipografica2_2';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam2_2)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam2_2').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam2_2').val('2_2');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam2_2').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam2_2, idPublicacion, '2_2')
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam2_2Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam2_2)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión editor guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  