using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionTipoIndicadorRepository
    {
        IEnumerable<DecVie_PlanAccionTipoIndicador> GetAllDecVie_PlanAccionTipoIndicador();
        DecVie_PlanAccionTipoIndicador GetDecVie_PlanAccionTipoIndicadorDetails(int id_tipoindicador);
        DecVie_PlanAccionTipoIndicador GetDecVie_PlanAccionTipoIndicadorNombre(string cd_nmtipoindicador);
        bool InsertDecVie_PlanAccionTipoIndicador(DecVie_PlanAccionTipoIndicador decVie_PlanAccionTipoIndicador);
        bool UpdateDecVie_PlanAccionTipoIndicador(DecVie_PlanAccionTipoIndicador decVie_PlanAccionTipoIndicador);
        bool DeleteDecVie_PlanAccionTipoIndicador(int id_tipoindicador);
        DataTableAdapter<DecVie_PlanAccionTipoIndicador> GetDataTableDecVie_PlanAccionTipoIndicador(DataTableRequest model);
    }
}
