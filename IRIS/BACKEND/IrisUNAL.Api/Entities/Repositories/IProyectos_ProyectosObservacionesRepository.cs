using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_ProyectosObservacionesRepository
    {
        IEnumerable<Proyectos_ProyectosObservaciones> GetAllProyectos_ProyectosObservaciones();
        Proyectos_ProyectosObservaciones GetProyectos_ProyectosObservacionesDetails(int id_proyectosobservaciones);
        IEnumerable<Proyectos_ProyectosObservaciones> GetProyectos_ProyectosObservacionesDescripcion(string cd_descripcion);
        bool InsertProyectos_ProyectosObservaciones(Proyectos_ProyectosObservaciones proyectos_ProyectosObservaciones);
        bool UpdateProyectos_ProyectosObservaciones(Proyectos_ProyectosObservaciones proyectos_ProyectosObservaciones);
        bool DeleteProyectos_ProyectosObservaciones(int id_proyectosobservaciones);
        DataTableAdapter<Proyectos_ProyectosObservaciones> GetDataTableProyectos_Observaciones(int id_asignacionproyecto, DataTableRequest model);
    }
}
