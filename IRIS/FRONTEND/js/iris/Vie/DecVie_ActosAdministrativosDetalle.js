$(document).ready(function () {

    if ($("#spanIdDecVie_ActosAdministrativos")[0].innerText == '') {
        CrearDecVie_ActosAdministrativosform();
    }
    else {
        EditarDecVie_ActosAdministrativosform($("#spanIdDecVie_ActosAdministrativos")[0].innerText);
    }

});

function CerrarDecVie_ActosAdministrativosDesdeEdicion() {
    DestruyeSelectDecVie_ActosAdministrativos();

    $("#dvDecVie_ActosAdministrativosDetalle").addClass("ocultar");    
    $("#dvDecVie_ActosAdministrativosTable").removeClass("ocultar");

}

function CrearDecVie_ActosAdministrativosform() {
    $("#spanIdDecVie_ActosAdministrativosForm")[0].innerText = '';
    
    CargarCombosDecVie_ActosAdministrativosDetalle();

    InicializaCamposDecVie_ActosAdministrativosDetalle()

    AddSelect2DivDecVie_ActosAdministrativosDetalle()    
    removeValidationFormByForm('formDecVie_ActosAdministrativosDetalle');

    $("#txtConsecutivoDecVie_ActosAdministrativos").prop( "disabled", false );

    $("#dvDecVie_ActosAdministrativosTable").addClass("ocultar");    
    $("#dvDecVie_ActosAdministrativosDetalle").removeClass("ocultar");            

}

