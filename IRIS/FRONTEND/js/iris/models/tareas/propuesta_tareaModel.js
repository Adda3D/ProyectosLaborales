function Propuesta_Tarea() {
        
    this.Campos = [
        {campo: 'id_tarea', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'relacioncon', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'idrelacionado', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_estadotarea', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fechainicio', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: ''},
        {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: false},
        {campo: 'consecutivo', tipo: 'string', nullable: true, llave: ''},
        {campo: 'detalles', tipo: 'string', nullable: false, llave: ''}        
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_tarea', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'relacioncon', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'idrelacionado', tipo: 'string', nullable: true, llave: 'foranea'},            
            {campo: 'id_estadotarea', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', etiqueta: 'Responsable', placeholder: '', title: 'Responsable', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'detalles', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Detalle Tarea', placeholder: 'Detalle Tarea', title: '', numcols: 6, numrows: 2, maxlength: 2000, funconchange: null, funconclick: null},
            {campo: 'consecutivo', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consecutivo Asociado', placeholder: 'Consecutivo Asociado', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'fechainicio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Asignación', placeholder: '', title: 'Fecha Asignación', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Vencimiento', placeholder: '', title: 'Fecha Vencimiento', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_tarea';
    this.Nombre = 'Propuesta_Tarea';
    this.ControllerName = 'Tareas';
    this.MethodGet = 'GetTareasDetails';
    this.MethodUpdate = 'UpdateTareas';
    this.MethodInsert = 'InsertTareas';
    this.ParamGetName1 = 'id_tarea';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPropuestasTareas';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
