using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ConsecutivoRepository
    {
        IEnumerable<DecVie_Consecutivo> GetAllDecVie_Consecutivo();
        DecVie_Consecutivo GetDecVie_ConsecutivoDetails(int id_decvieconsecutivo);
        DecVie_Consecutivo GetDecVie_ConsecutivoNumero(string cd_numconsecutivo);
        bool InsertDecVie_Consecutivo(DecVie_Consecutivo decVie_Consecutivo);
        DecVie_Consecutivo InsertDecVie_Consecutivo_Data(DecVie_Consecutivo decVie_Consecutivo);
        bool UpdateDecVie_Consecutivo(DecVie_Consecutivo decVie_Consecutivo);
        DecVie_Consecutivo UpdateDecVie_Consecutivo_Data(DecVie_Consecutivo decVie_Consecutivo);
        bool DeleteDecVie_Consecutivo(int id_decvieconsecutivo);
        DataTableAdapter<DecVie_Consecutivo> GetDataTableDecVie_Consecutivo(DataTableRequest model);
    }
}
