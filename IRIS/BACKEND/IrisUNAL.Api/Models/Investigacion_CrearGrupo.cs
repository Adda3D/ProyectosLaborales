using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_creargrupo", Schema="public")]
    public class Investigacion_CrearGrupo
    {
        [Key]
        public int id_creargrupo { get; set; }
        public int? id_areaacad { get; set; }
        public int id_persona { get; set; }
        public string minciencias { get; set; }
        public string codigohermes { get;set;}
        public string nombregrupo { get; set; }
        public string abreviatura { get; set; }
        public string hermesfortalecimiento { get; set; }
        public DateTime? creacionminciencias { get; set; }
        public string temageninvetigacion { get; set; }
        public bool actualizado { get; set; }
        public string clasificacionactual { get; set; }
        public string linkhermes { get; set; }
        public string linkcolciencias { get; set; }
        public int? idfuncionario { get; set; }
        public string correogrupo { get; set; }
        public string correoalternativo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona idpersona { get; set; }
        public Area_Academica idacademica { get; set; }
        public Funcionario funcionariocoordinador  { get; set; }

        [NotMapped]
        public string NomCompleto
        {
            get
            {
                return (idpersona == null) ? "" : idpersona.nombrecompleto;
            }
        } 
        [NotMapped]
        public string AreaCurricular
        {
            get
            {
                return (idacademica == null) ? "" : idacademica.nmaacad;
            }
        }
        [NotMapped]
        public string NombreCoordinador
        {
            get
            {
                return (funcionariocoordinador == null) ? "" : funcionariocoordinador.nombrecompleto;
            }
        }
    }
}