using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoResolucionRepository
    {
        IEnumerable<Publicaciones_DepositoResolucion> GetAllPublicaciones_DepositoResolucion();
        Publicaciones_DepositoResolucion GetPublicaciones_DepositoResolucionDetails(int id_resolucion);
        IEnumerable<Publicaciones_DepositoResolucion> GetPublicaciones_DepositoResolucionNumero(string cd_numresolucion);
        Publicaciones_DepositoResolucion GetPublicaciones_DepositoResolucionByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_DepositoResolucion(Publicaciones_DepositoResolucion publicaciones_DepositoResolucion);
        bool UpdatePublicaciones_DepositoResolucion(Publicaciones_DepositoResolucion publicaciones_DepositoResolucion);
        bool DeletePublicaciones_DepositoResolucion(int id_resolucion);
    }
}
