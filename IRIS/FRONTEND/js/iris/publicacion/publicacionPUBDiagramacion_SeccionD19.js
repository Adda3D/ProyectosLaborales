var ObjModelPublicacionesDiagramacionSeccionD19 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD19 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD19Form();
  
});

function EditarPublicacionesDiagramacionSeccionD19Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD19.SufijoNombreControl = 'D_19';
      ObjModelPublicacionesDiagramacionSeccionD19.FormEdicion = 'formPublicacionDiagramacionSeccionD19';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD19)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_19').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_19').val('D_19');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_19').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD19, idPublicacion, 'D_19')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD19Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD19)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Inserción correcciones hechas por editor guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  