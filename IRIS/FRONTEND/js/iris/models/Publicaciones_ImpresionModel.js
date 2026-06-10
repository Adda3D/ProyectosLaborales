function Publicaciones_Impresion() {
        
    this.Campos = [
        {campo: 'id_impresion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_encuadernacion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadImpresionTipoEncuadernacionSelect, loadnulo: true},
        {campo: 'id_papel', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadImpresionTipoPapelSelect, loadnulo: true},
        {campo: 'id_impresiontipo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadImpresionTipoImpresionSelect, loadnulo: true},
        {campo: 'id_gramaje', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadImpresionTipoGramajeSelect, loadnulo: true},
        {campo: 'id_tintastaco', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadImpresionTintasTacoSelect, loadnulo: true},
        {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
        {campo: 'paginasfinales', tipo: 'int', nullable: false, llave: ''},
        {campo: 'tiraje', tipo: 'int', nullable: false, llave: ''},
        {campo: 'fecinicio', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecentrega', tipo: 'date', nullable: true, llave: ''},
        {campo: 'pruebaimpresion', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'imptodotiraje', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'comentariosimpresion', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_impresion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_encuadernacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Encuadernación', placeholder: '', title: 'Tipo Encuadernación', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_papel', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Papel', placeholder: '', title: 'Tipo Papel', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_impresiontipo', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Impresión', placeholder: '', title: 'Tipo Impresión', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_gramaje', tipo: 'select', nullable: false, llave: '', etiqueta: 'Gramaje', placeholder: '', title: 'Gramaje', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'paginasfinales', tipo: 'int', nullable: false, llave: '', etiqueta: 'No. Páginas Finales', placeholder: '', title: 'No. Páginas Finales', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'id_tintastaco', tipo: 'select', nullable: false, llave: '', etiqueta: 'No. Tintas', placeholder: '', title: 'No. Tintas', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'tiraje', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiraje', placeholder: '', title: 'Tiraje', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Proveedor', placeholder: 'Proveedor', title: '', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecinicio', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fecentrega', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Entrega', placeholder: '', title: 'Fecha Entrega', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'pruebaimpresion', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Prueba Impresión', placeholder: '', title: 'Prueba Impresión', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'imptodotiraje', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Todo el tiraje', placeholder: '', title: 'Impresión Todo el tiraje', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'comentariosimpresion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Comentarios Impresión', placeholder: 'Comentarios Impresión', title: '', numcols: 4, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_impresion';
    this.Nombre = 'Publicaciones_Impresion';
    this.ControllerName = 'Publicaciones_Impresion';
    this.MethodGet = 'GetPublicaciones_ImpresionByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_Impresion';
    this.MethodInsert = 'InsertPublicaciones_Impresion';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDetalleImpresion';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
