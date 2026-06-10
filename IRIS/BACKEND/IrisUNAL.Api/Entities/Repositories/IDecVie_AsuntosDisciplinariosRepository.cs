using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_AsuntosDisciplinariosRepository
    {
        IEnumerable<DecVie_AsuntosDisciplinarios> GetAllDecVie_AsuntosDisciplinarios();
        DecVie_AsuntosDisciplinarios GetDecVie_AsuntosDisciplinariosDetails(int id_asuntosdisciplinarios);
        DecVie_AsuntosDisciplinarios GetDecVie_AsuntosDisciplinariosNombre(string cd_nmAsuntosDisciplinarios);
        bool InsertDecVie_AsuntosDisciplinarios(DecVie_AsuntosDisciplinarios decVie_AsuntosDisciplinarios);
        bool UpdateDecVie_AsuntosDisciplinarios(DecVie_AsuntosDisciplinarios decVie_AsuntosDisciplinarios);
        bool DeleteDecVie_AsuntosDisciplinarios(int id_asuntosdisciplinarios);
        DataTableAdapter<DecVie_AsuntosDisciplinarios> GetDataTableDecVie_AsuntosDisciplinarios(DataTableRequest model);
    }
}
