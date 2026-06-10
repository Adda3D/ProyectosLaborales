using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("suscripcion_liquidacion", Schema="public")]
    public class Suscripcion_Liquidacion
    {
        [Key]
        public int id_suscripcionliquidcion { get; set; }
        public int id_asignacionproyecto { get; set; }
        public string entregablesoproductosporentregar { get; set; }                
        public string desembolsospendientes { get; set; }        
        public string observacionesestadoproyecto { get; set; }
        public DateTime fecsolactliquidacion { get; set; }
        public string consecutivosolactaliquidacion { get; set; }        
        public DateTime? fecressolliquidacion { get; set; }
        public string observacionessolliquidacion { get; set; }        
        public DateTime? fecrecepactliquidacion { get; set; }        
        public DateTime? fecrevactliquidacion { get; set; }        
        public DateTime? fecsolinftesoreria { get; set; }
        public string consecutivosolinftesoreria { get; set; }        
        public DateTime? fecremdecobspreliminares { get; set; }
        public string consecutivoremdecanatura { get; set; }        
        public DateTime? fecrespdecanatura { get; set; }        
        public DateTime? fecintegraobservacionesal { get; set; }        
        public DateTime? fecremalobsentidad { get; set; }
        public string consecutivoremalobs { get; set; }        
        public DateTime? fecrespentidad { get; set; }
        public DateTime? fecrevfinalal { get; set; }
        public bool avalesinternos { get; set; }
        public DateTime? fecremdecverfinalal { get; set; }        
        public DateTime? fecrecfirmdec { get; set; }        
        public DateTime? fecremalfirmentidad { get; set; }        
        public DateTime? fecrecaltodasfirmas { get; set; }
        public int? idfuncionario { get; set; }
        public int? idfuncionariosolicitaacta { get; set; }
        public int? idfuncionarioobservacta { get; set; }
        public int? idfuncionariorecepcionacta { get; set; }
        public int? idfuncionariorevisionacta { get; set; }
        public int? idfuncionariosolicinfotesoreria { get; set; }
        public int? idfuncionarioremiobservdecanatura { get; set; }
        public int? idfuncionarioresptadecanatura { get; set; }
        public int? idfuncionariointegraobserv { get; set; }
        public int? idfuncionarioremiobserventidad { get; set; }
        public int? idfuncionarioremidecaversionfinal { get; set; }
        public int? idfuncionariofirmadeca { get; set; }
        public int? idfuncionarioremitefirmadaentidad { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo {get;set;}
        public Proyectos_AsignacionProyecto ObjProyecto { get; set; }
    }
}