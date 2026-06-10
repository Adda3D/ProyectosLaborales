function Proyecto_Seguimiento_Desembolso() {
    this.Campos = [
        {campo: 'id_segdesembolso', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_asignacionproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fechadesembolso', tipo: 'date', nullable: false, llave: ''},
        {campo: 'notas', tipo: 'string', nullable: true, llave: ''},
        {campo: 'valordesembolso', tipo: 'num', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_segdesembolso', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_asignacionproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fechadesembolso', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Desembolso', placeholder: '', title: 'Fecha Desembolso', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'valordesembolso', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Desembolso', placeholder: '', title: 'Valor Desembolso', numcols: 2, minimo: 1, funconchange: null, funconclick: null},
            {campo: 'notas', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_segdesembolso';
    this.Nombre = 'Proyecto_Seguimiento_Desembolso';
    this.ControllerName = 'Seguimiento_Desembolso';
    this.MethodGet = 'GetSeguimiento_DesembolsoDetails';
    this.MethodUpdate = 'UpdateSeguimiento_Desembolso';
    this.MethodInsert = 'InsertSeguimiento_Desembolso';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_segdesembolso';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoExtensionFinancieroAplicarDesembolso';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}