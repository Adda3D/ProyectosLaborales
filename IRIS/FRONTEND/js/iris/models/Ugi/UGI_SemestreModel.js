function UGI_Semestre () {
    
        
        this.Campos = [
            {campo: 'id_ugisemestre', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_semestre', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadSemestreSelect, loadnulo: false},
            {campo: 'numresolucion', tipo: 'string', nullable: false, llave: ''},
            {campo: 'fecresolucion', tipo: 'date', nullable: true, llave: ''},            
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}
            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_ugisemestre', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_semestre', tipo: 'select', nullable: false, llave: '', etiqueta: 'Semestre', placeholder: 'Semestre', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'numresolucion', tipo: 'string', nullable: false, llave: '', etiqueta: 'N° Resolución', placeholder: 'N° Resolución', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'fecresolucion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Resolución', placeholder: '', title: 'Fecha Resolución', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'string', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null}
               
            ]
        ];

        this.CampoLlave = 'id_ugisemestre';
        this.Nombre = 'UGI_Semestre';
        this.ControllerName = 'UGI_Semestre';
        this.MethodGet = 'GetUGI_SemestreDetails';
        this.MethodUpdate = 'UpdateUGI_Semestre';
        this.MethodInsert = 'InsertUGI_Semestre';
        //this.MethodValidarDuplicado = 'GetDecVie_InventarioGestionConocimientoNumero';
        this.ParamGetName1 = 'id_ugisemestre';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formUGI_SemestreDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   
}