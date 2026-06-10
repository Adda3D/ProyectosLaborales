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
    public class Decvie_MatryoshkaIndicadorEstrategicoRepository : SuperType<Decvie_MatryoshkaIndicadorEstrategico>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaIndicadorEstrategicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaIndicadorEstrategicoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_MatryoshkaIndicadorEstrategico> GetAllDecvie_MatryoshkaIndicadorEstrategico()
        {
            return Get();
        }

        public Decvie_MatryoshkaIndicadorEstrategico GetDecvie_MatryoshkaIndicadorEstrategicoDetails(int id_matryoshkaindicadorestrategico)
        {
            return Get(id_matryoshkaindicadorestrategico);
        }

        public bool InsertDecvie_MatryoshkaIndicadorEstrategico(Decvie_MatryoshkaIndicadorEstrategico decvie_MatryoshkaIndicadorEstrategico )
        {
            Add(decvie_MatryoshkaIndicadorEstrategico);
            return true;
        }

        public bool UpdateDecvie_MatryoshkaIndicadorEstrategico(Decvie_MatryoshkaIndicadorEstrategico decvie_MatryoshkaIndicadorEstrategico)
        {
            Update(decvie_MatryoshkaIndicadorEstrategico);
            return true;
        }

        public bool DeleteDecvie_MatryoshkaIndicadorEstrategico(int id_matryoshkaindicadorestrategico)
        {
            Delete(id_matryoshkaindicadorestrategico);
            return true;
        }

        public DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico> GetDataTableDecvie_MatryoshkaIndicadorEstrategico(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, string>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>> parameter2 = p => p.Objindicadoresestrategicos;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>>[] { parameter1, parameter2 };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_MatryoshkaIndicadorEstrategico>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico> result = new DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico> GetDataTableDecvie_MatryoshkaIndicadorEstrategicoByMatryohska(int id_matryoska, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, bool>> srchByFunc = null;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, int>> orderByFunc = null;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>> parameter1 = p => p.Objmatryoshka;
            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>> parameter2 = p => p.Objindicadoresestrategicos;

            Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>>[] parameterArray = new Expression<Func<Decvie_MatryoshkaIndicadorEstrategico, object>>[] { parameter1, parameter2, };
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

            orderByFunc = CreateExpressionOrderByInt<Decvie_MatryoshkaIndicadorEstrategico>("id_matryoshkaindicadorestrategico");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico> result = new DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico>();

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