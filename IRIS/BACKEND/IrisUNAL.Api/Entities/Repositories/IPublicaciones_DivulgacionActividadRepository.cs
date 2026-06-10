using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionActividadRepository
    {
        IEnumerable<Publicaciones_DivulgacionActividad> GetAllPublicaciones_DivulgacionActividad();
        Publicaciones_DivulgacionActividad GetPublicaciones_DivulgacionActividadDetails(int id_actividad);        
        bool InsertPublicaciones_DivulgacionActividad(Publicaciones_DivulgacionActividad publicaciones_DivulgacionActividad);
        bool UpdatePublicaciones_DivulgacionActividad(Publicaciones_DivulgacionActividad publicaciones_DivulgacionActividad);
        bool DeletePublicaciones_DivulgacionActividad(int id_actividad);
        Publicaciones_DivulgacionActividad GetPublicaciones_DivulgacionActividadByPublicacion(int id_crearpublicacion);
    }
}
