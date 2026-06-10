using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyecto_ObservacionRepository
    {
        IEnumerable<Proyecto_Observacion> GetAllProyecto_Observacion();
        Proyecto_Observacion GetProyecto_ObservacionDetails(int id_proyectoobservacion);
        bool InsertProyecto_Observacion(Proyecto_Observacion proyecto_Observacion);
        bool UpdateProyecto_Observacion(Proyecto_Observacion proyecto_Observacion);
        bool DeleteProyecto_Observacion(int id_proyectoobservacion);
    }
}
