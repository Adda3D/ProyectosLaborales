function Publicaciones_Digitalizacion() {
        
    this.Campos = [
        {campo: 'id_digitalizacion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
        {campo: 'versionpreliminareb', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'solajustesunijus', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'verfinaleb', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'envcomercializacion', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'fechainicio', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: ''},
        {campo: 'comentariosdig', tipo: 'string', nullable: true, llave: ''}        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_digitalizacion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Proveedor', placeholder: '', title: 'Proveedor', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fechainicio', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Entrega', placeholder: '', title: 'Fecha Entrega', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'versionpreliminareb', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Ver. Preliminar eBook', placeholder: '', title: 'Ver. Preliminar eBook', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'solajustesunijus', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Ajustes UNIJUS', placeholder: '', title: 'Ajustes UNIJUS', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'verfinaleb', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Ver. Final eBook', placeholder: '', title: 'Ver. Final eBook', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'envcomercializacion', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Envío Comercialización', placeholder: '', title: 'Envío Comercialización', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'comentariosdig', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Comentarios Digitalización', placeholder: 'Comentarios Digitalización', title: '', numcols: 4, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_digitalizacion';
    this.Nombre = 'Publicaciones_Digitalizacion';
    this.ControllerName = 'Publicaciones_Digitalizacion';
    this.MethodGet = 'GetPublicaciones_DigitalizacionByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_Digitalizacion';
    this.MethodInsert = 'InsertPublicaciones_Digitalizacion';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDetalleDigitalizacion';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
