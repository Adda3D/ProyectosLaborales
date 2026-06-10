function Publicaciones_DivulgacionPlanActividad() {
        
    this.Campos = [
        {campo: 'iddivulgacionplanactividad', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'actividad', tipo: 'string', nullable: false, llave: ''},
        {campo: 'fecha', tipo: 'date', nullable: true, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'iddivulgacionplanactividad', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'actividad', tipo: 'string', nullable: false, llave: '', etiqueta: 'Actividad', placeholder: 'Actividad', title: '', numcols: 4, maxlength: 90, funconchange: null, funconclick: null},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Estimada', placeholder: '', title: 'Fecha Estimada', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'iddivulgacionplanactividad';
    this.Nombre = 'Publicaciones_DivulgacionPlanActividad';
    this.ControllerName = 'Publicaciones_DivulgacionPlanActividad';
    this.MethodGet = 'GetPublicaciones_DivulgacionPlanActividadDetails';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionPlanActividad';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionPlanActividad';
    this.ParamGetName1 = 'iddivulgacionplanactividad';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicaciones_DivulgacionPlanActividades';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
