using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ColegiadosRepository
    {
        IEnumerable<DecVie_Colegiados> GetAllDecVie_Colegiados();
        DecVie_Colegiados GetDecVie_ColegiadosDetails(int id_colegiado);
        DecVie_Colegiados GetDecVie_ColegiadosNombre(string cd_nmcolegiado);
        bool InsertDecVie_Colegiados(DecVie_Colegiados decVie_Colegiados);
        bool UpdateDecVie_Colegiados(DecVie_Colegiados decVie_Colegiados);
        bool DeleteDecVie_Colegiados(int id_colegiado);
        DataTableAdapter<DecVie_Colegiados> GetDataTableDecVie_Colegiados(DataTableRequest model);
    }
}
