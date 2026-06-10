var ObjModelPublicaciones_DepositoPrecios = null;

$(document).ready(function () {

    ObjModelPublicaciones_DepositoPrecios = new Publicaciones_DepositoPrecios();
   
    EditarPublicaciones_DepositoPreciosForm();
  
});

function EditarPublicaciones_DepositoPreciosForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_DepositoPrecios)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_DepositoPrecios').val(idPublicacion);
            $('#txtid_precios_Publicaciones_DepositoPrecios').val('');
     
            LoadData_ToModel(ObjModelPublicaciones_DepositoPrecios, idPublicacion)
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
  
function ValidatePostUpdatePublicacionPreciosDistribucionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DepositoPrecios)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos resolución distribución guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  