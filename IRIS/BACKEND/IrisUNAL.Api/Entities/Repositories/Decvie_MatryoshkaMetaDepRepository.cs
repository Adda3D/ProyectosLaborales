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
    public class Decvie_MatryoshkaMetaDepRepository : SuperType<Decvie_MatryoshkaMetaDep>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaMetaDepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaMetaDepRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaMetaDep> GetAllDecvie_MatryoshkaMetaDep()
        {
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter3 = p => p.Objnombremeta;

            Expression<Func<Decvie_MatryoshkaMetaDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaMetaDep, object>>[] { parameter3, };

            return Get(parameterArray);
        }

        public Decvie_MatryoshkaMetaDep GetDecvie_MatryoshkaMetaDepDetails(int id_matryoshkametadep)
        {
            return Get(id_matryoshkametadep);
        }

        public bool InsertDecvie_MatryoshkaMetaDep(Decvie_MatryoshkaMetaDep decvie_MatryoshkaMetaDep)
        {
            Add(decvie_MatryoshkaMetaDep);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaMetaDep(Decvie_MatryoshkaMetaDep decvie_MatryoshkaMetaDep)
        {
            Update(decvie_MatryoshkaMetaDep);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaMetaDep(int id_matryoshkametadep)
        {
            Delete(id_matryoshkametadep);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaMetaDep> GetDataTableDecvie_MatryoshkaMetaDep(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaMetaDep, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaMetaDep, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter2 = p => p.Objobjetivodep;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter3 = p => p.Objnombremeta;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaMetaDep, object>>[] { parameter1, parameter2, parameter3, };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaMetaDep>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaMetaDep> result = new DataTableAdapter<Decvie_MatryoshkaMetaDep>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaMetaDep> GetDataTableDecvie_MatryoshkaMetaDepByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaMetaDep, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaMetaDep, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter2 = p => p.Objobjetivodep.Objobjetivodep;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>> parameter3 = p => p.Objnombremeta;
            Expression<Func<Decvie_MatryoshkaMetaDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaMetaDep, object>>[] { parameter1, parameter2, parameter3, };
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

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaMetaDep>("id_matryoshkametadep");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaMetaDep> result = new DataTableAdapter<Decvie_MatryoshkaMetaDep>();

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