function DecVie_Instancias () {
    
        
    this.Campos = [
        {campo: 'id_instancia', tipo: 'string', nullable: false, llave: 'primary'},       
        {campo: 'nminstancia', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
        {campo: 'identificacioninstancia', tipo: 'string', nullable: false, llave: ''},
        {campo: 'responsable', tipo: 'string', nullable: false, llave: ''},
        {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
                    
    ];

    this.CamposHTML = [
        [
            {campo: 'id_instancia', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'nminstancia', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Instancia', placeholder: 'Nombre Instancia', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'identificacioninstancia', tipo: 'string', nullable: false, llave: '', etiqueta: 'Identificación', placeholder: 'Identificación', title: '', numcols: 2, maxlength: 15, funconchange: null, funconclick: null},
            {campo: 'responsable', tipo: 'string', nullable: false, llave: '', etiqueta: 'Responsable', placeholder: 'Responsable', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null},
            {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 3, maxlength: 1500, funconchange: null, funconclick: null}
        ]
     
    ];

    this.CampoLlave = 'id_instancia';
    this.Nombre = 'DecVie_Instancias';
    this.ControllerName = 'DecVie_Instancias';
    this.MethodGet = 'GetDecVie_InstanciasDetails';
    this.MethodUpdate = 'UpdateDecVie_Instancias';
    this.MethodInsert = 'InsertDecVie_Instancias';
    this.MethodValidarDuplicado = 'GetDecVie_InstanciasNombre';
    this.ParamGetName1 = 'id_instancia';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ParamDuplicadoName = 'cd_nminstancia';
    this.ObjDatos = null;
    this.FormEdicion = 'formDecVie_InstanciasDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;

}