function DecVie_PlanAccionMatryoshka () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_matryoshka', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'id_lineapolitica', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionLineaPoliticaSelect, loadnulo: false},
            {campo: 'id_ejeestrategico', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionEjeEstrategicoSelect, loadnulo: false},
            {campo: 'id_objetivoestrategico', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivoEstrategicoSelect, loadnulo: false},
            {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionProgramaPgdSelect, loadnulo: false},
            {campo: 'estrategias', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivosPgdVriSedeSelect, loadnulo: false},
            {campo: 'procesosvsestrategias', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_objetivodependencia', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionObjetivoDependenciaSelect, loadnulo: false},
            {campo: 'id_meta', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionMetaSelect, loadnulo: false},
            {campo: 'actividades', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_indicadoresestrategicos', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionIndicadoresEstrategicosSelect, loadnulo: false},
            {campo: 'id_nuevosindicadores', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionNuevosIndicadoresSelect, loadnulo: false},
            {campo: 'id_tipoindicador', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionTipoIndicadorSelect, loadnulo: false},
            {campo: 'descripcion', tipo: 'string', nullable: false, llave: ''},
            {campo: 'presupuesto', tipo: 'int', nullable: false, llave: ''},
            {campo: 'id_planaccionalcance', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionAlcanceSelect, loadnulo: false}

        ];

        this.CamposHTML = [
            [
                {campo: 'id_matryoshka', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_depend', tipo: 'string', nullable: true, llave: 'foreign'},
                {campo: 'id_lineapolitica', tipo: 'select', nullable: false, llave: '', etiqueta: 'Línea Política', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'Politica', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Política', placeholder: 'Política', title: '', numcols: 4, maxlength: 1500, funconchange: null, funconclick: null},
                {campo: 'id_ejeestrategico', tipo: 'select', nullable: false, llave: '', etiqueta: 'Eje Estratégico', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'estrategia', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Estratégia', placeholder: 'Estratégia', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null}
            ],
            [   
                {campo: 'id_objetivoestrategico', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo Estratégico', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'objetivoestrategico', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Objetivos', placeholder: 'Objetivos', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'id_programapgd', tipo: 'select', nullable: false, llave: '', etiqueta: 'Programas', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'programapgd', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Programa', placeholder: 'Programa', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null} 

            
                
            ],
            [   
                {campo: 'estrategias', tipo: 'string', nullable: true, llave: '', etiqueta: 'Estrategias', placeholder: 'Estrategias', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'id_objetivopgdvrisede', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo PGD VRI Sede', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},                
                {campo: 'procesosvsestrategias', tipo: 'textarea', true: false, llave: '', etiqueta: 'Procesos vs Estrategias', placeholder: 'Procesos vs Estrategias', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'id_objetivodependencia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Objetivo Dependencia', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},                
                {campo: 'id_meta', tipo: 'select', nullable: false, llave: '', etiqueta: 'Metas', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null}                
             
            ],
            [                  
                {campo: 'actividades', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Actividades', placeholder: 'Actividades', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'id_indicadoresestrategicos', tipo: 'select', nullable: false, llave: '', etiqueta: 'Indicadores Estratégicos', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_nuevosindicadores', tipo: 'select', nullable: false, llave: '', etiqueta: 'Nuevos Indicadores', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_tipoindicador', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Indicador', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'descripcion', tipo: 'string', nullable: true, llave: '', etiqueta: 'Descripción', placeholder: 'Descripción', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'presupuesto', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto', placeholder: 'Presupuesto', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null}
               
            ],
            [                   
                {campo: 'id_planaccionalcance', tipo: 'select', nullable: false, llave: '', etiqueta: 'Alcance', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'alcances', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Alcances', placeholder: 'Alcances', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null}
            ],
        ];

        this.CampoLlave = 'id_matryoshka';
        this.Nombre = 'DecVie_PlanAccionMatryoshka';
        this.ControllerName = 'DecVie_PlanAccionMatryoshka';
        this.MethodGet = 'GetDecVie_PlanAccionMatryoshkaDetails';
        this.MethodUpdate = 'UpdateDecVie_PlanAccionMatryoshka';
        this.MethodInsert = 'InsertDecVie_PlanAccionMatryoshka';
        //this.MethodValidarDuplicado = 'GetDecVie_PlanAccionMatryoshkaNumero';
        this.ParamGetName1 = 'id_matryoshka';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PlanAccionMatryoshkaDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}