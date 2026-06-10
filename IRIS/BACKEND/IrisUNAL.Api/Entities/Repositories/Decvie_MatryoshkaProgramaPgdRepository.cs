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
    public class Decvie_MatryoshkaProgramaPgdRepository : SuperType<Decvie_MatryoshkaProgramaPgd>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaProgramaPgdRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaProgramaPgdRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaProgramaPgd> GetAllDecvie_MatryoshkaProgramaPgd()
        {
            return Get();
        }

        public Decvie_MatryoshkaProgramaPgd GetDecvie_MatryoshkaProgramaPgdDetails(int id_matryoshkaprogramapgd)
        {
            return Get(id_matryoshkaprogramapgd);
        }

        public bool InsertDecvie_MatryoshkaProgramaPgd(Decvie_MatryoshkaProgramaPgd decvie_MatryoshkaProgramaPgd )
        {
            Add(decvie_MatryoshkaProgramaPgd);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaProgramaPgd(Decvie_MatryoshkaProgramaPgd decvie_MatryoshkaProgramaPgd)
        {
            Update(decvie_MatryoshkaProgramaPgd);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaProgramaPgd(int id_matryoshkaprogramapgd)
        {
            Delete(id_matryoshkaprogramapgd);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaProgramaPgd> GetDataTableDecvie_MatryoshkaProgramaPgd(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaProgramaPgd, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, object>> parameter2 = p => p.Objprogramapgd;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaProgramaPgd, object>>[] { parameter1, parameter2 };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaProgramaPgd>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaProgramaPgd> result = new DataTableAdapter<Decvie_MatryoshkaProgramaPgd>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaProgramaPgd> GetDataTableDecvie_MatryoshkaProgramaPgdByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaProgramaPgd, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, object>> parameter2 = p => p.Objprogramapgd;
            Expression<Func<Decvie_MatryoshkaProgramaPgd, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaProgramaPgd, object>>[] { parameter1, parameter2 };
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

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaProgramaPgd>("id_matryoshkaprogramapgd");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaProgramaPgd> result = new DataTableAdapter<Decvie_MatryoshkaProgramaPgd>();

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