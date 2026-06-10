var ObjModelPublicacionesDiagramacionSeccionD13 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD13 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD13Form();
  
});

function EditarPublicacionesDiagramacionSeccionD13Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD13.SufijoNombreControl = 'D_13';
      ObjModelPublicacionesDiagramacionSeccionD13.FormEdicion = 'formPublicacionDiagramacionSeccionD13';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD13)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_13').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_13').val('D_13');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_13').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD13, idPublicacion, 'D_13')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD13Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD13)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Solicitud código ISBN guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  