function DecVie_PlanAccionProgramaPgd () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_programapgd', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'nmprogramapgd', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'descripcionprogramapgd', tipo: 'string', nullable: false, llave: ''},
            {campo: 'estrategiaprogramapgd', tipo: 'string', nullable: true, llave: ''}
                        
        ];

        this.CamposHTML = [
            [
                {campo: 'id_programapgd', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_depend', tipo: 'string', nullable: true, llave: 'foreign'},
                {campo: 'nmprogramapgd', tipo: 'string', nullable: false, llave: '', etiqueta: 'Programa PGD', placeholder: 'Programa PGD', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'descripcionprogramapgd', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción Programa PGD', placeholder: 'Descripción Programa PGD', title: '', numcols: 4, numrows: 3, maxlength: 1500, funconchange: null, funconclick: null},
                {campo: 'estrategiaprogramapgd', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Estratégia Programa PGD', placeholder: 'Estratégia Programa PGD', title: '', numcols: 4, numrows: 3, maxlength: 1500, funconchange: null, funconclick: null}
            ]
         
        ];

        this.CampoLlave = 'id_programapgd';
        this.Nombre = 'DecVie_PlanAccionProgramaPgd';
        this.ControllerName = 'DecVie_PlanAccionProgramaPgd';
        this.MethodGet = 'GetDecVie_PlanAccionProgramaPgdDetails';
        this.MethodUpdate = 'UpdateDecVie_PlanAccionProgramaPgd';
        this.MethodInsert = 'InsertDecVie_PlanAccionProgramaPgd';
        this.MethodValidarDuplicado = 'GetDecVie_PlanAccionProgramaPgdNombre';
        this.ParamGetName1 = 'id_programapgd';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nmprogramapgd';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PlanAccionProgramaPgdDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}