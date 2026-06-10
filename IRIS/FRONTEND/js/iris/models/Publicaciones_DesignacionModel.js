function Publicaciones_Designacion() {
        
        this.Campos = [
            {campo: 'id_designacion', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPrestadorServicio, loadnulo: true},
            {campo: 'id_tipologia', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionTipologiaSelect, loadnulo: true},
            {campo: 'nmcontratacion', tipo: 'string', nullable: false, llave: ''},
            {campo: 'numpagos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'fecinicio', tipo: 'date', nullable: true, llave: ''},
            {campo: 'fecfin', tipo: 'date', nullable: true, llave: ''},
            {campo: 'orpa1', tipo: 'string', nullable: true, llave: ''},
            {campo: 'fecpagopar', tipo: 'date', nullable: true, llave: ''},
            {campo: 'orpa2', tipo: 'string', nullable: true, llave: ''},
            {campo: 'fecpagofinal', tipo: 'date', nullable: true, llave: ''},            
            {campo: 'quipu', tipo: 'string', nullable: true, llave: ''},            
            {campo: 'id_tipodiagramacion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadpublicacionTipodiagramacionSelect, loadnulo: true}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_designacion', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
                {campo: 'id_persona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Diagramador', placeholder: 'Diagramador', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_tipologia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipología', placeholder: 'Tipología', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_tipodiagramacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Diagramación', placeholder: 'Tipo Diagramación', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'nmcontratacion', tipo: 'string', nullable: true, llave: '', etiqueta: 'No. Contrato', placeholder: 'Contrato', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
                {campo: 'numpagos', tipo: 'int', nullable: true, llave: '', etiqueta: 'No. Pagos', placeholder: 'No. Pagos', title: '', numcols: 2, minimo: '0', funconchange: null, funconclick: null},
                {campo: 'fecinicio', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Inicio', placeholder: '', title: 'Fecha Inicio', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}                
            ],
            [
                {campo: 'fecfin', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Finaliza', placeholder: '', title: 'Fecha Finaliza', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'orpa1', tipo: 'string', nullable: true, llave: '', etiqueta: 'ORPA 01', placeholder: 'ORPA', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
                {campo: 'fecpagopar', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Pago Parcial', placeholder: '', title: 'Fecha Pago Parcial', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'orpa2', tipo: 'string', nullable: true, llave: '', etiqueta: 'ORPA 02', placeholder: 'ORPA', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
                {campo: 'fecpagofinal', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Pago Final', placeholder: '', title: 'Fecha Pago Final', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},                
                {campo: 'quipu', tipo: 'string', nullable: true, llave: '', etiqueta: 'QUIPU', placeholder: 'QUIPU', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null}
            ]
        ];

        this.CampoLlave = 'id_designacion';
        this.Nombre = 'Publicaciones_Designacion';
        this.ControllerName = 'Publicaciones_Designacion';
        this.MethodGet = 'GetPublicaciones_DesignacionByPublicacion';
        this.MethodUpdate = 'UpdatePublicaciones_Designacion';
        this.MethodInsert = 'InsertPublicaciones_Designacion';
        this.ParamGetName1 = 'id_crearpublicacion';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ObjDatos = null;
        this.FormEdicion = 'formPublicacionDiagramacionDesignacion';
        this.IsModal = false;
        this.DatosNullEdicion = true;
        this.SufijoNombreControl = '';

}