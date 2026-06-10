$(document).ready(function () {
    InicializaFinancieroProyectoInvestigacionform();

    // Apply currency formatting
    $("input[data-type='currency']").on({
        keyup: function() {
            formatCurrency($(this));
        },
        blur: function() { 
            formatCurrency($(this), "blur");
        }
    });

    // Format number with commas
    function formatNumber(n) {
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }


    // Currency format for inputs
    function formatCurrency(input, blur) { 
        var input_val = input.val();
        if (input_val === "") { return; }

        var original_len = input_val.length;
        var caret_pos = input.prop("selectionStart");
        
        if (input_val.indexOf(".") >= 0) {
            var decimal_pos = input_val.indexOf(".");
            var left_side = input_val.substring(0, decimal_pos);
            var right_side = input_val.substring(decimal_pos);
            left_side = formatNumber(left_side);
            right_side = formatNumber(right_side);
            if (blur === "blur") {
                right_side += "00";
            }
            right_side = right_side.substring(0, 2);
            input_val = "$" + left_side;
        } else {
            input_val = formatNumber(input_val);
            if (blur === "blur") {
                input_val;
            }
        }
        
        input.val(input_val);
        var updated_len = input_val.length;
        caret_pos = updated_len - original_len + caret_pos;
        input[0].setSelectionRange(caret_pos, caret_pos);
    }

    // Apply colorization and set up observer on the initial table
    const initialTableSelector = '#tableSelector'; // Adjust this to your table's selector
    colorizeTableRows(initialTableSelector);
    observeTableChanges(initialTableSelector);
});

// Function to colorize the table rows
function colorizeTableRows(tableSelector) {
    const table = document.querySelector(tableSelector + " tbody");

    if (!table) {
        console.log("Table not found, check the selector or ensure it's rendered.");
        return;
    }

    // Iterate over the table rows
    table.querySelectorAll("tr").forEach((row) => {
        const numCells = row.cells.length;

        if (numCells >= 12) { // Adjust this based on your table structure
            const valorTotalCell = row.cells[9];   // Index 9 corresponds to the 10th cell
            const valorPagadoCell = row.cells[11]; // Index 11 corresponds to the 12th cell

            const valorTotal = parseFloat(valorTotalCell.textContent.replace(/[^\d.-]/g, '')) || 0;
            const valorPagado = parseFloat(valorPagadoCell.textContent.replace(/[^\d.-]/g, '')) || 0;

            row.style.backgroundColor = '';

            if (valorPagado === 0) {
                row.style.backgroundColor = '#f8d7da'; // Red
            } else if (valorPagado < valorTotal) {
                row.style.backgroundColor = '#fff3cd'; // Yellow
            } else if (valorPagado === valorTotal) {
                row.style.backgroundColor = '#d4edda'; // Green
            }
        }
    });
}

// Function to observe changes in the table body and apply colorization
function observeTableChanges(tableSelector) {
    const tableBody = document.querySelector(tableSelector + ' tbody');

    if (!tableBody) {
        console.log("Table body not found, check the selector or ensure it's rendered.");
        return;
    }

    const observer = new MutationObserver(function(mutations) {
        mutations.forEach(function(mutation) {
            if (mutation.type === 'childList') {
                colorizeTableRows(tableSelector);
            }
        });
    });

    observer.observe(tableBody, {
        childList: true,
        subtree: true
    });
}

// Function to handle tab click and apply colorization when switching tabs
function onclickTabPRJINVFin(idpagina, id_partida) {
    nombreItem = idpagina;
    var idTab = "#tab" + idpagina;
    let idDiv = "dvCont" + idpagina;
    let sNombreHtml = 'proyectoinvestigaciontabla' + idpagina + '.html'
    let urledit = '/Pages/investigacion/' + sNombreHtml;
    var tabExists = $("#dvTabsProyectoInvestigacionFinanciero").find(idTab);

    if (tabExists.length > 0) {
        StartLoader();

        if (!ExisteDivEdicionDatos(idDiv)) {
            CrearDivEdicionDatos(urledit, idDiv);
        } else {
            RefreshDataTableProyectoInvestigacionFinancieroGastosPorPartida(id_partida);
        }

        $("#tableProyectoInvestigacionFinanciero ul li .nav-link.tabPrin").removeClass('active show');
        $("#tableProyectoInvestigacionFinanciero div .tab-pane.tabPrin").removeClass('active show');

        $("#tableProyectoInvestigacionFinanciero ul li #nav" + idpagina).addClass('active show');
        $("#tableProyectoInvestigacionFinanciero div #tab" + idpagina).addClass('active show');

        // Apply colorization after the table content is loaded
        setTimeout(() => {
            const tableSelector = `#tab${idpagina} table`;

            // Apply colorization immediately
            colorizeTableRows(tableSelector);

            // Set up MutationObserver to detect changes in the table body
            observeTableChanges(tableSelector);
        }, 500); // Adjust the delay if necessary

        FinalizeLoader();
        return;
    }
}



