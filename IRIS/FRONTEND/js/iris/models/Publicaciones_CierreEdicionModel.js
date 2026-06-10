function Publicaciones_CierreEdicion() {
        
    this.Campos = [
        {campo: 'id_cierreedicion', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fichacatalografica', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'solicitudisbn', tipo: 'string', nullable: true, llave: ''},
        {campo: 'fecsolisbn', tipo: 'date', nullable: true, llave: ''},
        {campo: 'isbndigital', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSiNoNoAplicaSelect, loadnulo: false},
        {campo: 'nroisbndigital', tipo: 'string', nullable: true, llave: ''},
        {campo: 'isbnimpreso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSiNoNoAplicaSelect, loadnulo: false},
        {campo: 'nroisbnimpreso', tipo: 'string', nullable: true, llave: ''},
        {campo: 'isbndemanda', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSiNoNoAplicaSelect, loadnulo: false},
        {campo: 'nroisbndemanda', tipo: 'string', nullable: true, llave: ''},
        {campo: 'credproceditorial', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'anoedicion', tipo: 'date', nullable: true, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_cierreedicion', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fichacatalografica', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Ficha Catalográfica', placeholder: '', title: 'Ficha Catalográfica', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'solicitudisbn', tipo: 'string', nullable: false, llave: '', etiqueta: 'No. Solicitud ISBN', placeholder: 'No. Solicitud ISBN', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'fecsolisbn', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Solicitud ISBN', placeholder: '', title: 'Fecha Solicitud ISBN', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'isbndigital', tipo: 'select', nullable: false, llave: '', etiqueta: 'ISBN Digital', placeholder: '', title: 'ISBN Digital', numcols: 2, funconchange: "HabilitarControlISBNPublicaciones_CierreEdicion('cboisbndigital_Publicaciones_CierreEdicion','txtnroisbndigital_Publicaciones_CierreEdicion')", funconclick: null},
            {campo: 'nroisbndigital', tipo: 'string', nullable: true, llave: '', etiqueta: 'No. ISBN Digital', placeholder: 'No. ISBN Digital', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'isbnimpreso', tipo: 'select', nullable: false, llave: '', etiqueta: 'ISBN Impreso', placeholder: '', title: 'ISBN Impreso', numcols: 2, funconchange: "HabilitarControlISBNPublicaciones_CierreEdicion('cboisbnimpreso_Publicaciones_CierreEdicion','txtnroisbnimpreso_Publicaciones_CierreEdicion')", funconclick: null},
            {campo: 'nroisbnimpreso', tipo: 'string', nullable: true, llave: '', etiqueta: 'No. ISBN Impreso', placeholder: 'No. ISBN Impreso', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'isbndemanda', tipo: 'select', nullable: false, llave: '', etiqueta: 'ISBN Bajo Demanda', placeholder: '', title: 'ISBN Bajo Demanda', numcols: 2, funconchange: "HabilitarControlISBNPublicaciones_CierreEdicion('cboisbndemanda_Publicaciones_CierreEdicion','txtnroisbndemanda_Publicaciones_CierreEdicion')", funconclick: null},
            {campo: 'nroisbndemanda', tipo: 'string', nullable: true, llave: '', etiqueta: 'No. ISBN Bajo Demanda', placeholder: 'No. ISBN Bajo Demanda', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'credproceditorial', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Crédito Participantes', placeholder: '', title: 'Creditos de los participantes del proceso editorial', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'anoedicion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Impresión', placeholder: '', title: 'Fecha Impresión', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_cierreedicion';
    this.Nombre = 'Publicaciones_CierreEdicion';
    this.ControllerName = 'Publicaciones_CierreEdicion';
    this.MethodGet = 'GetPublicaciones_CierreEdicionByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_CierreEdicion';
    this.MethodInsert = 'InsertPublicaciones_CierreEdicion';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionCierreEdicion';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}