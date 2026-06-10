var ObjModelPublicacionesDiagramacionSeccionD8 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD8 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD8Form();
  
});

function EditarPublicacionesDiagramacionSeccionD8Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD8.SufijoNombreControl = 'D_8';
      ObjModelPublicacionesDiagramacionSeccionD8.FormEdicion = 'formPublicacionDiagramacionSeccionD8';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD8)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_8').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_8').val('D_8');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_8').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD8, idPublicacion, 'D_8')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD8Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD8)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión autores guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  