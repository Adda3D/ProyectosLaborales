var ObjModelPublicaciones_Impresion = null;

$(document).ready(function () {

    ObjModelPublicaciones_Impresion = new Publicaciones_Impresion();
   
    EditarPublicaciones_ImpresionForm();
  
});

function EditarPublicaciones_ImpresionForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_Impresion)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_Impresion').val(idPublicacion);
            $('#txtid_impresion_Publicaciones_Impresion').val('');

            LoadData_ToModel(ObjModelPublicaciones_Impresion, idPublicacion)
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
  
function ValidatePostUpdatePublicacionDetalleImpresionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_Impresion)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos impresión guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  