// "../js/iris/models/Solicitud_CertificadoModel.js"

// ============================================================
// 🛡️ PROTECCIÓN CONTRA REDECLARACIONES Y DISPONIBILIDAD GLOBAL
// ============================================================

// Verificar si ya existe la función Solicitud_Certificado
if (typeof Solicitud_Certificado === 'undefined') {
    function Solicitud_Certificado() {
        // ===============================
        // 📦 Definición de Campos
        // ===============================
        this.Campos = [
            { campo: 'id_solicitud', tipo: 'string', nullable: false, llave: 'primary' },
            { campo: 'solicitante', tipo: 'string', nullable: false, llave: '' },
            { campo: 'tipo_certificado', tipo: 'string', nullable: false, llave: '' },
            { campo: 'nivel_academico', tipo: 'string', nullable: false, llave: '' },
            { campo: 'programa', tipo: 'string', nullable: false, llave: '' },
            { campo: 'estado', tipo: 'string', nullable: false, llave: '' }
        ];

        // ===============================
        // 🧱 Definición para construir el formulario dinámico (HTML)
        // ===============================
        this.CamposHTML = [
            [
                { campo: 'id_solicitud', tipo: 'string', nullable: true, llave: 'primary' },
                { campo: 'solicitante', tipo: 'string', nullable: false, llave: '', etiqueta: 'Solicitante', placeholder: 'Nombre del solicitante', numcols: 2, maxlength: 150 },
                { campo: 'tipo_certificado', tipo: 'string', nullable: false, llave: '', etiqueta: 'Tipo de Certificado', placeholder: 'Ej: Académico, Laboral, etc.', numcols: 2, maxlength: 100 },
                { campo: 'nivel_academico', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nivel Académico', placeholder: 'Ej: Pregrado, Posgrado...', numcols: 2, maxlength: 50 },
                { campo: 'programa', tipo: 'string', nullable: false, llave: '', etiqueta: 'Programa', placeholder: 'Nombre del programa', numcols: 2, maxlength: 150 },
                { campo: 'estado', tipo: 'string', nullable: false, llave: '', etiqueta: 'Estado', placeholder: 'Ej: Pendiente, Aprobado...', numcols: 2, maxlength: 50 }
            ]
        ];

        // ===============================
        // ⚙️ Configuración del modelo
        // ===============================
        this.CampoLlave = 'id_solicitud';
        this.Nombre = 'Solicitud_Certificado';
        this.ControllerName = 'Solicitud_Certificado';
        this.MethodGet = 'GetSolicitud_CertificadoDetails';
        this.MethodUpdate = 'UpdateSolicitud_Certificado';
        this.MethodInsert = 'InsertSolicitud_Certificado';
        this.MethodValidarDuplicado = 'GetSolicitud_CertificadoByNombre';
        this.ParamGetName1 = 'id_solicitud';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'solicitante';
        this.ObjDatos = null;
        this.FormEdicion = 'formSolicitud_CertificadoDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;
    }
    
    // Hacer disponible globalmente
    window.Solicitud_Certificado = Solicitud_Certificado;
} else {
    console.log("ℹ️ Solicitud_Certificado ya estaba definido");
}

// Verificar si ya existe la clase Solicitud_CertificadoTrazabilidad
if (typeof Solicitud_CertificadoTrazabilidad === 'undefined') {
    class Solicitud_CertificadoTrazabilidad {
        constructor() {
            // ===============================
            // 🧱 ESTRUCTURA COMPATIBLE con CreateHTMLFromModel
            // ===============================
            
            // Campos para la lógica de base de datos
            this.Campos = [
                { campo: 'Id', tipo: 'number', nullable: false, llave: 'primary' },
                { campo: 'NumeroRadicado', tipo: 'string', nullable: true, llave: '' },
                { campo: 'FechaRadicado', tipo: 'datetime', nullable: true, llave: '' },
                { campo: 'Procedencia', tipo: 'string', nullable: true, llave: '' },
                { campo: 'CorreoElectronico', tipo: 'string', nullable: true, llave: '' },
                { campo: 'TipoDni', tipo: 'string', nullable: true, llave: '' },
                { campo: 'NumeroDni', tipo: 'string', nullable: true, llave: '' },
                { campo: 'DirigidoA', tipo: 'string', nullable: true, llave: '' },
                { campo: 'Asunto', tipo: 'string', nullable: true, llave: '' },
                { campo: 'Pago', tipo: 'string', nullable: true, llave: '' },
                { campo: 'Estado', tipo: 'string', nullable: true, llave: '' },
                { campo: 'Comentarios', tipo: 'string', nullable: true, llave: '' },
                { campo: 'Observaciones', tipo: 'string', nullable: true, llave: '' },
                { campo: 'FechaCreacion', tipo: 'datetime', nullable: true, llave: '' },
                { campo: 'FechaActualizacion', tipo: 'datetime', nullable: true, llave: '' }
            ];

            // Campos para construir el formulario HTML
            this.CamposHTML = [
                [
                    { campo: 'Id', tipo: 'hidden', valor: '' },
                    { campo: 'NumeroRadicado', label: 'Número de Radicado', tipo: 'label', numcols: 4 },
                    { campo: 'FechaRadicado', label: 'Fecha Radicado', tipo: 'label', numcols: 4 },
                    { campo: 'Procedencia', label: 'Solicitante', tipo: 'label', numcols: 4 },
                    { campo: 'CorreoElectronico', label: 'Correo', tipo: 'label', numcols: 6 },
                    { campo: 'TipoDni', label: 'Tipo Documento', tipo: 'label', numcols: 3 },
                    { campo: 'NumeroDni', label: 'Número Documento', tipo: 'label', numcols: 3 },
                    { campo: 'DirigidoA', label: 'Dirigido A', tipo: 'label', numcols: 6 },
                    { campo: 'Asunto', label: 'Asunto', tipo: 'label', numcols: 6 },
                    { campo: 'Pago', label: 'Pago', tipo: 'select', options: ['En verificación', 'Pagado', 'Gratis', 'No ha pagado'], numcols: 6 },
                    { campo: 'Estado', label: 'Estado', tipo: 'select', options: [
                        'En Verificación de Pago',
                        'En Proceso de Expedición',
                        'En proceso de firma',
                        'Enviado al usuario',
                        'No es de competencia o aun no puede expedirse',
                        'Anulado por el estudiante'
                    ], numcols: 6 },
                    { campo: 'Comentarios', label: 'Comentarios', tipo: 'textarea', longitudMax: 500, numcols: 12 },
                    { campo: 'Observaciones', label: 'Observaciones (Automáticas)', tipo: 'label', numcols: 12 },
                    { campo: 'FechaCreacion', label: 'Fecha Creación', tipo: 'label', numcols: 6 },
                    { campo: 'FechaActualizacion', label: 'Fecha Actualización', tipo: 'label', numcols: 6 }
                ]
            ];

            // ===============================
            // ⚙️ Configuración del modelo (REQUERIDA por CreateHTMLFromModel)
            // ===============================
            this.CampoLlave = 'Id';
            this.Nombre = 'Solicitud'; 
            this.ControllerName = 'Solicitud_CertificadoTrazabilidad';
            this.MethodGet = 'GetSolicitud_CertificadoTrazabilidadDetails';
            this.MethodUpdate = 'UpdateSolicitud_CertificadoTrazabilidad';
            this.MethodInsert = ''; // No usado en trazabilidad
            this.MethodValidarDuplicado = '';
            this.ParamGetName1 = 'Id';
            this.ParamGetName2 = '';
            this.ParamGetName3 = '';
            this.ParamDuplicadoName = '';
            this.ObjDatos = null;
            this.FormEdicion = 'formSolicitud_CertificadoDetalle';
            this.IsModal = false;
            this.DatosNullEdicion = true;

            // URLs para API
            this.urlController = urlController + "Solicitud_CertificadoTrazabilidad/";
            this.urlGetDetail = this.urlController + "GetSolicitud_CertificadoTrazabilidadDetails";
            this.urlUpdate = this.urlController + "UpdateSolicitud_CertificadoTrazabilidad";
        }
    }
    
    // Hacer disponible globalmente
    window.Solicitud_CertificadoTrazabilidad = Solicitud_CertificadoTrazabilidad;
} else {
    console.log("ℹ️ Solicitud_CertificadoTrazabilidad ya estaba definido");
}

// ============================================================
// ✅ CONFIRMACIÓN DE CARGA
// ============================================================
console.log("✅ Solicitud_CertificadoModel.js cargado correctamente");
console.log("Solicitud_Certificado definido:", typeof Solicitud_Certificado !== 'undefined');
console.log("Solicitud_CertificadoTrazabilidad definido:", typeof Solicitud_CertificadoTrazabilidad !== 'undefined');