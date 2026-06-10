using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_PreAvalConceptoDecanaturaDTO
    {
        public int id_preaval { get; set; }
        public int? id_conceptodecanatura { get; set; }
        public int? id_estadopreaval { get; set; }
        public string observacionesdecanatura { get; set; }
        public DecVie_ConceptoDecanatura Objconceptodecanatura { get; set; }
        public DecVie_EstadoPreAval Objestadopreaval { get; set; }

        [NotMapped]
        public string NombreConceptoDecanatura
        {
            get
            {
                return (Objconceptodecanatura == null) ? "" : Objconceptodecanatura.nmconceptodecanatura;
            }
        }

        [NotMapped]
        public string NombreEstadoPreaval
        {
            get
            {
                return (Objestadopreaval == null) ? "" : Objestadopreaval.nmestadopreaval;
            }
        }
    }
}