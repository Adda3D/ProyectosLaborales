
var urlController = "https://iris.unal.edu.co/APIirisunal/";
﻿// ============================================================
// Archivo: Solicitud_Certificado.js
// Descripción: Sincroniza y carga las solicitudes de certificados
// ============================================================

var DataTableSolicitud_Certificado = null;
var DetalleSolicitudCertificadoScriptCargado = false;

$(document).ready(function () {
    SyncTrazabilidadAndLoad();
});

// ============================================================
// Paso 1: Ejecuta la sincronización y luego carga la tabla
// ============================================================
function SyncTrazabilidadAndLoad() {
    ShowModalDialog('Sincronizando solicitudes, por favor espere...', true, 'info', '', 0);

    $.ajax({
        url: urlController + "Solicitud_CertificadoTrazabilidad/SyncTrazabilidad",
        type: "POST",
        headers: { "Authorization": "Bearer " + TokenIRIS },
        success: function (result) {
            if (result.Ok) {
                console.log("✔ Sincronización completada correctamente.");
                ShowModalDialog('Sincronización completada.', false, 'success', '', 0);
                LoadDataTableSolicitud_Certificado(); // ahora sí carga la tabla
            } else {
                ShowModalDialog(result.Message || 'Error al sincronizar.', false, 'warning', '', 0);
                LoadDataTableSolicitud_Certificado();
            }
        },
        error: function (xhr) {
            console.error("❌ Error al sincronizar:", xhr);
            ShowModalDialog("Error al sincronizar: " + xhr.statusText, false, 'error', '', 0);
            LoadDataTableSolicitud_Certificado();
        }
    });
}

// ============================================================
// Paso 2: Carga la tabla principal con DataTables
// ============================================================

