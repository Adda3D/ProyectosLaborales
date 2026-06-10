function Convocatoria_FuenteCnv () {
    
        
    this.Campos = [
        {campo: 'id_fuentecnv', tipo: 'string', nullable: false, llave: 'primary'},            
        {campo: 'nmfuentecnv', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
        {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_fuentecnv', tipo: 'string', nullable: true, llave: 'primary'},                
            {campo: 'nmfuentecnv', tipo: 'string', nullable: false, llave: '', etiqueta: 'Fuente CNV', placeholder: 'Fuente CNV', title: '', numcols: 2, maxlength: 250, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 3, maxlength: 500, funconchange: null, funconclick: null}
        ]
     
    ];

    this.CampoLlave = 'id_fuentecnv';
    this.Nombre = 'Convocatoria_FuenteCnv';
    this.ControllerName = 'Convocatoria_FuenteCnv';
    this.MethodGet = 'GetConvocatoria_FuenteCnvDetails';
    this.MethodUpdate = 'UpdateConvocatoria_FuenteCnv';
    this.MethodInsert = 'InsertConvocatoria_FuenteCnv';
    this.MethodValidarDuplicado = 'GetConvocatoria_FuenteCnvNombre';
    this.ParamGetName1 = 'id_fuentecnv';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nmfuentecnv';
    this.ObjDatos = null;
    this.FormEdicion = 'formConvocatoria_FuenteCnvDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;

}