using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Area_AcademicaRepository : SuperType<Area_Academica>, IArea_AcademicaRepository 
    {
        private ApplicationDbContext _context;

        public Area_AcademicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Area_AcademicaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteArea_Academica(int id_areaacad)
        {
            Delete(id_areaacad);

            return true;
        }

        public IEnumerable<Area_Academica> GetAllArea_Academica()
        {
            return Get();
        }

        public Area_Academica GetArea_AcademicaDetails(int id_reaacad)
        {
            return Get(id_reaacad);
        }

        public IEnumerable<Area_Academica> GetArea_AcademicaDetails(string cd_areaacad)
        {
            return Get(c => c.codarea == cd_areaacad);
        }

        public bool InsertArea_Academica(Area_Academica area_Academica)
        {

            Add(area_Academica);

            return true;
        }

        public bool UpdateArea_Academica(Area_Academica area_Academica)
        {
            Update(area_Academica);

            return true;
            
        }

        public DataTableAdapter<Area_Academica> GetDataTableArea(DataTableRequest model)
        {
            //List<Area_Academica> obj = new List<Area_Academica>();

            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression <Func<Area_Academica, bool>> srchByFunc = null;
            Expression<Func<Area_Academica, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.codarea.ToLower().Contains(model.SearchValue.ToLower()) || d.nmaacad.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);                
            }

            orderByFunc = CreateExpressionOrderBy<Area_Academica>(model.SortColumn);
            
            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
            
            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Area_Academica> result = new DataTableAdapter<Area_Academica>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;

        }

        /*
        static Expression<Func<T, string>> CreateExpressionOrderBy<T>(string propertyName)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type);
            var access = Expression.Property(parameter, property);
            var convert = Expression.Convert(access, typeof(string));
            var function = Expression.Lambda<Func<T, string>>(convert, parameter);

            return function;
        }
        */
        static Expression<Func<T, bool>> CreateExpressionFilter<T>(string strfld, string txtsrch)
        {
            var prop = typeof(T).GetProperties().FirstOrDefault(p => p.Name == strfld);
            Expression<Func<T, bool>> predicate = null;
            var type = typeof(T);

            if (prop != null)
            {
                var parameter = Expression.Parameter(type, "x");
                var member = Expression.Property(parameter, prop);

                var parameterExp = Expression.Parameter(type, "x");
                var propertyExp = Expression.Property(parameterExp, prop);
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                MethodInfo miLower = typeof(string).GetMethod("ToLower", Type.EmptyTypes);

                Expression lowerMethod = Expression.Call(member, miLower);

                var someValue = Expression.Constant(txtsrch, typeof(string));
                var containsMethodExp = Expression.Call(lowerMethod, method, someValue);
                predicate = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameter);
            }

            return predicate;
        }

        static Expression<Func<T, bool>> CreateExpressionFilter<T>(DataTableRequest model)
        {
            Expression<Func<T, bool>> predicate = null;
            Expression<Func<T, bool>> predicatetmp = null;

            Expression<Func<T, bool>> expresionfiltro = predicatetmp;            
            List<Expression<Func<T, bool>>> predicatelst = new List<Expression<Func<T, bool>>>();

            var strfld = "";
            string txtsrch = model.SearchValue.ToLower();

            foreach (var columna in model.columns)
            {
                if (columna.searchable)
                {
                    strfld = columna.data;

                    predicate = CreateExpressionFilter<T>(strfld, txtsrch);
                    predicatelst.Add(predicate);
                }
            }

            if (predicatelst.Count() == 1)
            {
                expresionfiltro = predicatelst[0];
                return expresionfiltro;
            }

            foreach (var expr in predicatelst)
            {
                expresionfiltro = Unirlas<T>(expresionfiltro, expr);                
            }
          
            return expresionfiltro;
        }

        static Expression<Func<T, bool>> Unirlas<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null) return right;
            var and = Expression.OrElse(left.Body, right.Body);
            return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
        }
    }
}
