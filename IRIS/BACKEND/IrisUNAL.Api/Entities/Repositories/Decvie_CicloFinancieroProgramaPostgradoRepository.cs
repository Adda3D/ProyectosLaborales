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
    public class Decvie_CicloFinancieroProgramaPostgradoRepository : SuperType<Decvie_CicloFinancieroProgramaPostgrado> 
    {
        private ApplicationDbContext _context;

        public Decvie_CicloFinancieroProgramaPostgradoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_CicloFinancieroProgramaPostgradoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_CicloFinancieroProgramaPostgrado> GetAllDecvie_CicloFinancieroProgramaPostgrado()
        {
            return Get();
        }

        public Decvie_CicloFinancieroProgramaPostgrado GetDecvie_CicloFinancieroProgramaPostgradoDetails(int id_programapostgrado)
        {
            return Get(id_programapostgrado);
        }

        public bool InsertDecvie_CicloFinancieroProgramaPostgrado(Decvie_CicloFinancieroProgramaPostgrado decvie_CicloFinancieroProgramaPostgrado)
        {
            Add(decvie_CicloFinancieroProgramaPostgrado);
            return true;
        }

        public bool UpdateDecvie_CicloFinancieroProgramaPostgrado(Decvie_CicloFinancieroProgramaPostgrado decvie_CicloFinancieroProgramaPostgrado)
        {
            Update(decvie_CicloFinancieroProgramaPostgrado);
            return true;
        }

        public bool DeleteDecvie_CicloFinancieroProgramaPostgrado(int id_programapostgrado)
        {
            Delete(id_programapostgrado);
            return true;
        }

        public DataTableAdapter<Decvie_CicloFinancieroProgramaPostgrado> GetDataTableDecvie_CicloFinancieroProgramaPostgrado(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_CicloFinancieroProgramaPostgrado, bool>> srchByFunc = null;
            Expression<Func<Decvie_CicloFinancieroProgramaPostgrado, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmprogramapostgrado.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_CicloFinancieroProgramaPostgrado>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_CicloFinancieroProgramaPostgrado> result = new DataTableAdapter<Decvie_CicloFinancieroProgramaPostgrado>();

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