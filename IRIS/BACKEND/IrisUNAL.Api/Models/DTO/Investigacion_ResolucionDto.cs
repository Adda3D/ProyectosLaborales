using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Investigacion_ResolucionDto
{
    public int id_proyectoresolucion { get; set; }
    public int id_crearproyecto { get; set; }
    public string numresolucion { get; set; }  // Esto debe coincidir con el Select en la consulta
    public decimal valor { get; set; }
    public DateTime fechacreacion { get; set; }
    public string usuariocreacion { get; set; }
    public DateTime? fechaactualizacion { get; set; }
    public string usuarioactualizacion { get; set; }
    public bool activo { get; set; }
}


