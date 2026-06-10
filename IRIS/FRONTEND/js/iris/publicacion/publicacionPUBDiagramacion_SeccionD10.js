var ObjModelPublicacionesDiagramacionSeccionD10 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD10 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD10Form();
  
});

function EditarPublicacionesDiagramacionSeccionD10Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD10.SufijoNombreControl = 'D_10';
      ObjModelPublicacionesDiagramacionSeccionD10.FormEdicion = 'formPublicacionDiagramacionSeccionD10';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD10)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_10').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_10').val('D_10');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_10').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD10, idPublicacion, 'D_10')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD10Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD10)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Foliación de índices guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  