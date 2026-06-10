using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionCierreRepository
    {
        IEnumerable<Publicaciones_DivulgacionCierre> GetAllPublicaciones_DivulgacionCierre();
        Publicaciones_DivulgacionCierre GetPublicaciones_DivulgacionCierreDetails(int id_cierre);        
        bool InsertPublicaciones_DivulgacionCierre(Publicaciones_DivulgacionCierre publicaciones_DivulgacionCierre);
        bool UpdatePublicaciones_DivulgacionCierre(Publicaciones_DivulgacionCierre publicaciones_DivulgacionCierre);
        bool DeletePublicaciones_DivulgacionCierre(int id_cierre);
        Publicaciones_DivulgacionCierre GetPublicaciones_DivulgacionCierreByPublicacion(int id_crearpublicacion);
    }
}
