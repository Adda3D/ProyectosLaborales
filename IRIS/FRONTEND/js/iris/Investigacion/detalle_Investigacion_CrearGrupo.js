$(document).ready(function () {

    if ($("#spanIdGrupoInvestigacion")[0].innerText == '') {
        CrearGrupoInvestigacionform();
    }
    else {
        EditarInvestigacion_CrearGrupoform($("#spanIdGrupoInvestigacion")[0].innerText);
    }

});

function VolverTablaGrupoInvestigacionDesdeEdicion() {
    DestruyeSelectGrupoInvestigacion();
    
    $("#dvGrupoInvestigacionDetalle").addClass("ocultar");    
    $("#dvInvestigacion_CrearGrupoTable").removeClass("ocultar");

}

function CrearGrupoInvestigacionform() {
    debugger;
    $("#spanIdGrupoInvestigacionForm")[0].innerText = '';
    
    CargarCombosDetalleGrupoInvestigacion();

    InicializaCamposDetalleGrupoInvestigacion()

    AddSelect2DivDetalleGrupoInvestigacion()    
    removeValidationFormByForm('formGrupoInvestigacionDetalle');

    $("#txtcodigoHermesCrearGrupo").prop( "disabled", false );

    $("#dvInvestigacion_CrearGrupoTable").addClass("ocultar");    
    $("#dvGrupoInvestigacionDetalle").removeClass("ocultar");            

}

