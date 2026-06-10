using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkanuevoindicador", Schema="public")]
    public class Decvie_MatryoshkaNuevoIndicador
    {
        [Key]
        public int id_matryoshkanuevoindicador { get; set; }
        public int id_matryoska { get; set; }
        public int id_matryoshkaobjetivodep { get; set; }
        public int id_nuevosindicadores { get; set; }
        public int id_tipoindicador { get; set; }
        public string descripcion { get; set; }
        public int presupuesto { get; set; }
        public string ejecucion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public Decvie_MatryoshkaObjetivoDep Objobjetivodep { get; set; }
        public DecVie_PlanAccionNuevosIndicadores Objnuevosindicadores { get; set; }
        public DecVie_PlanAccionTipoIndicador Objtipoindicador { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        public string NombreLargoObjetivoDependencia
        {
            get
            {
                return (Objobjetivodep == null) ? "" : Objobjetivodep.NombreObjetivoDep;
            }
        }

        public string NombreCortoObjetivoDependencia
        {
            get
            {
                return (Objobjetivodep == null) ? "" : Objobjetivodep.DescripcionObjetivoDep;
            }
        }

        [NotMapped]
        public string NombreLargoNuevoIndicador
        {
            get
            {
                return (Objnuevosindicadores == null) ? "" : Objnuevosindicadores.nmnuevosindicadores;
            }
        }

        [NotMapped]
        public string NombreCortoNuevoIndicador
        {
            get
            {
                return (Objnuevosindicadores == null) ? "" : (Objnuevosindicadores.nmnuevosindicadores == null) ? "" : (Objnuevosindicadores.nmnuevosindicadores.Length <= 60) ? Objnuevosindicadores.nmnuevosindicadores : Objnuevosindicadores.nmnuevosindicadores.Substring(1, 60) + "...";
            }
        }

        [NotMapped]
        public string NombreTipoIndicador
        {
            get
            {
                return (Objtipoindicador == null) ? "" : Objtipoindicador.nmtipoindicador;
            }
        }
    }
}