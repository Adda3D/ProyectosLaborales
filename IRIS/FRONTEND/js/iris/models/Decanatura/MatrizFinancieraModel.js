function MatrizFinanciera () {
    
    this.Campos = [
        {campo: 'id_matrizfinanciera', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},
        {campo: 'id_vigencia', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMatrizFinanciera_VigenciaSelect, loadnulo: false},
        {campo: 'presupuestogeneral', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestogeneralcomprometido', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestogeneralcomprometer', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestougi', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestougicomprometido', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestougicomprometer', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestoestudiantes', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestoestudiantescomprometido', tipo: 'int', nullable: false, llave: ''},
        {campo: 'presupuestoestudiantescomprometer', tipo: 'int', nullable: false, llave: ''}
            
    ];

    this.CamposHTML = [
        [
            {campo: 'id_matrizfinanciera', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: true, llave: 'foreign'},
            {campo: 'id_vigencia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Vigencia', placeholder: '', title: '', numcols: 3, maxlength: 20, funconchange: null, funconclick: null},
        ],
        [    
            {campo: 'presupuestogeneral', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto General Regulado', placeholder: 'Presupuesto General Regulado', title: '', numcols: 4, maxlength: 12, funconchange: "MatrizFinancieraValorXComprometerGeneral()", funconclick: null},
            {campo: 'presupuestogeneralcomprometido', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto General Regulado Comprometido', placeholder: 'Presupuesto General Regulado Comprometido', title: '', numcols: 4, maxlength: 12, funconchange: "MatrizFinancieraValorXComprometerGeneral()", funconclick: null},
            {campo: 'presupuestogeneralcomprometer', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto General Regulado por Comprometer', placeholder: 'Presupuesto General Regulado por Comprometer', title: '', numcols: 4, maxlength: 12, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'presupuestougi', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto UGI', placeholder: 'Presupuesto UGI', title: '', numcols: 4, maxlength: 12, funconchange: "MatrizFinancieraValorXComprometerUGI()", funconclick: null},
            {campo: 'presupuestougicomprometido', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto UGI Comprometido', placeholder: 'Presupuesto UGI Comprometido', title: '', numcols: 4, maxlength: 12, funconchange: "MatrizFinancieraValorXComprometerUGI()", funconclick: null},
            {campo: 'presupuestougicomprometer', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto UGI por Comprometer', placeholder: 'Presupuesto UGI por Comprometer', title: '', numcols: 4, maxlength: 12, funconchange: null, funconclick: null}
        ],
        [ 
            {campo: 'presupuestoestudiantes', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Estudiantes Regulado', placeholder: 'Presupuesto Estudiantes Regulado', title: '', numcols: 4, maxlength: 12, funconchange: "MatrizFinancieraValorXComprometerEST()", funconclick: null},
            {campo: 'presupuestoestudiantescomprometido', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Estudiantes Regulado Comprometido', placeholder: 'Presupuesto Estudiantes Regulado Comprometido', title: '', numcols: 4, maxlength: 12, funconchange: "MatrizFinancieraValorXComprometerEST()", funconclick: null},
            {campo: 'presupuestoestudiantescomprometer', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Estudiantes Regulado por Comprometer', placeholder: 'Presupuesto Estudiantes Regulado por Comprometer', title: '', numcols: 4, maxlength: 12, funconchange: null, funconclick: null}
        ]
        
    ];

    this.CampoLlave = 'id_matrizfinanciera';
    this.Nombre = 'MatrizFinanciera';
    this.ControllerName = 'MatrizFinanciera';
    this.MethodGet = 'GetMatrizFinancieraDetails';
    this.MethodUpdate = 'UpdateMatrizFinanciera';
    this.MethodInsert = 'InsertMatrizFinanciera';
 // this.MethodValidarDuplicado = 'GetMatrizFinancieraNombre';
    this.ParamGetName1 = 'id_matrizfinanciera';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
 // this.ParamDuplicadoName = 'cd_tituloconvocatoria';
    this.ObjDatos = null;
    this.FormEdicion = 'formMatrizFinancieraDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;

}