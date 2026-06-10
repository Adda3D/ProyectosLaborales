function Publicaciones_IngresosPorVentas() {
        
    this.Campos = [        
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'unidades', tipo: 'int', nullable: false, llave: ''},
        {campo: 'ventas', tipo: 'int', nullable: false, llave: ''},
        {campo: 'comision', tipo: 'int', nullable: false, llave: ''},
        {campo: 'neto', tipo: 'int', nullable: false, llave: ''},
        {campo: 'costounitario', tipo: 'int', nullable: false, llave: ''},
        {campo: 'ingresounitario', tipo: 'int', nullable: false, llave: ''},
        {campo: 'margenvalor', tipo: 'int', nullable: false, llave: ''},
        {campo: 'margenporcentaje', tipo: 'int', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [            
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'unidades', tipo: 'int', nullable: false, llave: '', etiqueta: 'Unidades Vendidas', placeholder: '', title: 'Unidades Vendidas', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'ventas', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Ventas', placeholder: '', title: 'Valor Ventas', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'comision', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Comisión', placeholder: '', title: 'Valor Comisión', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'neto', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Ingreso Facultad', placeholder: '', title: 'Valor Ingreso Facultad', numcols: 2, minimo: 0, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'ingresounitario', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Ingreso Unitario', placeholder: '', title: 'Valor Ingreso Unitario', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'costounitario', tipo: 'int', nullable: false, llave: '', etiqueta: 'Costo Unitario', placeholder: '', title: 'Costo Unitario', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'margenvalor', tipo: 'int', nullable: false, llave: '', etiqueta: 'Margen Unitario', placeholder: '', title: 'Margen Unitario', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'margenporcentaje', tipo: 'int', nullable: false, llave: '', etiqueta: 'Margen Unitario (%)', placeholder: '', title: 'Margen Unitario (%)', numcols: 2, minimo: 0, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_crearpublicacion';
    this.Nombre = 'Publicaciones_IngresosPorVentas';    
    this.ControllerName = 'PublicacionInformes';    
    this.MethodGet = 'GetIngresosVentasByPublicacion';
    this.MethodUpdate = '';
    this.MethodInsert = '';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionIngresosPorVentas';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
