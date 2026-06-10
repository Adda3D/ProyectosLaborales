var ObjModelPublicacionesDiagramacionSeccionD9 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD9 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD9Form();
  
});

function EditarPublicacionesDiagramacionSeccionD9Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD9.SufijoNombreControl = 'D_9';
      ObjModelPublicacionesDiagramacionSeccionD9.FormEdicion = 'formPublicacionDiagramacionSeccionD9';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD9)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_9').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_9').val('D_9');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_9').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD9, idPublicacion, 'D_9')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD9Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD9)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Inserción de correcciones autor + editor guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  