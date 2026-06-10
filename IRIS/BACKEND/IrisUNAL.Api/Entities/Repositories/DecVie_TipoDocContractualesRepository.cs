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
    public class DecVie_TipoDocContractualesRepository : SuperType<DecVie_TipoDocContractuales>, IDecVie_TipoDocContractualesRepository
    {
        private ApplicationDbContext _context;

        public DecVie_TipoDocContractualesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_TipoDocContractualesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_TipoDocContractuales(int id_doccontractuales)
        {
            Delete(id_doccontractuales);
            return true;
        }

        public IEnumerable<DecVie_TipoDocContractuales> GetAllDecVie_TipoDocContractuales()
        {
            return Get();
        }

        public DecVie_TipoDocContractuales GetDecVie_TipoDocContractualesDetails(int id_doccontractuales)
        {
            return Get(id_doccontractuales);
        }

        public DecVie_TipoDocContractuales GetDecVie_TipoDocContractualesNombre(string cd_nmdoccontractuales)
        {
            return Get(c => c.nmdoccontractuales == cd_nmdoccontractuales).FirstOrDefault();
        }

        public bool InsertDecVie_TipoDocContractuales(DecVie_TipoDocContractuales decVie_TipoDocContractuales)
        {
            Add(decVie_TipoDocContractuales);
            return true;
        }

        public bool UpdateDecVie_TipoDocContractuales(DecVie_TipoDocContractuales decVie_TipoDocContractuales)
        {
            Update(decVie_TipoDocContractuales);
            return true;
        }
        public DataTableAdapter<DecVie_TipoDocContractuales> GetDataTableDecVie_TipoDocContractuales(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_TipoDocContractuales, bool>> srchByFunc = null;
            Expression<Func<DecVie_TipoDocContractuales, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdoccontractuales.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_TipoDocContractuales>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_TipoDocContractuales> result = new DataTableAdapter<DecVie_TipoDocContractuales>();

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