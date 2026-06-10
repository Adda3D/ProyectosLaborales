var ObjModelPublicacionesDiagramacionSeccionD6 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD6 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD6Form();
  
});

function EditarPublicacionesDiagramacionSeccionD6Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD6.SufijoNombreControl = 'D_6';
      ObjModelPublicacionesDiagramacionSeccionD6.FormEdicion = 'formPublicacionDiagramacionSeccionD6';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD6)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_6').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_6').val('D_6');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_6').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD6, idPublicacion, 'D_6')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD6Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD6)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión de primeras artes guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  