function Publicaciones_DepositoResolucion() {
        
    this.Campos = [
        {campo: 'id_resolucion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'numresolucion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'quiengenera', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecresolucion', tipo: 'date', nullable: false, llave: ''},
        {campo: 'actoadmin', tipo: 'string', nullable: true, llave: ''},
        {campo: 'ejemplaresinstitucional', tipo: 'int', nullable: false, llave: ''},
        {campo: 'ejemplaresinmovil', tipo: 'int', nullable: false, llave: ''},        
        {campo: 'ejemplarescomercializa', tipo: 'int', nullable: false, llave: ''},
        {campo: 'tirajeimpresion', tipo: 'int', nullable: false, llave: ''},
        {campo: 'tirajetotal', tipo: 'int', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_resolucion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'numresolucion', tipo: 'string', nullable: false, llave: '', etiqueta: 'No. Resolución', placeholder: 'No. Resolución', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'quiengenera', tipo: 'string', nullable: true, llave: '', etiqueta: 'Genera Resolución', placeholder: 'Genera Resolución', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'fecresolucion', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Resolución', placeholder: '', title: 'Fecha Resolución', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'actoadmin', tipo: 'string', nullable: true, llave: '', etiqueta: 'Contrato Coedición', placeholder: 'Contrato Coedición', title: 'Es coedición? Acto Administrativo', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'ejemplaresinstitucional', tipo: 'int', nullable: false, llave: '', etiqueta: 'Ejemplares Institucional', placeholder: '', title: 'No. Ejemplares distribución Institucional', numcols: 2, minimo: 0, funconchange: "SumarTotales('nmejemplaresinstitucional_Publicaciones_DepositoResolucion','nmejemplarescomercializa_Publicaciones_DepositoResolucion',null,null,'nmtirajetotal_Publicaciones_DepositoResolucion');", funconclick: null},
            {campo: 'ejemplarescomercializa', tipo: 'int', nullable: false, llave: '', etiqueta: 'Ejemplares Comercialización', placeholder: '', title: 'No. Ejemplares para Comercialización', numcols: 2, minimo: 0, funconchange: "SumarTotales('nmejemplaresinstitucional_Publicaciones_DepositoResolucion','nmejemplarescomercializa_Publicaciones_DepositoResolucion',null,null,'nmtirajetotal_Publicaciones_DepositoResolucion');", funconclick: null},
        ],
        [
            {campo: 'tirajeimpresion', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiraje en Impresión', placeholder: '', title: 'Tiraje en Impresión', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'tirajetotal', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiraje Total', placeholder: '', title: 'Tiraje Total Impreso', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'ejemplaresinmovil', tipo: 'int', nullable: false, llave: '', etiqueta: 'Ejemplares Inmovilizados', placeholder: '', title: 'No. Ejemplares Inmovilizados', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_resolucion';
    this.Nombre = 'Publicaciones_DepositoResolucion';
    this.ControllerName = 'Publicaciones_DepositoResolucion';
    this.MethodGet = 'GetPublicaciones_DepositoResolucionByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoResolucion';
    this.MethodInsert = 'InsertPublicaciones_DepositoResolucion';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionResolucionDistribucion';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
