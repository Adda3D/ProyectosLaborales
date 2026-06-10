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
    public class Literal_UGIRepository : SuperType<Literal_UGI>, ILiteral_UGIRepository
    {
        private ApplicationDbContext _context;

        public Literal_UGIRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Literal_UGIRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteLiteral_UGI(int id_literal)
        {
            Delete(id_literal);
            return true;
        }

        public IEnumerable<Literal_UGI> GetAllLiteral_UGI()
        {
            return Get();            
        }

        public Literal_UGI GetLiteral_UGIDetails(int id_literal)
        {
            return Get(id_literal);            
        }

        public Literal_UGI GetLiteral_UGINombre(string cd_nmliteral)
        {
            return Get(c => c.nmliteral == cd_nmliteral).FirstOrDefault();            
        }

        public bool InsertLiteral_UGI(Literal_UGI literal_UGI)
        {
            Add(literal_UGI);
            return true;
        }

        public bool UpdateLiteral_UGI(Literal_UGI literal_UGI)
        {
            Update(literal_UGI);
            return true;
        }
        DataTableAdapter<Literal_UGI> ILiteral_UGIRepository.GetDataTableLiteral_UGI(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Literal_UGI, bool>> srchByFunc = null;
            Expression<Func<Literal_UGI, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmliteral.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Literal_UGI>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Literal_UGI> result = new DataTableAdapter<Literal_UGI>();

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