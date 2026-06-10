using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_ContrapartidaRepository
    {
        IEnumerable<Investigacion_Contrapartida> GetAllInvestigacion_Contrapartida();
        Investigacion_Contrapartida GetInvestigacion_ContrapartidaDetails(int id_contrapartida);
        IEnumerable<Investigacion_Contrapartida> GetInvestigacion_ContrapartidaCodigo(string codigohermes);
        bool InsertInvestigacion_Contrapartida(Investigacion_Contrapartida investigacion_Contrapartida);
        bool UpdateInvestigacion_Contrapartida(Investigacion_Contrapartida investigacion_Contrapartida);
        bool DeleteInvestigacion_Contrapartida(int id_contrapartida);
    }
}
