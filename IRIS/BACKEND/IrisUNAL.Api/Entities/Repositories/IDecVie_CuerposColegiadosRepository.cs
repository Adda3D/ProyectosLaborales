using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_CuerposColegiadosRepository
    {
        IEnumerable<DecVie_CuerposColegiados> GetAllDecVie_CuerposColegiados();
        DecVie_CuerposColegiados GetDecVie_CuerposColegiadosDetails(int id_cuerposcolegiados);
        DecVie_CuerposColegiados GetDecVie_CuerposColegiadosNumero(string cd_numacta);
        bool InsertDecVie_CuerposColegiados(DecVie_CuerposColegiados decVie_CuerposColegiados);
        bool UpdateDecVie_CuerposColegiados(DecVie_CuerposColegiados decVie_CuerposColegiados);
        bool DeleteDecVie_CuerposColegiados(int id_cuerposcolegiados);
        DataTableAdapter<DecVie_CuerposColegiados> GetDataTableDecVie_CuerposColegiados(DataTableRequest model);
    }
}
