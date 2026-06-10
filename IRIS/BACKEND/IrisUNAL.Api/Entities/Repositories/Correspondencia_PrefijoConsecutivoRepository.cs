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
    public class Correspondencia_PrefijoConsecutivoRepository : SuperType<Correspondencia_PrefijoConsecutivo>, ICorrespondencia_PrefijoConsecutivoRepository
    {
        public bool DeleteCorrespondencia_PrefijoConsecutivo(int id_prefijoconsecutivo)
        {
            Delete(id_prefijoconsecutivo);
            return true;
        }

        public IEnumerable<Correspondencia_PrefijoConsecutivo> GetAllCorrespondencia_PrefijoConsecutivo()
        {
            return Get();
        }

        public IEnumerable<Correspondencia_PrefijoConsecutivo> GetCorrespondencia_PrefijoConsecutivoByDependencia(int id_depend)
        {
            return Get(c => c.id_depend == id_depend);

        }

        public Correspondencia_PrefijoConsecutivo GetCorrespondencia_PrefijoConsecutivoDetails(int id_prefijoconsecutivo)
        {
            return Get(id_prefijoconsecutivo);
        }

        public Correspondencia_PrefijoConsecutivo GetCorrespondencia_PrefijoConsecutivoNombre(string cd_nmprefijo)
        {
            return Get(c => c.nmprefijo == cd_nmprefijo).FirstOrDefault();
        }

        public bool InsertCorrespondencia_PrefijoConsecutivo(Correspondencia_PrefijoConsecutivo correspondencia_PrefijoConsecutivo)
        {
            Add(correspondencia_PrefijoConsecutivo);
            return true;
        }

        public bool UpdateCorrespondencia_PrefijoConsecutivo(Correspondencia_PrefijoConsecutivo correspondencia_PrefijoConsecutivo)
        {
            Update(correspondencia_PrefijoConsecutivo);
            return true;
        }
        DataTableAdapter<Correspondencia_PrefijoConsecutivo> ICorrespondencia_PrefijoConsecutivoRepository.GetDataTableCorrespondencia_PrefijoConsecutivo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Correspondencia_PrefijoConsecutivo, bool>> srchByFunc = null;
            Expression<Func<Correspondencia_PrefijoConsecutivo, string>> orderByFunc = null;
            Expression<Func<Correspondencia_PrefijoConsecutivo, int>> orderByIntFunc = null;

            Expression<Func<Correspondencia_PrefijoConsecutivo, object>> parameter4 = d => d.Objdependencia;

            Expression<Func<Correspondencia_PrefijoConsecutivo, object>>[] parameterArray = new Expression<Func<Correspondencia_PrefijoConsecutivo, object>>[] {parameter4, };
            bool isOrderDesc = false;


            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmprefijo.ToLower().Contains(model.SearchValue.ToLower()) || d.prefijo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn == "id_prefijoconsecutivo")
            {
                orderByIntFunc = CreateExpressionOrderByInt<Correspondencia_PrefijoConsecutivo>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<Correspondencia_PrefijoConsecutivo>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<Correspondencia_PrefijoConsecutivo> data = null;
            
            if (model.SortColumn == "id_prefijoconsecutivo")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc,  orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Correspondencia_PrefijoConsecutivo> result = new DataTableAdapter<Correspondencia_PrefijoConsecutivo>();

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