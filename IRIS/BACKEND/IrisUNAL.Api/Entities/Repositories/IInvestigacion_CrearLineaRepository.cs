using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_CrearLineaRepository
    {
        IEnumerable<Investigacion_CrearLinea> GetAllInvestigacion_CrearLinea();
        Investigacion_CrearLinea GetInvestigacion_CrearLineaDetails(int id_crearlinea);
        Investigacion_CrearLinea GetInvestigacion_CrearLineaNombre(string linea);
        bool InsertInvestigacion_CrearLinea(Investigacion_CrearLinea investigacion_CrearLinea);
        bool UpdateInvestigacion_CrearLinea(Investigacion_CrearLinea investigacion_CrearLinea);
        bool DeleteInvestigacion_CrearLinea(int id_crearlinea);
        DataTableAdapter<Investigacion_CrearLinea> GetDataTableInvestigacion_CrearLinea(DataTableRequest model);
    }
}
