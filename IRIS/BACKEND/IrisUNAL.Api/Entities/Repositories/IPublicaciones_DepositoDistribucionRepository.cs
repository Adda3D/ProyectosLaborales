using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoDistribucionRepository
    {
        IEnumerable<Publicaciones_DepositoDistribucion> GetAllPublicaciones_DepositoDistribucion();
        Publicaciones_DepositoDistribucion GetPublicaciones_DepositoDistribucionDetails(int id_distribucion);        
        bool InsertPublicaciones_DepositoDistribucion(Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion);
        bool UpdatePublicaciones_DepositoDistribucion(Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion);
        bool DeletePublicaciones_DepositoDistribucion(int id_distribucion);
        DataTableAdapter<Publicaciones_DepositoDistribucion> GetDataTablePublicaciones_DepositoDistribucionByPublicacion(int id_crearpublicacion, DataTableRequest model);        
    }
}
