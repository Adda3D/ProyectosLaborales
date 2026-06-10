
$(document).ready(function () {    
    InicializaFinancieroPublicacionform();
    
    $("input[data-type='currency']").on({
        keyup: function() {
          formatCurrency($(this));
        },
        blur: function() { 
          formatCurrency($(this), "blur");
        }
    });
    
    
    function formatNumber(n) {
      // format number 1000000 to 1,234,567
      return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }
    
    
    function formatCurrency(input, blur) { 
        debugger;       
      // appends $ to value, validates decimal side
      // and puts cursor back in right position.
      
      // get input value
      var input_val = input.val();
      
      // don't validate empty input
      if (input_val === "") { return; }
      
      // original length
      var original_len = input_val.length;
    
      // initial caret position 
      var caret_pos = input.prop("selectionStart");
        
      // check for decimal
      if (input_val.indexOf(".") >= 0) {
    
        // get position of first decimal
        // this prevents multiple decimals from
        // being entered
        var decimal_pos = input_val.indexOf(".");
    
        // split number by decimal point
        var left_side = input_val.substring(0, decimal_pos);
        var right_side = input_val.substring(decimal_pos);
    
        // add commas to left side of number
        left_side = formatNumber(left_side);
    
        // validate right side
        right_side = formatNumber(right_side);
        
        // On blur make sure 2 numbers after decimal
        if (blur === "blur") {
          right_side += "00";
        }
        
        // Limit decimal to only 2 digits
        right_side = right_side.substring(0, 2);
    
        // join number by .
        input_val = "$" + left_side /*+ "." + right_side*/;
    
      } else {
        // no decimal entered
        // add commas to number
        // remove all non-digits
        input_val = formatNumber(input_val);
        input_val = /*"$" +*/ input_val;
        
        // final formatting
        if (blur === "blur") {
          input_val /*+= ".00"*/;
        }
      }
      
      // send updated string to input
      input.val(input_val);
    
      // put caret back in the right position
      var updated_len = input_val.length;
      caret_pos = updated_len - original_len + caret_pos;
      input[0].setSelectionRange(caret_pos, caret_pos);
    }

});

function VolverTablaPublicacionesDesdeControlFinanciero() {
    $("#dvPublicacionTablaFinanciero").addClass("ocultar");    
    $("#dvPublicacionesTable").removeClass("ocultar");

}

function InicializaFinancieroPublicacionform() {    
    $("#txtKardexPublicacionControlFinanciero").val($("#spanKardexPublicacion")[0].innerText);
    $("#txtHermesPublicacionControlFinanciero").val($("#spanHermesPublicacion")[0].innerText);
    $("#txtNombrePublicacionControlFinanciero").val($("#spanNombrePublicacion")[0].innerText);

    onclickTabPUBFinanciero('PUBFinancieroIngresos', 0);

    $("#dvPublicacionesTable").addClass("ocultar");    
    $("#dvPublicacionTablaFinanciero").removeClass("ocultar");
}

function onclickTabPUBFinanciero(idpagina, id_partida){    
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'publicaciontabla' + idpagina + '.html'
    let urledit = '/Pages/publicacion/' + sNombreHtml; 
    var tabExists = $("#dvTabsPublicacionControlFinanciero").find(idTab);    
    
    if (tabExists.length > 0) {
        StartLoader();

        if (!ExisteDivEdicionDatos(idDiv)) {
            CrearDivEdicionDatos(urledit, idDiv);
        }
        else {
            RefreshDataTablePublicacionControlFinancieroGastosPorPartida(id_partida);
        }

        $("#tablePublicacionControlFinanciero ul li .nav-link.tabPrin").removeClass('active show');
        $("#tablePublicacionControlFinanciero div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tablePublicacionControlFinanciero ul li #nav" + idpagina).addClass('active show');
        $("#tablePublicacionControlFinanciero div #tab" + idpagina).addClass('active show');       
        FinalizeLoader();
        return;
    }
}

