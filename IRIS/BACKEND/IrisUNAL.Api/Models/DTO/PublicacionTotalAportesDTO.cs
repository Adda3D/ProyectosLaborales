using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class PublicacionTotalAportesDTO
    {
        public int id_crearpublicacion { get; set; }
        public long? aportefacultad { get; set; }
        public long? aportevir { get; set; }
        public long? aportedieb { get; set; }
        public long? aprobadoconvenio { get; set; }
        public long? aportadoconvenio { get; set; }

    }
}