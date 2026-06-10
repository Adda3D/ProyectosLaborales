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
    public class DecVie_PlanAccionProgramaPgdRepository : SuperType<DecVie_PlanAccionProgramaPgd>, IDecVie_PlanAccionProgramaPgdRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionProgramaPgdRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionProgramaPgdRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionProgramaPgd(int id_programapgd)
        {
            Delete(id_programapgd);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionProgramaPgd> GetAllDecVie_PlanAccionProgramaPgd()
        {
            return Get();
        }

        public DecVie_PlanAccionProgramaPgd GetDecVie_PlanAccionProgramaPgdDetails(int id_programapgd)
        {
            return Get(id_programapgd);
        }

        public DecVie_PlanAccionProgramaPgd GetDecVie_PlanAccionProgramaPgdNombre(string cd_nmprogramapgd)
        {
            return Get(c => c.nmprogramapgd == cd_nmprogramapgd).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionProgramaPgd(DecVie_PlanAccionProgramaPgd decVie_PlanAccionProgramaPgd)
        {
            Add(decVie_PlanAccionProgramaPgd);
            return true;
        }

        public bool UpdateDecVie_PlanAccionProgramaPgd(DecVie_PlanAccionProgramaPgd decVie_PlanAccionProgramaPgd)
        {
            Update(decVie_PlanAccionProgramaPgd);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionProgramaPgd> IDecVie_PlanAccionProgramaPgdRepository.GetDataTableDecVie_PlanAccionProgramaPgd(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionProgramaPgd, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionProgramaPgd, string>> orderByFunc = null;
            Expression<Func<DecVie_PlanAccionProgramaPgd, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmprogramapgd.ToLower().Contains(model.SearchValue.ToLower()) || d.descripcionprogramapgd.ToLower().Contains(model.SearchValue.ToLower()) || d.estrategiaprogramapgd.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }
            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn == "id_programapgd")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PlanAccionProgramaPgd>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionProgramaPgd>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PlanAccionProgramaPgd> data = null;

            if (model.SortColumn == "id_programapgd")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionProgramaPgd> result = new DataTableAdapter<DecVie_PlanAccionProgramaPgd>();

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