function RefreshDataTablePublicacionControlFinancieroGastosPorPartida(id_partida) {
debugger;

    //DESEMBOLSOS
    if (id_partida == 0) {
        RefreshDataTablePublicacionFinancieroDesembolsos();        
        LoadDataAportesPublicacion();
    }

    //GASTOS DE PERSONAL
    if (id_partida == 1) {
        RefreshDataTablePublicacionFinancieroGastosPersonal();
    }

    //ADQUISICIÓN BIENES
    if (id_partida == 2) {
        RefreshDataTablePublicacionFinancieroGastosBienes();        
    }

    //ADQUISICIÓN SERVICIOS
    if (id_partida == 3) {
        RefreshDataTablePublicacionFinancieroGastosServicios();
    }

    //IMPUESTOS, CONTRIBUCIONES Y MULTAS
    if (id_partida == 4) {
        RefreshDataTablePublicacionFinancieroGastosImpuestos();
    }

    //TRANSFERENCIAS ENTRE FONDOS SIN CONTRAPRESTACIÓN
    if (id_partida == 5) {
        RefreshDataTablePublicacionFinancieroGastosTransferencias();
    }

    //PAGOS REALIZADOS
    if (id_partida == 6) {
        RefreshDataTablePublicacionFinancieroListaPagos();
    }

}

function CargarConceptosPublicacionCrearGasto() {    
    let idRubro = $("#cboPublicacionGastoRubro").val();

    if (idRubro != null){
        LoadSeguimientoConceptoByRubro('cboPublicacionGastoConcepto', false, idRubro);
    }
    
    if ($('#cboPublicacionGastoConcepto').data('select2')) {
        $('#cboPublicacionGastoConcepto').select2('destroy');        
      }                

    $('#cboPublicacionGastoConcepto').select2().val('').trigger("change");
    $('#cboPublicacionGastoConcepto').select2();

}

function CrearGasto_Publicacion(id_partida) {
    $("#spanPublicacionid_publicaciongasto")[0].innerText = '';
    $("#spanPublicacionGastoIdPartida")[0].innerText = id_partida;    

    CargarCombosPublicacionCrearGasto(id_partida);
    
    InicializaCamposPublicacionCrearGasto();

    AddSelect2DivPublicacionCrearGasto();
    
    removeValidationFormByForm('formPublicacionControlFinancieroCrearGasto');   
    
    $("#dvVolverTablaPublicacionesDesdeControlFinanciero").addClass("ocultar");    
    $("#tablePublicacionControlFinanciero").addClass("ocultar");    
    $("#dvCrearGastoPublicacionControlFinanciero").removeClass("ocultar");            
     
}

