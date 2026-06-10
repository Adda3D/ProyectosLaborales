function Decvie_MatryoshkaEstrategia () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaestrategia', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},            
        //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},                    
            {campo: 'estrategia', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaestrategia', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},                
            //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'estrategia', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Estrategia', placeholder: 'Estrategia', title: '', numcols: 12, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaestrategia';
        this.Nombre = 'Decvie_MatryoshkaEstrategia';
        this.ControllerName = 'Decvie_MatryoshkaEstrategia';
        this.MethodGet = 'GetDecvie_MatryoshkaEstrategiaDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaEstrategia';
        this.MethodInsert = 'InsertDecvie_MatryoshkaEstrategia';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaEstrategiaNumero';
        this.ParamGetName1 = 'id_matryoshkaestrategia';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaEstrategiaDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}