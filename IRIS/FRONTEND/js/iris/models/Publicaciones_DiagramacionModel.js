function Publicaciones_DiagramacionTaco() {    
        
        this.Campos = [
            {campo: 'id_diagramacion', tipo: 'string', nullable: false, llave: 'primary'},            
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'nmdiagramacion', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'id_estadodiagramacion', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadpublicacionEstadodiagramacionSelect, loadnulo: true},
            //{campo: 'id_estadocubierta', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadpublicacionEstadoCubiertaSelect, loadnulo: false},            
            {campo: 'fechainicio', tipo: 'date', nullable: false, llave: ''},
            {campo: 'duracion', tipo: 'int', nullable: true, llave: ''},
            {campo: 'fechaestimada', tipo: 'date', nullable: false, llave: ''},
            {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: ''}            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_diagramacion', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
                {campo: 'nmdiagramacion', tipo: 'string', nullable: true, llave: 'foranea'},
                {campo: 'id_estadodiagramacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Diagramación', placeholder: 'Estado Diagramación', title: '', numcols: 2, funconchange: null, funconclick: null},
                //{campo: 'id_estadocubierta', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Cubierta', placeholder: 'Estado Cubierta', title: '', numcols: 2, funconchange: null, funconclick: null},                
                {campo: 'fechainicio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'duracion', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiempo Programado', placeholder: '', title: 'Tiempo Programado', numcols: 2, minimo: '0', funconchange: null, funconclick: null},
                {campo: 'fechaestimada', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Estimada', placeholder: '', title: 'Fecha Estimada Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Real', placeholder: '', title: 'Fecha Real Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}                
            ]
        ];

        this.CampoLlave = 'id_diagramacion';
        this.Nombre = 'Publicaciones_DiagramacionTaco';
        this.ControllerName = 'Publicaciones_Diagramacion';
        this.MethodGet = 'GetPublicaciones_DiagramacionByPublicacionTipo';
        this.MethodUpdate = 'UpdatePublicaciones_Diagramacion';
        this.MethodInsert = 'InsertPublicaciones_Diagramacion';
        this.ParamGetName1 = 'id_crearpublicacion';
        this.ParamGetName2 = 'nmdiagramacion';
        this.ParamGetName3 = '';
        this.ObjDatos = null;
        this.FormEdicion = 'formPublicacionDiagramacionTACO';
        this.IsModal = false;
        this.DatosNullEdicion = true;
        this.SufijoNombreControl = '';
    
}

function Publicaciones_DiagramacionCubierta() {    
        
    this.Campos = [
        {campo: 'id_diagramacion', tipo: 'string', nullable: false, llave: 'primary'},            
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'nmdiagramacion', tipo: 'string', nullable: false, llave: 'foranea'},
        //{campo: 'id_estadodiagramacion', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadpublicacionEstadodiagramacionSelect, loadnulo: false},
        {campo: 'id_estadocubierta', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadpublicacionEstadoCubiertaSelect, loadnulo: true},            
        {campo: 'fechainicio', tipo: 'date', nullable: false, llave: ''},
        {campo: 'duracion', tipo: 'int', nullable: true, llave: ''},
        {campo: 'fechaestimada', tipo: 'date', nullable: false, llave: ''},
        {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: ''},
        {campo: 'resenacubierta', tipo: 'string', nullable: false, llave: '', noupdate: true},
    ];

    this.CamposHTML = [
        [
            {campo: 'id_diagramacion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'nmdiagramacion', tipo: 'string', nullable: true, llave: 'foranea'},
            //{campo: 'id_estadodiagramacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Diagramación', placeholder: 'Estado Diagramación', title: '', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_estadocubierta', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Cubierta', placeholder: 'Estado Cubierta', title: '', numcols: 2, funconchange: null, funconclick: null},                
            {campo: 'fechainicio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'duracion', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiempo Programado', placeholder: '', title: 'Tiempo Programado', numcols: 2, minimo: '0', funconchange: null, funconclick: null},
            {campo: 'fechaestimada', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Estimada', placeholder: '', title: 'Fecha Estimada Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'fechaentrega', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Real', placeholder: '', title: 'Fecha Real Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}                
        ],
        [
            {campo: 'resenacubierta', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Reseña Cubierta', placeholder: 'Reseña Cubierta', title: '', numcols: 4, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_diagramacion';
    this.Nombre = 'Publicaciones_DiagramacionCubierta';
    this.ControllerName = 'Publicaciones_Diagramacion';
    this.MethodGet = 'GetPublicaciones_DiagramacionByPublicacionTipo';
    this.MethodUpdate = 'UpdatePublicaciones_Diagramacion';
    this.MethodInsert = 'InsertPublicaciones_Diagramacion';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = 'nmdiagramacion';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDiagramacionCUBIERTA';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
