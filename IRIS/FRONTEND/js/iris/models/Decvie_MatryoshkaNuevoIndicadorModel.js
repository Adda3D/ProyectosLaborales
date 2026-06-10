function Decvie_MatryoshkaNuevoIndicador () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshkanuevoindicador', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'id_matryoshkaobjetivodep', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecvie_MatryoshkaObjetivoDepSelect, loadnulo: false},
            {campo: 'id_nuevosindicadores', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionNuevosIndicadoresSelect, loadnulo: false},           
            {campo: 'id_tipoindicador', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionTipoIndicadorSelect, loadnulo: false},                    
            {campo: 'descripcion', tipo: 'string', nullable: false, llave: ''},
            {campo: 'presupuesto', tipo: 'num', nullable: false, llave: ''},
            {campo: 'ejecucion', tipo: 'string', nullable: false, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshkanuevoindicador', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_matryoska', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'id_matryoshkaobjetivodep', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo Dependencia', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'id_nuevosindicadores', tipo: 'select', nullable: false, llave: '', etiqueta: 'Nuevo Indicador', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},               
                {campo: 'id_tipoindicador', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Indicador', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'descripcion', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción', placeholder: 'Descripción', title: '', numcols: 4, numrows: 2, maxlength: 1000, funconchange: null, funconclick: null},
                {campo: 'presupuesto', tipo: 'num', nullable: false, llave: '', etiqueta: 'Presupuesto', placeholder: 'Presupuesto', title: '', numcols: 4, maxlength: 60, funconchange: null, funconclick: null},
                {campo: 'ejecucion', tipo: 'string', nullable: false, llave: '', etiqueta: 'Ejecución', placeholder: 'Ejecución', title: '', numcols: 4, maxlength: 60, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_matryoshkanuevoindicador';
        this.Nombre = 'Decvie_MatryoshkaNuevoIndicador';
        this.ControllerName = 'Decvie_MatryoshkaNuevoIndicador';
        this.MethodGet = 'GetDecvie_MatryoshkaNuevoIndicadorDetails';
        this.MethodUpdate = 'UpdateDecvie_MatryoshkaNuevoIndicador';
        this.MethodInsert = 'InsertDecvie_MatryoshkaNuevoIndicador';
        //this.MethodValidarDuplicado = 'GetDecvie_MatryoshkaNuevoIndicadorNumero';
        this.ParamGetName1 = 'id_matryoshkanuevoindicador';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_MatryoshkaNuevoIndicadorDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}