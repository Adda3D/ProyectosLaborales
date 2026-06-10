using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_ProveedorServicioRepository : SuperType<Publicaciones_ProveedorServicio>, IPublicaciones_ProveedorServicioRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ProveedorServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ProveedorServicioRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ProveedorServicio(int id_proveedorservicio)
        {
            Delete(id_proveedorservicio);
            return true;
        }

        public IEnumerable<Publicaciones_ProveedorServicio> GetAllPublicaciones_ProveedorServicio()
        {
            return Get();
        }

        public Publicaciones_ProveedorServicio GetPublicaciones_ProveedorServicioDetails(int id_proveedorservicio)
        {
            return Get(id_proveedorservicio);
        }

        public IEnumerable<Publicaciones_ProveedorServicio> GetPublicaciones_ProveedorServicioNombre(string cd_nombreproveedor)
        {
            return Get(c => c.nombreproveedor == cd_nombreproveedor);
        }

        public bool InsertPublicaciones_ProveedorServicio(Publicaciones_ProveedorServicio publicaciones_ProveedorServicio)
        {
            Add(publicaciones_ProveedorServicio);
            return true;
        }

        public bool UpdatePublicaciones_ProveedorServicio(Publicaciones_ProveedorServicio publicaciones_ProveedorServicio)
        {
            Update(publicaciones_ProveedorServicio);
            return true;
        }
    }
}