var ObjModelPublicacionesDiagramacionSeccionD7 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD7 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD7Form();
  
});

function EditarPublicacionesDiagramacionSeccionD7Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD7.SufijoNombreControl = 'D_7';
      ObjModelPublicacionesDiagramacionSeccionD7.FormEdicion = 'formPublicacionDiagramacionSeccionD7';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD7)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_7').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_7').val('D_7');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_7').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD7, idPublicacion, 'D_7')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD7Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD7)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Inserción de correcciónes editor guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  