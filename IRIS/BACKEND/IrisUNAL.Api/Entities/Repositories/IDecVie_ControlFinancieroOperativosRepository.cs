using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ControlFinancieroOperativosRepository
    {
        IEnumerable<DecVie_ControlFinancieroOperativos> GetAllDecVie_ControlFinancieroOperativos();
        DecVie_ControlFinancieroOperativos GetDecVie_ControlFinancieroOperativosDetails(int id_operativos);
        bool InsertDecVie_ControlFinancieroOperativos(DecVie_ControlFinancieroOperativos decVie_ControlFinancieroOperativos);
        bool UpdateDecVie_ControlFinancieroOperativos(DecVie_ControlFinancieroOperativos decVie_ControlFinancieroOperativos);
        bool DeleteDecVie_ControlFinancieroOperativos(int id_operativos);
    }
}
