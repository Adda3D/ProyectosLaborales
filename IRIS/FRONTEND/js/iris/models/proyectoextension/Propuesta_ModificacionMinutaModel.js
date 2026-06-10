function Propuesta_ModificacionMinuta() {
        
    this.Campos = [
        {campo: 'id_modificacionminuta', tipo: 'string', nullable: false, llave: 'primary'},
        {campo: 'id_propuesta', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'id_suscripcionminuta', tipo: 'string', nullable: false, llave: 'foranea'},
        {campo: 'fecsolmodvol', tipo: 'date', nullable: false, llave: ''},
        {campo: 'id_tipomodificacion', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadTipoModificacionMinutaSelect, loadnulo: true},
        {campo: 'descripcionmodificacion', tipo: 'string', nullable: false, llave: ''},
        {campo: 'idresponsablerevsolicitud', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'fecrevisionsolicitud', tipo: 'date', nullable: true, llave: ''},
        {campo: 'idresponsableremitedecanatura', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'fecremsolmoddecanatura', tipo: 'date', nullable: true, llave: ''},
        {campo: 'consecutivoremisiondecanatura', tipo: 'string', nullable: true, llave: ''},
        {campo: 'tiemporevisiondec', tipo: 'int', nullable: true, llave: ''},
        {campo: 'idresponsableaprobmodificacion', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadFuncionarioSelect, loadnulo: true},
        {campo: 'fecrecepcionobsdec', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecremisionobsentidad', tipo: 'date', nullable: true, llave: ''},
        {campo: 'fecapromodificaciones', tipo: 'date', nullable: true, llave: ''},
        {campo: 'avalinterno', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadSiNoNoAplicaSelect, loadnulo: true},        
        {campo: 'fecsusmodacuvol', tipo: 'date', nullable: true, llave: ''},
        {campo: 'valorajustado', tipo: 'num', nullable: false, llave: ''},
        {campo: 'plazoejecajustado', tipo: 'string', nullable: false, llave: ''},
        {campo: 'obligacionesmodificadas', tipo: 'string', nullable: false, llave: ''},
        {campo: 'productosmodificados', tipo: 'string', nullable: false, llave: ''},
        {campo: 'enlacesoportes', tipo: 'string', nullable: true, llave: ''}
    ];

    this.CamposHTML = [
        [
            {campo: 'id_modificacionminuta', tipo: 'string', nullable: true, llave: 'primary'},
            {campo: 'id_propuesta', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'id_suscripcionminuta', tipo: 'string', nullable: true, llave: 'foranea'},
            {campo: 'fecsolmodvol', tipo: 'date', nullable: false, llave: '', etiqueta: 'Fecha Solicitud', placeholder: '', title: 'Fecha Solicitud', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'id_tipomodificacion', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipo Modificación', placeholder: '', title: 'Tipo Modificación', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'descripcionmodificacion', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Descripción Modificación', placeholder: 'Descripción Modificación', title: '', numcols: 2, numrows: 2, maxlength: 500, funconchange: null, funconclick: null},
            {campo: 'idresponsablerevsolicitud', tipo: 'select', nullable: true, llave: '', etiqueta: 'Resp. Revisa Solicitud', placeholder: '', title: 'Responsable Revisar Solicitud', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrevisionsolicitud', tipo: 'date', nullable: true, llave: '', etiqueta: 'Revisión Solicitud', placeholder: '', title: 'Fecha Revisión Solicitud', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'idresponsableremitedecanatura', tipo: 'select', nullable: true, llave: '', etiqueta: 'Resp. remitir DEC.', placeholder: '', title: 'Responsable remitir Decanatura', numcols: 2, funconchange: null, funconclick: null}
        ],        
        [
            {campo: 'fecremsolmoddecanatura', tipo: 'date', nullable: true, llave: '', etiqueta: 'F. Remite a DEC.', placeholder: '', title: 'Fecha Remisión Decanatura', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
            {campo: 'consecutivoremisiondecanatura', tipo: 'string', nullable: true, llave: '', etiqueta: 'Consec. Remite DEC.', placeholder: 'Consec. Remisión Dacanatura', title: '', numcols: 2, maxlength: 30, funconchange: null, funconclick: null},
            {campo: 'tiemporevisiondec', tipo: 'int', nullable: false, llave: '', etiqueta: 'T. Revisión', placeholder: '', title: 'Tiempo Revisión', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'idresponsableaprobmodificacion', tipo: 'select', nullable: true, llave: '', etiqueta: 'Resp. Aprob. Modi', placeholder: '', title: 'Resp. Aprobacipon Modificación', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecrecepcionobsdec', tipo: 'date', nullable: true, llave: '', etiqueta: 'F. Recibe Obs DEC.', placeholder: '', title: 'Fecha Recibe Observaciones Decanatura', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecremisionobsentidad', tipo: 'date', nullable: true, llave: '', etiqueta: 'F. Remite Obs Entidad', placeholder: '', title: 'Fecha Remite Observaciones Entidad', numcols: 2, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'fecapromodificaciones', tipo: 'date', nullable: true, llave: '', etiqueta: 'F. Aprob. Entidad', placeholder: '', title: 'Fecha Aprobación Entidad', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'avalinterno', tipo: 'select', nullable: true, llave: '', etiqueta: 'Avales Internos', placeholder: '', title: 'Avales Internos', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'fecsusmodacuvol', tipo: 'date', nullable: true, llave: '', etiqueta: 'F. Suscr. Modificación', placeholder: '', title: 'Fecha Suscripción Modificación', numcols: 2, funconchange: null, funconclick: null},
            {campo: 'valorajustado', tipo: 'num', nullable: false, llave: '', etiqueta: 'Valor Ajustado', placeholder: '', title: 'Valor Ajustado', numcols: 2, minimo: 0, funconchange: null, funconclick: null},
            {campo: 'plazoejecajustado', tipo: 'string', nullable: true, llave: '', etiqueta: 'Plazo Ejecución Ajustado', placeholder: 'Plazo Ejecución Ajustado', title: '', numcols: 2, maxlength: 120, funconchange: null, funconclick: null},
            {campo: 'obligacionesmodificadas', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Obligaciones Compromisos Modificados', placeholder: 'Obligaciones Compromisos Modificados', title: '', numcols: 2, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ],
        [
            {campo: 'productosmodificados', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Productos Modificados', placeholder: 'Productos Modificados', title: '', numcols: 2, numrows: 2, maxlength: 900, funconchange: null, funconclick: null},
            {campo: 'enlacesoportes', tipo: 'textarea', nullable: true, llave: '', etiqueta: 'Enlace Archivos', placeholder: 'Enlace Archivos', title: '', numcols: 4, numrows: 2, maxlength: 500, funconchange: null, funconclick: null}
        ]
    ];

    this.CampoLlave = 'id_modificacionminuta';
    this.Nombre = 'Propuesta_ModificacionMinuta';
    this.ControllerName = 'Propuesta_ModificacionMinuta';
    this.MethodGet = 'GetPropuesta_ModificacionMinutaDetails';
    this.MethodUpdate = 'UpdatePropuesta_ModificacionMinuta';
    this.MethodInsert = 'InsertPropuesta_ModificacionMinuta';
    this.ParamGetName1 = 'id_modificacionminuta';
    this.ParamGetName2 = '';
    this.ParamGetName3 = '';
    this.ObjDatos = null;
    this.FormEdicion = 'formproyectoextension_modificacionminutaDetalle';
    this.IsModal = false;
    this.DatosNullEdicion = true;
    this.SufijoNombreControl = '';

}
