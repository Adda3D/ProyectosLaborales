using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlRepVentasRepository
    {
        IEnumerable<Publicaciones_DepositoControlRepVentas> GetAllPublicaciones_DepositoControlRepVentas();
        Publicaciones_DepositoControlRepVentas GetPublicaciones_DepositoControlRepVentasDetails(int id_repventas);
        bool InsertPublicaciones_DepositoControlRepVentas(Publicaciones_DepositoControlRepVentas publicaciones_DepositoControlRepVentas);
        bool UpdatePublicaciones_DepositoControlRepVentas(Publicaciones_DepositoControlRepVentas publicaciones_DepositoControlRepVentas);
        bool DeletePublicaciones_DepositoControlRepVentas(int id_repventas);
        DataTableAdapter<Publicaciones_DepositoControlRepVentas> GetDataTablePublicaciones_DepositoControlRepVentasByPublicacion(int id_crearpublicacion, DataTableRequest model);
        PublicacionIngresoVentasDTO GetIngresosVentas(int id_crearpublicacion);
    }
}
