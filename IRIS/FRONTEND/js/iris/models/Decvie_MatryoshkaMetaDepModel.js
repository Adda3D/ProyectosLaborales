function Decvie_MatryoshkaMetaDep () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkametadep', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'id_matryoshkaobjetivodep', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvie_MatryoshkaObjetivoDepSelect, loadnulo: false},
            {campo: 'id_meta', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionMetaSelect, loadnulo: false},
        //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkametadep', tipo: 'string', nullable: false, llave: 'primary'},
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_matryoshkaobjetivodep', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo', placeholder: '', title: '', numcols: 6, funconchange: null, funconclick: null},
                {campo: 'id_meta', tipo: 'select', nullable: false, llave: '', etiqueta: 'Meta', placeholder: '', title: '', numcols: 6, funconchange: null, funconclick: null},               
            //    {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 12, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkametadep';
        this.Nombre = 'Decvie_MatryoshkaMetaDep';
        this.ControllerName = 'Decvie_MatryoshkaMetaDep';
        this.MethodGet = 'GetDecvie_MatryoshkaMetaDepDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaMetaDep';
        this.MethodInsert = 'InsertDecvie_MatryoshkaMetaDep';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaMetaDepNumero';
        this.ParamGetName1 = 'id_matryoshkametadep';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaMetaDepDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}