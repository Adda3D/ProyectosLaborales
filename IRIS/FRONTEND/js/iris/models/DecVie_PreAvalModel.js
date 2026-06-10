function DecVie_PreAval () {
    //****  ESTE MODELO ES EL QUE CARGA EL BOTON SOLICITAR PREAVAL
        
        this.Campos = [
            {campo: 'id_preaval', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'fecradicacion', tipo: 'date', nullable: true, llave: ''},
            {campo: 'consecutivo', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'tiposolucitud', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_rubro', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadSeguimiento_RubroSelect, loadnulo: true},
            {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMacroprocesoSelect, loadnulo: true},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},
            {campo: 'proyecto', tipo: 'string', nullable: true, llave: ''},
            {campo: 'quipu', tipo: 'string', nullable: true, llave: ''},
            {campo: 'hermes', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_doccontractuales', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_TipoDocContractualesSelect, loadnulo: true},
            {campo: 'montosolicitado', tipo: 'num', nullable: true, llave: ''},
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
            {campo: 'tiempovinculacion', tipo: 'string', nullable: true, llave: ''},
            {campo: 'objeto', tipo: 'string', nullable: true, llave: ''},
            {campo: 'obligaciones', tipo: 'string', nullable: true, llave: ''}            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_preaval', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'fecradicacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Radicación', placeholder: '', title: 'Fecha Radicación', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'consecutivo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Consecutivo', placeholder: 'Consecutivo', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'tiposolucitud', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Tipo Solicitud', placeholder: 'Tipo Solicitud', title: '', numcols: 2, numrows: 3, maxlength: 4000, funconchange: null, funconclick: null},
                {campo: 'id_rubro', tipo: 'select', nullable: true, llave: '', etiqueta: 'Rubro', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', etiqueta: 'Macroproceso', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', etiqueta: 'Dependencia', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null}
            ],
            [
                {campo: 'proyecto', tipo: 'string', nullable: true, llave: '', etiqueta: 'Proyecto', placeholder: 'Proyecto', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'quipu', tipo: 'string', nullable: true, llave: '', etiqueta: 'Quipu', placeholder: 'Quipu', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'hermes', tipo: 'string', nullable: true, llave: '', etiqueta: 'Hermes', placeholder: 'Hermes', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'id_doccontractuales', tipo: 'select', nullable: false, llave: '', etiqueta: 'Documentos Contractuales', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'montosolicitado', tipo: 'num', nullable: true, llave: '', etiqueta: 'Monto Solicitado', placeholder: 'Monto Solicitado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Contratista/Proveedor', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null}
            ],
            [
                {campo: 'tiempovinculacion', tipo: 'string', nullable: true, llave: '', etiqueta: 'Tiempo Vinculación', placeholder: 'Tiempo Vinculación', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'objeto', tipo: 'string', nullable: true, llave: '', etiqueta: 'Objeto', placeholder: 'Objeto', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'obligaciones', tipo: 'string', nullable: true, llave: '', etiqueta: 'Obligaciones', placeholder: 'Obligaciones', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null}                                
            ]
            
        ];

        this.CampoLlave = 'id_preaval';
        this.Nombre = 'DecVie_PreAval';
        this.ControllerName = 'DecVie_PreAval';
        this.MethodGet = 'GetDecVie_PreAvalDetails';
        this.MethodUpdate = 'UpdateDecVie_PreAval';
        this.MethodInsert = 'InsertDecVie_PreAval';
        this.MethodValidarDuplicado = 'GetDecVie_PreAvalCodigo';
        this.ParamGetName1 = 'id_preaval';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_consecutivo';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PreAvalDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;
  
}

function DecVie_PreAvalRevision (){
    this.Campos = [
        {campo: 'id_preaval', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'revisionprecontractual', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadrevisionprecontractualSelect, loadnulo: false},
        {campo: 'id_revsigep', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_RevSigepSelect, loadnulo: false},
        {campo: 'id_asuntosdisciplinarios', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_AsuntosDisciplinariosSelect, loadnulo: false},
        {campo: 'id_estadopreaval', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_EstadoPreAvalSelect, loadnulo: false}
        
    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_preaval', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'revisionprecontractual', tipo: 'select', nullable: true, llave: '', etiqueta: 'Revisión PreContractual', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},
            {campo: 'id_revsigep', tipo: 'select', nullable: true, llave: '', etiqueta: 'RevSigep', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},
            {campo: 'id_asuntosdisciplinarios', tipo: 'select', nullable: true, llave: '', etiqueta: 'Asuntos Disciplinarios', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},
            {campo: 'id_estadopreaval', tipo: 'select', nullable: true, llave: '', etiqueta: 'Estado PreAval', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null}
        ],
    ];

    this.CampoLlave = 'id_preaval';
    this.Nombre = 'DecVie_PreAval';
    this.ControllerName = 'DecVie_PreAval';
    this.MethodGet = 'GetDecVie_PreAvalDetails';
    this.MethodUpdate = 'UpdateDecVie_PreAvalRevision';
    this.MethodInsert = 'InsertDecVie_PreAval';
    this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_preaval';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formDecVie_PreAval_RevisionDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;

}

function DecVie_PreAvalConceptoDecanatura(){
    this.Campos = [
        {campo: 'id_preaval', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'id_conceptodecanatura', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_ConceptoDecanaturaSelect, loadnulo: false},
        {campo: 'id_estadopreaval', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_EstadoPreAvalSelect, loadnulo: false},
        {campo: 'observacionesdecanatura', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_preaval', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'id_conceptodecanatura', tipo: 'select', nullable: true, llave: '', etiqueta: 'Concepto Decanatura', placeholder: '', title: '', numcols: 6, funconchange: null, funconclick: null},
            {campo: 'id_estadopreaval', tipo: 'select', nullable: true, llave: '', etiqueta: 'Estado PreAval', placeholder: '', title: '', numcols: 6, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'observacionesdecanatura', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones Decanatura', placeholder: 'Observaciones', title: '', numcols: 12, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
        
    ];

    this.CampoLlave = 'id_preaval';
    this.Nombre = 'DecVie_PreAvalConcepto';
    this.ControllerName = 'DecVie_PreAval';
    this.MethodGet = 'GetDecVie_PreAvalDetails';
    this.MethodUpdate = 'UpdateDecVie_PreAvalConceptoDecanatura';
    this.MethodInsert = 'InsertDecVie_PreAval';
    this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_preaval';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formDecVie_PreAval_ConceptoDecanaturaDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;
}