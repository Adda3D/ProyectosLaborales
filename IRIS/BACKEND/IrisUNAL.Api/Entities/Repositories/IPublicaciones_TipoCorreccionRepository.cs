using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
   public interface IPublicaciones_TipoCorreccionRepository
    {
        IEnumerable<Publicaciones_TipoCorreccion> GetAllPublicaciones_TipoCorreccion();
        Publicaciones_TipoCorreccion GetPublicaciones_TipoCorreccionDetails(int id_tipocorreccion);
        Publicaciones_TipoCorreccion GetPublicaciones_TipoCorreccionByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_TipoCorreccion(Publicaciones_TipoCorreccion publicaciones_TipoCorreccion);
        bool UpdatePublicaciones_TipoCorreccion(Publicaciones_TipoCorreccion publicaciones_TipoCorreccion);
        bool DeletePublicaciones_TipoCorreccion(int id_tipocorreccion);
    }
}
