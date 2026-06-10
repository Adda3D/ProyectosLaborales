function Publicaciones_AutoresCierre() {
        
    this.Campos = [
        {campo: 'id_autores', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_persona', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'retroalimentacionevento', tipo: 'bool', nullable: true, llave: ''},
        {campo: 'retroalimentacionnotas', tipo: 'string', nullable: false, llave: ''},
        {campo: 'NombrePersona', tipo: 'string', nullable: false, llave: '', noupdate: true}        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_autores', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_persona', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'NombrePersona', tipo: 'string', nullable: true, llave: '', etiqueta: 'Nombre Autor', placeholder: 'Nombre Autor', title: '', numcols: 4, maxlength: 60, funconchange: null, funconclick: null},
            {campo: 'retroalimentacionevento', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Retroalimentación Autor', placeholder: '', title: 'Retroalimentación Autor', numcols: 3, funconchange: null, funconclick: null},
            {campo: 'retroalimentacionnotas', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observaciones Retroalimentación', placeholder: 'Observaciones Retroalimentación', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_autores';
    this.Nombre = 'Publicaciones_AutoresCierre';
    this.ControllerName = 'Publicaciones_Autores';
    this.MethodGet = 'GetPublicaciones_AutoresDetailsPersona';
    this.MethodUpdate = 'UpdatePublicaciones_AutoresCierre';
    this.MethodInsert = 'InsertPublicaciones_Autores';
    this.ParamGetName1 = 'id_autores';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionCierreAutores';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