function EditarDecVie_ActosAdministrativosform(idactoadministrativo) {
    $("#spanIdDecVie_ActosAdministrativosForm")[0].innerText = idactoadministrativo;

    CargarCombosDecVie_ActosAdministrativosDetalle()
    .then(()=>{

    

    removeValidationFormByForm('formDecVie_ActosAdministrativosDetalle');
    let urlEditarActoAdministrativo = urlController + "DecVie_ActosAdministrativos/GetDecVie_ActosAdministrativosDetails?id_actoadministrativo=" + idactoadministrativo;  
    StartLoader();

    fetch(urlEditarActoAdministrativo, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;
                
                CargarCamposDecVie_ActosAdministrativosDetalle(datos);
                FinalizeLoader();

            AddSelect2DivDecVie_ActosAdministrativosDetalle();
            $("#txtConsecutivoDecVie_ActosAdministrativos").prop( "disabled", true );
        

            $("#dvDecVie_ActosAdministrativosTable").addClass("ocultar");    
            $("#dvDecVie_ActosAdministrativosDetalle").removeClass("ocultar");            
        
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
    })
}


function CargarCombosDecVie_ActosAdministrativosDetalle() {
    let promises_arrDecVieActosAdmin = [];

    return new Promise((resolve, reject)=>{

        promises_arrDecVieActosAdmin.push(LoadDecVieTipoActoSelect('cboTipoDecVie_ActosAdministrativos', true));
        promises_arrDecVieActosAdmin.push(LoadDecVieTipologiaSelect('cboTipologiaDecVie_ActosAdministrativos', true));
        promises_arrDecVieActosAdmin.push(LoadMacroprocesoSelect('cboMacroprocesoDecVie_ActosAdministrativos', true));
        promises_arrDecVieActosAdmin.push(LoadDependenciaSelect('cboDependenciaSolicitanteDecVie_ActosAdministrativos', true));
        promises_arrDecVieActosAdmin.push(LoadPrestadorServicio('cboSolicitanteDecVie_ActosAdministrativos', true));
        promises_arrDecVieActosAdmin.push(LoadDependenciaSelect('cboDependenciafirmanteDecVie_ActosAdministrativos', true));    
        promises_arrDecVieActosAdmin.push(LoadDecVieEstadoActoAdministrativoSelect('cboEstadoDecVie_ActosAdministrativos', true));

        Promise.all(promises_arrDecVieActosAdmin)
        .then(selectcargado=>{
            if (selectcargado) {
                resolve (true);
            }
            else {
                resolve(false);
            }
        })
        .catch (err => {
            ShowModalDialog(err, false, 'error', '', 0); 
            reject(err); 
        })
    })
    
}

function InicializaCamposDecVie_ActosAdministrativosDetalle() {  
    $('#dtExpedicionDecVie_ActosAdministrativos').val(getFechaActual());
    $('#cboTipoDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#txtConsecutivoDecVie_ActosAdministrativos').val('');
    $('#txtConceptoDecVie_ActosAdministrativos').val('');
    $('#cboTipologiaDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#cboMacroprocesoDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#cboDependenciaSolicitanteDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#cboSolicitanteDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#cboDependenciafirmanteDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#txtBeneficiarioDecVie_ActosAdministrativos').val('');
    $('#txtidentificacionDecVie_ActosAdministrativos').val('');
    $('#cboEstadoDecVie_ActosAdministrativos').select2().val('').trigger("change");
    $('#txtDocumentoDecVie_ActosAdministrativos').val('');
         
}

function AddSelect2DivDecVie_ActosAdministrativosDetalle() {
    $('#cboTipoDecVie_ActosAdministrativos').select2();
    $('#cboTipologiaDecVie_ActosAdministrativos').select2();
    $('#cboMacroprocesoDecVie_ActosAdministrativos').select2();
    $('#cboDependenciaSolicitanteDecVie_ActosAdministrativos').select2();
    $('#cboSolicitanteDecVie_ActosAdministrativos').select2();
    $('#cboDependenciafirmanteDecVie_ActosAdministrativos').select2();   
    $('#cboEstadoDecVie_ActosAdministrativos').select2();
      
}

function DestruyeSelectDecVie_ActosAdministrativos() {
    if ($('#cboTipoDecVie_ActosAdministrativos').data('select2')) {
        $('#cboTipoDecVie_ActosAdministrativos').select2('destroy');        
      }    

    if ($('#cboTipologiaDecVie_ActosAdministrativos').data('select2')) {
        $('#cboTipologiaDecVie_ActosAdministrativos').select2('destroy');        
      }    

    if ($('#cboMacroprocesoDecVie_ActosAdministrativos').data('select2')) {
        $('#cboMacroprocesoDecVie_ActosAdministrativos').select2('destroy');        
      }    

    if ($('#cboDependenciaSolicitanteDecVie_ActosAdministrativos').data('select2')) {
        $('#cboDependenciaSolicitanteDecVie_ActosAdministrativos').select2('destroy');        
      }    

    if ($('#cboSolicitanteDecVie_ActosAdministrativos').data('select2')) {
        $('#cboSolicitanteDecVie_ActosAdministrativos').select2('destroy');        
      }    

    if ($('#cboDependenciafirmanteDecVie_ActosAdministrativos').data('select2')) {
        $('#cboDependenciafirmanteDecVie_ActosAdministrativos').select2('destroy');        
      }           

    if ($('#cboEstadoDecVie_ActosAdministrativos').data('select2')) {
        $('#cboEstadoDecVie_ActosAdministrativos').select2('destroy');        
      }         

}

function ValidatePostUpdateDecVie_ActosAdministrativos(formF) {
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
                if ($("#spanIdDecVie_ActosAdministrativosForm")[0].innerText == '') {
                    ExisteConsecutivoDecVie_ActosAdministrativos()
                        .then(existe => {
                            if (!existe) {                                    
                                AddUpdateDecVie_ActosAdministrativos();
                            }
                        })
                }
                else {
                    AddUpdateDecVie_ActosAdministrativos();
                }
                
            }
        }
    }    

}

