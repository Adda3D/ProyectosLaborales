function Investigacion_Observacion() {
    this.Campos = [
        {campo: 'id_proyectoobservacion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fechaobservacion', tipo: 'date', nullable: false, llave: ''},        
        {campo: 'observacion', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_proyectoobservacion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'observacion', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Detalle Observación', placeholder: 'Detalle Observación', title: '', numcols: 8, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'fechaobservacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Observación', placeholder: '', title: 'Fecha Observación', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}            
        ]
    ];

    this.CampoLlave = 'id_proyectoobservacion';
    this.Nombre = 'Investigacion_Observacion';
    this.ControllerName = 'Investigacion_Observacion';
    this.MethodGet = 'GetInvestigacion_ObservacionDetails';
    this.MethodUpdate = 'UpdateInvestigacion_Observacion';
    this.MethodInsert = 'InsertInvestigacion_Observacion';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_proyectoobservacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoInvestigacionObservaciones';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}