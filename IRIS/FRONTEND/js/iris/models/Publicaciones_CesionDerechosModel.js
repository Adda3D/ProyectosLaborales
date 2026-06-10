function Publicaciones_CesionDerechos() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_cesionderechos', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
            {campo: 'firmaautores', tipo: 'bool', nullable: false, llave: ''},
            {campo: 'firmadecano', tipo: 'bool', nullable: false, llave: ''},
            {campo: 'licrepro', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSiNoNoAplicaSelect, loadnulo: true},
            {campo: 'licrepo', tipo: 'bool', nullable: false, llave: ''},
            {campo: 'estado', tipo: 'string', nullable: true, llave: ''},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            {campo: 'enlacesdrive', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CampoLlave = 'id_cesionderechos';
        this.Nombre = 'Publicaciones_CesionDerechos';
        this.ControllerName = 'Publicaciones_CesionDerechos';
        this.MethodGet = 'GetPublicaciones_CesionDerechosByPublicacion';
        this.MethodUpdate = 'UpdatePublicaciones_CesionDerechos';
        this.MethodInsert = 'InsertPublicaciones_CesionDerechos';
        this.ParamGetName1 = 'id_crearpublicacion';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ObjDatos = null;
        this.FormEdicion = 'formPublicacionEdicionCesionDerechos';
        this.IsModal = false;
        this.DatosNullEdicion = true;

    //}
}