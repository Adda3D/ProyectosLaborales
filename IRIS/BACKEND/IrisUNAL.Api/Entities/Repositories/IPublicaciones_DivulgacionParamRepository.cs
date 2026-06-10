using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionParamRepository
    {
        IEnumerable<Publicaciones_DivulgacionParam> GetAllPublicaciones_DivulgacionParam();
        Publicaciones_DivulgacionParam GetPublicaciones_DivulgacionParamDetails(int id_divparam);
        IEnumerable<Publicaciones_DivulgacionParam> GetPublicaciones_DivulgacionParamCodigo(string cd_id_kardex);
        bool InsertPublicaciones_DivulgacionParam(Publicaciones_DivulgacionParam publicaciones_DivulgacionParam);
        bool UpdatePublicaciones_DivulgacionParam(Publicaciones_DivulgacionParam publicaciones_DivulgacionParam);
        bool DeletePublicaciones_DivulgacionParam(int id_divparam);
    }
}
