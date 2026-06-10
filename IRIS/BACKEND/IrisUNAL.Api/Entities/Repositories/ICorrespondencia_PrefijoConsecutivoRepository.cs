using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ICorrespondencia_PrefijoConsecutivoRepository
    {
        IEnumerable<Correspondencia_PrefijoConsecutivo> GetAllCorrespondencia_PrefijoConsecutivo();
        IEnumerable<Correspondencia_PrefijoConsecutivo> GetCorrespondencia_PrefijoConsecutivoByDependencia(int id_depend);
        Correspondencia_PrefijoConsecutivo GetCorrespondencia_PrefijoConsecutivoDetails(int id_prefijoconsecutivo);
        Correspondencia_PrefijoConsecutivo GetCorrespondencia_PrefijoConsecutivoNombre(string cd_nmprefijo);
        bool InsertCorrespondencia_PrefijoConsecutivo(Correspondencia_PrefijoConsecutivo correspondencia_PrefijoConsecutivo);
        bool UpdateCorrespondencia_PrefijoConsecutivo(Correspondencia_PrefijoConsecutivo correspondencia_PrefijoConsecutivo);
        bool DeleteCorrespondencia_PrefijoConsecutivo(int id_prefijoconsecutivo);
        DataTableAdapter<Correspondencia_PrefijoConsecutivo> GetDataTableCorrespondencia_PrefijoConsecutivo(DataTableRequest model);
    }
}
