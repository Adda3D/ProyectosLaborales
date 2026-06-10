using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Models.UGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.UGI
{
    public class UGI_ConceptoSemestreRepository : SuperType<UGI_ConceptoSemestre>
    {
        private ApplicationDbContext _context;

        public UGI_ConceptoSemestreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UGI_ConceptoSemestreRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<UGI_ConceptoSemestre> GetAllUGI_ConceptoSemestre()
        {
            return Get();
        }
        public UGI_ConceptoSemestre GetUGI_ConceptoSemestreDetails(int id_ugiconceptosemestre)
        {
            return Get(id_ugiconceptosemestre);
        }
        public bool InsertUGI_ConceptoSemestre (UGI_ConceptoSemestre uGI_ConceptoSemestre)
        {
            Add(uGI_ConceptoSemestre);
            return true;
        }
        public bool UpdateUGI_ConceptoSemestre(UGI_ConceptoSemestre uGI_ConceptoSemestre)
        {
            Update(uGI_ConceptoSemestre);
            return true;
        }
        public bool DeleteUGI_ConceptoSemestre(int id_ugiconceptosemestre)
        {
            Delete(id_ugiconceptosemestre);
            return true;
        }
        public DataTableAdapter<UGI_ConceptoSemestre> GetDataTableUGI_ConceptoSemestreBySemestre(int id_ugiliteralsemestre, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<UGI_ConceptoSemestre, bool>> srchByFunc = null;
            Expression<Func<UGI_ConceptoSemestre, int>> orderByFunc = null;
            Expression<Func<UGI_ConceptoSemestre, object>> parameter1 = p => p.Objugisemestre.Objsemestre;
            Expression<Func<UGI_ConceptoSemestre, object>> parameter2 = p => p.Objliteralsemestre.Objliteral;
            Expression<Func<UGI_ConceptoSemestre, object>> parameter3 = p => p.Objconcepto;

            Expression<Func<UGI_ConceptoSemestre, object>>[] parameterArray = new Expression<Func<UGI_ConceptoSemestre, object>>[] { parameter1, parameter2, parameter3, };
            bool isOrderDesc = false;

            //FILTRA POR Ciclo Financiero
            srchByFunc = d => d.id_ugiliteralsemestre == id_ugiliteralsemestre;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_ugiliteralsemestre == id_ugiliteralsemestre && d.NombreLiteralSemestre.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<UGI_ConceptoSemestre>("id_ugiconceptosemestre");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<UGI_ConceptoSemestre> result = new DataTableAdapter<UGI_ConceptoSemestre>();

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