function Publicaciones_DepositoDisposicionLegal() {
        
    this.Campos = [
        {campo: 'iddisposicionlegal', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'disposicionlegal', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'iddisposicionlegal', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'disposicionlegal', tipo: 'string', nullable: false, llave: '', etiqueta: 'Disposición Legal', placeholder: 'Disposición Legal', title: '', numcols: 8, maxlength: 70, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'iddisposicionlegal';
    this.Nombre = 'Publicaciones_DepositoDisposicionLegal';
    this.ControllerName = 'Publicaciones_DepositoDisposicionLegal';
    this.MethodGet = 'GetPublicaciones_DepositoDisposicionLegalDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoDisposicionLegal';
    this.MethodInsert = 'InsertPublicaciones_DepositoDisposicionLegal';
    this.ParamGetName1 = 'iddisposicionlegal';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DepositoDisposicionLegal';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
