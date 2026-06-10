using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoCorParamRepository
    {
        IEnumerable<Publicaciones_EstadoCorParam> GetAllPublicaciones_EstadoCorParam();
        Publicaciones_EstadoCorParam GetPublicaciones_EstadoCorParamDetails(int id_estadocorparam);
        Publicaciones_EstadoCorParam GetPublicaciones_EstadoCorParamByPublicacionEtapa(int id_crearpublicacion, string correccionetapa);
        bool InsertPublicaciones_EstadoCorParam(Publicaciones_EstadoCorParam publicaciones_EstadoCorParam);
        bool UpdatePublicaciones_EstadoCorParam(Publicaciones_EstadoCorParam publicaciones_EstadoCorParam);
        bool DeletePublicaciones_EstadoCorParam(int id_estadocorparam);
    }
}
