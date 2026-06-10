var ObjModelPublicacionesDiagramacionSeccionD16 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD16 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD16Form();
  
});

function EditarPublicacionesDiagramacionSeccionD16Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD16.SufijoNombreControl = 'D_16';
      ObjModelPublicacionesDiagramacionSeccionD16.FormEdicion = 'formPublicacionDiagramacionSeccionD16';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD16)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_16').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_16').val('D_16');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_16').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD16, idPublicacion, 'D_16')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD16Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD16)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Lectura final del editor guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  