function Publicaciones_DivulgacionPlan() {
        
    this.Campos = [
        {campo: 'id_plan', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_crearpublicacion', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'textopromocional', tipo: 'string', nullable: false, llave: ''},
        {campo: 'fecinicio', tipo: 'date', nullable: false, llave: ''},
        {campo: 'feccierre', tipo: 'date', nullable: false, llave: ''},
        {campo: 'derecho', tipo: 'bool', nullable: true, llave: ''},
        {campo: 'cienciapolitica', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'entregaautor', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'entregainvitado', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'entregamoderador', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'entregaeditorial', tipo: 'bool', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_plan', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_crearpublicacion', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'textopromocional', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Texto Promocional', placeholder: 'Texto Promocional', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'fecinicio', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Inicio', placeholder: '', title: 'Fecha Inicio', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'feccierre', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Cierre', placeholder: '', title: 'Fecha Cierre Programado', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'derecho', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Área Derecho', placeholder: '', title: 'Área Derecho', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'cienciapolitica', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Ciencia Política', placeholder: '', title: 'Ciencia Política', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'entregaautor', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Entrega Autores', placeholder: '', title: 'Entrega Autores', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'entregainvitado', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Entrega Invitados', placeholder: '', title: 'Entrega Invitados', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'entregamoderador', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Entrega Moderador', placeholder: '', title: 'Entrega Moderador', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'entregaeditorial', tipo: 'bool', nullable: false, llave: '', etiqueta: 'Entrega Editorial', placeholder: '', title: 'Entrega Editorial', numcols: 2, funconchange: null, funconclick: null},            
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 3, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_plan';
    this.Nombre = 'Publicaciones_DivulgacionPlan';
    this.ControllerName = 'Publicaciones_DivulgacionPlan';
    this.MethodGet = 'GetPublicaciones_DivulgacionPlanByPublicacion';
    this.MethodUpdate = 'UpdatePublicaciones_DivulgacionPlan';
    this.MethodInsert = 'InsertPublicaciones_DivulgacionPlan';
    this.ParamGetName1 = 'id_crearpublicacion';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formPublicacionDivulgacionPlanDatos';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
