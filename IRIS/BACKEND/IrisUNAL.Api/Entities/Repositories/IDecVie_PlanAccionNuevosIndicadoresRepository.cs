using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionNuevosIndicadoresRepository
    {
        IEnumerable<DecVie_PlanAccionNuevosIndicadores> GetAllDecVie_PlanAccionNuevosIndicadores();
        DecVie_PlanAccionNuevosIndicadores GetDecVie_PlanAccionNuevosIndicadoresDetails(int id_nuevosindicadores);
        DecVie_PlanAccionNuevosIndicadores GetDecVie_PlanAccionNuevosIndicadoresNombre(string cd_nmnuevosindicadores);
        bool InsertDecVie_PlanAccionNuevosIndicadores(DecVie_PlanAccionNuevosIndicadores decVie_PlanAccionNuevosIndicadores);
        bool UpdateDecVie_PlanAccionNuevosIndicadores(DecVie_PlanAccionNuevosIndicadores decVie_PlanAccionNuevosIndicadores);
        bool DeleteDecVie_PlanAccionNuevosIndicadores(int id_nuevosindicadores);
        DataTableAdapter<DecVie_PlanAccionNuevosIndicadores> GetDataTableDecVie_PlanAccionNuevosIndicadores(DataTableRequest model);
    }
}
