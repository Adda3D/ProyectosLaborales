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
    public class DecVie_PlanAccionAlcanceRepository : SuperType<DecVie_PlanAccionAlcance>, IDecVie_PlanAccionAlcanceRepository
    {
        public bool DeleteDecVie_PlanAccionAlcance(int id_planaccionalcance)
        {
            Delete(id_planaccionalcance);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionAlcance> GetAllDecVie_PlanAccionAlcance()
        {
            return Get();
        }

        public DecVie_PlanAccionAlcance GetDecVie_PlanAccionAlcanceDetails(int id_planaccionalcance)
        {
            return Get(id_planaccionalcance);
        }

        public DecVie_PlanAccionAlcance GetDecVie_PlanAccionAlcanceNombre(string cd_descripcionalcance)
        {
            return Get(c => c.descripcionalcance == cd_descripcionalcance).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionAlcance(DecVie_PlanAccionAlcance decVie_PlanAccionAlcance)
        {
            Add(decVie_PlanAccionAlcance);
            return true;
        }

        public bool UpdateDecVie_PlanAccionAlcance(DecVie_PlanAccionAlcance decVie_PlanAccionAlcance)
        {
            Update(decVie_PlanAccionAlcance);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionAlcance> IDecVie_PlanAccionAlcanceRepository.GetDataTableDecVie_PlanAccionAlcance(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            
            Expression<Func<DecVie_PlanAccionAlcance, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionAlcance, string>> orderByFunc = null;
            Expression<Func<DecVie_PlanAccionAlcance, int>> orderByIntFunc = null;

            Expression<Func<DecVie_PlanAccionAlcance, object>> parameter1 = d => d.ObjAlcanceanno;            
            Expression<Func<DecVie_PlanAccionAlcance, object>> parameter4 = d => d.Objdependencia;
            

            Expression<Func<DecVie_PlanAccionAlcance, object>>[] parameterArray = new Expression<Func<DecVie_PlanAccionAlcance, object>>[] { parameter1, parameter4, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.descripcionalcance.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
                        
            if (model.SortColumn == "id_planaccionalcance")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PlanAccionAlcance>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionAlcance>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PlanAccionAlcance> data = null;
            
            if (model.SortColumn == "id_planaccionalcance")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionAlcance> result = new DataTableAdapter<DecVie_PlanAccionAlcance>();

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