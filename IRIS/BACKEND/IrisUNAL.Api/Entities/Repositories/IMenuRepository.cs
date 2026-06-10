using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetAllMenu();
        Menu GetMenuDetails(int idmenu);
        IEnumerable<Menu> GetMenuNombre(string nombreitem);
        bool InsertMenu(Menu menu);
        bool UpdateMenu(Menu menu);
        bool DeleteMenu(int idmenu);
        List<MenuUsuario> GetMenuByRol(int idrol);
        List<MenuUsuario> GetMenuAcceso(int idrol);
    }
}
