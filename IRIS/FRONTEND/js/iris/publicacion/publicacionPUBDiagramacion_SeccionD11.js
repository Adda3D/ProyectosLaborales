var ObjModelPublicacionesDiagramacionSeccionD11 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD11 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD11Form();
  
});

function EditarPublicacionesDiagramacionSeccionD11Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD11.SufijoNombreControl = 'D_11';
      ObjModelPublicacionesDiagramacionSeccionD11.FormEdicion = 'formPublicacionDiagramacionSeccionD11';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD11)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_11').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_11').val('D_11');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_11').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD11, idPublicacion, 'D_11')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD11Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD11)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Remisión de información datos código QR guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  