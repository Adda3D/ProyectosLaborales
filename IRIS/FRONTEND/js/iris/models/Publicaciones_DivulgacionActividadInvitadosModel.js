function Publicaciones_DivulgacionActividadInvitados() {
        
    this.Campos = [
        {campo: 'id_invitados', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'nombrecompleto', tipo: 'string', nullable: false, llave: ''},
        {campo: 'institucion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'nalointer', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadInvitadoNacionalSelect, loadnulo: false},
        {campo: 'perfil', tipo: 'string', nullable: false, llave: ''},
        {campo: 'telefono', tipo: 'int', nullable: false, llave: ''},
        {campo: 'email', tipo: 'email', nullable: false, llave: ''},
        {campo: 'divulgacionnombre', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'divulgacionfoto', tipo: 'bool', nullable: false, llave: ''},        
        {campo: 'divulgacionperfil', tipo: 'bool', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_invitados', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'nombrecompleto', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Completo', placeholder: 'Nombre Completo', title: '', numcols: 3, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'institucion', tipo: 'string', nullable: false, llave: '', etiqueta: 'Institución', placeholder: 'Institución', title: '', numcols: 3, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'nalointer', tipo: 'select', nullable: false, llave: '', etiqueta: 'Es Nacional?', placeholder: '', title: 'Es Nacional?', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'perfil', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Perfil', placeholder: 'Perfil', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'telefono', tipo: 'int', nullable: false, llave: '', etiqueta: 'No. Celular', placeholder: '', title: 'No. Celular', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'email', tipo: 'email', nullable: false, llave: '', etiqueta: 'E-mail', placeholder: 'E-mail', title: '', numcols: 3, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'divulgacionnombre', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Nombre Validado', placeholder: '', title: 'Nombre Validado', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'divulgacionfoto', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Fotografía Validada', placeholder: '', title: 'Fotografía Validada', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'divulgacionperfil', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Perfil Validado', placeholder: '', title: 'Perfil Validado', numcols: 2, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_invitados';
    this.Nombre = 'Publicaciones_DivulgacionActividadInvitados';
    this.ControllerName = 'Publicaciones_DivulgacionActividadInvitados';
    this.MethodGet = 'GetPublicaciones_DivulgacionActividadInvitadosDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionActividadInvitados';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionActividadInvitados';
    this.ParamGetName1 = 'id_invitados';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionMediosInvitados';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
