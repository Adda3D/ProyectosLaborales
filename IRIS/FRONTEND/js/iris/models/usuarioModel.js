function Usuario() {
        
    this.Campos = [
        {campo: 'id_usuario', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'nombrecompleto', tipo: 'string', nullable: false, llave: ''},
        {campo: 'correoinstitucional', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
        {campo: 'idrol', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadRolUsuarioSelect, loadnulo: false},
        {campo: 'id_depend', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_usuario', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'nombrecompleto', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Completo', placeholder: 'Nombre Completo', title: '', numcols: 3, maxlength: 80, funconchange: null, funconclick: null},
            {campo: 'correoinstitucional', tipo: 'string', nullable: false, llave: '', etiqueta: 'Usuario UNAL', placeholder: 'Usuario UNAL', title: '', numcols: 2, maxlength: 20, funconchange: null, funconclick: null},
            {campo: 'idrol', tipo: 'select', nullable: false, llave: '', etiqueta: 'Rol Usuario', placeholder: '', title: 'Rol Usuario', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_depend', tipo: 'select', nullable: true, llave: '', etiqueta: 'Dependencia', placeholder: '', title: 'Dependencia', numcols: 2, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_usuario';
    this.Nombre = 'Usuario';
    this.ControllerName = 'Usuario';
    this.MethodGet = 'GetUsuario';
    this.MethodUpdate = 'UpdateUsuario';
    this.MethodInsert = 'InsertUsuario';
    this.MethodValidarDuplicado = 'GetUsuario';
    this.ParamGetName1 = 'id_usuario';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'correo';
    this.ObjDatos = null;
    this.FormEdicion = 'formUsuariosApp';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
