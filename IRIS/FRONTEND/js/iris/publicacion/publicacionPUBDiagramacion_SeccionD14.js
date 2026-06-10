var ObjModelPublicacionesDiagramacionSeccionD14 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD14 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD14Form();
  
});

function EditarPublicacionesDiagramacionSeccionD14Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD14.SufijoNombreControl = 'D_14';
      ObjModelPublicacionesDiagramacionSeccionD14.FormEdicion = 'formPublicacionDiagramacionSeccionD14';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD14)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_14').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_14').val('D_14');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_14').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD14, idPublicacion, 'D_14')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD14Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD14)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión autores guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  