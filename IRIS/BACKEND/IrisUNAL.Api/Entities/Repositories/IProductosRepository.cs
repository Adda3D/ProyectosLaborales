using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProductosRepository
    {
        IEnumerable<Productos> GetAllProductos();
        Productos GetProductosDetails(int id_productos);
        bool InsertProductos(Productos productos);
        bool UpdateProductos(Productos productos);
        bool DeleteProductos(int id_productos);
    }
}
