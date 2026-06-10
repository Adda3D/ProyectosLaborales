using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("tipoopcion", Schema="public")]
    public class TipoOpcion
    {
        [Key]
        public int idopcion { get; set; }
        public string nombreopcion { get; set; }
        public bool activo { get; set; }
    }
}