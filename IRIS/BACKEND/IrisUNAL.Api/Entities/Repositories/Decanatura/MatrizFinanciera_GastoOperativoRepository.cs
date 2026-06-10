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
    public class MatrizFinanciera_GastoOperativoRepository : SuperType<MatrizFinanciera_GastoOperativo>
    {
        private ApplicationDbContext _context;

        public MatrizFinanciera_GastoOperativoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MatrizFinanciera_GastoOperativoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MatrizFinanciera_GastoOperativo> GetAllMatrizFinanciera_GastoOperativo()
        {
            return Get();
        }
        public MatrizFinanciera_GastoOperativo GetMatrizFinanciera_GastoOperativoDetails(int id_gastooperativo)
        {
            return Get(id_gastooperativo);
        }
        public bool InsertMatrizFinanciera_GastoOperativo(MatrizFinanciera_GastoOperativo matrizFinanciera_GastoOperativo)
        {
            Add(matrizFinanciera_GastoOperativo);
            return true;
        }
        public bool UpdateMatrizFinanciera_GastoOperativo(MatrizFinanciera_GastoOperativo matrizFinanciera_GastoOperativo)
        {
            Update(matrizFinanciera_GastoOperativo);
            return true;
        }
        public bool DeleteMatrizFinanciera_GastoOperativo(int id_gastooperativo)
        {
            Delete(id_gastooperativo);
            return true;
        }
        public DataTableAdapter<MatrizFinanciera_GastoOperativo> GetDataTableMatrizFinanciera_GastoOperativoByMatriz(int id_matrizfinanciera, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<MatrizFinanciera_GastoOperativo, bool>> srchByFunc = null;
            Expression<Func<MatrizFinanciera_GastoOperativo, int>> orderByFunc = null;
            Expression<Func<MatrizFinanciera_GastoOperativo, object>> parameter1 = p => p.Objdependencia;
            Expression<Func<MatrizFinanciera_GastoOperativo, object>> parameter2 = p => p.Objmatrizfinanciera.Objvigencia;
            Expression<Func<MatrizFinanciera_GastoOperativo, object>> parameter3 = p => p.Objtipooperativo;

            Expression<Func<MatrizFinanciera_GastoOperativo, object>>[] parameterArray = new Expression<Func<MatrizFinanciera_GastoOperativo, object>>[] { parameter1, parameter2, parameter3,};
            bool isOrderDesc = false;

            //FILTRA POR Vigencia
            srchByFunc = d => d.id_matrizfinanciera == id_matrizfinanciera;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_matrizfinanciera == id_matrizfinanciera && d.Objtipooperativo.nmtipooperativo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<MatrizFinanciera_GastoOperativo>("id_gastooperativo");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<MatrizFinanciera_GastoOperativo> result = new DataTableAdapter<MatrizFinanciera_GastoOperativo>();

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