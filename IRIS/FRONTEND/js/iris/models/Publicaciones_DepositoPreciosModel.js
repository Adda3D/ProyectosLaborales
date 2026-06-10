function Publicaciones_DepositoPrecios() {
        
    this.Campos = [
        {campo: 'id_precios', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'pvpublico', tipo: 'num', nullable: false, llave: ''},
        {campo: 'pvcunal', tipo: 'num', nullable: false, llave: ''},
        {campo: 'pvdigital', tipo: 'num', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_precios', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'pvpublico', tipo: 'num', nullable: false, llave: '', etiqueta: 'Precio Venta Público', placeholder: '', title: 'Precio Venta Público', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'pvcunal', tipo: 'num', nullable: false, llave: '', etiqueta: 'Precio Venta UNAL', placeholder: '', title: 'Precio Venta Comunidad UNAL', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'pvdigital', tipo: 'num', nullable: false, llave: '', etiqueta: 'Precio Venta Digital', placeholder: '', title: 'Precio Venta Digital', numcols: 2, minimo: 0, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_precios';
    this.Nombre = 'Publicaciones_DepositoPrecios';
    this.ControllerName = 'Publicaciones_DepositoPrecios';
    this.MethodGet = 'GetPublicaciones_DepositoPreciosByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoPrecios';
    this.MethodInsert = 'InsertPublicaciones_DepositoPrecios';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionPreciosDistribucion';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
