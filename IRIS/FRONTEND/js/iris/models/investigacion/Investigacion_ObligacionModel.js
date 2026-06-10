function Investigacion_Obligacion() {
    this.Campos = [
        {campo: 'id_proyectoobligacion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_estadoobligacion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoObligacionProyecto, loadnulo: false},
        {campo: 'obligacion', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_proyectoobligacion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'obligacion', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Detalle Obligación', placeholder: 'Detalle Obligación', title: '', numcols: 8, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'id_estadoobligacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado', placeholder: '', title: 'Estado Obligación', numcols: 2, funconchange: null, funconclick: null}    
        ]
    ];

    this.CampoLlave = 'id_proyectoobligacion';
    this.Nombre = 'Investigacion_Obligacion';
    this.ControllerName = 'Investigacion_Obligacion';
    this.MethodGet = 'GetInvestigacion_ObligacionDetails';
    this.MethodUpdate = 'UpdateInvestigacion_Obligacion';
    this.MethodInsert = 'InsertInvestigacion_Obligacion';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_proyectoobligacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoInvestigacionObligaciones';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}