var ObjModelPublicaciones_DiagramacionTaco = null;

$(document).ready(function () {

    ObjModelPublicaciones_DiagramacionTaco = new Publicaciones_DiagramacionTaco();
   
    EditarPublicaciones_DiagramacionTacoForm();
  
});

function EditarPublicaciones_DiagramacionTacoForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
            
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_DiagramacionTaco)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_DiagramacionTaco').val(idPublicacion);
            $('#txtnmdiagramacion_Publicaciones_DiagramacionTaco').val('TACO');
            $('#txtid_diagramacion_Publicaciones_DiagramacionTaco').val('');   
            
            LoadData_ToModel(ObjModelPublicaciones_DiagramacionTaco, idPublicacion, 'TACO')
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
  
function ValidatePostUpdatePublicacionDiagramacionTACOForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DiagramacionTaco)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos diagramación del taco guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}
  