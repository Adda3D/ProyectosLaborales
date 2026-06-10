using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionObjetivoEstrategicoRepository
    {
        IEnumerable<DecVie_PlanAccionObjetivoEstrategico> GetAllDecVie_PlanAccionObjetivoEstrategico();
        DecVie_PlanAccionObjetivoEstrategico GetDecVie_PlanAccionObjetivoEstrategicoDetails(int id_objetivoestrategico);
        DecVie_PlanAccionObjetivoEstrategico GetDecVie_PlanAccionObjetivoEstrategicoNombre(string cd_objetivoestrategico);
        bool InsertDecVie_PlanAccionObjetivoEstrategico(DecVie_PlanAccionObjetivoEstrategico decVie_PlanAccionObjetivoEstrategico);
        bool UpdateDecVie_PlanAccionObjetivoEstrategico(DecVie_PlanAccionObjetivoEstrategico decVie_PlanAccionObjetivoEstrategico);
        bool DeleteDecVie_PlanAccionObjetivoEstrategico(int id_objetivoestrategico);
        DataTableAdapter<DecVie_PlanAccionObjetivoEstrategico> GetDataTableDecVie_PlanAccionObjetivoEstrategico(DataTableRequest model);
    }
}
