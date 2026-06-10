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
    public class MatrizFinanciera_VigenciaRepository : SuperType<MatrizFinanciera_Vigencia>
    {
        private ApplicationDbContext _context;

        public MatrizFinanciera_VigenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MatrizFinanciera_VigenciaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MatrizFinanciera_Vigencia> GetAllMatrizFinanciera_Vigencia()
        {
            return Get();
        }
        public MatrizFinanciera_Vigencia GetMatrizFinanciera_VigenciaDetails(int id_vigencia)
        {
            return Get(id_vigencia);
        }
        public MatrizFinanciera_Vigencia GetMatrizFinanciera_VigenciaNombre(string cd_nmvigencia)
        {
            return Get(c => c.nmvigencia == cd_nmvigencia).FirstOrDefault();
        }
        public bool InsertMatrizFinanciera_Vigencia(MatrizFinanciera_Vigencia matrizFinanciera_Vigencia)
        {
            Add(matrizFinanciera_Vigencia);
            return true;
        }
        public bool UpdateMatrizFinanciera_Vigencia(MatrizFinanciera_Vigencia matrizFinanciera_Vigencia)
        {
            Update(matrizFinanciera_Vigencia);
            return true;
        }
        public bool DeleteMatrizFinanciera_Vigencia(int id_vigencia)
        {
            Delete(id_vigencia);
            return true;
        }
        public DataTableAdapter<MatrizFinanciera_Vigencia> GetDataTableMatrizFinanciera_Vigencia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<MatrizFinanciera_Vigencia, bool>> srchByFunc = null;
            Expression<Func<MatrizFinanciera_Vigencia, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmvigencia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<MatrizFinanciera_Vigencia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<MatrizFinanciera_Vigencia> result = new DataTableAdapter<MatrizFinanciera_Vigencia>();

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