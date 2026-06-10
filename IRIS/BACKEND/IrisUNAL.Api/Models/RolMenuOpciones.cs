using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("rolmenuopciones", Schema="public")]
    public class RolMenuOpciones
    {
        [Key]
        public int idrolmenuopciones { get; set; }
        public int idrol { get; set; }
        public int idmenu { get; set; }
        public int idopcion { get; set; }
    }
}