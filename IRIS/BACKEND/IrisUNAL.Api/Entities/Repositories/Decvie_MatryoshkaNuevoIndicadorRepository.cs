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
    public class Decvie_MatryoshkaNuevoIndicadorRepository : SuperType<Decvie_MatryoshkaNuevoIndicador>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaNuevoIndicadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaNuevoIndicadorRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaNuevoIndicador> GetAllDecvie_MatryoshkaNuevoIndicador()
        {
            
            return Get();
        }

        public Decvie_MatryoshkaNuevoIndicador GetDecvie_MatryoshkaNuevoIndicadorDetails(int id_matryoshkanuevoindicador)
        {
            return Get(id_matryoshkanuevoindicador);
        }

        public bool InsertDecvie_MatryoshkaNuevoIndicador(Decvie_MatryoshkaNuevoIndicador decvie_MatryoshkaNuevoIndicador )
        {
            Add(decvie_MatryoshkaNuevoIndicador);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaNuevoIndicador(Decvie_MatryoshkaNuevoIndicador decvie_MatryoshkaNuevoIndicador)
        {
            Update(decvie_MatryoshkaNuevoIndicador);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaNuevoIndicador(int id_matryoshkanuevoindicador)
        {
            Delete(id_matryoshkanuevoindicador);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaNuevoIndicador> GetDataTableDecvie_MatryoshkaNuevoIndicador(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaNuevoIndicador, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter2 = p => p.Objobjetivodep;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter3 = p => p.Objnuevosindicadores;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter4 = p => p.Objtipoindicador;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>>[] { parameter1, parameter2, parameter3, parameter4 };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaNuevoIndicador>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaNuevoIndicador> result = new DataTableAdapter<Decvie_MatryoshkaNuevoIndicador>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaNuevoIndicador> GetDataTableDecvie_MatryoshkaNuevoIndicadorByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaNuevoIndicador, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter2 = p => p.Objobjetivodep.Objobjetivodep;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter3 = p => p.Objnuevosindicadores;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>> parameter4 = p => p.Objtipoindicador;
            Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaNuevoIndicador, object>>[] { parameter1, parameter2, parameter3, parameter4 };
            bool isOrderDesc = false;

            //FILTRA POR DEPENDENCIA
            srchByFunc = d => d.id_matryoska == id_matryoska;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_matryoska == id_matryoska && d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaNuevoIndicador>("id_matryoshkanuevoindicador");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaNuevoIndicador> result = new DataTableAdapter<Decvie_MatryoshkaNuevoIndicador>();

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