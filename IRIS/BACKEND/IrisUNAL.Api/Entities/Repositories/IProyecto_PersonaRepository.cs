using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyecto_PersonaRepository
    {
        IEnumerable<Proyecto_Persona> GetAllProyecto_Persona();
        Proyecto_Persona GetProyecto_PersonaDetails(int id_proyectopersona);
        Proyecto_Persona GetProyecto_PersonaByProyectoTipoPersona(int id_proyecto, int id_tipo, int id_persona);
        bool InsertProyecto_Persona(Proyecto_Persona proyecto_Persona);
        bool UpdateProyecto_Persona(Proyecto_Persona proyecto_Persona);
        bool DeleteProyecto_Persona(int id_proyectopersona);
        DataTableAdapter<Proyecto_Persona> GetDataTableProyectos_PersonaByProyecto(int id_asignacionproyecto, int id_tipoproyecto, DataTableRequest model);
    }
}
