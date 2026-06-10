function Investigacion_EstadoProyecto () {
    
        
    this.Campos = [
        {campo: 'id_estado', tipo: 'string', nullable: false, llave: 'primary'},        
        {campo: 'nmestado', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
        
                    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_estado', tipo: 'string', nullable: true, llave: 'primary'},            
            {campo: 'nmestado', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre del Estado', placeholder: 'Nombre del Estado', title: '', numcols: 12, maxlength: 50, funconchange: null, funconclick: null},
        ]
     
    ];

    this.CampoLlave = 'id_estado';
    this.Nombre = 'Investigacion_EstadoProyecto';
    this.ControllerName = 'Investigacion_EstadoProyecto';
    this.MethodGet = 'GetInvestigacion_EstadoProyectoDetails';
    this.MethodUpdate = 'UpdateInvestigacion_EstadoProyecto';
    this.MethodInsert = 'InsertInvestigacion_EstadoProyecto';
    this.MethodValidarDuplicado = 'GetInvestigacion_EstadoProyectoNombre';
    this.ParamGetName1 = 'id_estado';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nmestado';
    this.ObjDatos = null;
    this.FormEdicion = 'formInvestigacion_EstadoProyectoDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;

}