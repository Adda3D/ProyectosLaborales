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
    public class Decvie_MatryoshkaObjetivoDepRepository : SuperType<Decvie_MatryoshkaObjetivoDep>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaObjetivoDepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaObjetivoDepRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaObjetivoDep> GetAllDecvie_MatryoshkaObjetivoDep()
        {
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>> parameter2 = p => p.Objobjetivodep;

            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaObjetivoDep, object>>[] { parameter1, parameter2, };

            return Get(parameterArray);
        }

        public Decvie_MatryoshkaObjetivoDep GetDecvie_MatryoshkaObjetivoDepDetails(int id_matryoshkaobjetivodep)
        {
            return Get(id_matryoshkaobjetivodep);
        }

        public bool InsertDecvie_MatryoshkaObjetivoDep(Decvie_MatryoshkaObjetivoDep decvie_MatryoshkaObjetivoDep )
        {
            Add(decvie_MatryoshkaObjetivoDep);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaObjetivoDep(Decvie_MatryoshkaObjetivoDep decvie_MatryoshkaObjetivoDep )
        {
            Update(decvie_MatryoshkaObjetivoDep);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaObjetivoDep(int id_matryoshkaobjetivodep)
        {
            Delete(id_matryoshkaobjetivodep);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaObjetivoDep> GetDataTableDecvie_MatryoshkaObjetivoDep(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaObjetivoDep, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>> parameter2 = p => p.Objobjetivodep;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaObjetivoDep, object>>[] { parameter1, parameter2 };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaObjetivoDep>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaObjetivoDep> result = new DataTableAdapter<Decvie_MatryoshkaObjetivoDep>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaObjetivoDep> GetDataTableDecvie_MatryoshkaObjetivoDepByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaObjetivoDep, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>> parameter2 = p => p.Objobjetivodep;
            
            Expression<Func<Decvie_MatryoshkaObjetivoDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaObjetivoDep, object>>[] { parameter1, parameter2, };
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

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaObjetivoDep>("id_matryoshkaobjetivodep");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaObjetivoDep> result = new DataTableAdapter<Decvie_MatryoshkaObjetivoDep>();

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