using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_crearpublicacion", Schema="public")]
    public class Publicaciones_CrearPublicacion
    {
        internal string nombreproyecto;
        internal string codigohermes;

        [Key]
        public int id_crearpublicacion { get; set; }
        [Required(ErrorMessage = "Kardex es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string id_kardex { get; set; }
        public DateTime fecregmanuscrito { get; set; }
        [Required(ErrorMessage = "Título es requerido")]
        [StringLength(500, MinimumLength = 1)]
        public string titulomanuscrito { get; set; }    
        [Required(ErrorMessage = "Origen es requerido")]
        public int id_origenmanuscrito { get; set; }
        public string hermesidproyextedcontinua { get; set; }
        public string hermesidmanuscrito { get; set; }
        [Required(ErrorMessage = "Formato distribución es requerido")]
        public int id_formatodistribucion { get; set; }
        public int? id_creargrupo { get; set; }
        [Required(ErrorMessage = "Colección es requerido")]
        public int id_coleccion { get; set; }
        [Required(ErrorMessage = "Caracter Proyecto es requerido")]
        public int id_carproyeditorial { get; set; }
        public int? id_coedicion { get; set; }
        [Required(ErrorMessage = "Responsable es requerido")]
        public int idfuncionario { get; set; }        
        public string geseditunijus { get; set; }
        [Required(ErrorMessage = "Fecha Inicio ruta es requerido")]
        public DateTime fecinirutedit { get; set; }
        [Required(ErrorMessage = "Número caracteres es requerido")]
        public int numerocaracteres { get; set; }
        [Required(ErrorMessage = "Área Curricular es requerido")]
        public int id_areaacad { get; set; }
        public string comentregistro { get; set; }
        public string palabraclave { get; set; }
        [Required(ErrorMessage = "Complejidad es requerido")]
        public int id_complejidad { get; set; }
        [Required(ErrorMessage = "Tipo obra es requerido")]
        public int id_tipoobra { get; set; }
        [Required(ErrorMessage = "Idioma es requerido")]
        public int id_idioma { get; set; }
        public string id_hermes { get; set; }
        public string literal_ugi { get; set; }
        public string resolucion_ugi { get; set; }
        public string ficha_quipu { get; set; }
        public int? id_evaluacioninicial { get; set; }
        public int? nrocoleccion { get; set; }
        public int? nroedicion { get; set; }
        public bool? reimpresion { get; set; }
        public string anopublicacion { get; set; }
        public long? aportefacultad { get; set; }
        public long? aportevir { get; set; }
        public long? aportedieb { get; set; }
        public long? aprobadoconvenio { get; set; }
        public int idestadomanuscrito { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Funcionario ObjFuncionario { get; set; }
        public Publicaciones_EvaluacionInicial ObjEvaluacion { get; set; }

        [NotMapped]
        public string Responsable
        {
            get
            {
                return (ObjFuncionario == null) ? "" : ObjFuncionario.nombrecompleto;
            }
        }

        [NotMapped]
        public string TituloDt
        {
            get
            {
                return (titulomanuscrito.Length > 59) ? String.Concat(titulomanuscrito.Substring(0, 60), " ...") : titulomanuscrito;                
            }
        }

        [NotMapped]
        public string TextoEvaluacion
        {
            get
            {
                return (ObjEvaluacion == null) ? "" : ObjEvaluacion.nmevalinicial;
            }
        }
    }
}