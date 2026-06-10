var ObjModelPublicacionesDiagramacionSeccionD2 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD2 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD2Form();
  
});

function EditarPublicacionesDiagramacionSeccionD2Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD2.SufijoNombreControl = 'D_2';
      ObjModelPublicacionesDiagramacionSeccionD2.FormEdicion = 'formPublicacionDiagramacionSeccionD2';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD2)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_2').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_2').val('D_2');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_2').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD2, idPublicacion, 'D_2')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD2Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD2)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Diseño o ajuste de maqueta guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  