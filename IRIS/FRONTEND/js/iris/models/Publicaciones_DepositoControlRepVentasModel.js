function Publicaciones_DepositoControlRepVentas() {
        
    this.Campos = [
        {campo: 'id_repventas', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'iddistribuidor', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionComercializadorSelect, loadnulo: false},
        {campo: 'unidadesvendidas', tipo: 'int', nullable: false, llave: ''},
        {campo: 'valorventas', tipo: 'num', nullable: false, llave: ''},
        {campo: 'valorcomision', tipo: 'num', nullable: false, llave: ''},
        {campo: 'fecreporte', tipo: 'date', nullable: false, llave: ''},
        {campo: 'revisado', tipo: 'bool', nullable: false, llave: ''}        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_repventas', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'iddistribuidor', tipo: 'select', nullable: false, llave: '', etiqueta: 'Distribuidor Comercial', placeholder: '', title: 'Distribuidor Comercial', numcols: 4, funconchange: null, funconclick: null},
            {campo: 'fecreporte', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Reporte', placeholder: '', title: 'Fecha Reporte', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'unidadesvendidas', tipo: 'int', nullable: false, llave: '', etiqueta: 'Cantidad', placeholder: '', title: 'Cantidad', numcols: 2, minimo: 1, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'valorventas', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Ventas', placeholder: '', title: 'Valor Ventas', numcols: 2, minimo: 1, funconchange: null, funconclick: null},
            {campo: 'valorcomision', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Comisión', placeholder: '', title: 'Valor Comisión', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'revisado', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Revisado', placeholder: '', title: 'Revisado', numcols: 3, funconchange: null, funconclick: null},
        ]
    ];

    this.CampoLlave = 'id_repventas';
    this.Nombre = 'Publicaciones_DepositoControlRepVentas';
    this.ControllerName = 'Publicaciones_DepositoControlRepVentas';
    this.MethodGet = 'GetPublicaciones_DepositoControlRepVentasDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoControlRepVentas';
    this.MethodInsert = 'InsertPublicaciones_DepositoControlRepVentas';
    this.ParamGetName1 = 'id_repventas';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DepositoControlRepVentas';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
