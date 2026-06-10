using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Publicacion
{
    public class excelControlFinancieroPublicaciones
    {

        public int id_crearpublicacion { get; set; }
        public string director { get; set; }
        public string numidentificacion { get; set; }
        public string funcionario { get; set; }
        public string correo { get; set; }
        public string estadocontrato { get; set; }
        public int? suma { get; set; }
        public int? valordesembolso { get; set; }
        public DateTime fechadesembolso { get; set; }
        public string nombreconcepto { get; set; }
        public string nombrerubro { get; set; }
        public int id_rubro { get; set; }
        public int? sum { get; set; }
        public int? valortotal { get; set; }
        public int id_creargasto { get; set; }
        public string nombrecompleto { get; set; }
        public DateTime fechalegalizacionorden { get; set; }
        public string tipo { get; set; }
        public string numorden { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafinal { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public int id_relacionvinculo { get; set; }
        public string orpa { get; set; }
        public int? ejecutado { get; set; }
        public int? valorneto { get; set; }
        public string cp_egr { get; set; }
        public string nmsemestre { get; set; }
        public string codigohermes { get; set; }
        public string nombreproyecto { get; set; }
        public string quipu { get; set; }
        public string empresa { get; set; }
        public int valortotalproyecto { get; set; }
        public int valorejecutado { get; set; }
        public DateTime fechaentrega { get; set; }
        public int id_publicaciongasto { get; set; }
        public string titulomanuscrito { get; set; }
        public string id_kardex { get; set; }
    }
}