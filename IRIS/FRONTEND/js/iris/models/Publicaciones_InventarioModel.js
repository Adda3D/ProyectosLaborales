function Publicaciones_Inventario() {
        
    this.Campos = [        
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'invinamovible', tipo: 'int', nullable: false, llave: ''},
        {campo: 'invinstitucional', tipo: 'int', nullable: false, llave: ''},
        {campo: 'invcomercial', tipo: 'int', nullable: false, llave: ''},
        {campo: 'invterceros', tipo: 'int', nullable: false, llave: ''},
    ];

    this.CamposHTML = [
        [            
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'invinamovible', tipo: 'int', nullable: false, llave: '', etiqueta: 'Inventario Inamovible (en bodega facultad)', placeholder: '', title: 'Unidades Vendidas', numcols: 3, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'invinstitucional', tipo: 'int', nullable: false, llave: '', etiqueta: 'Inventario Institucional (en bodega facultad)', placeholder: '', title: 'Inventario Institucional (en bodega facultad)', numcols: 3, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'invcomercial', tipo: 'int', nullable: false, llave: '', etiqueta: 'Inventario Comercial (en bodega facultad)', placeholder: '', title: 'Inventario Comercial (en bodega facultad)', numcols: 3, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'invterceros', tipo: 'int', nullable: false, llave: '', etiqueta: 'Inventario Comercial (en terceros)', placeholder: '', title: 'Inventario Comercial (en terceros)', numcols: 3, minimo: 0, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_crearpublicacion';
    this.Nombre = 'Publicaciones_Inventario';    
    this.ControllerName = 'PublicacionInformes';    
    this.MethodGet = 'GetInventarioByPublicacion';
    this.MethodUpdate = '';
    this.MethodInsert = '';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionInventario';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
