var ObjModelPublicaciones_DivulgacionActividad = null;

$(document).ready(function () {

    ObjModelPublicaciones_DivulgacionActividad = new Publicaciones_DivulgacionActividad();
   
    EditarPublicaciones_DivulgacionActividadLanzamientoForm();
  
});

function EditarPublicaciones_DivulgacionActividadLanzamientoForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();         

      CreateHTMLFromModel(ObjModelPublicaciones_DivulgacionActividad)
      .then(htmlcreado => {
          $('#txtid_crearpublicacion_Publicaciones_DivulgacionActividad').val(idPublicacion);
          $('#txtid_actividad_Publicaciones_DivulgacionActividad').val('');
   
          LoadData_ToModel(ObjModelPublicaciones_DivulgacionActividad, idPublicacion)
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
  

function ValidatePostUpdatePublicacionDivulgacionMediosLanzamientoForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DivulgacionActividad)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos lanzamiento guardados', false, 'success', '', 0);
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

