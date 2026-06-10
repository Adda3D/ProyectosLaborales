function Publicaciones_DepositoControlCertVentas() {
        
    this.Campos = [
        {campo: 'id_certventas', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},        
        {campo: 'libroscert', tipo: 'int', nullable: false, llave: ''},        
        {campo: 'fecenvio', tipo: 'date', nullable: false, llave: ''},
        {campo: 'enviado', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'nrocertificado', tipo: 'string', nullable: true, llave: ''}    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_certventas', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},            
            {campo: 'fecenvio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Envío', placeholder: '', title: 'Fecha envío a Tesorería y Almacén Gral', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'libroscert', tipo: 'int', nullable: false, llave: '', etiqueta: 'Libros Certificados', placeholder: '', title: 'Libros Certificados', numcols: 3, minimo: 1, funconchange: null, funconclick: null},
            {campo: 'enviado', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Enviado', placeholder: '', title: 'Enviado', numcols: 3, funconchange: null, funconclick: null},
            {campo: 'nrocertificado', tipo: 'string', nullable: true, llave: '', etiqueta: 'No. Certificado', placeholder: 'Nro. Certificado', title: '', numcols: 2, maxlength: 20, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_certventas';
    this.Nombre = 'Publicaciones_DepositoControlCertVentas';
    this.ControllerName = 'Publicaciones_DepositoControlCertVentas';
    this.MethodGet = 'GetPublicaciones_DepositoControlCertVentasDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoControlCertVentas';
    this.MethodInsert = 'InsertPublicaciones_DepositoControlCertVentas';
    this.ParamGetName1 = 'id_certventas';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DepositoControlCertVentas';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
