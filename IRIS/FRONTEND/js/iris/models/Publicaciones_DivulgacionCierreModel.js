function Publicaciones_DivulgacionCierre() {
        
    this.Campos = [
        {campo: 'id_cierre', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'infdifundida', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'bitacora', tipo: 'string', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_cierre', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'infdifundida', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Recolección de Información', placeholder: '', title: 'Recolección de Información', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'bitacora', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Bitácora Seguimiento', placeholder: 'Bitácora Seguimiento', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_cierre';
    this.Nombre = 'Publicaciones_DivulgacionCierre';
    this.ControllerName = 'Publicaciones_DivulgacionCierre';
    this.MethodGet = 'GetPublicaciones_DivulgacionCierreByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionCierre';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionCierre';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDivulgacionCierreBitacora';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
