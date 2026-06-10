var ObjModelPublicacionesDiagramacionSeccionD12 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD12 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD12Form();
  
});

function EditarPublicacionesDiagramacionSeccionD12Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD12.SufijoNombreControl = 'D_12';
      ObjModelPublicacionesDiagramacionSeccionD12.FormEdicion = 'formPublicacionDiagramacionSeccionD12';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD12)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_12').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_12').val('D_12');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_12').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD12, idPublicacion, 'D_12')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD12Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD12)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Creación e inserción código QR guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  