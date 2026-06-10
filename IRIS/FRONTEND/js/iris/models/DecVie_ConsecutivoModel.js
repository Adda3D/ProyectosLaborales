function DecVie_Consecutivo() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_decvieconsecutivo', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_prefijoconsecutivo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadCorrespondencia_PrefijoConsecutivoSelect, loadnulo: true},
            {campo: 'numconsecutivo', tipo: 'string', nullable: true, llave: '', allowduplicate: false},
            {campo: 'tsersubserdocu', tipo: 'string', nullable: true, llave: ''},
            {campo: 'asunto', tipo: 'string', nullable: true, llave: ''},
            {campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},
            {campo: 'interno', tipo: 'bool', nullable: false, llave: ''},
            {campo: 'externo', tipo: 'bool', nullable: false, llave: ''},
            {campo: 'id_decvieconcepto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvieconcepto, loadnulo: true},
            {campo: 'dirigidoa', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
            {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMacroprocesoSelect, loadnulo: true},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            {campo: 'fecha', tipo: 'date', nullable: false, llave: ''},
            {campo: 'dependenciadestino', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},            
        ];

        this.CampoLlave = 'id_decvieconsecutivo';
        this.Nombre = 'DecVie_Consecutivo';
        this.ControllerName = 'DecVie_Consecutivo';
        this.MethodGet = 'GetDecVie_ConsecutivoDetails';
        this.MethodUpdate = 'UpdateDecVie_Consecutivo_Data';
        this.MethodInsert = 'InsertDecVie_Consecutivo_Data';
        this.MethodDelete = 'DeleteDecVie_Consecutivo';
        this.MethodValidarDuplicado = 'GetDecVie_ConsecutivoNumero';
        this.ParamGetName1 = 'id_decvieconsecutivo';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDeleteName = 'id_decvieconsecutivo';
        this.ParamDuplicadoName = 'cd_numconsecutivo';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_ConsecutivoDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = false;

    //}
}