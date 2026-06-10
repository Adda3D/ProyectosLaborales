function Investigacion_Resolucion() {
    this.Campos = [
        {campo: 'id_proyectoresolucion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'valor', tipo: 'num', nullable: false, llave: '', loadnulo: false},
        {campo: 'observación', tipo: 'string', nullable: false, llave: ''},
        {campo: 'resolucion',tipo: 'select', nullable: false, llave: '', funcloadselect: LoadResolucionUGI, loadnulo: true}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_proyectoresolucion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'resolucion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Resolución UGI', placeholder: '', title: 'Estado Proyecto', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'valor', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor', placeholder: '', title: 'Valor', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'observación', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observación', placeholder: 'Resolución', title: '', numcols: 8, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null},
        ]
    ];

    this.CampoLlave = 'id_proyectoresolucion';
    this.Nombre = 'Investigacion_Resolucion';
    this.ControllerName = 'Investigacion_Resolucion';
    this.MethodGet = 'GetInvestigacion_ResolucionDetails';
    this.MethodUpdate = 'UpdateInvestigacion_Resolucion';
    this.MethodInsert = 'InsertInvestigacion_Resolucion';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_proyectoresolucion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoInvestigacionResoluciones';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';
}
