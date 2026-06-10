var ObjModelPublicaciones_DiagramacionCubierta = null;

$(document).ready(function () {

    ObjModelPublicaciones_DiagramacionCubierta = new Publicaciones_DiagramacionCubierta();
   
    EditarPublicaciones_DiagramacionCubiertaForm();
  
});

function EditarPublicaciones_DiagramacionCubiertaForm() {
      let idPublicacion = $("#spanIdPublicacion")[0].innerText;
//      $('#txtid_crearpublicacion_Publicaciones_DiagramacionCubierta').val(idPublicacion);
//      $('#txtid_diagramacion_Publicaciones_DiagramacionCubierta').val('');   
      
      StartLoader();   

      CreateHTMLFromModel(ObjModelPublicaciones_DiagramacionCubierta)
        .then(htmlcreado => {
            $('#txtid_crearpublicacion_Publicaciones_DiagramacionCubierta').val(idPublicacion);
            $('#txtnmdiagramacion_Publicaciones_DiagramacionCubierta').val('CUBIERTA');
            $('#txtid_diagramacion_Publicaciones_DiagramacionCubierta').val('');

            DatosConceptoEditorialResenaCubierta(idPublicacion)
            .then(resenacargada => {

                LoadData_ToModel(ObjModelPublicaciones_DiagramacionCubierta, idPublicacion, 'CUBIERTA')
                .then(datoscargados => {
                    if (datoscargados) { 
                        $('#txtresenacubierta_Publicaciones_DiagramacionCubierta').val(resenacargada);
                        FinalizeLoader();
                    }
                    else {
                        $('#txtresenacubierta_Publicaciones_DiagramacionCubierta').val(resenacargada);
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

        })
        .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
        })  
}
  
function ValidatePostUpdatePublicacionDiagramacionCubiertaForm(formF) {

    ValidatePostUpdateModel_EdicionForm(ObjModelPublicaciones_DiagramacionCubierta)
    .then(datosGuardados => {
        FinalizeLoader();
        ShowModalDialog('Datos diagramación de Cubierta guardados', false, 'success', '', 0);                    
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    })

}

  