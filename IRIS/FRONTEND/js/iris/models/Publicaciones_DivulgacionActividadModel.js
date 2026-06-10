function Publicaciones_DivulgacionActividad() {
        
    this.Campos = [
        {campo: 'id_actividad', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'nombre', tipo: 'string', nullable: false, llave: ''},
        {campo: 'descripcion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},
        {campo: 'hora', tipo: 'time', nullable: false, llave: ''},
        {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
        {campo: 'linkguion', tipo: 'string', nullable: true, llave: ''},
        {campo: 'checkmaterial', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'linkmaterial', tipo: 'string', nullable: true, llave: ''},
        {campo: 'linkpublicidad', tipo: 'string', nullable: true, llave: ''},
        {campo: 'textoinvitacion', tipo: 'string', nullable: true, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_actividad', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'nombre', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre', placeholder: 'Nombre', title: '', numcols: 2, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'descripcion', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción', placeholder: 'Descripción', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha', placeholder: '', title: 'Fecha', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'hora', tipo: 'time', nullable: false, llave: '', etiqueta: 'Hora', placeholder: '', title: 'Hora', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Moderador', placeholder: '', title: 'Moderador', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'linkguion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Guíon Evento', placeholder: 'Guíon Evento', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'checkmaterial', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Material Autores', placeholder: '', title: 'Material Autores', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'linkmaterial', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Link Material Autores', placeholder: 'Link Material Autores', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'linkpublicidad', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Link Pieza Publicitaria', placeholder: 'Link Pieza Publicitaria', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'textoinvitacion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Texto Invitación', placeholder: 'Texto Invitación', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_actividad';
    this.Nombre = 'Publicaciones_DivulgacionActividad';
    this.ControllerName = 'Publicaciones_DivulgacionActividad';
    this.MethodGet = 'GetPublicaciones_DivulgacionActividadByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionActividad';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionActividad';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDivulgacionMediosLanzamiento';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
