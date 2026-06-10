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
    public interface IInvestigacion_CrearProyectoRepository
    {
        IEnumerable<Investigacion_CrearProyecto> GetAllInvestigacion_CrearProyecto();
        Investigacion_CrearProyecto GetInvestigacion_CrearProyectoDetails(int id_crearproyecto);
        IEnumerable<Investigacion_CrearProyecto> GetInvestigacion_CrearProyectoCodigo(string codigohermes);
        bool InsertInvestigacion_CrearProyecto(Investigacion_CrearProyecto investigacion_CrearProyecto);
        bool UpdateInvestigacion_CrearProyecto(Investigacion_CrearProyecto investigacion_CrearProyecto);
        bool DeleteInvestigacion_CrearProyecto(int id_crearproyecto);
        DataTableAdapter<Investigacion_CrearProyecto> GetDataTableInvestigacion_CrearProyecto(DataTableRequest model);
        ProyectoTotalAportesDTO GetInvestigacion_CrearProyectoAportes(int id_crearproyecto);
        bool UpdateInvestigacion_CrearProyectoAportes(ProyectoTotalAportesDTO proyecto_aportes);
        string ExcelInvestigacion_CrearProyecto(int id_crearproyecto);
    }
}
