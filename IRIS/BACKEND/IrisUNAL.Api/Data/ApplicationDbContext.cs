using IrisUNAL.Api.Entities;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Decanatura;
using IrisUNAL.Api.Models.Hermes;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.Publicacion;
using IrisUNAL.Api.Models.UGI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(nameOrConnectionString: "IrisConnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }

        public virtual DbSet<Area_Academica> Area_Academica { get; set; }
        public virtual DbSet<Dependencia> dependecia { get; set; }
        public virtual DbSet<Concepto_UGI> concepto_ugi { get; set; }
        public virtual DbSet<Estado_Tarea> estado_tarea { get; set; }
        public virtual DbSet<Literal_UGI> literal_ugi { get; set; }
        public virtual DbSet<Semestre> semestre { get; set; }
        public virtual DbSet<Tipo_Documento> tipo_documento { get; set; }
        public virtual DbSet<Tipo_Persona> tipo_persona { get; set; }
        public virtual DbSet<Persona_Ciudad> persona_ciudad { get; set; }
        public virtual DbSet<Persona_Formacion> persona_formacion { get; set; }
        public virtual DbSet<Persona_Genero> persona_genero { get; set; }
        public virtual DbSet<Persona_Pais> persona_pais { get; set; }
        public virtual DbSet<Persona_TipoEntidad> persona_tipoentidad { get; set; }
        public virtual DbSet<Persona_TipoServicio> persona_tiposervicio { get; set; }
        public virtual DbSet<Persona_TituloAlto> persona_tituloalto { get; set; }
        public virtual DbSet<Persona> persona { get; set; }
        public virtual DbSet<Persona_Calificacion> persona_calificacion { get; set; }
        public virtual DbSet<Distribucion_Fondo_UGI> distribucion_fondo_ugi { get; set; }
        public virtual DbSet<SeguimientoHistorico_Conceptos_Literales_UGI> seguimientohistorico_conceptos_literales_ugi { get; set; }
        public virtual DbSet<Propuesta_AprobacionConsejoFacultad> propuesta_aprobacionconsejofacultad { get; set; }
        public virtual DbSet<Propuesta_AvalConsejoFacultad> propuesta_avalconsejofacultad { get; set; }
        public virtual DbSet<Propuesta_AvalInterno> propuesta_avalinterno { get; set; }
        public virtual DbSet<Propuesta_Cobertura> propuesta_cobertura { get; set; }
        public virtual DbSet<Propuesta_EstadoPropuesta> propuesta_estadopropuesta { get; set; }
        public virtual DbSet<Propuesta_EstadoSuscripcionContratoConvenio> propuesta_estadosuscripcioncontratoconvenio { get; set; }
        public virtual DbSet<Propuesta_Modalidad> propuesta_modalidad { get; set; }
        public virtual DbSet<Propuesta_OrigenPropuesta> propuesta_origenpropuesta { get; set; }
        public virtual DbSet<Propuesta_TipoModificacion> propuesta_tipomodificacion { get; set; }
        public virtual DbSet<Propuesta_TipoPropuesta> propuesta_tipopropuesta { get; set; }
        public virtual DbSet<Propuesta_SuscripcionGarantia> propuesta_suscripciongarantia { get; set; }
        public virtual DbSet<Propuesta_SuscripcionMinuta> propuesta_suscripcionminuta { get; set; }
        public virtual DbSet<Propuesta_ModificacionMinuta> propuesta_modificacionminuta { get; set; }
        public virtual DbSet<Propuesta_ModificacionGarantia> propuesta_modificaciongarantia { get; set; }
        public virtual DbSet<Proyectos_TipoProyecto> proyectos_tipoproyecto { get; set; }
        public virtual DbSet<Proyectos_NaturalezaProyecto> proyectos_naturalezaproyecto { get; set; }
        public virtual DbSet<Proyectos_EstadoObligacion> proyectos_estadoobligacion { get; set; }
        public virtual DbSet<Proyectos_EstadoContrato> proyectos_estadocontrato { get; set; }
        public virtual DbSet<Proyectos_AlcanceProyecto> proyectos_alcanceproyecto { get; set; }
        public virtual DbSet<Proyectos_NuevoProducto> proyectos_nuevoproducto { get; set; }
        public virtual DbSet<Proyectos_Obligaciones> proyectos_obligaciones { get; set; }
        public virtual DbSet<Proyectos_ProyectosObservaciones> proyectos_proyectosobservaciones { get; set; }
        public virtual DbSet<Proyectos_AsignacionProyecto> proyectos_asignacionproyecto { get; set; }
        public virtual DbSet<Seguimiento_Partida> seguimiento_partida { get; set; }
        public virtual DbSet<Seguimiento_Rubro> seguimiento_rubro { get; set; }
        public virtual DbSet<Seguimiento_Concepto> seguimiento_concepto { get; set; }
        public virtual DbSet<Seguimiento_RelacionVinculo> seguimiento_relacionvinculo { get; set; }
        public virtual DbSet<Seguimiento_Desembolso> seguimiento_desembolso { get; set; }
        public virtual DbSet<Seguimiento_DetalleRubro> seguimiento_detallerubro { get; set; }
        public virtual DbSet<Seguimiento_DetalladoDesembolso> seguimiento_detalladodesembolso { get; set; }
        public virtual DbSet<Seguimiento_CrearGasto> seguimiento_creargasto { get; set; }
        public virtual DbSet<Seguimiento_FinancieroExcel> seguimiento_financieroexcel { get; set; }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<RolMenu> rolmenu { get; set; }
        public virtual DbSet<Menu> menu { get; set; }
        public virtual DbSet<Liquidacion_InformeFinalProy> liquidacion_informefinalproy { get; set; }
        public virtual DbSet<Propuesta> propuesta { get; set; }
        public virtual DbSet<Investigacion_CrearLinea> investigacion_crearlinea { get; set; }
        public virtual DbSet<Investigacion_CrearGrupo> investigacion_creargrupo { get; set; }
        public virtual DbSet<Investigacion_Producto> investigacion_producto { get; set; }
        public virtual DbSet<Investigacion_Linea> investigacion_linea { get; set; }
        
        public virtual DbSet<Investigacion_ActoAdmonContrapartida> investigacion_actoadmoncontrapartida { get; set; }
        public virtual DbSet<Investigacion_Contrapartida> investigacion_contrapartida { get; set; }
        public virtual DbSet<Investigacion_Publicacion> investigacion_publicacion { get; set; }
        public virtual DbSet<Investigacion_Seguimiento> investigacion_seguimiento { get; set; }
        public virtual DbSet<Seguimiento_AplicarPago> seguimiento_aplicarpago { get; set; }
        public virtual DbSet<Liquidacion_Finalizacion> liquidacion_finalizacion { get; set; }
        public virtual DbSet<Suscripcion_Liquidacion> suscripcion_liquidacion { get; set; }
        public virtual DbSet<RolMenuOpciones> rolmenuopciones { get; set; }
        public virtual DbSet<TipoOpcion> tipoopcion { get; set; }
        public virtual DbSet<Proyecto_Persona> proyecto_persona { get; set; }
        public virtual DbSet<Proyecto_Observacion> proyecto_observacion { get; set; }
        public virtual DbSet<Actualizacion_ModuloR> actualizacion_modulor { get; set; }
        public virtual DbSet<Contrapartidas> contrapartidas { get; set; }
        public virtual DbSet<Productos> productos { get; set; }
        public virtual DbSet<Propuesta_TipoUsuario> propuesta_tipousuario { get; set; }
        public virtual DbSet<Tareas> tareas { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<LTLogApp> ltlogapp { get; set; }
        public virtual DbSet<Propuesta_Entidad> propuesta_entidad { get; set; }
        public virtual DbSet<Publicaciones_AreaCurricular> publicaciones_areacurricular { get; set; }
        public virtual DbSet<Publicaciones_CarProyEditorial> publicaciones_carproyeditorial { get; set; }
        public virtual DbSet<Publicaciones_Coedicion> publicaciones_coedicion { get; set; }
        public virtual DbSet<Publicaciones_Coleccion> publicaciones_coleccion { get; set; }
        public virtual DbSet<Publicaciones_Complejidad> publicaciones_complejidad { get; set; }
        public virtual DbSet<Publicaciones_Concepto> publicaciones_concepto { get; set; }
        public virtual DbSet<Publicaciones_CostosOrigenContrato> publicaciones_costosorigencontrato { get; set; }
        public virtual DbSet<Publicaciones_CostosServicioEditorial> publicaciones_costosservicioeditorial { get; set; }
        public virtual DbSet<Publicaciones_DepositoControlActa> publicaciones_depositocontrolacta { get; set; }
        public virtual DbSet<Publicaciones_DepositoControlCertVentas> publicaciones_depositocontrolcertventas { get; set; }
        public virtual DbSet<Publicaciones_DepositoControlIngresoVentas> publicaciones_depositocontrolingresoventas { get; set; }
        public virtual DbSet<Publicaciones_DepositoControlInventarioBodega> publicaciones_depositocontrolinventariobodega { get; set; }
        public virtual DbSet<Publicaciones_DepositoControlInventarioMovimientos> publicaciones_depositocontrolinventariomovimientos { get; set; }
        public virtual DbSet<Publicaciones_DepositoControlRepVentas> publicaciones_depositocontrolrepventas { get; set; }
        public virtual DbSet<Publicaciones_DepositoDistribucionComercial> publicaciones_depositodistribucioncomercial { get; set; }
        public virtual DbSet<Publicaciones_DepositoDistribucionComercialOtros> publicaciones_depositodistribucioncomercialotros { get; set; }
        public virtual DbSet<Publicaciones_DepositoDistribucionParam> publicaciones_depositodistribucionparam { get; set; }
        public virtual DbSet<Publicaciones_DepositoDistribucionTitulo> publicaciones_depositodistribuciontitulo { get; set; }
        public virtual DbSet<Publicaciones_DepositoPrecios> publicaciones_depositoprecios { get; set; }
        public virtual DbSet<Publicaciones_DepositoResolucion> publicaciones_depositoresolucion { get; set; }
        public virtual DbSet<Publicaciones_DepositoTipoMov> publicaciones_depositotipomov { get; set; }
        public virtual DbSet <Publicaciones_DepositoTipoPub> publicaciones_depositotipopub { get; set; }
        public virtual DbSet<Publicaciones_DiagFinalParam> publicaciones_diagfinalparam { get; set; }
        public virtual DbSet<Publicaciones_DiagFinalTitulo> publicaciones_diagfinaltitulo { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionActividadInvitados> publicaciones_DivulgacionActividadInvitados { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionActividadNombre> publicaciones_divulgacionactividadnombre { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionCierre> publicaciones_divulgacioncierre { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionMailling> publicaciones_divulgacionmailling { get; set; }
        public virtual DbSet <Publicaciones_DivulgacionMedios> publicaciones_divulgacionmedios { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionParam> publicaciones_divulgacionparam { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionTipoMedio> publicaciones_divulgaciontipomedio { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionTitulo> publicaciones_divulgaciontitulo { get; set; }
        public virtual DbSet<Publicaciones_EdicionParam> publicaciones_edicionparam { get; set; }
        public virtual DbSet<Publicaciones_EstadoConcepto> publicaciones_estadoconcepto { get; set; }
        public virtual DbSet<Publicaciones_EstadoCorab> publicaciones_estadocorab { get; set; }
        public virtual DbSet<Publicaciones_EstadoCorreccion> publicaciones_estadocorreccion { get; set; }
        public virtual DbSet<Publicaciones_EstadoCubierta> publicaciones_estadocubierta { get; set; }
        public virtual DbSet<Publicaciones_EstadoDiagramacion> publicaciones_estadodiagramacion { get; set; }
        public virtual DbSet<Publicaciones_EstadoEvaluador> publicaciones_estadoevaluador { get; set; }
        public virtual DbSet<Publicaciones_EvalGenerada> publicaciones_evalgenerada { get; set; }
        public virtual DbSet<Publicaciones_EvaluacionInicial> publicaciones_evaluacioninicial { get; set; }
        public virtual DbSet<Publicaciones_FormatoDistribucion> publicaciones_formatodistribucion { get; set; }
        public virtual DbSet<Publicaciones_Hermes> publicaciones_hermes { get; set; }
        public virtual DbSet<Publicaciones_Idioma> publicaciones_idioma { get; set; }
        public virtual DbSet<Publicaciones_ImpresionEncuadernacion> publicaciones_impresionencuadernacion { get; set; }
        public virtual DbSet<Funcionario> funcionario { get; set; }
        public virtual DbSet<Propuestaseguimiento> propuestaseguimiento { get; set; }
        public virtual DbSet<Publicaciones_ImpresionGramaje> publicaciones_impresiongramaje { get; set; }
        public virtual DbSet<Publicaciones_ImpresionPapel> publicaciones_impresionpapel { get; set; }
        public virtual DbSet<Publicaciones_ImpresionTintasTaco> publicaciones_impresiontintastaco { get; set; }
        public virtual DbSet<Publicaciones_ImpresionTipo> publicaciones_impresiontipo { get; set; }
        public virtual DbSet<Publicaciones_InformacionPago> publicaciones_informacionpago { get; set; }
        public virtual DbSet<Publicaciones_OrigenManuscrito> publicaciones_origenmanuscrito { get; set; }
        public virtual DbSet<Publicaciones_ProveedorServicio> publicaciones_proveedorservicio { get; set; }
        public virtual DbSet<Publicaciones_Resena> publicaciones_resena { get; set; }
        public virtual DbSet<Publicaciones_ConceptoEditorial> publicaciones_conceptoeditorial { get; set; }
        public virtual DbSet<Publicaciones_Responsable> publicaciones_responsable { get; set; }
        public virtual DbSet<Publicaciones_RolEditorial> publicaciones_roleditorial { get; set; }
        public virtual DbSet<Publicaciones_TipoCorreccion> publicaciones_tipocorreccion { get; set; }
        public virtual DbSet<Publicaciones_TipoDiagramacion> publicaciones_tipodiagramacion { get; set; }
        public virtual DbSet<Publicaciones_TipoEvaluador> publicaciones_tipoevaluador { get; set; }
        public virtual DbSet<Publicaciones_Tipologia> publicaciones_tipologia { get; set; }
        public virtual DbSet<Publicaciones_TipoObra> publicaciones_tipoobra { get; set; }
        public virtual DbSet<Publicaciones_Autores> publicaciones_autores { get; set; }
        public virtual DbSet<Publicaciones_CesionDerechos> publicaciones_cesionderechos { get; set; }
        public virtual DbSet<Publicaciones_CierreEdicion> publicaciones_cierreedicion { get; set; }
        public virtual DbSet<Publicaciones_CostosEjecucionContractual> publicaciones_costosejecucioncontractual { get; set; }
        public virtual DbSet<Publicaciones_CostosParametrosPresupuestales> publicaciones_costosparametrospresupuestales { get; set; }
        public virtual DbSet<Publicaciones_Deposito> publicaciones_deposito { get; set; }
        public virtual DbSet<Publicaciones_DepositoDistribucion> publicaciones_depositodistribucion { get; set; }
        public virtual DbSet<Publicaciones_Designacion> publicaciones_designacion { get; set; }
        public virtual DbSet<Publicaciones_DiagFinal> publicaciones_diagfinal { get; set; }
        public virtual DbSet<Publicaciones_Diagramacion> publicaciones_diagramacion { get; set; }
        public virtual DbSet<Publicaciones_Digitalizacion> publicaciones_digitalizacion { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionActividad> publicaciones_divulgacionactividad { get; set; }
        public virtual DbSet<Publicaciones_CrearPublicacion> publicaciones_crearpublicacion { get; set; }
        public virtual DbSet<Publicaciones_DepositoControl> publicaciones_depositocontrol { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionHerramienta> publicaciones_divulgacionherramienta { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionPlan> publicaciones_divulgacionplan { get; set; }
        public virtual DbSet<Publicaciones_EstadoCore> publicaciones_estadocore { get; set; }
        public virtual DbSet<Publicaciones_EstadoCorParam> publicaciones_estadocorparam { get; set; }
        public virtual DbSet<Publicaciones_Evaluadores> publicaciones_evaluadores { get; set; }
        public virtual DbSet <Publicaciones_EvalConcepto> publicaciones_evalconcepto { get; set; }
        public virtual DbSet<Publicaciones_Evaluaciones> publicaciones_evaluaciones { get; set; }
        public virtual DbSet<Publicaciones_Impresion> publicaciones_impresion { get; set; }
        public virtual DbSet<DecVie_AlcanceSolicitud> decvie_alcancesolicitud { get; set; }
        public virtual DbSet<DecVie_AsuntosDisciplinarios> decvie_asuntosdisciplinarios { get; set; }
        public virtual DbSet<DecVie_CicloFinancieroPostProgram> decvie_ciclofinancieropostprogram { get; set; }
        public virtual DbSet<DecVie_Concepto> decvie_concepto { get; set; }
        //Añadido para radicacion Adda
        public virtual DbSet<DecVie_RadicadorTec> decvie_radicadortec { get; set; }
        public virtual DbSet<DecVie_ConceptoDecanatura> decvie_conceptodecanatura { get; set; }
        public virtual DbSet<DecVie_Consecutivo> decvie_consecutivo { get; set; }
        public virtual DbSet<DecVie_ControlFinanciero> decvie_controlfinanciero { get; set; }
        public virtual DbSet<DecVie_ControlFinancieroGastos> decvie_controlfinancierogastos { get; set; }
        public virtual DbSet<DecVie_ControlFinancieroOperativos> decvie_controlfinancierooperativos { get; set; }
        public virtual DbSet<DecVie_ControlFinancieroTipoOperativo> decvie_controlfinancierotipooperativo { get; set; }
        public virtual DbSet<DecVie_CuerposColegiados> decvie_cuerposcolegiados { get; set; }
        public virtual DbSet<DecVie_Dependencia> decvie_dependencia { get; set; }
        public virtual DbSet<DecVie_DerechosPeticion> decvie_derechospeticion { get; set; }
        public virtual DbSet<DecVie_DerechosPeticionEstado> decvie_derechospeticionestado { get; set; }
        public virtual DbSet<DecVie_DerechosPeticionOficina> decvie_derechospeticionoficina { get; set; }
        public virtual DbSet<DecVie_Estado> decvie_estado { get; set; }
        public virtual DbSet<DecVie_EstadoPreAval> decvie_estadopreaval { get; set; }
        public virtual DbSet<DecVie_Instancias> decvie_instancias { get; set; }
        public virtual DbSet<DecVie_InventarioConocimientoContratante> decvie_inventarioconocimientocontratante { get; set; }
        public virtual DbSet<DecVie_InventarioConocimientoEnfasis> decvie_inventarioconocimientoenfasis { get; set; }
        public virtual DbSet<DecVie_InventarioConocimientoImpacto> decvie_inventarioconocimientoimpacto { get; set; }
        public virtual DbSet<DecVie_InventarioConocimientoSoporte> decvie_inventarioconocimientosoporte { get; set; }
        public virtual DbSet<DecVie_InventarioConocimientoTipologia> decvie_inventarioconocimientotipologia { get; set; }
        public virtual DbSet<DecVie_InventarioGestionConocimiento> decvie_inventariogestionconocimiento { get; set; }
        public virtual DbSet<DecVie_InventarioObsolescenciaConcepto> decvie_inventarioobsolescenciaconcepto { get; set; }
        public virtual DbSet<DecVie_InventarioRegistroPatenteTipo> decvie_inventarioregistropatentetipo { get; set; }
        public virtual DbSet<DecVie_InventarioUsoAmpliadoAhorro> decvie_inventariousoampliadoahorro { get; set; }
        public virtual DbSet<DecVie_InventarioUsoAmpliadoInsumo> decvie_inventariousoampliadoinsumo { get; set; }
        public virtual DbSet<DecVie_Macroproceso> decvie_macroproceso { get; set; }
        public virtual DbSet<DecVie_OrigenSolicitud> decvie_origensolicitud { get; set; }
        public virtual DbSet<DecVie_PlanAccionActividades> decvie_planaccionactividades { get; set; }
        public virtual DbSet<DecVie_PlanAccionEjeEstrategico> decvie_planaccionejeestrategico { get; set; }
        public virtual DbSet<DecVie_PlanaccionFunciones> decvie_planaccionfunciones { get; set; }
        public virtual DbSet<DecVie_PlanAccionIndicadoresEstrategicos> decvie_planaccionindicadoresestrategicos { get; set; }
        public virtual DbSet<DecVie_PlanAccionLineaPolitica> decvie_planaccionlineapolitica { get; set; }
        public virtual DbSet<DecVie_PlanAccionMatrizIndicadores> decvie_planaccionmatrizindicadores { get; set; }
        public virtual DbSet<DecVie_PlanAccionMatryoshka> decvie_planaccionmatryoshka { get; set; }
        public virtual DbSet<DecVie_PlanAccionMeta> decvie_planaccionmeta { get; set; }
        public virtual DbSet<DecVie_PlanAccionNuevosIndicadores> decvie_planaccionnuevosindicadores { get; set; }
        public virtual DbSet<DecVie_PlanAccionObjetivoDependencia> decvie_planaccionobjetivodependencia { get; set; }
        public virtual DbSet<DecVie_PlanAccionObjetivoEstrategico> decvie_planaccionobjetivoestrategico { get; set; }
        public virtual DbSet<DecVie_PlanAccionObjetivosPgdVriSede> decvie_planaccionobjetivospgdvrisede { get; set; }
        public virtual DbSet<DecVie_PlanAccionProgramaFdcps> decvie_planaccionprogramafdcps { get; set; }
        public virtual DbSet<DecVie_PlanAccionProgramaPgd> decvie_planaccionprogramapgd { get; set; }
        public virtual DbSet<DecVie_PlanAccionTipoIndicador> decvie_planacciontipoindicador { get; set; }
        public virtual DbSet<DecVie_PreAval> decvie_preaval { get; set; }
        public virtual DbSet<DecVie_RadicadorCor> decvie_radicadorcor { get; set; }
        public virtual DbSet<DecVie_RevSigep> decvie_revsigep { get; set; }
        public virtual DbSet<DecVie_SerieDocumental> decvie_seriedocumental { get; set; }
        public virtual DbSet<DecVie_SubSerieDoc> decvie_subseriedoc { get; set; }
        public virtual DbSet<DecVie_TipoDocContractuales> decvie_tipodoccontractuales { get; set; }
        public virtual DbSet<DecVie_Tipologia> decvie_tipologia { get; set; }
        public virtual DbSet<Proyectos_TipoProducto> proyectos_tipoproducto { get; set; }
        public virtual DbSet<Proyectos_EstadoProducto> proyectos_estadoproducto { get; set; }
        public virtual DbSet<Seguimiento_Acuerdo> seguimiento_acuerdo { get; set; }
        public virtual DbSet<DecVie_ActosAdministrativosTipo> decvie_actosadministrativostipo { get; set; }
        public virtual DbSet<DecVie_ActosAdministrativosEstado> decvie_actosadministrativosestado { get; set; }
        public virtual DbSet<DecVie_ActosAdministrativos> decvie_actosadministrativos { get; set; }
        public virtual DbSet<Publicaciones_EvalObservaciones> publicaciones_evalobservaciones { get; set; }
        public virtual DbSet<DecVie_Colegiados> decvie_colegiados { get; set; }
        public virtual DbSet<DecVie_PlanAccionAlcanceAnno> decvie_planaccionalcanceanno { get; set; }
        public virtual DbSet<DecVie_PlanAccionAlcance> decvie_planaccionalcance { get; set; }
        public virtual DbSet<Correspondencia_PrefijoConsecutivo> correspondencia_prefijoconsecutivo { get; set; }
        public virtual DbSet<Publicaciones_DepositoDisposicionLegal> publicaciones_depositodisposicionlegal { get; set; }
        public virtual DbSet<Consecutivo_Annio> consecutivo_annio { get; set; }
        public virtual DbSet<Publicaciones_Distribuidor> publicaciones_distribuidor { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionInicio> publicaciones_divulgacioninicio { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionPlanActividad> publicaciones_divulgacionplanactividad { get; set; }
        public virtual DbSet<Publicaciones_DivulgacionActividadFeriaEvento> publicaciones_divulgacionactividadferiaevento { get; set; }
        public virtual DbSet<Decvie_Matryoshka> decvie_matryoshka { get; set; }
        public virtual DbSet<Decvie_MatryoshkaEjeEstrategico> decvie_matryoshkaejeestrategico { get; set; }
        public virtual DbSet<Decvie_MatryoshkaProgramaPgd> decvie_matryoshkaprogramapgd { get; set; }
        public virtual DbSet<Decvie_MatryoshkaEstrategia> decvie_matryoshkaestrategia { get; set; }
        public virtual DbSet<Decvie_MatryoshkaObjetivoPgd> decvie_matryoshkaobjetivopgd { get; set; }
        public virtual DbSet<Decvie_MatryoshkaObjetivoDep> decvie_matryoshkaobjetivodep { get; set; }
        public virtual DbSet<Decvie_MatryoshkaMetaDep> decvie_matryoshkametadep { get; set; }
        public virtual DbSet<Decvie_MatryoshkaActividadDep> decvie_matryoshkaactividaddep { get; set; }
        public virtual DbSet<Decvie_MatryoshkaIndicadorEstrategico> decvie_matryoshkaindicadorestrategico { get; set; }
        public virtual DbSet<Decvie_MatryoshkaNuevoIndicador> decvie_matryoshkanuevoindicador { get; set; }
        public virtual DbSet<Decvie_CicloFinanciero> decvie_ciclofinanciero { get; set; }
        public virtual DbSet<Decvie_CicloFinancieroProgramaPostgrado> decvie_ciclofinancieroprogramapostgrado { get; set; }
        public virtual DbSet<Tareas_Modulo> tareas_modulo { get; set; }
        public virtual DbSet<Tareas_Seguimiento> tareas_seguimiento { get; set; }
        public virtual DbSet<Alerta_Seguimiento> alerta_seguimiento { get; set; }
        //public virtual DbSet<UGI_Semestre> ugi_semestre { get; set; }
        public virtual DbSet<UGI_LiteralSemestre> ugi_literalsemestre { get; set; }
        public virtual DbSet<UGI_ConceptoSemestre> ugi_conceptosemestre { get; set; }
        public virtual DbSet<Convocatoria_Alcance> convocatoria_alcance { get; set; }
        public virtual DbSet<Convocatoria_EstadoCnv> convocatoria_estadocnv { get; set; }
        public virtual DbSet<Convocatoria_FuenteCnv> convocatoria_fuentecnv { get; set; }
        public virtual DbSet<Convocatoria> convocatoria { get; set; }
        public virtual DbSet<Convocatoria_RequerimientoRequisito> convocatoria_requerimientorequisito { get; set; }
        public virtual DbSet<Convocatoria_RecursoParticipante> convocatoria_recursoparticipante { get; set; }
        public virtual DbSet<Convocatoria_Interesados> convocatoria_interesados { get; set; }
        public virtual DbSet<Investigacion_EstadoProyecto> investigacion_estadoproyecto { get; set; }
        public virtual DbSet<MatrizFinanciera_Vigencia> matrizfinanciera_vigencia { get; set; }
        public virtual DbSet<MatrizFinanciera_TipoOperativo> matrizfinanciera_tipooperativo { get; set; }
        public virtual DbSet<MatrizFinanciera> matrizfinanciera { get; set; }
        public virtual DbSet<MatrizFinanciera_GastoApoyo> matrizfinanciera_gastoapoyo { get; set; }
        public virtual DbSet<MatrizFinanciera_GastoOperativo> matrizfinanciera_gastooperativo { get; set; }
        public virtual DbSet<Investigacion_Obligacion> investigacion_obligacion { get; set; }
        public virtual DbSet<Investigacion_Observacion> investigacion_observacion { get; set; }
        public virtual DbSet<Investigacion_Desembolso> investigacion_desembolso { get; set; }
        public virtual DbSet<Investigacion_Gasto> investigacion_gasto { get; set; }
        public virtual DbSet<Investigacion_Aplicarpago> investigacion_aplicarpago { get; set; }
        public virtual DbSet<HermesProyectoInvestigacion> hermesproyectoinvestigacion { get; set; }
        public virtual DbSet<HermesProyectoExtension> hermesproyectoextension { get; set; }
        public virtual DbSet<Publicacion_Desembolso> publicacion_desembolso { get; set; }
        public virtual DbSet<Publicacion_Gasto> publicacion_gasto { get; set; }
        public virtual DbSet<Publicacion_Aplicarpago> publicacion_aplicarpago { get; set; }
        public virtual DbSet<Publicaciones_EstadoManuscrito> publicaciones_estadomanuscritos { get; set; }

        //CAMBIO ADDA VARGAS
        public virtual DbSet<Investigacion_CrearProyecto> investigacion_crearproyecto { get; set; }
        public DbSet<Investigacion_Resolucion> Investigacion_Resolucion { get; set; }
        public DbSet<UGI_Semestre> UGI_Semestre { get; set; }
        public DbSet<DecVie_CertificadosTec> decvie_certificadostec { get; set; }

        //Cambio a radicador 29 de julio
        public DbSet<DecVie_RadicadorTecAuditoria> decvie_radicadortec_auditoria { get; set; }

        //Cambio para Aplicacion de Solicitud Certificados
        public virtual DbSet<Solicitud_CertificadoTrazabilidad> certificados_solicitud_trazabilidad { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investigacion_CrearProyecto>()
                .HasRequired(p => p.ObjPersona)
                .WithMany()
                .HasForeignKey(p => p.id_persona); // Relación entre proyecto y persona usando id_persona

            modelBuilder.Entity<Investigacion_Resolucion>()
                .HasRequired(r => r.UGI_Semestre)
                .WithMany(s => s.Resoluciones)
                .HasForeignKey(r => r.resolucion); // Relación entre resoluciones y semestre

            // Relación entre DecVie_RadicadorTec y Dependencia (ObjDependenciaDestino) - Requerida
            modelBuilder.Entity<DecVie_RadicadorTec>()
                .HasRequired(d => d.ObjDependenciaDestino)
                .WithMany()
                .HasForeignKey(d => d.dependenciadestino);

            // Relación entre DecVie_RadicadorTec y Correspondencia_PrefijoConsecutivo (Objprefijo) - Requerida
            modelBuilder.Entity<DecVie_RadicadorTec>()
                .HasRequired(d => d.Objprefijo)
                .WithMany()
                .HasForeignKey(d => d.id_prefijoconsecutivo);

            modelBuilder.Entity<DecVie_CertificadosTec>()
                .HasRequired(c => c.ObjDependencia)  // Relación requerida con la entidad Dependencia
                .WithMany()
                .HasForeignKey(c => c.id_depend);

            base.OnModelCreating(modelBuilder);
        }

    }

}