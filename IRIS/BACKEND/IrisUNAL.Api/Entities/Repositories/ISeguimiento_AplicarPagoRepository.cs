using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_AplicarPagoRepository
    {
        IEnumerable<Seguimiento_AplicarPago> GetAllSeguimiento_AplicarPago();
        Seguimiento_AplicarPago GetSeguimiento_AplicarPagoDetails(int id_aplicarpago);        
        bool InsertSeguimiento_AplicarPago(Seguimiento_AplicarPago seguimiento_AplicarPago);
        bool UpdateSeguimiento_AplicarPago(Seguimiento_AplicarPago seguimiento_AplicarPago);
        bool DeleteSeguimiento_AplicarPago(int id_aplicarpago);
        DataTableAdapter<Seguimiento_AplicarPago> GetDataTablePagosByGastoProyecto(int id_creargasto, DataTableRequest model);
        DataTableAdapter<Seguimiento_AplicarPago> GetDataTablePagosByProyecto(int id_asignacionproyecto, DataTableRequest model);
    }
}
