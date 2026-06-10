using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_FormacionRepository
    {
        IEnumerable<Persona_Formacion> GetAllPersona_Formacion();
        Persona_Formacion GetPersona_FormacionDetails(int id_formacion);
        Persona_Formacion GetPersona_FormacionDetails(string nmformacion);
        bool InsertPersona_Formacion(Persona_Formacion persona_Formacion);
        bool UpdatePersona_Formacion(Persona_Formacion persona_Formacion);
        bool DeletePersona_Formacion(int id_formacion);
        DataTableAdapter<Persona_Formacion> GetDataTablePersona_Formacion(DataTableRequest model);
    }
}
