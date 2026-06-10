using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InstanciasRepository
    {
        IEnumerable<DecVie_Instancias> GetAllDecVie_Instancias();
        DecVie_Instancias GetDecVie_InstanciasDetails(int id_instancia);
        DecVie_Instancias GetDecVie_InstanciasNombre(string cd_nminstancia);
        bool InsertDecVie_Instancias(DecVie_Instancias decVie_Instancias);
        bool UpdateDecVie_Instancias(DecVie_Instancias decVie_Instancias);
        bool DeleteDecVie_Instancias(int id_instancia);
        DataTableAdapter<DecVie_Instancias> GetDataTableDecVie_Instancias(DataTableRequest model);
    }
}
