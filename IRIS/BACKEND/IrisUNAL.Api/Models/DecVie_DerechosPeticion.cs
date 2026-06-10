using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_derechospeticion", Schema="public")]
    public class DecVie_DerechosPeticion
    {
        [Key]
        public int id_derechopeticion { get; set; }
        public DateTime fecha { get; set; }
        public int id_origensolicitud { get; set; }
        public string numradicacion { get; set; }
        public int id_instancia { get; set; }
        public int id_decviemacroproceso { get; set; }
        public string identificacionsolicitante { get; set; }
        public int id_depend { get; set; }
        public string solicitud { get; set; }
        public int id_oficina { get; set; }
        public DateTime? fecrespuesta { get; set; }
        public string numconsecutivoresp { get; set; }
        public int id_estadoderpet { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public string nombreresponsable { get; set; }
        public int id_tipopersona { get; set; }
        public DecVie_OrigenSolicitud Objorigen { get; set; }
        public DecVie_Instancias Objinstancia { get; set; }
        public DecVie_Macroproceso Objmacroproceso { get; set; }
        public Dependencia Objdependencia { get; set; }
        public DecVie_DerechosPeticionOficina Objoficina  { get; set; }
        public DecVie_DerechosPeticionEstado Objestadoderechopeticion { get; set; }
        public Tipo_Persona Objtipopersona  { get; set; }

        [NotMapped]
        public string NombreTipoOrigen
        {
            get
            {
                return (Objorigen == null) ? "" : Objorigen.nmorigensolicitud;
            }
        }

        [NotMapped]
        public string NombreInstancia
        {
            get
            {
                return (Objinstancia == null) ? "" : Objinstancia.nminstancia;
            }
        }

        [NotMapped]
        public string NombreMacroproceso
        {
            get
            {
                return (Objmacroproceso == null) ? "" : Objmacroproceso.nmdecviemacroproceso;
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
        public string NombreOficina
        {
            get
            {
                return (Objoficina == null) ? "" : Objoficina.nmoficina;
            }
        }

        [NotMapped]
        public string NombreEstado
        {
            get
            {
                return (Objestadoderechopeticion == null) ? "" : Objestadoderechopeticion.nmestadoderpet;
            }
        }

        [NotMapped]
        public string NombreTipoPersona
        {
            get
            {
                return (Objtipopersona == null) ? "" : Objtipopersona.nmtipoper;
            }
        }
    }
}