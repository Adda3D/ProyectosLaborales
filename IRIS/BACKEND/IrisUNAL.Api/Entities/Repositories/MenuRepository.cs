using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class MenuRepository : SuperType<Menu>, IMenuRepository
    {
        private ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MenuRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteMenu(int idmenu)
        {
            Delete(idmenu);
            return true;
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            return Get();
        }

        public Menu GetMenuDetails(int idmenu)
        {
            return Get(idmenu);
        }

        public IEnumerable<Menu> GetMenuNombre(string cd_nombreitem)
        {
            return Get(c=>c.nombreitem==cd_nombreitem);
        }

        public bool InsertMenu(Menu menu)
        {
            Add(menu);
            return true;
        }

        public bool UpdateMenu(Menu menu)
        {
            Update(menu);
            return true;
        }

        public List<MenuUsuario> GetMenuByRol(int idrol)
        {
            var listaopciones = (from rm in _context.rolmenu
                                 join m in _context.menu on rm.idmenu equals m.idmenu
                                 where rm.idrol == idrol
                                 orderby m.orden
                                 select m).ToList();

            List<MenuUsuario> menufinal = new List<MenuUsuario>();

            List<OpcionSubMenu> submenu = new List<OpcionSubMenu>();


            foreach (var opc in listaopciones)
            {
                if (opc.idmenupadre == 0)
                {
                    OpcionMenu menu = new OpcionMenu();
                    MenuUsuario menuusuario = new MenuUsuario();

                    setDetalleOpcion(opc, menu);

                    menuusuario.opcion = menu;

                    if ((bool)opc.opciones)
                    {
                        submenu = setSubMenu(listaopciones, menu.idmenu);
                        menuusuario.submenu = submenu;
                    }

                    menufinal.Add(menuusuario);
                }
            }

            return menufinal;
        }

        private void setDetalleOpcion(Menu opc, OpcionMenu menu)
        {
            menu.idmenu = opc.idmenu;
            menu.idmenupadre = opc.idmenupadre;
            menu.nombreitem = opc.nombreitem;
            menu.url = opc.url;
            menu.onclick = opc.onclick;
            menu.classimage = opc.classimage;
            menu.orden = opc.orden;
            menu.mostrar = opc.mostrar;
            menu.opciones = opc.opciones;

        }

        private List<OpcionSubMenu> setSubMenu(List<Menu> opciones, int idpadre)
        {
            List<OpcionSubMenu> submenu = new List<OpcionSubMenu>();

            foreach (var opc in opciones)
            {
                if (opc.idmenupadre == idpadre)
                {
                    if (opc.mostrar)
                    {
                        OpcionSubMenu opcionsubmenu = new OpcionSubMenu();
                        OpcionMenu opcion = new OpcionMenu();

                        setDetalleOpcion(opc, opcion);

                        opcionsubmenu.opcion = opcion;

                        if ((bool)opc.opciones)
                        {
                            List<OpcionSubMenu> submenunivel = new List<OpcionSubMenu>();

                            submenunivel = setSubMenu(opciones, opcion.idmenu);
                            opcionsubmenu.submenu = submenunivel;
                        }

                        submenu.Add(opcionsubmenu);
                    }
                }
            }

            return submenu;
        }

        public List<MenuUsuario> GetMenuAcceso(int idrol)
        {
            var queryacceso = "select m.idmenu,m.idmenupadre,m.nombreitem,m.url,m.onclick,m.classimage,m.orden,m.mostrar,m.opciones,rm.idrolmenu from menu m " +
                "left join rolmenu rm on m.idmenu = rm.idmenu and rm.idrol = @idrol " +
                "where m.mostrar order by m.orden";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@idrol", idrol));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var listaopciones = _context.Database.SqlQuery<OpcionMenu>(queryacceso, Param).ToList();

            List<MenuUsuario> menufinal = new List<MenuUsuario>();

            List<OpcionSubMenu> submenu = new List<OpcionSubMenu>();


            foreach (var opc in listaopciones)
            {
                if (opc.idmenupadre == 0)
                {
                    OpcionMenu menu = new OpcionMenu();
                    MenuUsuario menuusuario = new MenuUsuario();

                    //setDetalleOpcion(opc, menu);

                    menuusuario.opcion = opc;

                    if ((bool)opc.opciones)
                    {
                        submenu = setSubMenuAcceso(listaopciones, opc.idmenu);
                        menuusuario.submenu = submenu;
                    }

                    menufinal.Add(menuusuario);
                }
            }

            return menufinal;
        }

        private List<OpcionSubMenu> setSubMenuAcceso(List<OpcionMenu> opciones, int idpadre)
        {
            List<OpcionSubMenu> submenu = new List<OpcionSubMenu>();

            foreach (var opc in opciones)
            {
                if (opc.idmenupadre == idpadre)
                {
                    if (opc.mostrar)
                    {
                        OpcionSubMenu opcionsubmenu = new OpcionSubMenu();
                        OpcionMenu opcion = new OpcionMenu();

                        //setDetalleOpcion(opc, opcion);

                        opcionsubmenu.opcion = opc;

                        if ((bool)opc.opciones)
                        {
                            List<OpcionSubMenu> submenunivel = new List<OpcionSubMenu>();

                            submenunivel = setSubMenuAcceso(opciones, opc.idmenu);
                            opcionsubmenu.submenu = submenunivel;
                        }

                        submenu.Add(opcionsubmenu);
                    }
                }
            }

            return submenu;
        }

    }
}