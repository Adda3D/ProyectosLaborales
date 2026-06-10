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
    public class Decvie_MatryoshkaEjeEstrategicoRepository: SuperType<Decvie_MatryoshkaEjeEstrategico>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaEjeEstrategicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaEjeEstrategicoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaEjeEstrategico> GetAllDecvie_MatryoshkaEjeEstrategico()
        {
            return Get();
        }

        public Decvie_MatryoshkaEjeEstrategico GetDecvie_MatryoshkaEjeEstrategicoDetails(int id_matryoshkaejeestrategico)
        {
            return Get(id_matryoshkaejeestrategico);
        }

        public bool InsertDecvie_MatryoshkaEjeEstrategico(Decvie_MatryoshkaEjeEstrategico decvie_MatryoshkaEjeEstrategico)
        {
            Add(decvie_MatryoshkaEjeEstrategico);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaEjeEstrategico(Decvie_MatryoshkaEjeEstrategico decvie_MatryoshkaEjeEstrategico)
        {
            Update(decvie_MatryoshkaEjeEstrategico);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaEjeEstrategico(int id_matryoshkaejeestrategico)
        {
            Delete(id_matryoshkaejeestrategico);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaEjeEstrategico> GetDataTableDecvie_MatryoshkaEjeEstrategico(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaEjeEstrategico, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>> parameter2 = p => p.Objejeestrategico;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>>[] { parameter1, parameter2 };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaEjeEstrategico>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaEjeEstrategico> result = new DataTableAdapter<Decvie_MatryoshkaEjeEstrategico>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaEjeEstrategico> GetDataTableDecvie_MatryoshkaEjeEstrategicoByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaEjeEstrategico, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>> parameter2 = p => p.Objejeestrategico;
            Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaEjeEstrategico, object>>[] { parameter1, parameter2 };
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

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaEjeEstrategico>("id_matryoshkaejeestrategico");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaEjeEstrategico> result = new DataTableAdapter<Decvie_MatryoshkaEjeEstrategico>();

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