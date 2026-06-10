using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionActividadNombreRepository
    {
        IEnumerable<Publicaciones_DivulgacionActividadNombre> GetAllPublicaciones_DivulgacionActividadNombre();
        Publicaciones_DivulgacionActividadNombre GetPublicaciones_DivulgacionActividadNombreDetails(int id_actividadnombre);
        IEnumerable<Publicaciones_DivulgacionActividadNombre> GetPublicaciones_DivulgacionActividadNombreNom(string cd_nomactividadnombre);
        bool InsertPublicaciones_DivulgacionActividadNombre(Publicaciones_DivulgacionActividadNombre publicaciones_DivulgacionActividadNombre);
        bool UpdatePublicaciones_DivulgacionActividadNombre(Publicaciones_DivulgacionActividadNombre publicaciones_DivulgacionActividadNombre);
        bool DeletePublicaciones_DivulgacionActividadNombre(int id_actividadnombre);
    }
}
