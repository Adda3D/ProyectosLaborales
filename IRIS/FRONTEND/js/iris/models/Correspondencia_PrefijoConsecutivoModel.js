
//"../js/iris//models/Correspondencia_PrefijoConsecutivoModel.js"
function Correspondencia_PrefijoConsecutivo() {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_prefijoconsecutivo', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'nmprefijo', tipo: 'string', nullable: false, llave: '', allowduplicate: false},
            {campo: 'prefijo', tipo: 'string', nullable: true, llave: ''},
            {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDependenciaSelectNulo, loadnulo: true}

           
        ];

        this.CamposHTML = [
            [
                {campo: 'id_prefijoconsecutivo', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'nmprefijo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Nombre Prefijo', placeholder: 'Nombre Prefijo', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'prefijo', tipo: 'string', nullable: false, llave: '', etiqueta: 'Prefijo', placeholder: 'Prefijo', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'id_depend', tipo: 'select', nullable: false, llave: '', etiqueta: 'Dependencia', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},

               
            ]
        ];

        this.CampoLlave = 'id_prefijoconsecutivo';
        this.Nombre = 'Correspondencia_PrefijoConsecutivo';
        this.ControllerName = 'Correspondencia_PrefijoConsecutivo';
        this.MethodGet = 'GetCorrespondencia_PrefijoConsecutivoDetails';
        this.MethodUpdate = 'UpdateCorrespondencia_PrefijoConsecutivo';
        this.MethodInsert = 'InsertCorrespondencia_PrefijoConsecutivo';
        this.MethodValidarDuplicado = 'GetCorrespondencia_PrefijoConsecutivoNombre';
        this.ParamGetName1 = 'id_prefijoconsecutivo';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        this.ParamDuplicadoName = 'cd_nmprefijo';
        this.ObjDatos = null;
        this.FormEdicion = 'formCorrespondencia_PrefijoConsecutivoDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

    //}
}