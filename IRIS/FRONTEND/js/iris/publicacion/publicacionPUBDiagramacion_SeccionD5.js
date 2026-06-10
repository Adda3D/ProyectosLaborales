var ObjModelPublicacionesDiagramacionSeccionD5 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD5 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD5Form();
  
});

function EditarPublicacionesDiagramacionSeccionD5Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD5.SufijoNombreControl = 'D_5';
      ObjModelPublicacionesDiagramacionSeccionD5.FormEdicion = 'formPublicacionDiagramacionSeccionD5';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD5)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_5').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_5').val('D_5');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_5').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD5, idPublicacion, 'D_5')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD5Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD5)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Diseño carátula guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  