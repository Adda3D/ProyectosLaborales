function Proyectos_AsignacionProyecto() {
        
    this.Campos = [
        {campo: 'id_asignacionproyecto', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_propuesta', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'idpropuesta_entidad', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_tipopropuesta', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'propuesta_entidad', tipo: 'string', nullable: false, llave: '', noupdate: true},
        {campo: 'tipopropuesta', tipo: 'string', nullable: false, llave: '', noupdate: true},        
        {campo: 'consecutivo', tipo: 'string', nullable: false, llave: ''},
        {campo: 'yearsuscripcion', tipo: 'date', nullable: false, llave: ''},        
        {campo: 'id_naturalezaproyecto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadNaturalezaProyecto, loadnulo: true},        
        {campo: 'nombreproyecto', tipo: 'string', nullable: false, llave: ''},
        {campo: 'poblacionobjetivo', tipo: 'string', nullable: false, llave: ''},
        {campo: 'iddirector', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idsupervisor', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'idasistente', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'numcontratoconvenio', tipo: 'string', nullable: false, llave: ''},
        {campo: 'contratoconvenioenlace', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecacuerdovoluntades', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fecterminacion', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fichaquipu', tipo: 'string', nullable: false, llave: ''},
        {campo: 'codigohermes', tipo: 'string', nullable: false, llave: ''},
        {campo: 'objetocontratoactividad', tipo: 'string', nullable: false, llave: ''},
        {campo: 'id_alcanceproyecto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadAlcanceProyecto, loadnulo: true},
        {campo: 'valinicialaporteentidad', tipo: 'int', nullable: false, llave: ''},
        {campo: 'adiciondisminucion', tipo: 'int', nullable: true, llave: ''},
        {campo: 'contrapartida', tipo: 'int', nullable: true, llave: ''},
        //{campo: 'valortotal', tipo: 'int', nullable: false, llave: ''},
        {campo: 'id_areaacad', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadAreaAcademicaSelect, loadnulo: true},
        {campo: 'nestudiantesderecho', tipo: 'int', nullable: true, llave: ''},
        {campo: 'nestudiantespolitica', tipo: 'int', nullable: true, llave: ''},
        {campo: 'nestudiantespostgrados', tipo: 'int', nullable: true, llave: ''},
        {campo: 'numerosar', tipo: 'string', nullable: false, llave: ''},
        {campo: 'numeroodsops', tipo: 'string', nullable: false, llave: ''},
        {campo: 'id_estadocontrato', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoContrato, loadnulo: true},
        {campo: 'idregistrorup', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadRegistroRUP, loadnulo: true},
        {campo: 'idarchivoentrega', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadEntregaArchivo, loadnulo: true},
        {campo: 'entregaarchivoenlace', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_asignacionproyecto', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_propuesta', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'idpropuesta_entidad', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_tipopropuesta', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'consecutivo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Consecutivo Proyecto', placeholder: 'Consecutivo Proyecto', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'yearsuscripcion', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Suscripción', placeholder: '', title: 'Fecha Suscripción', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},            
            {campo: 'tipopropuesta', tipo: 'string', nullable: false, llave: '', etiqueta: 'Tipo Proyecto', placeholder: 'Tipo Proyecto', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'id_naturalezaproyecto', tipo: 'select', nullable: false, llave: '', etiqueta: 'Naturaleza Proyecto', placeholder: '', title: 'Naturaleza Proyecto', numcols: 2, funconchange: null, funconclick: null},                        
            {campo: 'propuesta_entidad', tipo: 'string', nullable: false, llave: '', etiqueta: 'Entidad Contratante', placeholder: 'Entidad Contratante', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'nombreproyecto', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Nombre Proyecto', placeholder: 'Nombre Proyecto', title: '', numcols: 2, numrows: 1, maxlength: 500, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'poblacionobjetivo', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Población Objetivo', placeholder: 'Población Objetivo', title: '', numcols: 2, numrows: 1, maxlength: 300, funconchange: null, funconclick: null},
            {campo: 'iddirector', tipo: 'select', nullable: false, llave: '', etiqueta: 'Director', placeholder: '', title: 'Director', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'idsupervisor', tipo: 'select', nullable: false, llave: '', etiqueta: 'Supervisor', placeholder: '', title: 'Supervisor', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'idasistente', tipo: 'select', nullable: false, llave: '', etiqueta: 'Asistente Administrativo', placeholder: '', title: 'Asistente Administrativo', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'numcontratoconvenio', tipo: 'string', nullable: false, llave: '', etiqueta: 'Contrato/Convenio', placeholder: 'Contrato/Convenio', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'contratoconvenioenlace', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Archivo Contrato', placeholder: 'Enlace Archivo Contrato', title: '', numcols: 4, numrows: 1, maxlength: 500, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'fecacuerdovoluntades', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fecterminacion', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Finaliza', placeholder: '', title: 'Fecha Finaliza', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fichaquipu', tipo: 'string', nullable: false, llave: '', etiqueta: 'Ficha QUIPU', placeholder: 'Ficha QUIPU', title: '', numcols: 2, maxlength: 20, funconchange: null, funconclick: null},
            {campo: 'codigohermes', tipo: 'string', nullable: false, llave: '', etiqueta: 'Código HERMES', placeholder: 'Código HERMES', title: '', numcols: 2, maxlength: 20, funconchange: null, funconclick: null},
            {campo: 'objetocontratoactividad', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Objeto Contrato', placeholder: 'Objeto Contrato', title: '', numcols: 4, numrows: 1, maxlength: 800, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'id_alcanceproyecto', tipo: 'select', nullable: false, llave: '', etiqueta: 'Asistente Administrativo', placeholder: '', title: 'Asistente Administrativo', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'valinicialaporteentidad', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Inicial', placeholder: '', title: 'Valor Inicial', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'adiciondisminucion', tipo: 'int', nullable: false, llave: '', etiqueta: 'Adición/Disminución', placeholder: '', title: 'Adición/Disminución', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'contrapartida', tipo: 'int', nullable: false, llave: '', etiqueta: 'Contrapartida', placeholder: '', title: 'Contrapartida', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'valortotal', tipo: 'string', nullable: false, llave: '', etiqueta: 'Valor Total', placeholder: '', title: 'Valor Total', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'id_areaacad', tipo: 'select', nullable: false, llave: '', etiqueta: 'Área Académica', placeholder: '', title: 'Área Académica', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'nestudiantesderecho', tipo: 'int', nullable: true, llave: '', etiqueta: '# Estud. Derecho', placeholder: '', title: '# Estud. Derecho', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'nestudiantespolitica', tipo: 'int', nullable: true, llave: '', etiqueta: '# Estud. Ciencia Política', placeholder: '', title: '# Estud. Ciencia Política', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'nestudiantespostgrados', tipo: 'int', nullable: true, llave: '', etiqueta: '# Estud. Posgrado', placeholder: '', title: '# Estud. Ciencia Política', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'numerosar', tipo: 'string', nullable: false, llave: '', etiqueta: 'No. SAR', placeholder: 'No. SAR', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'numeroodsops', tipo: 'string', nullable: false, llave: '', etiqueta: 'No. ODS/OPS', placeholder: 'No. ODS/OPS', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'id_estadocontrato', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Contrato', placeholder: '', title: 'Estado Contrato', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'idregistrorup', tipo: 'select', nullable: true, llave: '', etiqueta: 'Registro RUP', placeholder: '', title: 'Registro RUP', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'idarchivoentrega', tipo: 'select', nullable: true, llave: '', etiqueta: 'Entrega Archivo', placeholder: '', title: 'Entrega Archivo', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'entregaarchivoenlace', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Archivo Entregado', placeholder: 'Enlace Archivo Entregado', title: '', numcols: 4, numrows: 1, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_asignacionproyecto';
    this.Nombre = 'Proyectos_AsignacionProyecto';
    this.ControllerName = 'Proyectos_AsignacionProyecto';
    this.MethodGet = 'GetProyectos_AsignacionProyectoDetails';
    this.MethodUpdate = 'UpdateProyectos_AsignacionProyecto';
    this.MethodInsert = 'InsertProyectos_AsignacionProyecto';
    this.ParamGetName1 = 'id_asignacionproyecto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoExtensionPropuestaDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
