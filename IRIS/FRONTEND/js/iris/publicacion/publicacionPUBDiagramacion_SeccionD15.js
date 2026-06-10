var ObjModelPublicacionesDiagramacionSeccionD15 = null;

$(document).ready(function () {

    ObjModelPublicacionesDiagramacionSeccionD15 = new Publicaciones_EstadoCorParam();

    EditarPublicacionesDiagramacionSeccionD15Form();
  
});

function EditarPublicacionesDiagramacionSeccionD15Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicacionesDiagramacionSeccionD15.SufijoNombreControl = 'D_15';
      ObjModelPublicacionesDiagramacionSeccionD15.FormEdicion = 'formPublicacionDiagramacionSeccionD15';

      CreateHTMLFromModel(ObjModelPublicacionesDiagramacionSeccionD15)
        .then(htmlcreado => {            
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParamD_15').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParamD_15').val('D_15');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParamD_15').val('');

            LoadData_ToModel(ObjModelPublicacionesDiagramacionSeccionD15, idPublicacion, 'D_15')
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
  
function ValidatePostUpdatePublicacionesDiagramacionSeccionD15Form(formF) {
debugger;
    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionesDiagramacionSeccionD15)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Inserción de ISBN y Ficha catalográfica guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  