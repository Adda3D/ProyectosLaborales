using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_DependenciaRepository
    {
        IEnumerable<DecVie_Dependencia> GetAllDecVie_Dependencia();
        DecVie_Dependencia GetDecVie_DependenciaDetails(int id_decviedependencia);
        DecVie_Dependencia GetDecVie_DependenciaNombre(string cd_nmdecviedependencia);
        bool InsertDecVie_Dependencia(DecVie_Dependencia decVie_Dependencia);
        bool UpdateDecVie_Dependencia(DecVie_Dependencia decVie_Dependencia);
        bool DeleteDecVie_Dependencia(int id_decviedependencia);
        DataTableAdapter<DecVie_Dependencia> GetDataTableDecVie_Dependencia(DataTableRequest model);
    }
}
