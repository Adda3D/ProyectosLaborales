using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class ProductosRepository : SuperType<Productos>, IProductosRepository
    {
        private ApplicationDbContext _context;

        public ProductosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProductos(int id_productos)
        {
            Delete(id_productos);
            return true;
        }

        public IEnumerable<Productos> GetAllProductos()
        {
            return Get();
        }

        public Productos GetProductosDetails(int id_productos)
        {
            return Get(id_productos);
        }

        public bool InsertProductos(Productos productos)
        {
            Add(productos);
            return true;
        }

        public bool UpdateProductos(Productos productos)
        {
            Update(productos);
            return true;
        }
    }
}