using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlActaRepository
    {
        IEnumerable<Publicaciones_DepositoControlActa> GetAllPublicaciones_DepositoControlActa();
        Publicaciones_DepositoControlActa GetPublicaciones_DepositoControlActaDetails(int id_actacosto);
        Publicaciones_DepositoControlActa GetPublicaciones_DepositoControlActaByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_DepositoControlActa(Publicaciones_DepositoControlActa publicaciones_DepositoControlActa);
        bool UpdatePublicaciones_DepositoControlActa(Publicaciones_DepositoControlActa publicaciones_DepositoControlActa);
        bool DeletePublicaciones_DepositoControlActa(int id_actacosto);
    }
}
