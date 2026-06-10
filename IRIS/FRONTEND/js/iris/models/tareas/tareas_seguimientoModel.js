function Tarea_Seguimiento() {
        
    this.Campos = [
        {campo: 'idtareaseguimiento', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_tarea', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'UsuarioSeguimiento', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fecharealiza', tipo: 'date', nullable: false, llave: ''},        
        {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}        
        
    ];

    this.CamposHTML = [
        [
            {campo: 'idtareaseguimiento', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_tarea', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'UsuarioSeguimiento', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fecharealiza', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Seguimiento', placeholder: '', title: 'Fecha Seguimiento', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Detalle Seguimiento', placeholder: 'Detalle Seguimiento', title: '', numcols: 10, numrows: 2, maxlength: 150, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'idtareaseguimiento';
    this.Nombre = 'Tarea_Seguimiento';
    this.ControllerName = 'Tareas_Seguimiento';
    this.MethodGet = 'GetTareas_SeguimientoDetails';
    this.MethodUpdate = 'UpdateTareas_Seguimiento';
    this.MethodInsert = 'InsertTareas_Seguimiento';
    this.ParamGetName1 = 'idtareaseguimiento';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formModalSeguimientoTareaUsuario';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}

function Tarea_EstadoAvanceModel() {
        
    this.Campos = [
        {campo: 'id_tarea', tipo: 'string', nullable: false, llave: 'primary'},                
        {campo: 'usuario', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_estadotarea', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTareaSelect, loadnulo: false},
        {campo: 'avance', tipo: 'int', nullable: false, llave: ''}        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_tarea', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'usuario', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_estadotarea', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Tarea', placeholder: '', title: 'Estado Tarea', numcols: 6, funconchange: null, funconclick: null},
            {campo: 'avance', tipo: 'int', nullable: false, llave: '', etiqueta: '% Avance', placeholder: '', title: '% Avance', numcols: 3, minimo: 0, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_tarea';
    this.Nombre = 'Tarea_EstadoAvance';
    this.ControllerName = 'Tareas';
    this.MethodGet = 'GetTareasDetails';
    this.MethodUpdate = 'UpdateTareaEstadoAvance';
    this.MethodInsert = 'InsertTareas';
    this.ParamGetName1 = 'id_tarea';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formModalEstadoAvanceTareaUsuario';
    this.IsModal = true;        
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
