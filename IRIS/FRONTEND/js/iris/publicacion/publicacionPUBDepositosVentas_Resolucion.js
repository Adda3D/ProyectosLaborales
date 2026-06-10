var ObjModelPublicaciones_DepositoResolucion = null;

$(document).ready(function () {

    ObjModelPublicaciones_DepositoResolucion = new Publicaciones_DepositoResolucion();
   
    EditarPublicaciones_DepositoResolucionForm();
  
});

function EditarPublicaciones_DepositoResolucionForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_DepositoResolucion)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_DepositoResolucion').val(idPublicacion);
            $('#txtid_resolucion_Publicaciones_DepositoResolucion').val('');
     
            LoadData_ToModel(ObjModelPublicaciones_DepositoResolucion, idPublicacion)
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
  
function ValidatePostUpdatePublicacionResolucionDistribucionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoResolucion)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos resolución distribución guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  