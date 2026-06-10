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
    public class Investigacion_ProductoRepository : SuperType<Investigacion_Producto>, IInvestigacion_ProductoRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_ProductoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_Producto(int id_producto)
        {
            Delete(id_producto);
            return true;
        }

        public IEnumerable<Investigacion_Producto> GetAllInvestigacion_Producto()
        {
            return Get();
        }

        public Investigacion_Producto GetInvestigacion_ProductoDetails(int id_producto)
        {
            return Get(id_producto);
        }

        public bool InsertInvestigacion_Producto(Investigacion_Producto investigacion_Producto)
        {
            Add(investigacion_Producto);
            return true;
        }

        public bool UpdateInvestigacion_Producto(Investigacion_Producto investigacion_Producto)
        {
            Update(investigacion_Producto);
            return true;
        }

        public DataTableAdapter<Investigacion_Producto> GetDataTableInvestigacion_ProductoByProyecto(int id_crearproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Producto, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Producto, string>> orderByFunc = null;
            //Expression<Func<Investigacion_Producto, DateTime>> orderByDateFunc = null;

            Expression<Func<Investigacion_Producto, object>> parameter1 = m => m.ObjEstadoProducto;
            Expression<Func<Investigacion_Producto, object>> parameter2 = m => m.ObjTipoPropducto;
            Expression<Func<Investigacion_Producto, object>>[] parameterArray = new Expression<Func<Investigacion_Producto, object>>[] { parameter1,parameter2 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_crearproyecto == id_crearproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearproyecto == id_crearproyecto && d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_Producto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Producto> result = new DataTableAdapter<Investigacion_Producto>();

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