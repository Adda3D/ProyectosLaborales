using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EvaluadoresRepository
    {
        IEnumerable<Publicaciones_Evaluadores> GetAllPublicaciones_Evaluadores();
        Publicaciones_Evaluadores GetPublicaciones_EvaluadoresDetails(int id_evaluadores);
        IEnumerable<Publicaciones_Evaluadores> GetPublicaciones_EvaluadoresByPublicacion(int id_crearpublicacion);
        Publicaciones_Evaluadores GetPublicaciones_EvaluadoresExisteEvaluador(int id_crearpublicacion, int id_persona);
        bool InsertPublicaciones_Evaluadores(Publicaciones_Evaluadores publicaciones_Evaluadores);
        bool UpdatePublicaciones_Evaluadores(Publicaciones_Evaluadores publicaciones_Evaluadores);
        bool DeletePublicaciones_Evaluadores(int id_evaluadores);
        DataTableAdapter<Publicaciones_Evaluadores> GetDataTablePublicaciones_EvaluadoresByPublicacion(int id_crearpublicacion, DataTableRequest model);
    }
}
