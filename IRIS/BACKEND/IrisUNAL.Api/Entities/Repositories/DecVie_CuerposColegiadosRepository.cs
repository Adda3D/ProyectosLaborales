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
    public class DecVie_CuerposColegiadosRepository : SuperType<DecVie_CuerposColegiados>, IDecVie_CuerposColegiadosRepository
    {
        private ApplicationDbContext _context;

        public DecVie_CuerposColegiadosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_CuerposColegiadosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_CuerposColegiados(int id_cuerposcolegiados)
        {
            Delete(id_cuerposcolegiados);
            return true;
        }

        public IEnumerable<DecVie_CuerposColegiados> GetAllDecVie_CuerposColegiados()
        {
            return Get();
        }

        public DecVie_CuerposColegiados GetDecVie_CuerposColegiadosDetails(int id_cuerposcolegiados)
        {
            return Get(id_cuerposcolegiados);
        }

        public DecVie_CuerposColegiados GetDecVie_CuerposColegiadosNumero(string cd_numacta)
        {
            return Get(c => c.numacta == cd_numacta).FirstOrDefault();
        }

        public bool InsertDecVie_CuerposColegiados(DecVie_CuerposColegiados decVie_CuerposColegiados)
        {
            Add(decVie_CuerposColegiados);
            return true;
        }

        public bool UpdateDecVie_CuerposColegiados(DecVie_CuerposColegiados decVie_CuerposColegiados)
        {
            Update(decVie_CuerposColegiados);
            return true;
        }
        public DataTableAdapter<DecVie_CuerposColegiados> GetDataTableDecVie_CuerposColegiados(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_CuerposColegiados, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_CuerposColegiados, bool>> srchByFunc = null;
            Expression<Func<DecVie_CuerposColegiados, string>> orderByFunc = null;
            Expression<Func<DecVie_CuerposColegiados, int>> orderByIntFunc = null;

            Expression<Func<DecVie_CuerposColegiados, object>> parameter2 = d => d.Objcolegiados;
            Expression<Func<DecVie_CuerposColegiados, object>> parameter3 = d => d.Objmacroproceso;
            Expression<Func<DecVie_CuerposColegiados, object>> parameter5 = d => d.Objdependencia;          

            Expression<Func<DecVie_CuerposColegiados, object>>[] parameterArray = new Expression<Func<DecVie_CuerposColegiados, object>>[] { parameter2, parameter3, parameter5, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numacta.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "ano")
                orderByDateFunc = CreateExpressionOrderByDate<DecVie_CuerposColegiados>("ano");
            else

            if (model.SortColumn == "id_cuerposcolegiados")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_CuerposColegiados>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_CuerposColegiados>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_CuerposColegiados> data = null;
            if (model.SortColumn.ToLower() == "ano")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_cuerposcolegiados")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_CuerposColegiados> result = new DataTableAdapter<DecVie_CuerposColegiados>();

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