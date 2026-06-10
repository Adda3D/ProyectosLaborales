function DecVie_PlanAccionAlcanceAnno() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_alcanceanno', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'nmalcanceanno', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            //{campo: 'prefijo', tipo: 'string', nullable: true, llave: ''},
           // {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: false}

           
        ];

        this.CamposHTML = [
            [
                {campo: 'id_alcanceanno', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'nmalcanceanno', tipo: 'string', nullable: false, llave: '', etiqueta: 'Alcane Año', placeholder: 'Alcane Año', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
               // {campo: 'prefijo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Prefijo', placeholder: 'Prefijo', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
               // {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', etiqueta: 'Dependencia', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},

               
            ]
        ];

        this.CampoLlave = 'id_alcanceanno';
        this.Nombre = 'DecVie_PlanAccionAlcanceAnno';
        this.ControllerName = 'DecVie_PlanAccionAlcanceAnno';
        this.MethodGet = 'GetDecVie_PlanAccionAlcanceAnnoDetails';
        this.MethodUpdate = 'UpdateDecVie_PlanAccionAlcanceAnno';
        this.MethodInsert = 'InsertDecVie_PlanAccionAlcanceAnno';
        this.MethodValidarDuplicado = 'GetDecVie_PlanAccionAlcanceAnnoNombre';
        this.ParamGetName1 = 'id_alcanceanno';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nmalcanceanno';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PlanAccionAlcanceAnnoDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

    //}
}