function CargarResolucionesProyectoInvestigacion(id_crearproyecto) {
    var flagSeleccionCorrecta = false;  // Flag para evitar reescribir la selección

    $.ajax({
        url: urlController + "Investigacion_Resolucion/GetResolucionesByProyecto",
        type: 'GET',
        data: { id_crearproyecto: id_crearproyecto },
        success: function (data) {
            var select = $('#cboProyectoInvestigacionGastoResolucion');
            select.empty();
            
            console.log("Resoluciones recibidas del backend:", data);
            
            data.forEach(function (resolucion) {
                select.append(`<option value="${resolucion.id_proyectoresolucion}">${resolucion.numresolucion}</option>`);
            });

            // Resolución seleccionada
            var resolucionSeleccionada = $('#spanProyectoInvestigacionid_investigaciongasto').data('resolucion-id'); // Usar el id correcto
            console.log("Resolución seleccionada enviada:", resolucionSeleccionada);

            if (resolucionSeleccionada) {
                console.log("Valor actual del select antes de seleccionar:", select.val());

                // Recorremos las opciones para verificar qué valores existen
                select.find('option').each(function () {
                    console.log("Valor de opción:", $(this).val(), " - Texto:", $(this).text());
                });

                // Buscar y seleccionar la resolución por id_proyectoresolucion
                var encontrado = false;
                select.find('option').each(function () {
                    if ($(this).val() == resolucionSeleccionada) {
                        $(this).prop('selected', true);
                        encontrado = true;
                        flagSeleccionCorrecta = true;  // Actualizamos el flag
                        return false;  // Romper el loop
                    }
                });

                if (!encontrado) {
                    console.log("La resolución seleccionada no está en la lista de resoluciones disponibles.");
                } else {
                    console.log("Resolución seleccionada correctamente:", select.val());
                }

                select.trigger("change");  // Actualizar el valor del select
            } else {
                console.log("No se recibió un ID de resolución válido.");
            }
            
            console.log("Valor actual del select después de intentar seleccionar:", select.val());
        },
        error: function () {
            alert("No se han asignado resoluciones a este proyecto, debe asignar primero una");
        }
    });
}

function VolverTablaProyectoInvestigacionDesdeControlFinancieroForm() {
    $("#dvProyectoInvestigacionTablaFinanciero").addClass("ocultar");    
    $("#dvProyectoInvestigacionTable").removeClass("ocultar");

}



function InicializaFinancieroProyectoInvestigacionform() {    
    $("#txtHermesPRJINVControlFinanciero").val($("#spanHermesProyectoInvestigacion")[0].innerText);
    $("#txtQuipuPRJINVControlFinanciero").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
    $("#txtNombrePRJINVControlFinanciero").val($("#spanNombreProyectoInvestigacion")[0].innerText);

    onclickTabPRJINVFin('PRJINVFinIngresos', 0);

    $("#dvProyectoInvestigacionTable").addClass("ocultar");    
    $("#dvProyectoInvestigacionTablaFinanciero").removeClass("ocultar");

    // Call colorizeTableRows() after the table is fully initialized and populated with data
    colorizeTableRows();
}


function RefreshDataTableProyectoInvestigacionFinancieroGastosPorPartida(id_partida) {


    //DESEMBOLSOS
    if (id_partida == 0) {
        RefreshDataTableProyectoInvestigacionFinancieroDesembolsos();
        LoadDataAportesProyectoInvestigacion();
    }

    //GASTOS DE PERSONAL
    if (id_partida == 1) {
        RefreshDataTableProyectoInvestigacionFinancieroGastosPersonal();
    }

    //ADQUISICIÓN BIENES
    if (id_partida == 2) {
        RefreshDataTableProyectoInvestigacionFinancieroGastosBienes();        
    }

    //ADQUISICIÓN SERVICIOS
    if (id_partida == 3) {
        RefreshDataTableProyectoInvestigacionFinancieroGastosServicios();
    }

    //IMPUESTOS, CONTRIBUCIONES Y MULTAS
    if (id_partida == 4) {
        RefreshDataTableProyectoInvestigacionFinancieroGastosImpuestos();
    }

    //TRANSFERENCIAS ENTRE FONDOS SIN CONTRAPRESTACIÓN
    if (id_partida == 5) {
        RefreshDataTableProyectoInvestigacionFinancieroGastosTransferencias();
    }

    //PAGOS REALIZADOS
    if (id_partida == 6) {
        InicializaFinancieroProyectoInvestigacionListaPagosform();
    }

}

function CargarConceptosProyectoInvestigacionCrearGasto() {    
    let idRubro = $("#cboProyectoInvestigacionGastoRubro").val();

    if (idRubro != null){
        LoadSeguimientoConceptoByRubro('cboProyectoInvestigacionGastoConcepto', false, idRubro);
    }
    
    if ($('#cboProyectoInvestigacionGastoConcepto').data('select2')) {
        $('#cboProyectoInvestigacionGastoConcepto').select2('destroy');        
      }                

    $('#cboProyectoInvestigacionGastoConcepto').select2().val('').trigger("change");
    $('#cboProyectoInvestigacionGastoConcepto').select2();

}



function CrearGasto_ProyectoInvestigacion(id_partida) {
    $("#spanProyectoInvestigacionid_investigaciongasto")[0].innerText = '';
    $("#spanProyectoInvestigacionGastoIdPartida")[0].innerText = id_partida;

    CargarCombosProyectoInvestigacionCrearGasto(id_partida);

    InicializaCamposProyectoInvestigacionCrearGasto();

    AddSelect2DivProyectoInvestigacionCrearGasto();

    removeValidationFormByForm('formProyectoInvestigacionFinancieroCrearGasto');

    $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").addClass("ocultar");
    $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");
    $("#dvCrearGastoProyectoInvestigacionFinanciero").removeClass("ocultar");

    // Obtener el ID del proyecto desde un elemento del DOM
    var id_crearproyecto = $("#spanIdProyectoInvestigacion").text(); // Asegúrate de que este sea el ID correcto

    if (id_crearproyecto) {
        // Llamar a la función solo si el id_crearproyecto es válido
        CargarResolucionesProyectoInvestigacion(id_crearproyecto);
    } else {
        console.error("No se encontró el ID del proyecto. Verifica que el elemento tenga el ID correcto.");
    }
}





