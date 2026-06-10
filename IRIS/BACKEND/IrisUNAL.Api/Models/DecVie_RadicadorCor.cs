using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_radicadorcor", Schema="public")]
    public class DecVie_RadicadorCor
    {
        [Key]
        public int id_radicadorcor { get; set; }
        public string ogdchasqui { get; set; }
        public DateTime fecradicacion { get; set; }
        public int id_origensolicitud { get; set; }
        public int id_instancia { get; set; }
        public string observaciones { get; set; }
        public string identificacionsolicitante { get; set; }
        public string numerodocumento { get; set; }
        public DateTime fecdocumento { get; set; }
        public int id_alcancesolicitud { get; set; }
        public int id_decviemacroproceso { get; set; }
        public int id_depend { get; set; }
        public string unidadproductora { get; set; }
        public int id_decvieestado { get; set; }
        public string consecutivorespuesta { get; set; }        
        public string archivorespuesta { get; set; }
        public int? id_decvietipologia { get; set; }
        public int? id_seriedocumental { get; set; }
        public int? id_subseriedoc { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public DecVie_OrigenSolicitud Objorigensolicitud { get; set; }
        public DecVie_Instancias Objinstancia { get; set; }
        public DecVie_AlcanceSolicitud Objalcancesolicitud { get; set; }
        public DecVie_Macroproceso Objmacroproceso { get; set; }
        public Dependencia Objdependencia { get; set; }
        public DecVie_Estado Objestado { get; set; }

        [NotMapped]
        public string OrigenSolicitud
        {
            get
            {
                return (Objorigensolicitud == null) ? "" : Objorigensolicitud.nmorigensolicitud;
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
        public string NombreAlcanceSolicitud
        {
            get
            {
                return (Objalcancesolicitud == null) ? "" : Objalcancesolicitud.nmalcancesolicitud;
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
        public string DependenciaRespuesta
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }
        
        [NotMapped]
        public string EstadoSolicitud
        {
            get 
            { 
                return (Objestado == null) ? "" : Objestado.nmdecvieestado; 
            }
        }
        
    }
}