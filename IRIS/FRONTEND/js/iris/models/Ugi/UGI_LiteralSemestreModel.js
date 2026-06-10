function UGI_LiteralSemestre () {
    
        
    this.Campos = [
        {campo: 'id_ugiliteralsemestre', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_ugisemestre', tipo: 'string', nullable: false, llave: 'foreign'},
     // {campo: 'id_ugisemestre', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSemestreSelect, loadnulo: false},
        {campo: 'id_literal', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadLiteral_UGI, loadnulo: false},                  
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_ugiliteralsemestre', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_ugisemestre', tipo: 'string', nullable: true, llave: 'foreign'},
        //  {campo: 'id_ugisemestre', tipo: 'select', nullable: false, llave: '', etiqueta: 'Semestre', placeholder: 'Semestre', title: '', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'id_literal', tipo: 'select', nullable: false, llave: '', etiqueta: 'Literal', placeholder: 'Literal', title: '', numcols: 4, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 8, maxlength: 500, funconchange: null, funconclick: null}
           
        ]
    ];

    this.CampoLlave = 'id_ugiliteralsemestre';
    this.Nombre = 'UGI_LiteralSemestre';
    this.ControllerName = 'UGI_LiteralSemestre';
    this.MethodGet = 'GetUGI_LiteralSemestreDetails';
    this.MethodUpdate = 'UpdateUGI_LiteralSemestre';
    this.MethodInsert = 'InsertUGI_LiteralSemestre';
    //this.MethodValidarDuplicado = 'GetDecVie_InventarioGestionConocimientoNumero';
    this.ParamGetName1 = 'id_ugiliteralsemestre';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_numradicacion';
    this.ObjDatos = null;
    this.FormEdicion = 'formUGILiteralSemestreDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;


}