function LoadDataTableSolicitud_Certificado() {
    if (DataTableSolicitud_Certificado) {
        DataTableSolicitud_Certificado.destroy();

        // Limpiar filtros personalizados de DataTables
        $.fn.dataTable.ext.search = [];
    }

    DataTableSolicitud_Certificado = $('#tblSolicitud_Certificado').DataTable({
        language: {
            url: "/lib/dataTables/Language.json"
        },
        serverSide: false,
        processing: true,
        search: { 
            caseInsensitive: true,
            regex: true
        },
        ajax: {
            url: urlController + "Solicitud_CertificadoTrazabilidad/GetAllSolicitud_CertificadoTrazabilidad",
            type: "GET",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + TokenIRIS);
            },
            dataSrc: function (json) {
                console.log("Datos obtenidos del backend:", json);
                if (json.Ok && json.Data) {
                    //Auto-generated
                    // Filtrar por nivel académico según rol del usuario
                    var idrolRaw = sessionStorage.getItem('idrol');
                    var idrol = parseInt(idrolRaw || '0');
                    // DEBUG: ver qué rol está leyendo al cargar la tabla
                    console.log("🎓 sessionStorage 'idrol' (raw):", idrolRaw, "-> parseado:", idrol);
                    var datos = json.Data;
                    if (idrol === 25) {
                        // NotasPosgrado: solo filas donde DirigidoA contenga "Posgrado"
                        datos = datos.filter(function(r) {
                            return (r.DirigidoA || '').toLowerCase().indexOf('posgrado') !== -1;
                        });
                        console.log("🎓 Filtro Posgrado aplicado (rol 25): " + datos.length + " registros");
                    } else if (idrol === 26) {
                        // NotasPregrado: solo filas donde DirigidoA contenga "Pregrado"
                        datos = datos.filter(function(r) {
                            return (r.DirigidoA || '').toLowerCase().indexOf('pregrado') !== -1;
                        });
                        console.log("🎓 Filtro Pregrado aplicado (rol 26): " + datos.length + " registros");
                    }
                    return datos;
                } else {
                    ShowModalDialog(json.Message || "No hay registros disponibles.", false, 'warning', '', 0);
                    return [];
                }
            },
            error: function (xhr) {
                ShowModalDialog("Error al cargar los datos: " + xhr.statusText, false, 'error', '', 0);
            }
        },
        columns: [
            { 
                data: "NumeroRadicado", 
                orderable: true,
                render: function(data) {
                    return data || '-';
                }
            },
            { 
                data: "FechaRadicado", 
                orderable: true,
                render: function(data) {
                    if (!data) return '-';
                    try {
                        const fecha = new Date(data);
                        return fecha.toLocaleDateString('es-ES');
                    } catch (e) {
                        return data;
                    }
                }
            },
            { 
                data: "Procedencia", 
                orderable: true,
                render: function(data) {
                    return data || '-';
                }
            },
            {
                data: "Asunto",
                orderable: false,
                render: function (data) {
                    return data ? data.replace(/^CER\s*\d+\s*-\s*/i, "") : "-";
                }
            },
            { 
                data: "DirigidoA", 
                orderable: false,
                render: function(data) {
                    return data || '-';
                }
            },
            { 
                data: "Pago", 
                orderable: false,
                render: function(data) {
                    let clase = '';
                    let texto = data || 'No definido';
                    
                    // Asignar clases según el estado de pago
                    switch(data) {
                        case 'Pagado':
                            clase = 'pago-gris';
                            break;
                        case 'Gratis':
                            clase = 'pago-amarillo';
                            break;
                        case 'No ha pagado':
                            clase = 'pago-vinotinto';
                            break;
                        case 'En verificación':
                            clase = 'estado-naranja'; // Usamos naranja temporal
                            break;
                        default:
                            clase = 'estado-gris';
                    }
                    
                    return `<span class="${clase}">${texto}</span>`;
                }
            },
            { 
                data: "Estado", 
                orderable: true,
                render: function(data) {
                    let clase = '';
                    let texto = data || 'No definido';
                    
                    // Asignar clases según el estado
                    switch(data) {
                        case 'En Verificación de Pago':
                            clase = 'estado-rojo';
                            break;
                        case 'En Proceso de Expedición':
                            clase = 'estado-naranja';
                            break;
                        case 'Enviado al usuario':
                            clase = 'estado-verde';
                            break;
                        case 'No es de competencia o aun no puede expedirse':
                            clase = 'estado-gris';
                            break;
                        case 'En proceso de firma':
                            clase = 'estado-morado';
                            break;
                        case 'Anulado por el estudiante':
                            clase = 'estado-cafe';
                            break;
                        default:
                            clase = 'estado-gris';
                    }
                    
                    return `<span class="${clase}">${texto}</span>`;
                }
            },
            {
                render: function (data, type, row) {
                    return '<div class="text-center">' +
                        '<img src="../images/iris/Editar.png" class="cambiarMouse" title="Ver Detalle" onclick="VerDetalleSolicitudDetalle(' + row.Id + ')" />' +
                        '</div>';
                },
                className: "text-center",
                orderable: false
            }
        ],
        columnDefs: [{ targets: "_all", defaultContent: "-" }],
        dom: 'lBfrtip',
        lengthMenu: [[10, 20, 30, 50], [10, 20, 30, 50]],
        initComplete: function() {
            // Agregar placeholder al buscador
            $('.dataTables_filter input').attr('placeholder', 'Buscar en todos los campos...');
        }
    });

    // Configurar filtros personalizados
    configurarFiltrosDataTable();
    
    // Inicializar componentes de filtros avanzados
    setTimeout(() => {
        inicializarFiltrosAvanzados();
    }, 500);
    
    return DataTableSolicitud_Certificado;
}

function formatearFecha(fechaString) {
    if (!fechaString) return '-';
    try {
        const fecha = new Date(fechaString);
        return fecha.toLocaleDateString('es-ES') + ' ' + fecha.toLocaleTimeString('es-ES', {hour: '2-digit', minute: '2-digit'});
    } catch (e) {
        return fechaString;
    }
}


