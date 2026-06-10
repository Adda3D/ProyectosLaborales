using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_TituloAltoRepository
    {
        IEnumerable<Persona_TituloAlto> GetAllPersona_TituloAlto();
        Persona_TituloAlto GetPersona_TituloAltoDetails(int id_tituloalto);
        Persona_TituloAlto GetPersona_TituloAltoDetails(string nmtituloalto);
        bool InsertPersona_TituloAlto(Persona_TituloAlto persona_TituloAlto);
        bool UpdatePersona_TituloAlto(Persona_TituloAlto persona_TituloAlto);
        bool DeletePersona_TituloAlto(int id_tituloalto);
        DataTableAdapter<Persona_TituloAlto> GetDataTablePersona_TituloAlto(DataTableRequest model);
    }
}
