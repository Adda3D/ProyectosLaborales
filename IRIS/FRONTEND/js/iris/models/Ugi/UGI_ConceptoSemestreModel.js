function UGI_ConceptoSemestre () {
    
        
    this.Campos = [
        {campo: 'id_ugiconceptosemestre', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_ugisemestre', tipo: 'string', nullable: false, llave: 'foreign'},
        {campo: 'id_ugiliteralsemestre', tipo: 'string', nullable: false, llave: 'foreign'},        
        {campo: 'id_conceptougi', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadConcepto_UGISelect, loadnulo: false},
        {campo: 'valorproyectado', tipo: 'int', nullable: false, llave: ''},               
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        
    ];

    this.CamposHTML = [
        [
            {campo: 'id_ugiconceptosemestre', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_ugisemestre', tipo: 'string', nullable: true, llave: 'foreign'},
            {campo: 'id_ugiliteralsemestre', tipo: 'string', nullable: true, llave: 'foreign'},
            {campo: 'id_conceptougi', tipo: 'select', nullable: false, llave: '', etiqueta: 'Concepto', placeholder: 'Concepto', title: '', numcols: 4, funconchange: null, funconclick: null},
            {campo: 'valorproyectado', tipo: 'int', nullable: true, llave: '', etiqueta: 'Valor Proyectado', placeholder: 'Valor Proyectado', title: '', numcols: 4, maxlength: 12, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null}
           
        ]
    ];

    this.CampoLlave = 'id_ugiconceptosemestre';
    this.Nombre = 'UGI_ConceptoSemestre';
    this.ControllerName = 'UGI_ConceptoSemestre';
    this.MethodGet = 'GetUGI_ConceptoSemestreDetails';
    this.MethodUpdate = 'UpdateUGI_ConceptoSemestre';
    this.MethodInsert = 'InsertUGI_ConceptoSemestre';
    //this.MethodValidarDuplicado = 'GetDecVie_InventarioGestionConocimientoNumero';
    this.ParamGetName1 = 'id_ugiconceptosemestre';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    //this.ParamDuplicadoName = 'cd_numradicacion';
    this.ObjDatos = null;
    this.FormEdicion = 'formUGIConceptoSemestreDetalle';
    this.IsModal = true;
    this.DatosNullEdicion = true;


}