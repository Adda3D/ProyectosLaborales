function MatrizFinanciera_GastoApoyo () {
    
        
        this.Campos = [
            {campo: 'id_gastoapoyo', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_matrizfinanciera', tipo: 'string', nullable: false, llave: 'foreign'},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true},            
            {campo: 'especializado', tipo: 'int', nullable: true, llave: ''},
            {campo: 'profesional', tipo: 'int', nullable: true, llave: ''},
            {campo: 'tecnico', tipo: 'int', nullable: true, llave: ''},
            {campo: 'asistencial', tipo: 'int', nullable: true, llave: ''},
            {campo: 'totalpersonascontratadas', tipo: 'int', nullable: true, llave: ''},
            {campo: 'valortotal', tipo: 'int', nullable: false, llave: ''},
            {campo: 'observaciones', tipo: 'string', nullable: false, llave: ''}
            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_gastoapoyo', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_matrizfinanciera', tipo: 'string', nullable: true, llave: 'foreign'},
                {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', etiqueta: 'Dependencia', placeholder: '', title: '', numcols: 3, maxlength: 20, funconchange: null, funconclick: null},                
                {campo: 'especializado', tipo: 'int', nullable: true, llave: '', etiqueta: 'Total Personal Especializado', placeholder: 'Personal Especializado', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'profesional', tipo: 'int', nullable: true, llave: '', etiqueta: 'Personal Profecional', placeholder: 'Personal Profecional', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'tecnico', tipo: 'int', nullable: true, llave: '', etiqueta: 'Personal Técnico', placeholder: 'Personal Técnico', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null}
                
            ],
            [   
                {campo: 'asistencial', tipo: 'int', nullable: true, llave: '', etiqueta: 'Personal Asistencial', placeholder: 'Personal Asistencial', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'totalpersonascontratadas', tipo: 'int', nullable: true, llave: '', etiqueta: 'Total Personas Contratadas', placeholder: 'Total Personas Contratadas', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'valortotal', tipo: 'int', nullable: false, llave: '', etiqueta: 'Valor Total', placeholder: 'Valor Total', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 3, numrows:2, maxlength: 500, funconchange: null, funconclick: null}

            ]
         
        ];

        this.CampoLlave = 'id_gastoapoyo';
        this.Nombre = 'MatrizFinanciera_GastoApoyo';
        this.ControllerName = 'MatrizFinanciera_GastoApoyo';
        this.MethodGet = 'GetMatrizFinanciera_GastoApoyoDetails';
        this.MethodUpdate = 'UpdateMatrizFinanciera_GastoApoyo';
        this.MethodInsert = 'InsertMatrizFinanciera_GastoApoyo';
        //this.MethodValidarDuplicado = 'GetMatrizFinanciera_GastoApoyoNombre';
        this.ParamGetName1 = 'id_gastoapoyo';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_nmprogramapgd';
        this.ObjDatos = null;
        this.FormEdicion = 'formMatrizFinanciera_GastoApoyoDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

  
}