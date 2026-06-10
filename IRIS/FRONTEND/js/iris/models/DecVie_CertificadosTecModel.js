function DecVie_CertificadosTec() {
    this.Campos = [
        { campo: 'id_decviecertificadostec', tipo: 'string', nullable: false, llave: 'primary' },
        { campo: 'id_prefijoconsecutivo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadCorrespondencia_PrefijoConsecutivoSelect, loadnulo: true },
        { campo: 'numcertificadotec', tipo: 'string', nullable: true, llave: '', allowduplicate: false },
        { campo: 'tsersubserdocu', tipo: 'string', nullable: true, llave: '' },
        { campo: 'asunto', tipo: 'string', nullable: true, llave: '' },
        { campo: 'idfuncionario', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true },
        { campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true },
        { campo: 'id_certificado_tipo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvieTipoCertificado, loadnulo: true }, // Nuevo campo para Tipo
        { campo: 'tipo', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvieTipo, loadnulo: true }, // Nuevo campo para Tipo
        { campo: 'estado_pago', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvieEstadoPago, loadnulo: true }, // Nuevo campo para Estado Pago
        { campo: 'dni', tipo: 'string', nullable: true, llave: '' },
        { campo: 'observaciones', tipo: 'string', nullable: true, llave: '' },
        { campo: 'fecha', tipo: 'datetime', nullable: false, llave: '' },
        { campo: 'recibido_dependencia', tipo: 'date', nullable: false, llave: '' }
    ];

    this.CampoLlave = 'id_decviecertificadostec';
    this.Nombre = 'DecVie_CertificadosTec';
    this.ControllerName = 'DecVie_CertificadosTec';
    this.MethodGet = 'GetDecVie_CertificadosTecDetails';
    this.MethodUpdate = 'UpdateDecVie_CertificadosTec_Data';
    this.MethodInsert = 'InsertDecVie_CertificadosTec_Data';
    this.MethodDelete = 'DeleteDecVie_CertificadosTec';
    this.MethodValidarDuplicado = 'GetDecVie_CertificadosTecNumero';
    this.ParamGetName1 = 'id_decviecertificadostec';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDeleteName = 'id_decviecertificadostec';
    this.ParamDuplicadoName = 'cd_numcertificadotec';
    this.ObjDatos = null;
    this.FormEdicion = 'formDecVie_CertificadosTecDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = false;
}
