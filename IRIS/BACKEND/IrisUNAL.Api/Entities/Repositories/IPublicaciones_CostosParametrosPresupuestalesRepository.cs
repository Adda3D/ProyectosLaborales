using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CostosParametrosPresupuestalesRepository
    {
        IEnumerable<Publicaciones_CostosParametrosPresupuestales> GetAllPublicaciones_CostosParametrosPresupuestales();
        Publicaciones_CostosParametrosPresupuestales GetPublicaciones_CostosParametrosPresupuestalesDetails(int id_costopublicacion);
        IEnumerable<Publicaciones_CostosParametrosPresupuestales> GetPublicaciones_CostosParametrosPresupuestalesCodigo(string cd_id_kardex);
        bool InsertPublicaciones_CostosParametrosPresupuestales(Publicaciones_CostosParametrosPresupuestales publicaciones_CostosParametrosPresupuestales);
        bool UpdatePublicaciones_CostosParametrosPresupuestales(Publicaciones_CostosParametrosPresupuestales publicaciones_CostosParametrosPresupuestales);
        bool DeletePublicaciones_CostosParametrosPresupuestales(int id_costopublicacion);
    }
}
