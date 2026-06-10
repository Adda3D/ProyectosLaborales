using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_CicloFinancieroPostProgramUAdministrativaDTO
    {
        public int id_postprogram { get; set; }
        public int? recaudobogota { get; set; }
        public int? recaudoconvenio { get; set; }
        public int? porcentajeugi { get; set; }
        public int? porcentajederadmtvos { get; set; }
        public string facultaddsps { get; set; }
        public int? total { get; set; }
        public int? porcentajeugiconvenio { get; set; }
        public int? porcentajederadmtvosconvenio { get; set; }
        public int? trasladoistconvenio { get; set; }
        public string facultaddspsconvenio { get; set; }
    }
}