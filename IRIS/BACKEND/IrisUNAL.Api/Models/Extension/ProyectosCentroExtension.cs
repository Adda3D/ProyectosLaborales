using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IrisUNAL.Api.Models.Extension
{
    [Table("proyectoscentroextension", Schema = "public")]

    public class ProyectosCentroExtension
    {

        public string estadopropuesta { get; set; }
        public int totalestadopropuesta { get; set; }
        public string modalidadpropuesta { get; set; }
        public int totalmodalidadpropuesta { get; set; }
        public string nmpropuestatipousuario { get; set; }
        public int count { get; set; }
        public string origenpropuesta { get; set; }
        public int totalorigenpropuesta { get; set; }
        public string razonsocial { get; set; }
        public int nument { get; set; }
        public int id_propuesta { get; set; }
        public string nmpropuesta { get; set; }
        public int valorinicialpropuesta { get; set; }
        public string consecutivooferta { get; set; }
        public DateTime fecrad { get; set; }
        public int id_modalidad { get; set; }
        public int id_origenpropuesta { get; set; }
        public int id_tipopropuesta { get; set; }
        //public int id_aprobacionconsejofacultad { get; set; }
        public int id_estadopropuesta { get; set; }
        //public int id_estadosuscripcioncontratoconvenio { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        //public DateTime fechaactualiacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int idfuncionario { get; set; }
        public int id_propuestatipousuario { get; set; }
        public string contratoconvenio { get; set; }
        public int idpropuesta_entidad { get; set; }
        //public int id_actaconsejofacultad { get; set; }
        public string oficioaprobacion { get; set; }
        public string actaaprobacion { get; set; }
        public string oficioaprobenlace { get; set; }
        public string actaaprobenlace { get; set; }
        public int id_asignacionproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public int valinicialaporteentidad { get; set; }
        public string concat { get; set; }
        //Qry 13
        public string entidad { get; set; }
        public int contrapartida { get; set; }
        public string productos { get; set; }
        public DateTime fecterminacion { get; set; }
        //
        //Qry 14
        //public DateTime yearsuscripcion { get; set; }
        public int id_naturalezaproyecto { get; set; }
        public string poblacionobjetivo { get; set; }
        public string numcontratoconvenio { get; set; }
        //public string? yearsejecucion { get; set; } //String nulo
        //public string plazoejecucion { get; set; } //String nulo
        //public DateTime fecacuerdovoluntades { get; set; }
        //public DateTime fecactainicio { get; set; }
        public string fichaquipu { get; set; }
        public string codigohermes { get; set; }
        //public string numeromodificaciones { get; set; } //String nulo
        public string objetocontratoactividad { get; set; }
        public int id_alcanceproyecto { get; set; }
        public int adiciondisminucion { get; set; }
        //public int? valortotal { get; set; }
        public int id_areacad { get; set; }
        public int nestudiantesderecho { get; set; }
        public int nestudiantespolitica { get; set; }
        public int nestudiantespostgrados { get; set; }
        public string numerosar { get; set; }
        public string numeroodsops { get; set; }
        public int id_estadocontrato { get; set; }
        public string consecutivo { get; set; }
        public int id_propuestaentidad { get; set; }
        public int iddirector { get; set; }
        public int idsupervisor { get; set; }
        public int idasistente { get; set; }
        //public int? idregistrorup { get; set; }
        //public int? idarchivoentrega { get; set; }
        public string contratoconvenioenlace { get; set; }
        public string entregaarchivoenlace { get; set; }
        public int aportefacultad { get; set; }
        public int aportevir { get; set; }
        public int aportedieb { get; set; }
        public int aprobadoconvenio { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechaentrega { get; set; }
        public string quipu { get; set; }
        public int valortotalproyecto { get; set; }
        public int valorejecutado { get; set; }


    }
}