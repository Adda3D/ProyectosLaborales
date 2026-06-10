using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_radicadortec_auditoria", Schema = "public")]
    public class DecVie_RadicadorTecAuditoria
    {
        [Key]
        [Column("id_auditoria")]
        public int id_auditoria { get; set; }

        [Column("id_decvieradicadortec")]
        public int id_decvieradicadortec { get; set; }

        [Column("tipo_cambio")]
        public string tipo_cambio { get; set; }

        [Column("valor_nuevo")]
        public string valor_nuevo { get; set; }

        [Column("usuario")]
        public string usuario { get; set; }

        [Column("fecha_cambio")]
        public DateTime fecha_cambio { get; set; }
    }
}
