using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_CiudadRepository
    {
        IEnumerable<Persona_Ciudad> GetAllPersona_Ciudad();
        Persona_Ciudad GetPersona_CiudadDetails(int id_ciudad);
        IEnumerable<Persona_Ciudad> GetPersona_CiudadDetails(string cd_nmciudad);
        bool InsertPersona_Ciudad(Persona_Ciudad persona_Ciudad);
        bool UpdatePersona_Ciudad(Persona_Ciudad persona_Ciudad);
        bool DeletePersona_Ciudad(int id_ciudad);
    }
}
