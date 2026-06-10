var ObjModelPublicacionesDiagramacionSeccionC6 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionC6 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionC6Form();
  
});

function EditarPublicacionesDiagramacionSeccionC6Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionC6.SufijoNombreControl = 'C_6';
      ObjModelPublicacionesDiagramacionSeccionC6.FormEdicion = 'formPublicacionDiagramacionSeccionC6';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionC6)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamC_6').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamC_6').val('C_6');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamC_6').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionC6, idPublicacion, 'C_6')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionC6Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionC6)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Lectura en maqueta guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  