function EditarGasto_ProyectoInvestigacion(id_investigaciongasto, id_partida) {
    $("#spanProyectoInvestigacionid_investigaciongasto")[0].innerText = id_investigaciongasto;
    $("#spanProyectoInvestigacionGastoIdPartida")[0].innerText = id_partida;
    $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").addClass("ocultar");
    $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");
    $("#dvCrearGastoProyectoInvestigacionFinanciero").removeClass("ocultar");
    $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");

    CargarCombosProyectoInvestigacionCrearGasto(id_partida)
        .then(() => {
            removeValidationFormByForm('formProyectoInvestigacionFinancieroCrearGasto');
            let urlEditaGasto = urlController + "Investigacion_Gasto/GetInvestigacion_GastoDetails?id_investigaciongasto=" + id_investigaciongasto;
            StartLoader();

            fetch(urlEditaGasto, {
                method: 'GET',
                headers: { 'Authorization': 'Bearer ' + TokenIRIS }
            })
                .then(response => response.json())
                .then(data => {
                    if (data.Ok) {
                        let datos = data.Data;
                        AddSelect2DivProyectoInvestigacionCrearGasto();
                        CargarCamposProyectoInvestigacionCrearGasto(datos);

                        // Asegúrate de obtener el id_crearproyecto del objeto de datos (si está disponible)
                        let id_crearproyecto = datos.id_crearproyecto;

                        // Cargar las resoluciones asociadas al proyecto si el id_crearproyecto está presente
                        if (id_crearproyecto) {
                            CargarResolucionesProyectoInvestigacion(id_crearproyecto);
                        } else {
                            console.error("No se encontró el ID del proyecto para cargar las resoluciones.");
                        }

                        FinalizeLoader();
                    } else {
                        FinalizeLoader();
                        ShowModalDialog(data.Message, false, 'warning', '', 0);
                    }
                })
                .catch(err => {
                    FinalizeLoader();
                    ShowModalDialog(err, false, 'error', '', 0);
                });
        });
}


function CargarCombosProyectoInvestigacionCrearGasto(idpartida) {
    let promises_arr = [];
    return new Promise( (resolve, reject) => {

        promises_arr.push(LoadSeguimientoRubroByPartida('cboProyectoInvestigacionGastoRubro', true, idpartida));
        $('#cboProyectoInvestigacionGastoConcepto').empty();
        promises_arr.push(LoadSeguimientoConceptoByRubro('cboProyectoInvestigacionGastoConcepto', false, 1));
        promises_arr.push(LoadPrestadorServicio('cboProyectoInvestigacionGastoPrestador' ,true));
        promises_arr.push(LoadPrestadorVinculoSelect('cboProyectoInvestigacionGastoVinculo', true));    

        Promise.all(promises_arr)
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
    });
}

function InicializaCamposProyectoInvestigacionCrearGasto() {
    $('#txtProyectoInvestigacionGastoNombre').val('');
    $('#nmProyectoInvestigacionGastoTotal').val('0');
    $('#nmProyectoInvestigacionGastoinvgastocuatroxmil').val('');
    $('#dtProyectoInvestigacionGastoFLegalizacion').val(getFechaActual());    
    $('#txtProyectoInvestigacionGastoNorden').val('');  
    $('#txtProyectoInvestigacionGastoTipo').val('');        
    $('#dtProyectoInvestigacionGastoFInicio').val(getFechaActual());
    $('#dtProyectoInvestigacionGastoFFinal').val(getFechaActual());
    $('#txtProyectoInvestigacionGastoEstado').val('');
    $('#txtProyectoInvestigacionGastoObservaciones').val('');
    
    // Añadir la inicialización para "Valor Neto" y "Valor Total"
    $('#nmProyectoInvestigacionPagoValor').val('');  // Inicializar Valor Neto vacío
    $('#txtProyectoInvestigacionPagoTotal').val('');  // Inicializar Valor Total vacío
}


function AddSelect2DivProyectoInvestigacionCrearGasto() {
    $('#cboProyectoInvestigacionGastoRubro').select2();
    $('#cboProyectoInvestigacionGastoPrestador').select2();
    $('#cboProyectoInvestigacionGastoVinculo').select2();
    $('#cboProyectoInvestigacionGastoConcepto').select2();
    $('#cboProyectoInvestigacionGastoResolucion').select2();  // Aplica select2 para el campo Resolución

}

function DestruyeSelectProyectoInvestigacionCrearGasto() {
    if ($('#cboProyectoInvestigacionGastoRubro').data('select2')) {
        $('#cboProyectoInvestigacionGastoRubro').select2('destroy');        
      }    

      if ($('#cboProyectoInvestigacionGastoPrestador').data('select2')) {
        $('#cboProyectoInvestigacionGastoPrestador').select2('destroy');        
      }    

      if ($('#cboProyectoInvestigacionGastoVinculo').data('select2')) {
        $('#cboProyectoInvestigacionGastoVinculo').select2('destroy');        
      }    

      if ($('#cboProyectoInvestigacionGastoConcepto').data('select2')) {
        $('#cboProyectoInvestigacionGastoConcepto').select2('destroy');        
      }    

}

