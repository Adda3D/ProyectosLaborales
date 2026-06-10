var ObjModelPublicaciones_DivulgacionPlan = null;

$(document).ready(function () {
debugger;
    ObjModelPublicaciones_DivulgacionPlanDatos = new Publicaciones_DivulgacionPlan();
   
    EditarPublicaciones_DivulgacionPlanDatosForm();
  
});

function EditarPublicaciones_DivulgacionPlanDatosForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   
      debugger;

      CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionPlanDatos)
      .then(htmlcreado => {
          $('#txtid_crearpublicacion_Publicaciones_DivulgacionPlan').val(idPublicacion);
          $('#txtid_plan_Publicaciones_DivulgacionPlan').val('');
   
          LoadData_ToModel(ObjModelPublicaciones_DivulgacionPlanDatos, idPublicacion)
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
  

function ValidatePostUpdatePublicacionDivulgacionPlanDatosForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionPlanDatos)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos plan guardados', false, 'success', '', 0);
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

