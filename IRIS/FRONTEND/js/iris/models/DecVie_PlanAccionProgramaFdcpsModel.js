function DecVie_PlanAccionProgramaFdcps () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_programafdcps', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'programafacultad', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'descripcionprogramafacultad', tipo: 'string', nullable: false, llave: ''}                        
        ];

        this.CamposHTML = [
            [
                {campo: 'id_programafdcps', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_depend', tipo: 'string', nullable: true, llave: 'foreign'},
                {campo: 'programafacultad', tipo: 'string', nullable: false, llave: '', etiqueta: 'Programa PGD', placeholder: 'Programa PGD', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'descripcionprogramafacultad', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción Programa PGD', placeholder: 'Descripción Programa PGD', title: '', numcols: 4, numrows: 3, maxlength: 1500, funconchange: null, funconclick: null}

            ]
         
        ];

        this.CampoLlave = 'id_programafdcps';
        this.Nombre = 'DecVie_PlanAccionProgramaFdcps';
        this.ControllerName = 'DecVie_PlanAccionProgramaFdcps';
        this.MethodGet = 'GetDecVie_PlanAccionProgramaFdcpsDetails';
        this.MethodUpdate = 'UpdateDecVie_PlanAccionProgramaFdcps';
        this.MethodInsert = 'InsertDecVie_PlanAccionProgramaFdcps';
        this.MethodValidarDuplicado = 'GetDecVie_PlanAccionProgramaFdcpsNombre';
        this.ParamGetName1 = 'id_programafdcps';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_programafacultad';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PlanAccionProgramaFdcpsDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}