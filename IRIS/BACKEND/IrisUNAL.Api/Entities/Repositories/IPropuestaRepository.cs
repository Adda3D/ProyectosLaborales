using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuestaRepository
    {
        IEnumerable<Propuesta> GetAllPropuesta();
        Propuesta GetPropuestaDetails(int id_propuesta);
        Propuesta GetPropuestaNumero(string numeropropuesta);
        Propuesta GetPropuestaConsecutivo(string consecutivo);
        bool InsertPropuesta(Propuesta propuesta);
        bool UpdatePropuesta(Propuesta propuesta);
        bool DeletePropuesta(int id_propuesta);
        DataTableAdapter<Propuesta> GetDataTablePropuesta(DataTableRequest model);
    }
}
