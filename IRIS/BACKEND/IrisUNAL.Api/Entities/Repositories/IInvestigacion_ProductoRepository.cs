using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_ProductoRepository
    {
        IEnumerable<Investigacion_Producto> GetAllInvestigacion_Producto();
        Investigacion_Producto GetInvestigacion_ProductoDetails(int id_producto);       
        bool InsertInvestigacion_Producto(Investigacion_Producto investigacion_Producto);
        bool UpdateInvestigacion_Producto(Investigacion_Producto investigacion_Producto);
        bool DeleteInvestigacion_Producto(int id_producto);
        DataTableAdapter<Investigacion_Producto> GetDataTableInvestigacion_ProductoByProyecto(int id_crearproyecto, DataTableRequest model);
    }
}
