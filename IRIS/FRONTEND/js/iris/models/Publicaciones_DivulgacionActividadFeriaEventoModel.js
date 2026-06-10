function Publicaciones_DivulgacionActividadFeriaEvento() {
        
    this.Campos = [
        {campo: 'idferiaevento', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'tipo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFeriaEventoSelect, loadnulo: false},
        {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},
        {campo: 'nombre', tipo: 'string', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'idferiaevento', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'tipo', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo', placeholder: '', title: 'Tipo', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'nombre', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Actividad', placeholder: 'Nombre Actividad', title: '', numcols: 4, maxlength: 100, funconchange: null, funconclick: null},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Actividad', placeholder: '', title: 'Fecha Actividad', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'idferiaevento';
    this.Nombre = 'Publicaciones_DivulgacionActividadFeriaEvento';
    this.ControllerName = 'Publicaciones_DivulgacionActividadFeriaEvento';
    this.MethodGet = 'GetPublicaciones_DivulgacionActividadFeriaEventoDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionActividadFeriaEvento';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionActividadFeriaEvento';
    this.ParamGetName1 = 'idferiaevento';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionActividadFeriaEvento';
    this.IsModal = true;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
