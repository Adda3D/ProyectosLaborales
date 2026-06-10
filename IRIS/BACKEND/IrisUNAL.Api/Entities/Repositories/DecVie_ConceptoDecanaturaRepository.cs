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
    public class DecVie_ConceptoDecanaturaRepository : SuperType<DecVie_ConceptoDecanatura>, IDecVie_ConceptoDecanaturaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ConceptoDecanaturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ConceptoDecanaturaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_ConceptoDecanatura(int id_conceptodecanatura)
        {
            Delete(id_conceptodecanatura);
            return true;
        }

        public IEnumerable<DecVie_ConceptoDecanatura> GetAllDecVie_ConceptoDecanatura()
        {
            return Get();
        }

        public DecVie_ConceptoDecanatura GetDecVie_ConceptoDecanaturaDetails(int id_conceptodecanatura)
        {
            return Get(id_conceptodecanatura);
        }

        public DecVie_ConceptoDecanatura GetDecVie_ConceptoDecanaturaNombre(string cd_nmconceptodecanatura)
        {
            return Get(c => c.nmconceptodecanatura == cd_nmconceptodecanatura).FirstOrDefault();
        }

        public bool InsertDecVie_ConceptoDecanatura(DecVie_ConceptoDecanatura decVie_ConceptoDecanatura)
        {
            Add(decVie_ConceptoDecanatura);
            return true;
        }

        public bool UpdateDecVie_ConceptoDecanatura(DecVie_ConceptoDecanatura decVie_ConceptoDecanatura)
        {
            Update(decVie_ConceptoDecanatura);
            return true;
        }
        DataTableAdapter<DecVie_ConceptoDecanatura> IDecVie_ConceptoDecanaturaRepository.GetDataTableDecVie_ConceptoDecanatura(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_ConceptoDecanatura, bool>> srchByFunc = null;
            Expression<Func<DecVie_ConceptoDecanatura, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmconceptodecanatura.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_ConceptoDecanatura>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_ConceptoDecanatura> result = new DataTableAdapter<DecVie_ConceptoDecanatura>();

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