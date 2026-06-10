function Suscripcion_Liquidacion() {
    this.Campos = [
        {campo: 'id_suscripcionliquidcion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_asignacionproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
       // {campo: '[ObjProyecto][nombreentidad]', tipo: 'string', nullable: false, llave: '', noupdate: true},
        {campo: 'entregablesoproductosporentregar', tipo: 'string', nullable: true, llave: ''},
        {campo: 'desembolsospendientes', tipo: 'string', nullable: true, llave: ''},
        {campo: 'observacionesestadoproyecto', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecsolactliquidacion', tipo: 'date', nullable: false, llave: ''},
        {campo: 'consecutivosolactaliquidacion', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecressolliquidacion', tipo: 'date', nullable: true, llave: ''},
        {campo: 'observacionessolliquidacion', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecrecepactliquidacion', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecrevactliquidacion', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecsolinftesoreria', tipo: 'date', nullable: true, llave: ''},
        {campo: 'consecutivosolinftesoreria', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecremdecobspreliminares', tipo: 'date', nullable: true, llave: ''},
        {campo: 'consecutivoremdecanatura', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecrespdecanatura', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecintegraobservacionesal', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecremalobsentidad', tipo: 'date', nullable: true, llave: ''},
        {campo: 'consecutivoremalobs', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecrespentidad', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecrevfinalal', tipo: 'date', nullable: true, llave: ''},
        {campo: 'avalesinternos', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'fecremdecverfinalal', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecrecfirmdec', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecremalfirmentidad', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecrecaltodasfirmas', tipo: 'date', nullable: true, llave: ''},
        {campo: 'idfuncionario', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariosolicitaacta', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioobservacta', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariorecepcionacta', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariorevisionacta', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariosolicinfotesoreria', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioremiobservdecanatura', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioresptadecanatura', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariointegraobserv', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioremiobserventidad', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioremidecaversionfinal', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariofirmadeca', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioremitefirmadaentidad', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionario', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_suscripcionliquidcion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_asignacionproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'entregablesoproductosporentregar', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Productos Por Entregar', placeholder: 'Productos Por Entregar', title: '', numcols: 3, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null},
           // {campo: '[ObjProyecto][nombreentidad]', tipo: 'string', nullable: true, llave: '', etiqueta: 'Entidad Responsable', placeholder: '', title: 'Entidad Responsable Productos por Entregar', numcols: 2, maxlength: 300, funconchange: null, funconclick: null},
            {campo: 'desembolsospendientes', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Desembolsos Pendientes', placeholder: 'Desembolsos Pendientes', title: '', numcols: 3, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'idfuncionario', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Desembolsos', numcols: 2, funconchange: null, funconclick: null},            
            {campo: 'observacionesestadoproyecto', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones Estado', placeholder: '', title: 'Observaciones Estado del proyecto', numcols: 3, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null}
        ],
        [            
            {campo: 'fecsolactliquidacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Solic. Acta', placeholder: '', title: 'Fecha Solicitud Acta Liquidación', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'consecutivosolactaliquidacion', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consecutivo Solicitud', placeholder: '', title: 'Consecutivo Solicitud Acta', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'idfuncionariosolicitaacta', tipo: 'select', nullable: false, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Solicitud Acta', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecressolliquidacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Rpta Solicitud', placeholder: '', title: 'Fecha Respuesta Solicitud Acta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observacionessolliquidacion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones Solicitud', placeholder: '', title: 'Observaciones Solicitud Acta', numcols: 2, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioobservacta', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Observaciones Acta', numcols: 2, funconchange: null, funconclick: null}            
        ],
        [
            {campo: 'fecrecepactliquidacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Recepción Acta', placeholder: '', title: 'Fecha Recepción Acta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionariorecepcionacta', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Recepción Acta', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrevactliquidacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Revisión Acta', placeholder: '', title: 'Fecha Revisión Acta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionariorevisionacta', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Revisión Acta', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecsolinftesoreria', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Solic. Tesorería', placeholder: '', title: 'Fecha Solicitud Información Tesorería', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'consecutivosolinftesoreria', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consecutivo Solic. Tesorería', placeholder: '', title: 'Consecutivo Solicitud Informacion Tesorería', numcols: 2, maxlength: 30, funconchange: null, funconclick: null}            
        ],
        [
            {campo: 'idfuncionariosolicinfotesoreria', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Solicitud Informacion Tesorería', numcols: 2, funconchange: null, funconclick: null},            
            {campo: 'fecremdecobspreliminares', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Remite Observ.', placeholder: '', title: 'Fecha Remisión Observaciones Acta a Decanatura', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'consecutivoremdecanatura', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consecutivo Remite Observ.', placeholder: '', title: 'Consecutivo Remisión Observaciones Acta a Decanatura', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioremiobservdecanatura', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Remisión Observaciones Acta a Decanatura', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrespdecanatura', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Rpta Decanatura', placeholder: '', title: 'Fecha Respuesta Decanatura', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioresptadecanatura', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Respuesta Decanatura', numcols: 2, funconchange: null, funconclick: null}            
        ],
        [
            {campo: 'fecintegraobservacionesal', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Integra Observ.', placeholder: '', title: 'Fecha Integra Observaciones Acta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionariointegraobserv', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Integra Observaciones Acta', numcols: 2, funconchange: null, funconclick: null}
        ],
        [            
            {campo: 'fecremalobsentidad', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Remite Entidad', placeholder: '', title: 'Fecha Remisión Acta a la Entidad', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'consecutivoremalobs', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consecutivo Remite Entidad', placeholder: '', title: 'Consecutivo Remisión Acta a la Entidad', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioremiobserventidad', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Remisión Acta a la Entidad', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrespentidad', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Rpta Entidad', placeholder: '', title: 'Fecha respuesta de la Entidad', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fecrevfinalal', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Revisión Final', placeholder: '', title: 'Fecha Revisión Final Acta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'avalesinternos', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Avales Internos', placeholder: '', title: 'Avales Internos', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecremdecverfinalal', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Remite V. Final', placeholder: '', title: 'Fecha Remisión Versión Final Acta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioremidecaversionfinal', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Remisión Versión Final Acta', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrecfirmdec', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Recep. Firmada', placeholder: '', title: 'Fecha Recepción Acta Firmada Decanatura', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionariofirmadeca', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Recepción Acta Firmada Decanatura', numcols: 2, funconchange: null, funconclick: null}        
        ],
        [
            {campo: 'fecremalfirmentidad', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Remite Entidad', placeholder: '', title: 'Fecha Remite Acta Firmada Entidad', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioremitefirmadaentidad', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable Remisión Acta Firmada Entidad', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrecaltodasfirmas', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Recep. Todas', placeholder: '', title: 'Fecha Recepción Todas las firmas', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 2, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_suscripcionliquidcion';
    this.Nombre = 'Proyecto_Suscripcion_Liquidacion';
    this.ControllerName = 'Suscripcion_Liquidacion';
    this.MethodGet = 'GetSuscripcion_LiquidacionByProyecto';
    this.MethodUpdate = 'UpdateSuscripcion_Liquidacion';
    this.MethodInsert = 'InsertSuscripcion_Liquidacion';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_asignacionproyecto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formproyectoextensionPEL_SuscripcionActa';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';    
}