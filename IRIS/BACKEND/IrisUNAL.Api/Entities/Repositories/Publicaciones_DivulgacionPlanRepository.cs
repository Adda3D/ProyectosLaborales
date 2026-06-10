using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionPlanRepository : SuperType<Publicaciones_DivulgacionPlan>, IPublicaciones_DivulgacionPlanRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionPlanRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionPlan(int id_plan)
        {
            Delete(id_plan);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionPlan> GetAllPublicaciones_DivulgacionPlan()
        {
            return Get();
        }

        public Publicaciones_DivulgacionPlan GetPublicaciones_DivulgacionPlanDetails(int id_plan)
        {
            return Get(id_plan);
        }

        public bool InsertPublicaciones_DivulgacionPlan(Publicaciones_DivulgacionPlan publicaciones_DivulgacionPlan)
        {
            Add(publicaciones_DivulgacionPlan);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionPlan(Publicaciones_DivulgacionPlan publicaciones_DivulgacionPlan)
        {
            Update(publicaciones_DivulgacionPlan);
            return true;
        }

        public Publicaciones_DivulgacionPlan GetPublicaciones_DivulgacionPlanByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}