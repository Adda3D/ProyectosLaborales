using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoRepository
    {
        IEnumerable<Publicaciones_Deposito> GetAllPublicaciones_Deposito();
        Publicaciones_Deposito GetPublicaciones_DepositoDetails(int id_deposito);
        IEnumerable<Publicaciones_Deposito> GetPublicaciones_DepositoCodigo(string cd_id_kardex);
        bool InsertPublicaciones_Deposito(Publicaciones_Deposito publicaciones_Deposito);
        bool UpdatePublicaciones_Deposito(Publicaciones_Deposito publicaciones_Deposito);
        bool DeletePublicaciones_Deposito(int id_deposito);
    }
}
