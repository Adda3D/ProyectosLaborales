using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlIngresoVentasRepository
    {
        IEnumerable<Publicaciones_DepositoControlIngresoVentas> GetAllPublicaciones_DepositoControlIngresoVentas();
        Publicaciones_DepositoControlIngresoVentas GetPublicaciones_DepositoControlIngresoVentasDetails(int id_ingresoventas);
        bool InsertPublicaciones_DepositoControlIngresoVentas(Publicaciones_DepositoControlIngresoVentas publicaciones_DepositoControlIngresoVentas);
        bool UpdatePublicaciones_DepositoControlIngresoVentas(Publicaciones_DepositoControlIngresoVentas publicaciones_DepositoControlIngresoVentas);
        bool DeletePublicaciones_DepositoControlIngresoVentas(int id_ingresoventas);
    }
}
