using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlRepository
    {
        IEnumerable<Publicaciones_DepositoControl> GetAllPublicaciones_DepositoControl();
        Publicaciones_DepositoControl GetPublicaciones_DepositoControlDetails(int id_control);
        IEnumerable<Publicaciones_DepositoControl> GetPublicaciones_DepositoControlCodigo(string cd_id_kardex);
        bool InsertPublicaciones_DepositoControl(Publicaciones_DepositoControl publicaciones_DepositoControl);
        bool UpdatePublicaciones_DepositoControl(Publicaciones_DepositoControl publicaciones_DepositoControl);
        bool DeletePublicaciones_DepositoControl(int id_control);
    }
}
