var ObjModelproyectoextensionPEL_ModuloRUP = null;

$(document).ready(function () {

    ObjModelproyectoextensionPEL_ModuloRUP = new Actualizacion_ModuloRUP();

    EditarproyectoextensionPEL_ModuloRUPForm();
  
});

function EditarproyectoextensionPEL_ModuloRUPForm() {
      let idProyecto = $("#spanIdProyectoExtension")[0].innerText;

      CreateHTMLFromModel(ObjModelproyectoextensionPEL_ModuloRUP)
        .then(htmlcreado => {
            $('#txtid_asignacionproyecto_Proyecto_Actualizacion_ModuloRUP').val(idProyecto);            
            $('#txtid_actualizacionmodulor_Proyecto_Actualizacion_ModuloRUP').val('');

            LoadData_ToModel(ObjModelproyectoextensionPEL_ModuloRUP, idProyecto)
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
  
function ValidatePostUpdateproyectoextensionPEL_ModuloRUPForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelproyectoextensionPEL_ModuloRUP)
    .then(datosGuardados => {
        if ($('#txtid_actualizacionmodulor_Proyecto_Actualizacion_ModuloRUP').val() == '') {
            EditarproyectoextensionPEL_ModuloRUPForm();
        }
        
        FinalizeLoader();
        ShowModalDialog('Datos módulo RUP guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  