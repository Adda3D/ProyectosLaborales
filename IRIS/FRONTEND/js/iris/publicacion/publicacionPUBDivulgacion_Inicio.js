var ObjModelPublicaciones_DivulgacionInicio = null;

$(document).ready(function () {
debugger;
    ObjModelPublicaciones_DivulgacionInicio = new Publicaciones_DivulgacionInicio();
   
    EditarPublicaciones_DivulgacionInicioForm();
  
});

function EditarPublicaciones_DivulgacionInicioForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   
      debugger;

      CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionInicio)
      .then(htmlcreado => {
          $('#txtid_crearpublicacion_Publicaciones_DivulgacionInicio').val(idPublicacion);
          $('#txtiddivulgacioninicio_Publicaciones_DivulgacionInicio').val('');
   
          LoadData_ToModel(ObjModelPublicaciones_DivulgacionInicio, idPublicacion)
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
  

function ValidatePostUpdatePublicacionDivulgacionInicioForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionInicio)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos inicio guardados', false, 'success', '', 0);
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

