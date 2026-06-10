using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlInventarioMovimientosRepository
    {
        IEnumerable<Publicaciones_DepositoControlInventarioMovimientos> GetAllPublicaciones_DepositoControlInventarioMovimientos();
        Publicaciones_DepositoControlInventarioMovimientos GetPublicaciones_DepositoControlInventarioMovimientosDetails(int id_movimientos);        
        bool InsertPublicaciones_DepositoControlInventarioMovimientos(Publicaciones_DepositoControlInventarioMovimientos publicaciones_DepositoControlInventarioMovimientos);
        bool UpdatePublicaciones_DepositoControlInventarioMovimientos(Publicaciones_DepositoControlInventarioMovimientos publicaciones_DepositoControlInventarioMovimientos);
        bool DeletePublicaciones_DepositoControlInventarioMovimientos(int id_movimintos);
        DataTableAdapter<Publicaciones_DepositoControlInventarioMovimientos> GetDataTablePublicaciones_DepositoControlInventarioMovimientosByPublicacion(int id_crearpublicacion, DataTableRequest model);
    }
}
