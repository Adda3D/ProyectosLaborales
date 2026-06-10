using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CesionDerechosRepository
    {
        IEnumerable<Publicaciones_CesionDerechos> GetAllPublicaciones_CesionDerechos();
        Publicaciones_CesionDerechos GetPublicaciones_CesionDerechosDetails(int id_cesionderechos);
        Publicaciones_CesionDerechos GetPublicaciones_CesionDerechosByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_CesionDerechos(Publicaciones_CesionDerechos publicaciones_CesionDerechos);
        bool UpdatePublicaciones_CesionDerechos(Publicaciones_CesionDerechos publicaciones_CesionDerechos);
        bool DeletePublicaciones_CesionDerechos(int id_cesionderechos);
    }
}
