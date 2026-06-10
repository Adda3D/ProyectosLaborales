var ObjModelPublicaciones_EstadoCorParam1_1 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam1_1 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam1_1Form();
  
});

function EditarPublicaciones_EstadoCorParam1_1Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam1_1.SufijoNombreControl = '1_1';
      ObjModelPublicaciones_EstadoCorParam1_1.FormEdicion = 'formPublicacionCorreccionEstilo1_1';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam1_1)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam1_1').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam1_1').val('1_1');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam1_1').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam1_1, idPublicacion, '1_1')
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam1_1Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam1_1)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Primera corrección de estilo guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  