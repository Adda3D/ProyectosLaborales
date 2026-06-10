var ObjModelPublicacionesDiagramacionSeccionD4 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD4 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD4Form();
  
});

function EditarPublicacionesDiagramacionSeccionD4Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD4.SufijoNombreControl = 'D_4';
      ObjModelPublicacionesDiagramacionSeccionD4.FormEdicion = 'formPublicacionDiagramacionSeccionD4';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD4)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_4').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_4').val('D_4');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_4').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD4, idPublicacion, 'D_4')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD4Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD4)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión editorial de diagramación guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  