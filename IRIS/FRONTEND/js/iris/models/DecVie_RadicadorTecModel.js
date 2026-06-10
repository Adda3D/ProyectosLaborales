
function DecVie_RadicadorTec() {
    this.Campos = [
        { campo: 'id_decvieradicadortec', tipo: 'string', nullable: false, llave: 'primary' },
        { campo: 'id_prefijoconsecutivo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadCorrespondencia_PrefijoConsecutivoSelect, loadnulo: true },
        //{campo: 'id_prefijoradicadortec', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadCorrespondencia_PrefijoRadicadorTecSelect, loadnulo: true},
        { campo: 'numradicadortec', tipo: 'string', nullable: true, llave: '', allowduplicate: false },
        { campo: 'tsersubserdocu', tipo: 'string', nullable: true, llave: '' },
        { campo: 'asunto', tipo: 'string', nullable: true, llave: '' },
        { campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true },
        { campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true },
        { campo: 'interno', tipo: 'bool', nullable: false, llave: '' },
        { campo: 'externo', tipo: 'bool', nullable: false, llave: '' },
        { campo: 'id_decvieconcepto', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvieconceptoRadicador, loadnulo: true },
        { campo: 'nfolios', tipo: 'int', nullable: false, llave: '', etiqueta: 'No. Folios', placeholder: '', title: 'No. Folios', numcols: 2, minimo: 0, funconchange: null, funconclick: null },
        { campo: 'otroasunto', tipo: 'string', nullable: true, llave: '' },
        { campo: 'dni', tipo: 'string', nullable: true, llave: '' },
        { campo: 'personasrelacionadas', tipo: 'string', nullable: true, llave: '' },
        // { campo: 'dirigidoa', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true },
        { campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvieEstadoRadicador, loadnulo: true },
        //{campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMacroprocesoSelect, loadnulo: true},
        { campo: 'observaciones', tipo: 'string', nullable: true, llave: '' },
        { campo: 'fecha', tipo: 'datetime', nullable: false, llave: '' },
        { campo: 'recibido_dependencia', tipo: 'date', nullable: false, llave: '' },
        { campo: 'fecha_vencimiento', tipo: 'date', nullable: false, llave: '' },
        { campo: 'fecha_respuesta', tipo: 'date', nullable: false, llave: '' },
        { campo: 'dependenciadestino', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true },
    ];

    this.CampoLlave = 'id_decvieradicadortec';
    this.Nombre = 'DecVie_RadicadorTec';
    this.ControllerName = 'DecVie_RadicadorTec';
    this.MethodGet = 'GetDecVie_RadicadorTecDetails';
    this.MethodUpdate = 'UpdateDecVie_RadicadorTec_Data';
    this.MethodInsert = 'InsertDecVie_RadicadorTec_Data';
    this.MethodDelete = 'DeleteDecVie_RadicadorTec';
    this.MethodValidarDuplicado = 'GetDecVie_RadicadorTecNumero';
    this.ParamGetName1 = 'id_decvieradicadortec';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDeleteName = 'id_decvieradicadortec';
    this.ParamDuplicadoName = 'cd_numradicadortec';
    this.ObjDatos = null;
    this.FormEdicion = 'formDecVie_RadicadorTecDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = false;
}
