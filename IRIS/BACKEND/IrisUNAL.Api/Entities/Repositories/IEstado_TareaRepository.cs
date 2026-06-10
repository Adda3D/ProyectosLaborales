using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IEstado_TareaRepository
    {
        IEnumerable<Estado_Tarea> GetAllEstado_Tarea();
        Estado_Tarea GetEstado_TareaDetails(int id_estadotarea);
        IEnumerable<Estado_Tarea> GetEstado_TareaDetails(string cd_nmestadotarea);
        bool InsertEstado_Tarea(Estado_Tarea estado_Tarea);
        bool UpdateEstado_Tarea(Estado_Tarea estado_Tarea);
        bool DeleteEstado_Tarea(int id_estadotarea);
    }
}
