function MatrizFinanciera_GastoOperativo () {
    
        
    this.Campos = [
        {campo: 'id_gastooperativo', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_matrizfinanciera', tipo: 'string', nullable: false, llave: 'foreign'},
        {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},         
        {campo: 'id_tipooperativo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMatrizFinanciera_TipoOperativoSelect, loadnulo: false},
        {campo: 'totalpersonascontratadas', tipo: 'int', nullable: false, llave: ''},
        {campo: 'valortotal', tipo: 'int', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_gastooperativo', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_matrizfinanciera', tipo: 'string', nullable: true, llave: 'foreign'},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', etiqueta: 'Dependencia', placeholder: '', title: '', numcols: 4, maxlength: 20, funconchange: null, funconclick: null},
            {campo: 'id_tipooperativo', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Operativo', placeholder: '', title: '', numcols: 4, maxlength: 150, funconchange: null, funconclick: null},
            {campo: 'totalpersonascontratadas', tipo: 'int', nullable: true, llave: '', etiqueta: 'Total Personal Contratado', placeholder: 'Total Personal Contratado', title: '', numcols: 4, maxlength: 12, funconchange: null, funconclick: null},
            
        ],
        [
            {campo: 'valortotal', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Total', placeholder: 'Valor Total', title: '', numcols: 6, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows:2, maxlength: 500, funconchange: null, funconclick: null}
        ]
     
    ];

    this.CampoLlave = 'id_gastooperativo';
    this.Nombre = 'MatrizFinanciera_GastoOperativo';
    this.ControllerName = 'MatrizFinanciera_GastoOperativo';
    this.MethodGet = 'GetMatrizFinanciera_GastoOperativoDetails';
    this.MethodUpdate = 'UpdateMatrizFinanciera_GastoOperativo';
    this.MethodInsert = 'InsertMatrizFinanciera_GastoOperativo';
    //this.MethodValidarDuplicado = 'GetMatrizFinanciera_GastoOperativoNombre';
    this.ParamGetName1 = 'id_gastooperativo';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_nmprogramapgd';
    this.ObjDatos = null;
    this.FormEdicion = 'formMatrizFinanciera_GastoOperativoDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;


}