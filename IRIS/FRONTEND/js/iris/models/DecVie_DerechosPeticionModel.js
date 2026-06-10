function DecVie_DerechosPeticion() {
    
        
        this.Campos = [
            {campo: 'id_derechopeticion', tipo: 'string', nullable: false, llave: 'primary'},   
            {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},         
            {campo: 'id_origensolicitud', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_OrigenSolicitud, loadnulo: true},
            {campo: 'numradicacion', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'id_instancia', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_Instancias, loadnulo: true},
            {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMacroprocesoSelect, loadnulo: true},
            {campo: 'identificacionsolicitante', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},
            {campo: 'solicitud', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_oficina', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadOficinaDecVieSelect, loadnulo: true},
            {campo: 'fecrespuesta', tipo: 'date', nullable: true, llave: ''},
            {campo: 'numconsecutivoresp', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_estadoderpet', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadEstadoDerechoPeticionSelect, loadnulo: true},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_tipopersona', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadTipoPersonaSelect, loadnulo: true},
            {campo: 'nombreresponsable', tipo: 'string', nullable: true, llave: ''}           
        ];

        this.CamposHTML = [
            [
                {campo: 'id_derechopeticion', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'fecha', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha', placeholder: '', title: 'Fecha Registro', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'id_origensolicitud', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Recepción', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'numradicacion', tipo: 'string', nullable: false, llave: '', etiqueta: 'No. Radicación', placeholder: 'No. Radicación', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'id_instancia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Instancia', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'identificacionsolicitante', tipo: 'string', nullable: false, llave: '', etiqueta: 'Identificación Solicitante', placeholder: 'Identificación Solicitante', title: '', numcols: 2, maxlength: 15, funconchange: null, funconclick: null},
                {campo: 'nombreresponsable', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Solicitante', placeholder: 'Nombre Solicitante', title: '', numcols: 2, maxlength: 100, funconchange: null, funconclick: null}
            ],
            [                    
                {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', etiqueta: 'Macroproceso', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_tipopersona', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Usuario', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', etiqueta: 'Dependencia', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'solicitud', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Solicitud', placeholder: 'Solicitud', title: '', numcols: 2, numrows: 3, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'id_oficina', tipo: 'select', nullable: false, llave: '', etiqueta: 'Reparto', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'fecrespuesta', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Respuesta', placeholder: '', title: 'Fecha Respuesta', numcols: 2, maxlength: 0, funconchange: null, funconclick: null}
            ],
            [                
                {campo: 'numconsecutivoresp', tipo: 'string', nullable: true, llave: '', etiqueta: 'Oficio Respuesta', placeholder: 'Oficio Respuesta', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},                
                {campo: 'id_estadoderpet', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado', placeholder: 'Estado', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 3, maxlength: 500, funconchange: null, funconclick: null}
            ]
        ];

        this.CampoLlave = 'id_derechopeticion';
        this.Nombre = 'DecVie_DerechosPeticion';
        this.ControllerName = 'DecVie_DerechosPeticion';
        this.MethodGet = 'GetDecVie_DerechosPeticionDetails';
        this.MethodUpdate = 'UpdateDecVie_DerechosPeticion';
        this.MethodInsert = 'InsertDecVie_DerechosPeticion';
        this.MethodValidarDuplicado = 'GetDecVie_DerechosPeticionNumero';
        this.ParamGetName1 = 'id_derechopeticion';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_DerechosPeticionDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;
    
}