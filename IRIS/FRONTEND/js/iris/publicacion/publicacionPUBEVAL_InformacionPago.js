$(document).ready(function () {

    EditarPublicacionEvalInformacionPagoForm();

});

function VolverTablaPublicacionEvaluadoresDesdeInformacionPago() {    
    $("#dvPUBEVAL_EvaluadoresInformacionPago").addClass("ocultar");    
    $("#tablePublicacionEvaluadores").removeClass("ocultar");        
}

function EditarPublicacionEvalInformacionPagoForm() {
    $("#spanPublicacionEvalPagoIdPago")[0].innerText = '';
    let idevaluador = $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText;
    let idpublicacion = $("#spanIdPublicacion")[0].innerText;

    InicializaCamposPublicacionEvalInformacionPagoForm();

    removeValidationFormByForm('formPublicacionEvalInformacionPago');    
    
    let urlEditar = urlController + "Publicaciones_InformacionPago/GetPublicaciones_InformacionPagoByEvaluador?id_evaluadores=" + idevaluador;  
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;

            if (datos != null) {
                CargarCamposPublicacionEvalInformacionPagoForm(datos);
            }
        
            FinalizeLoader();

            $("#tablePublicacionEvaluadores").addClass("ocultar");    
            $("#dvPUBEVAL_EvaluadoresInformacionPago").removeClass("ocultar");    
        
            return;
        }
        else {
        
            FinalizeLoader();

            $("#tablePublicacionEvaluadores").addClass("ocultar");    
            $("#dvPUBEVAL_EvaluadoresInformacionPago").removeClass("ocultar");    
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
      } );       

}

function InicializaCamposPublicacionEvalInformacionPagoForm() {
    $('#txtPublicacionEvalPagoQuipu').val('');
    $('#txtPublicacionEvalPagoRag').val('');
    $('#txtPublicacionEvalPagoOrpa').val('');
    $('#txtPublicacionEvalPagoCpeg').val('');
    $('#dtPublicacionEvalfecpago').val(getFechaActual());
    $('#nmPublicacionEvalPagoValor').val('0');
    $('#nmPublicacionEvalPagoValor4Mil').val('0');    
}

function CargarCamposPublicacionEvalInformacionPagoForm(objdatos) {
    $('#txtPublicacionEvalPagoQuipu').val(objdatos.quipu);
    $('#txtPublicacionEvalPagoRag').val(objdatos.rag);
    $('#txtPublicacionEvalPagoOrpa').val(objdatos.orpa);
    $('#txtPublicacionEvalPagoCpeg').val(objdatos.cpeg);
    $('#dtPublicacionEvalfecpago').val(objdatos.fecpago.slice(0,10));
    $('#nmPublicacionEvalPagoValor').val(objdatos.valor);

    PublicacionEvaluacionTotalPago4xmil('nmPublicacionEvalPagoValor', 'nmPublicacionEvalPagoValor4Mil');
}

function ValidatePostUpdatePublicacionEvalInformacionPago(formF) {
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
                AddUpdatePublicacionEvalInformacionPago();
            }
        }
    }    
}

function AddUpdatePublicacionEvalInformacionPago() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicaciones_InformacionPago/UpdatePublicaciones_InformacionPago";    
    
    objData.id_informacionpago = ($("#spanPublicacionEvalPagoIdPago")[0].innerText == '') ? undefined : $("#spanPublicacionEvalPagoIdPago")[0].innerText;
    objData.id_evaluadores = $("#spanPUBEVAL_EvaluadoresIdEvaluador")[0].innerText;
    objData.id_crearpublicacion = $("#spanIdPublicacion")[0].innerText;
    objData.id_persona = $("#spanPUBEVAL_EvaluadoresIdPersona")[0].innerText;
    
    objData.quipu = $('#txtPublicacionEvalPagoQuipu').val();
    objData.rag = $('#txtPublicacionEvalPagoRag').val();
    objData.orpa = $('#txtPublicacionEvalPagoOrpa').val();
    objData.cpeg = $('#txtPublicacionEvalPagoCpeg').val();
    objData.fecpago = $('#dtPublicacionEvalfecpago').val();
    objData.valor = $('#nmPublicacionEvalPagoValor').val();
        
    if (objData.id_informacionpago == undefined) {
        urlUpdate = urlController + "Publicaciones_InformacionPago/InsertPublicaciones_InformacionPago";
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

            $("#dvPUBEVAL_EvaluadoresInformacionPago").addClass("ocultar");    
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
