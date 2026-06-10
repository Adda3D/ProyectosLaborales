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
    public class DependenciaRepository : SuperType<Dependencia>, IDependenciaRepository
    {
        private ApplicationDbContext _context;

        public DependenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DependenciaRepository()
        {
            _context = new ApplicationDbContext();
        }


        public bool DeleteDependencia(int id_depend)
        {
            Delete(id_depend);
            
            return true;
        }

        public IEnumerable<Dependencia> GetAllDependencia()
        {
            return Get();
        }

        public Dependencia GetDependenciaDetails(int id_depend)
        {
            return Get(id_depend);
        }

        public bool InsertDependencia(Dependencia dependencia)
        {
            Add(dependencia);

            return true;
        }

        public bool UpdateDependencia(Dependencia dependencia)
        {
            Update(dependencia);

            return true;
        }

        public Dependencia GetDependenciaDetails(string coddepend)
        {
            return Get(d => d.coddepend == coddepend).FirstOrDefault();
        }

        public DataTableAdapter<Dependencia> GetDataTableDependencia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Dependencia, bool>> srchByFunc = null;
            Expression<Func<Dependencia, string>> orderByFunc = null;

            Expression<Func<Dependencia, object>> parameter1 = d => d.areaacademica;
            Expression<Func<Dependencia, object>>[] parameterArray = new Expression<Func<Dependencia, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdepend.ToLower().Contains(model.SearchValue.ToLower()) || d.coddepend.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Dependencia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Dependencia> result = new DataTableAdapter<Dependencia>();

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