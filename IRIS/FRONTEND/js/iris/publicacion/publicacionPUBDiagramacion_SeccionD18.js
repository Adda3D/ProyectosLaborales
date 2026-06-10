var ObjModelPublicacionesDiagramacionSeccionD18 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD18 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD18Form();
  
});

function EditarPublicacionesDiagramacionSeccionD18Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD18.SufijoNombreControl = 'D_18';
      ObjModelPublicacionesDiagramacionSeccionD18.FormEdicion = 'formPublicacionDiagramacionSeccionD18';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD18)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_18').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_18').val('D_18');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_18').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD18, idPublicacion, 'D_18')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD18Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD18)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Inserción correcciones hechas por editor guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  