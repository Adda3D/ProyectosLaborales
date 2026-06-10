function Publicaciones_DepositoControlActa() {
        
    this.Campos = [
        {campo: 'id_actacosto', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fecenvioagu', tipo: 'date', nullable: false, llave: ''},
        {campo: 'costodirecto', tipo: 'int', nullable: false, llave: ''},
        {campo: 'costoindirecto', tipo: 'int', nullable: false, llave: ''},
        {campo: 'costototal', tipo: 'int', nullable: false, llave: ''},
        {campo: 'tirajetotal', tipo: 'int', nullable: false, llave: ''},
        {campo: 'costounitario', tipo: 'int', nullable: false, llave: ''},
    ];

    this.CamposHTML = [
        [
            {campo: 'id_actacosto', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fecenvioagu', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Envío Almacén', placeholder: '', title: 'Fecha Envío Almacén', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'costodirecto', tipo: 'int', nullable: false, llave: '', etiqueta: 'Costo Directo', placeholder: '', title: 'Costo Directo', numcols: 2, minimo: 0, funconchange: "Publicacion_TotalyCostoUnitario();", funconclick: null},
            {campo: 'costoindirecto', tipo: 'int', nullable: false, llave: '', etiqueta: 'Costo InDirecto', placeholder: '', title: 'Costo InDirecto', numcols: 2, minimo: 0, funconchange: "Publicacion_TotalyCostoUnitario();", funconclick: null},
            {campo: 'costototal', tipo: 'int', nullable: false, llave: '', etiqueta: 'Costo Total', placeholder: '', title: 'Costo Total', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'tirajetotal', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiraje Total', placeholder: '', title: 'Tiraje Total', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'costounitario', tipo: 'int', nullable: false, llave: '', etiqueta: 'Costo Unitario', placeholder: '', title: 'Costo Unitario', numcols: 2, minimo: 0, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_actacosto';
    this.Nombre = 'Publicaciones_DepositoControlActa';
    this.ControllerName = 'Publicaciones_DepositoControlActa';
    this.MethodGet = 'GetPublicaciones_DepositoControlActaByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DepositoControlActa';
    this.MethodInsert = 'InsertPublicaciones_DepositoControlActa';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDistribucionActaCostos';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
