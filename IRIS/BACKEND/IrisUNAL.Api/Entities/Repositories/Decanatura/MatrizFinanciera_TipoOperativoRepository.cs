using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Decanatura;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Decanatura
{
    public class MatrizFinanciera_TipoOperativoRepository : SuperType<MatrizFinanciera_TipoOperativo>
    {
        private ApplicationDbContext _context;

        public MatrizFinanciera_TipoOperativoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MatrizFinanciera_TipoOperativoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MatrizFinanciera_TipoOperativo> GetAllMatrizFinanciera_TipoOperativo()
        {
            return Get();
        }
        public MatrizFinanciera_TipoOperativo GetMatrizFinanciera_TipoOperativoDetails(int id_tipooperativo)
        {
            return Get(id_tipooperativo);
        }
        public MatrizFinanciera_TipoOperativo GetMatrizFinanciera_TipoOperativoNombre(string cd_nmtipooperativo)
        {
            return Get(c => c.nmtipooperativo == cd_nmtipooperativo).FirstOrDefault();
        }
        public bool InsertMatrizFinanciera_TipoOperativo(MatrizFinanciera_TipoOperativo matrizFinanciera_TipoOperativo)
        {
            Add(matrizFinanciera_TipoOperativo);
            return true;
        }
        public bool UpdateMatrizFinanciera_TipoOperativo(MatrizFinanciera_TipoOperativo matrizFinanciera_TipoOperativo)
        {
            Update(matrizFinanciera_TipoOperativo);
            return true;
        }
        public bool DeleteMatrizFinanciera_TipoOperativo(int id_tipooperativo)
        {
            Delete(id_tipooperativo);
            return true;
        }
        
        public DataTableAdapter<MatrizFinanciera_TipoOperativo> GetDataTableMatrizFinanciera_TipoOperativo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            
            Expression<Func<MatrizFinanciera_TipoOperativo, bool>> srchByFunc = null;
            Expression<Func<MatrizFinanciera_TipoOperativo, string>> orderByFunc = null;
            Expression<Func<MatrizFinanciera_TipoOperativo, int>> orderByIntFunc = null;

            Expression<Func<MatrizFinanciera_TipoOperativo, object>>[] parameterArray = new Expression<Func<MatrizFinanciera_TipoOperativo, object>>[] {};

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipooperativo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
            
            if (model.SortColumn == "id_tipooperativo")
            {
                orderByIntFunc = CreateExpressionOrderByInt<MatrizFinanciera_TipoOperativo>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<MatrizFinanciera_TipoOperativo>(model.SortColumn);
            }
            
            List<MatrizFinanciera_TipoOperativo> data = null;
            
            if (model.SortColumn == "id_tipooperativo")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<MatrizFinanciera_TipoOperativo> result = new DataTableAdapter<MatrizFinanciera_TipoOperativo>();

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