// function CargarCamposProyectoInvestigacionCrearGasto(objdatos) {
    //     debugger;
    
    //     let id_crearproyecto = objdatos.id_crearproyecto;
    
    //     // Llamamos a la función que carga las resoluciones asociadas al proyecto
    //     CargarResolucionesProyectoInvestigacion(id_crearproyecto);
    
    
    //     $('#cboProyectoInvestigacionGastoRubro').select2().val(objdatos.id_rubro).trigger("change");
       
    //     LoadSeguimientoConceptoByRubro('cboProyectoInvestigacionGastoConcepto', false, objdatos.id_rubro);
    
    //     if ($('#cboProyectoInvestigacionGastoConcepto').data('select2')) {
    //         $('#cboProyectoInvestigacionGastoConcepto').select2('destroy');        
    //     }                
    
    //     $('#cboProyectoInvestigacionGastoConcepto').select2().val(objdatos.id_segconcepto).trigger("change");
    //     $('#txtProyectoInvestigacionGastoNombre').val(objdatos.nombregasto);    
    //     $('#cboProyectoInvestigacionGastoPrestador').select2().val(objdatos.id_persona).trigger("change");
    //     $('#cboProyectoInvestigacionGastoVinculo').select2().val(objdatos.id_relacionvinculo).trigger("change");
    //     $('#nmProyectoInvestigacionGastoTotal').val(objdatos.valortotal.toLocaleString('en-US'));
    //     $('#nmProyectoInvestigacionGastoinvgastocuatroxmil').val(objdatos.invgastocuatroxmil.toLocaleString('en-US'));
    //     $('#dtProyectoInvestigacionGastoFLegalizacion').val(objdatos.fechalegalizacionorden.slice(0, 10));
    //     $('#txtProyectoInvestigacionGastoNorden').val(objdatos.numorden);
    //     $('#txtProyectoInvestigacionGastoTipo').val(objdatos.tipo);  
    //     $('#dtProyectoInvestigacionGastoFInicio').val(objdatos.fechainicio.slice(0, 10));
    //     $('#dtProyectoInvestigacionGastoFFinal').val(objdatos.fechafinal.slice(0, 10));
    //     $('#txtProyectoInvestigacionGastoEstado').val(objdatos.estado);
    //     $('#txtProyectoInvestigacionGastoObservaciones').val(objdatos.observaciones);
    //     //$('#cboProyectoInvestigacionGastoResolucion').select2().val(objdatos.id_resolucion).trigger("change");  // Cargar la resolución seleccionada
        
    //      // Asignar el valor de "Valor Neto" (valortotal del JSON)
    //      $('#nmProyectoInvestigacionPagoValor').val(objdatos.valortotal.toLocaleString('en-US'));  // Asignamos valortotal
    
    //      // Asignar el valor de "Valor Total" (Total4mil del JSON)
    //      $('#txtProyectoInvestigacionPagoTotal').val(objdatos.Total4mil.toLocaleString('en-US'));  // Asignamos Total4mil
    
    //      // Cargar la resolución si es que ya hay una asociada
    //     if (objdatos.resolucion_id) {
    //         $('#cboProyectoInvestigacionGastoResolucion').select2().val(objdatos.resolucion_id).trigger("change");
    //     }
    // }

function CargarCamposProyectoInvestigacionCrearGasto(objdatos) {
    debugger;

    let id_crearproyecto = objdatos.id_crearproyecto;
    let resolucion_id = objdatos.resolucion_id;
    console.log("Resolución ID obtenida desde el backend:", resolucion_id);

    // Llamamos a la función que carga las resoluciones asociadas al proyecto y pasamos la resolución seleccionada
    CargarResolucionesProyectoInvestigacion(id_crearproyecto);
    // Guardamos el ID de la resolución en un atributo data para obtenerlo más tarde
    $('#spanProyectoInvestigacionid_investigaciongasto').data('resolucion-id', resolucion_id);
    console.log("Resolución ID almacenada en el span:", $('#spanProyectoInvestigacionid_investigaciongasto').data('resolucion-id'));

    $('#cboProyectoInvestigacionGastoRubro').select2().val(objdatos.id_rubro).trigger("change");
   
    LoadSeguimientoConceptoByRubro('cboProyectoInvestigacionGastoConcepto', false, objdatos.id_rubro);

    if ($('#cboProyectoInvestigacionGastoConcepto').data('select2')) {
        $('#cboProyectoInvestigacionGastoConcepto').select2('destroy');        
    }                

    $('#cboProyectoInvestigacionGastoConcepto').select2().val(objdatos.id_segconcepto).trigger("change");
    $('#txtProyectoInvestigacionGastoNombre').val(objdatos.nombregasto);    
    $('#cboProyectoInvestigacionGastoPrestador').select2().val(objdatos.id_persona).trigger("change");
    $('#cboProyectoInvestigacionGastoVinculo').select2().val(objdatos.id_relacionvinculo).trigger("change");
    $('#nmProyectoInvestigacionGastoTotal').val(objdatos.valortotal.toLocaleString('en-US'));
    $('#nmProyectoInvestigacionGastoinvgastocuatroxmil').val(objdatos.invgastocuatroxmil.toLocaleString('en-US'));
    $('#dtProyectoInvestigacionGastoFLegalizacion').val(objdatos.fechalegalizacionorden.slice(0, 10));
    $('#txtProyectoInvestigacionGastoNorden').val(objdatos.numorden);
    $('#txtProyectoInvestigacionGastoTipo').val(objdatos.tipo);  
    $('#dtProyectoInvestigacionGastoFInicio').val(objdatos.fechainicio.slice(0, 10));
    $('#dtProyectoInvestigacionGastoFFinal').val(objdatos.fechafinal.slice(0, 10));
    $('#txtProyectoInvestigacionGastoEstado').val(objdatos.estado);
    $('#txtProyectoInvestigacionGastoObservaciones').val(objdatos.observaciones);

    // Asignar el valor de "Valor Neto" (valortotal del JSON)
    $('#nmProyectoInvestigacionPagoValor').val(objdatos.valortotal.toLocaleString('en-US'));  // Asignamos valortotal

    // Asignar el valor de "Valor Total" (Total4mil del JSON)
    $('#txtProyectoInvestigacionPagoTotal').val(objdatos.Total4mil.toLocaleString('en-US'));  // Asignamos Total4mil
}

