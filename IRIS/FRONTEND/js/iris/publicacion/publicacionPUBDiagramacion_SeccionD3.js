var ObjModelPublicacionesDiagramacionSeccionD3 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD3 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD3Form();
  
});

function EditarPublicacionesDiagramacionSeccionD3Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD3.SufijoNombreControl = 'D_3';
      ObjModelPublicacionesDiagramacionSeccionD3.FormEdicion = 'formPublicacionDiagramacionSeccionD3';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD3)
        .then(htmlcreado => {
            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD3, idPublicacion, 'D_3')
            .then(datoscargados => {
                $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_3').val(idPublicacion);
                $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_3').val('D_3');
                $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_3').val('');
    
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD3Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD3)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Diagramación TACO guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  