using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ITareasRepository
    {
        IEnumerable<Tareas> GetAllTareas();
        Tareas GetTareasDetails(int id_tarea);        
        bool InsertTareas(Tareas tareas);
        bool UpdateTareas(Tareas tareas);
        bool UpdateTareaEstadoAvance(TareasEstadoAvanceDTO tarea);
        bool DeleteTareas(int id_tarea);
        DataTableAdapter<Tareas> GetDataTableTareasByFuncionarioEstado(string idfuncionario, int id_estadotarea, DataTableRequest model);
        DataTableAdapter<Tareas> GetDataTableTareasByModuloRelacionado(int idtareamodulo, int idrelacionado, DataTableRequest model);
        DataTableAdapter<Tareas> GetDataTableTareasByRelacioncon(string relacioncon, int idrelacionado, DataTableRequest model);
        DataTableAdapter<Tareas> GetDataTableTareasByAsignadoPorEstado(string asignadopor, int id_estadotarea, DataTableRequest model);
    }
}
