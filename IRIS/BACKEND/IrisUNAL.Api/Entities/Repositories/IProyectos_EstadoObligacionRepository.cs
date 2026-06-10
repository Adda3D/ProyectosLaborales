using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_EstadoObligacionRepository
    {
        IEnumerable<Proyectos_EstadoObligacion> GetAllProyectos_EstadoObligacion();
        Proyectos_EstadoObligacion GetProyectos_EstadoObligacionDetails(int id_estadoobligacion);
        Proyectos_EstadoObligacion GetProyectos_EstadoObligacionEstado(string cd_estadoobligacion);
        bool InsertProyectos_EstadoObligacion(Proyectos_EstadoObligacion proyectos_EstadoObligacion);
        bool UpdateProyectos_EstadoObligacion(Proyectos_EstadoObligacion proyectos_EstadoObligacion);
        bool DeleteProyectos_EstadoObligacion(int id_estadoobligacion);
        DataTableAdapter<Proyectos_EstadoObligacion> GetDataTableProyectos_EstadoObligacion(DataTableRequest model);
    }
}
