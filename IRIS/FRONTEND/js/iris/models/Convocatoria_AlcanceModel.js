function Convocatoria_Alcance () {
    
        
        this.Campos = [
            {campo: 'id_alcance', tipo: 'string', nullable: false, llave: 'primary'},            
            {campo: 'nmalcance', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_alcance', tipo: 'string', nullable: true, llave: 'primary'},                
                {campo: 'nmalcance', tipo: 'string', nullable: false, llave: '', etiqueta: 'Alcance', placeholder: 'Alcance', title: '', numcols: 2, maxlength: 250, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 3, maxlength: 500, funconchange: null, funconclick: null}
            ]
         
        ];

        this.CampoLlave = 'id_alcance';
        this.Nombre = 'Convocatoria_Alcance';
        this.ControllerName = 'Convocatoria_Alcance';
        this.MethodGet = 'GetConvocatoria_AlcanceDetails';
        this.MethodUpdate = 'UpdateConvocatoria_Alcance';
        this.MethodInsert = 'InsertConvocatoria_Alcance';
        this.MethodValidarDuplicado = 'GetConvocatoria_AlcanceNombre';
        this.ParamGetName1 = 'id_alcance';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nmalcance';
        this.ObjDatos = null;
        this.FormEdicion = 'formConvocatoria_AlcanceDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

}