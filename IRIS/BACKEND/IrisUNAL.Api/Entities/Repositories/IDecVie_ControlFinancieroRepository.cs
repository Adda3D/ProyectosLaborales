using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ControlFinancieroRepository
    {
        IEnumerable<DecVie_ControlFinanciero> GetAllDecVie_ControlFinanciero();
        DecVie_ControlFinanciero GetDecVie_ControlFinancieroDetails(int id_controlfinanciero);
        IEnumerable<DecVie_ControlFinanciero> GetDecVie_ControlFinancieroNombre(string cd_nmpresupuesto);
        bool InsertDecVie_ControlFinanciero(DecVie_ControlFinanciero decVie_ControlFinanciero);
        bool UpdateDecVie_ControlFinanciero(DecVie_ControlFinanciero decVie_ControlFinanciero);
        bool DeleteDecVie_ControlFinanciero(int id_controlfinanciero);
    }
}
