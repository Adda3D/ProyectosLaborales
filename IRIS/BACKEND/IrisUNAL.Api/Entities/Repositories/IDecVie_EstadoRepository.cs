using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_EstadoRepository
    {
        IEnumerable<DecVie_Estado> GetAllDecVie_Estado();
        DecVie_Estado GetDecVie_EstadoDetails(int id_decvieestado);
        DecVie_Estado GetDecVie_EstadoNombre(string cd_nmdecvieestado);
        bool InsertDecVie_Estado(DecVie_Estado decVie_Estado);
        bool UpdateDecVie_Estado(DecVie_Estado decVie_Estado);
        bool DeleteDecVie_Estado(int id_decvieestado);
        DataTableAdapter<DecVie_Estado> GetDataTableDecVie_Estado(DataTableRequest model);
    }
}
