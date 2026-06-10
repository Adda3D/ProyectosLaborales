using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    public class excelControlFinancieroInvestigacion
    {

        public int id_desembolso { get; set; }
        public int id_crearproyecto { get; set; }
        public DateTime fechadesembolso { get; set; }
        public long valordesembolso { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Investigacion_CrearProyecto ObjProyecto { get; set; }
        public string nombrerubro { get; set; }
        public string nombreconcepto { get; set; }
        public int id_rubro { get; set; }
        public int? sum { get; set; }
        public string orpa { get; set; }
        public DateTime fechapago { get; set; }
        public string cp_egr { get; set; }
        public string nmsemestre { get; set; }
        public int? valorneto { get; set; }
        public string estado { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafinal { get; set; }
        public string numorden { get; set; }
        public DateTime fechalegalizacionorden { get; set; }
        public string tipo { get; set; }
        public int? valortotal { get; set; }
        public string nmestado { get; set; }

        public string nombrecompleto { get; set; }
        public string numidentificacion { get; set; }
        public string correo1 { get; set; }
        public string correo { get; set; }
        public string funcionario { get; set; }
        public int id_relacionvinculo { get; set; }
        public int id_investigaciongasto { get; set; }
        public int? suma { get; set; }
        public int? ejecutado { get; set; }


    }
}