using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_autores", Schema="public")]
    public class Publicaciones_Autores
    {
        [Key]
        public int id_autores { get; set; }
        public int id_persona { get; set; }
        public int id_crearpublicacion { get; set; }
        public bool? divulgacionfoto { get; set; }
        public bool? divulgacionnombre { get; set; }
        public bool? divulgacionperfil { get; set; }
        public bool? retroalimentacionevento { get; set; }
        public string retroalimentacionnotas { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona nompersona { get; set; }
        public Publicaciones_CrearPublicacion nompublicaion { get; set; }

        [NotMapped]
        public string NombrePersona
        {
            get
            {
                return (nompersona == null) ? "" : nompersona.nombrecompleto;
            }
        }

        [NotMapped]
        public string EmailAutor
        {
            get
            {
                return (nompersona == null) ? "" : (nompersona.correo1 == null) ? "" : nompersona.correo1;
            }
        }

        [NotMapped]
        public string CelularAutor
        {
            get
            {
                return (nompersona == null) ? "" : (nompersona.celular == null) ? "" : nompersona.celular;
            }
        }

        [NotMapped]
        public string NombrePublicacion
        {
            get
            {
                return (nompublicaion == null) ? "" : nompublicaion.titulomanuscrito;
            }
        }

        [NotMapped]
        public string Notasdt
        {
            get
            {
                return (retroalimentacionnotas == null) ? "" : (retroalimentacionnotas.Length > 89) ? String.Concat(retroalimentacionnotas.Substring(0, 90), " ...") : retroalimentacionnotas;
            }
        }

    }
}