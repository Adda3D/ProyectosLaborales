function Convocatoria_RecursoParticipante () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_recursoparticipante', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'foreign'}, 
            {campo: 'nmrecurso', tipo: 'string', nullable: true, llave: '', allowduplicate: false},
            {campo: 'valorrecurso', tipo: 'num', nullable: false, llave: ''},
            {campo: 'observaciones', tipo: 'string', nullable: true, llave: ''}            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_recursoparticipante', tipo: 'string', nullable: false, llave: 'primary'},                
                {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'foreign'},
                {campo: 'nmrecurso', tipo: 'string', nullable: true, llave: '', etiqueta: 'Nombre Recurso', placeholder: 'Nombre Recurso', title: '', numcols: 6, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'valorrecurso', tipo: 'num', nullable: true, llave: '', etiqueta: 'Valor Recursos', placeholder: 'Valor Recursos', title: '', numcols: 6, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'observaciones', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 6, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}                
            ]            
                                    
        ];

        this.CampoLlave = 'id_recursoparticipante';
        this.Nombre = 'Convocatoria_RecursoParticipante';
        this.ControllerName = 'Convocatoria_RecursoParticipante';
        this.MethodGet = 'GetConvocatoria_RecursoParticipanteDetails';
        this.MethodUpdate = 'UpdateConvocatoria_RecursoParticipante';
        this.MethodInsert = 'InsertConvocatoria_RecursoParticipante';
        this.MethodValidarDuplicado = 'GetConvocatoria_RecursoParticipanteNombre';
        this.ParamGetName1 = 'id_recursoparticipante';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nmrecurso';
        this.ObjDatos = null;
        this.FormEdicion = 'formConvocatoria_RecursoParticipanteDetalle';
        this.IsModal = true;
        this.DatosNullEdicion = true;

   // }
}