var ObjModelPublicaciones_Designacion = null;

$(document).ready(function () {

    ObjModelPublicaciones_Designacion = new Publicaciones_Designacion();
   
    EditarPublicaciones_DesignacionForm();
  
});

function EditarPublicaciones_DesignacionForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      //$('#txtid_crearpublicacion_Publicaciones_Designacion').val(idPublicacion);
      
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_Designacion)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_Designacion').val(idPublicacion);
            $('#txtid_designacion_Publicaciones_Designacion').val('');

            LoadData_ToModel(ObjModelPublicaciones_Designacion, idPublicacion)
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
  
function ValidatePostUpdatePublicacionDiagramacionDesignacionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_Designacion)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos designación diagramador guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  