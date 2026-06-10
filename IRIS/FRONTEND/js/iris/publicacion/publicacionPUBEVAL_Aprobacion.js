$(document).ready(function () {

  EditarPublicacionEvaluacionAprobacionForm();

});

function CargarCombosPublicacionEvaluacionAprobacionForm() {
  return new Promise( (resolve, reject) => {

  if ($('#cboPublicacionEvaluacionFinal').data('select2')) {
    $('#cboPublicacionEvaluacionFinal').select2('destroy');        
  }    

  if ($('#cboPublicacionEvaltipopublicacion').data('select2')) {
    $('#cboPublicacionEvaltipopublicacion').select2('destroy');        
  }    

  LoadPublicacionEvaluacionInicialSelect('cboPublicacionEvaluacionFinal', true)
  .then(EvaluacionInicialLoad => {
    LoadPublicacionAprobacionTipoPublicacionSelect('cboPublicacionEvaltipopublicacion', true)
    .then(AprobacionLoad => {
      $('#cboPublicacionEvaluacionFinal').select2().val('').trigger("change");
      $('#cboPublicacionEvaltipopublicacion').select2().val('').trigger("change");

    })
  
    return resolve(true)
  })
  .catch(err=>{
    reject(err)
  })
  })
}

function InicializarCamposPublicacionEvaluacionAprobacionForm() {
  return new Promise( (resolve, reject) => {

  $('#cboPublicacionEvaluacionFinal').select2().val('').trigger("change");
  $('#txtPublicacionactaprocomifacultad').val('');
  $('#dtPublicacionfechaactaprocomifacultad').val('');
  $('#txtPublicacionnombreactaprocomifacultad').val('');
  $('#cboPublicacionEvaltipopublicacion').select2().val('').trigger("change");
  $('#nmPublicaciontirajetotal').val('0');
  $('#txtPublicacionactaproconsfacultad').val('');
  $('#dtPublicacionfechaactaproconsfacultad').val('');
  $('#txtPublicacionnombreactaproconsfacultad').val('');
  $('#txtPublicaciongestorevalunijus').val('');
    return resolve(true)
    .catch(err=>{
      reject(err)
    })
  })
}

function CargarCamposPublicacionEvaluacionAprobacionForm(objdatos) {
  $("#spanPUBEVAL_AprobacionIdEvaluacion")[0].innerText = objdatos.id_evaluaciones;

  $('#cboPublicacionEvaluacionFinal').select2().val(objdatos.id_evaluacioninicial).trigger("change");
  $('#txtPublicacionactaprocomifacultad').val(objdatos.actaprocomifacultad);

  if (objdatos.fechaactaprocomifacultad) {
    $('#dtPublicacionfechaactaprocomifacultad').val(objdatos.fechaactaprocomifacultad.slice(0,10));
  }
  
  $('#txtPublicacionnombreactaprocomifacultad').val(objdatos.nombreactaprocomifacultad);

  if (objdatos.tipopublicacion != null) {
    $('#cboPublicacionEvaltipopublicacion').select2().val(objdatos.tipopublicacion).trigger("change");
  }
  
  $('#nmPublicaciontirajetotal').val(objdatos.tirajetotal);
  $('#txtPublicacionactaproconsfacultad').val(objdatos.actaproconsfacultad);

  if (objdatos.fechaactaproconsfacultad) {
    $('#dtPublicacionfechaactaproconsfacultad').val(objdatos.fechaactaproconsfacultad.slice(0,10));
  }

  $('#txtPublicacionnombreactaproconsfacultad').val(objdatos.nombreactaproconsfacultad);
  $('#txtPublicaciongestorevalunijus').val(objdatos.gestorevalunijus);

}

function AddSElectDivPublicacionEvaluacionAprobacionForm() {
  $('#cboPublicacionEvaluacionFinal').select2();
  $('#cboPublicacionEvaltipopublicacion').select2()  
}

function EditarPublicacionEvaluacionAprobacionForm() {
    let idPublicacion = $("#spanIdPublicacion")[0].innerText;
    $("#spanPUBEVAL_AprobacionIdEvaluacion")[0].innerText = '';
    
    CargarCombosPublicacionEvaluacionAprobacionForm()
    .then(camposCargados=>{

      InicializarCamposPublicacionEvaluacionAprobacionForm()
      .then(camposInicializados => {

        removeValidationFormByForm('formPublicacionEvaluacionAprobacion');    
        
        let urlEditar = urlController + "Publicaciones_Evaluaciones/GetPublicaciones_EvaluacionesByPublicacion?id_crearpublicacion=" + idPublicacion;  
        StartLoader();
    
        fetch(urlEditar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {                      
                let datos = data.Data;
    
                CargarCamposPublicacionEvaluacionAprobacionForm(datos);
                AddSElectDivPublicacionEvaluacionAprobacionForm();
                                  
                FinalizeLoader();
    
                return;
            }
            else {
                AddSElectDivPublicacionEvaluacionAprobacionForm();            
                FinalizeLoader();
                return;
            }            
          })
          .catch (err => {
            FinalizeLoader();
            ShowModalDialog(err, false, 'error', '', 0);
          } );       
      })
  
    })


}

function ValidatePostUpdatePublicacionEvaluacionAprobacion(formF) {
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
            AddUpdatePublicacionEvaluacionAprobacion();
          }
      }
  }    
}

function AddUpdatePublicacionEvaluacionAprobacion() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_Evaluaciones/UpdatePublicaciones_Evaluaciones"; 
    StartLoader();   

    objData.id_evaluaciones = ($("#spanPUBEVAL_AprobacionIdEvaluacion")[0].innerText == '') ? undefined : $("#spanPUBEVAL_AprobacionIdEvaluacion")[0].innerText;

    objData.id_crearpublicacion = $("#spanIdPublicacion")[0].innerText;;
    objData.id_evaluacioninicial = $('#cboPublicacionEvaluacionFinal').val();
    objData.actaprocomifacultad = $('#txtPublicacionactaprocomifacultad').val();
    objData.fechaactaprocomifacultad = $('#dtPublicacionfechaactaprocomifacultad').val();    
    objData.nombreactaprocomifacultad = $('#txtPublicacionnombreactaprocomifacultad').val();  
    objData.tipopublicacion = $('#cboPublicacionEvaltipopublicacion').val();    
    objData.tirajetotal = $('#nmPublicaciontirajetotal').val();
    objData.actaproconsfacultad = $('#txtPublicacionactaproconsfacultad').val();
    objData.fechaactaproconsfacultad = $('#dtPublicacionfechaactaproconsfacultad').val();
    objData.nombreactaproconsfacultad = $('#txtPublicacionnombreactaproconsfacultad').val();
    objData.gestorevalunijus = $('#txtPublicaciongestorevalunijus').val();
    
    if (objData.id_evaluaciones == undefined) {
      urlUpdate = urlController + "Publicaciones_Evaluaciones/InsertPublicaciones_Evaluaciones";       
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
            ShowModalDialog('Resultado evaluación aprobación, guardado', false, 'success', '', 0);                    
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