function Decvie_MatryoshkaActividadDep () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkaactividaddep', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'id_matryoshkametadep', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvie_MatryoshkaMetaDepSelect, loadnulo: false},
            {campo: 'id_actividades', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionActividadesSelect, loadnulo: false},
        //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkaactividaddep', tipo: 'string', nullable: false, llave: 'primary'},
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_matryoshkametadep', tipo: 'select', nullable: false, llave: '', etiqueta: 'Meta', placeholder: '', title: '', numcols: 6, funconchange: null, funconclick: null},
                {campo: 'id_actividades', tipo: 'select', nullable: false, llave: '', etiqueta: 'Actividad', placeholder: '', title: '', numcols: 6, funconchange: null, funconclick: null},               
            //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 12, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkaactividaddep';
        this.Nombre = 'Decvie_MatryoshkaActividadDep';
        this.ControllerName = 'Decvie_MatryoshkaActividadDep';
        this.MethodGet = 'GetDecvie_MatryoshkaActividadDepDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaActividadDep';
        this.MethodInsert = 'InsertDecvie_MatryoshkaActividadDep';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaActividadDepNumero';
        this.ParamGetName1 = 'id_matryoshkaactividaddep';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaActividadDepDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}