function EditarGasto_Publicacion(id_publicaciongasto, id_partida) {
    $("#spanPublicacionid_publicaciongasto")[0].innerText = id_publicaciongasto;
    $("#spanPublicacionGastoIdPartida")[0].innerText = id_partida;

    CargarCombosPublicacionCrearGasto(id_partida)
    .then(()=>{

    
    removeValidationFormByForm('formPublicacionControlFinancieroCrearGasto');    

    let urlEditaGasto = urlController + "Publicacion_Gasto/GetPublicacion_GastoDetails?id_publicaciongasto=" + id_publicaciongasto;  
    StartLoader();

    fetch(urlEditaGasto, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {                      
            let datos = data.Data;
            AddSelect2DivPublicacionCrearGasto();
                
            CargarCamposPublicacionCrearGasto(datos);
            FinalizeLoader();


            $("#dvVolverTablaPublicacionesDesdeControlFinanciero").addClass("ocultar");    
            $("#tablePublicacionControlFinanciero").addClass("ocultar");    
            $("#dvCrearGastoPublicacionControlFinanciero").removeClass("ocultar");            

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

function CargarCombosPublicacionCrearGasto(idpartida) {
    let promises_arrPub = [];
    return new Promise((resolve, reject)=>{

        promises_arrPub.push(LoadSeguimientoRubroByPartida('cboPublicacionGastoRubro', true, idpartida));
        $('#cboPublicacionGastoConcepto').empty();
        promises_arrPub.push(LoadSeguimientoConceptoByRubro('cboPublicacionGastoConcepto', true, 1));
        promises_arrPub.push(LoadPrestadorServicio('cboPublicacionGastoPrestador' ,true));
        promises_arrPub.push(LoadPrestadorVinculoSelect('cboPublicacionGastoVinculo', true));
        
        Promise.all(promises_arrPub)
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

function InicializaCamposPublicacionCrearGasto() {
    $('#txtPublicacionGastoNombre').val('');
    $('#nmPublicacionGastoTotal').val('0');
    $('#txtPublicacionGastoTotal4mil').val('');
    $('#dtPublicacionGastoFLegalizacion').val(getFechaActual());    
    $('#txtPublicacionGastoNorden').val('');  
    $('#txtPublicacionGastoTipo').val('');        
    $('#dtPublicacionGastoFInicio').val(getFechaActual());
    $('#dtPublicacionGastoFFinal').val(getFechaActual());
    $('#txtPublicacionGastoEstado').val('');
    $('#txtPublicacionGastoObservaciones').val('');
    
    
}

function AddSelect2DivPublicacionCrearGasto() {
    $('#cboPublicacionGastoRubro').select2();
    $('#cboPublicacionGastoPrestador').select2();
    $('#cboPublicacionGastoVinculo').select2();
    $('#cboPublicacionGastoConcepto').select2();
}

function DestruyeSelectPublicacionCrearGasto() {
    if ($('#cboPublicacionGastoRubro').data('select2')) {
        $('#cboPublicacionGastoRubro').select2('destroy');        
      }    

      if ($('#cboPublicacionGastoPrestador').data('select2')) {
        $('#cboPublicacionGastoPrestador').select2('destroy');        
      }    

      if ($('#cboPublicacionGastoVinculo').data('select2')) {
        $('#cboPublicacionGastoVinculo').select2('destroy');        
      }    

      if ($('#cboPublicacionGastoConcepto').data('select2')) {
        $('#cboPublicacionGastoConcepto').select2('destroy');        
      }    

}

function CargarCamposPublicacionCrearGasto(objdatos) {
    debugger;
    $('#cboPublicacionGastoRubro').select2().val(objdatos.id_rubro).trigger("change");
   
    LoadSeguimientoConceptoByRubro('cboPublicacionGastoConcepto', false, objdatos.id_rubro);

    if ($('#cboPublicacionGastoConcepto').data('select2')) {
        $('#cboPublicacionGastoConcepto').select2('destroy');        
      }                

    $('#cboPublicacionGastoConcepto').select2().val(objdatos.id_segconcepto).trigger("change");
    $('#txtPublicacionGastoNombre').val(objdatos.nombregasto);    
    $('#cboPublicacionGastoPrestador').select2().val(objdatos.id_persona).trigger("change");
    $('#cboPublicacionGastoVinculo').select2().val(objdatos.id_relacionvinculo).trigger("change");
    $('#nmPublicacionGastoTotal').val(objdatos.valortotal.toLocaleString('en-US'));
    $('#txtPublicacionGastoTotal4mil').val(objdatos.gastototal4mil.toLocaleString('en-US'));
    $('#dtPublicacionGastoFLegalizacion').val(objdatos.fechalegalizacionorden.slice(0, 10));
    $('#txtPublicacionGastoNorden').val(objdatos.numorden);
    $('#txtPublicacionGastoTipo').val(objdatos.tipo);  
    $('#dtPublicacionGastoFInicio').val(objdatos.fechainicio.slice(0, 10));
    $('#dtPublicacionGastoFFinal').val(objdatos.fechafinal.slice(0, 10));
    $('#txtPublicacionGastoEstado').val(objdatos.estado);
    $('#txtPublicacionGastoObservaciones').val(objdatos.observaciones);

}

function ValidatePostUpdatePublicacionControlFinancieroCrearGasto(formF) {
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
                     AddUpdatePublicacionControlFinancieroCrearGasto();                    
            }
        }
    }    
}


function AddUpdatePublicacionControlFinancieroCrearGasto() {
    debugger;
    var objData = new Object();
    let urlUpdate = urlController + "Publicacion_Gasto/UpdatePublicacion_Gasto";
    
    objData.id_publicaciongasto = ($("#spanPublicacionid_publicaciongasto")[0].innerText == '') ? undefined : $("#spanPublicacionid_publicaciongasto")[0].innerText;
    objData.id_crearpublicacion = $("#spanIdPublicacion")[0].innerText;
    objData.id_partida = $("#spanPublicacionGastoIdPartida")[0].innerText;    
    objData.id_segconcepto = $("#cboPublicacionGastoConcepto").val();
    objData.id_rubro = $("#cboPublicacionGastoRubro").val();
    objData.nombregasto = $('#txtPublicacionGastoNombre').val();    
    objData.id_persona = $("#cboPublicacionGastoPrestador").val();    
    objData.id_relacionvinculo = $("#cboPublicacionGastoVinculo").val();    
    objData.valortotal = $('#nmPublicacionGastoTotal').val();
    objData.gastototal4mil = $('#txtPublicacionGastoTotal4mil').val();
    objData.fechalegalizacionorden = $('#dtPublicacionGastoFInicio').val();
    objData.numorden = $('#txtPublicacionGastoNorden').val();
    objData.tipo = $('#txtPublicacionGastoTipo').val();
    objData.fechainicio = $('#dtPublicacionGastoFInicio').val();
    objData.fechafinal = $('#dtPublicacionGastoFFinal').val();
    objData.estado = $('#txtPublicacionGastoEstado').val();
    objData.observaciones = $('#txtPublicacionGastoObservaciones').val();
        
    if (objData.id_publicaciongasto == undefined) {
        urlUpdate = urlController + "Publicacion_Gasto/InsertPublicacion_Gasto";
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
            DestruyeSelectPublicacionCrearGasto();    
            
            $("#dvCrearGastoPublicacionControlFinanciero").addClass("ocultar");    
            $("#tablePublicacionControlFinanciero").removeClass("ocultar");
            $("#dvVolverTablaPublicacionesDesdeControlFinanciero").removeClass("ocultar");    

            RefreshDataTablePublicacionControlFinancieroGastosPorPartida(objData.id_partida);
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

function VolverTablaGastosPublicacionControlFinancieroDesdeEdicion() {
    DestruyeSelectPublicacionCrearGasto();    

    $("#dvCrearGastoPublicacionControlFinanciero").addClass("ocultar");    
    $("#tablePublicacionControlFinanciero").removeClass("ocultar");            
    $("#dvVolverTablaPublicacionesDesdeControlFinanciero").removeClass("ocultar");    

}


function ValidarEliminarGastoPublicacion(id_publicaciongasto, id_partida) {
    ShowDialogConfirmacion('','Seguro de eliminar gasto ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarGastoPublicacion(id_publicaciongasto, id_partida);
            }
        });

}

function EliminarGastoPublicacion(id_publicaciongasto, id_partida) {
    let urlEliminar = urlController + "Publicacion_Gasto/DeletePublicacion_Gasto?id_publicaciongasto=" + id_publicaciongasto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTablePublicacionControlFinancieroGastosPorPartida(id_partida);
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );      

}

function GenerarPagoGastoPublicacion(idpublicacion, id_publicaciongasto, rubro, descripciongasto, prestador, descripcion, id_partida ) {    
    $("#spanPublicacionPagoIdGasto")[0].innerText = id_publicaciongasto;
    $("#spanPublicacionPagoIdPublicacion")[0].innerText = idpublicacion;
    $('#LabeldvAplicarPagoPublicacionControlFinanciero')[0].innerText = 'Datos para aplicar Pago ' + descripcion;
    $("#spanPublicacionPagoGastoIdPartida")[0].innerText = id_partida;
    
    $('#txtPublicacionPagoNombreRubro').val(rubro); 
    $('#txtPublicacionPagoPrestador').val(prestador); 
    $('#txtPublicacionPagoDescrGasto').val(descripciongasto); 

    LoadSemestreSelect('cboPublicacionPagoPeriodo',false);
    
    $('#dtPublicacionPagoFecha').val(getFechaActual());
    $('#nmPublicacionPagoValor').val('0');
    $('#nmPublicacionPagoTotal').val('0');
    $('#txtPublicacionPagoOrpa').val('');
    $('#txtPublicacionPagoEgreso').val('');
    $('#txtPublicacionPagoNotas').val('');

    removeValidationFormByForm('formPublicacionControlFinancieroAplicarPago');    

    $('#cboPublicacionPagoPeriodo').select2();

    $("#dvVolverTablaPublicacionesDesdeControlFinanciero").addClass("ocultar");    
    $("#tablePublicacionControlFinanciero").addClass("ocultar");    
    $("#dvAplicarPagoPublicacionControlFinanciero").removeClass("ocultar");            
}

function VolverTablaGastosPublicacionControlFinancieroDesdePago() {
    if ($('#cboPublicacionPagoPeriodo').data('select2')) {
        $('#cboPublicacionPagoPeriodo').select2('destroy');        
      }    

    $("#dvAplicarPagoPublicacionControlFinanciero").addClass("ocultar");    
    $("#tablePublicacionControlFinanciero").removeClass("ocultar");            
    $("#dvVolverTablaPublicacionesDesdeControlFinanciero").removeClass("ocultar");    
}


function ValidatePostUpdatePublicacionControlFinancieroPagoGasto(formF) {
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
                     AddUpdatePublicacionControlFinancieroPagoGasto();
            }
        }
    }    

}

function AddUpdatePublicacionControlFinancieroPagoGasto() {
    var objData = new Object();
    let urlUpdate = urlController + "Publicacion_Aplicarpago/UpdatePublicacion_Aplicarpago";
    
    objData.id_publicacionpago = undefined;
    objData.id_publicaciongasto = $("#spanPublicacionPagoIdGasto")[0].innerText;
    objData.id_crearpublicacion = $("#spanIdPublicacion")[0].innerText;
    objData.fechapago = $('#dtPublicacionPagoFecha').val();
    objData.orpa = $('#txtPublicacionPagoOrpa').val();    
    objData.cp_egr = $('#txtPublicacionPagoEgreso').val();    
    objData.id_semestre = $("#cboPublicacionPagoPeriodo").val();
    objData.valorneto = $('#nmPublicacionPagoValor').val();
    objData.notas = $('#txtPublicacionPagoNotas').val();    
        
    if (objData.id_publicacionpago == undefined) {
        urlUpdate = urlController + "Publicacion_Aplicarpago/InsertPublicacion_Aplicarpago";
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

            if ($('#cboPublicacionPagoPeriodo').data('select2')) {
                $('#cboPublicacionPagoPeriodo').select2('destroy');        
              }    
            
            $("#dvAplicarPagoPublicacionControlFinanciero").addClass("ocultar");    
            $("#tablePublicacionControlFinanciero").removeClass("ocultar");            
            $("#dvVolverTablaPublicacionesDesdeControlFinanciero").removeClass("ocultar");    

            ShowModalDialog('Pago aplicado correctamente', false, 'success', '', 0);

            RefreshDataTablePublicacionControlFinancieroGastosPorPartida($("#spanPublicacionPagoGastoIdPartida")[0].innerText);
          
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

function ValorTotalPago4xmilPUBFin(inputorigen, inputdestino) {
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto);
    let valorimpuesto = valorneto * 4 / 1000;
    valorimpuesto = Math.round(valorimpuesto);
    let valortotal = valorneto + valorimpuesto;
    $('#' + inputdestino).val(valortotal.toLocaleString('en-US'));   
}

function GenerarExcelPublicacionControlFinanciero(){
    let urlExcel = urlController + "Publicaciones_CrearPublicacion/ExcelFinancieroPublicaciones_CrearPublicacion?id_crearpublicacion=" + $("#spanIdPublicacion")[0].innerText;
    StartLoader();

    fetch(urlExcel, {
        method: 'GET',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {      
            debugger;                 
            FinalizeLoader();
            location.href = urlDownload + data.Data;
            return;
        }
        else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
      })
      .catch (err => {
        ShowModalDialog(err, false, 'error', '', 0);
      } );  
      
}

function GastoTotal4milPRJINV(inputorigen, inputdestino) {
    debugger;
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto.replace(/[$,.]/g,'')); 
    let valorimpuesto = valorneto * 4 / 1000;
    valorimpuesto = Math.round(valorimpuesto);
    let valortotal = valorneto + valorimpuesto;
    //$('#' + inputdestino).val(valortotal);
    $('#' + inputdestino).val(valortotal.toLocaleString('en-US'));   
}   