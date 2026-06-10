function Convocatoria_RequerimientoRequisito () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_requisito', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'nmrequisito', tipo: 'string', nullable: true, llave: '', allowduplicate: false},
            {campo: 'descripcionrequisito', tipo: 'string', nullable: true, llave: ''},
            {campo: 'linkdocumento', tipo: 'string', nullable: true, llave: ''},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_requisito', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'foreign'},                
                {campo: 'nmrequisito', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Nombre Requisito', placeholder: 'Nombre Requisito', title: '', numcols: 3, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null},                
                {campo: 'descripcionrequisito', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Descripción Requisito', placeholder: 'Descripción Requisito', title: '', numcols: 3, numrows: 2, maxlength: 5000, funconchange: null, funconclick: null},                
                {campo: 'linkdocumento', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Link Documentos', placeholder: 'Link Documentos', title: '', numcols: 3, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 3, numrows: 2, maxlength: 5000, funconchange: null, funconclick: null}
            ]            
                                    
        ];

        this.CampoLlave = 'id_requisito';
        this.Nombre = 'Convocatoria_RequerimientoRequisito';
        this.ControllerName = 'Convocatoria_RequerimientoRequisito';
        this.MethodGet = 'GetConvocatoria_RequerimientoRequisitoDetails';
        this.MethodUpdate = 'UpdateConvocatoria_RequerimientoRequisito';
        this.MethodInsert = 'InsertConvocatoria_RequerimientoRequisito';
        this.MethodValidarDuplicado = 'GetConvocatoria_RequerimientoRequisitoNombre';
        this.ParamGetName1 = 'id_requisito';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nmrequisito';
        this.ObjDatos = null;
        this.FormEdicion = 'formConvocatoria_RequerimientoRequisitoDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}