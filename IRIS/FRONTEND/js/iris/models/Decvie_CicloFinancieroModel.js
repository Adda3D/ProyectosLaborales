function Decvie_CicloFinanciero () {
    //constructor() { 
        
        this.Campos = [
            {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_semestre',tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSemestreSelect, loadnulo: true},            
            //{campo: 'alcance', tipo: 'string', nullable: false, llave: ''},            
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''},
            

        ];

        this.CamposHTML = [
            [
                {campo: 'id_ciclofinanciero', tipo: 'string', nullable: false, llave: 'primary'},
                {campo: 'id_semestre', tipo: 'select', nullable: false, llave: '', etiqueta: 'Semestre', placeholder: '', title: '', numcols: 4, funconchange: null, funconclick: null},                
              //  {campo: 'alcance', tipo: 'string', nullable: false, llave: '', etiqueta: 'Alcance', placeholder: 'Alcance', title: '', numcols: 4, maxlength: 50, funconchange: null, funconclick: null},                
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, maxlength: 500, funconchange: null, funconclick: null}
            ],
            
            
            
            
        ];

        this.CampoLlave = 'id_ciclofinanciero';
        this.Nombre = 'Decvie_CicloFinanciero';
        this.ControllerName = 'Decvie_CicloFinanciero';
        this.MethodGet = 'GetDecvie_CicloFinancieroDetails';
        this.MethodUpdate = 'UpdateDecvie_CicloFinanciero';
        this.MethodInsert = 'InsertDecvie_CicloFinanciero';
        //this.MethodValidarDuplicado = 'GetDecvie_CicloFinancieroNumero';
        this.ParamGetName1 = 'id_ciclofinanciero';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecvie_CicloFinancieroDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}