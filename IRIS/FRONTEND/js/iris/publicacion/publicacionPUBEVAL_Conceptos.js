$(document).ready(function () {

    EditarPublicacionRealizacionConceptoform();

});

function VolverTablaPublicacionEvaluadoresDesdeRealizarConcepto() {
    DestruyeSelectPublicacionRealizaConceptos();

    $("#dvPUBEVAL_EvaluadoresRealizacionConcepto").addClass("ocultar");    
    $("#tablePublicacionEvaluadores").removeClass("ocultar");    
    
}

function EditarPublicacionRealizacionConceptoform() {    
    $("#spanIdEvalConceptoFormRealizaConcepto")[0].innerText = '';
    let idevaluador = $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText;
    

    CargarCombosPublicacionRealizaConceptos();

    InicializaCamposPublicacionRealizaConceptos();

    removeValidationFormByForm('formPublicacionRealizacionConceptos');    
    
    let urlEditaPublicacion = urlController + "Publicaciones_EvalConcepto/GetPublicaciones_EvalConceptoByEvaluador?id_evaluadores=" + idevaluador;  
    StartLoader();

    fetch(urlEditaPublicacion, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;
            CargarCamposPublicacionRealizaConceptos(datos);

            AddSelect2DivPublicacionRealizaConceptos();            
        
            FinalizeLoader();

            $("#tablePublicacionEvaluadores").addClass("ocultar");    
            $("#dvPUBEVAL_EvaluadoresRealizacionConcepto").removeClass("ocultar");    
        
            return;
        }
        else {
            AddSelect2DivPublicacionRealizaConceptos();            
        
            FinalizeLoader();

            $("#tablePublicacionEvaluadores").addClass("ocultar");    
            $("#dvPUBEVAL_EvaluadoresRealizacionConcepto").removeClass("ocultar");    
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );       

}

function CargarCombosPublicacionRealizaConceptos() {
    LoadPublicacionConceptoNroEvaluacionSelect('cboPublicacionConceptoNumero', false);
    LoadPublicacionConceptoEstadoSelect('cboPublicacionConceptoEstado', true);
    LoadPublicacionConceptoFinalSelect('cboPublicacionConceptoFinal', true);    
}

function InicializaCamposPublicacionRealizaConceptos() {
    $('#cboPublicacionConceptoNumero').select2().val('').trigger("change");
    $('#cboPublicacionConceptoFinal').select2().val('').trigger("change");
    $('#cboPublicacionConceptoEstado').select2().val('').trigger("change");
    $('#dtfecPublicacionConceptoAceptado').val('');
    $('#dtfecPublicacionConceptoFinaliza').val('');
    $('#dtfecPublicacionConceptoEntrega').val('');
    $('#txtPublicacionConceptoEnlace').val('');
    
}

function DestruyeSelectPublicacionRealizaConceptos() {
    if ($('#cboPublicacionConceptoNumero').data('select2')) {
        $('#cboPublicacionConceptoNumero').select2('destroy');        
      }    

    if ($('#cboPublicacionConceptoFinal').data('select2')) {
        $('#cboPublicacionConceptoFinal').select2('destroy');        
      }    

    if ($('#cboPublicacionConceptoEstado').data('select2')) {
        $('#cboPublicacionConceptoEstado').select2('destroy');        
      }    

}

function CargarCamposPublicacionRealizaConceptos(objdatos) {
    $("#spanIdEvalConceptoFormRealizaConcepto")[0].innerText = objdatos.id_evalconcepto;

    $('#cboPublicacionConceptoNumero').select2().val(objdatos.id_evalgenerada).trigger("change");

    if (objdatos.id_concepto != null) {
        $('#cboPublicacionConceptoFinal').select2().val(objdatos.id_concepto).trigger("change");
    }
    
    if (objdatos.id_estadoconcepto != null) {
        $('#cboPublicacionConceptoEstado').select2().val(objdatos.id_estadoconcepto).trigger("change");
    }
    
    if (objdatos.fecaceptado != null) {
        $('#dtfecPublicacionConceptoAceptado').val(objdatos.fecaceptado.slice(0, 10));    
    }

    if (objdatos.fecinicial != null) {
        $('#dtfecPublicacionConceptoFinaliza').val(objdatos.fecinicial.slice(0, 10));    
    }

    if (objdatos.fecentrega != null) {
        $('#dtfecPublicacionConceptoEntrega').val(objdatos.fecentrega.slice(0, 10));    
    }

    $('#txtPublicacionConceptoEnlace').val(objdatos.linkdocumento); 
        
}

function AddSelect2DivPublicacionRealizaConceptos() {
    $('#cboPublicacionConceptoNumero').select2();    
    $('#cboPublicacionConceptoEstado').select2();    
    $('#cboPublicacionConceptoFinal').select2();        
}

function ValidatePostUpdatePublicacionEvaluacionConcepto(formF) {
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
                ExisteConceptoParaEvaluador()
                    .then(existe => {
                        if (!existe) {                                    
                            AddUpdatePublicacionEvaluacionCreaConcepto();
                        }
                    })                                 
            }
        }
    }    
}

function ExisteConceptoParaEvaluador() {
    let idpersona = $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText;
    let idpublicacion = $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText
    let nroevaluacion = $('#cboPublicacionConceptoNumero').val();
    
    let urlValidar = urlController + "Publicaciones_EvalConcepto/GetPublicaciones_EvalConceptoByPublicacionEvaluacion?id_crearpublicacion=" + idpublicacion + "&id_evalgenerada=" + nroevaluacion;

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {

                if (data.Data.id_persona == idpersona) {
                    return false;
                }
                else {
                    let message = "Evaluación se encuentra asignada a otro evaluador.";
                    ShowModalDialog(message, false, 'warning', '', 0);
                    return true;    
                }
            }
            else {
                return false;
            }            
          })
          .then( resultado => {
            return resolve(resultado);
          }) 
          .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0);
            reject(err);
          } );
      }); 
}

function AddUpdatePublicacionEvaluacionCreaConcepto() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_EvalConcepto/UpdatePublicaciones_EvalConcepto";    
    
    objData.id_evalconcepto = ($("#spanIdEvalConceptoFormRealizaConcepto")[0].innerText == '') ? undefined : $("#spanIdEvalConceptoFormRealizaConcepto")[0].innerText;
    objData.id_evaluadores = ($("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText == '') ? undefined : $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText;
    objData.id_crearpublicacion = $("#spanPUBEVAL_EvaluadoresIdPublicacion")[0].innerText;
    objData.id_persona = $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText;
    
    objData.id_evalgenerada = $('#cboPublicacionConceptoNumero').val();
    objData.id_concepto = $('#cboPublicacionConceptoFinal').val();
    objData.id_estadoconcepto = $('#cboPublicacionConceptoEstado').val();    
    objData.fecaceptado = $('#dtfecPublicacionConceptoAceptado').val();    
    objData.fecinicial = $('#dtfecPublicacionConceptoFinaliza').val();
    objData.fecentrega = $('#dtfecPublicacionConceptoEntrega').val();    
    objData.linkdocumento =$('#txtPublicacionConceptoEnlace').val();
        
    if (objData.id_evalconcepto == undefined) {
        urlUpdate = urlController + "Publicaciones_EvalConcepto/InsertPublicaciones_EvalConcepto";
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
                        
            DestruyeSelectPublicacionRealizaConceptos();

            $("#dvPUBEVAL_EvaluadoresRealizacionConcepto").addClass("ocultar");    
            $("#tablePublicacionEvaluadores").removeClass("ocultar");    
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