function ValidatePostUpdateProyectoInvestigacionFinancieroCrearGasto(formF) {
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
                     AddUpdateProyectoInvestigacionFinancieroCrearGasto();                    
            }
        }
    }    
}


//CAMBIO ADDA PARA AÑADIR RESOLUCIONES
function AddUpdateProyectoInvestigacionFinancieroCrearGasto() {
    var objData = new Object();
    let urlUpdate = urlController + "Investigacion_Gasto/UpdateInvestigacion_Gasto";
    
    objData.id_investigaciongasto = ($("#spanProyectoInvestigacionid_investigaciongasto")[0].innerText == '') ? undefined : $("#spanProyectoInvestigacionid_investigaciongasto")[0].innerText;
    objData.id_crearproyecto = $("#spanIdProyectoInvestigacion")[0].innerText;
    objData.id_partida = $("#spanProyectoInvestigacionGastoIdPartida")[0].innerText;    
    objData.id_segconcepto = $("#cboProyectoInvestigacionGastoConcepto").val();
    objData.id_rubro = $("#cboProyectoInvestigacionGastoRubro").val();
    objData.nombregasto = $('#txtProyectoInvestigacionGastoNombre').val();
    objData.id_persona = $("#cboProyectoInvestigacionGastoPrestador").val();
    objData.id_relacionvinculo = $("#cboProyectoInvestigacionGastoVinculo").val();
    // objData.valortotal = $('#nmProyectoInvestigacionGastoTotal').val();
    // objData.invgastocuatroxmil = $('#nmProyectoInvestigacionGastoinvgastocuatroxmil').val();

    objData.valortotal = $('#nmProyectoInvestigacionPagoValor').val();  // Correcto para Valor Total
    objData.invgastocuatroxmil = $('#txtProyectoInvestigacionPagoTotal').val();  // Correcto para Valor NetotxtProyectoInvestigacionPagoTotal
    objData.fechalegalizacionorden = $('#dtProyectoInvestigacionGastoFInicio').val();
    objData.numorden = $('#txtProyectoInvestigacionGastoNorden').val();
    objData.tipo = $('#txtProyectoInvestigacionGastoTipo').val();
    objData.fechainicio = $('#dtProyectoInvestigacionGastoFInicio').val();
    objData.fechafinal = $('#dtProyectoInvestigacionGastoFFinal').val();
    objData.estado = $('#txtProyectoInvestigacionGastoEstado').val();
    objData.observaciones = $('#txtProyectoInvestigacionGastoObservaciones').val();

    // Añadir el ID de la resolución seleccionada al objeto
    objData.resolucion_id = $("#cboProyectoInvestigacionGastoResolucion").val();  // Aquí enviamos la resolución

    if (objData.id_investigaciongasto == undefined) {
        urlUpdate = urlController + "Investigacion_Gasto/InsertInvestigacion_Gasto";
    }

    // Enviar el objeto al backend
    fetch(urlUpdate, {
        method: 'POST',
        body: JSON.stringify(objData),
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + TokenIRIS, 'Usuario': sessionStorage.getItem('usersession') }
    })
    .then(response => response.json())
    .then(data => {
        console.log('Respuesta del servidor:', data); 
        if (data.Ok) {      
            console.log('Resolucion ID:', data.Data.resolucion_id);     
            FinalizeLoader();
            DestruyeSelectProyectoInvestigacionCrearGasto();    
            
            $("#dvCrearGastoProyectoInvestigacionFinanciero").addClass("ocultar");    
            $("#tableProyectoInvestigacionFinanciero").removeClass("ocultar");
            $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").removeClass("ocultar");    

            RefreshDataTableProyectoInvestigacionFinancieroGastosPorPartida(objData.id_partida);
            return;
        } else {
            FinalizeLoader();
            ShowModalDialog(data.Message, false, 'warning', '', 0);            
            return;
        }            
    })
    .catch(err => {
        FinalizeLoader();
        ShowModalDialog(err, false, 'error', '', 0);
    });      
}



function VolverTablaGastosProyectoInvestigacionFinancieroDesdeEdicion() {
    DestruyeSelectProyectoInvestigacionCrearGasto();    

    $("#dvCrearGastoProyectoInvestigacionFinanciero").addClass("ocultar");    
    $("#tableProyectoInvestigacionFinanciero").removeClass("ocultar");            
    $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").removeClass("ocultar");    

}