// ============================================================
// Paso 3: Ver detalle de una solicitud (versión unificada y corregida)
// ============================================================
function VerDetalleSolicitudDetalle(idSolicitud) {
    console.log("🟢 Clic en Ver Detalle con id:", idSolicitud);
     $("#filtrosAvanzados").addClass("ocultar-filtros");
    // Limpiar y mostrar el detalle
    $("#dvSolicitud_CertificadoTable").addClass("ocultar");
    $("#dvSolicitud_CertificadoDetalle").removeClass("ocultar");
    
    // Establecer el ID
    $("#spanIdSolicitud_Certificado").text(idSolicitud);

    if (!ExisteDivEdicionDatos('dvSolicitud_CertificadoDetalle')) {
        console.log("📄 Cargando detalle desde HTML...");
        CargarDetalleSolicitudHTML(function () {
            CargarScriptDetalleSolicitud(function () {
                esperarFormularioYEditar(idSolicitud);
            });
        });
    } else {
        console.log("🌀 Detalle ya existe, recargando datos...");
        // Asegurarnos de que el script esté cargado antes de proceder
        if (typeof EditarSolicitud_Certificadoform === "function") {
            EditarSolicitud_Certificadoform(idSolicitud);
        } else {
            CargarScriptDetalleSolicitud(function () {
                esperarFormularioYEditar(idSolicitud);
            });
        }
    }
}

function CargarDetalleSolicitudHTML(callback) {
    // Asegurarnos de que el contenedor existe y está vacío
    if ($('#dvSolicitud_CertificadoDetalle').length === 0) {
        console.error("❌ Contenedor dvSolicitud_CertificadoDetalle no encontrado");
        return;
    }
    
    // Cache-bust: siempre cargar la versión más reciente del HTML
    $.get('/Pages/SolicitudCertificados/Solicitud_CertificadoDetalle.html?v=' + Date.now())
        .done(function (htmlexterno) {
            $('#dvSolicitud_CertificadoDetalle').html(htmlexterno);
            console.log("✅ HTML cargado correctamente");
            if (typeof callback === "function") callback();
        })
        .fail(function (xhr) {
            console.error("❌ Error al cargar el HTML de detalle:", xhr);
            ShowModalDialog("Error al cargar el detalle: " + xhr.statusText, false, 'error', '', 0);
        });
}

function CargarScriptDetalleSolicitud(callback) {
    if (DetalleSolicitudCertificadoScriptCargado && typeof EditarSolicitud_Certificadoform === "function") {
        console.log("✅ Script ya cargado");
        if (typeof callback === "function") callback();
        return;
    }
    
    console.log("📦 Cargando script del detalle...");
    // Cache-bust: siempre cargar la versión más reciente del script
    $.getScript("/js/iris/Solicitud_CertificadoDetalle.js?v=" + Date.now())
        .done(function () {
            DetalleSolicitudCertificadoScriptCargado = true;
            console.log("✅ Script cargado correctamente");
            // Pequeño delay para asegurar que las funciones estén disponibles
            setTimeout(function () {
                if (typeof callback === "function") callback();
            }, 100);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("❌ Error cargando el script del detalle:", exception);
            ShowModalDialog("No fue posible cargar el detalle.", false, 'error', '', 0);
        });
}

function esperarFormularioYEditar(idSolicitud) {
    let intentos = 0;
    const maxIntentos = 50;
    const intervalo = 100;
    
    let checkExist = setInterval(function () {
        intentos++;
        const formListo = $("#formSolicitud_CertificadoDetalle").length > 0;
        const fnDisponible = typeof InicializarDetalleSolicitud === "function";

        console.log(`⏳ Intento ${intentos}: formListo=${formListo}, fnDisponible=${fnDisponible}`);
        
        if (formListo && fnDisponible) {
            clearInterval(checkExist);
            console.log("✅ Formulario y función listos, iniciando edición...");
            $("#dvSolicitud_CertificadoTable").addClass("ocultar");
            $("#dvSolicitud_CertificadoDetalle").removeClass("ocultar");
            
            // ✅ CORRECTO: Llamar a InicializarDetalleSolicitud
            InicializarDetalleSolicitud(idSolicitud);
        } else if (intentos >= maxIntentos) {
            clearInterval(checkExist);
            console.error("❌ Tiempo de espera agotado para cargar el formulario de detalle.");
            ShowModalDialog("No fue posible preparar el detalle de la solicitud.", false, 'warning', '', 0);
        }
    }, intervalo);
}

