using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoDistribucionComercialOtrosRepository
    {
        IEnumerable<Publicaciones_DepositoDistribucionComercialOtros> GetAllPublicaciones_DepositoDistribucionComercialOtros();
        Publicaciones_DepositoDistribucionComercialOtros GetPublicaciones_DepositoDistribucionComercialOtrosDetails(int id_otrosdistribuidores);
        IEnumerable<Publicaciones_DepositoDistribucionComercialOtros> GetPublicaciones_DepositoDistribucionComercialOtrosNombre(string cd_nmotrosdistribuidores);
        bool InsertPublicaciones_DepositoDistribucionComercialOtros(Publicaciones_DepositoDistribucionComercialOtros publicaciones_DepositoDistribucionComercialOtros);
        bool UpdatePublicaciones_DepositoDistribucionComercialOtros(Publicaciones_DepositoDistribucionComercialOtros publicaciones_DepositoDistribucionComercialOtros);
        bool DeletePublicaciones_DepositoDistribucionComercialOtros(int id_otrosdistribuidores);
    }
}
