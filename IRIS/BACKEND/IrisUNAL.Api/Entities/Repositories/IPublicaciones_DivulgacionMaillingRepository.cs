using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionMaillingRepository
    {
        IEnumerable<Publicaciones_DivulgacionMailling> GetAllPublicaciones_DivulgacionMailling();
        Publicaciones_DivulgacionMailling GetPublicaciones_DivulgacionMaillingDetails(int id_mailling);
        IEnumerable<Publicaciones_DivulgacionMailling> GetPublicaciones_DivulgacionMaillingCodigo(string cd_id_kardex);
        bool InsertPublicaciones_DivulgacionMailling(Publicaciones_DivulgacionMailling publicaciones_DivulgacionMailling);
        bool UpdatePublicaciones_DivulgacionMailling(Publicaciones_DivulgacionMailling publicaciones_DivulgacionMailling);
        bool DeletePublicaciones_DivulgacionMailling(int id_mailling);
    }
}
