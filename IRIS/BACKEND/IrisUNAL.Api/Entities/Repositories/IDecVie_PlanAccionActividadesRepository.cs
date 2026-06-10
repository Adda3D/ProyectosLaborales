using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionActividadesRepository
    {
        IEnumerable<DecVie_PlanAccionActividades> GetAllDecVie_PlanAccionActividades();
        DecVie_PlanAccionActividades GetDecVie_PlanAccionActividadesDetails(int id_actividades);
        DecVie_PlanAccionActividades GetDecVie_PlanAccionActividadesNombre(string cd_nmactividad);
        bool InsertDecVie_PlanAccionActividades(DecVie_PlanAccionActividades decVie_PlanAccionActividades);
        bool UpdateDecVie_PlanAccionActividades(DecVie_PlanAccionActividades decVie_PlanAccionActividades);
        bool DeleteDecVie_PlanAccionActividades(int id_actividades);
        DataTableAdapter<DecVie_PlanAccionActividades> GetDataTableDecVie_PlanAccionActividades(DataTableRequest model);
    }
}
