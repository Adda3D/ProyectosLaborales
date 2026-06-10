function Decvie_MatryoshkaObjetivoDep () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaobjetivodep', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'id_objetivodependencia', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivoDependenciaSelect, loadnulo: false},
        //    {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivosPgdVriSedeSelect, loadnulo: false},           
        //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},                    
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaobjetivodep', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_objetivodependencia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo', placeholder: '', title: '', numcols: 5, funconchange: null, funconclick: null},
            //    {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo', placeholder: '', title: '', numcols: 3, funconchange: null, funconclick: null},               
            //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 7, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaobjetivodep';
        this.Nombre = 'Decvie_MatryoshkaObjetivoDep';
        this.ControllerName = 'Decvie_MatryoshkaObjetivoDep';
        this.MethodGet = 'GetDecvie_MatryoshkaObjetivoDepDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaObjetivoDep';
        this.MethodInsert = 'InsertDecvie_MatryoshkaObjetivoDep';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaObjetivoDepNumero';
        this.ParamGetName1 = 'id_matryoshkaobjetivodep';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaObjetivoDepDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}