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
    public class Decvie_MatryoshkaActividadDepRepository : SuperType<Decvie_MatryoshkaActividadDep>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaActividadDepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaActividadDepRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaActividadDep> GetAllDecvie_MatryoshkaActividadDep()
        {
            return Get();
        }

        public Decvie_MatryoshkaActividadDep GetDecvie_MatryoshkaActividadDepDetails(int id_matryoshkaactividaddep)
        {
            return Get(id_matryoshkaactividaddep);
        }

        public bool InsertDecvie_MatryoshkaActividadDep(Decvie_MatryoshkaActividadDep decvie_MatryoshkaActividadDep)
        {
            Add(decvie_MatryoshkaActividadDep);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaActividadDep(Decvie_MatryoshkaActividadDep decvie_MatryoshkaActividadDep)
        {
            Update(decvie_MatryoshkaActividadDep);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaActividadDep(int id_matryoshkaactividaddep)
        {
            Delete(id_matryoshkaactividaddep);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaActividadDep> GetDataTableDecvie_MatryoshkaActividadDep(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaActividadDep, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaActividadDep, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>> parameter2 = p => p.Objmetadep.Objnombremeta;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>> parameter3 = p => p.Objactividades;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaActividadDep, object>>[] { parameter1, parameter2, parameter3, };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaActividadDep>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaActividadDep> result = new DataTableAdapter<Decvie_MatryoshkaActividadDep>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaActividadDep> GetDataTableDecvie_MatryoshkaActividadDepByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaActividadDep, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaActividadDep, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>> parameter2 = p => p.Objmetadep.Objnombremeta;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>> parameter3 = p => p.Objactividades;
            Expression<Func<Decvie_MatryoshkaActividadDep, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaActividadDep, object>>[] { parameter1, parameter2, parameter3, };
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

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaActividadDep>("id_matryoshkaactividaddep");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaActividadDep> result = new DataTableAdapter<Decvie_MatryoshkaActividadDep>();

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