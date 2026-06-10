function Liquidacion_Finalizacion() {
    this.Campos = [
        {campo: 'id_liqfinalizacion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_asignacionproyecto', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'ingresos', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'pagos', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'transferencias', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'liquidacioninternahermes', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'resumenestado', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fechafincontratoasistente', tipo: 'date', nullable: true, llave: ''},
        {campo: 'ordenesnumhermes', tipo: 'string', nullable: true, llave: ''},
        {campo: 'matrizsegejecucion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'transferenciascope', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'balfifinalfirmado', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'subproyectofinhermes', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'proacahermesuncompdrive', tipo: 'string', nullable: true, llave: ''},
        {campo: 'productoacademicoenlace', tipo: 'string', nullable: true, llave: ''},
        {campo: 'correoinstitucionalproy', tipo: 'email', nullable: true, llave: ''},
        {campo: 'actaliqentidad', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'actaliqentidadenlace', tipo: 'string', nullable: true, llave: ''},        
        {campo: 'entregaarchivoce', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'resolucionliqinterna', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},        
        {campo: 'consecutivosrequerimientos', tipo: 'string', nullable: true, llave: ''},
        {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'id_estadocontrato', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoContrato, loadnulo: true},
        {campo: 'fechaestado', tipo: 'date', nullable: false, llave: ''},        
        {campo: 'pagoscumplidos', tipo: 'string', nullable: true, llave: ''},
        {campo: 'informefinal', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoTramiteSelect, loadnulo: true},
        {campo: 'informefinalenlace', tipo: 'string', nullable: true, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecultimarev', tipo: 'date', nullable: false, llave: ''}
    ]; 

    this.CamposHTML = [
        [
            {campo: 'id_liqfinalizacion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_asignacionproyecto', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', etiqueta: 'Encargado Segumiento', placeholder: '', title: 'Persona Encargada Segumiento', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'ingresos', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Ingresos', placeholder: '', title: 'Ingresos', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'pagos', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Pagos', placeholder: '', title: 'Pagos', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'transferencias', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Transferencias', placeholder: '', title: 'Transferencias', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'liquidacioninternahermes', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Liquidación HERMES', placeholder: '', title: 'Liquidación Interna HERMES', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'resumenestado', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Resumen Estado', placeholder: 'Resumen Estado', title: '', numcols: 2, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null}            
        ],
        [
            {campo: 'id_estadocontrato', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Proyecto', placeholder: '', title: 'Estado Proyecto', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fechaestado', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Cambio Estado', placeholder: '', title: 'Fecha Cambio Estado', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechafincontratoasistente', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha fin Contrato Asistente', placeholder: '', title: 'Fecha fin Contrato Asistente', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'pagoscumplidos', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Pagos Cumplidos', placeholder: 'Pagos Cumplidos', title: '', numcols: 2, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null},                        
            {campo: 'ordenesnumhermes', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Ordenes HERMES', placeholder: 'Ordenes HERMES', title: '', numcols: 2, numrows: 1, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'matrizsegejecucion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Matriz Seguimiento', placeholder: '', title: 'Matriz Seguimiento a la ejecución', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'transferenciascope', tipo: 'select', nullable: false, llave: '', etiqueta: 'Transferencias', placeholder: '', title: 'Transferencias', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'balfifinalfirmado', tipo: 'select', nullable: false, llave: '', etiqueta: 'Balance Final Firmado', placeholder: '', title: 'Balance Financiero Final Firmado', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'subproyectofinhermes', tipo: 'select', nullable: false, llave: '', etiqueta: 'SubProyecto HERMES', placeholder: '', title: 'SubProyecto Finalizado en HERMES', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'proacahermesuncompdrive', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Productos en HERMES', placeholder: 'Productos Académicos en HERMES', title: '', numcols: 2, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'productoacademicoenlace', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Productos', placeholder: 'Enlace Productos Académicos', title: '', numcols: 2, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null},
            {campo: 'informefinal', tipo: 'select', nullable: false, llave: '', etiqueta: 'Informe Final Proyecto', placeholder: '', title: 'Informe Final Proyecto', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'informefinalenlace', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Informe Final', placeholder: 'Enlace Informe Final', title: '', numcols: 2, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'correoinstitucionalproy', tipo: 'email', nullable: true, llave: '', etiqueta: 'Correo Proyecto', placeholder: 'Correo Proyecto', title: '', numcols: 2, maxlength: 150, funconchange: null, funconclick: null},
            {campo: 'actaliqentidad', tipo: 'select', nullable: false, llave: '', etiqueta: 'Acta Liq. Entidad', placeholder: '', title: 'Acta Liquidación Entidad', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'actaliqentidadenlace', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Acta Liq. Entidad', placeholder: 'Enlace Acta Liquidación Entidad', title: '', numcols: 2, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'entregaarchivoce', tipo: 'select', nullable: false, llave: '', etiqueta: 'Entrega Archivo C.E', placeholder: '', title: 'Entrega Archivo Centro Extensión', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'resolucionliqinterna', tipo: 'select', nullable: false, llave: '', etiqueta: 'Resolución Liq. Interna', placeholder: '', title: 'Resolución Liquidación Interna', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'consecutivosrequerimientos', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consecutivo Requerimientos', placeholder: 'Consecutivo Requerimientos', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'fecultimarev', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Últ. Revisión', placeholder: '', title: 'Fecha Última Revisión', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 2, numrows: 2, maxlength: 3000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_liqfinalizacion';
    this.Nombre = 'Proyecto_Liquidacion_Finalizacion';
    this.ControllerName = 'Liquidacion_Finalizacion';
    this.MethodGet = 'GetLiquidacion_FinalizacionByProyecto';
    this.MethodUpdate = 'UpdateLiquidacion_Finalizacion';
    this.MethodInsert = 'InsertLiquidacion_Finalizacion';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_asignacionproyecto';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formproyectoextensionPEL_Liquidacion';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}