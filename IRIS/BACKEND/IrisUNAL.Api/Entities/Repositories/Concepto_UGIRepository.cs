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
    public class Concepto_UGIRepository : SuperType<Concepto_UGI>,IConcepto_UGIRepository
    {
        private ApplicationDbContext _context;

        public Concepto_UGIRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Concepto_UGIRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteConcepto_UGI(int id_conceptougi)
        {
            Delete(id_conceptougi);
            return true;
        }
        public IEnumerable<Concepto_UGI> GetAllConcepto_UGI()
        {
            return Get();
        }
        public Concepto_UGI GetConcepto_UGIDetails(int id_conceptougi)
        {
            return Get(id_conceptougi);
        }
        public Concepto_UGI GetConcepto_UGINombre(string cd_concepto)
        {
            return Get(c => c.concepto == cd_concepto).FirstOrDefault();
        }
        public bool InsertConcepto_UGI(Concepto_UGI concepto_UGI)
        {

            Add(concepto_UGI);
            return true;
        }
        public bool UpdateConcepto_UGI(Concepto_UGI concepto_UGI)
        {
            Update(concepto_UGI);
            return true;

        }

        DataTableAdapter<Concepto_UGI> IConcepto_UGIRepository.GetDataTableConcepto_UGI(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Concepto_UGI, bool>> srchByFunc = null;
            Expression<Func<Concepto_UGI, string>> orderByFunc = null;

          //  Expression<Func<Concepto_UGI, object>> parameter1 = p => p.literal;
            Expression<Func<Concepto_UGI, object>>[] parameterArray = new Expression<Func<Concepto_UGI, object>>[] {};

            bool isOrderDesc = false;                     

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.concepto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Concepto_UGI>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Concepto_UGI> result = new DataTableAdapter<Concepto_UGI>();

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