// Función auxiliar para verificar si el div de edición existe y tiene contenido
function ExisteDivEdicionDatos(id) {
    const element = document.getElementById(id);
    return element && element.innerHTML && element.innerHTML.trim() !== '';
}

// ============================================================
// Paso 4: Crear nueva solicitud (a futuro)
// ============================================================
function CrearSolicitud_Certificado() {
    ShowModalDialog('Función en desarrollo', false, 'info', '', 0);
}

// ============================================================
// 🔄 Función para actualizar la tabla después de guardar
// ============================================================
function RefreshDataTableSolicitud_Certificado() {
    console.log("🔄 Actualizando tabla principal...");
    
    if (DataTableSolicitud_Certificado) {
        DataTableSolicitud_Certificado.ajax.reload(null, false); // false = mantiene la paginación actual
        console.log("✅ Tabla actualizada correctamente");
    } else {
        console.warn("⚠️ DataTable no está inicializado");
        // Si la tabla no existe, recargar desde cero
        LoadDataTableSolicitud_Certificado();
    }
}


// function EditarSolicitud_Certificadoform(idSolicitud) {
//     console.log("✳️ Entrando a EditarSolicitud_Certificadoform con id:", idSolicitud);

//     // Esperar hasta que el formulario esté disponible
//     let checkForm = setInterval(function () {
//         if ($("#formSolicitud_CertificadoDetalle").length > 0) {
//             clearInterval(checkForm);
//             console.log("✅ Formulario encontrado, cargando datos...");

//             // Aquí va tu lógica original:
//             let model = new Solicitud_CertificadoTrazabilidad();
//             $.ajax({
//                 url: model.urlGetDetail + "?id=" + idSolicitud,
//                 type: "GET",
//                 success: function (response) {
//                     console.log("📦 Datos recibidos:", response);
//                     if (response.Ok && response.Data) {
//                         ConstruirFormularioEdicion(model.Model, "formSolicitud_CertificadoDetalle", response.Data);
//                     } else {
//                         console.warn("⚠️ No se encontró información del certificado.");
//                     }
//                 },
//                 error: function (xhr) {
//                     console.error("❌ Error al obtener detalle:", xhr);
//                 }
//             });
//         } else {
//             console.log("⏳ Esperando que el formSolicitud_CertificadoDetalle aparezca en DOM...");
//         }
//     }, 150);
// }



// Variables para filtros
var filtrosActivos = {
    estado: [],
    pago: [],
    fechaDesde: null,
    fechaHasta: null,
    solicitante: ''
};

// Inicializar componentes de filtros
function inicializarFiltrosAvanzados() {
    console.log("🎛️ Inicializando filtros avanzados...");
    
    // Inicializar select múltiple para estados
    $('#filtroEstado').multiselect({
        nonSelectedText: 'Todos los estados',
        nSelectedText: 'estados seleccionados',
        allSelectedText: 'Todos los estados',
        selectAllText: 'Seleccionar todos',
        deselectAllText: 'Deseleccionar todos',
        includeSelectAllOption: true,
        buttonClass: 'btn btn-light',
        buttonWidth: '100%',
        maxHeight: 200
    });

    // Inicializar select múltiple para pagos
    $('#filtroPago').multiselect({
        nonSelectedText: 'Todos los pagos',
        nSelectedText: 'pagos seleccionados',
        allSelectedText: 'Todos los pagos',
        selectAllText: 'Seleccionar todos',
        deselectAllText: 'Deseleccionar todos',
        includeSelectAllOption: true,
        buttonClass: 'btn btn-light',
        buttonWidth: '100%',
        maxHeight: 200
    });

    // Inicializar datepicker para fechas
    $('#datepicker').datepicker({
        format: 'yyyy-mm-dd',
        language: 'es',
        autoclose: true,
        todayHighlight: true
    });

    // Eventos para filtros en tiempo real
    $('#filtroSolicitante').on('input', function() {
        if (this.value.length >= 3 || this.value.length === 0) {
            aplicarFiltros();
        }
    });

    // Eventos para selects múltiples
    $('#filtroEstado, #filtroPago').on('change', function() {
        aplicarFiltros();
    });

    // Eventos para fechas
    $('#filtroFechaDesde, #filtroFechaHasta').on('changeDate', function() {
        aplicarFiltros();
    });

    console.log("✅ Filtros avanzados inicializados");
}

