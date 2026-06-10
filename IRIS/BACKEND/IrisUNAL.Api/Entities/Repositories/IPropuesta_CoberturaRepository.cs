using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_CoberturaRepository
    {
        IEnumerable<Propuesta_Cobertura> GetAllPropuesta_Cobertura();
        Propuesta_Cobertura GetPropuesta_CoberturaDetails(int id_cobertura);
        Propuesta_Cobertura GetPropuesta_CoberturaDetails(string cd_nmcobertura);
        bool InsertPropuesta_Cobertura(Propuesta_Cobertura propuesta_Cobertura);
        bool UpdatePropuesta_Cobertura(Propuesta_Cobertura propuesta_Cobertura);
        bool DeletePropuesta_Cobertura(int id_cobertura);
        DataTableAdapter<Propuesta_Cobertura> GetDataTablePropuestaCobertura(DataTableRequest model);
    }
}
