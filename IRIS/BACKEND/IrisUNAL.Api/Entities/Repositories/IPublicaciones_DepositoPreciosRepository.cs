using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoPreciosRepository
    {
        IEnumerable<Publicaciones_DepositoPrecios> GetAllPublicaciones_DepositoPrecios();
        Publicaciones_DepositoPrecios GetPublicaciones_DepositoPreciosDetails(int id_precios);
        Publicaciones_DepositoPrecios GetPublicaciones_DepositoPreciosByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_DepositoPrecios(Publicaciones_DepositoPrecios publicaciones_DepositoPrecios);
        bool UpdatePublicaciones_DepositoPrecios(Publicaciones_DepositoPrecios publicaciones_DepositoPrecios);
        bool DeletePublicaciones_DepositoPrecios(int id_precios);
    }
}
