using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ResenaRepository
    {
        IEnumerable<Publicaciones_Resena> GetAllPublicaciones_Resena();
        Publicaciones_Resena GetPublicaciones_ResenaDetails(int id_resena);
        IEnumerable<Publicaciones_Resena> GetPublicaciones_ResenaNombre(string cd_nmresena);
        bool InsertPublicaciones_Resena(Publicaciones_Resena publicaciones_Resena);
        bool UpdatePublicaciones_Resena(Publicaciones_Resena publicaciones_Resena);
        bool DeletePublicaciones_Resena(int id_resena);
    }
}