// Función para mostrar/ocultar filtros
function mostrarOcultarFiltros() {
    const filtros = $('#filtrosAvanzados');
    const toggle = $('#toggleFiltros');
    
    if (filtros.is(':visible')) {
        filtros.slideUp(300);
        toggle.html('<i class="fa fa-chevron-down"></i> Mostrar');
    } else {
        filtros.slideDown(300);
        toggle.html('<i class="fa fa-chevron-up"></i> Ocultar');
    }
}

// Aplicar todos los filtros
function aplicarFiltros() {
    console.log("🔍 Aplicando filtros...");
    
    // Actualizar objeto de filtros activos
    actualizarFiltrosActivos();
    
    // Aplicar filtros a DataTable
    aplicarFiltrosDataTable();
    
    // Actualizar etiquetas de filtros activos
    actualizarEtiquetasFiltros();
    
    console.log("✅ Filtros aplicados:", filtrosActivos);
}

// Actualizar objeto de filtros activos
function actualizarFiltrosActivos() {
    filtrosActivos.estado = $('#filtroEstado').val() || [];
    filtrosActivos.pago = $('#filtroPago').val() || [];
    filtrosActivos.fechaDesde = $('#filtroFechaDesde').val();
    filtrosActivos.fechaHasta = $('#filtroFechaHasta').val();
    filtrosActivos.solicitante = $('#filtroSolicitante').val();
}

// Aplicar filtros a DataTable
function aplicarFiltrosDataTable() {
    if (!DataTableSolicitud_Certificado) return;
    
    // 🔥 Asegurarnos de que se aplica correctamente el redibujado
    DataTableSolicitud_Certificado.draw();
    
    // Mostrar información del filtrado
    const totalFiltrado = DataTableSolicitud_Certificado.rows({ filter: 'applied' }).count();
    const totalGeneral = DataTableSolicitud_Certificado.rows().count();
    
    console.log(`📊 Registros: ${totalFiltrado} de ${totalGeneral} (filtrados/total)`);
}

// Configurar filtros personalizados en DataTables
function configurarFiltrosDataTable() {
    if (!DataTableSolicitud_Certificado) return;
    
    // Limpiar cualquier filtro personalizado previo
    $.fn.dataTable.ext.search = [];
    
    $.fn.dataTable.ext.search.push(function(settings, data, dataIndex) {
        // Si no hay filtros activos, mostrar todos los registros
        if (filtrosActivos.estado.length === 0 && 
            filtrosActivos.pago.length === 0 && 
            !filtrosActivos.fechaDesde && 
            !filtrosActivos.fechaHasta && 
            !filtrosActivos.solicitante) {
            return true;
        }
        
        const estado = data[6] || ''; // Columna de estado
        const pago = data[5] || '';   // Columna de pago
        const fechaRadicado = data[1] || ''; // Columna de fecha
        const solicitante = data[2] || ''; // Columna de solicitante
        
        // Filtro por estado
        if (filtrosActivos.estado.length > 0) {
            const estadoMatch = filtrosActivos.estado.some(filtro => 
                estado.includes(filtro)
            );
            if (!estadoMatch) return false;
        }
        
        // Filtro por pago
        if (filtrosActivos.pago.length > 0) {
            const pagoMatch = filtrosActivos.pago.some(filtro => 
                pago.includes(filtro)
            );
            if (!pagoMatch) return false;
        }
        
        // Filtro por fecha
        if (filtrosActivos.fechaDesde || filtrosActivos.fechaHasta) {
            const fecha = new Date(fechaRadicado);
            const desde = filtrosActivos.fechaDesde ? new Date(filtrosActivos.fechaDesde) : null;
            const hasta = filtrosActivos.fechaHasta ? new Date(filtrosActivos.fechaHasta) : null;
            
            if (desde && fecha < desde) return false;
            if (hasta && fecha > hasta) return false;
        }
        
        // Filtro por solicitante
        if (filtrosActivos.solicitante) {
            const solicitanteLower = solicitante.toLowerCase();
            const filtroLower = filtrosActivos.solicitante.toLowerCase();
            if (!solicitanteLower.includes(filtroLower)) return false;
        }
        
        return true;
    });
}

