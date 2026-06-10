using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_CrearGastoRepository
    {
        IEnumerable<Seguimiento_CrearGasto> GetAllSeguimiento_CrearGasto();
        Seguimiento_CrearGasto GetSeguimiento_CrearGastoDetails(int id_creargasto);
        Seguimiento_CrearGasto GetSeguimiento_CrearGastoRelaciones(int id_creargasto);
        bool InsertSeguimiento_CrearGasto(Seguimiento_CrearGasto seguimiento_CrearGasto);
        bool UpdateSeguimiento_CrearGasto(Seguimiento_CrearGasto seguimiento_CrearGasto);
        bool DeleteSeguimiento_CrearGasto(int id_creargasto);
        DataTableAdapter<Seguimiento_CrearGasto> GetDataTableProyectoGastosByProyecto(int id_asignacionproyecto, int id_partida, DataTableRequest model);
    }
}
