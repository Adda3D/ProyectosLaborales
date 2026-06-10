using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ActosAdministrativosTipoRepository
    {
        IEnumerable<DecVie_ActosAdministrativosTipo> GetAllDecVie_ActosAdministrativosTipo();
        DecVie_ActosAdministrativosTipo GetDecVie_ActosAdministrativosTipoDetails(int id_tipoactoadministrativo);
        DecVie_ActosAdministrativosTipo GetDecVie_ActosAdministrativosTipoNombre(string cd_nmidtipoactoadministrativo);
        bool InsertDecVie_ActosAdministrativosTipo(DecVie_ActosAdministrativosTipo decVie_ActosAdministrativosTipo);
        bool UpdateDecVie_ActosAdministrativosTipo(DecVie_ActosAdministrativosTipo decVie_ActosAdministrativosTipo);
        bool DeleteDecVie_ActosAdministrativosTipo(int id_tipoactoadministrativo);
        DataTableAdapter<DecVie_ActosAdministrativosTipo> GetDataTableDecVie_ActosAdministrativosTipo(DataTableRequest model);
    }
}
