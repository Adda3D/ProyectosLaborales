using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IProyectos_AlcanceProyectoRepository
    {
        IEnumerable<Proyectos_AlcanceProyecto> GetAllProyectos_AlcanceProyecto();
        Proyectos_AlcanceProyecto GetProyectos_AlcanceProyectoDetails(int id_alcanceproyecto);
        Proyectos_AlcanceProyecto GetProyectos_AlcanceProyectoAlcance(string cd_alcanceproyecto);
        bool InsertProyectos_AlcanceProyecto(Proyectos_AlcanceProyecto proyectos_AlcanceProyecto);
        bool UpdateProyectos_AlcanceProyecto(Proyectos_AlcanceProyecto proyectos_AlcanceProyecto);
        bool DeleteProyectos_AlcanceProyecto(int id_alcanceproyecto);
        DataTableAdapter<Proyectos_AlcanceProyecto> GetDataTableProyectos_AlcanceProyecto(DataTableRequest model);
    }
}
