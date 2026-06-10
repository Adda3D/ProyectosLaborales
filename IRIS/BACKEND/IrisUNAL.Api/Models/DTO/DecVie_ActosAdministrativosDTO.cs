using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_ActosAdministrativosDTO
    {
        public int id_actoadministrativo { get; set; }
        public DateTime fechaexpedicion { get; set; }
        public string nmidtipoactoadministrativo { get; set; }
        public string consecutivoactoadministrativo { get; set; }
        public string conconceptoasunto { get; set; }
        public string nmdecvietipologia { get; set; }
        public string nmdecviemacroproceso { get; set; }
        public string nmdepend { get; set; }
        public string beneficiario { get; set; }
        public string dependenciafirma { get; set; }
        public string nombrecompleto { get; set; }
        public string nmestadoactoadministrativo { get; set; }
        public string dependenciadocumento { get; set; }
        public string numidentificacion { get; set; }
    }
}