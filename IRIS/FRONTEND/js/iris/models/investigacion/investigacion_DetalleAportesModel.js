function Investigacion_DetalleAportes() {
    this.Campos = [
        {campo: 'id_proyecto', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'aportefacultad', tipo: 'num', nullable: false, llave: ''},
        {campo: 'aportevir', tipo: 'num', nullable: false, llave: ''},
        {campo: 'aportedieb', tipo: 'num', nullable: false, llave: ''},
        {campo: 'aprobadoconvenio', tipo: 'num', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_proyecto', tipo: 'string', nullable: true, llave: 'primary'},                        
            {campo: 'aportefacultad', tipo: 'num', nullable: false, llave: '', etiqueta: 'Aporte de Facultad', placeholder: '', title: 'Aporte de Facultad', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'aportevir', tipo: 'num', nullable: false, llave: '', etiqueta: 'Aporte VIR', placeholder: '', title: 'Aporte VIR', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'aportedieb', tipo: 'num', nullable: false, llave: '', etiqueta: 'Aporte DIEB', placeholder: '', title: 'Aporte DIEB', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'aprobadoconvenio', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Convenio Aprobado', placeholder: '', title: 'Valor Convenio Aprobado', numcols: 2, minimo: 0, funconchange: null, funconclick: null}            
        ]
    ];

    this.CampoLlave = 'id_proyecto';
    this.Nombre = 'Investigacion_DetalleAportes';
    this.ControllerName = 'Investigacion_CrearProyecto';
    this.MethodGet = 'GetInvestigacion_CrearProyectoAportes';
    this.MethodUpdate = 'UpdateInvestigacion_CrearProyectoAportes';
    this.MethodInsert = '';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_crearproyecto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoInvestigacionDetalleAportes';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}