// Actualizar etiquetas de filtros activos
function actualizarEtiquetasFiltros() {
    const etiquetas = $('#etiquetasFiltros');
    const contenedor = $('#filtrosActivos');
    
    etiquetas.empty();
    
    let hayFiltros = false;
    
    // Etiquetas para estados
    filtrosActivos.estado.forEach(estado => {
        etiquetas.append(`
            <span class="filtro-etiqueta">
                Estado: ${estado}
                <span class="close" onclick="removerFiltroEstado('${estado}')">×</span>
            </span>
        `);
        hayFiltros = true;
    });
    
    // Etiquetas para pagos
    filtrosActivos.pago.forEach(pago => {
        etiquetas.append(`
            <span class="filtro-etiqueta">
                Pago: ${pago}
                <span class="close" onclick="removerFiltroPago('${pago}')">×</span>
            </span>
        `);
        hayFiltros = true;
    });
    
    // Etiqueta para fechas
    if (filtrosActivos.fechaDesde || filtrosActivos.fechaHasta) {
        const textoFecha = `${filtrosActivos.fechaDesde || ''} - ${filtrosActivos.fechaHasta || ''}`;
        etiquetas.append(`
            <span class="filtro-etiqueta">
                Fecha: ${textoFecha}
                <span class="close" onclick="removerFiltroFecha()">×</span>
            </span>
        `);
        hayFiltros = true;
    }
    
    // Etiqueta para solicitante
    if (filtrosActivos.solicitante) {
        etiquetas.append(`
            <span class="filtro-etiqueta">
                Solicitante: ${filtrosActivos.solicitante}
                <span class="close" onclick="removerFiltroSolicitante()">×</span>
            </span>
        `);
        hayFiltros = true;
    }
    
    // Mostrar u ocultar contenedor
    if (hayFiltros) {
        contenedor.show();
    } else {
        contenedor.hide();
    }
}

// Funciones para remover filtros individuales
function removerFiltroEstado(estado) {
    const valores = $('#filtroEstado').val();
    const nuevosValores = valores.filter(v => v !== estado);
    $('#filtroEstado').val(nuevosValores).multiselect('refresh');
    aplicarFiltros();
}

function removerFiltroPago(pago) {
    const valores = $('#filtroPago').val();
    const nuevosValores = valores.filter(v => v !== pago);
    $('#filtroPago').val(nuevosValores).multiselect('refresh');
    aplicarFiltros();
}

function removerFiltroFecha() {
    $('#filtroFechaDesde').val('');
    $('#filtroFechaHasta').val('');
    $('#filtroFechaDesde').datepicker('update');
    $('#filtroFechaHasta').datepicker('update');
    aplicarFiltros();
}

function removerFiltroSolicitante() {
    $('#filtroSolicitante').val('');
    aplicarFiltros();
}

