$(document).ready(function () {

    if ($("#spanIdPrestadorServicio")[0].innerText == '') {
        CrearPrestadorServicioform();
    }
    else {
        EditarPrestadorServicioform($("#spanIdPrestadorServicio")[0].innerText);
    }

});

function CrearPrestadorServicioform() {
    $("#spanIdpersona")[0].innerText = '';
    
    CargarCombosDetallePrestadorServicio();

    InicializaCamposDetallePrestadorServicio()

    AddSelect2DivDetallePrestadorServicio()    
    removeValidationFormByForm('formPrestadorServicioDetalle');

    $("#dvPrestadorServicioTable").addClass("ocultar");    
    $("#dvPrestadorServicioDetalle").removeClass("ocultar");            

}

function EditarPrestadorServicioform(idprestadorservicio) {
    $("#spanIdpersona")[0].innerText = idprestadorservicio;

    CargarCombosDetallePrestadorServicio()
    .then(()=>{

    

    removeValidationFormByForm('formPrestadorServicioDetalle');
    let urlEditaPersona = urlController + "Persona/GetPersonaDetails?id_persona=" + idprestadorservicio;  
    StartLoader();

    fetch(urlEditaPersona, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;
            AddSelect2DivDetallePrestadorServicio();
                CargarCamposPrestadorServicio(datos);
                FinalizeLoader();
                
        

            $("#dvPrestadorServicioTable").addClass("ocultar");    
            $("#dvPrestadorServicioDetalle").removeClass("ocultar");            
        
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

function VolverTablaPersonasDesdeEdicion() {
    DestruyeSelectPrestadorServicio()
        
    $("#dvPrestadorServicioDetalle").addClass("ocultar");    
    $("#dvPrestadorServicioTable").removeClass("ocultar");

}

function CargarCombosDetallePrestadorServicio() {
    let promises_arrDetPropuestas = [];
    return new Promise((resolve, reject)=>{

        promises_arrDetPropuestas.push(LoadTipoPersonaSelect('cboNaturalezaPersona', true));
        promises_arrDetPropuestas.push(LoadTipoEntidadSelect('cboTipoEntidadPersona', true));
        promises_arrDetPropuestas.push(LoadTipoDocumentoSelect('cboTipoDocumentoPersona', true));
        promises_arrDetPropuestas.push(LoadPersonaGeneroSelect('cboGeneroPersona', true));
        promises_arrDetPropuestas.push(LoadDependenciaSelectNulo('cboDependenciaPersona', true));
        promises_arrDetPropuestas.push(LoadPersonaTipoServicioSelect('cboTipoServicioPersona', true));
        promises_arrDetPropuestas.push(LoadPersonaFormacionSelect('cboFormacionPersona', true));
        promises_arrDetPropuestas.push(LoadPersonaTituloAltoSelect('cboTituloaltoPersona', true));
        promises_arrDetPropuestas.push(LoadPersonaCalificacionSelect('cboidcalificacionPersona', true));            
        promises_arrDetPropuestas.push(LoadPersonaTipoEvaluadorSelect('cboTipoEvaluadorPersona', true));
        
        
        Promise.all(promises_arrDetPropuestas)
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

function InicializaCamposDetallePrestadorServicio() {
    $('#cboNaturalezaPersona').select2().val('').trigger("change");
    $('#cboTipoEntidadPersona').select2().val('').trigger("change");
    $('#cboTipoDocumentoPersona').select2().val('').trigger("change");
    $("#txtnumidentificacionPersona").val('');
    $("#txtNombreCompletoPersona").val('');
    $('#cboGeneroPersona').select2().val('').trigger("change");    
    $("#txtnacionalidadPersona").val('');
    $("#txttelefonoPersona").val('');
    $("#txtcelularPersona").val('');
    $("#txtdireccionPersona").val('');
    $("#txtciudadPersona").val('');
    $("#txtcorreoPersona").val('');
    $("#txtinstitucionPersona").val('');
    $("#txtcargoPersona").val('');           
    $('#cboDependenciaPersona').select2().val('').trigger("change");
    $('#cboTipoServicioPersona').select2().val('').trigger("change");
    $("#txtareainterespersona").val('');
    $("#txtenlacecvlacpersona").val('');
    $("#txtperfilpersona").val('');
    $('#cboFormacionPersona').select2().val('').trigger("change");
    $('#cboTituloaltoPersona').select2().val('').trigger("change");
    $("#txttituloposgradospersona").val('');    
    $('#cboidcalificacionPersona').select2().val('').trigger("change");   
    $('#chkEvaluadorPublicacionPersona').prop('checked', false); 
    $('#cboTipoEvaluadorPersona').select2().val('').trigger("change");   
    $("#txtcvlacEvaluadorPersona").val('');    
    $("#txtobservacionespersona").val('');  

    EnableDatosEvaluadorPersona();
}

function AddSelect2DivDetallePrestadorServicio() {
    $('#cboNaturalezaPersona').select2();
    $('#cboTipoEntidadPersona').select2();
    $('#cboTipoDocumentoPersona').select2();
    $('#cboGeneroPersona').select2();
    $('#cboDependenciaPersona').select2();
    $('#cboTipoServicioPersona').select2({multiple: true});
    $('#cboFormacionPersona').select2();
    $('#cboTituloaltoPersona').select2();
    $('#cboidcalificacionPersona').select2();
    $('#cboTipoEvaluadorPersona').select2();
}

function DestruyeSelectPrestadorServicio() {
    $('#cboNaturalezaPersona').select2('destroy');
    $('#cboTipoEntidadPersona').select2('destroy');
    $('#cboTipoDocumentoPersona').select2('destroy');
    $('#cboGeneroPersona').select2('destroy');
    $('#cboDependenciaPersona').select2('destroy');
    $('#cboTipoServicioPersona').select2('destroy');
    $('#cboFormacionPersona').select2('destroy');
    $('#cboTituloaltoPersona').select2('destroy');
    $('#cboidcalificacionPersona').select2('destroy');
    $('#cboTipoEvaluadorPersona').select2('destroy');
}

function ValidatePostUpdatePrestadorServicio(formF) {
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
                AddUpdatePestadorServicio();
            }
        }
    }    

}

function AddUpdatePestadorServicio() {
    let objprestadorservicio = new Object();
    let urlUpdate = urlController + "Persona/UpdatePersona";
    StartLoader();
    
    let arraytiposervicio = $("#cboTipoServicioPersona").val();
    let strtiposervicio = arraytiposervicio.toString();

    objprestadorservicio.id_persona = ($("#spanIdpersona")[0].innerText == '') ? undefined : $("#spanIdpersona")[0].innerText;
    
    objprestadorservicio.id_tipodocumento = $("#cboTipoDocumentoPersona").val();
    objprestadorservicio.id_tipopersona = $("#cboNaturalezaPersona").val();
    objprestadorservicio.numidentificacion = $("#txtnumidentificacionPersona").val();    
    objprestadorservicio.nacionalidad = $("#txtnacionalidadPersona").val();
    objprestadorservicio.id_genero = ($("#cboGeneroPersona").val() == '') ? undefined : $("#cboGeneroPersona").val();
    objprestadorservicio.id_tipoentidad = $("#cboTipoEntidadPersona").val();    
    objprestadorservicio.nombrecompleto = $("#txtNombreCompletoPersona").val();
    objprestadorservicio.direccion1 = $("#txtdireccionPersona").val();
    objprestadorservicio.telefono = $("#txttelefonoPersona").val();
    objprestadorservicio.celular = $("#txtcelularPersona").val();
    objprestadorservicio.correo1 =  $("#txtcorreoPersona").val();
    objprestadorservicio.institucion = $("#txtinstitucionPersona").val();
    objprestadorservicio.cargo = $("#txtcargoPersona").val();
    objprestadorservicio.id_tiposervicio = strtiposervicio;    
    objprestadorservicio.ciudad = $("#txtciudadPersona").val();
    objprestadorservicio.id_depend = ($("#cboDependenciaPersona").val() == '') ? undefined : $("#cboDependenciaPersona").val();    
    objprestadorservicio.areainteres = $("#txtareainterespersona").val();
    objprestadorservicio.enlacecvlac = $("#txtenlacecvlacpersona").val();
    objprestadorservicio.id_formacion = ($("#cboFormacionPersona").val() == '') ? undefined : $("#cboFormacionPersona").val(); 
    objprestadorservicio.id_tituloalto = ($("#cboTituloaltoPersona").val() == '') ? undefined : $("#cboTituloaltoPersona").val(); 
    objprestadorservicio.tituloposgrados = $("#txttituloposgradospersona").val();
    objprestadorservicio.perfil = $("#txtperfilpersona").val();
    objprestadorservicio.id_calificacion = ($("#cboidcalificacionPersona").val() == '') ? undefined : $("#cboidcalificacionPersona").val();     
    objprestadorservicio.evaluadorpublicacion = $('#chkEvaluadorPublicacionPersona').is(':checked'); 
    objprestadorservicio.evaluadorinternoexterno = ($("#cboTipoEvaluadorPersona").val() == '') ? undefined : $("#cboTipoEvaluadorPersona").val();
    objprestadorservicio.evaluadorminciencias = $("#txtcvlacEvaluadorPersona").val();
    objprestadorservicio.observaciones = $("#txtobservacionespersona").val();
        
    if (objprestadorservicio.id_persona == undefined) {
        urlUpdate = urlController + "Persona/InsertPersona";
    }
    
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objprestadorservicio),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario' : sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {     
            FinalizeLoader();

            DestruyeSelectPrestadorServicio();

            $("#dvPrestadorServicioDetalle").addClass("ocultar");    
            $("#dvPrestadorServicioTable").removeClass("ocultar");
        
            RefreshDataTablePrestadorServicio();
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

function CargarCamposPrestadorServicio(objdatos) {
    let strtiposervicio = objdatos.id_tiposervicio;
    let arraytiposervicio = strtiposervicio.split(',');

    $('#cboTipoDocumentoPersona').select2().val(objdatos.id_tipodocumento).trigger("change");
    $('#cboNaturalezaPersona').select2().val(objdatos.id_tipopersona).trigger("change");    
    $("#txtnumidentificacionPersona").val(objdatos.numidentificacion);
    $("#txtnacionalidadPersona").val(objdatos.nacionalidad);

    if (objdatos.id_genero != null) {
        $('#cboGeneroPersona').select2().val(objdatos.id_genero).trigger("change");
    }

    $('#cboTipoEntidadPersona').select2().val(objdatos.id_tipoentidad).trigger("change");
    $("#txtNombreCompletoPersona").val(objdatos.nombrecompleto);
    $("#txtdireccionPersona").val(objdatos.direccion1);
    $("#txttelefonoPersona").val(objdatos.telefono);
    $("#txtcelularPersona").val(objdatos.celular);
    $("#txtcorreoPersona").val(objdatos.correo1);
    $("#txtinstitucionPersona").val(objdatos.institucion);
    $("#txtcargoPersona").val(objdatos.cargo);
    $('#cboTipoServicioPersona').select2().val(arraytiposervicio).trigger("change");
    $("#txtciudadPersona").val(objdatos.ciudad);

    if (objdatos.id_depend != null) {
        $('#cboDependenciaPersona').select2().val(objdatos.id_depend).trigger("change");
    }

    $("#txtareainterespersona").val(objdatos.areainteres);
    $("#txtenlacecvlacpersona").val(objdatos.enlacecvlac);

    if (objdatos.id_formacion != null) {
        $('#cboFormacionPersona').select2().val(objdatos.id_formacion).trigger("change");
    }

    if (objdatos.id_tituloalto != null) {
        $('#cboTituloaltoPersona').select2().val(objdatos.id_tituloalto).trigger("change");
    }

    $("#txttituloposgradospersona").val(objdatos.tituloposgrados);
    $("#txtperfilpersona").val(objdatos.perfil);

    if (objdatos.id_calificacion != null) {
        $('#cboidcalificacionPersona').select2().val(objdatos.id_calificacion).trigger("change");
    }

    $('#chkEvaluadorPublicacionPersona').prop('checked', objdatos.evaluadorpublicacion);

    if (objdatos.evaluadorinternoexterno != null) {
        $('#cboTipoEvaluadorPersona').select2().val(objdatos.evaluadorinternoexterno).trigger("change");
    }

    $("#txtcvlacEvaluadorPersona").val(objdatos.evaluadorminciencias);
    $("#txtobservacionespersona").val(objdatos.observaciones);

    EnableDatosEvaluadorPersona();
}

function EnableDatosEvaluadorPersona() {
    document.getElementById("cboTipoEvaluadorPersona").disabled = !$('#chkEvaluadorPublicacionPersona').is(':checked');
    document.getElementById("txtcvlacEvaluadorPersona").disabled = !$('#chkEvaluadorPublicacionPersona').is(':checked');
}