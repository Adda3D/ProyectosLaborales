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
    public class Decvie_MatryoshkaEstrategiaRepository : SuperType<Decvie_MatryoshkaEstrategia>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaEstrategiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaEstrategiaRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaEstrategia> GetAllDecvie_MatryoshkaEstrategia()
        {
            return Get();
        }

        public Decvie_MatryoshkaEstrategia GetDecvie_MatryoshkaEstrategiaDetails(int id_matryoshkaestrategia)
        {
            return Get(id_matryoshkaestrategia);
        }

        public bool InsertDecvie_MatryoshkaEstrategia(Decvie_MatryoshkaEstrategia decvie_MatryoshkaEstrategia)
        {
            Add(decvie_MatryoshkaEstrategia);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaEstrategia(Decvie_MatryoshkaEstrategia decvie_MatryoshkaEstrategia)
        {
            Update(decvie_MatryoshkaEstrategia);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaEstrategia(int id_matryoshkaestrategia)
        {
            Delete(id_matryoshkaestrategia);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaEstrategia> GetDataTableDecvie_MatryoshkaEstrategia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaEstrategia, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaEstrategia, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaEstrategia, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaEstrategia, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaEstrategia, object>>[] { parameter1,};
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.estrategia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaEstrategia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaEstrategia> result = new DataTableAdapter<Decvie_MatryoshkaEstrategia>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaEstrategia> GetDataTableDecvie_MatryoshkaEstrategiaByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaEstrategia, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaEstrategia, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaEstrategia, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaEstrategia, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaEstrategia, object>>[] { parameter1,};
            bool isOrderDesc = false;

            //FILTRA POR DEPENDENCIA
            srchByFunc = d => d.id_matryoska == id_matryoska;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_matryoska == id_matryoska && d.estrategia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaEstrategia>("id_matryoshkaestrategia");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaEstrategia> result = new DataTableAdapter<Decvie_MatryoshkaEstrategia>();

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