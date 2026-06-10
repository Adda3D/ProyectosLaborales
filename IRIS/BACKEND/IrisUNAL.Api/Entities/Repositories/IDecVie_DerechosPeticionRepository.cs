using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_DerechosPeticionRepository
    {
        IEnumerable<DecVie_DerechosPeticion> GetAllDecVie_DerechosPeticion();
        DecVie_DerechosPeticion GetDecVie_DerechosPeticionDetails(int id_derechopeticion);
        DecVie_DerechosPeticion GetDecVie_DerechosPeticionNumero(string cd_numradicacion);
        bool InsertDecVie_DerechosPeticion(DecVie_DerechosPeticion decVie_DerechosPeticion);
        bool UpdateDecVie_DerechosPeticion(DecVie_DerechosPeticion decVie_DerechosPeticion);
        bool DeleteDecVie_DerechosPeticion(int id_derechopeticion);
        DataTableAdapter<DecVie_DerechosPeticion> GetDataTableDecVie_DerechosPeticion(DataTableRequest model);
    }
}
