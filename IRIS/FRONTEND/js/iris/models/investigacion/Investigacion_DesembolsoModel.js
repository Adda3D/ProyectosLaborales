function Investigacion_Desembolso() {
    this.Campos = [
        {campo: 'id_desembolso', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fechadesembolso', tipo: 'date', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
        {campo: 'valordesembolso', tipo: 'num', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_desembolso', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fechadesembolso', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Desembolso', placeholder: '', title: 'Fecha Desembolso', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'valordesembolso', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Desembolso', placeholder: '', title: 'Valor Desembolso', numcols: 2, minimo: 1, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_desembolso';
    this.Nombre = 'Investigacion_Desembolso';
    this.ControllerName = 'Investigacion_Desembolso';
    this.MethodGet = 'GetInvestigacion_DesembolsoDetails';
    this.MethodUpdate = 'UpdateInvestigacion_Desembolso';
    this.MethodInsert = 'InsertInvestigacion_Desembolso';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_desembolso';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoInvestigacionFinancieroAplicarDesembolso';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}