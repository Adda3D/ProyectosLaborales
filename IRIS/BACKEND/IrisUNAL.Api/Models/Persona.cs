using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("persona", Schema="public")]
    public class Persona
    {
        [Key]
        public int id_persona { get; set; }
        public int id_tipodocumento { get; set; }
        [Required(ErrorMessage = "Naturaleza es requerido")]
        public int id_tipopersona { get; set; }
        [Required(ErrorMessage = "Número Identificación requerido")]
        [StringLength(15, MinimumLength = 1)]
        public string numidentificacion { get; set; }
        [Required(ErrorMessage = "Nacionalidad requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string nacionalidad { get; set; }        
        public int? id_genero { get; set; }
        [Required(ErrorMessage = "Tipo entidad es requerido")]
        public int id_tipoentidad { get; set; }
        [Required(ErrorMessage = "Nombre Completo/Razón Social requerido")]
        [StringLength(150, MinimumLength = 1)]
        public string nombrecompleto { get; set; }
        [Required(ErrorMessage = "Dirección requerida")]
        [StringLength(150, MinimumLength = 1)]
        public string direccion1 { get; set; }
        [Required(ErrorMessage = "Teléfono requerido")]
        [StringLength(15, MinimumLength = 7)]
        public string telefono { get; set; }
        public string celular { get; set; }
        [Required(ErrorMessage = "Email requerido")]
        [StringLength(100, MinimumLength = 7)]
        public string correo1 { get; set; }        
        public string institucion { get; set; }
        public string cargo { get; set; }
        [Required(ErrorMessage = "Tipo prestación servicio requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string id_tiposervicio { get; set; }
        [StringLength(50)]
        public string ciudad { get; set; }        
        public int? id_pais { get; set; }        
        public int? id_depend { get; set; }
        [StringLength(300)]
        public string areainteres { get; set; }
        [StringLength(100)]
        public string enlacecvlac { get; set; }        
        public int? id_formacion { get; set; }        
        public int? id_tituloalto { get; set; }
        public string tituloposgrados { get; set; }
        [StringLength(300)]
        public string perfil { get; set; }        
        public int? id_calificacion { get; set; }
        public bool evaluadorpublicacion { get; set; }
        public int? evaluadorinternoexterno { get; set; }
        public string evaluadorminciencias { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}