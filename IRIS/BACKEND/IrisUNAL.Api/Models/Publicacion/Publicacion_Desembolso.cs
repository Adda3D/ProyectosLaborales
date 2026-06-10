using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Publicacion
{
    [Table("publicacion_desembolso", Schema = "public")]
    public class Publicacion_Desembolso
    {
        [Key]
        public int id_desembolso { get; set; }
        [Required(ErrorMessage = "Id Publicación es requerido")]
        public int id_crearpublicacion { get; set; }
        [Required(ErrorMessage = "Fecha es requerido")]
        public DateTime fechadesembolso { get; set; }
        [Required(ErrorMessage = "Valor es requerido")]
        public long valordesembolso { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Publicaciones_CrearPublicacion ObjPublicacion { get; set; }

        [NotMapped]
        public decimal Porcentaje
        {
            get
            {
                if (ObjPublicacion != null)
                {
                    long valortotal = valordesembolso * 100;
                    long totalaprobado = (ObjPublicacion.aprobadoconvenio == null) ? 0 : (long)ObjPublicacion.aprobadoconvenio;

                    decimal porcentaje = (totalaprobado != 0) ? Decimal.Divide(valortotal, totalaprobado) : 0;
                    return porcentaje;
                }
                else
                    return 0;
            }
        }
    }
}