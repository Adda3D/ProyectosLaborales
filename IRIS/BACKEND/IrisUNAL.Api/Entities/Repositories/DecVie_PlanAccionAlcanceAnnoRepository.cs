using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_PlanAccionAlcanceAnnoRepository : SuperType<DecVie_PlanAccionAlcanceAnno>, IDecVie_PlanAccionAlcanceAnnoRepository
    {
        public bool DeleteDecVie_PlanAccionAlcanceAnno(int id_alcanceanno)
        {
            Delete(id_alcanceanno);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionAlcanceAnno> GetAllDecVie_PlanAccionAlcanceAnno()
        {
            return Get();
        }

        public DecVie_PlanAccionAlcanceAnno GetDecVie_PlanAccionAlcanceAnnoDetails(int id_alcanceanno)
        {
            return Get(id_alcanceanno);
        }

        public DecVie_PlanAccionAlcanceAnno GetDecVie_PlanAccionAlcanceAnnoNombre(string cd_nmalcanceanno)
        {
            return Get(c => c.nmalcanceanno == cd_nmalcanceanno).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionAlcanceAnno(DecVie_PlanAccionAlcanceAnno decVie_PlanAccionAlcanceAnno)
        {
            Add(decVie_PlanAccionAlcanceAnno);
            return true;
        }

        public bool UpdateDecVie_PlanAccionAlcanceAnno(DecVie_PlanAccionAlcanceAnno decVie_PlanAccionAlcanceAnno)
        {
            Update(decVie_PlanAccionAlcanceAnno);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionAlcanceAnno> IDecVie_PlanAccionAlcanceAnnoRepository.GetDataTableDecVie_PlanAccionAlcanceAnno(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionAlcanceAnno, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionAlcanceAnno, string>> orderByFunc = null;
            Expression<Func<DecVie_PlanAccionAlcanceAnno, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmalcanceanno.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }
            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn == "id_alcanceanno")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PlanAccionAlcanceAnno>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionAlcanceAnno>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PlanAccionAlcanceAnno> data = null;

            if (model.SortColumn == "id_alcanceanno")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionAlcanceAnno> result = new DataTableAdapter<DecVie_PlanAccionAlcanceAnno>();

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