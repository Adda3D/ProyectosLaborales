using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_TipoDocContractualesRepository
    {
        IEnumerable<DecVie_TipoDocContractuales> GetAllDecVie_TipoDocContractuales();
        DecVie_TipoDocContractuales GetDecVie_TipoDocContractualesDetails(int id_doccontractuales);
        DecVie_TipoDocContractuales GetDecVie_TipoDocContractualesNombre(string cd_nmdoccontractuales);
        bool InsertDecVie_TipoDocContractuales(DecVie_TipoDocContractuales decVie_TipoDocContractuales);
        bool UpdateDecVie_TipoDocContractuales(DecVie_TipoDocContractuales decVie_TipoDocContractuales);
        bool DeleteDecVie_TipoDocContractuales(int id_doccontractuales);
        DataTableAdapter<DecVie_TipoDocContractuales> GetDataTableDecVie_TipoDocContractuales(DataTableRequest model);
    }
}
