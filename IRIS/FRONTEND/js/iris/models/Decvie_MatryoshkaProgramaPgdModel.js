function Decvie_MatryoshkaProgramaPgd () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaprogramapgd', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},            
            {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},                    
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaprogramapgd', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},                
                {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaprogramapgd';
        this.Nombre = 'Decvie_MatryoshkaProgramaPgd';
        this.ControllerName = 'Decvie_MatryoshkaProgramaPgd';
        this.MethodGet = 'GetDecvie_MatryoshkaProgramaPgdDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaProgramaPgd';
        this.MethodInsert = 'InsertDecvie_MatryoshkaProgramaPgd';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaProgramaPgdNumero';
        this.ParamGetName1 = 'id_matryoshkaprogramapgd';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaProgramaPgdDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}