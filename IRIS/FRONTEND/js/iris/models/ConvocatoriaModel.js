function Convocatoria () {
    
        this.Campos = [
            {campo: 'id_convocatoria', tipo: 'string', nullable: false, llave: 'primary'},                        
            {campo: 'naturaleza', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadNaturalezaConvocatoriaSelect, loadnulo: true},
            {campo: 'id_alcance', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadConvocatoria_AlcanceSelect, loadnulo: true},
            {campo: 'id_fuentecnv', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadConvocatoria_FuenteCNVSelect, loadnulo: true}, 
            {campo: 'tituloconvocatoria', tipo: 'string', nullable: false, llave: ''/* , allowduplicate: false */},
            {campo: 'objetivogeneral', tipo: 'string', nullable: false, llave: ''},
            {campo: 'dirigidolargo', tipo: 'string', nullable: false, llave: ''},
            {campo: 'dirigidocorto', tipo: 'string', nullable: false, llave: ''},
            {campo: 'totalrecursos', tipo: 'num', nullable: false, llave: ''},
            //{campo: 'id_recursoparticipante', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_OrigenSolicitud, loadnulo: true},
            {campo: 'fechaapertura', tipo: 'date', nullable: false, llave: ''},
            {campo: 'fechacierre', tipo: 'date', nullable: false, llave: ''},
            {campo: 'fecharesultadosdef', tipo: 'date', nullable: true, llave: ''},
            {campo: 'id_estadocnv', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadConvocatoria_EstadoCNVSelect, loadnulo: true},
            {campo: 'contrapartida', tipo: 'int', nullable: false, llave: ''}
          //{campo: 'id_requisito', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_OrigenSolicitud, loadnulo: true}        
            
        ];

        this.CamposHTML = [
            [
                {campo: 'id_convocatoria', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'naturaleza', tipo: 'select', nullable: false, llave: '', etiqueta: 'Naturaleza', placeholder: '', title: '', numcols: 3, maxlength: 20, funconchange: null, funconclick: null},
                {campo: 'id_alcance', tipo: 'select', nullable: false, llave: '', etiqueta: 'Alcance', placeholder: '', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'id_fuentecnv', tipo: 'select', nullable: false, llave: '', etiqueta: 'Fuente', placeholder: '', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'tituloconvocatoria', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Título Convocatoria', placeholder: 'Título Convocatoria', title: '', numcols: 3, numrows: 3, maxlength: 2000, funconchange: null, funconclick: null}
            ],
            [
                {campo: 'objetivogeneral', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Objetivo General', placeholder: 'Objetivo General', title: '', numcols: 3, numrows: 3, maxlength: 5000, funconchange: null, funconclick: null},
                {campo: 'dirigidolargo', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Dirigido Largo', placeholder: 'Dirigido Largo', title: '', numcols: 3, numrows: 3, maxlength: 5000, funconchange: null, funconclick: null},
                {campo: 'dirigidocorto', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Dirigido Corto', placeholder: 'Dirigido Corto', title: '', numcols: 3, numrows: 3, maxlength: 5000, funconchange: null, funconclick: null},
                {campo: 'totalrecursos', tipo: 'num', nullable: true, llave: '', etiqueta: 'Total Recursos', placeholder: 'Total Recursos', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null}
            ],
            [
            //  {campo: 'id_recursoparticipante', tipo: 'select', nullable: False, llave: '', etiqueta: 'Recurso Participante', placeholder: 'Recurso Participante', title: '', numcols: 3, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'fechaapertura', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Apertura', placeholder: '', title: 'Fecha Apertura', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'fechacierre', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Cierre', placeholder: '', title: 'Fecha Cierre', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'fecharesultadosdef', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Resultados', placeholder: '', title: 'Fecha Resultados', numcols: 3, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'id_estadocnv', tipo: 'select', nullable: false, llave: '', etiqueta: 'Estado', placeholder: 'Estado', title: '', numcols: 3, maxlength: 50, funconchange: null, funconclick: null}
            ],
            [
                
                {campo: 'contrapartida', tipo: 'int', nullable: true, llave: '', etiqueta: 'Contrapartida', placeholder: 'Contrapartida', title: '', numcols: 3, maxlength: 12, funconchange: null, funconclick: null}
               // {campo: 'id_requisito', tipo: 'select', nullable: False, llave: '', etiqueta: 'Requisitos', placeholder: 'Requisitos', title: '', numcols: 3, maxlength: 500, funconchange: null, funconclick: null}
                
            ]
            
        ];

        this.CampoLlave = 'id_convocatoria';
        this.Nombre = 'Convocatoria';
        this.ControllerName = 'Convocatoria';
        this.MethodGet = 'GetConvocatoriaDetails';
        this.MethodUpdate = 'UpdateConvocatoria';
        this.MethodInsert = 'InsertConvocatoria';
        this.MethodValidarDuplicado = 'GetConvocatoriaNombre';
        this.ParamGetName1 = 'id_convocatoria';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_tituloconvocatoria';
        this.ObjDatos = null;
        this.FormEdicion = 'formConvocatoriaDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

}