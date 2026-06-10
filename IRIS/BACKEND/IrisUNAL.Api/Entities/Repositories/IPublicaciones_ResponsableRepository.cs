using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ResponsableRepository
    {
        IEnumerable<Publicaciones_Responsable> GetAllPublicaciones_Responsable();
        Publicaciones_Responsable GetPublicaciones_ResponsableDetails(int id_responsable);
        bool InsertPublicaciones_Responsable(Publicaciones_Responsable publicaciones_Responsable);
        bool UpdatePublicaciones_Responsable(Publicaciones_Responsable publicaciones_Responsable);
        bool DeletePublicaciones_Responsable(int id_responsable);
    }
}
