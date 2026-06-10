using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoControlInventarioBodegaRepository
    {
        IEnumerable<Publicaciones_DepositoControlInventarioBodega> GetAllPublicaciones_DepositoControlInventarioBodega();
        Publicaciones_DepositoControlInventarioBodega GetPublicaciones_DepositoControlInventarioBodegaDetails(int id_bodega);
        Publicaciones_DepositoControlInventarioBodega GetPublicaciones_DepositoControlInventarioBodegaNombre(string cd_nmbodega);
        bool InsertPublicaciones_DepositoControlInventarioBodega(Publicaciones_DepositoControlInventarioBodega publicaciones_DepositoControlInventarioBodega);
        bool UpdatePublicaciones_DepositoControlInventarioBodega(Publicaciones_DepositoControlInventarioBodega publicaciones_DepositoControlInventarioBodega);
        bool DeletePublicaciones_DepositoControlInventarioBodega(int id_bodega);
        DataTableAdapter<Publicaciones_DepositoControlInventarioBodega> GetDataTablePublicaciones_DepositoControlInventarioBodega(DataTableRequest model);
    }
}
