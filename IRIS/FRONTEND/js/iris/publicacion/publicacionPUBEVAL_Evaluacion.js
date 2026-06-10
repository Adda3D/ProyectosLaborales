$(document).ready(function () {

    EditarPublicacionEvaluacionInicialForm();

});

function EditarPublicacionEvaluacionInicialForm() {
    let idPublicacion = $("#spanIdPublicacion")[0].innerText;

    if ($('#cboPublicacionEvaluacionInicial').data('select2')) {
        $('#cboPublicacionEvaluacionInicial').select2('destroy');        
      }    
    
    LoadPublicacionEvaluacionInicialSelect('cboPublicacionEvaluacionInicial', true)
    .then(EstadoCargado => {
      $('#cboPublicacionEvaluacionInicial').select2().val('').trigger("change");

      removeValidationFormByForm('formPublicacionEvaluacionInicial');    
      
      let urlEditaPublicacion = urlController + "Publicaciones_CrearPublicacion/GetPublicaciones_CrearPublicacionEvaluacionInicial?id_crearpublicacion=" + idPublicacion;  
      StartLoader();
  
      fetch(urlEditaPublicacion, {
          method: 'GET',
          headers: { 'Authorization': 'Bearer ' + TokenIRIS }
      })
      .then(response => response.json())
        .then(data => {
          if (data.Ok) {                      
              let datos = data.Data;
  
              if (datos != null) {
                  $('#cboPublicacionEvaluacionInicial').select2().val(datos).trigger("change");
              }
  
              $('#cboPublicacionEvaluacionInicial').select2();
                                
              FinalizeLoader();
  
              return;
          }
          else {
              ShowModalDialog(data.Message, false, 'warning', '', 0);
              FinalizeLoader();
              return;
          }            
        })
        .catch (err => {
          FinalizeLoader();
          ShowModalDialog(err, false, 'error', '', 0);
        } );       
    })
    

}

function ValidatePostUpdatePublicacionInicial() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_CrearPublicacion/UpdatePublicaciones_CrearPublicacionEvaluacion"; 
    StartLoader();   
    
    objData.id_crearpublicacion = $("#spanIdPublicacion")[0].innerText;
    objData.id_evaluacioninicial = $('#cboPublicacionEvaluacionInicial').val();
    debugger;

    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            ShowModalDialog('Resultado evaluación inicial, guardado', false, 'success', '', 0);                    
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );       

    
}