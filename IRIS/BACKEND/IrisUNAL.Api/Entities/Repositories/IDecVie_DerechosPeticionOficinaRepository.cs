using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_DerechosPeticionOficinaRepository
    {
        IEnumerable<DecVie_DerechosPeticionOficina> GetAllDecVie_DerechosPeticionOficina();
        DecVie_DerechosPeticionOficina GetDecVie_DerechosPeticionOficinaDetails(int id_oficina);
        DecVie_DerechosPeticionOficina GetDecVie_DerechosPeticionOficinaNombre(string cd_nmoficina);
        bool InsertDecVie_DerechosPeticionOficina(DecVie_DerechosPeticionOficina decVie_DerechosPeticionOficina);
        bool UpdateDecVie_DerechosPeticionOficina(DecVie_DerechosPeticionOficina decVie_DerechosPeticionOficina);
        bool DeleteDecVie_DerechosPeticionOficina(int id_oficina);
        DataTableAdapter<DecVie_DerechosPeticionOficina> GetDataTableDecVie_DerechosPeticionOficina(DataTableRequest model);
    }
}
