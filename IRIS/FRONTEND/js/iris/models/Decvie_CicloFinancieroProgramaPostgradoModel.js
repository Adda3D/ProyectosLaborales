function Decvie_CicloFinancieroProgramaPostgrado () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_programapostgrado', tipo: 'string', nullable: false, llave: 'primary'},            
            {campo: 'nmprogramapostgrado', tipo: 'string', nullable: true, llave: ''},
            {campo: 'tipoprograma', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadTipoProgramaPostgradoSelect, loadnulo: true},                    
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_programapostgrado', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'nmprogramapostgrado', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Programa Postgrado', placeholder: 'Programa Postgrado', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'tipoprograma', tipo: 'select', nullable: true, llave: '', etiqueta: 'Tipo de Programa', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Codigo Programa', placeholder: 'Codigo Programa', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_programapostgrado';
        this.Nombre = 'Decvie_CicloFinancieroProgramaPostgrado';
        this.ControllerName = 'Decvie_CicloFinancieroProgramaPostgrado';
        this.MethodGet = 'GetDecvie_CicloFinancieroProgramaPostgradoDetails';
        this.MethodUpdate = 'UpdateDecvie_CicloFinancieroProgramaPostgrado';
        this.MethodInsert = 'InsertDecvie_CicloFinancieroProgramaPostgrado';
        //this.MethodValidarDuplicado = 'GetDecvie_CicloFinancieroProgramaPostgradoNumero';
        this.ParamGetName1 = 'id_programapostgrado';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_CicloFinancieroProgramaPostgradoDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}