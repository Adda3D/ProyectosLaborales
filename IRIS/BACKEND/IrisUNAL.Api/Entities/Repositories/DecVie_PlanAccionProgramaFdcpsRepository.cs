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
    public class DecVie_PlanAccionProgramaFdcpsRepository : SuperType<DecVie_PlanAccionProgramaFdcps>, IDecVie_PlanAccionProgramaFdcpsRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionProgramaFdcpsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionProgramaFdcpsRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionProgramaFdcps(int id_programafdcps)
        {
            Delete(id_programafdcps);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionProgramaFdcps> GetAllDecVie_PlanAccionProgramaFdcps()
        {
            return Get();
        }

        public DecVie_PlanAccionProgramaFdcps GetDecVie_PlanAccionProgramaFdcpsDetails(int id_programafdcps)
        {
            return Get(id_programafdcps);
        }

        public DecVie_PlanAccionProgramaFdcps GetDecVie_PlanAccionProgramaFdcpsNombre(string cd_programafacultad)
        {
            return Get(c => c.programafacultad == cd_programafacultad).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionProgramaFdcps(DecVie_PlanAccionProgramaFdcps decVie_PlanAccionProgramaFdcps)
        {
            Add(decVie_PlanAccionProgramaFdcps);
            return true;
        }

        public bool UpdateDecVie_PlanAccionProgramaFdcps(DecVie_PlanAccionProgramaFdcps decVie_PlanAccionProgramaFdcps)
        {
            Update(decVie_PlanAccionProgramaFdcps);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionProgramaFdcps> IDecVie_PlanAccionProgramaFdcpsRepository.GetDataTableDecVie_PlanAccionProgramaFdcps(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionProgramaFdcps, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionProgramaFdcps, string>> orderByFunc = null;
            Expression<Func<DecVie_PlanAccionProgramaFdcps, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.programafacultad.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }
            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn == "id_programafdcps")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PlanAccionProgramaFdcps>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionProgramaFdcps>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PlanAccionProgramaFdcps> data = null;

            if (model.SortColumn == "id_programafdcps")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionProgramaFdcps> result = new DataTableAdapter<DecVie_PlanAccionProgramaFdcps>();

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