const _ = require('lodash');

exports.USER_STATES = {
  active: "ACTIVO",
  inactive: "DESHABILITADO",
  pendingActivation: "PENDIENTE DE REVISION",
  incomplete: "INCOMPLETO"
}

exports.PROCESS_STATES = {
  REQUESTED: "Solicitud Visita",
  IN_VISIT: "En Visita",
  VISIT_VALIDATION: "Revision de la Visita",
  PREVENTIVE_SUSPENSION: "Suspencion Preventiva",
  PRELIMINARY_INVESTIGATION: "Indagacion preliminar",
  //LEGAL_REVIEW: "Revision Juridica",
  //SANCTION_PROCESS: "Proceso Administrativo Sancionatorio",
  INDICTMENT: "Auto pliego de cargos y notificacion",
  EVIDENTIARY_STAGE: "Etapa Probatoria",
  PLEADINGS_STAGE: "Etapa de Alegatos",
  PENALTY_RESOLUTION: "Resolucion Sancionatoria",
  FOLLOW_UP: "Seguimiento Acto Administrativo Sancionatorio",
  TO_ARCHIVE: "En Revision antes de cierre",
  ARCHIVED: "Archivado",
}

exports.VISIT_STATES = {
  REQUESTED: "Visita Solicitada",
  ASSIGNED: "Asignada",
  ENTRY: "Entrada Denegada",
  //IN_PROCESS: "En Proceso",
  VALIDATION: "Validacion de Licencias",
  REPORT: "Creacion del informe",
  FINISHED: "Finalizada",
  REPROGRAMED: "Reprogramada"
}

exports.IDENTIFICATION_TYPES={
  CC: "Cedula de ciudadanía",
  CE: "Cedula de extranjería"
}

exports.VISIT_TYPES = {
  INSPEC: "Inspección de obra",
  SUSPEN: "Suspensión de obra",
  //INSPEC_IP: "Inspección de obra como Indagacion Preliminar",
}

exports.VISIT_CAUSAL_TYPES = {
  SPIPCC: "Solicitud de profesional del IPCC",
  PQRS: "PQRS",
  PJ: "Proceso Juridico",
  RR: "Resultado del Recorrido"
}

exports.VISIT_BUILDING_TYPE = {
  MNT: "Mantenimiento",
  CONS: "Consolidación",
  RECP: "Recuperación",
  ACON: "Acondicionamiento",
  SUBD: "Subdivición",
  AMP: "Ampliación",
  REST: "Reestructuración",
}

exports.visitInterventionTipe ={
  REST_MN: "Restauración monumental",
  REST_TIP: "Restauración tipologica",
  REST_FAC: "Restauración de Fachada y adecuación interna",
  REST_ADE: "Adecuación",
  BUILDNG_NEW:"Edificación nueva",
  BUILDNG_NEW2: "Edificación nueva 2 pisos",
  BUILDNG_NEW1: "Edificación nueva 1 piso",
  RECOVER_FAC: "Recuperación de paramento",
}


exports.ACTIONS = {
  createProcess: "Crear proceso",
  modifyProcess: "Modificar proceso",
  assignRole: "Asignar rol",
  createVisit: "Crear visita",
  requestVisit: "Solicitar visita",
  assignVisit: "Asignar visita",
  modifyVisit: "Modificar visita",
  uploadFile: "Cargar informe a visita",
  uploadFileToArchive: "Cargar documento a Archivo",
  generateDocument: "Generar Oficio",
  manageUsers: "Administrar usuarios",
  readEvents: "Lectura de eventos",
  readVisits: "Lectura de visitas",
  readFiles: "Lectura de archivos",
}

exports.ROLES = {
  ASSIST: {
    title: "Asistente",
    actions: Object.values(_.pick(this.ACTIONS, ["createVisit", "assignRole", "assignVisit", "generateDocument", "uploadFileToArchive", "createProcess", "modifyVisit", "readFiles"]))//"uploadFile"
  },
  LEGAL: {
    title: "Juridico",
    actions:  Object.values(_.pick(this.ACTIONS, ["requestVisit", "modifyProcess", "generateDocument", "uploadFile", "readFiles"]))
  },
  TECHNIC: {
    title: "Tecnico",
    actions:  Object.values(_.pick(this.ACTIONS, ["createVisit", "uploadFile", "modifyVisit", "requestVisit", "readFiles"]))
  },
  ADMIN: {
    title: "Administrador",
    actions: Object.values({...this.ACTIONS})
  }
}



/**
flujo = "solicitud visita"-> "formulario asignacion" -> "en visita" -> "archivado"
                                                                    -> "revision juridica" -> "proceso sancionatorio" -> "en revision" -> "archivado"
*/

