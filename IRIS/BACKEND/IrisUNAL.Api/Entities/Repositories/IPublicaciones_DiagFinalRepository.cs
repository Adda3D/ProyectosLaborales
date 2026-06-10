using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DiagFinalRepository
    {
        IEnumerable<Publicaciones_DiagFinal> GetAllPublicaciones_DiagFinal();
        Publicaciones_DiagFinal GetPublicaciones_DiagFinalDetails(int id_diagfinal);
        bool InsertPublicaciones_DiagFinal(Publicaciones_DiagFinal publicaciones_DiagFinal);
        bool UpdatePublicaciones_DiagFinal(Publicaciones_DiagFinal publicaciones_DiagFinal);
        bool DeletePublicaciones_DiagFinal(int id_diagfinal);
    }
}
