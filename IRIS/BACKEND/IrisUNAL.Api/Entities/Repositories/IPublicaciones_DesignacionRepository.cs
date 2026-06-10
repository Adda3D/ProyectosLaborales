using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DesignacionRepository
    {
        IEnumerable<Publicaciones_Designacion> GetAllPublicaciones_Designacion();
        Publicaciones_Designacion GetPublicaciones_DesignacionDetails(int id_designacion);
        Publicaciones_Designacion GetPublicaciones_DesignacionByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_Designacion(Publicaciones_Designacion publicaciones_Designacion);
        bool UpdatePublicaciones_Designacion(Publicaciones_Designacion publicaciones_Designacion);
        bool DeletePublicaciones_Designacion(int id_designacion);
    }
}
