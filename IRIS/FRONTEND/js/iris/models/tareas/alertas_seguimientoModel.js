function Alerta_Seguimiento() {
        
    this.Campos = [
        {campo: 'idalertaseguimiento', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'opcion', tipo: 'string', nullable: false, llave: 'foranea'},        
        {campo: 'usuario', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'estado', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'consecutivo', tipo: 'string', nullable: false, llave: ''},
        {campo: 'tituloalerta', tipo: 'string', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fechavence', tipo: 'date', nullable: false, llave: ''}                    
    ];

    this.CamposHTML = [
        [
            {campo: 'idalertaseguimiento', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'opcion', tipo: 'string', nullable: true, llave: 'foranea'},            
            {campo: 'usuario', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'estado', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'consecutivo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Consecutivo', placeholder: 'Consecutivo', title: '', numcols: 2, maxlength: 40, funconchange: null, funconclick: null},
            {campo: 'tituloalerta', tipo: 'string', nullable: false, llave: '', etiqueta: 'Título Notificación', placeholder: 'Título Notificación', title: '', numcols: 3, maxlength: 40, funconchange: null, funconclick: null},
            {campo: 'fechavence', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Vencimiento', placeholder: '', title: 'Fecha Vencimiento', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Detalle Notificación', placeholder: 'Detalle Notificación', title: '', numcols: 5, numrows: 2, maxlength: 150, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'idalertaseguimiento';
    this.Nombre = 'Alerta_Seguimiento';
    this.ControllerName = 'Alerta_Seguimiento';
    this.MethodGet = 'GetAlerta_SeguimientoDetails';
    this.MethodUpdate = 'UpdateAlerta_Seguimiento';
    this.MethodInsert = 'InsertAlerta_Seguimiento';
    this.ParamGetName1 = 'idalertaseguimiento';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formModalGenerarAlertaUsuario';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}


function Alerta_SeguimientoGeneral() {
        
    this.Campos = [
        {campo: 'idalertaseguimiento', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'usuario', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'estado', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'opcion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'consecutivo', tipo: 'string', nullable: false, llave: ''},
        {campo: 'tituloalerta', tipo: 'string', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fechavence', tipo: 'date', nullable: false, llave: ''}                    
    ];

    this.CamposHTML = [
        [
            {campo: 'idalertaseguimiento', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'usuario', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'estado', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'opcion', tipo: 'string', nullable: false, llave: '', etiqueta: 'Módulo', placeholder: 'Módulo', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'consecutivo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Consecutivo', placeholder: 'Consecutivo', title: '', numcols: 2, maxlength: 40, funconchange: null, funconclick: null},
            {campo: 'tituloalerta', tipo: 'string', nullable: false, llave: '', etiqueta: 'Título Notificación', placeholder: 'Título Notificación', title: '', numcols: 3, maxlength: 40, funconchange: null, funconclick: null},
            {campo: 'fechavence', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Vencimiento', placeholder: '', title: 'Fecha Vencimiento', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Detalle Notificación', placeholder: 'Detalle Notificación', title: '', numcols: 8, numrows: 1, maxlength: 150, funconchange: null, funconclick: null}
        ]        
    ];

    this.CampoLlave = 'idalertaseguimiento';
    this.Nombre = 'Alerta_SeguimientoGeneral';
    this.ControllerName = 'Alerta_Seguimiento';
    this.MethodGet = 'GetAlerta_SeguimientoDetails';
    this.MethodUpdate = 'UpdateAlerta_Seguimiento';
    this.MethodInsert = 'InsertAlerta_Seguimiento';
    this.ParamGetName1 = 'idalertaseguimiento';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formModalGenerarAlertaUsuarioGeneral';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
