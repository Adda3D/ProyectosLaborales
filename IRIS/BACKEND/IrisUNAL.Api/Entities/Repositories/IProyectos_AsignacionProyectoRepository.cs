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
    public interface IProyectos_AsignacionProyectoRepository
    {
        IEnumerable<Proyectos_AsignacionProyecto> GetAllProyectos_AsignacionProyecto();
        Proyectos_AsignacionProyecto GetProyectos_AsignacionProyectoDetails(int id_asignacionproyecto);
        Proyectos_AsignacionProyecto GetProyectos_AsignacionProyectoContrato(string cd_numcontratoconvenio);
        Proyectos_AsignacionProyecto GetProyectos_AsignacionProyectoConsecutivo(string consecutivo);
        Proyectos_AsignacionProyecto GetProyectos_AsignacionProyectoPropuesta(int id_propuesta);
        bool InsertProyectos_AsignacionProyecto(Proyectos_AsignacionProyecto proyectos_AsignacionProyecto);
        bool UpdateProyectos_AsignacionProyecto(Proyectos_AsignacionProyecto proyectos_AsignacionProyecto);
        bool DeleteProyectos_AsignacionProyecto(int id_asignacionproyecto);
        bool UpdateProyectoContrato(AsignacionProyectoDTO proyectocontrato);
        DataTableAdapter<Proyectos_AsignacionProyecto> GetDataTableProyectos_AsignacionProyecto(DataTableRequest model);
        bool UpdateProyectos_AsignacionProyectoAportes(ProyectoTotalAportesDTO proyecto_aportes);
        ProyectoTotalAportesDTO GetProyectos_AsignacionProyectoAportes(int id_asignacionproyecto);
        string ExcelProyectos_AsignacionProyecto(int id_asignacionproyecto);
        
    }
}
