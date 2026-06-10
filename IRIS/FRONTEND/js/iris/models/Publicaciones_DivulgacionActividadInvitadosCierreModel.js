function Publicaciones_DivulgacionActividadInvitadosCierre() {
        
    this.Campos = [
        {campo: 'id_invitados', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'nombrecompleto', tipo: 'string', nullable: false, llave: '', noupdate: true},
        {campo: 'agradecimientoevento', tipo: 'bool', nullable: true, llave: ''},
        {campo: 'agradecimientonotas', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_invitados', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'nombrecompleto', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Invitado', placeholder: 'Nombre Invitado', title: '', numcols: 3, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'agradecimientoevento', tipo: 'bool', nullable: true, llave: '', etiqueta: 'Nombre Validado', placeholder: '', title: 'Nombre Validado', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'agradecimientonotas', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_invitados';
    this.Nombre = 'Publicaciones_DivulgacionActividadInvitadosCierre';
    this.ControllerName = 'Publicaciones_DivulgacionActividadInvitados';
    this.MethodGet = 'GetPublicaciones_DivulgacionActividadInvitadosDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionActividadInvitadosCierre';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionActividadInvitados';
    this.ParamGetName1 = 'id_invitados';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionCierreRetroInvitados';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
