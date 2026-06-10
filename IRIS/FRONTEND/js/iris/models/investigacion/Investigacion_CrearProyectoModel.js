function Investigacion_CrearProyecto() {
    this.Campos = [
        {campo: 'id_crearproyecto', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_literal', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadLiteral_UGI, loadnulo: true},
        {campo: 'id_conceptougi', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadConcepto_UGISelect, loadnulo: true},
        {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
        {campo: 'id_convocatoria', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadConvocatoriaSelect, loadnulo: true},
        {campo: 'id_creargrupo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadGrupoInvestigacionSelect, loadnulo: true},
        {campo: 'id_estado', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoProyectoSelect, loadnulo: true},
        {campo: 'codigohermes', tipo: 'string', nullable: false, llave: ''},
        {campo: 'nombreproyecto', tipo: 'string', nullable: false, llave: ''},
        {campo: 'id_naturalezaproyecto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadNaturalezaProyecto, loadnulo: true},
        {campo: 'codigoavalsede', tipo: 'string', nullable: true, llave: ''},
        {campo: 'consecutivoavaldedicaciondocente', tipo: 'string', nullable: true, llave: ''},
        {campo: 'horasaprobadas', tipo: 'int', nullable: false, llave: ''},
        {campo: 'id_modalidad', tipo: 'string', nullable: false, llave: ''},
        //{campo: 'actoadministrativo', tipo: 'string', nullable: true, llave: ''},
        //El campo actoadminsitrativo en la DB hace referencia a la resolución UGI
        //{campo: 'actoadministrativo',tipo: 'select', nullable: false, llave: '', funcloadselect: LoadResolucionUGI, loadnulo: true},
        {campo: 'resoluciondeaperturapresupuestal', tipo: 'string', nullable: false, llave: ''},
        {campo: 'quipu', tipo: 'string', nullable: true, llave: ''},
        {campo: 'anopublicacion', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadAnnoPublicacionSelect, loadnulo: true},
        {campo: 'empresa', tipo: 'string', nullable: false, llave: ''},
        //{campo: 'valoraprobado', tipo: 'int', nullable: false, llave: ''},
        {campo: 'valoraportevir', tipo: 'num', nullable: false, llave: ''},
        {campo: 'valoraportefacultad', tipo: 'num', nullable: false, llave: ''}, 
        {campo: 'valoraportedieb', tipo: 'num', nullable: false, llave: ''},
        //{campo: 'valoraporteotro', tipo: 'int', nullable: false, llave: ''},
        {campo: 'valoraporteexterno', tipo: 'num', nullable: false, llave: ''},
        {campo: 'valortotalproyecto', tipo: 'string', nullable: false, llave: '', noupdate: true},
        {campo: 'fechainicio', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fechafinaliza', tipo: 'date', nullable: true, llave: ''},  
        {campo: 'vigencia', tipo: 'string', nullable: true, llave: '', noupdate: true},
        {campo: 'archivoproyectoenlace', tipo: 'string', nullable: true, llave: ''},
        //Cambios ADDAVARGAS 22/04/2024
        //{campo: 'id_resolucionugi', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadResolucionUGI, loadnulo: true},
    ];

    this.CamposHTML = [
        [
            {campo: 'id_crearproyecto', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'codigohermes', tipo: 'string', nullable: false, llave: '', etiqueta: 'ID Hermes', placeholder: 'ID Hermes', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'nombreproyecto', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Nombre Proyecto', placeholder: 'Nombre Proyecto', title: '', numcols: 4, numrows: 1, maxlength: 1000, funconchange: null, funconclick: null},
            {campo: 'id_naturalezaproyecto', tipo: 'select', nullable: false, llave: '', etiqueta: 'Naturaleza', placeholder: '', title: 'Naturaleza', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_literal', tipo: 'select', nullable: false, llave: '', etiqueta: 'Literal UGI', placeholder: '', title: 'Literal UGI', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_conceptougi', tipo: 'select', nullable: false, llave: '', etiqueta: 'Concepto UGI', placeholder: '', title: 'Concepto UGI', numcols: 2, funconchange: null, funconclick: null}    
        ],
        [
            {campo: 'codigoavalsede', tipo: 'string', nullable: true, llave: '', etiqueta: 'Aval Sede', placeholder: 'Aval Sede', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'consecutivoavaldedicaciondocente', tipo: 'string', nullable: false, llave: '', etiqueta: 'Consecutivo Aval', placeholder: 'Consecutivo Aval', title: 'Consecutivo Aval Dedicación Docente', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'horasaprobadas', tipo: 'int', nullable: false, llave: '', etiqueta: 'No. Horas Aprob.', placeholder: '', title: 'No. Horas Aprob.', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'id_convocatoria', tipo: 'select', nullable: false, llave: '', etiqueta: 'Convocatoria', placeholder: '', title: 'Convocatoria', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_modalidad', tipo: 'string', nullable: false, llave: '', etiqueta: 'Modalidad', placeholder: '', title: 'Modalidad', numcols: 2, funconchange: null, funconclick: null},
            //Cambios ADDAVARGAS 22/04/2024 actoadministrativo
            //{campo: 'id_resolucionugi', tipo: 'select', nullable: false, llave: '', etiqueta: 'Resolución UGI', placeholder: '', title: 'Estado Proyecto', numcols: 2, funconchange: null, funconclick: null}
            //{campo: 'actoadministrativo', tipo: 'select', nullable: false, llave: '', etiqueta: 'Resolución UGI', placeholder: '', title: 'Estado Proyecto', numcols: 2, funconchange: null, funconclick: null}
            //{campo: 'actoadministrativo', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadResolucionUGI, loadnulo: true}

    
        ],
        [
            {campo: 'id_estado', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Proyecto', placeholder: '', title: 'Estado Proyecto', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'resoluciondeaperturapresupuestal', tipo: 'string', nullable: true, llave: '', etiqueta: 'Acta/Resolución', placeholder: 'Acta/Resolución', title: 'Resolución Apertura Presupuestal', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'quipu', tipo: 'string', nullable: true, llave: '', etiqueta: 'QUIPU', placeholder: 'QUIPU', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'anopublicacion', tipo: 'select', nullable: true, llave: '', etiqueta: 'Año Publicación', placeholder: '', title: 'Año Publicación', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'empresa', tipo: 'string', nullable: true, llave: '', etiqueta: 'Empresa', placeholder: 'Empresa', title: '', numcols: 2, maxlength: 150, funconchange: null, funconclick: null},
            {campo: 'id_creargrupo', tipo: 'select', nullable: false, llave: '', etiqueta: 'Grupo Investigación', placeholder: '', title: 'Grupo Investigación', numcols: 2, funconchange: null, funconclick: null}    
        ],
        [
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Director', placeholder: '', title: 'Director', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', etiqueta: 'Coordinador Seguimiento', placeholder: '', title: 'Coordinador Seguimiento', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fechainicio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Finaliza', placeholder: '', title: 'Fecha Finaliza', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechafinaliza', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Entrega Real', placeholder: '', title: 'Fecha Entrega Real', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'vigencia', tipo: 'string', nullable: false, llave: '', etiqueta: 'Vigencia', placeholder: 'Vigencia', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null}    
        ],
        [
           // {campo: 'valoraprobado', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Aprobado', placeholder: '', title: 'Valor Aprobado', numcols: 2, minimo: 0, funconchange: "TotalesValorPRJINV();", funconclick: null},
            {campo: 'valoraportefacultad', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Facultad', placeholder: '', title: 'Valor Facultad', numcols: 2, minimo: 0, funconchange: "TotalesValorPRJINV();", funconclick: null},
            {campo: 'valoraportevir', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor VIR', placeholder: '', title: 'Valor VIR', numcols: 2, minimo: 0, funconchange: "TotalesValorPRJINV();", funconclick: null},            
            {campo: 'valoraportedieb', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor DIEB', placeholder: '', title: 'Valor DIEB', numcols: 2, minimo: 0, funconchange: "TotalesValorPRJINV();", funconclick: null},
           // {campo: 'valoraporteotro', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Otro', placeholder: '', title: 'Valor Otro', numcols: 2, minimo: 0, funconchange: "TotalesValorPRJINV();", funconclick: null},
            {campo: 'valoraporteexterno', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Externo', placeholder: '', title: 'Valor Externo', numcols: 2, minimo: 0, funconchange: "TotalesValorPRJINV();", funconclick: null},
            {campo: 'valortotalproyecto', tipo: 'string', nullable: true, llave: '', etiqueta: 'Total Proyecto', placeholder: '', title: '', numcols: 2, maxlength: 150, funconchange: "TotalesValorPRJINV();", funconclick: null}
        ],
        [            
            {campo: 'archivoproyectoenlace', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Archivo Proyecto', placeholder: 'Enlace Archivo Proyecto', title: '', numcols: 4, numrows: 1, maxlength: 500, funconchange: null, funconclick: null},            
            //{campo: 'actoadministrativo', tipo: 'string', nullable: true, llave: '', etiqueta: 'Acto Administrativo', placeholder: 'Acto Administrativo', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null, hidden: true}    
        ]
    ];

    this.CampoLlave = 'id_crearproyecto';
    this.Nombre = 'Investigacion_CrearProyecto';
    this.ControllerName = 'Investigacion_CrearProyecto';
    this.MethodGet = 'GetInvestigacion_CrearProyectoDetails';
    this.MethodUpdate = 'UpdateInvestigacion_CrearProyecto';
    this.MethodInsert = 'InsertInvestigacion_CrearProyecto';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_crearproyecto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyecto_InvestigacionDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = ''; 

}
