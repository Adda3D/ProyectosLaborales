using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Persona_PaisRepository : SuperType<Persona_Pais>, IPersona_PaisRepository
    {
        private ApplicationDbContext _context;

        public Persona_PaisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_PaisRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_Pais(int id_pais)
        {
            Delete(id_pais);
            return true;            
        }

        public IEnumerable<Persona_Pais> GetAllPersona_Pais()
        {
            return Get();
        }

        public Persona_Pais GetPersona_PaisDetails(int id_pais)
        {
            return Get(id_pais);            
        }

        public IEnumerable<Persona_Pais> GetPersona_PaisDetails(string cd_nmpais)
        {
            return Get(c => c.nmpais == cd_nmpais);
        }

        public bool InsertPersona_Pais(Persona_Pais persona_Pais)
        {
            Add(persona_Pais);
            return true;            
        }

        public bool UpdatePersona_Pais(Persona_Pais persona_Pais)
        {
            Update(persona_Pais);
            return true;            
        }
    }
}