var urlController = "https://iris.unal.edu.co/APIirisunal/";
var ObjModelSolicitud_CertificadoTrazabilidad = null;

console.log("🧩 Archivo Solicitud_CertificadoDetalle.js cargado correctamente.");

function InicializarDetalleSolicitud(idSolicitud) {
    console.log("🔧 Inicializando detalle con ID:", idSolicitud);
    
    if (!ObjModelSolicitud_CertificadoTrazabilidad) {
        ObjModelSolicitud_CertificadoTrazabilidad = new Solicitud_CertificadoTrazabilidad();
    }
    
    if (!idSolicitud || idSolicitud === '' || idSolicitud === '0') {
        console.log("📝 Modo creación");
        CrearFormularioManual();
    } else {
        console.log("📖 Modo edición con ID:", idSolicitud);
        CrearFormularioManual();
        CargarDatosFormulario(idSolicitud);
    }
}


function CrearFormularioManual() {
    console.log("🔥 CREANDO FORMULARIO COMPACTO");
    
    const htmlFormulario = `
        <div class="formulario-detalle-compacto">
            <!-- Título -->
            <div class="row mb-3">
                <div class="col-md-12">
                    <h4 class="text-primary border-bottom pb-2">Detalle de Solicitud de Certificado</h4>
                </div>
            </div>

            <!-- Fila 1: Radicado / Fecha / Solicitante / Correo -->
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Radicado</label>
                        <div id="campo_NumeroRadicado" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Fecha Radicado</label>
                        <div id="campo_FechaRadicado" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Solicitante</label>
                        <div id="campo_Procedencia" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Correo</label>
                        <div id="campo_CorreoElectronico" class="form-control-static">-</div>
                    </div>
                </div>
            </div>

            <!-- Fila 2: Tipo doc / Num. doc / Dirigido A / Asunto -->
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Tipo Doc.</label>
                        <div id="campo_TipoDni" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Núm. Documento</label>
                        <div id="campo_NumeroDni" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Dirigido A (Nivel)</label>
                        <div id="campo_DirigidoA" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Asunto (Certificado)</label>
                        <div id="campo_Asunto" class="form-control-static">-</div>
                    </div>
                </div>
            </div>

            <!-- Separador entre campos informativos y editables -->
            <hr style="border-top: 2px solid #4e73df; margin: 8px 0 16px 0;">

            <!-- Fila 3: Pago / Estado / Comprobante / Fechas -->
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="campo_Pago">Pago</label>
                        <select id="campo_Pago" class="form-control">
                            <option value="En verificación">En verificación</option>
                            <option value="Pagado">Pagado</option>
                            <option value="Gratis">Gratis</option>
                            <option value="No ha pagado">No ha pagado</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="campo_Estado">Estado</label>
                        <select id="campo_Estado" class="form-control">
                            <option value="En Verificación de Pago">En Verificación de Pago</option>
                            <option value="En Proceso de Expedición">En Proceso de Expedición</option>
                            <option value="En proceso de firma">En proceso de firma</option>
                            <option value="Enviado al usuario">Enviado al usuario</option>
                            <option value="No es de competencia o aun no puede expedirse">No es de competencia</option>
                            <option value="Anulado por el estudiante">Anulado por estudiante</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Fecha Creación</label>
                        <div id="campo_FechaCreacion" class="form-control-static">-</div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>
                            Fecha Actualización
                            <span id="iconoComprobante" style="display:none; margin-left:8px;">
                                <i class="fas fa-file-invoice text-primary" style="cursor:pointer;"
                                   onclick="mostrarComprobante()"
                                   title="Ver comprobante de pago"></i>
                            </span>
                        </label>
                        <div id="campo_FechaActualizacion" class="form-control-static">-</div>
                    </div>
                </div>
            </div>

            <!-- Fila 4: Observaciones -->
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Observaciones (Automáticas)</label>
                        <div id="campo_Observaciones" class="form-control-static" style="min-height:60px;">-</div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="campo_Comentarios">Comentarios</label>
                        <textarea id="campo_Comentarios" class="form-control" rows="3" placeholder="Ingrese comentarios aquí..."></textarea>
                    </div>
                </div>
            </div>

            <input type="hidden" id="campo_Id" value="">
            <input type="hidden" id="campo_ComprobantePago" value="">
        </div>

        <!-- Modal comprobante -->
        <div class="modal fade" id="modalComprobante" tabindex="-1">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Comprobante de Pago</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                    </div>
                    <div class="modal-body text-center">
                        <img id="imagenComprobante" src="" alt="Comprobante" style="max-width:100%;">
                    </div>
                </div>
            </div>
        </div>
    `;
    
    $("#formSolicitud_CertificadoDetalle").html(htmlFormulario);
    console.log("✅ FORMULARIO COMPACTO CREADO EXITOSAMENTE");
}


