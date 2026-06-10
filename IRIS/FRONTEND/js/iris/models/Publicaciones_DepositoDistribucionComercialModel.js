function Publicaciones_DepositoDistribucionComercial() {
        
    this.Campos = [
        {campo: 'id_distribucioncomercial', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'iddistribuidor', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionComercializadorSelect, loadnulo: false},
        {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: ''},                
        {campo: 'cantidad', tipo: 'int', nullable: false, llave: ''},
        {campo: 'notas', tipo: 'string', nullable: true, llave: ''},    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_distribucioncomercial', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'iddistribuidor', tipo: 'select', nullable: false, llave: '', etiqueta: 'Distribuidor Comercial', placeholder: '', title: 'Distribuidor Comercial', numcols: 4, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Entrega', placeholder: '', title: 'Fecha Entrega', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'cantidad', tipo: 'int', nullable: false, llave: '', etiqueta: 'Cantidad', placeholder: '', title: 'Cantidad', numcols: 2, minimo: 1, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'notas', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]        
    ];

    this.CampoLlave = 'id_distribucioncomercial';
    this.Nombre = 'Publicaciones_DepositoDistribucionComercial';
    this.ControllerName = 'Publicaciones_DepositoDistribucionComercial';
    this.MethodGet = 'GetPublicaciones_DepositoDistribucionComercialDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoDistribucionComercial';
    this.MethodInsert = 'InsertPublicaciones_DepositoDistribucionComercial';
    this.ParamGetName1 = 'id_distribucioncomercial';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DepositoDistribucionComercial';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
