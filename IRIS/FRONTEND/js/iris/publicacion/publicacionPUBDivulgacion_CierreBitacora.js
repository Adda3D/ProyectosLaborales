var ObjModelPublicacionDivulgacionCierreBitacora = null;

$(document).ready(function () {
debugger;
    ObjModelPublicacionDivulgacionCierreBitacora = new Publicaciones_DivulgacionCierre();
   
    EditarPublicacionDivulgacionCierreBitacoraForm();
  
});

function EditarPublicacionDivulgacionCierreBitacoraForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
      StartLoader();   
      debugger;

      CreateHTMLFromModel(ObjModelPublicacionDivulgacionCierreBitacora)
      .then(htmlcreado => {
          $('#txtid_crearpublicacion_Publicaciones_DivulgacionCierre').val(idPublicacion);
          $('#txtid_cierre_Publicaciones_DivulgacionCierre').val('');
   
          LoadData_ToModel(ObjModelPublicacionDivulgacionCierreBitacora, idPublicacion)
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
  

function ValidatePostUpdatePublicacionDivulgacionCierreBitacoraForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicacionDivulgacionCierreBitacora)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos cierre guardados', false, 'success', '', 0);
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

