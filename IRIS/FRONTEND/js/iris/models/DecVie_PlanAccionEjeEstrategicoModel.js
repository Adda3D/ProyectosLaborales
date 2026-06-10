function DecVie_PlanAccionEjeEstrategico () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_ejeestrategico', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'ejeestrategico', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'descripcionejeestrategico', tipo: 'string', nullable: false, llave: ''},
            {campo: 'planaccionesestrategica', tipo: 'string', nullable: true, llave: ''},
            {campo: 'planaccionesoperativa', tipo: 'string', nullable: true, llave: ''},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_ejeestrategico', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_depend', tipo: 'string', nullable: true, llave: 'foreign'},
                {campo: 'ejeestrategico', tipo: 'string', nullable: false, llave: '', etiqueta: 'Eje Estratégico', placeholder: 'Eje Estratégico', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'descripcionejeestrategico', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción Eje Estratégico', placeholder: 'Descripción Eje Estratégico', title: '', numcols: 2, numrows: 3, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'planaccionesestrategica', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Acción Estratégica', placeholder: 'Acción Estratégica', title: '', numcols: 2, numrows: 3, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'planaccionesoperativa', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Acción Operativa', placeholder: 'Acción Operativa', title: '', numcols: 2, numrows: 3, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'string', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null}
     
            ]
         
        ];

        this.CampoLlave = 'id_ejeestrategico';
        this.Nombre = 'DecVie_PlanAccionEjeEstrategico';
        this.ControllerName = 'DecVie_PlanAccionEjeEstrategico';
        this.MethodGet = 'GetDecVie_PlanAccionEjeEstrategicoDetails';
        this.MethodUpdate = 'UpdateDecVie_PlanAccionEjeEstrategico';
        this.MethodInsert = 'InsertDecVie_PlanAccionEjeEstrategico';
        this.MethodValidarDuplicado = 'GetDecVie_PlanAccionEjeEstrategicoNombre';
        this.ParamGetName1 = 'id_ejeestrategico';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_ejeestrategico';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PlanAccionEjeEstrategicoDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}