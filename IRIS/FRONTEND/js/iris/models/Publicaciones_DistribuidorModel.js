function Publicaciones_Distribuidor() {
        
    this.Campos = [
        {campo: 'iddistribuidor', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'distribuidor', tipo: 'string', nullable: false, llave: ''},
        {campo: 'direccion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'telefono', tipo: 'int', nullable: false, llave: ''},
        {campo: 'correo', tipo: 'email', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'iddistribuidor', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'distribuidor', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Distribuidor', placeholder: 'Nombre Distribuidor', title: '', numcols: 2, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'direccion', tipo: 'string', nullable: false, llave: '', etiqueta: 'Dirección', placeholder: 'Dirección', title: '', numcols: 2, maxlength: 150, funconchange: null, funconclick: null},
            {campo: 'telefono', tipo: 'int', nullable: false, llave: '', etiqueta: 'Teléfono', placeholder: '', title: 'Teléfono', numcols: 2, minimo: 0, funconchange: null, funconclick: null},            
            {campo: 'correo', tipo: 'email', nullable: false, llave: '', etiqueta: 'E-mail', placeholder: 'E-mail', title: '', numcols: 2, maxlength: 100, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'iddistribuidor';
    this.Nombre = 'Publicaciones_Distribuidor';
    this.ControllerName = 'Publicaciones_Distribuidor';
    this.MethodGet = 'GetPublicaciones_DistribuidorDetails';
    this.MethodUpdate = 'UpdatePublicaciones_Distribuidor';
    this.MethodInsert = 'InsertPublicaciones_Distribuidor';
    this.ParamGetName1 = 'iddistribuidor';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DistribuidorDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
