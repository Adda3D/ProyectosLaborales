function Publicaciones_DepositoDistribucion() {
        
    this.Campos = [
        {campo: 'id_distribucion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'iddisposicionlegal', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionDisposicionLegalSelect, loadnulo: false},
        {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: ''},
        {campo: 'cantidad', tipo: 'int', nullable: false, llave: ''},
        {campo: 'notas', tipo: 'string', nullable: true, llave: ''},
    ];

    this.CamposHTML = [
        [
            {campo: 'id_distribucion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'iddisposicionlegal', tipo: 'select', nullable: false, llave: '', etiqueta: 'Disposición Legal', placeholder: '', title: 'Disposición Legal', numcols: 4, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Entrega', placeholder: '', title: 'Fecha Entrega', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'cantidad', tipo: 'int', nullable: false, llave: '', etiqueta: 'Cantidad', placeholder: '', title: 'Cantidad', numcols: 2, minimo: 1, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'notas', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_distribucion';
    this.Nombre = 'Publicaciones_DepositoDistribucion';
    this.ControllerName = 'Publicaciones_DepositoDistribucion';
    this.MethodGet = 'GetPublicaciones_DepositoDistribucionDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoDistribucion';
    this.MethodInsert = 'InsertPublicaciones_DepositoDistribucion';
    this.ParamGetName1 = 'id_distribucion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DepositoDistribucion';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
