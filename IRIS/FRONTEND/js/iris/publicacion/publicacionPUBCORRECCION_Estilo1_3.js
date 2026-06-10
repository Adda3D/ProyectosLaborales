var ObjModelPublicaciones_EstadoCorParam1_3 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam1_3 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam1_3Form();
  
});

function EditarPublicaciones_EstadoCorParam1_3Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam1_3.SufijoNombreControl = '1_3';
      ObjModelPublicaciones_EstadoCorParam1_3.FormEdicion = 'formPublicacionCorreccionEstilo1_3';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam1_3)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam1_3').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam1_3').val('1_3');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam1_3').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam1_3, idPublicacion, '1_3')
            .then(datoscargados => {
                if (datoscargados) { 
                    FinalizeLoader();
                   // $("#dvPublicacionesTable").addClass("ocultar");    
                   // $("#dvPublicacionCesionDerechos").removeClass("ocultar");    
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam1_3Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam1_3)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión primera corrección estilo (autor) guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  