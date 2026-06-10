function Decvie_MatryoshkaObjetivoPgd () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaobjetivopgd', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'id_matryoshkaestrategia', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvie_MatryoshkaEstrategiaSelect, loadnulo: false},
            {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivosPgdVriSedeSelect, loadnulo: false},           
        //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},                    
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaobjetivopgd', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_matryoshkaestrategia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estrategia', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},
                {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},               
            //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'observaciones', placeholder: 'observaciones', title: '', numcols: 6, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaobjetivopgd';
        this.Nombre = 'Decvie_MatryoshkaObjetivoPgd';
        this.ControllerName = 'Decvie_MatryoshkaObjetivoPgd';
        this.MethodGet = 'GetDecvie_MatryoshkaObjetivoPgdDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaObjetivoPgd';
        this.MethodInsert = 'InsertDecvie_MatryoshkaObjetivoPgd';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaObjetivoPgdNumero';
        this.ParamGetName1 = 'id_matryoshkaobjetivopgd';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaObjetivoPgdDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}