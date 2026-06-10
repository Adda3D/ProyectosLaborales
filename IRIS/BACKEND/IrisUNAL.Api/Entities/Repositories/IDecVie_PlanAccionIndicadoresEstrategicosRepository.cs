using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionIndicadoresEstrategicosRepository
    {
        IEnumerable<DecVie_PlanAccionIndicadoresEstrategicos> GetAllDecVie_PlanAccionIndicadoresEstrategicos();
        DecVie_PlanAccionIndicadoresEstrategicos GetDecVie_PlanAccionIndicadoresEstrategicosDetails(int id_indicadoresestrategicos);
        DecVie_PlanAccionIndicadoresEstrategicos GetDecVie_PlanAccionIndicadoresEstrategicosNombre(string cd_nmindicadoresestrategicos);
        bool InsertDecVie_PlanAccionIndicadoresEstrategicos(DecVie_PlanAccionIndicadoresEstrategicos decVie_PlanAccionIndicadoresEstrategicos);
        bool UpdateDecVie_PlanAccionIndicadoresEstrategicos(DecVie_PlanAccionIndicadoresEstrategicos decVie_PlanAccionIndicadoresEstrategicos);
        bool DeleteDecVie_PlanAccionIndicadoresEstrategicos(int id_indicadoresestrategicos);
        DataTableAdapter<DecVie_PlanAccionIndicadoresEstrategicos> GetDataTableDecVie_PlanAccionIndicadoresEstrategicos(DataTableRequest model);
    }
}
