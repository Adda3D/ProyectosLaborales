using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_NaturalezaProyectoRepository
    {
        IEnumerable<Proyectos_NaturalezaProyecto> GetAllProyectos_NaturalezaProyecto();
        Proyectos_NaturalezaProyecto GetProyectos_NaturalezaProyectoDetails(int id_naturalezaproyecto);
        Proyectos_NaturalezaProyecto GetProyectos_NaturalezaProyectoNaturaleza(string cd_naturalezaproyecto);
        bool InsertProyectos_NaturalezaProyecto(Proyectos_NaturalezaProyecto proyectos_NaturalezaProyecto);
        bool UpdateProyectos_NaturalezaProyecto(Proyectos_NaturalezaProyecto proyectos_NaturalezaProyecto);
        bool DeleteProyectos_NaturalezaProyecto(int id_naturalezaproyecto);
        DataTableAdapter<Proyectos_NaturalezaProyecto> GetDataTableProyectos_NaturalezaProyecto(DataTableRequest model);
    }
}