function mostrarComprobante() {
    const comprobante = $('#campo_ComprobantePago').val();
    console.log("🔍 Comprobante encontrado:", comprobante);
    
    if (comprobante && comprobante !== '') {
        const urlCompleta = 'https://derecho.bogota.unal.edu.co/media/' + comprobante;
        console.log("📁 URL completa:", urlCompleta);
        
        // Abrir en nueva pestaña
        window.open(urlCompleta, '_blank');
        
        // O mostrar en un modal simple sin Bootstrap
        // mostrarModalSimple(urlCompleta);
    }
}

// Alternativa: Modal simple sin Bootstrap
function mostrarModalSimple(url) {
    const modalHtml = `
        <div id="modalSimple" style="position:fixed; top:0; left:0; width:100%; height:100%; background:rgba(0,0,0,0.8); z-index:9999; display:flex; align-items:center; justify-content:center;">
            <div style="background:white; padding:20px; border-radius:8px; max-width:90%; max-height:90%;">
                <div style="text-align:right; margin-bottom:10px;">
                    <button onclick="cerrarModalSimple()" style="background:none; border:none; font-size:20px; cursor:pointer;">×</button>
                </div>
                <img src="${url}" style="max-width:100%; max-height:80vh;">
            </div>
        </div>
    `;
    $('body').append(modalHtml);
}

function cerrarModalSimple() {
    $('#modalSimple').remove();
}

function CargarDatosFormulario(idSolicitud) {
    console.log("📥 Cargando datos para ID:", idSolicitud);
    
    const model = new Solicitud_CertificadoTrazabilidad();
    
    $.ajax({
        url: model.urlGetDetail + "?id=" + idSolicitud,
        type: "GET",
        headers: { "Authorization": "Bearer " + TokenIRIS },
        success: function (response) {
            console.log("✅ Datos recibidos del backend");
            if (response.Ok && response.Data) {
                const data = response.Data;
                
                // ASIGNAR DATOS DIRECTAMENTE A LOS CAMPOS
                if (data.Id) $('#campo_Id').val(data.Id);
                if (data.NumeroRadicado) $('#campo_NumeroRadicado').text(data.NumeroRadicado);
                if (data.FechaRadicado) $('#campo_FechaRadicado').text(formatearFecha(data.FechaRadicado));
                if (data.Procedencia) $('#campo_Procedencia').text(data.Procedencia);
                if (data.CorreoElectronico) $('#campo_CorreoElectronico').text(data.CorreoElectronico);
                if (data.TipoDni) $('#campo_TipoDni').text(data.TipoDni);
                if (data.NumeroDni) $('#campo_NumeroDni').text(data.NumeroDni);
                if (data.DirigidoA) $('#campo_DirigidoA').text(data.DirigidoA);
                if (data.Asunto) $('#campo_Asunto').text(data.Asunto.replace(/^CER\s*\d+\s*-\s*/i, ""));
                if (data.Pago) $('#campo_Pago').val(data.Pago);
                if (data.Estado) $('#campo_Estado').val(data.Estado);
                if (data.Comentarios) $('#campo_Comentarios').val(data.Comentarios);
                if (data.Observaciones) $('#campo_Observaciones').text(data.Observaciones);
                if (data.FechaCreacion) $('#campo_FechaCreacion').text(formatearFecha(data.FechaCreacion));
                if (data.FechaActualizacion) $('#campo_FechaActualizacion').text(formatearFecha(data.FechaActualizacion));
                // Agrega esto con las otras asignaciones de datos:
                if (data.ComprobantePago) {
                    $('#campo_ComprobantePago').val(data.ComprobantePago);
                    $('#iconoComprobante').show();
                } else {
                    $('#campo_ComprobantePago').val('');
                    $('#iconoComprobante').hide();
}
                console.log("🎉 ¡DATOS CARGADOS EXITOSAMENTE EN EL FORMULARIO!");
                
            } else {
                console.warn("⚠️ No se encontró información del certificado.");
                ShowModalDialog("No se encontró información para este certificado.", false, 'warning', '', 0);
            }
        },
        error: function (xhr) {
            console.error("❌ Error al cargar datos:", xhr);
            ShowModalDialog("Error al cargar los datos del certificado.", false, 'error', '', 0);
        }
    });
}

