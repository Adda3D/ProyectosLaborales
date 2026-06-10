using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_DesembolsoRepository
    {
        IEnumerable<Seguimiento_Desembolso> GetAllSeguimiento_Desembolso();
        Seguimiento_Desembolso GetSeguimiento_DesembolsoDetails(int id_segdesembolso);       
        bool InsertSeguimiento_Desembolso(Seguimiento_Desembolso seguimiento_Desembolso);
        bool UpdateSeguimiento_Desembolso(Seguimiento_Desembolso seguimiento_Desembolso);
        bool DeleteSeguimiento_Desembolso(int id_segdesembolso);
        DataTableAdapter<Seguimiento_Desembolso> GetDataTableProyectoDesembolsosByProyecto(int id_asignacionproyecto, DataTableRequest model);
    }
}
