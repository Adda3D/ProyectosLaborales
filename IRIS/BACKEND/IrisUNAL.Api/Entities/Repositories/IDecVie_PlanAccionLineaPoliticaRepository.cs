using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionLineaPoliticaRepository
    {
        IEnumerable<DecVie_PlanAccionLineaPolitica> GetAllDecVie_PlanAccionLineaPolitica();
        DecVie_PlanAccionLineaPolitica GetDecVie_PlanAccionLineaPoliticaDetails(int id_lineapolitica);
        DecVie_PlanAccionLineaPolitica GetDecVie_PlanAccionLineaPoliticaNombre(string cd_lineapolitica);
        bool InsertDecVie_PlanAccionLineaPolitica(DecVie_PlanAccionLineaPolitica decVie_PlanAccionLineaPolitica);
        bool UpdateDecVie_PlanAccionLineaPolitica(DecVie_PlanAccionLineaPolitica decVie_PlanAccionLineaPolitica);
        bool DeleteDecVie_PlanAccionLineaPolitica(int id_lineapolitica);
        DataTableAdapter<DecVie_PlanAccionLineaPolitica> GetDataTableDecVie_PlanAccionLineaPolitica(DataTableRequest model);
    }
}