function formatearFecha(fechaString) {
    if (!fechaString) return '-';
    try {
        const fecha = new Date(fechaString);
        return fecha.toLocaleDateString('es-ES') + ' ' + fecha.toLocaleTimeString('es-ES');
    } catch (e) {
        return fechaString;
    }
}

function CerrarSolicitud_CertificadoDesdeEdicion() {
    $("#dvSolicitud_CertificadoDetalle").addClass("ocultar");
    $("#dvSolicitud_CertificadoTable").removeClass("ocultar");
    $("#filtrosAvanzados").removeClass("ocultar-filtros");
}

function ValidatePostUpdateSolicitud_CertificadoForm() {
    console.log("💾 Guardando datos...");
    
    const datosActualizar = {
        Id: $('#campo_Id').val(),
        Pago: $('#campo_Pago').val(),
        Estado: $('#campo_Estado').val(),
        Comentarios: $('#campo_Comentarios').val()
    };
    
    console.log("📤 Datos a actualizar:", datosActualizar);
    
    const model = new Solicitud_CertificadoTrazabilidad();
    
    ShowModalDialog('Guardando cambios...', true, 'info', '', 0);
    
    $.ajax({
        url: model.urlUpdate,
        type: "POST",
        headers: { 
            "Authorization": "Bearer " + TokenIRIS,
            "Content-Type": "application/json"
        },
        data: JSON.stringify(datosActualizar),
        success: function (response) {
            if (response.Ok) {
                ShowModalDialog('✅ Solicitud actualizada correctamente.', false, 'success', '', 2000);
                
                // 🔥 ACTUALIZAR Y CERRAR DESPUÉS DE 2 SEGUNDOS
                setTimeout(() => {
                    // 1. Cerrar el detalle
                    CerrarSolicitud_CertificadoDesdeEdicion();
                    
                    // 2. Actualizar la tabla principal
                    if (typeof RefreshDataTableSolicitud_Certificado === 'function') {
                        RefreshDataTableSolicitud_Certificado();
                    } else {
                        // Si no existe la función, recargar manualmente
                        if (DataTableSolicitud_Certificado) {
                            DataTableSolicitud_Certificado.ajax.reload();
                        }
                    }
                }, 2000);
                
            } else {
                ShowModalDialog('❌ Error: ' + (response.Message || 'No se pudo actualizar'), false, 'error', '', 0);
            }
        },
        error: function (xhr) {
            console.error("❌ Error al guardar:", xhr);
            ShowModalDialog('❌ Error al guardar los cambios.', false, 'error', '', 0);
        }
    });
}