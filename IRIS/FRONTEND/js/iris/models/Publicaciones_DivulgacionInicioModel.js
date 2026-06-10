function Publicaciones_DivulgacionInicio() {
        
    this.Campos = [
        {campo: 'iddivulgacioninicio', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'linkcubierta', tipo: 'string', nullable: false, llave: ''},
        {campo: 'linkportada', tipo: 'string', nullable: false, llave: ''},
        {campo: 'linkcontraportada', tipo: 'string', nullable: true, llave: ''},
        {campo: 'linklomo', tipo: 'string', nullable: true, llave: ''},
        {campo: 'linksolapas', tipo: 'string', nullable: true, llave: ''},
        {campo: 'linkwebunal', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'iddivulgacioninicio', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'linkcubierta', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Enlace a Cubierta', placeholder: 'Enlace a Cubierta', title: '', numcols: 3, numrows: 2, maxlength: 300, funconchange: null, funconclick: null},
            {campo: 'linkportada', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Enlace a Portada', placeholder: 'Enlace a Portada', title: '', numcols: 3, numrows: 2, maxlength: 300, funconchange: null, funconclick: null},
            {campo: 'linkcontraportada', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace a ContraPortada', placeholder: 'Enlace a ContraPortada', title: '', numcols: 3, numrows: 2, maxlength: 300, funconchange: null, funconclick: null},
            {campo: 'linklomo', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace a Lomo', placeholder: 'Enlace a Lomo', title: '', numcols: 3, numrows: 2, maxlength: 300, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'linksolapas', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace a Solapas', placeholder: 'Enlace a Solapas', title: '', numcols: 3, numrows: 2, maxlength: 300, funconchange: null, funconclick: null},
            {campo: 'linkwebunal', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace a Web Editorial', placeholder: 'Enlace a Web Editorial', title: '', numcols: 3, numrows: 2, maxlength: 300, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'iddivulgacioninicio';
    this.Nombre = 'Publicaciones_DivulgacionInicio';
    this.ControllerName = 'Publicaciones_DivulgacionInicio';
    this.MethodGet = 'GetPublicaciones_DivulgacionInicioByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionInicio';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionInicio';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDivulgacionInicio';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
