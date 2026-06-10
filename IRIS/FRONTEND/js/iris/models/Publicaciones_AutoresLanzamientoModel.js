function Publicaciones_AutoresLanzamiento() {
        
    this.Campos = [
        {campo: 'id_autores', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_persona', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'divulgacionnombre', tipo: 'bool', nullable: true, llave: ''},
        {campo: 'divulgacionfoto', tipo: 'bool', nullable: true, llave: ''},        
        {campo: 'divulgacionperfil', tipo: 'bool', nullable: true, llave: ''},
        {campo: 'NombrePersona', tipo: 'string', nullable: false, llave: '', noupdate: true}        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_autores', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_persona', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'NombrePersona', tipo: 'string', nullable: true, llave: '', etiqueta: 'Nombre Autor', placeholder: 'Nombre Autor', title: '', numcols: 4, maxlength: 60, funconchange: null, funconclick: null},
            {campo: 'divulgacionnombre', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Nombre Validado', placeholder: '', title: 'Nombre Validado', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'divulgacionfoto', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Fotografía Validada', placeholder: '', title: 'Fotografía Validada', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'divulgacionperfil', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Perfil Validado', placeholder: '', title: 'Perfil Validado', numcols: 2, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_autores';
    this.Nombre = 'Publicaciones_AutoresLanzamiento';
    this.ControllerName = 'Publicaciones_Autores';
    this.MethodGet = 'GetPublicaciones_AutoresDetailsPersona';
    this.MethodUpdate = 'UpdatePublicaciones_AutoresLanzamiento';
    this.MethodInsert = 'InsertPublicaciones_Autores';
    this.ParamGetName1 = 'id_autores';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionMediosAutores';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