function ValidarEliminarGastoProyectoInvestigacion(id_investigaciongasto, id_partida) {
    ShowDialogConfirmacion('','Seguro de eliminar gasto ?', 'Sí, eliminar', 'No, cancelar')
        .then(borrar => {
            if (borrar) {
                EliminarGastoProyectoInvestigacion(id_investigaciongasto, id_partida);
            }
        });

}

function EliminarGastoProyectoInvestigacion(id_investigaciongasto, id_partida) {
    let urlEliminar = urlController + "Investigacion_Gasto/DeleteInvestigacion_Gasto?id_investigaciongasto=" + id_investigaciongasto;
    StartLoader();

    fetch(urlEliminar, {
        method: 'DELETE',
        headers: { 'Authorization': 'Bearer ' + TokenIRIS }
    })
    .then(response => response.json())
      .then(data => {
        if (data.Ok) {           
            FinalizeLoader();
            RefreshDataTableProyectoInvestigacionFinancieroGastosPorPartida(id_partida);
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

function GenerarPagoGastoProyectoInvestigacion(idproyecto, id_investigaciongasto, rubro, descripciongasto, prestador, descripcion, id_partida ) {    
    $("#spanProyectoInvestigacionPagoIdGasto")[0].innerText = id_investigaciongasto;
    $("#spanProyectoInvestigacionPagoIdProyecto")[0].innerText = idproyecto;
    $('#LabeldvAplicarPagoProyectoInvestigacionFinanciero')[0].innerText = 'Datos para aplicar Pago ' + descripcion;
    $("#spanProyectoInvestigacionPagoGastoIdPartida")[0].innerText = id_partida;
    
    $('#txtProyectoInvestigacionPagoNombreRubro').val(rubro); 
    $('#txtProyectoInvestigacionPagoPrestador').val(prestador); 
    $('#txtProyectoInvestigacionPagoDescrGasto').val(descripciongasto); 

    LoadSemestreSelect('cboProyectoInvestigacionPagoPeriodo',false);
    
    $('#dtProyectoInvestigacionPagoFecha').val(getFechaActual());
    $('#nmProyectoInvestigacionPagoValor1').val('');
    $('#txtProyectoInvestigacionPagoTotal1').val('');

    $('#txtProyectoInvestigacionPagoOrpa').val('');
    $('#txtProyectoInvestigacionPagoEgreso').val('');
    $('#txtProyectoInvestigacionPagoNotas').val('');

    removeValidationFormByForm('formProyectoInvestigacionFinancieroAplicarPago');    

    $('#cboProyectoInvestigacionPagoPeriodo').select2();

    $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").addClass("ocultar");    
    $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");    
    $("#dvAplicarPagoProyectoInvestigacionFinanciero").removeClass("ocultar");            
}

function VolverTablaGastosProyectoInvestigacionFinancieroDesdePago() {
    if ($('#cboProyectoInvestigacionPagoPeriodo').data('select2')) {
        $('#cboProyectoInvestigacionPagoPeriodo').select2('destroy');        
      }    

    $("#dvAplicarPagoProyectoInvestigacionFinanciero").addClass("ocultar");    
    $("#tableProyectoInvestigacionFinanciero").removeClass("ocultar");            
    $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").removeClass("ocultar");    
}


function ValidatePostUpdateProyectoInvestigacionFinancieroPagoGasto(formF) {
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
                     AddUpdateProyectoInvestigacionFinancieroPagoGasto();
            }
        }
    }    

}

function AddUpdateProyectoInvestigacionFinancieroPagoGasto() {
    var objData = new Object();
    let urlUpdate = urlController + "Investigacion_Aplicarpago/UpdateInvestigacion_Aplicarpago";
    
    objData.id_investigacionpago = undefined;
    objData.id_investigaciongasto = $("#spanProyectoInvestigacionPagoIdGasto")[0].innerText;
    objData.id_crearproyecto = $("#spanIdProyectoInvestigacion")[0].innerText;
    objData.fechapago = $('#dtProyectoInvestigacionPagoFecha').val();
    objData.orpa = $('#txtProyectoInvestigacionPagoOrpa').val();    
    objData.cp_egr = $('#txtProyectoInvestigacionPagoEgreso').val();    
    objData.id_semestre = $("#cboProyectoInvestigacionPagoPeriodo").val();
    objData.valorneto = $('#nmProyectoInvestigacionPagoValor1').val();
    objData.notas = $('#txtProyectoInvestigacionPagoNotas').val();    

    if (objData.id_investigacionpago == undefined) {
        urlUpdate = urlController + "Investigacion_Aplicarpago/InsertInvestigacion_Aplicarpago";
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
            
            if ($('#cboProyectoInvestigacionPagoPeriodo').data('select2')) {
                $('#cboProyectoInvestigacionPagoPeriodo').select2('destroy');        
              }    
            
            $("#dvAplicarPagoProyectoInvestigacionFinanciero").addClass("ocultar");    
            $("#tableProyectoInvestigacionFinanciero").removeClass("ocultar");            
            $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").removeClass("ocultar");    

            ShowModalDialog('Pago aplicado correctamente', false, 'success', '', 0);

            RefreshDataTableProyectoInvestigacionFinancieroGastosPorPartida($("#spanProyectoInvestigacionPagoGastoIdPartida")[0].innerText);
          
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

function ValorTotalPago4xmilPRJINV(inputorigen, inputdestino) {
    console.log("Función ValorTotalPago4xmilPRJINV llamada");
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto.replace(/[$,.]/g,'')); 
    let valorimpuesto = valorneto * 4 / 1000;
    valorimpuesto = Math.round(valorimpuesto);
    let valortotal = valorneto + valorimpuesto;
    //$('#' + inputdestino).val(valortotal);
    $('#' + inputdestino).val(valortotal.toLocaleString('en-US'));   
    console.log (valortotal);
}

function ValorTotalPago4xmilPRJINV1(inputorigen, inputdestino) {
    console.log("Función ValorTotalPago4xmilPRJINV1 llamada");
    let valorneto = $('#' + inputorigen).val();
    valorneto = Number(valorneto.replace(/[$,.]/g,'')); 
    let valorimpuesto = valorneto * 4 / 1000;
    valorimpuesto = Math.round(valorimpuesto);
    let valortotal = valorneto + valorimpuesto;
    //$('#' + inputdestino).val(valortotal);
    $('#' + inputdestino).val(valortotal.toLocaleString('en-US'));   
    console.log (valortotal);
}

function GenerarExcelProyectoInvestigacionFinanciero(){
    let urlExcel = urlController + "Investigacion_CrearProyecto/ExcelInvestigacion_CrearProyecto?id_crearproyecto=" + $("#spanIdProyectoInvestigacion")[0].innerText;
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


function ActualizarIdentificacion() {
    const select = document.getElementById('cboProyectoInvestigacionGastoPrestador');
    const selectedOption = select.options[select.selectedIndex];
    
    const identificacion = selectedOption.getAttribute('data-identificacion');
    
    document.getElementById('txtProyectoInvestigacionGastoIdentificacion').value = identificacion || '';
}




// function CargarCamposProyectoInvestigacionCrearGasto(objdatos) {
//     debugger;

//     let id_crearproyecto = objdatos.id_crearproyecto;

//     // Llamamos a la función que carga las resoluciones asociadas al proyecto
//     CargarResolucionesProyectoInvestigacion(id_crearproyecto);


//     $('#cboProyectoInvestigacionGastoRubro').select2().val(objdatos.id_rubro).trigger("change");
   
//     LoadSeguimientoConceptoByRubro('cboProyectoInvestigacionGastoConcepto', false, objdatos.id_rubro);

//     if ($('#cboProyectoInvestigacionGastoConcepto').data('select2')) {
//         $('#cboProyectoInvestigacionGastoConcepto').select2('destroy');        
//     }                

//     $('#cboProyectoInvestigacionGastoConcepto').select2().val(objdatos.id_segconcepto).trigger("change");
//     $('#txtProyectoInvestigacionGastoNombre').val(objdatos.nombregasto);    
//     $('#cboProyectoInvestigacionGastoPrestador').select2().val(objdatos.id_persona).trigger("change");
//     $('#cboProyectoInvestigacionGastoVinculo').select2().val(objdatos.id_relacionvinculo).trigger("change");
//     $('#nmProyectoInvestigacionGastoTotal').val(objdatos.valortotal.toLocaleString('en-US'));
//     $('#nmProyectoInvestigacionGastoinvgastocuatroxmil').val(objdatos.invgastocuatroxmil.toLocaleString('en-US'));
//     $('#dtProyectoInvestigacionGastoFLegalizacion').val(objdatos.fechalegalizacionorden.slice(0, 10));
//     $('#txtProyectoInvestigacionGastoNorden').val(objdatos.numorden);
//     $('#txtProyectoInvestigacionGastoTipo').val(objdatos.tipo);  
//     $('#dtProyectoInvestigacionGastoFInicio').val(objdatos.fechainicio.slice(0, 10));
//     $('#dtProyectoInvestigacionGastoFFinal').val(objdatos.fechafinal.slice(0, 10));
//     $('#txtProyectoInvestigacionGastoEstado').val(objdatos.estado);
//     $('#txtProyectoInvestigacionGastoObservaciones').val(objdatos.observaciones);
//     //$('#cboProyectoInvestigacionGastoResolucion').select2().val(objdatos.id_resolucion).trigger("change");  // Cargar la resolución seleccionada
    
//      // Asignar el valor de "Valor Neto" (valortotal del JSON)
//      $('#nmProyectoInvestigacionPagoValor').val(objdatos.valortotal.toLocaleString('en-US'));  // Asignamos valortotal

//      // Asignar el valor de "Valor Total" (Total4mil del JSON)
//      $('#txtProyectoInvestigacionPagoTotal').val(objdatos.Total4mil.toLocaleString('en-US'));  // Asignamos Total4mil

//      // Cargar la resolución si es que ya hay una asociada
//     if (objdatos.resolucion_id) {
//         $('#cboProyectoInvestigacionGastoResolucion').select2().val(objdatos.resolucion_id).trigger("change");
//     }
// }


//  function EditarGasto_ProyectoInvestigacion(id_investigaciongasto, id_partida) {
//     $("#spanProyectoInvestigacionid_investigaciongasto")[0].innerText = id_investigaciongasto;
//     $("#spanProyectoInvestigacionGastoIdPartida")[0].innerText = id_partida;
//     $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").addClass("ocultar");
//     $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");
//     $("#dvCrearGastoProyectoInvestigacionFinanciero").removeClass("ocultar");
//     $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");

//        CargarCombosProyectoInvestigacionCrearGasto(id_partida)
//        .then(()=>{
//         removeValidationFormByForm('formProyectoInvestigacionFinancieroCrearGasto');
//         let urlEditaGasto = urlController + "Investigacion_Gasto/GetInvestigacion_GastoDetails?id_investigaciongasto=" + id_investigaciongasto;
//         StartLoader();
//         fetch(urlEditaGasto, {
//             method: 'GET',
//             headers: { 'Authorization': 'Bearer ' + TokenIRIS }
//         })
//             .then(response => response.json())
//             .then(data => {
//                 if (data.Ok) {
//                     let datos = data.Data;
//                     AddSelect2DivProyectoInvestigacionCrearGasto();
//                     CargarCamposProyectoInvestigacionCrearGasto(datos);
//                     FinalizeLoader();
    
                   
//                     return;
//                 }
//                 else {
//                     FinalizeLoader();
//                     ShowModalDialog(data.Message, false, 'warning', '', 0);
//                     return;
//                 }
//             })
//             .catch(err => {
//                 FinalizeLoader();
//                 ShowModalDialog(err, false, 'error', '', 0);
//             });
//         })
// }

//CAMBIO ADDA PARA TRAER RESOLUCIONES
// function CargarResolucionesProyectoInvestigacion(id_crearproyecto) {
//     // Realizamos una llamada AJAX para obtener las resoluciones asociadas a este proyecto
//     $.ajax({
//         url: urlController + "Investigacion_Resolucion/GetResolucionesByProyecto", // URL corregida
//         type: 'GET',
//         data: { id_crearproyecto: id_crearproyecto },  // Pasamos el parámetro como query string
//         success: function (data) {
//             var select = $('#cboProyectoInvestigacionGastoResolucion');
//             select.empty(); // Limpiamos las opciones previas
//             data.forEach(function (resolucion) {
//                 select.append(`<option value="${resolucion.id_proyectoresolucion}">${resolucion.numresolucion}</option>`);
//             });
//         },
//         error: function () {
//             alert("No se han asignado resoluciones a este proyecto, debe asignar primero una");
//         }
//     });
    
// }

// function InicializaFinancieroProyectoInvestigacionform() {    
//     $("#txtHermesPRJINVControlFinanciero").val($("#spanHermesProyectoInvestigacion")[0].innerText);
//     $("#txtQuipuPRJINVControlFinanciero").val($("#spanQuipuProyectoInvestigacion")[0].innerText);
//     $("#txtNombrePRJINVControlFinanciero").val($("#spanNombreProyectoInvestigacion")[0].innerText);

//     onclickTabPRJINVFin('PRJINVFinIngresos', 0);

//     $("#dvProyectoInvestigacionTable").addClass("ocultar");    
//     $("#dvProyectoInvestigacionTablaFinanciero").removeClass("ocultar");

//     colorizeTableRows();
// }

// function onclickTabPRJINVFin(idpagina, id_partida){    
//     nombreItem = idpagina;     
//     var idTab = "#tab" + idpagina;
//     let idDiv = "dvCont" + idpagina;
//     let sNombreHtml = 'proyectoinvestigaciontabla' + idpagina + '.html'
//     let urledit = '/Pages/investigacion/' + sNombreHtml; 
//     var tabExists = $("#dvTabsProyectoInvestigacionFinanciero").find(idTab);    
    
//     if (tabExists.length > 0) {
//         StartLoader();

//         if (!ExisteDivEdicionDatos(idDiv)) {
//             CrearDivEdicionDatos(urledit, idDiv);
//         }
//         else {
//             RefreshDataTableProyectoInvestigacionFinancieroGastosPorPartida(id_partida);
//         }

//         $("#tableProyectoInvestigacionFinanciero ul li .nav-link.tabPrin").removeClass('active show');
//         $("#tableProyectoInvestigacionFinanciero div .tab-pane.tabPrin").removeClass('active show');
    
//         $("#tableProyectoInvestigacionFinanciero ul li #nav" + idpagina).addClass('active show');
//         $("#tableProyectoInvestigacionFinanciero div #tab" + idpagina).addClass('active show');       
//         FinalizeLoader();
//         return;
//     }
// }

//CAMBIO ADDA PARA AÑADIR LA RESOLUCIÓN
// function CrearGasto_ProyectoInvestigacion(id_partida) {
//     $("#spanProyectoInvestigacionid_investigaciongasto")[0].innerText = '';
//     $("#spanProyectoInvestigacionGastoIdPartida")[0].innerText = id_partida;    
    

//     CargarCombosProyectoInvestigacionCrearGasto(id_partida);
    
//     InicializaCamposProyectoInvestigacionCrearGasto();

//     AddSelect2DivProyectoInvestigacionCrearGasto();
    
//     removeValidationFormByForm('formProyectoInvestigacionFinancieroCrearGasto');   
    
//     $("#dvVolverTablaProyectoInvestigacionDesdeFinanciero").addClass("ocultar");    
//     $("#tableProyectoInvestigacionFinanciero").addClass("ocultar");    
//     $("#dvCrearGastoProyectoInvestigacionFinanciero").removeClass("ocultar");        
    
//     // Asegúrate de pasar el ID del proyecto aquí
//     var id_crearproyecto = $("#spanIdProyectoInvestigacion").text(); // Si este es el ID correcto
//     CargarResolucionesProyectoInvestigacion(id_crearproyecto); // Llamar a la función para cargar las resoluciones
     
// }
