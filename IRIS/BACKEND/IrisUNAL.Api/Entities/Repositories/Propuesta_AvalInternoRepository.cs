using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Propuesta_AvalInternoRepository : SuperType<Propuesta_AvalInterno>, IPropuesta_AvalInternoRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_AvalInternoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_AvalInternoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_AvalInterno(int id_avalinterno)
        {
            Delete(id_avalinterno);
            return true;
        }

        public IEnumerable<Propuesta_AvalInterno> GetAllPropuesta_AvalInterno()
        {
            return Get();
        }

        public Propuesta_AvalInterno GetPropuesta_AvalInternoDetails(int id_avalinterno)
        {
            return Get(id_avalinterno);
        }

        public IEnumerable<Propuesta_AvalInterno> GetPropuesta_AvalInternoDetails(string cd_avalinterno)
        {
            return Get(c=> c.avalinterno==cd_avalinterno);
        }

        public bool InsertPropuesta_AvalInterno(Propuesta_AvalInterno propuesta_AvalInterno)
        {
            Add(propuesta_AvalInterno);
            return true;
        }

        public bool UpdatePropuesta_AvalInterno(Propuesta_AvalInterno propuesta_AvalInterno)
        {
            Update(propuesta_AvalInterno);
            return true;
        }
    }
}