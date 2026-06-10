function Propuestas_cobertura () {
    
        
    this.Campos = [
        {campo: 'id_cobertura', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'nmcobertura', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
        
                    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_cobertura', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'nmcobertura', tipo: 'string', nullable: false, llave: '', etiqueta: 'Cobertura', placeholder: 'Cobertura', title: '', numcols: 12, maxlength: 50, funconchange: null, funconclick: null},
        ]
     
    ];

    this.CampoLlave = 'id_cobertura';
    this.Nombre = 'Propuesta_Cobertura';
    this.ControllerName = 'Propuesta_Cobertura';
    this.MethodGet = 'GetPropuesta_CoberturaDetails';
    this.MethodUpdate = 'UpdatePropuesta_Cobertura';
    this.MethodInsert = 'InsertPropuesta_Cobertura';
    this.MethodValidarDuplicado = 'GetPropuesta_CoberturaNombre';
    this.ParamGetName1 = 'id_cobertura';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nmcobertura';
    this.ObjDatos = null;
    this.FormEdicion = 'formPropuestas_coberturaDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;

}