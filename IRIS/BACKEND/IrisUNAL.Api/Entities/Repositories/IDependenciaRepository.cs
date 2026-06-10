using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDependenciaRepository
    {        
        IEnumerable<Dependencia> GetAllDependencia();
        Dependencia GetDependenciaDetails(int id_depend);
        Dependencia GetDependenciaDetails(string coddepend);
        bool InsertDependencia(Dependencia dependencia);
        bool UpdateDependencia(Dependencia dependencia);
        bool DeleteDependencia(int id_depend);
        DataTableAdapter<Dependencia> GetDataTableDependencia(DataTableRequest model);
    }
}