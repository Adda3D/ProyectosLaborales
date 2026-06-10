using IrisUNAL.Api.Models.UGI;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("investigacion_resolucion", Schema = "public")]
    public class Investigacion_Resolucion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_proyectoresolucion { get; set; }

        [Required(ErrorMessage = "ID proyecto requerido")]
        public int id_crearproyecto { get; set; }

        // Clave foránea que referencia a SE CAMBIA: UGI_Semestre
       [ForeignKey("UGI_Semestre")]
       public int resolucion { get; set; }


        public decimal valor { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

        // Propiedad de navegación para la relación con UGI_Semestre
        public virtual UGI_Semestre UGI_Semestre { get; set; }
    }
}
