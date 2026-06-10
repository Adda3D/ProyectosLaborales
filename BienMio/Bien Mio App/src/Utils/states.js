import _ from "lodash";

export const USER_STATES = {
  active: "ACTIVO",
  inactive: "DESHABILITADO",
  // pendingActivation: "PENDIENTE DE REVISION",
  // incomplete: "INCOMPLETO"
};

export const PROCESS_STATES = {
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
};

export const VISIT_STATES = {
  REQUESTED: "Visita Solicitada",
  ASSIGNED: "Asignada",
  ENTRY: "Entrada Denegada",
  IN_PROCESS: "En Proceso",
  VALIDATION: "Validacion de Licencias",
  REPORT: "Creacion del informe",
  FINISHED: "Finalizada",
  REPROGRAMED: "Reprogramada",
};

export const visitNextState = (visit) => {
  if (visit) {
    if (visit.type === VISIT_TYPES.SUSPEN) {
      switch (visit.status) {
        case VISIT_STATES.REQUESTED:
          return VISIT_STATES.ASSIGNED;
        case VISIT_STATES.ASSIGNED:
          return VISIT_STATES.REPORT;
        case VISIT_STATES.REPORT:
          return VISIT_STATES.FINISHED;
        case VISIT_STATES.REPROGRAMED:
          return VISIT_STATES.VALIDATION;
        case VISIT_STATES.ENTRY:
          return VISIT_STATES.REPORT;
        default:
          return null;
      }
    } else {
      switch (visit.status) {
        case VISIT_STATES.REQUESTED:
          return VISIT_STATES.ASSIGNED;
        case VISIT_STATES.ASSIGNED:
          //   return VISIT_STATES.IN_PROCESS;
          // case VISIT_STATES.IN_PROCESS:
          return VISIT_STATES.VALIDATION;
        case VISIT_STATES.VALIDATION:
          return VISIT_STATES.REPORT;
        case VISIT_STATES.REPORT:
          return VISIT_STATES.FINISHED;
        case VISIT_STATES.REPROGRAMED:
          // return VISIT_STATES.IN_PROCESS;
          return VISIT_STATES.VALIDATION;
        case VISIT_STATES.ENTRY:
          return VISIT_STATES.REPORT;
        default:
          return null;
      }
    }
  }
};

export const posibleProcessNextState = (status) =>{
  switch (status) {
    case PROCESS_STATES.VISIT_VALIDATION: 
    return _.pick(PROCESS_STATES, ["PREVENTIVE_SUSPENSION", "PRELIMINARY_INVESTIGATION",
    "INDICTMENT",
    "EVIDENTIARY_STAGE",
    "PLEADINGS_STAGE",
    "PENALTY_RESOLUTION",
    "FOLLOW_UP",
    "TO_ARCHIVE",])
      case PROCESS_STATES.PREVENTIVE_SUSPENSION:
        return _.pick(PROCESS_STATES, ["PRELIMINARY_INVESTIGATION",
    "INDICTMENT",
    "EVIDENTIARY_STAGE",
    "PLEADINGS_STAGE",
    "PENALTY_RESOLUTION",
    "FOLLOW_UP",
    "TO_ARCHIVE",])
      case PROCESS_STATES.PRELIMINARY_INVESTIGATION:
        return _.pick(PROCESS_STATES, [
    "INDICTMENT",
    "EVIDENTIARY_STAGE",
    "PLEADINGS_STAGE",
    "PENALTY_RESOLUTION",
    "FOLLOW_UP",
    "TO_ARCHIVE",])
    case PROCESS_STATES.FOLLOW_UP:
        return _.pick(PROCESS_STATES, [
          "PRELIMINARY_INVESTIGATION",
    "INDICTMENT",
    "EVIDENTIARY_STAGE",
    "PLEADINGS_STAGE",
    "PENALTY_RESOLUTION",
    "TO_ARCHIVE",])
    case PROCESS_STATES.TO_ARCHIVE:
        return _.pick(PROCESS_STATES, [
    "INDICTMENT",
    "EVIDENTIARY_STAGE",
    "PLEADINGS_STAGE",
    "PENALTY_RESOLUTION",
    "FOLLOW_UP",
    "ARCHIVED",
  ])
    default:
      return PROCESS_STATES;
  }
}

export const identificationTypes = {
  CC: "Cedula de ciudadanía",
  CE: "Cedula de extranjería",
};

export const VISIT_TYPES = {
  INSPEC: "Inspección de obra",
  SUSPEN: "Suspensión de obra",
  OTHER: "No se conoce",
};

export const VISIT_CAUSAL_TYPES = {
  SPIPCC: "Solicitud de profesional del IPCC",
  PQRS: "PQRS",
  PJ: "Proceso Juridico",
};

export const BUILDING_TYPE = {
  MNT: "Mantenimiento",
  CONS: "Consolidación",
  RECP: "Recuperación",
  ACON: "Acondicionamiento",
  SUBD: "Subdivición",
  AMP: "Ampliación",
  REST: "Reestructuración",
  OTHER: "No se conoce",
};

export const INTERVENTION_TYPE = {
  REST_MN: "Restauración monumental",
  REST_TIP: "Restauración tipologica",
  REST_FAC: "Restauración de Fachada y adecuación interna",
  REST_ADE: "Adecuación",
  BUILDNG_NEW: "Edificación nueva",
  BUILDNG_NEW2: "Edificación nueva 2 pisos",
  BUILDNG_NEW1: "Edificación nueva 1 piso",
  RECOVER_FAC: "Recuperación de paramento",
  OTHER: "No se conoce",
};

export const ROLES = {
  ASSIST: "Asistente",
  LEGAL: "Juridico",
  TECHNIC: "Tecnico",
  ADMIN: "Administrador",
};

export const isAdmin = (user) =>
  user?.roles.includes(ROLES.ASSIST) || user?.roles.includes(ROLES.ADMIN);

export const editVisitTexts = (state, type, role) => {
  if (type === "dialog-title") {
    if (role === ROLES.TECHNIC) {
      switch (state) {
        case VISIT_STATES.ASSIGNED:
          return "Confirmar entrada al predio";
        case VISIT_STATES.VALIDATION:
          return "Validar y adjuntar documentos";
        case VISIT_STATES.REPORT:
          return "Crear Informe";
        case VISIT_STATES.FINISHED:
          return "Resumen Visita";
        default:
          return "Editar Visita";
      }
    }
    if (role === ROLES.ASSIST) {
      switch (state) {
        case VISIT_STATES.REQUESTED:
          return "Asignar Visita";
        default:
          return "Agregar Comentarios";
      }
    }
  }
};

/**
flujo = "solicitud visita"-> "formulario asignacion" -> "en visita" -> "archivado"
                                                                    -> "revision juridica" -> "proceso sancionatorio" -> "en revision" -> "archivado"
*/
