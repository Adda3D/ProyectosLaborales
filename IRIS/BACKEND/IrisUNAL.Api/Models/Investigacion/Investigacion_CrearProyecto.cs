using IrisUNAL.Api.Models.Investigacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{

    [Table("investigacion_crearproyecto", Schema = "public")]
    public class Investigacion_CrearProyecto
    {
        [Key]
        public int id_crearproyecto { get; set; }
        public int id_literal { get; set; }
        public int id_conceptougi { get; set; }
        public int idfuncionario { get; set; }
        public int id_persona { get; set; }  // Clave externa a Persona
        public int? id_convocatoria { get; set; }
        public int id_creargrupo { get; set; }
        public int id_estado { get; set; }
        public string codigohermes { get; set; }
        public string nombreproyecto { get; set; }
        public int id_naturalezaproyecto { get; set; }
        public string codigoavalsede { get; set; }
        public string consecutivoavaldedicaciondocente { get; set; }
        public int? horasaprobadas { get; set; }
        public string id_modalidad { get; set; }
        public string actoadministrativo { get; set; }
        public string resoluciondeaperturapresupuestal { get; set; }
        public string quipu { get; set; }
        public string anopublicacion { get; set; }
        public string empresa { get; set; }
        public long valortotalproyecto { get; set; }
        public long valorejecutado { get; set; }
        public long saldoporcomprometer { get; set; }
        public long valoraportevir { get; set; }
        public long valoraportefacultad { get; set; }
        public long valoraportedieb { get; set; }
        public long valoraporteexterno { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechaentrega { get; set; }
        public DateTime? fechafinaliza { get; set; }
        public string archivoproyectoenlace { get; set; }
        public string vigencia { get; set; }
        public long? aportefacultad { get; set; }
        public long? aportevir { get; set; }
        public long? aportedieb { get; set; }
        public long? aprobadoconvenio { get; set; }

        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public string departamento { get; set; }

        public virtual Proyectos_NaturalezaProyecto ObjNaturaleza { get; set; }
        public virtual Funcionario ObjFuncionario { get; set; }
        public virtual Persona ObjPersona { get; set; }
        public virtual Investigacion_CrearGrupo ObjGrupo { get; set; }

        [NotMapped]
        public string NombreNaturaleza
        {
            get
            {
                return (ObjNaturaleza == null) ? "" : ObjNaturaleza.naturalezaproyecto;
            }
        }

        [NotMapped]
        public string nmproyectodt
        {
            get
            {
                return (nombreproyecto.Length > 59) ? String.Concat(nombreproyecto.Substring(0, 60), " ...") : nombreproyecto;
            }
        }

        [NotMapped]
        public string NombreDirector
        {
            get
            {
                return (ObjPersona == null) ? "" : ObjPersona.nombrecompleto;
            }
        }
    }

    //[Table("investigacion_crearproyecto", Schema="public")]
    //public class Investigacion_CrearProyecto
    //{
    //    [Key]
    //    public int id_crearproyecto { get; set; }
    //    public int id_literal { get; set; }
    //    public int id_conceptougi { get; set; }
    //    public int idfuncionario { get; set; }
    //    public int id_persona { get; set; }
    //    public int? id_convocatoria { get; set; }
    //    public int id_creargrupo { get; set; }
    //    public int id_estado { get; set; }
    //    public string codigohermes { get; set; }
    //    public string nombreproyecto { get; set; }
    //    public int id_naturalezaproyecto { get; set; }        
    //    public string codigoavalsede { get; set; }
    //    public string consecutivoavaldedicaciondocente { get; set; }
    //    public int? horasaprobadas { get; set; }        
    //    public string id_modalidad { get; set; }
    //    public string actoadministrativo { get; set; }        
    //    public string resoluciondeaperturapresupuestal { get; set; }
    //    public string quipu { get; set; }
    //    public string anopublicacion { get; set; }
    //    public string empresa { get; set; }        
    //    //public long valoraprobado { get; set; }
    //    public long valortotalproyecto { get; set; }
    //    public long valorejecutado { get; set; }
    //    public long saldoporcomprometer { get; set; }
    //    public long valoraportevir { get; set; }
    //    public long valoraportefacultad { get; set; }
    //    public long valoraportedieb { get; set; }
    //    //public long? valoraporteotro { get; set; }
    //    public long valoraporteexterno { get; set; }
    //    public DateTime fechainicio { get; set; }
    //    public DateTime fechaentrega { get; set; }
    //    public DateTime? fechafinaliza { get; set; }
    //    public string archivoproyectoenlace { get; set; }
    //    public string vigencia { get; set; }
    //    public long? aportefacultad { get; set; }
    //    public long? aportevir { get; set; }
    //    public long? aportedieb { get; set; }
    //    public long? aprobadoconvenio { get; set; }

    //    public DateTime fechacreacion { get; set; }
    //    public string usuariocreacion { get; set; }
    //    public DateTime fechaactualizacion { get; set; }
    //    public string usuarioactualizacion { get; set; }
    //    public bool activo { get; set; }
    //    public string departamento { get; set; }
    //    public Proyectos_NaturalezaProyecto ObjNaturaleza { get; set; }
    //   /* public Propuesta_Modalidad ObjModalidad { get; set; }*/
    //    public Convocatoria ObjConvcatoria { get; set; }
    //    public Literal_UGI ObjLiteral { get; set; }
    //    public Concepto_UGI ObjConcepto { get; set; }
    //    //public investigacion_estado ObjEstado { get; set; }
    //    public Funcionario ObjFuncionario { get; set; }
    //    public Persona ObjPersona { get; set; }
    //    public Investigacion_CrearGrupo ObjGrupo { get; set; }

    //    //CAMBIO ADDA VARGAS
    //    public virtual Persona Persona { get; set; }

    //    [NotMapped]
    //    public string NombreNaturaleza
    //    {
    //        get
    //        {
    //            return (ObjNaturaleza == null) ? "" : ObjNaturaleza.naturalezaproyecto;
    //        }
    //    }

    //    [NotMapped]
    //    public string nmproyectodt
    //    {
    //        get
    //        {
    //            return (nombreproyecto.Length > 59) ? String.Concat(nombreproyecto.Substring(0, 60), " ...") : nombreproyecto;
    //        }
    //    }

    //    [NotMapped]
    //    public string NombreDirector
    //    {
    //         get
    //         {
    //            return (ObjPersona == null) ? "" : ObjPersona.nombrecompleto;

    //        }
    //    }

    //}
}