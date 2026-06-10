using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class RolMenuRepository : SuperType<RolMenu>, IRolMenuRepository
    {
        private ApplicationDbContext _context;

        public RolMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RolMenuRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteRolMenu(int id_rolmenu)
        {
            Delete(id_rolmenu);
            return true;
        }

        public IEnumerable<RolMenu> GetAllRolMenu()
        {
            return Get();
        }

        public RolMenu GetRolMenuDetails(int id_rolmenu)
        {
            return Get(id_rolmenu);
        }

        public bool InsertRolMenu(RolMenu rolMenu)
        {
            Add(rolMenu);
            return true;
        }

        public bool UpdateRolMenu(RolMenu rolMenu)
        {
            Update(rolMenu);
            return true;
        }

        public bool UpdateAccesoRol(List<AccesoOpcion> datoacceso)
        {
            int idrolborra = 0;
            //PRIMERO BORRAR TODOS LOS ACCESOS ASIGNADOS AL ROL
            if (datoacceso.Count() > 0)
            {
                idrolborra = datoacceso[0].idrol;
                var accesoanterior = Get(a => a.idrol == idrolborra).ToList();

                foreach (var opcion in accesoanterior)
                {
                    Delete(opcion.idrolmenu);
                }
            }
            
            //CREAR LOS ACCESOS DEFINIDOS
            foreach (var opcion in datoacceso)
            {
                if (opcion.acceso)
                {
                    RolMenu nuevoacceso = new RolMenu();
                    nuevoacceso.idrol = opcion.idrol;
                    nuevoacceso.idmenu = opcion.idmenu;

                    //BUSCAR LOS MENU PADRE Y LOS ACTIVA
                    UpdateAccesoPadre(opcion.idmenupadre, opcion.idrol);

                    RolMenu nueva = new RolMenu();

                    nueva.idmenu = opcion.idmenu;
                    nueva.idrol = opcion.idrol;

                    Add(nueva);
                }
            } 

            return true;            
        }

        public bool UpdateAccesoPadre(int idmenu, int idrol)
        {
            var opcionrol = Get(r => r.idmenu == idmenu && r.idrol == idrol).FirstOrDefault();

            if (opcionrol != null)
            {
                return true;
            }

            Menu opcionpadre = null;

            using (var _mn = new MenuRepository())
            {
                opcionpadre = _mn.Get(r => r.idmenu == idmenu).FirstOrDefault();
            }
                
            if (opcionpadre != null)
            {
                if (opcionpadre.idmenupadre != 0)
                {
                    UpdateAccesoPadre(opcionpadre.idmenupadre, idrol);
                }

                RolMenu nueva = new RolMenu();

                nueva.idmenu = idmenu;
                nueva.idrol = idrol;

                Add(nueva);                
            }

            return true;
        }
    }
}