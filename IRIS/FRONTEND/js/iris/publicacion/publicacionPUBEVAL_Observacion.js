$(document).ready(function () {

    EditarPublicacionEvaluacionObservacionesForm();

});

function EditarPublicacionEvaluacionObservacionesForm() {
    let idPublicacion = $("#spanIdPublicacion")[0].innerText;
    $("#spanPUBEVAL_ObservacionIdObservacion")[0].innerText = '';
    $('#txtPublicacionEvaluacionObservaciones').val('');    

    removeValidationFormByForm('formPublicacionEvaluacionObservaciones');    
    
    let urlEditaPublicacion = urlController + "Publicaciones_EvalObservaciones/GetPublicaciones_EvalObservacionesByPublicacion?id_crearpublicacion=" + idPublicacion;  
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
                $("#spanPUBEVAL_ObservacionIdObservacion")[0].innerText = datos.idevalobservacion;
                $('#txtPublicacionEvaluacionObservaciones').val(datos.observacion);
            }            
                              
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

}

function ValidatePostUpdatePublicacionEvaluacionObservaciones(formF) {
    validateTextXSSLastButtonByForm(formF);
  
    var formV = $("#" + formF);
    if (formV[0].checkValidity() == false) {
        $(formV).addClass('was-validated');
    } else {
        if (checkValidityXSS == false) {
            $(formV).addClass('was-validated');
        } else {
            if (checkValiditySelect == false) {
                $(formV).addClass('was-validated');
            } else {
                AddUpdatePublicacionEvaluacionObservaciones();
            }
        }
    }    
}

function AddUpdatePublicacionEvaluacionObservaciones() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EvalObservaciones/UpdatePublicaciones_EvalObservaciones"; 
    StartLoader();       
    
    objData.idevalobservacion = ($("#spanPUBEVAL_ObservacionIdObservacion")[0].innerText == '') ? undefined : $("#spanPUBEVAL_ObservacionIdObservacion")[0].innerText;
    objData.id_crearpublicacion = $("#spanIdPublicacion")[0].innerText;
    objData.observacion = $('#txtPublicacionEvaluacionObservaciones').val();
    
    if (objData.idevalobservacion == undefined) {
        urlUpdate = urlController + "Publicaciones_EvalObservaciones/InsertPublicaciones_EvalObservaciones";       
      }
  
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            ShowModalDialog('Observaciones Evaluación, guardadas', false, 'success', '', 0);                    
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