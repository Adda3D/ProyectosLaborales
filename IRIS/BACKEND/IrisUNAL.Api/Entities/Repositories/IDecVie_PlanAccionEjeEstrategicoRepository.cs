using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionEjeEstrategicoRepository
    {
        IEnumerable<DecVie_PlanAccionEjeEstrategico> GetAllDecVie_PlanAccionEjeEstrategico();
        DecVie_PlanAccionEjeEstrategico GetDecVie_PlanAccionEjeEstrategicoDetails(int id_ejeestrategico);
        DecVie_PlanAccionEjeEstrategico GetDecVie_PlanAccionEjeEstrategicoNombre(string cd_ejeestrategico);
        bool InsertDecVie_PlanAccionEjeEstrategico(DecVie_PlanAccionEjeEstrategico decVie_PlanAccionEjeEstrategico);
        bool UpdateDecVie_PlanAccionEjeEstrategico(DecVie_PlanAccionEjeEstrategico decVie_PlanAccionEjeEstrategico);
        bool DeleteDecVie_PlanAccionEjeEstrategico(int id_ejeestrategico);
        DataTableAdapter<DecVie_PlanAccionEjeEstrategico> GetDataTableDecVie_PlanAccionEjeEstrategico(DataTableRequest model);
    }
}
