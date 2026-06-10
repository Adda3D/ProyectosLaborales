function Publicaciones_EstadoCorParam() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_estadocorparam', tipo: 'string', nullable: false, llave: 'primary'},            
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'correccionetapa', tipo: 'string', nullable: false, llave: 'foranea'},
            //{campo: 'id_persona', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: false},
            //{campo: 'responsable', tipo: 'string', nullable: false, llave: ''},            
            {campo: 'ingreso', tipo: 'date', nullable: false, llave: ''},
            {campo: 'duracion', tipo: 'int', nullable: false, llave: ''},
            {campo: 'finalizacion', tipo: 'date', nullable: false, llave: ''},
            {campo: 'fecharealfinalizacion', tipo: 'date', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_estadocorparam', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
                {campo: 'correccionetapa', tipo: 'string', nullable: true, llave: 'foranea'},
                //{campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Corrector', placeholder: 'Corrector', title: '', numcols: 2, funconchange: null, funconclick: null},
                //{campo: 'responsable', tipo: 'string', nullable: false, llave: '', etiqueta: 'Responsable', placeholder: 'Responsable', title: '', numcols: 2, maxlength: 80, funconchange: null, funconclick: null},
                {campo: 'ingreso', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicia', placeholder: '', title: 'Fecha Inicia', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'duracion', tipo: 'int', nullable: false, llave: '', etiqueta: 'Tiempo Programado', placeholder: '', title: 'Tiempo Programado', numcols: 2, minimo: '0', funconchange: null, funconclick: null},
                {campo: 'finalizacion', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Final', placeholder: '', title: 'Fecha Estimada Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'fecharealfinalizacion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Real', placeholder: '', title: 'Fecha Real Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}                
            ]
        ];

        this.CampoLlave = 'id_estadocorparam';
        this.Nombre = 'Publicaciones_EstadoCorParam';
        this.ControllerName = 'Publicaciones_EstadoCorParam';
        this.MethodGet = 'GetPublicaciones_EstadoCorParamByPublicacionEtapa';
        this.MethodUpdate = 'UpdatePublicaciones_EstadoCorParam';
        this.MethodInsert = 'InsertPublicaciones_EstadoCorParam';
        this.ParamGetName1 = 'id_crearpublicacion';
        this.ParamGetName2 = 'correccionetapa';
        this.ParamGetName3 = '';
        this.ObjDatos = null;
        this.FormEdicion = 'formPublicacionCorreccionEstilo';
        this.IsModal = false;
        this.DatosNullEdicion = true;
        this.SufijoNombreControl = '';

    //}
}