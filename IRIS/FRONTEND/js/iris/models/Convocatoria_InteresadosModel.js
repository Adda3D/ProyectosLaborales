function Convocatoria_Interesados () {
            
        this.Campos = [
            {campo: 'id_interesados', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'nombreinteresado', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'correointeresado', tipo: 'string', nullable: false, llave: ''},
            {campo: 'idhermes', tipo: 'int', nullable: true, llave: ''},
            {campo: 'fechainteres', tipo: 'date', nullable: false, llave: ''},
            {campo: 'diascierre', tipo: 'date', nullable: true, llave: ''},
            {campo: 'fecenviocorreo', tipo: 'date', nullable: true, llave: ''},
            {campo: 'consecutivocorreo', tipo: 'string', nullable: false, llave: ''}                        
        ];

        this.CamposHTML = [
            [
                {campo: 'id_interesados', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'nombreinteresado', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Interesado', placeholder: 'Nombre Interesado', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'correointeresado', tipo: 'string', nullable: false, llave: '', etiqueta: 'Correo Interesado', placeholder: 'Correo Interesado', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'idhermes', tipo: 'int', nullable: true, llave: '', etiqueta: 'IdHermes (si aplica)', placeholder: 'IdHermes (si aplica)', title: '', numcols: 4, maxlength: 12, funconchange: null, funconclick: null}
            ],
            [
                {campo: 'fechainteres', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Interés', placeholder: '', title: 'Fecha Interés', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'diascierre', tipo: 'date', nullable: true, llave: '', etiqueta: 'Día Cierre', placeholder: '', title: 'Día Cierre', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'fecenviocorreo', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Envío Correo', placeholder: '', title: 'Fecha Envío Correo', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'consecutivocorreo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Consecutivo Correo', placeholder: 'Consecutivo Correo', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null}
            ]            
                                    
        ];

        this.CampoLlave = 'id_interesados';
        this.Nombre = 'Convocatoria_Interesados';
        this.ControllerName = 'Convocatoria_Interesados';
        this.MethodGet = 'GetConvocatoria_InteresadosDetails';
        this.MethodUpdate = 'UpdateConvocatoria_Interesados';
        this.MethodInsert = 'InsertConvocatoria_Interesados';
        this.MethodValidarDuplicado = 'GetConvocatoria_InteresadosNombre';
        this.ParamGetName1 = 'id_interesados';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nombreinteresado';
        this.ObjDatos = null;
        this.FormEdicion = 'formConvocatoria_InteresadosDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

}