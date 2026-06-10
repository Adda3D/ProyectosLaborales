using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_RadicadorCorRepository
    {
        IEnumerable<DecVie_RadicadorCor> GetAllDecVie_RadicadorCor();
        DecVie_RadicadorCor GetDecVie_RadicadorCorDetails(int id_radicadorcor);
        DecVie_RadicadorCor GetDecVie_RadicadorCorNombre(string cd_numerodocumento);
        bool InsertDecVie_RadicadorCor(DecVie_RadicadorCor decVie_RadicadorCor);
        bool UpdateDecVie_RadicadorCor(DecVie_RadicadorCor decVie_RadicadorCor);
        bool DeleteDecVie_RadicadorCor(int id_radicadorcor);
        DataTableAdapter<DecVie_RadicadorCor> GetDataTableDecVie_RadicadorCor(DataTableRequest model);
    }
}
