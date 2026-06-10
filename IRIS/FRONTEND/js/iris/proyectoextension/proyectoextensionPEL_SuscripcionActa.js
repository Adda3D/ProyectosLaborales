var ObjModelproyectoextensionPEL_SuscripcionActa = null;

$(document).ready(function () {

    ObjModelproyectoextensionPEL_SuscripcionActa = new Suscripcion_Liquidacion();

    EditarproyectoextensionPEL_SuscripcionActaForm();
  
});

function EditarproyectoextensionPEL_SuscripcionActaForm() {
      let idProyecto = $("#spanIdProyectoExtension")[0].innerText;

      CreateHTMLFromModel(ObjModelproyectoextensionPEL_SuscripcionActa)
        .then(htmlcreado => {
            $('#txtid_asignacionproyecto_Proyecto_Suscripcion_Liquidacion').val(idProyecto);            
            $('#txtid_suscripcionliquidcion_Proyecto_Suscripcion_Liquidacion').val('');

            LoadData_ToModel(ObjModelproyectoextensionPEL_SuscripcionActa, idProyecto)
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
  
function ValidatePostUpdateproyectoextensionPEL_SuscripcionActaForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelproyectoextensionPEL_SuscripcionActa)
    .then(datosGuardados => {
        if ($('#txtid_suscripcionliquidcion_Proyecto_Suscripcion_Liquidacion').val() == '') {
            EditarproyectoextensionPEL_SuscripcionActaForm();
        }
        
        FinalizeLoader();
        ShowModalDialog('Datos acta liquidación proyecto guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  