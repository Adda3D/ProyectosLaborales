function Propuesta_ModificacionGarantia() {

    this.Campos = [
        {campo: 'id_modificaciongarantia', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_suscripciongarantia', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_propuesta', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_tipomodificacion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadTipoModificacionMinutaSelect, loadnulo: true},
        {campo: 'fecsolicitud', tipo: 'date', nullable: true, llave: ''},
        {campo: 'descripcion', tipo: 'string', nullable: false, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_modificaciongarantia', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_suscripciongarantia', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_propuesta', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_tipomodificacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Modificación', placeholder: '', title: 'Tipo Modificación', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecsolicitud', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Solicitud', placeholder: '', title: 'Fecha Solicitud', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'descripcion', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Observaciones', placeholder: 'Observaciones', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_modificaciongarantia';
    this.Nombre = 'Propuesta_ModificacionGarantia';
    this.ControllerName = 'Propuesta_ModificacionGarantia';
    this.MethodGet = 'GetPropuesta_ModificacionGarantiaDetails';
    this.MethodUpdate = 'UpdatePropuesta_ModificacionGarantia';
    this.MethodInsert = 'InsertPropuesta_ModificacionGarantia';
	this.MethodValidarDuplicado = '';
    this.ParamGetName1 = 'id_modificaciongarantia';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
	this.ParamDuplicadoName = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formproyectoextension_modificacionGarantiaDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}