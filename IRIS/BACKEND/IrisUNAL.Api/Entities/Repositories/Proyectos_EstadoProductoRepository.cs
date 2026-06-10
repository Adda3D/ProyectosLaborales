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
    public class Proyectos_EstadoProductoRepository : SuperType<Proyectos_EstadoProducto>
    {
        private ApplicationDbContext _context;

        public Proyectos_EstadoProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_EstadoProductoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteProyectos_EstadoProducto(int id_estadoproducto)
        {
            Delete(id_estadoproducto);
            return true;
        }

        public IEnumerable<Proyectos_EstadoProducto> GetAllProyectos_EstadoProducto()
        {
            return Get();
        }

        public Proyectos_EstadoProducto GetProyectos_EstadoProductoDetails(int id_estadoproducto)
        {
            return Get(id_estadoproducto);
        }
        public Proyectos_EstadoProducto GetProyectos_EstadoProductoNombre(string cd_estadoproducto)
        {
            return Get(c=>c.estadoproducto==cd_estadoproducto).FirstOrDefault();
        }

        public bool InsertProyectos_EstadoProducto(Proyectos_EstadoProducto proyectos_estadoproducto)
        {
            Add(proyectos_estadoproducto);
            return true;
        }

        public bool UpdateProyectos_EstadoProducto(Proyectos_EstadoProducto proyectos_estadoproducto)
        {
            Update(proyectos_estadoproducto);
            return true;
        }

        public DataTableAdapter<Proyectos_EstadoProducto> GetDataTableProyectos_EstadoProducto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_EstadoProducto, bool>> srchByFunc = null;
            Expression<Func<Proyectos_EstadoProducto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.estadoproducto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_EstadoProducto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_EstadoProducto> result = new DataTableAdapter<Proyectos_EstadoProducto>();

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