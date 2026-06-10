using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionProgramaFdcpsRepository
    {
        IEnumerable<DecVie_PlanAccionProgramaFdcps> GetAllDecVie_PlanAccionProgramaFdcps();
        DecVie_PlanAccionProgramaFdcps GetDecVie_PlanAccionProgramaFdcpsDetails(int id_programafdcps);
        DecVie_PlanAccionProgramaFdcps GetDecVie_PlanAccionProgramaFdcpsNombre(string cd_programafacultad);
        bool InsertDecVie_PlanAccionProgramaFdcps(DecVie_PlanAccionProgramaFdcps decVie_PlanAccionProgramaFdcps);
        bool UpdateDecVie_PlanAccionProgramaFdcps(DecVie_PlanAccionProgramaFdcps decVie_PlanAccionProgramaFdcps);
        bool DeleteDecVie_PlanAccionProgramaFdcps(int id_programafdcps);
        DataTableAdapter<DecVie_PlanAccionProgramaFdcps> GetDataTableDecVie_PlanAccionProgramaFdcps(DataTableRequest model);
    }
}
