function Publicaciones_DivulgacionHerramientaMailing() {
        
    this.Campos = [
        {campo: 'id_herramienta', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_tipomedio', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},
        {campo: 'numeroenvios', tipo: 'int', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_herramienta', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_tipomedio', tipo: 'string', nullable: true, llave: 'foranea'},            
            {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Envío', placeholder: '', title: 'Fecha Envío', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'numeroenvios', tipo: 'int', nullable: false, llave: '', etiqueta: 'No. Correos Enviados', placeholder: '', title: 'No. Correos Enviados', numcols: 2, minimo: 1, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_herramienta';
    this.Nombre = 'Publicaciones_DivulgacionHerramientaMailing';
    this.ControllerName = 'Publicaciones_DivulgacionHerramienta';
    this.MethodGet = 'GetPublicaciones_DivulgacionHerramientaDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionHerramienta';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionHerramienta';
    this.ParamGetName1 = 'id_herramienta';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionHerramientasMailing';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
