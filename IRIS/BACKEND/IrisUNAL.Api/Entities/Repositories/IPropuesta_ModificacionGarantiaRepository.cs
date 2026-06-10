using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_ModificacionGarantiaRepository
    {
        IEnumerable<Propuesta_ModificacionGarantia> GetAllPropuesta_ModificacionGarantia();
        Propuesta_ModificacionGarantia GetPropuesta_ModificacionGarantiaDetails(int id_modificaciongarantia);
        Propuesta_ModificacionGarantia GetPropuesta_ModificacionGarantiaPoliza(int id_suscripciongarantia);
        bool InsertPropuesta_ModificacionGarantia(Propuesta_ModificacionGarantia propuesta_ModificacionGarantia);
        bool UpdatePropuesta_ModificacionGarantia(Propuesta_ModificacionGarantia propuesta_ModificacionGarantia);
        bool DeletePropuesta_ModificacionGarantia(int id_modificaciongarantia);
        DataTableAdapter<Propuesta_ModificacionGarantia> GetDataTablePropuestaModificacionGarantiaByGarantia(int id_suscripciongarantia, DataTableRequest model);
        DataTableAdapter<Propuesta_ModificacionGarantia> GetDataTablePropuestaModificacionGarantiaByPropuesta(int id_propuesta, DataTableRequest model);
    }
}
