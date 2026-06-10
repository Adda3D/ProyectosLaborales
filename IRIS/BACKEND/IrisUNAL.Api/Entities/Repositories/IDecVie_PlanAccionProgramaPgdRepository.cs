using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionProgramaPgdRepository
    {
        IEnumerable<DecVie_PlanAccionProgramaPgd> GetAllDecVie_PlanAccionProgramaPgd();
        DecVie_PlanAccionProgramaPgd GetDecVie_PlanAccionProgramaPgdDetails(int id_programapgd);
        DecVie_PlanAccionProgramaPgd GetDecVie_PlanAccionProgramaPgdNombre(string cd_nmprogramapgd);
        bool InsertDecVie_PlanAccionProgramaPgd(DecVie_PlanAccionProgramaPgd decVie_PlanAccionProgramaPgd);
        bool UpdateDecVie_PlanAccionProgramaPgd(DecVie_PlanAccionProgramaPgd decVie_PlanAccionProgramaPgd);
        bool DeleteDecVie_PlanAccionProgramaPgd(int id_programapgd);
        DataTableAdapter<DecVie_PlanAccionProgramaPgd> GetDataTableDecVie_PlanAccionProgramaPgd(DataTableRequest model);
    }
}