function limpiarFiltros() {
    console.log("🔥🔥🔥 EJECUTANDO limpiarFiltros - VERSIÓN SIMPLE");
    
    try {
        // 1. Limpiar controles visuales
        if ($('#filtroEstado').length) {
            $('#filtroEstado').val([]);
            if ($('#filtroEstado').data('multiselect')) {
                $('#filtroEstado').multiselect('refresh');
            }
        }
        
        if ($('#filtroPago').length) {
            $('#filtroPago').val([]);
            if ($('#filtroPago').data('multiselect')) {
                $('#filtroPago').multiselect('refresh');
            }
        }
        
        if ($('#filtroFechaDesde').length) {
            $('#filtroFechaDesde').val('');
        }
        
        if ($('#filtroFechaHasta').length) {
            $('#filtroFechaHasta').val('');
        }
        
        if ($('#filtroSolicitante').length) {
            $('#filtroSolicitante').val('');
        }
        
        // 2. Resetear el objeto de filtros activos
        filtrosActivos = {
            estado: [],
            pago: [],
            fechaDesde: null,
            fechaHasta: null,
            solicitante: ''
        };
        
        // 3. 🔥 RECARGAR COMPLETAMENTE LA TABLA (GARANTIZADO)
        if (DataTableSolicitud_Certificado) {
            console.log("🔄 Recargando tabla completa...");
            
            // Opción A: Recargar datos desde el servidor
            DataTableSolicitud_Certificado.ajax.reload();
            
            // Opción B: Si la opción A no funciona, usar esta
            // DataTableSolicitud_Certificado.search('').draw();
        } else {
            console.error("DataTableSolicitud_Certificado no está definido");
        }
        
        // 4. Ocultar etiquetas de filtros activos
        $('#filtrosActivos').hide();
        $('#etiquetasFiltros').empty();

        
    } catch (error) {
        console.error("💥 ERROR en limpiarFiltros:", error);
        ShowModalDialog('Error al limpiar filtros: ' + error.message, false, 'error', '', 0);
    }
}
// Exportar datos filtrados
function exportarFiltros() {
    if (!DataTableSolicitud_Certificado) return;
    
    const totalFiltrado = DataTableSolicitud_Certificado.rows({ filter: 'applied' }).count();
    const totalGeneral = DataTableSolicitud_Certificado.rows().count();
    
    let mensaje = `¿Exportar ${totalFiltrado} registros filtrados?`;
    if (totalFiltrado === totalGeneral) {
        mensaje = "¿Exportar todos los registros?";
    }
    
    ShowModalDialog(mensaje, false, 'info', 'Exportar', 0, function() {
        // Aquí va la lógica de exportación
        exportarDatosFiltrados();
    });
}

function exportarDatosFiltrados() {
    console.log("📤 Exportando datos filtrados...");
    
    // Obtener datos filtrados
    const datosFiltrados = DataTableSolicitud_Certificado.rows({ filter: 'applied' }).data().toArray();
    
    // Crear CSV
    let csv = 'Número,Fecha Radicado,Solicitante,Tipo Certificado,Nivel Académico,Pago,Estado\n';
    
    datosFiltrados.forEach(row => {
        const fila = [
            `"${row.NumeroRadicado || ''}"`,
            `"${formatearFechaParaExportacion(row.FechaRadicado)}"`,
            `"${row.Procedencia || ''}"`,
            `"${(row.Asunto || '').replace(/^CER\s*\d+\s*-\s*/i, '')}"`,
            `"${row.DirigidoA || ''}"`,
            `"${row.Pago || ''}"`,
            `"${row.Estado || ''}"`
        ].join(',');
        
        csv += fila + '\n';
    });
    
    // Descargar archivo
    const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    const link = document.createElement('a');
    const url = URL.createObjectURL(blob);
    
    link.setAttribute('href', url);
    link.setAttribute('download', `certificados_${new Date().toISOString().split('T')[0]}.csv`);
    link.style.visibility = 'hidden';
    
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    
    console.log("✅ Exportación completada");
}

function formatearFechaParaExportacion(fechaString) {
    if (!fechaString) return '';
    try {
        const fecha = new Date(fechaString);
        return fecha.toLocaleDateString('es-ES');
    } catch (e) {
        return fechaString;
    }
}