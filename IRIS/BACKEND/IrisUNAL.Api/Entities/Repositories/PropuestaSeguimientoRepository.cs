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
    public class PropuestaSeguimientoRepository : SuperType<Propuestaseguimiento>
    {
        private ApplicationDbContext _context;

        public PropuestaSeguimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PropuestaSeguimientoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Propuestaseguimiento> GetAllPropuestaSeguimiento()
        {
            return Get();
        }

        public Propuestaseguimiento GetPropuestaSeguimientoDetails(int idseguimiento)
        {
            return Get(idseguimiento);
        }

        public bool InsertPropuestaSeguimiento(Propuestaseguimiento propuestaseguimiento)
        {
            Add(propuestaseguimiento);
            return true;
        }
        public bool UpdatePropuestaSeguimiento(Propuestaseguimiento propuestaseguimiento)
        {
            Update(propuestaseguimiento);
            return true;

        }
        public bool DeletePropuestaSeguimiento(int idseguimiento)
        {
            Delete(idseguimiento);
            return true;
        }
        public DataTableAdapter<Propuestaseguimiento> GetDataTablePropuestaSeguimiento(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuestaseguimiento, bool>> srchByFunc = null;
            Expression<Func<Propuestaseguimiento, string>> orderByFunc = null;

            Expression<Func<Propuestaseguimiento, object>> parameter1 = v => v.funcionario;
            Expression<Func<Propuestaseguimiento, object>>[] parameterArray = new Expression<Func<Propuestaseguimiento, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.seguimientodetalle.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuestaseguimiento>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuestaseguimiento> result = new DataTableAdapter<Propuestaseguimiento>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Propuestaseguimiento> GetDataTablePropuestaSeguimientoByPropuesta(int id_propuesta, DataTableRequest model)
        {
            var totalRows = 0; // Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuestaseguimiento, bool>> srchByFunc = null;
            Expression<Func<Propuestaseguimiento, string>> orderByFunc = null;
            Expression<Func<Propuestaseguimiento, DateTime>> orderByDateFunc = null;            

            Expression <Func<Propuestaseguimiento, object>> parameter1 = v => v.funcionario;
            Expression<Func<Propuestaseguimiento, object>>[] parameterArray = new Expression<Func<Propuestaseguimiento, object>>[] { parameter1 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_propuesta == id_propuesta;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = p => p.id_propuesta == id_propuesta && p.seguimientodetalle.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "strfechaseguimiento")
                orderByDateFunc = CreateExpressionOrderByDate<Propuestaseguimiento>("fechaseguimiento");
            else
                orderByFunc = CreateExpressionOrderBy<Propuestaseguimiento>(model.SortColumn);
             
            var data = (model.SortColumn.ToLower() == "strfechaseguimiento") ? 
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() : 
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuestaseguimiento> result = new DataTableAdapter<Propuestaseguimiento>();

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