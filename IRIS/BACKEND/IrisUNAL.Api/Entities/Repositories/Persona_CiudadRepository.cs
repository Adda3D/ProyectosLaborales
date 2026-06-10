using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Persona_CiudadRepository : SuperType<Persona_Ciudad>, IPersona_CiudadRepository
    {
        private ApplicationDbContext _context;

        public Persona_CiudadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_CiudadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_Ciudad(int id_ciudad)
        {
            Delete(id_ciudad);
            return true;
        }

        public IEnumerable<Persona_Ciudad> GetAllPersona_Ciudad()
        {
            return Get();
        }

        public Persona_Ciudad GetPersona_CiudadDetails(int id_ciudad)
        {
            return Get(id_ciudad);
        }

        public IEnumerable<Persona_Ciudad> GetPersona_CiudadDetails(string cd_nmciudad)
        {
            return Get(c => c.nmciudad == cd_nmciudad);
        }

        public bool InsertPersona_Ciudad(Persona_Ciudad persona_Ciudad)
        {
            Add(persona_Ciudad);
            return true;
        }

        public bool UpdatePersona_Ciudad(Persona_Ciudad persona_Ciudad)
        {
            Update(persona_Ciudad);
            return true;
        }
    }
}