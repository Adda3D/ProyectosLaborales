using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoDistribucionComercialRepository
    {
        IEnumerable<Publicaciones_DepositoDistribucionComercial> GetAllPublicaciones_DepositoDistribucionComercial();
        Publicaciones_DepositoDistribucionComercial GetPublicaciones_DepositoDistribucionComercialDetails(int id_distribucioncomercial);        
        bool InsertPublicaciones_DepositoDistribucionComercial(Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial);
        bool UpdatePublicaciones_DepositoDistribucionComercial(Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial);
        bool DeletePublicaciones_DepositoDistribucionComercial(int id_distribucioncomercial);
        DataTableAdapter<Publicaciones_DepositoDistribucionComercial> GetDataTablePublicaciones_DepositoDistribucionComercialByPublicacion(int id_crearpublicacion, DataTableRequest model);
    }
}
