using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanaccionFuncionesRepository
    {
        IEnumerable<DecVie_PlanaccionFunciones> GetAllDecVie_PlanaccionFunciones();
        DecVie_PlanaccionFunciones GetDecVie_PlanaccionFuncionesDetails(int id_funciones);
        DecVie_PlanaccionFunciones GetDecVie_PlanaccionFuncionesNombre(string cd_nmfuncion);
        bool InsertDecVie_PlanaccionFunciones(DecVie_PlanaccionFunciones decVie_PlanaccionFunciones);
        bool UpdateDecVie_PlanaccionFunciones(DecVie_PlanaccionFunciones decVie_PlanaccionFunciones);
        bool DeleteDecVie_PlanaccionFunciones(int id_funciones);
        DataTableAdapter<DecVie_PlanaccionFunciones> GetDataTableDecVie_PlanaccionFunciones(DataTableRequest model);
    }
}
