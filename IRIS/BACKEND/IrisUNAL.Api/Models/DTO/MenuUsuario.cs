using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class OpcionMenu
    {
        public int idmenu { get; set; }
        public int idmenupadre { get; set; }
        public string nombreitem { get; set; }
        public string url { get; set; }
        public string onclick { get; set; }
        public string classimage { get; set; }
        public int orden { get; set; }
        public bool mostrar { get; set; }
        public bool? opciones { get; set; }
        public int? idrolmenu { get; set; }
    }

    public class OpcionSubMenu
    {
        public OpcionMenu opcion { get; set; }

        public List<OpcionSubMenu> submenu { get; set; }
    }

    public class MenuUsuario
    {
        public OpcionMenu opcion { get; set; }

        public List<OpcionSubMenu> submenu { get; set; }
    }

}