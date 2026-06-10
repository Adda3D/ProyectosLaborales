using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_CalificacionRepository
    {
        IEnumerable<Persona_Calificacion> GetAllPersona_Calificacion();
        Persona_Calificacion GetPersona_CalificacionDetails(int id_calificacion);
        IEnumerable<Persona_Calificacion> GetPersona_CalificacionCalificacion(string cd_calificacion);
        bool InsertPersona_Calificacion(Persona_Calificacion persona_Calificacion);
        bool UpdatePersona_Calificacion(Persona_Calificacion persona_Calificacion);
        bool DeletePersona_Calificacion(int id_calificacion);
    }
}
