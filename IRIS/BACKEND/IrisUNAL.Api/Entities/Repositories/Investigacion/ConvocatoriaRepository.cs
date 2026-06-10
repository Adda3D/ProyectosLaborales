using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class ConvocatoriaRepository : SuperType<Convocatoria>
    {
        private ApplicationDbContext _context;

        public ConvocatoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ConvocatoriaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Convocatoria> GetAllConvocatoria()
        {
            return Get();
        }
        public Convocatoria GetConvocatoriaDetails(int id_convocatoria)
        {
            return Get(id_convocatoria);
        }
        public Convocatoria GetConvocatoriaNombre(string cd_tituloconvocatoria)
        {
            return Get(c => c.tituloconvocatoria == cd_tituloconvocatoria).FirstOrDefault();
        }
        public bool InsertConvocatoria(Convocatoria convocatoria)
        {
            Add(convocatoria);
            return true;
        }
        public bool UpdateConvocatoria(Convocatoria convocatoria)
        {
            Update(convocatoria);
            return true;
        }
        public bool DeleteConvocatoria(int id_convocatoria)
        {
            Delete(id_convocatoria);
            return true;
        }
        public DataTableAdapter<Convocatoria> GetDataTableConvocatoria(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria, DateTime>> orderByDateFunc = null;
            Expression<Func<Convocatoria, bool>> srchByFunc = null;
            Expression<Func<Convocatoria, string>> orderByFunc = null;
            Expression<Func<Convocatoria, int>> orderByIntFunc = null;

            Expression<Func<Convocatoria, object>> parameter1 = d => d.Objconvocatoriaalcance;
            Expression<Func<Convocatoria, object>> parameter2 = d => d.Objconvocatoriaestado;
            Expression<Func<Convocatoria, object>> parameter3 = d => d.Objconvocatoriafuente;


            Expression<Func<Convocatoria, object>>[] parameterArray = new Expression<Func<Convocatoria, object>>[] { parameter1, parameter2, parameter3, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.tituloconvocatoria.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "fechaapertura")
                orderByDateFunc = CreateExpressionOrderByDate<Convocatoria>("fechaapertura");
            else

            if (model.SortColumn == "id_convocatoria")
            {
                orderByIntFunc = CreateExpressionOrderByInt<Convocatoria>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<Convocatoria>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<Convocatoria> data = null;
            if (model.SortColumn.ToLower() == "fechaapertura")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_convocatoria")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria> result = new DataTableAdapter<Convocatoria>();

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