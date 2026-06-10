function MatrizFinanciera_TipoOperativo () {
    
        
    this.Campos = [
        {campo: 'id_tipooperativo', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'codtipooperativo', tipo: 'string', nullable: false, llave: ''},
        {campo: 'nmtipooperativo', tipo: 'string', nullable: false, llave: '', allowduplicate: 'false'}
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_tipooperativo', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'codtipooperativo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Código Tipo', placeholder: 'Código Tipo', title: '', numcols: 6, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'nmtipooperativo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Tipo Operativo', placeholder: 'Nombre Tipo Operativo', title: '', numcols: 6, maxlength: 150, funconchange: null, funconclick: null}
        ]
        
     
    ];

    this.CampoLlave = 'id_tipooperativo';
    this.Nombre = 'MatrizFinanciera_TipoOperativo';
    this.ControllerName = 'MatrizFinanciera_TipoOperativo';
    this.MethodGet = 'GetMatrizFinanciera_TipoOperativoDetails';
    this.MethodUpdate = 'UpdateMatrizFinanciera_TipoOperativo';
    this.MethodInsert = 'InsertMatrizFinanciera_TipoOperativo';
    this.MethodValidarDuplicado = 'GetMatrizFinanciera_TipoOperativoNombre';
    this.ParamGetName1 = 'id_tipooperativo';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nmtipooperativo';
    this.ObjDatos = null;
    this.FormEdicion = 'formMatrizFinanciera_TipoOperativoDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;


}