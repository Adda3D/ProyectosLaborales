using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoCoreRepository
    {
        IEnumerable<Publicaciones_EstadoCore> GetAllPublicaciones_EstadoCore();
        Publicaciones_EstadoCore GetPublicaciones_EstadoCoreDetails(int id_estadocore);
        IEnumerable<Publicaciones_EstadoCore> GetPublicaciones_EstadoCoreCodigo(string cd_id_kardex);
        bool InsertPublicaciones_EstadoCore(Publicaciones_EstadoCore publicaciones_EstadoCore);
        bool UpdatePublicaciones_EstadoCore(Publicaciones_EstadoCore publicaciones_EstadoCore);
        bool DeletePublicaciones_EstadoCore(int id_estadocore);
    }
}
