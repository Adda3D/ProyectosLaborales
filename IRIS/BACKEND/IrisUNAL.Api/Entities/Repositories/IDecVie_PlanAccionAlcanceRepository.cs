using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionAlcanceRepository
    {
        IEnumerable<DecVie_PlanAccionAlcance> GetAllDecVie_PlanAccionAlcance();
        DecVie_PlanAccionAlcance GetDecVie_PlanAccionAlcanceDetails(int id_planaccionalcance);
        DecVie_PlanAccionAlcance GetDecVie_PlanAccionAlcanceNombre(string cd_descripcionalcance);
        bool InsertDecVie_PlanAccionAlcance(DecVie_PlanAccionAlcance decVie_PlanAccionAlcance);
        bool UpdateDecVie_PlanAccionAlcance(DecVie_PlanAccionAlcance decVie_PlanAccionAlcance);
        bool DeleteDecVie_PlanAccionAlcance(int id_planaccionalcance);
        DataTableAdapter<DecVie_PlanAccionAlcance> GetDataTableDecVie_PlanAccionAlcance(DataTableRequest model);
    }
}
