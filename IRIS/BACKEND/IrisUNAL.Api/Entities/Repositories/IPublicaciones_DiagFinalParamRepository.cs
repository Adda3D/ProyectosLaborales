using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DiagFinalParamRepository
    {
        IEnumerable<Publicaciones_DiagFinalParam> GetAllPublicaciones_DiagFinalParam();
        Publicaciones_DiagFinalParam GetPublicaciones_DiagFinalParamDetails(int id_diagfinalparam);
        IEnumerable<Publicaciones_DiagFinalParam> GetPublicaciones_DiagFinalParamNombre(string cd_responsable);
        bool InsertPublicaciones_DiagFinalParam(Publicaciones_DiagFinalParam publicaciones_DiagFinalParam);
        bool UpdatePublicaciones_DiagFinalParam(Publicaciones_DiagFinalParam publicaciones_DiagFinalParam);
        bool DeletePublicaciones_DiagFinalParam(int id_diagfinalparam);
    }
}
