using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ProveedorServicioRepository
    {
        IEnumerable<Publicaciones_ProveedorServicio> GetAllPublicaciones_ProveedorServicio();
        Publicaciones_ProveedorServicio GetPublicaciones_ProveedorServicioDetails(int id_proveedorservicio);
        IEnumerable<Publicaciones_ProveedorServicio> GetPublicaciones_ProveedorServicioNombre(string cd_nombreproveedor);
        bool InsertPublicaciones_ProveedorServicio(Publicaciones_ProveedorServicio publicaciones_ProveedorServicio);
        bool UpdatePublicaciones_ProveedorServicio(Publicaciones_ProveedorServicio publicaciones_ProveedorServicio);
        bool DeletePublicaciones_ProveedorServicio(int id_proveedorservicio);
    }
}
