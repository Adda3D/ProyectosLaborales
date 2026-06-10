function DecVie_Colegiados() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_colegiado', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'nmcolegiado', tipo: 'string', nullable: false, llave: '', allowduplicate: false},            
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},            
        ];

        this.CampoLlave = 'id_colegiado';
        this.Nombre = 'DecVie_Colegiados';
        this.ControllerName = 'DecVie_Colegiados';
        this.MethodGet = 'GetDecVie_ColegiadosDetails';
        this.MethodUpdate = 'UpdateDecVie_Colegiados';
        this.MethodInsert = 'InsertDecVie_Colegiados';
        this.MethodDelete = 'DeleteDecVie_Colegiados';
        this.MethodValidarDuplicado = 'GetDecVie_ColegiadosNombre';
        this.ParamGetName1 = 'id_colegiado';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDeleteName = 'id_colegiado';
        this.ParamDuplicadoName = 'cd_nmcolegiado';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_Colegiados';
        this.IsModal = true;
        this.DatosNullEdicion = false;

    //}
}