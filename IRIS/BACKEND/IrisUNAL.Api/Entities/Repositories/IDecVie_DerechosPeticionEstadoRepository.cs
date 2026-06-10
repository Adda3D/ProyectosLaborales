using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_DerechosPeticionEstadoRepository
    {
        IEnumerable<DecVie_DerechosPeticionEstado> GetAllDecVie_DerechosPeticionEstado();
        DecVie_DerechosPeticionEstado GetDecVie_DerechosPeticionEstadoDetails(int id_estadoderpet);
        DecVie_DerechosPeticionEstado GetDecVie_DerechosPeticionEstadoNombre(string cd_nmestadoderpet);
        bool InsertDecVie_DerechosPeticionEstado(DecVie_DerechosPeticionEstado decVie_DerechosPeticionEstado);
        bool UpdateDecVie_DerechosPeticionEstado(DecVie_DerechosPeticionEstado decVie_DerechosPeticionEstado);
        bool DeleteDecVie_DerechosPeticionEstado(int id_estadoderpet);
        DataTableAdapter<DecVie_DerechosPeticionEstado> GetDataTableDecVie_DerechosPeticionEstado(DataTableRequest model);
    }
}
