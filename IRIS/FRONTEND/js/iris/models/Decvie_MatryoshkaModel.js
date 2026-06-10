function Decvie_Matryoshka () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},            
            {campo: 'alcance', tipo: 'string', nullable: false, llave: ''},            
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            

        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'primary'},
                {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},                
                {campo: 'alcance', tipo: 'string', nullable: false, llave: '', etiqueta: 'Alcance', placeholder: 'Alcance', title: '', numcols: 4, maxlength: 50, funconchange: null, funconclick: null},                
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null}
            ],
            
            
            
            
        ];

        this.CampoLlave = 'id_matryoska';
        this.Nombre = 'Decvie_Matryoshka';
        this.ControllerName = 'Decvie_Matryoshka';
        this.MethodGet = 'GetDecvie_MatryoshkaDetails';
        this.MethodUpdate = 'UpdateDecvie_Matryoshka';
        this.MethodInsert = 'InsertDecvie_Matryoshka';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaNumero';
        this.ParamGetName1 = 'id_matryoska';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}