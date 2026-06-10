using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IRolMenuRepository
    {
        IEnumerable<RolMenu> GetAllRolMenu();
        RolMenu GetRolMenuDetails(int id_rolmenu);        
        bool InsertRolMenu(RolMenu rolMenu);
        bool UpdateRolMenu(RolMenu rolMenu);
        bool DeleteRolMenu(int id_rolmenu);
        bool UpdateAccesoRol(List<AccesoOpcion> acceso);
        bool UpdateAccesoPadre(int idmenu, int idrol);
    }
}
