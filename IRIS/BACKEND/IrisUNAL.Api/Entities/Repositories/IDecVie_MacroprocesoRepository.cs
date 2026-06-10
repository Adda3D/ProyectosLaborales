using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_MacroprocesoRepository
    {
        IEnumerable<DecVie_Macroproceso> GetAllDecVie_Macroproceso();
        DecVie_Macroproceso GetDecVie_MacroprocesoDetails(int id_decviemacroproceso);
        DecVie_Macroproceso GetDecVie_MacroprocesoNombre(string cd_nmdecviemacroproceso);
        bool InsertDecVie_Macroproceso(DecVie_Macroproceso decVie_Macroproceso);
        bool UpdateDecVie_Macroproceso(DecVie_Macroproceso decVie_Macroproceso);
        bool DeleteDecVie_Macroproceso(int id_decviemacroproceso);
        DataTableAdapter<DecVie_Macroproceso> GetDataTableDecVie_Macroproceso(DataTableRequest model);
    }
}
