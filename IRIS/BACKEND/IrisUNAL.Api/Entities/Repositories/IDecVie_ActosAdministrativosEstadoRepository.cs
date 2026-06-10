using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ActosAdministrativosEstadoRepository
    {
        IEnumerable<DecVie_ActosAdministrativosEstado> GetAllDecVie_ActosAdministrativosEstado();
        DecVie_ActosAdministrativosEstado GetDecVie_ActosAdministrativosEstadoDetails(int id_estadoactoadministrativo);
        DecVie_ActosAdministrativosEstado GetDecVie_ActosAdministrativosEstadoNombre(string cd_nmestadoactoadministrativo);
        bool InsertDecVie_ActosAdministrativosEstado(DecVie_ActosAdministrativosEstado decVie_ActosAdministrativosEstado);
        bool UpdateDecVie_ActosAdministrativosEstado(DecVie_ActosAdministrativosEstado decVie_ActosAdministrativosEstado);
        bool DeleteDecVie_ActosAdministrativosEstado(int id_estadoactoadministrativo);
        DataTableAdapter<DecVie_ActosAdministrativosEstado> GetDataTableDecVie_ActosAdministrativosEstado(DataTableRequest model);
    }
}