function EditarInvestigacion_CrearGrupoform(IdGrupoInvestigacion) {       
    $("#spanIdGrupoInvestigacionForm")[0].innerText = IdGrupoInvestigacion;

    CargarCombosDetalleGrupoInvestigacion()
    .then(()=>{

    

    removeValidationFormByForm('formGrupoInvestigacionDetalle');

    let urlEditar = urlController + "Investigacion_CrearGrupo/GetInvestigacion_CrearGrupoDetails?id_creargrupo=" + IdGrupoInvestigacion;  
    StartLoader();

    fetch(urlEditar, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;
                
                CargarCamposGrupoInvestigacion(datos);
                FinalizeLoader();

            AddSelect2DivDetalleGrupoInvestigacion();
            $("#txtcodigoHermesCrearGrupo").prop( "disabled", true );            
        

            $("#dvInvestigacion_CrearGrupoTable").addClass("ocultar");    
            $("#dvGrupoInvestigacionDetalle").removeClass("ocultar");            
        
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


function CargarCombosDetalleGrupoInvestigacion() {
    let promises_arrDetGrupoInv = [];
    return new Promise((resolve, reject)=>{

        promises_arrDetGrupoInv.push(LoadAreaAcademicaSelect('cboAreaCrearGrupo', true));
        promises_arrDetGrupoInv.push(LoadPrestadorServicio('cboNombreLiderCrearGrupo', true));
        promises_arrDetGrupoInv.push(LoadFuncionarioSelect('cboCoordinadorCrearGrupo', true));        

        Promise.all(promises_arrDetGrupoInv)
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

function InicializaCamposDetalleGrupoInvestigacion() {
    $('#txtcodigoHermesCrearGrupo').val('');
    $('#txtMincienciasCrearGrupo').val('');
    $('#txtfortalecimientoCrearGrupo').val('');
    $('#cboAreaCrearGrupo').select2().val('').trigger("change");
    $('#txtClasificacionCrearGrupo').val('');
    $('#txtTemaGeneralCrearGrupo').val('');
    $('#nmNumLineaCrearGrupo').val('0');
    $('#chkActualizadoGrupo').prop('checked', false);    
    $('#txtNombreGrupoCrearGrupo').val('');
    $('#txtAbreviaturaCrearGrupo').val('');
    $('#nmPublicacionesUnijusCrearGrupo').val('0');
    $('#nmPoductosEntregadosCrearGrupo').val('0');
    $('#dtCreacionMincienciasCrearGrupo').val('');
    $('#cboNombreLiderCrearGrupo').select2().val('').trigger("change");
    $('#cboCoordinadorCrearGrupo').select2().val('').trigger("change");
    $('#txtCorreoCrearGrupo').val('');
    $('#txtCorreoAlternoCrearGrupo').val('');
    $('#txtlinkHermesCrearGrupo').val('');
    $('#txtlinkMincienciasCrearGrupo').val('');
    
}

function AddSelect2DivDetalleGrupoInvestigacion() {
    $('#cboAreaCrearGrupo').select2();
    $('#cboNombreLiderCrearGrupo').select2();
    $('#cboCoordinadorCrearGrupo').select2();
}

function DestruyeSelectGrupoInvestigacion() {
    if ($('#cboAreaCrearGrupo').data('select2')) {
        $('#cboAreaCrearGrupo').select2('destroy');        
      }    

    if ($('#cboNombreLiderCrearGrupo').data('select2')) {
        $('#cboNombreLiderCrearGrupo').select2('destroy');        
      }    

    if ($('#cboCoordinadorCrearGrupo').data('select2')) {
        $('#cboCoordinadorCrearGrupo').select2('destroy');        
      }    

}

function ValidatePostUpdateGrupoInvestigacion(formF) {
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
                if ($("#spanIdGrupoInvestigacionForm")[0].innerText == '') {
                    ExisteCodigoHermesGrupoInvestigacion()
                        .then(existe => {
                            if (!existe) {                                                            
                                AddUpdateGrupoInvestigacion();
                            }
                        })
                }
                else {
                    AddUpdateGrupoInvestigacion();
                }
                
            }
        }
    }    

}

function ExisteCodigoHermesGrupoInvestigacion() {    
    let codigohermes = $('#txtcodigoHermesCrearGrupo').val();   
    let urlValidar = urlController + "Investigacion_CrearGrupo/GetInvestigacion_CrearGrupoCodigo?cd_codigohermes=" + codigohermes;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "Ya existe un grupo registrado con el Id Hermes " + codigohermes;
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

function AddUpdateGrupoInvestigacion() {    
    let objGrupoInvestigacion = new Object();    
    let urlUpdate = urlController + "Investigacion_CrearGrupo/UpdateInvestigacion_CrearGrupo";
    StartLoader();
    
    objGrupoInvestigacion.id_creargrupo = ($("#spanIdGrupoInvestigacionForm")[0].innerText == '') ? undefined : $("#spanIdGrupoInvestigacionForm")[0].innerText;

    objGrupoInvestigacion.id_areaacad = $('#cboAreaCrearGrupo').val();
    objGrupoInvestigacion.id_persona = $('#cboNombreLiderCrearGrupo').val();
    objGrupoInvestigacion.minciencias = $('#txtMincienciasCrearGrupo').val();
    objGrupoInvestigacion.codigohermes = $("#txtcodigoHermesCrearGrupo").val();
    objGrupoInvestigacion.nombregrupo = $('#txtNombreGrupoCrearGrupo').val();
    objGrupoInvestigacion.abreviatura = $('#txtAbreviaturaCrearGrupo').val();
    objGrupoInvestigacion.hermesfortalecimiento = $('#txtfortalecimientoCrearGrupo').val();
    objGrupoInvestigacion.creacionminciencias = $('#dtCreacionMincienciasCrearGrupo').val();
    objGrupoInvestigacion.temageninvetigacion = $('#txtTemaGeneralCrearGrupo').val();
    objGrupoInvestigacion.actualizado = false;

    if ($('#chkActualizadoGrupo').is(':checked')) {
        objGrupoInvestigacion.actualizado = true;
    }
    
    objGrupoInvestigacion.clasificacionactual = $('#txtClasificacionCrearGrupo').val();
    objGrupoInvestigacion.linkhermes = $('#txtlinkHermesCrearGrupo').val();
    objGrupoInvestigacion.linkcolciencias = $('#txtlinkMincienciasCrearGrupo').val();
    objGrupoInvestigacion.idfuncionario = $('#cboCoordinadorCrearGrupo').val();
    objGrupoInvestigacion.correogrupo = $('#txtCorreoCrearGrupo').val();
    objGrupoInvestigacion.correoalternativo = $('#txtCorreoAlternoCrearGrupo').val();    
                
    if (objGrupoInvestigacion.id_creargrupo == undefined) {
        urlUpdate = urlController + "Investigacion_CrearGrupo/InsertInvestigacion_CrearGrupo";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objGrupoInvestigacion),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectGrupoInvestigacion();

            $("#dvGrupoInvestigacionDetalle").addClass("ocultar");    
            $("#dvInvestigacion_CrearGrupoTable").removeClass("ocultar");
        
            RefreshDataTableInvestigacion_CrearGrupo();
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

function CargarCamposGrupoInvestigacion(objGrupoInvestigacion) {   
    debugger; 

    $('#cboAreaCrearGrupo').select2().val(objGrupoInvestigacion.id_areaacad).trigger("change");
    $('#cboNombreLiderCrearGrupo').select2().val(objGrupoInvestigacion.id_persona).trigger("change");
    $('#txtMincienciasCrearGrupo').val(objGrupoInvestigacion.minciencias);
    $("#txtcodigoHermesCrearGrupo").val(objGrupoInvestigacion.codigohermes);
    $('#txtNombreGrupoCrearGrupo').val(objGrupoInvestigacion.nombregrupo);
    $('#txtAbreviaturaCrearGrupo').val(objGrupoInvestigacion.abreviatura);
    $('#txtfortalecimientoCrearGrupo').val(objGrupoInvestigacion.hermesfortalecimiento);

    if (objGrupoInvestigacion.creacionminciencias != null) {
        $('#dtCreacionMincienciasCrearGrupo').val(objGrupoInvestigacion.creacionminciencias.slice(0, 10));
    }
   
    $('#txtTemaGeneralCrearGrupo').val(objGrupoInvestigacion.temageninvetigacion);
    $('#chkActualizadoGrupo').prop('checked', objGrupoInvestigacion.actualizado);
    //$('#chkActualizadoGrupo').prop('checked', false);

    //if (objGrupoInvestigacion.actualizado == true) {
      //  $('#chkActualizadoGrupo').prop('checked', true)
    //}    
    $('#txtClasificacionCrearGrupo').val(objGrupoInvestigacion.clasificacionactual);
    $('#txtlinkHermesCrearGrupo').val(objGrupoInvestigacion.linkhermes);
    $('#txtlinkMincienciasCrearGrupo').val(objGrupoInvestigacion.linkcolciencias);

    if (objGrupoInvestigacion.idfuncionario != null) {
        $('#cboCoordinadorCrearGrupo').select2().val(objGrupoInvestigacion.idfuncionario).trigger("change");
    }
    
    $('#txtCorreoCrearGrupo').val(objGrupoInvestigacion.correogrupo);
    $('#txtCorreoAlternoCrearGrupo').val(objGrupoInvestigacion.correoalternativo);


}