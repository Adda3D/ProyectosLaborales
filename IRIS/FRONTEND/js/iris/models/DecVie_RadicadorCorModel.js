function DecVie_RadicadorCor() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_radicadorcor', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'ogdchasqui', tipo: 'string', nullable: true, llave: ''},
            {campo: 'fecradicacion', tipo: 'date', nullable: false, llave: ''},
            {campo: 'id_origensolicitud', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_OrigenSolicitud, loadnulo: true},
            {campo: 'id_instancia', tipo: 'select', nullable: false, llave: '', funcloadselect:LoadDecVie_Instancias, loadnulo: true},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            //{campo: 'identificacionsolicitante', tipo: 'string', nullable: true, llave: ''},
            {campo: 'numerodocumento', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'fecdocumento', tipo: 'date', nullable: false, llave: ''},
            {campo: 'id_alcancesolicitud', tipo: 'select', nullable: false, llave: '', funcloadselect:LoadDecVie_AlcanceSolicitud, loadnulo: true},
            {campo: 'id_decviemacroproceso', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadMacroprocesoSelect, loadnulo: true},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},
            {campo: 'unidadproductora', tipo: 'select', nullable: false, llave: '', funcloadselect:LoadunidadproductoraDecVie_RadicadorCorSelect, loadnulo: true},
            {campo: 'id_decvieestado', tipo: 'select', nullable: false, llave: '', funcloadselect:LoadDecVie_Estado, loadnulo: true},
            {campo: 'consecutivorespuesta', tipo: 'string', nullable: true, llave: ''},
            {campo: 'archivorespuesta', tipo: 'string', nullable: true, llave: ''},
            
        ];

        this.CampoLlave = 'id_radicadorcor';
        this.Nombre = 'DecVie_RadicadorCor';
        this.ControllerName = 'DecVie_RadicadorCor';
        this.MethodGet = 'GetDecVie_RadicadorCorDetails';
        this.MethodUpdate = 'UpdateDecVie_RadicadorCor';
        this.MethodInsert = 'InsertDecVie_RadicadorCor';
        this.MethodDelete = 'DeleteDecVie_RadicadorCor';
        this.MethodValidarDuplicado = 'GetDecVie_RadicadorCorNombre';
        this.ParamGetName1 = 'id_radicadorcor';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDeleteName = 'id_radicadorcor';
        this.ParamDuplicadoName = 'cd_numerodocumento';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_RadicadorCorDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = false;

    //}
}