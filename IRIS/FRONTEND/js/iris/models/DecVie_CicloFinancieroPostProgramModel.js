function DecVie_CicloFinancieroPostProgram () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_programapostgrado', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'costosemprog', tipo: 'num', nullable: true, llave: ''},
            {campo: 'cupos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'inscritos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'admitidos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'matriculados', tipo: 'int', nullable: true, llave: ''},
            {campo: 'aplazados', tipo: 'int', nullable: true, llave: ''},
            {campo: 'numestudiantes', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentaje', tipo: 'int', nullable: true, llave: ''},
            {campo: 'valor', tipo: 'num', nullable: true, llave: ''},
            {campo: 'costosemconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'cuposconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'inscritosconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'admitidosconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'matriculadosconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'aplazadosconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'numestudiantesconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentajeconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'valorconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'graduadosbogota', tipo: 'int', nullable: true, llave: ''},
            {campo: 'graduadosconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'recaudobogota', tipo: 'int', nullable: true, llave: ''},
            {campo: 'recaudoconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentajeugi', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentajederadmtvos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'facultaddsps', tipo: 'string', nullable: true, llave: ''},
            {campo: 'total', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentajeugiconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentajederadmtvosconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'trasladoistconvenio', tipo: 'int', nullable: true, llave: ''},
            {campo: 'facultaddspsconvenio', tipo: 'string', nullable: true, llave: ''}
          //  {campo: 'tipoprograma', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadTipoProgramaPostgradoSelect, loadnulo: false},                    
          //  {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_programapostgrado', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'costosemprog', tipo: 'num', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'cupos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'inscritos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'admitidos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'matriculados', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'aplazados', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            ],
            [
                {campo: 'numestudiantes', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentaje', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'valor', tipo: 'num', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'costosemconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'cuposconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'inscritosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            ],
            [
                {campo: 'admitidosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'matriculadosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'aplazadosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'numestudiantesconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentajeconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'valorconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            ],
            [
                {campo: 'graduadosbogota', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'graduadosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'recaudobogota', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'recaudoconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentajeugi', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentajederadmtvos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            ],
            [
                {campo: 'facultaddsps', tipo: 'string', nullable: true, llave: '', etiqueta: 'Patente Vigencia', placeholder: 'Patente Vigencia', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'total', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentajeugiconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentajederadmtvosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'trasladoistconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'facultaddspsconvenio', tipo: 'string', nullable: true, llave: '', etiqueta: 'Patente Vigencia', placeholder: 'Patente Vigencia', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null}
            ],            
                                    
        ];

        this.CampoLlave = 'id_postprogram';
        this.Nombre = 'DecVie_CicloFinancieroPostProgram';
        this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
        this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
        this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgram';
        this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
        //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
        this.ParamGetName1 = 'id_postprogram';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_CicloFinancieroPostProgramDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}

function DecVie_CicloFinancieroProgramasDisponibles() {
    this.Campos = [
        {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'foreign'},
        {campo: 'id_programapostgrado', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecvie_CicloFinancieroProgramasPostgradoSelect, loadnulo: false},
        {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'id_numeroplan', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_programapostgrado', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas Disponibles', placeholder: '', title: 'Programas Disponibles', numcols: 10, funconchange: null, funconclick: null},
            {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', etiqueta: 'Coordinador Academico', placeholder: 'Coordinador Academico', title: 'Coordinador Academico', numcols: 5, funconchange: null, funconclick: null},
            {campo: 'id_numeroplan', tipo: 'string', nullable: false, llave: '', etiqueta: 'Número de Plan', placeholder: 'Ingrese el número de plan', title: 'Número de Plan', numcols: 3, funconchange: null, funconclick: null}
        ] 
    ];

    this.CampoLlave = 'id_postprogram';
    this.Nombre = 'DecVie_CicloFinancieroPostProgram';
    this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
    this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
    this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgram';
    this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
    //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
    this.ParamGetName1 = 'id_postprogram';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_numradicacion';
    this.ObjDatos = null;
    this.FormEdicion = 'formCicloFinancieroProgramasDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;
}

// function DecVie_CicloFinancieroProgramasDisponibles() {
            
//     this.Campos = [
//         {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
//         {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'foreign'},
//         {campo: 'id_programapostgrado', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecvie_CicloFinancieroProgramasPostgradoSelect, loadnulo: false} ,
        
//         //Cambio Adda para nuevos campos: 
//         {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
//         {campo: 'id_numeroplan', tipo: 'number', nullable: false, llave: 'unique'}
//     ];

//     this.CamposHTML = [
//         [
//             {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},                
//             {campo: 'id_programapostgrado', tipo: 'select',  nullable: false, llave: '', etiqueta: 'Programas Disponibles', placeholder: '', title: 'Programas Disponibles', numcols: 5, funconchange: null, funconclick: null},
//             {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'foreign'},     
//             //Cambio Adda para nuevos campos: 
//             {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', etiqueta: 'Coordinador Seguimiento', placeholder: '', title: 'Coordinador Seguimiento', numcols: 2, funconchange: null, funconclick: null},
//             {campo: 'id_numeroplan', tipo: 'number', nullable: false, llave: 'unique', etiqueta: 'Número de Plan', placeholder: 'Ingrese el número de plan', title: 'Número de Plan', numcols: 6}  
//         ]
//     ];

//     this.CampoLlave = 'id_postprogram';
//     this.Nombre = 'DecVie_CicloFinancieroPostProgram';
//     this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
//     this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
//     this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgram';
//     this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
//     //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
//     this.ParamGetName1 = 'id_postprogram';
//     this.ParamGetName2 = '';
//     this.ParamGetName3 = '';
//     //this.ParamDuplicadoName = 'cd_numradicacion';
//     this.ObjDatos = null;
//     this.FormEdicion = 'formCicloFinancieroProgramasDetalle';
//     this.IsModal = true;
//     this.DatosNullEdicion = true;

// }

function DecVie_CicloFinancieroPostProgramBogota() {
            
        this.Campos = [
            {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'costosemprog', tipo: 'num', nullable: true, llave: ''},
            {campo: 'cupos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'inscritos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'admitidos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'matriculados', tipo: 'int', nullable: true, llave: ''},
            {campo: 'aplazados', tipo: 'int', nullable: true, llave: ''},
            {campo: 'numestudiantes', tipo: 'int', nullable: true, llave: ''},
            {campo: 'porcentaje', tipo: 'int', nullable: true, llave: ''},
            {campo: 'valor', tipo: 'num', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},  
                {campo: 'costosemprog', tipo: 'num', nullable: true, llave: '', etiqueta: 'Costo Semestre', placeholder: 'Costo Semestre', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'cupos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Cupos', placeholder: 'Cupos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'inscritos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Inscritos', placeholder: 'Inscritos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'admitidos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Admitidos', placeholder: 'Admitidos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'matriculados', tipo: 'int', nullable: true, llave: '', etiqueta: 'Matriculados', placeholder: 'Matriculados', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'aplazados', tipo: 'int', nullable: true, llave: '', etiqueta: 'Aplazados', placeholder: 'Aplazados', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            ],
            [
                {campo: 'numestudiantes', tipo: 'int', nullable: true, llave: '', etiqueta: 'Número de Estudiantes', placeholder: 'Número de Estudiantes', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'porcentaje', tipo: 'int', nullable: true, llave: '', etiqueta: 'Porcentage', placeholder: 'Porcentage', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'valor', tipo: 'num', nullable: true, llave: '', etiqueta: 'Valor', placeholder: 'Valor', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null}
            ]                                             
        ];

        this.CampoLlave = 'id_postprogram';
        this.Nombre = 'DecVie_CicloFinancieroPostProgramBogota';
        this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
        this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
        this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgramBogota';
        this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
        //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
        this.ParamGetName1 = 'id_postprogram';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_CicloFinancieroProgramaPostgradoDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;
   
}

function DecVie_CicloFinancieroPostProgramConvenios() {
            
    this.Campos = [
        {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'costosemconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'cuposconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'inscritosconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'admitidosconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'matriculadosconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'aplazadosconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'numestudiantesconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'porcentajeconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'valorconvenio', tipo: 'int', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},  
            {campo: 'costosemconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Costo Semestre Convenio', placeholder: 'Costo Semestre', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'cuposconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Cupos', placeholder: 'Cupos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'inscritosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Inscritos', placeholder: 'Inscritos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'admitidosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Admitidos', placeholder: 'Admitidos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'matriculadosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Matriculados', placeholder: 'Matriculados', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'aplazadosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Aplazados', placeholder: 'Aplazados', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
        ],
        [
            {campo: 'numestudiantesconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Número de Estudiantes', placeholder: 'Número de Estudiantes', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'porcentajeconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Porcentage', placeholder: 'Porcentage', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'valorconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Valor', placeholder: 'Valor', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null}
        ]                                             
    ];

    this.CampoLlave = 'id_postprogram';
    this.Nombre = 'DecVie_CicloFinancieroPostProgramConvenios';
    this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
    this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
    this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgramConvenio';
    this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
    //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
    this.ParamGetName1 = 'id_postprogram';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_numradicacion';
    this.ObjDatos = null;
    this.FormEdicion = 'formCicloFinancieroProgramas_ConvenioDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;

}

function DecVie_CicloFinancieroPostProgramFacultad() {
            
    this.Campos = [
        {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'graduadosbogota', tipo: 'int', nullable: true, llave: ''},
        {campo: 'graduadosconvenio', tipo: 'int', nullable: true, llave: ''},
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},  
            {campo: 'graduadosbogota', tipo: 'int', nullable: true, llave: '', etiqueta: 'Graduados Bogotá', placeholder: 'Graduados Bogotá', title: '', numcols: 6, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'graduadosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Graduados Convenio', placeholder: 'Graduados Convenio', title: '', numcols: 6, maxlength: 12, funconchange: null, funconclick: null},
            
        ]                                             
    ];

    this.CampoLlave = 'id_postprogram';
    this.Nombre = 'DecVie_CicloFinancieroPostProgramFacultad';
    this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
    this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
    this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgramFacultad';
    this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
    //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
    this.ParamGetName1 = 'id_postprogram';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_numradicacion';
    this.ObjDatos = null;
    this.FormEdicion = 'formCicloFinancieroProgramas_FacultadDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;

}

function DecVie_CicloFinancieroPostProgramUAdministrativa() {
            
    this.Campos = [
        {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'recaudobogota', tipo: 'int', nullable: true, llave: ''},
        {campo: 'recaudoconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'porcentajeugi', tipo: 'int', nullable: true, llave: ''},
        {campo: 'porcentajederadmtvos', tipo: 'int', nullable: true, llave: ''},
        {campo: 'facultaddsps', tipo: 'string', nullable: true, llave: ''},
        {campo: 'total', tipo: 'int', nullable: true, llave: ''},
        {campo: 'porcentajeugiconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'porcentajederadmtvosconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'trasladoistconvenio', tipo: 'int', nullable: true, llave: ''},
        {campo: 'facultaddspsconvenio', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_postprogram', tipo: 'string', nullable: false, llave: 'primary'},  
            {campo: 'recaudobogota', tipo: 'int', nullable: true, llave: '', etiqueta: 'Recaudo Bogotá', placeholder: 'Recaudo Bogotá', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'recaudoconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Reacudo Convenio', placeholder: 'Reacudo Convenio', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'porcentajeugi', tipo: 'int', nullable: true, llave: '', etiqueta: 'Porcentage UGI', placeholder: 'Porcentage UGI', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'porcentajederadmtvos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Porcentage DerAdministrativos', placeholder: 'Porcentage DerAdministrativos', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'facultaddsps', tipo: 'string', nullable: true, llave: '', etiqueta: 'Facultad DSPS', placeholder: 'Facultad DSPS', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'total', tipo: 'int', nullable: true, llave: '', etiqueta: 'Total', placeholder: 'Total', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null}
        ],
        [            
            {campo: 'porcentajeugiconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Porcentage UGI Convenio', placeholder: 'Porcentage UGI Convenio', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'porcentajederadmtvosconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Porcentage DerAdministrativos Convenio', placeholder: 'Porcentage DerAdministrativos Convenio', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'trasladoistconvenio', tipo: 'int', nullable: true, llave: '', etiqueta: 'Traslado Convenio', placeholder: 'Traslado Convenio', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'facultaddspsconvenio', tipo: 'string', nullable: true, llave: '', etiqueta: 'Facultad DCPs', placeholder: 'Facultad DCPs', title: '', numcols: 3, maxlength: 500, funconchange: null, funconclick: null}
        ],                                             
    ];

    this.CampoLlave = 'id_postprogram';
    this.Nombre = 'DecVie_CicloFinancieroPostProgramBogota';
    this.ControllerName = 'DecVie_CicloFinancieroPostProgram';
    this.MethodGet = 'GetDecVie_CicloFinancieroPostProgramDetails';
    this.MethodUpdate = 'UpdateDecVie_CicloFinancieroPostProgramUAdministrativa';
    this.MethodInsert = 'InsertDecVie_CicloFinancieroPostProgram';
    //this.MethodValidarDuplicado = 'GetDecVie_CicloFinancieroPostProgramNumero';
    this.ParamGetName1 = 'id_postprogram';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_numradicacion';
    this.ObjDatos = null;
    this.FormEdicion = 'formCicloFinancieroProgramas_UAdministrativaDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;

}