function Publicaciones_DepositoControlInventarioMovimientos() {
        
    this.Campos = [
        {campo: 'id_movimientos', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_bodega', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionBodegaInventarioSelect, loadnulo: true},
        {campo: 'id_tipomov', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionTipoMovimientoInventarioSelect, loadnulo: false},
        {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},                
        {campo: 'cantidad', tipo: 'int', nullable: false, llave: ''},
        {campo: 'descripcion', tipo: 'string', nullable: true, llave: ''},    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_movimientos', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_bodega', tipo: 'select', nullable: false, llave: '', etiqueta: 'Bodega', placeholder: '', title: 'Bodega', numcols: 4, funconchange: null, funconclick: null},
            {campo: 'id_tipomov', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Ajuste', placeholder: '', title: 'Tipo Ajuste', numcols: 3, funconchange: null, funconclick: null},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Ajuste', placeholder: '', title: 'Fecha Ajuste', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'cantidad', tipo: 'int', nullable: false, llave: '', etiqueta: 'Cantidad', placeholder: '', title: 'Cantidad', numcols: 2, minimo: 1, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'descripcion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Motivo Ajuste', placeholder: 'Motivo Ajuste', title: '', numcols: 6, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]        
    ];

    this.CampoLlave = 'id_movimientos';
    this.Nombre = 'Publicaciones_DepositoControlInventarioMovimientos';
    this.ControllerName = 'Publicaciones_DepositoControlInventarioMovimientos';
    this.MethodGet = 'GetPublicaciones_DepositoControlInventarioMovimientosDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoControlInventarioMovimientos';
    this.MethodInsert = 'InsertPublicaciones_DepositoControlInventarioMovimientos';
    this.ParamGetName1 = 'id_movimientos';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DepositoControlInventarioMovimientos';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
