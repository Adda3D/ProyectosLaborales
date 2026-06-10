using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_SeguimientoRepository
    {
        IEnumerable<Investigacion_Seguimiento> GetAllInvestigacion_Seguimiento();
        Investigacion_Seguimiento GetInvestigacion_SeguimientoDetails(int id_seguimiento);
        Investigacion_Seguimiento GetInvestigacion_SeguimientoDescripcion(string seguimiento);
        bool InsertInvestigacion_Seguimiento(Investigacion_Seguimiento investigacion_Seguimiento);
        bool UpdateInvestigacion_Seguimiento(Investigacion_Seguimiento investigacion_Seguimiento);
        bool DeleteInvestigacion_Seguimiento(int id_seguimiento);
        DataTableAdapter<Investigacion_Seguimiento> GetDataTableInvestigacion_Seguimiento(DataTableRequest model);
    }
}
