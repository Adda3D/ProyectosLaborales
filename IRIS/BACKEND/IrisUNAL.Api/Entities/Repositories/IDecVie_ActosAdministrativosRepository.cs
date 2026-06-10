using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ActosAdministrativosRepository
    {
        IEnumerable<DecVie_ActosAdministrativos> GetAllDecVie_ActosAdministrativos();
        DecVie_ActosAdministrativos GetDecVie_ActosAdministrativosDetails(int id_actoadministrativo);
        DecVie_ActosAdministrativos GetDecVie_ActosAdministrativosConsecutivo(string cd_consecutivoactoadministrativo);
        bool InsertDecVie_ActosAdministrativos(DecVie_ActosAdministrativos decVie_ActosAdministrativos);
        bool UpdateDecVie_ActosAdministrativos(DecVie_ActosAdministrativos decVie_ActosAdministrativos);
        bool DeleteDecVie_ActosAdministrativos(int id_actoadministrativo);
        DataTableAdapter<DecVie_ActosAdministrativos> GetDataTableDecVie_ActosAdministrativos(DataTableRequest model);
        string ExcelDecVie_ActosAdministrativos();
    }
}
