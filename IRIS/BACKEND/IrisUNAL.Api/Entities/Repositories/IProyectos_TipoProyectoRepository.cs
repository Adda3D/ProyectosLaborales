using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_TipoProyectoRepository
    {
        IEnumerable<Proyectos_TipoProyecto> GetAllProyectos_TipoProyecto();
        Proyectos_TipoProyecto GetProyectos_TipoProyectoDetails(int id_tipoproyecto);
        Proyectos_TipoProyecto GetProyectos_TipoProyectoTipo(string cd_tipoproyecto);
        bool InsertProyectos_TipoProyecto(Proyectos_TipoProyecto proyectos_TipoProyecto);
        bool UpdateProyectos_TipoProyecto(Proyectos_TipoProyecto proyectos_TipoProyecto);
        bool DeleteProyectos_TipoProyecto(int id_tipoproyecto);
        DataTableAdapter<Proyectos_TipoProyecto> GetDataTableProyectos_TipoProyecto(DataTableRequest model);
    }
}
