function DecVie_PlanAccionAlcance () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_planaccionalcance', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_depend', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'descripcionalcance', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_alcanceanno', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_PlanAccionAlcanceAnnoSelect, loadnulo: false}
         //   {campo: 'estrategiaprogramapgd', tipo: 'string', nullable: true, llave: ''}
                        
        ];

        this.CamposHTML = [
            [
                {campo: 'id_planaccionalcance', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_depend', tipo: 'string', nullable: true, llave: 'foreign'},
                {campo: 'descripcionalcance', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción Alcance', placeholder: 'Descripción Alcance', title: '', numcols: 4, numrows: 3, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'string', nullable: false, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},                
                {campo: 'id_alcanceanno', tipo: 'select', nullable: false, llave: '', etiqueta: 'Alcance', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null}
              //  {campo: 'estrategiaprogramapgd', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Estratégia Programa PGD', placeholder: 'Estratégia Programa PGD', title: '', numcols: 4, numrows: 3, maxlength: 1500, funconchange: null, funconclick: null}
            ]
         
        ];

        this.CampoLlave = 'id_planaccionalcance';
        this.Nombre = 'DecVie_PlanAccionAlcance';
        this.ControllerName = 'DecVie_PlanAccionAlcance';
        this.MethodGet = 'GetDecVie_PlanAccionAlcanceDetails';
        this.MethodUpdate = 'UpdateDecVie_PlanAccionAlcance';
        this.MethodInsert = 'InsertDecVie_PlanAccionAlcance';
        this.MethodValidarDuplicado = 'GetDecVie_PlanAccionAlcanceNombre';
        this.ParamGetName1 = 'id_planaccionalcance';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_descripcionalcance';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_PlanAccionAlcanceDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}