using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_PlanAccionMatrizIndicadoresRepository : SuperType<DecVie_PlanAccionMatrizIndicadores>, IDecVie_PlanAccionMatrizIndicadoresRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionMatrizIndicadoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionMatrizIndicadoresRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionMatrizIndicadores(int id_matrizindicadores)
        {
            Delete(id_matrizindicadores);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionMatrizIndicadores> GetAllDecVie_PlanAccionMatrizIndicadores()
        {
            return Get();
        }

        public DecVie_PlanAccionMatrizIndicadores GetDecVie_PlanAccionMatrizIndicadoresDetails(int id_matrizindicadores)
        {
            return Get(id_matrizindicadores);
        }

        public bool InsertDecVie_PlanAccionMatrizIndicadores(DecVie_PlanAccionMatrizIndicadores decVie_PlanAccionMatrizIndicadores)
        {
            Add(decVie_PlanAccionMatrizIndicadores);
            return true;
        }

        public bool UpdateDecVie_PlanAccionMatrizIndicadores(DecVie_PlanAccionMatrizIndicadores decVie_PlanAccionMatrizIndicadores)
        {
            Update(decVie_PlanAccionMatrizIndicadores);
            return true;
        }
    }
}