using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_ActoAdmonContrapartidaRepository
    {
        IEnumerable<Investigacion_ActoAdmonContrapartida> GetAllInvestigacion_ActoAdmonContrapartida();
        Investigacion_ActoAdmonContrapartida GetInvestigacion_ActoAdmonContrapartidaDetails(int id_actoadmoncontrapartida);
        Investigacion_ActoAdmonContrapartida GetInvestigacion_ActoAdmonContrapartidaCodigo(string codigohermes);
        bool InsertInvestigacion_ActoAdmonContrapartida(Investigacion_ActoAdmonContrapartida investigacion_ActoAdmonContrapartida);
        bool UpdateInvestigacion_ActoAdmonContrapartida(Investigacion_ActoAdmonContrapartida investigacion_ActoAdmonContrapartida);
        bool DeleteInvestigacion_ActoAdmonContrapartida(int id_actoadmoncontrapartida);
        DataTableAdapter<Investigacion_ActoAdmonContrapartida> GetDataTableInvestigacion_ActoAdmonContrapartida(DataTableRequest model);
    }
}
