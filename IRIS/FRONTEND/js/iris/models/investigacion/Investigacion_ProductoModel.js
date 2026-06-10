function Investigacion_Producto() {
    this.Campos = [
        {campo: 'id_producto', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_tipoproducto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadTipoProductoProyecto, loadnulo: true},
        {campo: 'id_estadoproducto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoProductoProyecto, loadnulo: true},        
        {campo: 'descripcion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'cantidad', tipo: 'int', nullable: false, llave: ''},
        {campo: 'cumplidos', tipo: 'int', nullable: false, llave: ''},
        {campo: 'fechainicio', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fechafin', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_producto', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_tipoproducto', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Producto', placeholder: '', title: 'Tipo Producto', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'descripcion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Descripción', placeholder: 'Descripción', title: '', numcols: 6, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'cantidad', tipo: 'int', nullable: false, llave: '', etiqueta: 'Cantidad', placeholder: '', title: 'Cantidad', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'cumplidos', tipo: 'int', nullable: false, llave: '', etiqueta: 'No. Cumplidos', placeholder: '', title: 'No. Cumplidos', numcols: 2, minimo: 0, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'fechainicio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechafin', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Finaliza', placeholder: '', title: 'Fecha Finaliza', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Entrega', placeholder: '', title: 'Fecha Finaliza', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'id_estadoproducto', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado', placeholder: '', title: 'Estado', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_producto';
    this.Nombre = 'Investigacion_Producto';
    this.ControllerName = 'Investigacion_Producto';
    this.MethodGet = 'GetInvestigacion_ProductoDetails';
    this.MethodUpdate = 'UpdateInvestigacion_Producto';
    this.MethodInsert = 'InsertInvestigacion_Producto';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_producto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formProyectoInvestigacionProductos';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}