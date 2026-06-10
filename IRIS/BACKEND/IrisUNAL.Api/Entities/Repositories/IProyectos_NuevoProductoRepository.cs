using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_NuevoProductoRepository
    {
        IEnumerable<Proyectos_NuevoProducto> GetAllProyectos_NuevoProducto();
        Proyectos_NuevoProducto GetProyectos_NuevoProductoDetails(int id_nuevoproducto);        
        bool InsertProyectos_NuevoProducto(Proyectos_NuevoProducto proyectos_NuevoProducto);
        bool UpdateProyectos_NuevoProducto(Proyectos_NuevoProducto proyectos_NuevoProducto);
        bool DeleteProyectos_NuevoProducto(int id_nuevoproducto);
        DataTableAdapter<Proyectos_NuevoProducto> GetDataTableProyectos_ProductosByProyecto(int id_asignacionproyecto, DataTableRequest model);
    }
}
