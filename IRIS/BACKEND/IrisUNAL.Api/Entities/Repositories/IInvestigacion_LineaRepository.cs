using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_LineaRepository
    {
        IEnumerable<Investigacion_Linea> GetAllInvestigacion_Linea();
        Investigacion_Linea GetInvestigacion_LineaDetails(int id_linea);
        IEnumerable<Investigacion_Linea> GetInvestigacion_LineaCodigo(string codigohermes);
        bool InsertInvestigacion_Linea(Investigacion_Linea investigacion_Linea);
        bool UpdateInvestigacion_Linea(Investigacion_Linea investigacion_Linea);
        bool DeleteInvestigacion_Linea(int id_linea);
    }
}
