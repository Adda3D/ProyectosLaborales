function Publicaciones_TipoCorreccion() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_tipocorreccion', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
            {campo: 'contratocorreccion', tipo: 'string', nullable: true, llave: ''},
            {campo: 'orpa1', tipo: 'string', nullable: true, llave: ''},
            {campo: 'fechaorpa1', tipo: 'date', nullable: true, llave: ''},
            {campo: 'orpa2', tipo: 'string', nullable: true, llave: ''},
            {campo: 'fechaorpa2', tipo: 'date', nullable: true, llave: ''},
            {campo: 'quipu', tipo: 'string', nullable: true, llave: ''},
            {campo: 'tipocorreccion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPublicacionTipoCorreccionselect, loadnulo: true},
            {campo: 'id_estadocorreccion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoCorreccionSelect, loadnulo: true},
            {campo: 'reqindices', tipo: 'bool', nullable: false, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_tipocorreccion', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
                {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Corrector', placeholder: 'Corrector', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'contratocorreccion', tipo: 'string', nullable: true, llave: '', etiqueta: 'No. Contrato', placeholder: 'Contrato', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'orpa1', tipo: 'string', nullable: true, llave: '', etiqueta: 'ORPA 01', placeholder: 'ORPA', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
                {campo: 'fechaorpa1', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha ORPA 01', placeholder: '', title: 'Fecha ORPA', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'orpa2', tipo: 'string', nullable: true, llave: '', etiqueta: 'ORPA 02', placeholder: 'ORPA', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
                {campo: 'fechaorpa2', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha ORPA 02', placeholder: '', title: 'Fecha ORPA', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}
            ],
            [
                {campo: 'reqindices', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Requiere Indices', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'quipu', tipo: 'string', nullable: true, llave: '', etiqueta: 'QUIPU', placeholder: 'QUIPU', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'tipocorreccion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Corrección', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_estadocorreccion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado Corrección', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null}
            ]
        ];

        this.CampoLlave = 'id_tipocorreccion';
        this.Nombre = 'Publicaciones_TipoCorreccion';
        this.ControllerName = 'Publicaciones_TipoCorreccion';
        this.MethodGet = 'GetPublicaciones_TipoCorreccionByPublicacion';
        this.MethodUpdate = 'UpdatePublicaciones_TipoCorreccion';
        this.MethodInsert = 'InsertPublicaciones_TipoCorreccion';
        this.ParamGetName1 = 'id_crearpublicacion';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ObjDatos = null;
        this.FormEdicion = 'formPublicacionCorreccionDefinicion';
        this.IsModal = false;
        this.DatosNullEdicion = true;
        this.SufijoNombreControl = '';

    //}
}