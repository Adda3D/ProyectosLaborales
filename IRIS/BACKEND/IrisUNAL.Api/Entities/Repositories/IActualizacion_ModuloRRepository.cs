using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IActualizacion_ModuloRRepository
    {
        IEnumerable<Actualizacion_ModuloR> GetAllActualizacion_ModuloR();
        Actualizacion_ModuloR GetActualizacion_ModuloRDetails(int id_actualizacionmodulor);        
        bool InsertActualizacion_ModuloR(Actualizacion_ModuloR actualizacion_ModuloR);
        bool UpdateActualizacion_ModuloR(Actualizacion_ModuloR actualizacion_ModuloR);
        bool DeleteActualizacion_ModuloR(int id_actualizacionmodulor);
        Actualizacion_ModuloR GetActualizacion_ModuloRByProyecto(int id_asignacionproyecto);
    }
}
