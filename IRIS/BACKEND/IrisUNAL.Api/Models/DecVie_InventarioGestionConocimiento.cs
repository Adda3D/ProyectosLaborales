using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_inventariogestionconocimiento", Schema="public")]
    public class DecVie_InventarioGestionConocimiento
    {
        [Key]
        public int id_invgesconocimiento { get; set; }
        public int id_conocimientosoporte { get; set; }
        public string vigencia { get; set; }
        public int id_conocimientotipologia { get; set; }
        public int id_conocimientoenfasis { get; set; }
        public int idpropuesta_entidad { get; set; }
        public string beneficiarios { get; set; }
        public int? id_conocimientoimpacto { get; set; }
        public int? id_patentetipo { get; set; }
        public string vigenciapatente { get; set; }
        public string entidadpatente { get; set; }
        public long? gastos { get; set; }
        public long? costodirecto { get; set; }
        public long? total { get; set; }
        public int? id_insumo { get; set; }
        public int? id_ahorro { get; set; }
        public int? id_obsolescenciaconcepto { get; set; }
        public int? presupuestoejecutado { get; set; }
        public int? designadogestion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public DateTime? fechavaloracion { get; set; }
        public DecVie_InventarioConocimientoSoporte Objsoporte { get; set; }
        public DecVie_InventarioConocimientoTipologia Objtipologia { get; set; }
        public DecVie_InventarioConocimientoEnfasis Objenfasis { get; set; }
        public Propuesta_Entidad Objcontratante { get; set; }
        public DecVie_InventarioConocimientoImpacto Objimpacto { get; set; }
        public DecVie_InventarioRegistroPatenteTipo Objpatentetipo { get; set; }
        public DecVie_InventarioUsoAmpliadoInsumo Objinsumo { get; set; }
        public DecVie_InventarioUsoAmpliadoAhorro Objahorro { get; set; }
        public DecVie_InventarioObsolescenciaConcepto Objobsolescenciaconcepto { get; set; }

        public string NombreSoporte
        {
            get
            {
                return (Objsoporte == null) ? "" : Objsoporte.nmsoporte;
            }
        }

        public string NombreTipologia
        {
            get
            {
                return (Objtipologia == null) ? "" : Objtipologia.nmtipologia;
            }
        }

        public string NombreEnfasis
        {
            get
            {
                return (Objenfasis == null) ? "" : Objenfasis.nmenfasis;
            }
        }

        public string NombreEntidad
        {
            get
            {
                return (Objcontratante == null) ? "" : Objcontratante.razonsocial;
            }
        }

        public string NombreImpacto
        {
            get
            {
                return (Objimpacto == null) ? "" : Objimpacto.nmimpacto;
            }
        }

        public string NombrePatenteTipo
        {
            get
            {
                return (Objpatentetipo == null) ? "" : Objpatentetipo.nmpatentetipo;
            }
        }

        public string NombreInsumo
        {
            get
            {
                return (Objinsumo == null) ? "" : Objinsumo.nminsumo;
            }
        }

        public string NombreAhorro
        {
            get
            {
                return (Objahorro == null) ? "" : Objahorro.nmahorro;
            }
        }

        public string NombreConepto
        {
            get
            {
                return (Objobsolescenciaconcepto == null) ? "" : Objobsolescenciaconcepto.nmconcepto;
            }
        }
    }
}