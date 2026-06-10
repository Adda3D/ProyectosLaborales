using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoTipoMovRepository
    {
        IEnumerable<Publicaciones_DepositoTipoMov> GetAllPublicaciones_DepositoTipoMov();
        Publicaciones_DepositoTipoMov GetPublicaciones_DepositoTipoMovDetails(int id_tipomov);
        Publicaciones_DepositoTipoMov GetPublicaciones_DepositoTipoMovNombre(string cd_nmtipomov);
        bool InsertPublicaciones_DepositoTipoMov(Publicaciones_DepositoTipoMov publicaciones_DepositoTipoMov);
        bool UpdatePublicaciones_DepositoTipoMov(Publicaciones_DepositoTipoMov publicaciones_DepositoTipoMov);
        bool DeletePublicaciones_DepositoTipoMov(int id_tipomov);
        DataTableAdapter<Publicaciones_DepositoTipoMov> GetDataTablePublicaciones_DepositoTipoMov(DataTableRequest model);
    }
}
