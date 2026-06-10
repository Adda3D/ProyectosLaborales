function Convocatoria_EstadoCnv () {
    
        
    this.Campos = [
        {campo: 'id_estadocnv', tipo: 'string', nullable: false, llave: 'primary'},            
        {campo: 'nmestadocnv', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
        {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_estadocnv', tipo: 'string', nullable: true, llave: 'primary'},                
            {campo: 'nmestadocnv', tipo: 'string', nullable: false, llave: '', etiqueta: 'Estado CNV', placeholder: 'Estado CNV', title: '', numcols: 2, maxlength: 250, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 3, maxlength: 500, funconchange: null, funconclick: null}
        ]
     
    ];

    this.CampoLlave = 'id_estadocnv';
    this.Nombre = 'Convocatoria_EstadoCnv';
    this.ControllerName = 'Convocatoria_EstadoCnv';
    this.MethodGet = 'GetConvocatoria_EstadoCnvDetails';
    this.MethodUpdate = 'UpdateConvocatoria_EstadoCnv';
    this.MethodInsert = 'InsertConvocatoria_EstadoCnv';
    this.MethodValidarDuplicado = 'GetConvocatoria_EstadoCnvNombre';
    this.ParamGetName1 = 'id_estadocnv';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nmestadocnv';
    this.ObjDatos = null;
    this.FormEdicion = 'formConvocatoria_EstadoCnvDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;

}