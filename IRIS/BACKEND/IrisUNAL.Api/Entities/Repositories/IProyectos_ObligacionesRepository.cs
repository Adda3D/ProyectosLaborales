using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_ObligacionesRepository
    {
        IEnumerable<Proyectos_Obligaciones> GetAllProyectos_Obligaciones();
        IEnumerable<Proyectos_Obligaciones> GetAllProyectos_ObligacionesByProyecto(int id_asignacionproyecto);
        Proyectos_Obligaciones GetProyectos_ObligacionesDetails(int id_proyectoobligaciones);
        IEnumerable<Proyectos_Obligaciones> GetProyectos_ObligacionesNombre(string cd_obligacion);
        bool InsertProyectos_Obligaciones(Proyectos_Obligaciones proyectos_Obligaciones);
        bool UpdateProyectos_Obligaciones(Proyectos_Obligaciones proyectos_Obligaciones);
        bool DeleteProyectos_Obligaciones(int id_proyectoobligaciones);
        DataTableAdapter<Proyectos_Obligaciones> GetDataTableProyectos_Obligaciones(int id_asignacionproyecto, DataTableRequest model);
    }
}
