using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CierreEdicionRepository
    {
        IEnumerable<Publicaciones_CierreEdicion> GetAllPublicaciones_CierreEdicion();
        Publicaciones_CierreEdicion GetPublicaciones_CierreEdicionDetails(int id_cierreedicion);
        Publicaciones_CierreEdicion GetPublicaciones_CierreEdicionByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_CierreEdicion(Publicaciones_CierreEdicion publicaciones_CierreEdicion);
        bool UpdatePublicaciones_CierreEdicion(Publicaciones_CierreEdicion publicaciones_CierreEdicion);
        bool DeletePublicaciones_CierreEdicion(int id_cierreedicion);
    }
}
