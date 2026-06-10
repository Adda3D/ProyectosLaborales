using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionObjetivoDependenciaRepository
    {
        IEnumerable<DecVie_PlanAccionObjetivoDependencia> GetAllDecVie_PlanAccionObjetivoDependencia();
        DecVie_PlanAccionObjetivoDependencia GetDecVie_PlanAccionObjetivoDependenciaDetails(int id_objetivodependencia);
        DecVie_PlanAccionObjetivoDependencia GetDecVie_PlanAccionObjetivoDependenciaNombre(string cd_nmobjetivodependencia);
        bool InsertDecVie_PlanAccionObjetivoDependencia(DecVie_PlanAccionObjetivoDependencia decVie_PlanAccionObjetivoDependencia);
        bool UpdateDecVie_PlanAccionObjetivoDependencia(DecVie_PlanAccionObjetivoDependencia decVie_PlanAccionObjetivoDependencia);
        bool DeleteDecVie_PlanAccionObjetivoDependencia(int id_objetivodependencia);
        DataTableAdapter<DecVie_PlanAccionObjetivoDependencia> GetDataTableDecVie_PlanAccionObjetivoDependencia(DataTableRequest model);
    }
}
