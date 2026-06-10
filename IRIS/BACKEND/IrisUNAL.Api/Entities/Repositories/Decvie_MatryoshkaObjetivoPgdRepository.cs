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
    public class Decvie_MatryoshkaObjetivoPgdRepository : SuperType<Decvie_MatryoshkaObjetivoPgd>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaObjetivoPgdRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaObjetivoPgdRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaObjetivoPgd> GetAllDecvie_MatryoshkaObjetivoPgd()
        {
            return Get();
        }        

        public Decvie_MatryoshkaObjetivoPgd GetDecvie_MatryoshkaObjetivoPgdDetails(int id_matryoshkaobjetivopgd)
        {
            return Get(id_matryoshkaobjetivopgd);
        }

        public bool InsertDecvie_MatryoshkaObjetivoPgd(Decvie_MatryoshkaObjetivoPgd decvie_MatryoshkaObjetivoPgd)
        {
            Add(decvie_MatryoshkaObjetivoPgd);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaObjetivoPgd(Decvie_MatryoshkaObjetivoPgd decvie_MatryoshkaObjetivoPgd )
        {
            Update(decvie_MatryoshkaObjetivoPgd);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaObjetivoPgd(int id_matryoshkaobjetivopgd)
        {
            Delete(id_matryoshkaobjetivopgd);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaObjetivoPgd> GetDataTableDecvie_MatryoshkaObjetivoPgd(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaObjetivoPgd, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>> parameter2 = p => p.Objmatryoshkaestrategia;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>> parameter3 = p => p.Objobjetivopgdvri;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>>[] { parameter1, parameter2, parameter3, };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaObjetivoPgd>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaObjetivoPgd> result = new DataTableAdapter<Decvie_MatryoshkaObjetivoPgd>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaObjetivoPgd> GetDataTableDecvie_MatryoshkaObjetivoPgdByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaObjetivoPgd, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>> parameter2 = p => p.Objmatryoshkaestrategia;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>> parameter3 = p => p.Objobjetivopgdvri;
            Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaObjetivoPgd, object>>[] { parameter1, parameter2, parameter3, };
            bool isOrderDesc = false;

            //FILTRA POR DEPENDENCIA
            srchByFunc = d => d.id_matryoska == id_matryoska;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_matryoska == id_matryoska && d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaObjetivoPgd>("id_matryoshkaobjetivopgd");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaObjetivoPgd> result = new DataTableAdapter<Decvie_MatryoshkaObjetivoPgd>();

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