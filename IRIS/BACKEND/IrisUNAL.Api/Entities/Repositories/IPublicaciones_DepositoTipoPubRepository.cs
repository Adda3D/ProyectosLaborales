using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoTipoPubRepository
    {
        IEnumerable<Publicaciones_DepositoTipoPub> GetAllPublicaciones_DepositoTipoPub();
        Publicaciones_DepositoTipoPub GetPublicaciones_DepositoTipoPubDetails(int id_tipopub);
        Publicaciones_DepositoTipoPub GetPublicaciones_DepositoTipoPubNombre(string cd_nmtipopub);
        bool InsertPublicaciones_DepositoTipoPub(Publicaciones_DepositoTipoPub publicaciones_DepositoTipoPub);
        bool UpdatePublicaciones_DepositoTipoPub(Publicaciones_DepositoTipoPub publicaciones_DepositoTipoPub);
        bool DeletePublicaciones_DepositoTipoPub(int id_tipopub);
        DataTableAdapter<Publicaciones_DepositoTipoPub> GetDataTablePublicaciones_DepositoTipoPub(DataTableRequest model);
    }
}
