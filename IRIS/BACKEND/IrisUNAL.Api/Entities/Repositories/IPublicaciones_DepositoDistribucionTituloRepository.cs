using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoDistribucionTituloRepository
    {
        IEnumerable<Publicaciones_DepositoDistribucionTitulo> GetAllPublicaciones_DepositoDistribucionTitulo();
        Publicaciones_DepositoDistribucionTitulo GetPublicaciones_DepositoDistribucionTituloDetails(int id_disttitulo);
        IEnumerable<Publicaciones_DepositoDistribucionTitulo> GetPublicaciones_DepositoDistribucionTituloNombre(string cd_nmtitulo);
        bool InsertPublicaciones_DepositoDistribucionTitulo(Publicaciones_DepositoDistribucionTitulo publicaciones_DepositoDistribucionTitulo);
        bool UpdatePublicaciones_DepositoDistribucionTitulo(Publicaciones_DepositoDistribucionTitulo publicaciones_DepositoDistribucionTitulo);
        bool DeletePublicaciones_DepositoDistribucionTitulo(int id_disttitulo);        
    }
}
