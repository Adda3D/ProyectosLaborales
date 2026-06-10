function DecVie_CuerposColegiados() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_cuerposcolegiados', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'ano', tipo: 'date', nullable: false, llave: ''},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},
            {campo: 'numacta', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMacroprocesoSelect, loadnulo: true},
            {campo: 'decisionrecomendacion', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},
            {campo: 'chasqui', tipo: 'string', nullable: true, llave: ''},
            {campo: 'numconsecutivosecretaria', tipo: 'string', nullable: true, llave: ''},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            {campo: 'url', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_colegiado', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_ColegiadosSelect, loadnulo: true},            
        ];

        this.CampoLlave = 'id_cuerposcolegiados';
        this.Nombre = 'DecVie_CuerposColegiados';
        this.ControllerName = 'DecVie_CuerposColegiados';
        this.MethodGet = 'GetDecVie_CuerposColegiadosDetails';
        this.MethodUpdate = 'UpdateDecVie_CuerposColegiados';
        this.MethodInsert = 'InsertDecVie_CuerposColegiados';
        this.MethodDelete = 'DeleteDecVie_CuerposColegiados';
        this.MethodValidarDuplicado = 'GetDecVie_CuerposColegiadosNumero';
        this.ParamGetName1 = 'id_cuerposcolegiados';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDeleteName = 'id_cuerposcolegiados';
        this.ParamDuplicadoName = 'cd_numacta';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_CuerposColegiadosDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = false;

    //}
}