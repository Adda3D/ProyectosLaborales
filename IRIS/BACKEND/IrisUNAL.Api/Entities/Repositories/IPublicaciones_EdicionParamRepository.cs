using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EdicionParamRepository
    {
        IEnumerable<Publicaciones_EdicionParam> GetAllPublicaciones_EdicionParam();
        Publicaciones_EdicionParam GetPublicaciones_EdicionParamDetails(int id_edicionparam);
        IEnumerable<Publicaciones_EdicionParam> GetPublicaciones_EdicionParamCodigo(string cd_codhermes);
        bool InsertPublicaciones_EdicionParam(Publicaciones_EdicionParam publicaciones_EdicionParam);
        bool UpdatePublicaciones_EdicionParam(Publicaciones_EdicionParam publicaciones_EdicionParam);
        bool DeletePublicaciones_EdicionParam(int id_edicionparam);
    }
}
