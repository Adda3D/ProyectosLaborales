using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionmatryoshka", Schema="public")]
    public class DecVie_PlanAccionMatryoshka
    {
        [Key]
        public int id_matryoshka { get; set; }
        public int id_lineapolitica { get; set; }
        public int id_programapgd { get; set; }
        public int id_objetivoestrategico { get; set; }
        public string procesosvsestrategias { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int? id_programafdcps { get; set; }
        public int id_ejeestrategico { get; set; }
        public int id_planaccionalcance { get; set; }
        public int id_depend { get; set; }
        public string estrategias { get; set; }
        public int id_objetivopgdvrisede { get; set; }
        public int id_objetivodependencia { get; set; }
        public int id_meta { get; set; }
        public string actividades { get; set; }
        public int id_indicadoresestrategicos { get; set; }
        public int id_nuevosindicadores { get; set; }
        public int id_tipoindicador { get; set; }
        public string descripcion { get; set; }
        public int presupuesto { get; set; }
        public DecVie_PlanAccionLineaPolitica Objlineapolitica { get; set; }
        public DecVie_PlanAccionProgramaPgd Objprogramapgd { get; set; }
        public DecVie_PlanAccionObjetivoEstrategico ObjObjetivoestrategico { get; set; }
        public DecVie_PlanAccionEjeEstrategico Objejeestrategico { get; set; }
        public DecVie_PlanAccionAlcance Objalcance { get; set; }
        public Dependencia Objdependencia { get; set; }
        public DecVie_PlanAccionObjetivosPgdVriSede Objobjetivopgdvrisede { get; set; }
        public DecVie_PlanAccionObjetivoDependencia ObjObjetivoDependencia { get; set; }
        public DecVie_PlanAccionMeta ObjMeta { get; set; }
        public DecVie_PlanAccionIndicadoresEstrategicos Objindicadoresestrategicos { get; set; }
        public DecVie_PlanAccionNuevosIndicadores Objnuevosindicadores { get; set; }
        public DecVie_PlanAccionTipoIndicador Objtipoindicador { get; set; }

        [NotMapped]
        public string TipoIndicador
        {
            get
            {
                return (Objtipoindicador == null) ? "" : Objtipoindicador.nmtipoindicador;
            }
        }

        [NotMapped]
        public string NuevosIndicadores
        {
            get
            {
                return (Objnuevosindicadores == null) ? "" : Objnuevosindicadores.nmnuevosindicadores;
            }
        }

        [NotMapped]
        public string IndicadorEstrategico
        {
            get
            {
                return (Objindicadoresestrategicos == null) ? "" : Objindicadoresestrategicos.nmindicadoresestrategicos;
            }
        }

        [NotMapped]
        public string NombreMeta
        {
            get
            {
                return (ObjMeta == null) ? "" : ObjMeta.nmmeta;
            }
        }

        [NotMapped]
        public string NombreObjetivoDependencia
        {
            get
            {
                return (ObjObjetivoDependencia == null) ? "" : ObjObjetivoDependencia.nmobjetivodependencia;
            }
        }

        [NotMapped]
        public string NombreObjetivoPgdVriSede
        {
            get
            {
                return (Objobjetivopgdvrisede == null) ? "" : Objobjetivopgdvrisede.nmobjetivopgdvrisede;
            }
        }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }

        [NotMapped]
        public string NombreLineapolitica
        {
            get
            {
                return (Objlineapolitica == null) ? "" : Objlineapolitica.lineapolitica;
            }
        }

        [NotMapped]
        public string NombreProgramaPGD
        {
            get
            {
                return (Objprogramapgd == null) ? "" : Objprogramapgd.nmprogramapgd;
            }
        }

        [NotMapped]
        public string NombreObjetivoEstrategico
        {
            get
            {
                return (ObjObjetivoestrategico == null) ? "" : ObjObjetivoestrategico.objetivoestrategico;
            }
        } 

        [NotMapped]
        public string NombreEjeEstrategico
        {
            get
            {
                return (Objejeestrategico == null) ? "" : Objejeestrategico.ejeestrategico;
            }
        }

        [NotMapped]
        public string NombreAlcance
        {
            get
            {
                return (id_planaccionalcance == 0) ? "" : id_planaccionalcance.ToString("id_alcanceanno");
            }
        }
    }
}