function ExisteConsecutivoDecVie_ActosAdministrativos() {    
    let consecutivoactoadministrativo = $('#txtConsecutivoDecVie_ActosAdministrativos').val();   
    let urlValidar = urlController + "DecVie_ActosAdministrativos/GetDecVie_ActosAdministrativosConsecutivo?cd_consecutivoactoadministrativo=" + consecutivoactoadministrativo;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "Ya existe un Acto Administrativo registrado con el consecutivo " + consecutivoactoadministrativo;
                ShowModalDialog(message, false, 'warning', '', 0);
                return true;
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

function AddUpdateDecVie_ActosAdministrativos() {
    let objDecVie = new Object();    
    let urlUpdate = urlController + "DecVie_ActosAdministrativos/UpdateDecVie_ActosAdministrativos";
    StartLoader();
    
    objDecVie.id_actoadministrativo = ($("#spanIdDecVie_ActosAdministrativosForm")[0].innerText == '') ? undefined : $("#spanIdDecVie_ActosAdministrativosForm")[0].innerText;

    objDecVie.consecutivoactoadministrativo = $('#txtConsecutivoDecVie_ActosAdministrativos').val();
    objDecVie.fechaexpedicion = $("#dtExpedicionDecVie_ActosAdministrativos").val();
    objDecVie.id_tipoactoadministrativo = $("#cboTipoDecVie_ActosAdministrativos").val();
    objDecVie.conconceptoasunto = $('#txtConceptoDecVie_ActosAdministrativos').val();
    objDecVie.id_decvietipologia = $("#cboTipologiaDecVie_ActosAdministrativos").val();
    objDecVie.id_decviemacroproceso = $("#cboMacroprocesoDecVie_ActosAdministrativos").val();
    objDecVie.id_depend = $("#cboDependenciaSolicitanteDecVie_ActosAdministrativos").val();
    objDecVie.beneficiario = $("#txtBeneficiarioDecVie_ActosAdministrativos").val();
    objDecVie.dependenciafirma = $("#cboDependenciafirmanteDecVie_ActosAdministrativos").val();
    objDecVie.id_persona = $("#cboSolicitanteDecVie_ActosAdministrativos").val();
    objDecVie.id_estadoactoadministrativo = $("#cboEstadoDecVie_ActosAdministrativos").val();
    objDecVie.dependenciadocumento = $('#txtDocumentoDecVie_ActosAdministrativos').val();
    objDecVie.numidentificacion = $('#txtidentificacionDecVie_ActosAdministrativos').val();
  //  objDecVie.idregistrorup = ($("#cboRegistroRUPProyectoExtension").val() == '') ? undefined : $("#cboRegistroRUPProyectoExtension").val();
  //  objDecVie.idarchivoentrega = ($("#cboArchivoProyectoExtension").val() == '') ? undefined : $("#cboArchivoProyectoExtension").val();
                
    if (objDecVie.id_actoadministrativo == undefined) {
        urlUpdate = urlController + "DecVie_ActosAdministrativos/InsertDecVie_ActosAdministrativos";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objDecVie),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectDecVie_ActosAdministrativos();

            $("#dvDecVie_ActosAdministrativosDetalle").addClass("ocultar");    
            $("#dvDecVie_ActosAdministrativosTable").removeClass("ocultar");
        
            RefreshDataTableDecVie_ActosAdministrativos();
            return;                  
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);      
            /*
            DestruyeSelectDecVie_ActosAdministrativos();      

            $("#dvProyectoExtensionDetalle").addClass("ocultar");    
            $("#dvProyectoExtensionTable").removeClass("ocultar");
*/
            return;
        }            
      })
      .catch (err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
        /*
        DestruyeSelectDecVie_ActosAdministrativos();      

        $("#dvProyectoExtensionDetalle").addClass("ocultar");    
        $("#dvProyectoExtensionTable").removeClass("ocultar");
*/
      } );          
}

function CargarCamposDecVie_ActosAdministrativosDetalle(objdatos) {    
    $('#dtExpedicionDecVie_ActosAdministrativos').val(objdatos.fechaexpedicion.slice(0, 10));
    $('#cboTipoDecVie_ActosAdministrativos').select2().val(objdatos.id_tipoactoadministrativo).trigger("change");
    $('#txtConsecutivoDecVie_ActosAdministrativos').val(objdatos.consecutivoactoadministrativo);
    $('#txtConceptoDecVie_ActosAdministrativos').val(objdatos.conconceptoasunto);
    $('#cboTipologiaDecVie_ActosAdministrativos').select2().val(objdatos.id_decvietipologia).trigger("change");
    $('#cboMacroprocesoDecVie_ActosAdministrativos').select2().val(objdatos.id_decviemacroproceso).trigger("change");
    $('#cboDependenciaSolicitanteDecVie_ActosAdministrativos').select2().val(objdatos.id_depend).trigger("change");
    $('#cboSolicitanteDecVie_ActosAdministrativos').select2().val(objdatos.id_persona).trigger("change");
    $('#cboDependenciafirmanteDecVie_ActosAdministrativos').select2().val(objdatos.dependenciafirma).trigger("change");
    $('#txtBeneficiarioDecVie_ActosAdministrativos').val(objdatos.beneficiario);
    $('#txtidentificacionDecVie_ActosAdministrativos').val(objdatos.numidentificacion);
    $('#cboEstadoDecVie_ActosAdministrativos').select2().val(objdatos.id_estadoactoadministrativo).trigger("change");
    $('#txtDocumentoDecVie_ActosAdministrativos').val(objdatos.dependenciadocumento);    

}

