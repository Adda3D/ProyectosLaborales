function DecVie_InventarioGestionConocimiento () {
    //constructor() {
        
        this.Campos = [
            {campo: 'id_invgesconocimiento', tipo: 'string', nullable: false, llave: 'primary'},
            {campo: 'id_conocimientosoporte', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_InventarioConocimientoSoporteSelect, loadnulo: false},
            {campo: 'vigencia', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_conocimientotipologia', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_InventarioConocimientoTipologiaSelect, loadnulo: false},
            {campo: 'id_conocimientoenfasis', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadDecVie_InventarioConocimientoEnfasisSelect, loadnulo: false},
            {campo: 'idpropuesta_entidad', tipo: 'select', nullable: false, llave: '', funcloadselect: LoadPropuestaContratante, loadnulo: true},
            {campo: 'beneficiarios', tipo: 'string', nullable: false, llave: ''},
            {campo: 'id_conocimientoimpacto', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_InventarioConocimientoImpactoSelect, loadnulo: false},
            {campo: 'id_patentetipo', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_InventarioRegistroPatenteTipoSelect, loadnulo: false},
            {campo: 'vigenciapatente', tipo: 'string', nullable: true, llave: ''},
            {campo: 'entidadpatente', tipo: 'string', nullable: true, llave: ''},
            {campo: 'gastos', tipo: 'int', nullable: true, llave: ''},
            {campo: 'costodirecto', tipo: 'int', nullable: true, llave: ''},
            {campo: 'total', tipo: 'int', nullable: true, llave: ''},
            {campo: 'id_insumo', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_InventarioUsoAmpliadoInsumoSelect, loadnulo: true},
            {campo: 'id_ahorro', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_InventarioUsoAmpliadoAhorroSelect, loadnulo: true},
            {campo: 'id_obsolescenciaconcepto', tipo: 'select', nullable: true, llave: '', funcloadselect: LoadDecVie_InventarioObsolescenciaConceptoSelect, loadnulo: false},
            {campo: 'presupuestoejecutado', tipo: 'int', nullable: true, llave: ''},
            {campo: 'designadogestion', tipo: 'int', nullable: true, llave: ''},
            {campo: 'fechavaloracion', tipo: 'date', nullable: true, llave: ''}
        ];

        this.CamposHTML = [
            [
                {campo: 'id_invgesconocimiento', tipo: 'string', nullable: true, llave: 'primary'},
                {campo: 'id_conocimientosoporte', tipo: 'select', nullable: false, llave: '', etiqueta: 'Soporte', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'vigencia', tipo: 'string', nullable: false, llave: '', etiqueta: 'Vigencia', placeholder: 'Vigencia', title: '', numcols: 2, maxlength: 50, funconchange: null, funconclick: null},
                {campo: 'id_conocimientotipologia', tipo: 'select', nullable: false, llave: '', etiqueta: 'Tipología', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_conocimientoenfasis', tipo: 'select', nullable: false, llave: '', etiqueta: 'Enfasis', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'idpropuesta_entidad', tipo: 'select', nullable: false, llave: '', etiqueta: 'Contratante', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'beneficiarios', tipo: 'textarea', nullable: false, llave: '', etiqueta: 'Beneficiarios', placeholder: 'Beneficiarios', title: '', numcols: 2, numrows: 2, maxlength: 50, funconchange: null, funconclick: null}                
            ],
            [                    
                {campo: 'id_conocimientoimpacto', tipo: 'select', nullable: true, llave: '', etiqueta: 'Impacto', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_patentetipo', tipo: 'select', nullable: true, llave: '', etiqueta: 'Patente Tipo', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'vigenciapatente', tipo: 'string', nullable: true, llave: '', etiqueta: 'Patente Vigencia', placeholder: 'Patente Vigencia', title: '', numcols: 2, maxlength: 500, funconchange: null, funconclick: null},
                {campo: 'entidadpatente', tipo: 'string', nullable: true, llave: '', etiqueta: 'Entidad Patente', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'gastos', tipo: 'int', nullable: true, llave: '', etiqueta: 'Gastos', placeholder: 'Gastos', title: '', numcols: 2, maxlength: 12, funconchange: "SumarTotales('nmgastos_DecVie_InventarioGestionConocimiento', 'nmcostodirecto_DecVie_InventarioGestionConocimiento',null,null,'nmtotal_DecVie_InventarioGestionConocimiento')", funconclick: null},
                {campo: 'costodirecto', tipo: 'int', nullable: true, llave: '', etiqueta: 'Costo Directo', placeholder: 'Costo Directo', title: '', numcols: 2, maxlength: 12, funconchange: "SumarTotales('nmgastos_DecVie_InventarioGestionConocimiento', 'nmcostodirecto_DecVie_InventarioGestionConocimiento',null,null,'nmtotal_DecVie_InventarioGestionConocimiento')", funconclick: null}
                
            ],
            [   
                {campo: 'total', tipo: 'int', nullable: true, llave: '', etiqueta: 'Total', placeholder: 'Total', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null},
                {campo: 'id_insumo', tipo: 'select', nullable: true, llave: '', etiqueta: 'Insumo', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'id_ahorro', tipo: 'select', nullable: true, llave: '', etiqueta: 'Ahorro', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'fechavaloracion', tipo: 'date', nullable: true, llave: '', etiqueta: 'Fecha Valoración', placeholder: '', title: 'Fecha Valoración', numcols: 2, maxlength: 0, funconchange: null, funconclick: null},
                {campo: 'id_obsolescenciaconcepto', tipo: 'select', nullable: true, llave: '', etiqueta: 'Obsolescencia Concepto', placeholder: '', title: '', numcols: 2, funconchange: null, funconclick: null},
                {campo: 'presupuestoejecutado', tipo: 'int', nullable: true, llave: '', etiqueta: 'Presupuesto Ejecutado', placeholder: 'Presupuesto Ejecutado', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null}
            ],
            [   
                {campo: 'designadogestion', tipo: 'int', nullable: true, llave: '', etiqueta: 'Designado Para Gestión', placeholder: 'Designado Para Gestión', title: '', numcols: 2, maxlength: 12, funconchange: null, funconclick: null}
               
            ]
        ];

        this.CampoLlave = 'id_invgesconocimiento';
        this.Nombre = 'DecVie_InventarioGestionConocimiento';
        this.ControllerName = 'DecVie_InventarioGestionConocimiento';
        this.MethodGet = 'GetDecVie_InventarioGestionConocimientoDetails';
        this.MethodUpdate = 'UpdateDecVie_InventarioGestionConocimiento';
        this.MethodInsert = 'InsertDecVie_InventarioGestionConocimiento';
        //this.MethodValidarDuplicado = 'GetDecVie_InventarioGestionConocimientoNumero';
        this.ParamGetName1 = 'id_invgesconocimiento';
        this.ParamGetName2 = '';
        this.ParamGetName3 = '';
        //this.ParamDuplicadoName = 'cd_numradicacion';
        this.ObjDatos = null;
        this.FormEdicion = 'formDecVie_InventarioGestionConocimientoDetalle';
        this.IsModal = false;
        this.DatosNullEdicion = true;

   // }
}