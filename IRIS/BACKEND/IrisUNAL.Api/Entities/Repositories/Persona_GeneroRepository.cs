using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Persona_GeneroRepository : SuperType<Persona_Genero>, IPersona_GeneroRepository
    {
        private ApplicationDbContext _context;

        public Persona_GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_GeneroRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_Genero(int id_genero)
        {
            Delete(id_genero);
            return true;            
        }

        public IEnumerable<Persona_Genero> GetAllPersona_Genero()
        {
            return Get();            
        }

        public Persona_Genero GetPersona_GeneroDetails(int id_genero)
        {
            return Get(id_genero);            
        }

        public IEnumerable<Persona_Genero> GetPersona_GeneroDetails(string cd_nmgenero)
        {
            return Get(c => c.nmgenero == cd_nmgenero);
        }

        public bool InsertPersona_Genero(Persona_Genero persona_Genero)
        {
            Add(persona_Genero);

            return true;
        }

        public bool UpdatePersona_Genero(Persona_Genero persona_Genero)
        {
            Update(persona_Genero);

            return true;
        }
    }
}