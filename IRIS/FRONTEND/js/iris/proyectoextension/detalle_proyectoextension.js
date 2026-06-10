$(document).ready(function () {

    if ($("#spanIdProyectoExtension")[0].innerText == '') {
        CrearProyectoExtensionform();
    }
    else {
        EditarProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText);
    }

});

function VolverTablaProyectoExtensionsDesdeEdicion() {
    DestruyeSelectProyectoExtension();

    $("#dvProyectoExtensionDetalle").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function CrearProyectoExtensionform() {
    $("#spanIdProyectoExtensionForm")[0].innerText = '';
    
    CargarCombosDetalleProyectoExtension();

    InicializaCamposDetalleProyectoExtension()

    AddSelect2DivDetalleProyectoExtension()    
    removeValidationFormByForm('formProyectoExtensionDetalle');

    $("#txtConsecutivoProyectoExtension").prop( "disabled", false );

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionDetalle").removeClass("ocultar");            

}

function EditarProyectoExtensionform(idProyectoExtension) {
    $("#spanIdProyectoExtensionForm")[0].innerText = idProyectoExtension;

    CargarCombosDetalleProyectoExtension()
    .then(()=>{

        removeValidationFormByForm('formProyectoExtensionDetalle');
        let urlEditaProyecto = urlController + "Proyectos_AsignacionProyecto/GetProyectos_AsignacionProyectoDetails?id_asignacionproyecto=" + idProyectoExtension;  
        StartLoader();
    
        fetch(urlEditaProyecto, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {                      
                let datos = data.Data;
    
                CargarCamposProyectoExtension(datos);
    
                AddSelect2DivDetalleProyectoExtension();
                $("#txtConsecutivoProyectoExtension").prop( "disabled", true );
            
                FinalizeLoader();
    
                $("#dvProyectoExtensionTable").addClass("ocultar");    
                $("#dvProyectoExtensionDetalle").removeClass("ocultar");            
            
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


function CargarCombosDetalleProyectoExtension() {
    let promises_arrDetExt = [];
    return new Promise((resolve, reject)=>{

        promises_arrDetExt.push(LoadPropuestaTipoPropuesta('cboTipoProyectoExtension', false));
        promises_arrDetExt.push(LoadNaturalezaProyecto('cboNaturalezaProyectoExtension', false));
        promises_arrDetExt.push(LoadPropuestaContratante('cboEntidadProyectoExtension', false));
        promises_arrDetExt.push(LoadFuncionarioSelect('cboDirectorProyectoExtension', false));
        promises_arrDetExt.push(LoadFuncionarioSelect('cboSupervisorProyectoExtension', false));
        promises_arrDetExt.push(LoadFuncionarioSelect('cboAsistenteProyectoExtension', false));
        promises_arrDetExt.push(LoadAlcanceProyecto('cboAlcanceProyectoExtension', false));
        promises_arrDetExt.push(LoadAreaAcademicaSelect('cboAreaAcadProyectoExtension', true));
        promises_arrDetExt.push(LoadEstadoContrato('cboEstadoContratoProyectoExtension', false));
        promises_arrDetExt.push(LoadRegistroRUP('cboRegistroRUPProyectoExtension', true));
        promises_arrDetExt.push(LoadEntregaArchivo('cboArchivoProyectoExtension', true));

        Promise.all(promises_arrDetExt)
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

function InicializaCamposDetalleProyectoExtension() {    
    $('#txtConsecutivoProyectoExtension').val('');
    $('#dtAnnioSuscripcionProyectoExtension').val(getFechaActual());
    $('#cboTipoProyectoExtension').select2().val('').trigger("change");
    $('#cboNaturalezaProyectoExtension').select2().val('').trigger("change");
    $('#cboEntidadProyectoExtension').select2().val('').trigger("change");
    $('#txtNombreProyectoExtension').val('');
    $('#txtPoblObjetivoProyectoExtension').val('');
    $('#cboDirectorProyectoExtension').select2().val('').trigger("change");
    $('#cboSupervisorProyectoExtension').select2().val('').trigger("change");
    $('#cboAsistenteProyectoExtension').select2().val('').trigger("change");
    $('#txtContratoProyectoExtension').val('');
    $('#dtFInicioProyectoExtension').val(getFechaActual());
    $('#dtFFinalizaProyectoExtension').val(getFechaActual());
    $('#txtQuipuProyectoExtension').val('');
    $('#txtHermesProyectoExtension').val('');
    $('#txtObjetoContratoProyectoExtension').val('');
    $('#cboAlcanceProyectoExtension').select2().val('').trigger("change");
    $('#nmValorIniProyectoExtension').val('0');
    $('#nmAdicDismProyectoExtension').val('0');
    $('#nmContrapartidaProyectoExtension').val('0');
    $('#cboAreaAcadProyectoExtension').select2().val('').trigger("change");
    $('#nmEstDerechoProyectoExtension').val('0');
    $('#nmEstCienciaPolProyectoExtension').val('0');
    $('#nmEstPosgradoProyectoExtension').val('0');
    $('#txtNumeroSarProyectoExtension').val('');
    $('#txtNumeroODSProyectoExtension').val('');
    $('#cboEstadoContratoProyectoExtension').select2().val('').trigger("change");
    $('#cboRegistroRUPProyectoExtension').select2().val('').trigger("change");
    $('#cboArchivoProyectoExtension').select2().val('').trigger("change"); 
    $('#txtcontratoconvenioenlaceProyectoExtension').val('');
    $('#txtentregaarchivoenlaceProyectoExtension').val('');      
}

function AddSelect2DivDetalleProyectoExtension() {
    $('#cboTipoProyectoExtension').select2();
    $('#cboNaturalezaProyectoExtension').select2();
    $('#cboEntidadProyectoExtension').select2();
    $('#cboDirectorProyectoExtension').select2();
    $('#cboSupervisorProyectoExtension').select2();
    $('#cboAsistenteProyectoExtension').select2();
    $('#cboAlcanceProyectoExtension').select2();
    $('#cboAreaAcadProyectoExtension').select2();
    $('#cboEstadoContratoProyectoExtension').select2();
    $('#cboRegistroRUPProyectoExtension').select2();
    $('#cboArchivoProyectoExtension').select2();    
}

function DestruyeSelectProyectoExtension() {
    if ($('#cboTipoProyectoExtension').data('select2')) {
        $('#cboTipoProyectoExtension').select2('destroy');        
      }    

    if ($('#cboNaturalezaProyectoExtension').data('select2')) {
        $('#cboNaturalezaProyectoExtension').select2('destroy');        
      }    

    if ($('#cboEntidadProyectoExtension').data('select2')) {
        $('#cboEntidadProyectoExtension').select2('destroy');        
      }    

    if ($('#cboDirectorProyectoExtension').data('select2')) {
        $('#cboDirectorProyectoExtension').select2('destroy');        
      }    

    if ($('#cboSupervisorProyectoExtension').data('select2')) {
        $('#cboSupervisorProyectoExtension').select2('destroy');        
      }    

    if ($('#cboAsistenteProyectoExtension').data('select2')) {
        $('#cboAsistenteProyectoExtension').select2('destroy');        
      }    

    if ($('#cboAlcanceProyectoExtension').data('select2')) {
        $('#cboAlcanceProyectoExtension').select2('destroy');        
      }    

    if ($('#cboAreaAcadProyectoExtension').data('select2')) {
        $('#cboAreaAcadProyectoExtension').select2('destroy');        
      }    

    if ($('#cboEstadoContratoProyectoExtension').data('select2')) {
        $('#cboEstadoContratoProyectoExtension').select2('destroy');        
      }    

    if ($('#cboRegistroRUPProyectoExtension').data('select2')) {
        $('#cboRegistroRUPProyectoExtension').select2('destroy');        
      }    

    if ($('#cboArchivoProyectoExtension').data('select2')) {
        $('#cboArchivoProyectoExtension').select2('destroy');        
      }    

}

function ValidatePostUpdateProyectoExtension(formF) {
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
                if ($("#spanIdProyectoExtensionForm")[0].innerText == '') {
                    ExisteConsecutivoProyectoExtension()
                        .then(existe => {
                            if (!existe) {                                    
                                AddUpdateProyectoExtension();
                            }
                        })
                }
                else {
                    AddUpdateProyectoExtension();
                }
                
            }
        }
    }    

}

function ExisteConsecutivoProyectoExtension() {    
    let consecutivoproyecto = $('#txtConsecutivoProyectoExtension').val();   
    let urlValidar = urlController + "Proyectos_AsignacionProyecto/GetProyectos_AsignacionProyectoConsecutivo?consecutivo=" + consecutivoproyecto;    

    return new Promise( (resolve, reject) => {
        fetch(urlValidar, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {
                let message = "Ya existe un proyecto registrado con el consecutivo " + consecutivoproyecto;
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

function AddUpdateProyectoExtension() {
    let objProyectoExtension = new Object();    
    let urlUpdate = urlController + "Proyectos_AsignacionProyecto/UpdateProyectos_AsignacionProyecto";
    StartLoader();
    
    objProyectoExtension.id_asignacionproyecto = ($("#spanIdProyectoExtensionForm")[0].innerText == '') ? undefined : $("#spanIdProyectoExtensionForm")[0].innerText;

    objProyectoExtension.id_propuesta =$('#txtid_propuesta_ProyectoExtension').val();
    objProyectoExtension.consecutivo = $('#txtConsecutivoProyectoExtension').val();
    objProyectoExtension.yearsuscripcion = $("#dtAnnioSuscripcionProyectoExtension").val();
    objProyectoExtension.id_tipopropuesta = $("#cboTipoProyectoExtension").val();
    objProyectoExtension.id_naturalezaproyecto = $("#cboNaturalezaProyectoExtension").val();
    objProyectoExtension.idpropuesta_entidad = $("#cboEntidadProyectoExtension").val();
    objProyectoExtension.nombreproyecto = $("#txtNombreProyectoExtension").val();
    objProyectoExtension.poblacionobjetivo = $("#txtPoblObjetivoProyectoExtension").val();
    objProyectoExtension.iddirector = $("#cboDirectorProyectoExtension").val();
    objProyectoExtension.idsupervisor = $("#cboSupervisorProyectoExtension").val();
    objProyectoExtension.idasistente = $("#cboAsistenteProyectoExtension").val();
    objProyectoExtension.numcontratoconvenio = $("#txtContratoProyectoExtension").val();
    objProyectoExtension.fecacuerdovoluntades = $("#dtFInicioProyectoExtension").val();
    objProyectoExtension.fecterminacion = $("#dtFFinalizaProyectoExtension").val();
    objProyectoExtension.fichaquipu = $("#txtQuipuProyectoExtension").val();
    objProyectoExtension.codigohermes = $("#txtHermesProyectoExtension").val();
    objProyectoExtension.objetocontratoactividad = $("#txtObjetoContratoProyectoExtension").val();
    objProyectoExtension.id_alcanceproyecto = $("#cboAlcanceProyectoExtension").val();
    objProyectoExtension.valinicialaporteentidad = $("#nmValorIniProyectoExtension").val();
    objProyectoExtension.adiciondisminucion = $("#nmAdicDismProyectoExtension").val();
    objProyectoExtension.contrapartida = $("#nmContrapartidaProyectoExtension").val();
    objProyectoExtension.id_areaacad = $("#cboAreaAcadProyectoExtension").val();
    objProyectoExtension.nestudiantesderecho = $("#nmEstDerechoProyectoExtension").val();
    objProyectoExtension.nestudiantespolitica = $("#nmEstCienciaPolProyectoExtension").val();
    objProyectoExtension.nestudiantespostgrados = $("#nmEstPosgradoProyectoExtension").val();
    objProyectoExtension.numerosar = $("#txtNumeroSarProyectoExtension").val();
    objProyectoExtension.numeroodsops = $("#txtNumeroODSProyectoExtension").val();
    objProyectoExtension.id_estadocontrato = $("#cboEstadoContratoProyectoExtension").val();
    objProyectoExtension.idregistrorup = ($("#cboRegistroRUPProyectoExtension").val() == '') ? undefined : $("#cboRegistroRUPProyectoExtension").val();
    objProyectoExtension.idarchivoentrega = ($("#cboArchivoProyectoExtension").val() == '') ? undefined : $("#cboArchivoProyectoExtension").val();
    objProyectoExtension.contratoconvenioenlace = $('#txtcontratoconvenioenlaceProyectoExtension').val();
    objProyectoExtension.entregaarchivoenlace = $('#txtentregaarchivoenlaceProyectoExtension').val();      
                
    if (objProyectoExtension.id_asignacionproyecto == undefined) {
        urlUpdate = urlController + "Proyectos_AsignacionProyecto/InsertProyectos_AsignacionProyecto";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objProyectoExtension),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectProyectoExtension();

            $("#dvProyectoExtensionDetalle").addClass("ocultar");    
            $("#dvProyectoExtensionTable").removeClass("ocultar");
        
            RefreshDataTableProyectoExtension();
            return;                  
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);      
            /*
            DestruyeSelectProyectoExtension();      

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
        DestruyeSelectProyectoExtension();      

        $("#dvProyectoExtensionDetalle").addClass("ocultar");    
        $("#dvProyectoExtensionTable").removeClass("ocultar");
*/
      } );          
}

function CargarCamposProyectoExtension(objdatos) {    
    $('#txtid_propuesta_ProyectoExtension').val(objdatos.id_propuesta);
    $('#txtConsecutivoProyectoExtension').val(objdatos.consecutivo);
    $('#dtAnnioSuscripcionProyectoExtension').val(objdatos.yearsuscripcion.slice(0, 10));
    $('#cboTipoProyectoExtension').select2().val(objdatos.id_tipopropuesta).trigger("change");
    $('#cboNaturalezaProyectoExtension').select2().val(objdatos.id_naturalezaproyecto).trigger("change");
    $('#cboEntidadProyectoExtension').select2().val(objdatos.idpropuesta_entidad).trigger("change");
    $('#txtNombreProyectoExtension').val(objdatos.nombreproyecto);
    $('#txtPoblObjetivoProyectoExtension').val(objdatos.poblacionobjetivo);
    $('#cboDirectorProyectoExtension').select2().val(objdatos.iddirector).trigger("change");
    $('#cboSupervisorProyectoExtension').select2().val(objdatos.idsupervisor).trigger("change");
    $('#cboAsistenteProyectoExtension').select2().val(objdatos.idasistente).trigger("change");
    $('#txtContratoProyectoExtension').val(objdatos.numcontratoconvenio);
    $('#dtFInicioProyectoExtension').val(objdatos.fecacuerdovoluntades.slice(0, 10));
    $('#dtFFinalizaProyectoExtension').val(objdatos.fecterminacion.slice(0, 10));
    $('#txtQuipuProyectoExtension').val(objdatos.fichaquipu);
    $('#txtHermesProyectoExtension').val(objdatos.codigohermes);
    $('#txtObjetoContratoProyectoExtension').val(objdatos.objetocontratoactividad);
    $('#cboAlcanceProyectoExtension').select2().val(objdatos.id_alcanceproyecto).trigger("change");
    $('#nmValorIniProyectoExtension').val(objdatos.valinicialaporteentidad);
    $('#nmAdicDismProyectoExtension').val(objdatos.adiciondisminucion);
    $('#nmContrapartidaProyectoExtension').val(objdatos.contrapartida);
    $('#cboAreaAcadProyectoExtension').select2().val(objdatos.id_areaacad).trigger("change");
    $('#nmEstDerechoProyectoExtension').val(objdatos.nestudiantesderecho);
    $('#nmEstCienciaPolProyectoExtension').val(objdatos.nestudiantespolitica);
    $('#nmEstPosgradoProyectoExtension').val(objdatos.nestudiantespostgrados);
    $('#txtNumeroSarProyectoExtension').val(objdatos.numerosar);
    $('#txtNumeroODSProyectoExtension').val(objdatos.numeroodsops);
    $('#cboEstadoContratoProyectoExtension').select2().val(objdatos.id_estadocontrato).trigger("change");

    if (objdatos.idregistrorup != null) {
        $('#cboRegistroRUPProyectoExtension').select2().val(objdatos.idregistrorup).trigger("change");
    }

    if (objdatos.idarchivoentrega != null) {
        $('#cboArchivoProyectoExtension').select2().val(objdatos.idarchivoentrega).trigger("change");
    }

    $('#txtcontratoconvenioenlaceProyectoExtension').val(objdatos.contratoconvenioenlace);
    $('#txtentregaarchivoenlaceProyectoExtension').val(objdatos.entregaarchivoenlace);      

    CalculaValorTotal();

    $( "#txtConsecutivoProyectoExtension" ).prop( "disabled", true );
    $( "#dtAnnioSuscripcionProyectoExtension" ).prop( "disabled", true );
    $( "#cboTipoProyectoExtension" ).prop( "disabled", true );
    $( "#cboEntidadProyectoExtension" ).prop( "disabled", true );

}

function CalculaValorTotal() {
    let svalorinicial = $('#nmValorIniProyectoExtension').val();
    let scambio = $('#nmAdicDismProyectoExtension').val();
    let scontrapartida = $('#nmContrapartidaProyectoExtension').val();
    nvalorinicial = Number(svalorinicial);
    ncambio = Number(scambio);
    ncontrapartida = Number(scontrapartida);

    let nvalortotal = nvalorinicial + ncambio + ncontrapartida;
    let svalortotal = nvalortotal.toLocaleString('en-US');
    
    $('#txtvalortotalProyectoExtension').val(svalortotal);           
}