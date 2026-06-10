function Decvie_MatryoshkaIndicadorEstrategico () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaindicadorestrategico', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'id_indicadoresestrategicos', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_PlanAccionIndicadoresEstrategicosSelect, loadnulo: false},
        //    {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivosPgdVriSedeSelect, loadnulo: false},           
        //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},                    
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaindicadorestrategico', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_indicadoresestrategicos', tipo: 'select', nullable: false, llave: '', etiqueta: 'Indicador Estratégico', placeholder: '', title: '', numcols: 5, funconchange: null, funconclick: null},
            //    {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},               
            //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 7, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaindicadorestrategico';
        this.Nombre = 'Decvie_MatryoshkaIndicadorEstrategico';
        this.ControllerName = 'Decvie_MatryoshkaIndicadorEstrategico';
        this.MethodGet = 'GetDecvie_MatryoshkaIndicadorEstrategicoDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaIndicadorEstrategico';
        this.MethodInsert = 'InsertDecvie_MatryoshkaIndicadorEstrategico';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaIndicadorEstrategicoNumero';
        this.ParamGetName1 = 'id_matryoshkaindicadorestrategico';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaIndicadorEstrategicoDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}