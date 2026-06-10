using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("investigacion_desembolso", Schema = "public")]
    public class Investigacion_Desembolso
    {
        [Key]
        public int id_desembolso { get; set; }
        [Required(ErrorMessage = "Id Proyecto es requerido")]
        public int id_crearproyecto { get; set; }
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
        public Investigacion_CrearProyecto ObjProyecto { get; set; }

        [NotMapped]
        public decimal Porcentaje
        {
            get
            {
                if (ObjProyecto != null)
                {
                    long valortotal = valordesembolso * 100;
                    long totalaprobado = (ObjProyecto.aprobadoconvenio == null) ? 0 : (long)ObjProyecto.aprobadoconvenio;

                    decimal porcentaje = (totalaprobado != 0) ? Decimal.Divide(valortotal, totalaprobado) : 0;
                    return porcentaje;
                }
                else
                    return 0;
            }
        }

    }
}