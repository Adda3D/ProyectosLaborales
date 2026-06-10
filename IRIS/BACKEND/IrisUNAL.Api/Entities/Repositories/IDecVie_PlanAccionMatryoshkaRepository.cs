using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionMatryoshkaRepository
    {
        IEnumerable<DecVie_PlanAccionMatryoshka> GetAllDecVie_PlanAccionMatryoshka();
        DecVie_PlanAccionMatryoshka GetDecVie_PlanAccionMatryoshkaDetails(int id_matryoshka);
        bool InsertDecVie_PlanAccionMatryoshka(DecVie_PlanAccionMatryoshka decVie_PlanAccionMatryoshka);
        bool UpdateDecVie_PlanAccionMatryoshka(DecVie_PlanAccionMatryoshka decVie_PlanAccionMatryoshka);
        bool DeleteDecVie_PlanAccionMatryoshka(int id_matryoshka);
        DataTableAdapter<DecVie_PlanAccionMatryoshka> GetDataTableDecVie_PlanAccionMatryoshka(DataTableRequest model);
    }
}
