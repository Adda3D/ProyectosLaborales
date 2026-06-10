using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionPlanRepository
    {
        IEnumerable<Publicaciones_DivulgacionPlan> GetAllPublicaciones_DivulgacionPlan();
        Publicaciones_DivulgacionPlan GetPublicaciones_DivulgacionPlanDetails(int id_plan);        
        bool InsertPublicaciones_DivulgacionPlan(Publicaciones_DivulgacionPlan publicaciones_DivulgacionPlan);
        bool UpdatePublicaciones_DivulgacionPlan(Publicaciones_DivulgacionPlan publicaciones_DivulgacionPlan);
        bool DeletePublicaciones_DivulgacionPlan(int id_plan);
        Publicaciones_DivulgacionPlan GetPublicaciones_DivulgacionPlanByPublicacion(int id_crearpublicacion);
    }
}
