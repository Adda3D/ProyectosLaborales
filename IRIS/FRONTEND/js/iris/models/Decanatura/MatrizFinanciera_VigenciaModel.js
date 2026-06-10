function MatrizFinanciera_Vigencia () {
    
        
    this.Campos = [
        {campo: 'id_vigencia', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'codvigencia', tipo: 'string', nullable: false, llave: ''},
        {campo: 'nmvigencia', tipo: 'string', nullable: false, llave: '', allowduplicate: false}
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_vigencia', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'codvigencia', tipo: 'string', nullable: false, llave: '', etiqueta: 'Código Vigencia', placeholder: 'Código Vigencia', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'nmvigencia', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Vigencia', placeholder: 'Nombre Vigencia', title: '', numcols: 5, maxlength: 50, funconchange: null, funconclick: null},
            
        ]
     
    ];

    this.CampoLlave = 'id_vigencia';
    this.Nombre = 'MatrizFinanciera_Vigencia';
    this.ControllerName = 'MatrizFinanciera_Vigencia';
    this.MethodGet = 'GetMatrizFinanciera_VigenciaDetails';
    this.MethodUpdate = 'UpdateMatrizFinanciera_Vigencia';
    this.MethodInsert = 'InsertMatrizFinanciera_Vigencia';
    this.MethodValidarDuplicado = 'GetMatrizFinanciera_VigenciaNombre';
    this.ParamGetName1 = 'id_vigencia';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nmvigencia';
    this.ObjDatos = null;
    this.FormEdicion = 'formMatrizFinanciera_VigenciaDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;

}