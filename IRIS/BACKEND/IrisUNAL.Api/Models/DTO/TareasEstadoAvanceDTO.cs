using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class TareasEstadoAvanceDTO
    {
        public int id_tarea { get; set; }
        public int id_estadotarea { get; set; }
        public int avance { get; set; }
        public string usuario { get; set; }
    }
}