function RolUsuario() {
        
    this.Campos = [
        {campo: 'idrol', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'nombre', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'idrol', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'nombre', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Rol', placeholder: 'Nombre Rol', title: '', numcols: 8, maxlength: 50, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'idrol';
    this.Nombre = 'RolUsuario';
    this.ControllerName = 'Rol';
    this.MethodGet = 'GetRolDetails';
    this.MethodUpdate = 'UpdateRol';
    this.MethodInsert = 'InsertRol';
    this.ParamGetName1 = 'id_rol';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formRolesUsuario';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
