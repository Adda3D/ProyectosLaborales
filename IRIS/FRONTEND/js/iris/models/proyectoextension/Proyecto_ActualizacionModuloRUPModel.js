function Actualizacion_ModuloRUP() {
    this.Campos = [
        {campo: 'id_actualizacionmodulor', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_asignacionproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fecrevinicialeshermesrup', tipo: 'date', nullable: false, llave: ''},
        {campo: 'obscerrarmodrup', tipo: 'string', nullable: false, llave: ''},
        {campo: 'fecremproydneipi1', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecdevdneipi', tipo: 'date', nullable: true, llave: ''},
        {campo: 'feccorreccionproy', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecremproydneipi2', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecverenvcamaracomercio', tipo: 'date', nullable: true, llave: ''},
        {campo: 'codrup', tipo: 'string', nullable: true, llave: ''},
        {campo: 'valorsmlv', tipo: 'int', nullable: false, llave: ''},
        {campo: 'idfuncionarioremitedneipi', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariodevodneipi', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionariocorreccion', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idfuncionarioreenviodneipi', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_actualizacionmodulor', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_asignacionproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fecrevinicialeshermesrup', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Revisión Inicial', placeholder: '', title: 'Fecha Revisión Inicial HERMES - RUP', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'obscerrarmodrup', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observaciones Cerrar RUP', placeholder: '', title: 'Observaciones para Cerrar módulo RUP', numcols: 2, numrows: 1, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'fecremproydneipi1', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Remisión DNEIPI', placeholder: '', title: 'Fecha Remisión proyecto a la DNEIPI', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioremitedneipi', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable Remisión DNEIPI', placeholder: '', title: 'Responsable Remisión DNEIPI', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecdevdneipi', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Devolución DNEIPI', placeholder: '', title: 'Fecha Devolución DNEIPI', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionariodevodneipi', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable Dev. DNEIPI', placeholder: '', title: 'Responsable Devolución DNEIPI', numcols: 2, funconchange: null, funconclick: null}    
        ],
        [
            {campo: 'feccorreccionproy', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Corrección', placeholder: '', title: 'Fecha Corrección Proyecto', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionariocorreccion', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable Corrección', placeholder: '', title: 'Responsable Corrección Proyecto', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecremproydneipi2', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha ReEnvío DNEIPI', placeholder: '', title: 'Fecha ReEnvío Proyecto DNEIPI', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idfuncionarioreenviodneipi', tipo: 'select', nullable: true, llave: '', etiqueta: 'Responsable ReEnvío', placeholder: '', title: 'Responsable ReEnvío Proyecto DNEIPI', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecverenvcamaracomercio', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Envío C.C.', placeholder: '', title: 'Fecha Envío Cámara de Comercio', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'codrup', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Códigos RUP', placeholder: '', title: 'Códigos RUP', numcols: 2, numrows: 1, maxlength: 500, funconchange: null, funconclick: null},
        ],
        [
            {campo: 'valorsmlv', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor en SMLMV', placeholder: '', title: 'Valor en SMLMV', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 1, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_actualizacionmodulor';
    this.Nombre = 'Proyecto_Actualizacion_ModuloRUP';
    this.ControllerName = 'Actualizacion_ModuloR';
    this.MethodGet = 'GetActualizacion_ModuloRByProyecto';
    this.MethodUpdate = 'UpdateActualizacion_ModuloR';
    this.MethodInsert = 'InsertActualizacion_ModuloR';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_asignacionproyecto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formproyectoextensionPEL_ModuloRUP';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';    

}