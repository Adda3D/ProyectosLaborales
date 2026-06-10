function Decvie_MatryoshkaEjeEstrategico () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaejeestrategico', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},            
            {campo: 'id_ejeestrategico', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionEjeEstrategicoSelect, loadnulo: false},                    
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaejeestrategico', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},                
                {campo: 'id_ejeestrategico', tipo: 'select', nullable: false, llave: '', etiqueta: 'Eje Estratégico', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaejeestrategico';
        this.Nombre = 'Decvie_MatryoshkaEjeEstrategico';
        this.ControllerName = 'Decvie_MatryoshkaEjeEstrategico';
        this.MethodGet = 'GetDecvie_MatryoshkaEjeEstrategicoDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaEjeEstrategico';
        this.MethodInsert = 'InsertDecvie_MatryoshkaEjeEstrategico';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaEjeEstrategicoNumero';
        this.ParamGetName1 = 'id_matryoshkaejeestrategico';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaEjeEstrategicoDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}