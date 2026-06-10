using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_SubSerieDocRepository
    {
        IEnumerable<DecVie_SubSerieDoc> GetAllDecVie_SubSerieDoc();
        DecVie_SubSerieDoc GetDecVie_SubSerieDocDetails(int id_subseriedoc);
        DecVie_SubSerieDoc GetDecVie_SubSerieDocNombre(string cd_nmsubseriedoc);
        bool InsertDecVie_SubSerieDoc(DecVie_SubSerieDoc decVie_SubSerieDoc);
        bool UpdateDecVie_SubSerieDoc(DecVie_SubSerieDoc decVie_SubSerieDoc);
        bool DeleteDecVie_SubSerieDoc(int id_subseriedoc);
        DataTableAdapter<DecVie_SubSerieDoc> GetDataTableDecVie_SubSerieDoc(DataTableRequest model);
    }
}
