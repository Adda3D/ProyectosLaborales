using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Persona_CalificacionRepository : SuperType<Persona_Calificacion>, IPersona_CalificacionRepository
    {
        private ApplicationDbContext _context;

        public Persona_CalificacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_CalificacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_Calificacion(int id_calificacion)
        {
            Delete(id_calificacion);
            return true;            
        }

        public IEnumerable<Persona_Calificacion> GetAllPersona_Calificacion()
        {
            return Get();
        }

        public Persona_Calificacion GetPersona_CalificacionDetails(int id_calificacion)
        {
            return Get(id_calificacion);
        }

        public IEnumerable<Persona_Calificacion> GetPersona_CalificacionCalificacion(string cd_calificacion)
        {
            return Get(c=>c.calificacion==cd_calificacion);
        }

        public bool InsertPersona_Calificacion(Persona_Calificacion persona_Calificacion)
        {
            Add(persona_Calificacion);
            return true;
        }

        public bool UpdatePersona_Calificacion(Persona_Calificacion persona_Calificacion)
        {
            Update(persona_Calificacion);
            return true;
        }
    }
}