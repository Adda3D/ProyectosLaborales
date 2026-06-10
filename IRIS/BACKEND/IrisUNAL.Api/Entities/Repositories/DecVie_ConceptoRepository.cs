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
    public class DecVie_ConceptoRepository : SuperType<DecVie_Concepto>, IDecVie_ConceptoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ConceptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ConceptoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Concepto(int id_decvieconcepto)
        {
            Delete(id_decvieconcepto);
            return true;
        }

        public IEnumerable<DecVie_Concepto> GetAllDecVie_Concepto()
        {
            return Get ();
        }

        public DecVie_Concepto GetDecVie_ConceptoDetails(int id_decvieconcepto)
        {
            return Get(id_decvieconcepto);
        }

        public DecVie_Concepto GetDecVie_ConceptoNombre(string cd_nmconcepto)
        {
            return Get(c => c.nmconcepto == cd_nmconcepto).FirstOrDefault();
        }

        public bool InsertDecVie_Concepto(DecVie_Concepto decVie_Concepto)
        {
            Add(decVie_Concepto);
            return true;
        }

        public bool UpdateDecVie_Concepto(DecVie_Concepto decVie_Concepto)
        {
            Update(decVie_Concepto);
            return true;
        }
        DataTableAdapter<DecVie_Concepto> IDecVie_ConceptoRepository.GetDataTableDecVie_Concepto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Concepto, bool>> srchByFunc = null;
            Expression<Func<DecVie_Concepto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmconcepto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Concepto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Concepto> result = new DataTableAdapter<DecVie_Concepto>();

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