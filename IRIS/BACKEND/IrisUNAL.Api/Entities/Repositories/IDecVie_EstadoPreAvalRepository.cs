using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_EstadoPreAvalRepository
    {
        IEnumerable<DecVie_EstadoPreAval> GetAllDecVie_EstadoPreAval();
        DecVie_EstadoPreAval GetDecVie_EstadoPreAvalDetails(int id_estadopreaval);
        DecVie_EstadoPreAval GetDecVie_EstadoPreAvalNombre(string cd_nmestadopreaval);
        bool InsertDecVie_EstadoPreAval(DecVie_EstadoPreAval decVie_EstadoPreAval);
        bool UpdateDecVie_EstadoPreAval(DecVie_EstadoPreAval decVie_EstadoPreAval);
        bool DeleteDecVie_EstadoPreAval(int id_estadopreaval);
        DataTableAdapter<DecVie_EstadoPreAval> GetDataTableDecVie_EstadoPreAval(DataTableRequest model);
    }
}
