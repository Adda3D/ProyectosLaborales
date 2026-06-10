function Publicaciones_DivulgacionHerramientaUnimedios() {
        
    this.Campos = [
        {campo: 'id_herramienta', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_tipomedio', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'enlace', tipo: 'string', nullable: false, llave: ''},        
        {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},        
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_herramienta', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_tipomedio', tipo: 'string', nullable: true, llave: 'foranea'},            
            {campo: 'enlace', tipo: 'string', nullable: false, llave: '', etiqueta: 'Link Publicación', placeholder: 'Link Publicación', title: '', numcols: 4, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Publicación', placeholder: '', title: 'Fecha Publicación', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},            
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_herramienta';
    this.Nombre = 'Publicaciones_DivulgacionHerramientaUnimedios';
    this.ControllerName = 'Publicaciones_DivulgacionHerramienta';
    this.MethodGet = 'GetPublicaciones_DivulgacionHerramientaDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionHerramienta';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionHerramienta';
    this.ParamGetName1 = 'id_herramienta';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionHerramientasUnimedios';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
