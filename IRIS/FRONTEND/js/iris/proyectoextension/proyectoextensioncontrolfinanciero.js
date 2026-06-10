var DataTableProyectoExtensionFinanciero = null;

$(document).ready(function () {    
    InicializaFinancieroProyectoExtensionform($("#spanIdProyectoExtension")[0].innerText, $("#spanConsecutivoProyectoExtension")[0].innerText,
                                                $("#spanContratoProyectoExtension")[0].innerText, $("#spanNombreProyectoExtension")[0].innerText);
    //es el que cambia un valor a los puntos
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

function VolverTablaProyectoExtensionDesdeFinanciero() { 
    $("#dvProyectoExtensionTablaFinanciero").addClass("ocultar");    
    $("#dvProyectoExtensionTable").removeClass("ocultar");

}

function InicializaFinancieroProyectoExtensionform(id_asignacionproyecto, consecutivo, contrato, nombreproyecto) {
    $("#spanIdProyectoExtensionFinanciero")[0].innerText = id_asignacionproyecto; 

    $("#txtConsProyectoExtensionFinanciero").val(consecutivo);
    $("#txtContratoProyectoExtensionFinanciero").val(contrato);
    $("#txtNombreProyectoExtensionFinanciero").val(nombreproyecto);

    onclickTabPEFin('PEFinIngresos', 0);

    $("#dvProyectoExtensionTable").addClass("ocultar");    
    $("#dvProyectoExtensionTablaFinanciero").removeClass("ocultar");
}

function onclickTabPEFin(idpagina, id_partida){    
    nombreItem = idpagina;     
    var idTab = "#tab" + idpagina;
    var tabExists = $("#dvTabsProyectoExtensionFinanciero").find(idTab);
    debugger;
    
    if (tabExists.length > 0) {
        StartLoader();

        if (!ExisteDivContentFinancieroProyectoExtension(idpagina)) {
            CrearDivContentFinancieroProyectoExtension(idpagina);
        }
        else {
            if (id_partida == 0) {
                InicializaFinancieroProyectoExtensionDesembolsosform($("#spanIdProyectoExtension")[0].innerText);                
            }
            else {
                RefreshDataTableProyectoExtensionFinancieroGastosPorPartida(id_partida)            
            }                        
        }
    
        $("#tableProyectoExtensionFinanciero ul li .nav-link.tabPrin").removeClass('active show');
        $("#tableProyectoExtensionFinanciero div .tab-pane.tabPrin").removeClass('active show');
    
        $("#tableProyectoExtensionFinanciero ul li #nav" + idpagina).addClass('active show');
        $("#tableProyectoExtensionFinanciero div #tab" + idpagina).addClass('active show');       
        FinalizeLoader();
        return;
    }
}

function ExisteDivContentFinancieroProyectoExtension(idpagina) {
    let idDiv = "dvCont" + idpagina;
    let divontenido = document.getElementById(idDiv).innerHTML.trim();

    if (divontenido == null || divontenido == "") {
        return false;
    }
    else {
        return true;
    }
}

function CrearDivContentFinancieroProyectoExtension(idpagina) {
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'proyectoextensiontabla' + idpagina + '.html'
    let urledit = '/Pages/ProyectoExtension/' + sNombreHtml; 

    $.get(urledit, function (htmlexterno) {
        $('#' + idDiv).html(htmlexterno);
    });    

}


function CargarConceptosProyectoExtensionCrearGasto() {    
    let idRubro = $("#cboProyectoExtensionGastoRubro").val();

    if (idRubro != null){
        LoadSeguimientoConceptoByRubro('cboProyectoExtensionGastoConcepto', false, idRubro);
    }
    
    if ($('#cboProyectoExtensionGastoConcepto').data('select2')) {
        $('#cboProyectoExtensionGastoConcepto').select2('destroy');        
      }                

    $('#cboProyectoExtensionGastoConcepto').select2().val('').trigger("change");
    $('#cboProyectoExtensionGastoConcepto').select2();

}

function _actualizarOpcionesTipo(id_partida) {
    var sel = $('#txtProyectoExtensionGastoTipo');
    sel.empty();
    sel.append('<option value="">Seleccione</option>');
    var opciones = (id_partida == 1)
        ? ['SAR','OSE','RAG','OPSOSE','OPS']
        : (id_partida == 5)
            ? ['ATI','ELT']
            : ['OSU','OCA','ODA','ODC','ODO','CPS','CDO','CDC','CSE','CSU','CCP','CDA','CIS'];
    opciones.forEach(function(o) { sel.append('<option value="'+o+'">'+o+'</option>'); });
}

function CrearProyectoExtensionCrearGasto(id_partida) {
    $("#spanProyectoExtensionIdGasto")[0].innerText = '';
    $("#spanProyectoExtensionGastoIdPartida")[0].innerText = id_partida;
    _actualizarOpcionesTipo(id_partida);

    CargarCombosProyectoExtensionCrearGasto(id_partida);
    
    InicializaCamposProyectoExtensionCrearGasto();

    AddSelect2DivProyectoExtensionCrearGasto();
    
    removeValidationFormByForm('formProyectoExtensionFinancieroCrearGasto');   
    
    $("#dvVolverTablaProyectoExtensionDesdeFinanciero").addClass("ocultar");    
    $("#tableProyectoExtensionFinanciero").addClass("ocultar");    
    $("#dvCrearGastoProyectoExtensionFinanciero").removeClass("ocultar");            
     
}

function EditarProyectoExtensionCrearGasto(id_creargasto, id_partida) {
    $("#spanProyectoExtensionIdGasto")[0].innerText = id_creargasto;
    $("#spanProyectoExtensionGastoIdPartida")[0].innerText = id_partida;
    _actualizarOpcionesTipo(id_partida);

    CargarCombosProyectoExtensionCrearGasto(id_partida)
    .then(()=>{

        removeValidationFormByForm('formProyectoExtensionFinancieroCrearGasto');    
    
        let urlEditaGasto = urlController + "Seguimiento_CrearGasto/GetSeguimiento_CrearGastoDetails?id_creargasto=" + id_creargasto;  
        StartLoader();
    
        fetch(urlEditaGasto, {
            method: 'GET',
            headers: { 'Authorization': 'Bearer ' + TokenIRIS }
        })
        .then(response => response.json())
          .then(data => {
            if (data.Ok) {                      
                let datos = data.Data;
                AddSelect2DivProyectoExtensionCrearGasto();
                    
                    CargarCamposProyectoExtensionCrearGasto(datos);
                    FinalizeLoader();
    
                $("#dvVolverTablaProyectoExtensionDesdeFinanciero").addClass("ocultar");    
                $("#tableProyectoExtensionFinanciero").addClass("ocultar");    
                $("#dvCrearGastoProyectoExtensionFinanciero").removeClass("ocultar");            
    
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

function CargarCombosProyectoExtensionCrearGasto(idpartida) {
    let promises_arrExt = [];
    
    return new Promise((resolve, reject) =>{

        promises_arrExt.push(LoadSeguimientoRubroByPartida('cboProyectoExtensionGastoRubro', true, idpartida));
        $('#cboProyectoExtensionGastoConcepto').empty();
        promises_arrExt.push(LoadSeguimientoConceptoByRubro('cboProyectoExtensionGastoConcepto', true, 1));
        promises_arrExt.push(LoadPrestadorServicio('cboProyectoExtensionGastoPrestador' ,true));
        promises_arrExt.push(LoadPrestadorVinculoSelect('cboProyectoExtensionGastoVinculo', true));    

        Promise.all(promises_arrExt)
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

function InicializaCamposProyectoExtensionCrearGasto() {
    $('#txtProyectoExtensionGastoNombre').val('');
    $('#nmProyectoExtensionGastoTotal').val('0');
    $('#nmProyectoExtensionGastoTotal4mil').val('');
    $('#dtProyectoExtensionGastoFLegalizacion').val(getFechaActual());
    $('#txtProyectoExtensionGastoTipo').val('');
    $('#txtProyectoExtensionGastoNorden').val('');    
    $('#dtProyectoExtensionGastoFInicio').val(getFechaActual());
    $('#dtProyectoExtensionGastoFFinal').val(getFechaActual());
    $('#txtProyectoExtensionGastoEstado').val('');
    
}

function AddSelect2DivProyectoExtensionCrearGasto() {
    $('#cboProyectoExtensionGastoRubro').select2();
    $('#cboProyectoExtensionGastoPrestador').select2();
    $('#cboProyectoExtensionGastoVinculo').select2();
    $('#cboProyectoExtensionGastoConcepto').select2();
}

function DestruyeSelectProyectoExtensionCrearGasto() {
    if ($('#cboProyectoExtensionGastoRubro').data('select2')) {
        $('#cboProyectoExtensionGastoRubro').select2('destroy');        
      }    

      if ($('#cboProyectoExtensionGastoPrestador').data('select2')) {
        $('#cboProyectoExtensionGastoPrestador').select2('destroy');        
      }    

      if ($('#cboProyectoExtensionGastoVinculo').data('select2')) {
        $('#cboProyectoExtensionGastoVinculo').select2('destroy');        
      }    

      if ($('#cboProyectoExtensionGastoConcepto').data('select2')) {
        $('#cboProyectoExtensionGastoConcepto').select2('destroy');        
      }    

}

function CargarCamposProyectoExtensionCrearGasto(objdatos) {
    debugger;
    $('#cboProyectoExtensionGastoRubro').select2().val(objdatos.id_rubro).trigger("change");
   
    LoadSeguimientoConceptoByRubro('cboProyectoExtensionGastoConcepto', false, objdatos.id_rubro);

    if ($('#cboProyectoExtensionGastoConcepto').data('select2')) {
        $('#cboProyectoExtensionGastoConcepto').select2('destroy');        
      }                

    $('#cboProyectoExtensionGastoConcepto').select2().val(objdatos.id_segconcepto).trigger("change");
    $('#txtProyectoExtensionGastoNombre').val(objdatos.nombregasto);    
    $('#cboProyectoExtensionGastoPrestador').select2().val(objdatos.id_persona).trigger("change");
    $('#cboProyectoExtensionGastoVinculo').select2().val(objdatos.id_relacionvinculo).trigger("change");
    $('#nmProyectoExtensionGastoTotal').val(objdatos.valortotal.toLocaleString('en-US'));
    $('#nmProyectoExtensionGastoTotal4mil').val(objdatos.gastototal4mil.toLocaleString('en-US'));
    $('#dtProyectoExtensionGastoFLegalizacion').val(objdatos.fechalegalizacionorden.slice(0, 10));
    $('#txtProyectoExtensionGastoNorden').val(objdatos.numorden);
    $('#dtProyectoExtensionGastoFInicio').val(objdatos.fechainicio.slice(0, 10));
    $('#dtProyectoExtensionGastoFFinal').val(objdatos.fechafinal.slice(0, 10));
    $('#txtProyectoExtensionGastoEstado').val(objdatos.estado);
    $('#txtProyectoExtensionGastoTipo').val(objdatos.tipo);

}

function ValidatePostUpdateProyectoExtensionFinancieroCrearGasto(formF) {
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
                     AddUpdateProyectoExtensionFinancieroCrearGasto();                    
            }
        }
    }    
}


function AddUpdateProyectoExtensionFinancieroCrearGasto() {
    var objData = new Object();
    let urlUpdate = urlController + "Seguimiento_CrearGasto/UpdateSeguimiento_CrearGasto";
    
    objData.id_creargasto = ($("#spanProyectoExtensionIdGasto")[0].innerText == '') ? undefined : $("#spanProyectoExtensionIdGasto")[0].innerText;
    objData.id_asignacionproyecto = $("#spanIdProyectoExtensionFinanciero")[0].innerText;
    objData.id_partida = $("#spanProyectoExtensionGastoIdPartida")[0].innerText;    
    objData.id_segconcepto = $("#cboProyectoExtensionGastoConcepto").val();
    objData.id_rubro = $("#cboProyectoExtensionGastoRubro").val();
    objData.nombregasto = $('#txtProyectoExtensionGastoNombre').val();    
    objData.id_persona = $("#cboProyectoExtensionGastoPrestador").val();    
    objData.id_relacionvinculo = $("#cboProyectoExtensionGastoVinculo").val();   
    objData.gastototal4mil = $('#nmProyectoExtensionGastoTotal4mil').val();
    objData.valortotal = $('#nmProyectoExtensionGastoTotal').val();
    objData.fechalegalizacionorden = $('#dtProyectoExtensionGastoFLegalizacion').val();
    objData.numorden = $('#txtProyectoExtensionGastoNorden').val();
    objData.fechainicio = $('#dtProyectoExtensionGastoFInicio').val();
    objData.fechafinal = $('#dtProyectoExtensionGastoFFinal').val();
    objData.estado = $('#txtProyectoExtensionGastoEstado').val();
    objData.tipo = $('#txtProyectoExtensionGastoTipo').val();
        
    if (objData.id_creargasto == undefined) {
        urlUpdate = urlController + "Seguimiento_CrearGasto/InsertSeguimiento_CrearGasto";
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
            DestruyeSelectProyectoExtensionCrearGasto();    
            
            $("#dvCrearGastoProyectoExtensionFinanciero").addClass("ocultar");    
            $("#tableProyectoExtensionFinanciero").removeClass("ocultar");
            $("#dvVolverTablaProyectoExtensionDesdeFinanciero").removeClass("ocultar");    

            RefreshDataTableProyectoExtensionFinancieroGastosPorPartida(objData.id_partida);
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

function VolverTablaGastosProyectoExtensionFinancieroDesdeEdicion() {
    DestruyeSelectProyectoExtensionCrearGasto();    

    $("#dvCrearGastoProyectoExtensionFinanciero").addClass("ocultar");    
    $("#tableProyectoExtensionFinanciero").removeClass("ocultar");            
    $("#dvVolverTablaProyectoExtensionDesdeFinanciero").removeClass("ocultar");    

}

function RefreshDataTableProyectoExtensionFinancieroGastosPorPartida(id_partida) {

    //DESEMBOLSOS
    if (id_partida == 0) {
        RefreshDataTableProyectoExtensionFinancieroDesembolsos();
        LoadDataAportesProyectoExtension();
    }

    //GASTOS DE PERSONAL
    if (id_partida == 1) {
        RefreshDataTableProyectoExtensionFinancieroGastosPersonal();
    }

    //ADQUISICIÓN BIENES
    if (id_partida == 2) {
        RefreshDataTableProyectoExtensionFinancieroGastoAdquisicionBienes();
    }

    //ADQUISICIÓN SERVICIOS
    if (id_partida == 3) {
        RefreshDataTableProyectoExtensionFinancieroAdquisicionServicios();
    }

    //IMPUESTOS, CONTRIBUCIONES Y MULTAS
    if (id_partida == 4) {
        RefreshDataTableProyectoExtensionFinancieroImpuestosMultas();
    }

    //TRANSFERENCIAS ENTRE FONDOS SIN CONTRAPRESTACIÓN
    if (id_partida == 5) {
        RefreshDataTableProyectoExtensionFinancieroTransferencias();
    }

    //TRANSFERENCIAS ENTRE FONDOS SIN CONTRAPRESTACIÓN
    if (id_partida == 6) {
        InicializaFinancieroProyectoExtensionListaPagosform();
    }

}

function ValidarEliminarGastoProyectoExtension(id_creargasto, id_partida) {
    ShowDialogConfirmacion('','Seguro de eliminar gasto ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarGastoProyectoExtension(id_creargasto, id_partida);
            }
        });

}

function EliminarGastoProyectoExtension(id_creargasto, id_partida) {
    let urlEliminar = urlController + "Seguimiento_CrearGasto/DeleteSeguimiento_CrearGasto?id_creargasto=" + id_creargasto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoExtensionFinancieroGastosPorPartida(id_partida);
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

function GenerarPagoGastoProyectoExtension(idproyecto, id_creargasto, rubro, descripciongasto, prestador, descripcion, id_partida ) {    
    $("#spanProyectoExtensionPagoIdGasto")[0].innerText = id_creargasto;
    $("#spanProyectoExtensionPagoIdProyecto")[0].innerText = idproyecto;
    $('#LabeldvAplicarPagoProyectoExtensionFinanciero')[0].innerText = 'Datos para aplicar Pago ' + descripcion;
    $("#spanProyectoExtensionPagoGastoIdPartida")[0].innerText = id_partida;    

    $('#txtProyectoExtensionPagoNombreRubro').val(rubro); 
    $('#txtProyectoExtensionPagoPrestador').val(prestador); 
    $('#txtProyectoExtensionPagoDescrGasto').val(descripciongasto); 

    LoadSemestreSelect('cboProyectoExtensionPagoPeriodo',false);
    
    $('#dtProyectoExtensionPagoFecha').val(getFechaActual());
    $('#nmProyectoExtensionPagoValor').val('0');
    $('#nmProyectoExtensionPagoTotal').val('0');
    $('#txtProyectoExtensionPagoOrpa').val('');
    $('#txtProyectoExtensionPagoEgreso').val('');
    $('#txtProyectoExtensionPagoNotas').val('');

    removeValidationFormByForm('formProyectoExtensionFinancieroAplicarPago');    

    $('#cboProyectoExtensionPagoPeriodo').select2();

    $("#dvVolverTablaProyectoExtensionDesdeFinanciero").addClass("ocultar");    
    $("#tableProyectoExtensionFinanciero").addClass("ocultar");    
    $("#dvAplicarPagoProyectoExtensionFinanciero").removeClass("ocultar");            
}

function VolverTablaGastosProyectoExtensionFinancieroDesdePago() {
    if ($('#cboProyectoExtensionPagoPeriodo').data('select2')) {
        $('#cboProyectoExtensionPagoPeriodo').select2('destroy');        
      }    

    $("#dvAplicarPagoProyectoExtensionFinanciero").addClass("ocultar");    
    $("#tableProyectoExtensionFinanciero").removeClass("ocultar");            
    $("#dvVolverTablaProyectoExtensionDesdeFinanciero").removeClass("ocultar");    
}


function ValidatePostUpdateProyectoExtensionFinancieroPagoGasto(formF) {
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
                     AddUpdateProyectoExtensionFinancieroPagoGasto();
            }
        }
    }    

}

function AddUpdateProyectoExtensionFinancieroPagoGasto() {
    var objData = new Object();
    let urlUpdate = urlController + "Seguimiento_AplicarPago/UpdateSeguimiento_AplicarPago";
    
    let valorneto = $('#nmProyectoExtensionPagoValor').val();
    let nmr = valorneto.replace(/,/g, ""); 
    let valorCampoToInt = parseInt(nmr);

    
    objData.id_aplicarpago = undefined;
    objData.id_creargasto = $("#spanProyectoExtensionPagoIdGasto")[0].innerText;
    objData.id_asignacionproyecto = $("#spanProyectoExtensionPagoIdProyecto")[0].innerText;
    objData.fecha = $('#dtProyectoExtensionPagoFecha').val();
    objData.orpa = $('#txtProyectoExtensionPagoOrpa').val();    
    objData.cp_egr = $('#txtProyectoExtensionPagoEgreso').val();    
    objData.id_semestre = $("#cboProyectoExtensionPagoPeriodo").val();
    objData.valorneto = valorCampoToInt;


    objData.notas = $('#txtProyectoExtensionPagoNotas').val();    
        
    if (objData.id_aplicarpago == undefined) {
        urlUpdate = urlController + "Seguimiento_AplicarPago/InsertSeguimiento_AplicarPago";
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

            if ($('#cboProyectoExtensionPagoPeriodo').data('select2')) {
                $('#cboProyectoExtensionPagoPeriodo').select2('destroy');        
              }    
            
            $("#dvAplicarPagoProyectoExtensionFinanciero").addClass("ocultar");    
            $("#tableProyectoExtensionFinanciero").removeClass("ocultar");            
            $("#dvVolverTablaProyectoExtensionDesdeFinanciero").removeClass("ocultar");    

            ShowModalDialog('Pago aplicado correctamente', false, 'success', '', 0);
          
            RefreshDataTableProyectoExtensionFinancieroGastosPorPartida($("#spanProyectoExtensionPagoGastoIdPartida")[0].innerText);
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

function ValorTotalPago4xmil(inputorigen, inputdestino) {
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto);
    let valorimpuesto = valorneto * 4 / 1000;
    let valortotal = valorneto + valorimpuesto;
    $('#' + inputdestino).val(valortotal);   
}

function GenerarExcelProyectoExtensionFinanciero(){
    let urlExcel = urlController + "Proyectos_AsignacionProyecto/ExcelProyectos_AsignacionProyecto?id_asignacionproyecto=" + $("#spanIdProyectoExtension")[0].innerText;
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

// ============================================================
// MODAL CREAR CONTRATISTA
// ============================================================

function AbrirModalNuevoContratista() {
    _CargarCombosModalContratista().then(function () {
        _InicializaCamposModalContratista();
        _AddSelect2ModalContratista();
        removeValidationFormByForm('formModalCrearContratista');
        new bootstrap.Modal(document.getElementById('ModalCrearContratista')).show();
    });
}

function _CargarCombosModalContratista() {
    var promises = [];
    promises.push(LoadTipoPersonaSelect('mcpNaturaleza', true));
    promises.push(LoadTipoEntidadSelect('mcpTipoEntidad', true));
    promises.push(LoadTipoDocumentoSelect('mcpTipoDocumento', true));
    promises.push(LoadPersonaGeneroSelect('mcpGenero', true));
    promises.push(LoadDependenciaSelectNulo('mcpDependencia', true));
    promises.push(LoadPersonaTipoServicioSelect('mcpTipoServicio', true));
    promises.push(LoadPersonaFormacionSelect('mcpFormacion', true));
    promises.push(LoadPersonaTituloAltoSelect('mcpTituloAlto', true));
    promises.push(LoadPersonaCalificacionSelect('mcpCalificacion', true));
    promises.push(LoadPersonaTipoEvaluadorSelect('mcpTipoEvaluador', true));
    return Promise.all(promises);
}

function _InicializaCamposModalContratista() {
    $('#mcpNaturaleza').select2().val('').trigger('change');
    $('#mcpTipoEntidad').select2().val('').trigger('change');
    $('#mcpTipoDocumento').select2().val('').trigger('change');
    $('#mcpGenero').select2().val('').trigger('change');
    $('#mcpDependencia').select2().val('').trigger('change');
    $('#mcpTipoServicio').select2().val([]).trigger('change');
    $('#mcpFormacion').select2().val('').trigger('change');
    $('#mcpTituloAlto').select2().val('').trigger('change');
    $('#mcpCalificacion').select2().val('').trigger('change');
    $('#mcpTipoEvaluador').select2().val('').trigger('change');
    $('#mcpNumIdentificacion').val('');
    $('#mcpNombre').val('');
    $('#mcpNacionalidad').val('');
    $('#mcpTelefono').val('');
    $('#mcpCelular').val('');
    $('#mcpDireccion').val('');
    $('#mcpCiudad').val('');
    $('#mcpCorreo').val('');
    $('#mcpInstitucion').val('');
    $('#mcpCargo').val('');
    $('#mcpAreaInteres').val('');
    $('#mcpContrato').val('');
    $('#mcpPerfil').val('');
    $('#mcpTituloPosgrado').val('');
    $('#mcpObservaciones').val('');
    $('#mcpChkEvaluador').prop('checked', false);
    $('#mcpCvlac').val('');
    _EnableDatosEvaluadorMcp();
}

function _AddSelect2ModalContratista() {
    var parent = $('#ModalCrearContratista');
    $('#mcpNaturaleza').select2({ dropdownParent: parent });
    $('#mcpTipoEntidad').select2({ dropdownParent: parent });
    $('#mcpTipoDocumento').select2({ dropdownParent: parent });
    $('#mcpGenero').select2({ dropdownParent: parent });
    $('#mcpDependencia').select2({ dropdownParent: parent });
    $('#mcpTipoServicio').select2({ multiple: true, dropdownParent: parent });
    $('#mcpFormacion').select2({ dropdownParent: parent });
    $('#mcpTituloAlto').select2({ dropdownParent: parent });
    $('#mcpCalificacion').select2({ dropdownParent: parent });
    $('#mcpTipoEvaluador').select2({ dropdownParent: parent });
}

function _EnableDatosEvaluadorMcp() {
    document.getElementById('mcpTipoEvaluador').disabled = !$('#mcpChkEvaluador').is(':checked');
    document.getElementById('mcpCvlac').disabled = !$('#mcpChkEvaluador').is(':checked');
}

function GuardarNuevoContratista() {
    validateTextXSSLastButtonByForm('formModalCrearContratista');
    var formV = $('#formModalCrearContratista');
    if (formV[0].checkValidity() === false) { $(formV).addClass('was-validated'); return; }
    if (checkValidityXSS === false) { $(formV).addClass('was-validated'); return; }
    if (checkValiditySelect === false) { $(formV).addClass('was-validated'); return; }
    _InsertarContratistaDesdeModal();
}

function _InsertarContratistaDesdeModal() {
    var obj = {};
    obj.id_tipodocumento   = $('#mcpTipoDocumento').val();
    obj.id_tipopersona     = $('#mcpNaturaleza').val();
    obj.numidentificacion  = $('#mcpNumIdentificacion').val();
    obj.nacionalidad       = $('#mcpNacionalidad').val();
    obj.id_genero          = ($('#mcpGenero').val() == '') ? undefined : $('#mcpGenero').val();
    obj.id_tipoentidad     = $('#mcpTipoEntidad').val();
    obj.nombrecompleto     = $('#mcpNombre').val();
    obj.direccion1         = $('#mcpDireccion').val();
    obj.telefono           = $('#mcpTelefono').val();
    obj.celular            = $('#mcpCelular').val();
    obj.correo1            = $('#mcpCorreo').val();
    obj.institucion        = $('#mcpInstitucion').val();
    obj.cargo              = $('#mcpCargo').val();
    obj.id_tiposervicio    = $('#mcpTipoServicio').val().toString();
    obj.ciudad             = $('#mcpCiudad').val();
    obj.id_depend          = ($('#mcpDependencia').val() == '') ? undefined : $('#mcpDependencia').val();
    obj.areainteres        = $('#mcpAreaInteres').val();
    obj.enlacecvlac        = $('#mcpContrato').val();
    obj.id_formacion       = ($('#mcpFormacion').val() == '') ? undefined : $('#mcpFormacion').val();
    obj.id_tituloalto      = ($('#mcpTituloAlto').val() == '') ? undefined : $('#mcpTituloAlto').val();
    obj.tituloposgrados    = $('#mcpTituloPosgrado').val();
    obj.perfil             = $('#mcpPerfil').val();
    obj.id_calificacion    = ($('#mcpCalificacion').val() == '') ? undefined : $('#mcpCalificacion').val();
    obj.evaluadorpublicacion     = $('#mcpChkEvaluador').is(':checked');
    obj.evaluadorinternoexterno  = ($('#mcpTipoEvaluador').val() == '') ? undefined : $('#mcpTipoEvaluador').val();
    obj.evaluadorminciencias     = $('#mcpCvlac').val();
    obj.observaciones            = $('#mcpObservaciones').val();

    StartLoader();
    fetch(urlController + 'Persona/InsertPersona', {
        method: 'POST',
        body: JSON.stringify(obj),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario': sessionStorage.getItem('usersession') }
    })
    .then(r => r.json())
    .then(data => {
        FinalizeLoader();
        if (data.Ok) {
            var nuevoId = data.Data;
            bootstrap.Modal.getInstance(document.getElementById('ModalCrearContratista')).hide();
            LoadPrestadorServicio('cboProyectoExtensionGastoPrestador', true).then(function () {
                if (nuevoId) {
                    $('#cboProyectoExtensionGastoPrestador').select2().val(String(nuevoId)).trigger('change');
                }
            });
        } else {
            ShowModalDialog(data.Message, false, 'warning', '', 0);
        }
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    });
}

function ValorTotalPago4xmilPRJINV(inputorigen, inputdestino) {
    debugger;
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto.replace(/[$,.]/g,'')); 
    let valorimpuesto = valorneto * 4 / 1000;
    valorimpuesto = Math.round(valorimpuesto);
    let valortotal = valorneto + valorimpuesto;
    //$('#' + inputdestino).val(valortotal);
    $('#' + inputdestino).val(valortotal.toLocaleString('en-US'));   
}