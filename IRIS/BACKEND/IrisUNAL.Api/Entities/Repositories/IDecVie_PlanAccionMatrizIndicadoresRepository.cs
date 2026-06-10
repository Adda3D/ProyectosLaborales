using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionMatrizIndicadoresRepository
    {
        IEnumerable<DecVie_PlanAccionMatrizIndicadores> GetAllDecVie_PlanAccionMatrizIndicadores();
        DecVie_PlanAccionMatrizIndicadores GetDecVie_PlanAccionMatrizIndicadoresDetails(int id_matrizindicadores);
        bool InsertDecVie_PlanAccionMatrizIndicadores(DecVie_PlanAccionMatrizIndicadores decVie_PlanAccionMatrizIndicadores);
        bool UpdateDecVie_PlanAccionMatrizIndicadores(DecVie_PlanAccionMatrizIndicadores decVie_PlanAccionMatrizIndicadores);
        bool DeleteDecVie_PlanAccionMatrizIndicadores(int id_matrizindicadores);
    }
}
