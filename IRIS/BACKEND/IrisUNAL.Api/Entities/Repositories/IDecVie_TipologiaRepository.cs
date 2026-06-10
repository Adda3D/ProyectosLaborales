using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_TipologiaRepository
    {
        IEnumerable<DecVie_Tipologia> GetAllDecVie_Tipologia();
        DecVie_Tipologia GetDecVie_TipologiaDetails(int id_decvietipologia);
        DecVie_Tipologia GetDecVie_TipologiaNombre(string cd_nmdecvietipologia);
        bool InsertDecVie_Tipologia(DecVie_Tipologia decVie_Tipologia);
        bool UpdateDecVie_Tipologia(DecVie_Tipologia decVie_Tipologia);
        bool DeleteDecVie_Tipologia(int id_decvietipologia);
        DataTableAdapter<DecVie_Tipologia> GetDataTableDecVieTipologia(DataTableRequest model);
    }
}
