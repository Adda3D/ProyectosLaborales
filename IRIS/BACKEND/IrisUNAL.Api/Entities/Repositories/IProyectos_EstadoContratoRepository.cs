using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_EstadoContratoRepository
    {
        IEnumerable<Proyectos_EstadoContrato> GetAllProyectos_EstadoContrato();
        Proyectos_EstadoContrato GetProyectos_EstadoContratoDetails(int id_estadocontrato);
        Proyectos_EstadoContrato GetProyectos_EstadoContratoEstado(string cd_estadocontrato);
        bool InsertProyectos_EstadoContrato(Proyectos_EstadoContrato proyectos_EstadoContrato);
        bool UpdateProyectos_EstadoContrato(Proyectos_EstadoContrato proyectos_EstadoContrato);
        bool DeleteProyectos_EstadoContrato(int id_estadocontrato);
        DataTableAdapter<Proyectos_EstadoContrato> GetDataTableProyectos_EstadoContrato(DataTableRequest model);
    }
}
