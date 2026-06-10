using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{   
    public class AsignacionProyectoDTO
    {        
            public int id_asignacionproyecto { get; set; }
            public string numcontratoconvenio { get; set; }

    }
}