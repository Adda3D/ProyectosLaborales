using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Proyectos_TipoProductoRepository : SuperType<Proyectos_TipoProducto>
    {
        private ApplicationDbContext _context;

        public Proyectos_TipoProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_TipoProductoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteProyectos_TipoProducto(int id_TipoProducto)
        {
            Delete(id_TipoProducto);
            return true;
        }

        public IEnumerable<Proyectos_TipoProducto> GetAllProyectos_TipoProducto()
        {
            return Get();
        }

        public Proyectos_TipoProducto GetProyectos_TipoProductoNombre(string cd_tipoproducto)
        {
            return Get(c=>c.tipoproducto==cd_tipoproducto).FirstOrDefault();
        }

        public Proyectos_TipoProducto GetProyectos_TipoProductoDetails(int id_tipoproducto)
        {
            return Get(id_tipoproducto);
        }

        public bool InsertProyectos_TipoProducto(Proyectos_TipoProducto proyectos_tipoproducto)
        {
            Add(proyectos_tipoproducto);
            return true;
        }

        public bool UpdateProyectos_TipoProducto(Proyectos_TipoProducto proyectos_tipoproducto)
        {
            Update(proyectos_tipoproducto);
            return true;
        }

        public DataTableAdapter<Proyectos_TipoProducto> GetDataTableProyectoTipoProducto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_TipoProducto, bool>> srchByFunc = null;
            Expression<Func<Proyectos_TipoProducto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.tipoproducto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_TipoProducto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_TipoProducto> result = new DataTableAdapter<Proyectos_TipoProducto>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }
    }
}