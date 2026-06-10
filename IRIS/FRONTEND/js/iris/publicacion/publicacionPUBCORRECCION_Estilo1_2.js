var ObjModelPublicaciones_EstadoCorParam1_2 = null;

$(document).ready(function () {

    ObjModelPublicaciones_EstadoCorParam1_2 = new Publicaciones_EstadoCorParam();

    EditarPublicaciones_EstadoCorParam1_2Form();
  
});

function EditarPublicaciones_EstadoCorParam1_2Form() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      ObjModelPublicaciones_EstadoCorParam1_2.SufijoNombreControl = '1_2';
      ObjModelPublicaciones_EstadoCorParam1_2.FormEdicion = 'formPublicacionCorreccionEstilo1_2';

      CreateHTMLFromModel(ObjModelPublicaciones_EstadoCorParam1_2)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_EstadoCorParam1_2').val(idPublicacion);
            $('#txtcorreccionetapa_Publicaciones_EstadoCorParam1_2').val('1_2');
            $('#txtid_estadocorparam_Publicaciones_EstadoCorParam1_2').val('');

            LoadData_ToModel(ObjModelPublicaciones_EstadoCorParam1_2, idPublicacion, '1_2')
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
  
function ValidatePostUpdatePublicaciones_EstadoCorParam1_2Form(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_EstadoCorParam1_2)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos Revisión primera corrección estilo guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  