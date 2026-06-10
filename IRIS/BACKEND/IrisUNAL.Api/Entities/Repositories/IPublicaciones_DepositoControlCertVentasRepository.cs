using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlCertVentasRepository
    {
        IEnumerable<Publicaciones_DepositoControlCertVentas> GetAllPublicaciones_DepositoControlCertVentas();
        Publicaciones_DepositoControlCertVentas GetPublicaciones_DepositoControlCertVentasDetails(int id_certventas);        
        bool InsertPublicaciones_DepositoControlCertVentas(Publicaciones_DepositoControlCertVentas publicaciones_DepositoControlCertVentas);
        bool UpdatePublicaciones_DepositoControlCertVentas(Publicaciones_DepositoControlCertVentas publicaciones_DepositoControlCertVentas);
        bool DeletePublicaciones_DepositoControlCertVentas(int id_certventas);
        DataTableAdapter<Publicaciones_DepositoControlCertVentas> GetDataTablePublicaciones_DepositoControlCertVentasByPublicacion(int id_crearpublicacion, DataTableRequest model);
    }
}
