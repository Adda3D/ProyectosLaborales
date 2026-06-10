using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ControlFinancieroGastosRepository
    {
        IEnumerable<DecVie_ControlFinancieroGastos> GetAllDecVie_ControlFinancieroGastos();
        DecVie_ControlFinancieroGastos GetDecVie_ControlFinancieroGastosDetails(int id_gastos);
        bool InsertDecVie_ControlFinancieroGastos(DecVie_ControlFinancieroGastos decVie_ControlFinancieroGastos);
        bool UpdateDecVie_ControlFinancieroGastos(DecVie_ControlFinancieroGastos decVie_ControlFinancieroGastos);
        bool DeleteDecVie_ControlFinancieroGastos(int id_gastos);
    }
}
