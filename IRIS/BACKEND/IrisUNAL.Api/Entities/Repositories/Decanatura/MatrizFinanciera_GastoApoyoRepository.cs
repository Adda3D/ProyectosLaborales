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
    public class MatrizFinanciera_GastoApoyoRepository : SuperType<MatrizFinanciera_GastoApoyo>
    {
        private ApplicationDbContext _context;

        public MatrizFinanciera_GastoApoyoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MatrizFinanciera_GastoApoyoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MatrizFinanciera_GastoApoyo> GetAllMatrizFinanciera_GastoApoyo()
        {
            return Get();
        }
        public MatrizFinanciera_GastoApoyo GetMatrizFinanciera_GastoApoyoDetails(int id_gastoapoyo)
        {
            return Get(id_gastoapoyo);
        }
        public bool InsertMatrizFinanciera_GastoApoyo(MatrizFinanciera_GastoApoyo matrizFinanciera_GastoApoyo)
        {
            Add(matrizFinanciera_GastoApoyo);
            return true;
        }
        public bool UpdateMatrizFinanciera_GastoApoyo(MatrizFinanciera_GastoApoyo matrizFinanciera_GastoApoyo)
        {
            Update(matrizFinanciera_GastoApoyo);
            return true;
        }
        public bool DeleteMatrizFinanciera_GastoApoyo(int id_gastoapoyo)
        {
            Delete(id_gastoapoyo);
            return true;
        }
        public DataTableAdapter<MatrizFinanciera_GastoApoyo> GetDataTableMatrizFinanciera_GastoApoyoByMatriz(int id_matrizfinanciera, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<MatrizFinanciera_GastoApoyo, bool>> srchByFunc = null;
            Expression<Func<MatrizFinanciera_GastoApoyo, int>> orderByFunc = null;
            Expression<Func<MatrizFinanciera_GastoApoyo, object>> parameter1 = p => p.Objdependencia;
            Expression<Func<MatrizFinanciera_GastoApoyo, object>> parameter2 = p => p.Objmatrizfinanciera.Objvigencia;

            Expression<Func<MatrizFinanciera_GastoApoyo, object>>[] parameterArray = new Expression<Func<MatrizFinanciera_GastoApoyo, object>>[] { parameter1, parameter2, };
            bool isOrderDesc = false;

            //FILTRA POR Vigencia
            srchByFunc = d => d.id_matrizfinanciera == id_matrizfinanciera;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.totalpersonascontratadas.ToString().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
                
            }

            orderByFunc = CreateExpressionOrderByInt<MatrizFinanciera_GastoApoyo>("id_gastoapoyo");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<MatrizFinanciera_GastoApoyo> result = new DataTableAdapter<MatrizFinanciera_GastoApoyo>();

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