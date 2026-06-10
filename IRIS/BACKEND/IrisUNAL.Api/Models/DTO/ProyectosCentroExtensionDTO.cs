using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class ProyectosCentroExtensionDTO
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
        public int? id_propuesta { get; set; }
        public string nmpropuesta { get; set; }
        public long valorinicialpropuesta { get; set; }
        public string consecutivooferta { get; set; }
        public DateTime? fecrad { get; set; }
        public int id_modalidad { get; set; }
        public int id_origenpropuesta { get; set; }
        public int id_tipopropuesta { get; set; }
        public int? id_aprobacionconsejofacultad { get; set; }
        public int id_estadopropuesta { get; set; }
        public int? id_estadosuscripcioncontratoconvenio { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualiacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int idfuncionario { get; set; }
        public int id_propuestatipousuario { get; set; }
        public string contratoconvenio { get; set; }
        public int idpropuesta_entidad { get; set; }
        public int? id_actaconsejofacultad { get; set; }
        public string oficioaprobacion { get; set; }
        public string actaaprobacion { get; set; }
        public string oficioaprobenlace { get; set; }
        public string actaaprobenlace { get; set; }
        public int totalproyectos { get; set; }
        public string nmmodalidad { get; set; }
        public int cantidadmodalidad { get; set; }
        public int id_asignacionproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public int valinicialaporteentidad { get; set; }
        public string concat { get; set; }
        //Qry 13
        public string entidad { get; set; }
        public int contrapartida { get; set; }
        public string productos { get; set; }
        //public DateTime fecterminacion { get; set; }
        //Qry 14  
        public DateTime? yearsuscripcion { get; set; }
        public int id_naturalezaproyecto { get; set; }
        public string poblacionobjetivo { get; set; }
        public string numcontratoconvenio { get; set; }
        public string yearsejecucion { get; set; }
        public string plazoejecucion { get; set; }
        public DateTime? fecacuerdovoluntades { get; set; }
        public DateTime? fecactainicio { get; set; }
        public string fichaquipu { get; set; }
        public string codigohermes { get; set; }
        public string objetocontratoactividad { get; set; }
        public int id_alcanceproyecto { get; set; }
        public int adiciondisminucion { get; set; }
        public int? valortotal { get; set; }
        public int id_areaacad { get; set; }
        public int nestudiantesderecho { get; set; }
        public int nestudiantespolitica { get; set; }
        public int nestudiantespostgrados { get; set; }
        public string numerosar { get; set; }
        public string numeroodsops { get; set; }
        public int id_estadocontrato { get; set; }
        public string consecutivo { get; set; }
        public int iddirector { get; set; }
        public int idsupervisor { get; set; }
        public int idasistente { get; set; }
        public int? idregistrorup { get; set; }
        public int? idarchivoentrega { get; set; }
        public string contratoconvenioenlace { get; set; }
        public string entregaarchivoenlace { get; set; }
        public int? aportefacultad { get; set; }
        public int? aportevir { get; set; }
        public int? aportedieb { get; set; }
        public int? aprobadoconvenio { get; set; }
        // qry 16
        public string numeromodificaciones { get; set; }
        //qry 19
        //qry 20
        public string proyectos { get; set; }
        public string transferencia { get; set; }
        //qry 23
        public int id_liqfinalizacion { get; set; }
        public bool ingresos { get; set; }
        public bool pagos { get; set; }
        public bool transferencias { get; set; }
        public bool liquidacioninternahermes { get; set; }
        public string resumenestado { get; set; }
        public DateTime? fechafincontratoasistente { get; set; }
        public string ordenesnumhermes { get; set; }
        public string matrizsegejecucion { get; set; }
        public string transferenciascope { get; set; }
        public string balfifinalfirmado { get; set; }
        public string subproyectofinhermes { get; set; }
        public string proacahermesuncompdrive { get; set; }
        public string correoinstitucionalproy { get; set; }
        public string actaliqentidad { get; set; }
        public string entregaarchivoce { get; set; }
        public string resolucionliqinterna { get; set; }
        public string consecutivosrequerimientos { get; set; }
        public DateTime? fecultimarev { get; set; }
        public DateTime? fechacreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string pagoscumplidos { get; set; }
        public DateTime? fechaestado { get; set; }
        public string informefinal { get; set; }
        public string informefinalenlace { get; set; }
        public string observaciones { get; set; }
        public string productoacademicoenlace { get; set; }
        public string actaliqentidadenlace { get; set; }
        //qry 24
        public DateTime? fecterminacion { get; set; }
        public string estadocontrato { get; set; }
        public string acta { get; set; }
        public DateTime vencimiento { get; set; }

        public string nmorigenpropuesta { get; set; }
        public string nmtipopropuesta { get; set; }
        public string nmestadopropuesta { get; set; }
        public string nombresapell { get; set; }
        public string naturalezaproyecto { get; set; }
        public string alcanceproyecto { get; set; }
        public string nmaacad { get; set; }
        public string director { get; set; }
        public string supervisor { get; set; }
        public string asistente { get; set; }

        public int totalportipousuario { get; set; }
        public int numpropraz { get; set; }
        public string id_kardex { get; set; }
        public int total_inventario { get; set; }
        public int unidades_vendidas { get; set; }
        public int total_ventas { get; set; }
        public int inv_institucional { get; set; }
        public int inv_comercial { get; set; }
        public string nmbodega { get; set;  }
        public int ajustes { get; set; }
        public string nmformatodis { get; set; }

        public DateTime fechavencimiento { get; set; }








    }
}