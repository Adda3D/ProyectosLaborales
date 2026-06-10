using IrisUNAL.Api.Models.Investigacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.UGI
{
    [Table("ugi_semestre", Schema = "public")]
    public class UGI_Semestre
    {
        [Key]
        public int id_ugisemestre { get; set; }
        public int id_semestre { get; set; }
        public string numresolucion { get; set; }
        public DateTime fecresolucion { get; set; }
        public long? valortotalsemestre { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Semestre Objsemestre { get; set; }

        // Propiedad de navegación para las resoluciones
        public virtual ICollection<Investigacion_Resolucion> Resoluciones { get; set; }




        [NotMapped]
        public string NombreSemestre
        {
            get
            {
                return (Objsemestre == null) ? "" : Objsemestre.nmsemestre;
            }
        }

        [NotMapped]
        public int ValTotalSemestre
        {
            get
            {
                return (int)((valortotalsemestre == null) ? valortotalsemestre = 0 : valortotalsemestre);
            }
        }
    }
}
