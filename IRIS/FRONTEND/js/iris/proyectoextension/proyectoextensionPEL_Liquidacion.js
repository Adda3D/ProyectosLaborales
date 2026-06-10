var ObjModelproyectoextensionPEL_Liquidacion = null;

$(document).ready(function () {

    ObjModelproyectoextensionPEL_Liquidacion = new Liquidacion_Finalizacion();

    EditarproyectoextensionPEL_LiquidacionForm();
  
});

function EditarproyectoextensionPEL_LiquidacionForm() {
      let idProyecto = $("#spanIdProyectoExtension")[0].innerText;

      CreateHTMLFromModel(ObjModelproyectoextensionPEL_Liquidacion)
        .then(htmlcreado => {
            $('#txtid_asignacionproyecto_Proyecto_Liquidacion_Finalizacion').val(idProyecto);            
            $('#txtid_liqfinalizacion_Proyecto_Liquidacion_Finalizacion').val('');

            LoadData_ToModel(ObjModelproyectoextensionPEL_Liquidacion, idProyecto)
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
  
function ValidatePostUpdateproyectoextensionPEL_LiquidacionForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelproyectoextensionPEL_Liquidacion)
    .then(datosGuardados => {
        if ($('#txtid_liqfinalizacion_Proyecto_Liquidacion_Finalizacion').val() == '') {
            EditarproyectoextensionPEL_LiquidacionForm();
        }
        
        FinalizeLoader();
        ShowModalDialog('Datos liquidación proyecto guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  