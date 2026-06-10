using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EvaluacionesRepository
    {
        IEnumerable<Publicaciones_Evaluaciones> GetAllPublicaciones_Evaluaciones();
        Publicaciones_Evaluaciones GetPublicaciones_EvaluacionesDetails(int id_evaluaciones);        
        bool InsertPublicaciones_Evaluaciones(Publicaciones_Evaluaciones publicaciones_Evaluaciones);
        bool UpdatePublicaciones_Evaluaciones(Publicaciones_Evaluaciones publicaciones_Evaluaciones);
        bool DeletePublicaciones_Evaluaciones(int id_evaluaciones);
        Publicaciones_Evaluaciones GetPublicaciones_EvaluacionesByPublicacion(int id_crearpublicacion);
    }
}
