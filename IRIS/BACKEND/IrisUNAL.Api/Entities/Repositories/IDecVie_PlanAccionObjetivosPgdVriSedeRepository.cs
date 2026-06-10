using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionObjetivosPgdVriSedeRepository
    {
        IEnumerable<DecVie_PlanAccionObjetivosPgdVriSede> GetAllDecVie_PlanAccionObjetivosPgdVriSede();
        DecVie_PlanAccionObjetivosPgdVriSede GetDecVie_PlanAccionObjetivosPgdVriSedeDetails(int id_objetivopgdvrisede);
        DecVie_PlanAccionObjetivosPgdVriSede GetDecVie_PlanAccionObjetivosPgdVriSedeNombre(string cd_nmobjetivopgdvrisede);
        bool InsertDecVie_PlanAccionObjetivosPgdVriSede(DecVie_PlanAccionObjetivosPgdVriSede decVie_PlanAccionObjetivosPgdVriSede);
        bool UpdateDecVie_PlanAccionObjetivosPgdVriSede(DecVie_PlanAccionObjetivosPgdVriSede decVie_PlanAccionObjetivosPgdVriSede);
        bool DeleteDecVie_PlanAccionObjetivosPgdVriSede(int id_objetivopgdvrisede);
        DataTableAdapter<DecVie_PlanAccionObjetivosPgdVriSede> GetDataTableDecVie_PlanAccionObjetivosPgdVriSede(DataTableRequest model);
    }
}
