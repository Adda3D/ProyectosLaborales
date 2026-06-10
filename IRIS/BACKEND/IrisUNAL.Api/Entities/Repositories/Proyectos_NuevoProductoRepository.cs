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
    public class Proyectos_NuevoProductoRepository : SuperType<Proyectos_NuevoProducto>, IProyectos_NuevoProductoRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_NuevoProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_NuevoProductoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyectos_NuevoProducto(int id_nuevoproducto)
        {
            Delete(id_nuevoproducto);
            return true;
        }

        public IEnumerable<Proyectos_NuevoProducto> GetAllProyectos_NuevoProducto()
        {
            return Get();
        }

        public Proyectos_NuevoProducto GetProyectos_NuevoProductoDetails(int id_nuevoproducto)
        {
            return Get(id_nuevoproducto);
        }

        public bool InsertProyectos_NuevoProducto(Proyectos_NuevoProducto proyectos_NuevoProducto)
        {
            Add(proyectos_NuevoProducto);
            return true;
        }

        public bool UpdateProyectos_NuevoProducto(Proyectos_NuevoProducto proyectos_NuevoProducto)
        {
            Update(proyectos_NuevoProducto);
            return true;
        }

        public DataTableAdapter<Proyectos_NuevoProducto> GetDataTableProyectos_ProductosByProyecto(int id_asignacionproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_NuevoProducto, bool>> srchByFunc = null;
            Expression<Func<Proyectos_NuevoProducto, string>> orderByFunc = null;
            Expression<Func<Proyectos_NuevoProducto, DateTime>> orderByDateFunc = null;

            Expression<Func<Proyectos_NuevoProducto, object>> parameter1 = m => m.tipoProducto;
            Expression<Func<Proyectos_NuevoProducto, object>> parameter2 = m => m.estadoProducto;
            Expression<Func<Proyectos_NuevoProducto, object>>[] parameterArray = new Expression<Func<Proyectos_NuevoProducto, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Proyectos_NuevoProducto>("fechaentrega");
            else
                orderByFunc = CreateExpressionOrderBy<Proyectos_NuevoProducto>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto && d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            //orderByFunc = CreateExpressionOrderBy<Proyectos_ProyectosObservaciones>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_NuevoProducto> result = new DataTableAdapter<Proyectos_NuevoProducto>();

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