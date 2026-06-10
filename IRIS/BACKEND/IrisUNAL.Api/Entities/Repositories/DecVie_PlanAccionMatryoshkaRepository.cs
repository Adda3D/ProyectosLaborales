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
    public class DecVie_PlanAccionMatryoshkaRepository : SuperType<DecVie_PlanAccionMatryoshka>, IDecVie_PlanAccionMatryoshkaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionMatryoshkaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionMatryoshkaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionMatryoshka(int id_matryoshka)
        {

            Delete(id_matryoshka);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionMatryoshka> GetAllDecVie_PlanAccionMatryoshka()
        {
            return Get();
        }

        public DecVie_PlanAccionMatryoshka GetDecVie_PlanAccionMatryoshkaDetails(int id_matryoshka)
        {
            return Get(id_matryoshka);
        }

        public bool InsertDecVie_PlanAccionMatryoshka(DecVie_PlanAccionMatryoshka decVie_PlanAccionMatryoshka)
        {
            Add(decVie_PlanAccionMatryoshka);
            return true;
        }

        public bool UpdateDecVie_PlanAccionMatryoshka(DecVie_PlanAccionMatryoshka decVie_PlanAccionMatryoshka)
        {
            Update(decVie_PlanAccionMatryoshka);
            return true;
        }
        public DataTableAdapter<DecVie_PlanAccionMatryoshka> GetDataTableDecVie_PlanAccionMatryoshka(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            //Expression<Func<DecVie_PlanAccionMatryoshka, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_PlanAccionMatryoshka, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionMatryoshka, string>> orderByFunc = null;
            Expression<Func<DecVie_PlanAccionMatryoshka, int>> orderByIntFunc = null;

            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter1 = d => d.Objlineapolitica;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter2 = d => d.Objprogramapgd;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter3 = d => d.ObjObjetivoestrategico;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter4 = d => d.Objejeestrategico;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter5 = d => d.Objalcance;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter6 = d => d.Objdependencia;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter7 = d => d.Objobjetivopgdvrisede;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter8 = d => d.ObjObjetivoDependencia;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter9 = d => d.ObjMeta;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter10 = d => d.Objindicadoresestrategicos;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter11 = d => d.Objnuevosindicadores;
            Expression<Func<DecVie_PlanAccionMatryoshka, object>> parameter12 = d => d.Objtipoindicador;


            Expression<Func<DecVie_PlanAccionMatryoshka, object>>[] parameterArray = new Expression<Func<DecVie_PlanAccionMatryoshka, object>>[] { parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.procesosvsestrategias.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

           

            if (model.SortColumn == "id_matryoshka")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PlanAccionMatryoshka>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionMatryoshka>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PlanAccionMatryoshka> data = null;
            
            if (model.SortColumn == "id_matryoshka")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionMatryoshka> result = new DataTableAdapter<DecVie_PlanAccionMatryoshka>();

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