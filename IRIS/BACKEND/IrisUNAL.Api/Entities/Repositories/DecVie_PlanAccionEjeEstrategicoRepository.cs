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
    public class DecVie_PlanAccionEjeEstrategicoRepository : SuperType<DecVie_PlanAccionEjeEstrategico>, IDecVie_PlanAccionEjeEstrategicoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionEjeEstrategicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionEjeEstrategicoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionEjeEstrategico(int id_ejeestrategico)
        {
            Delete(id_ejeestrategico);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionEjeEstrategico> GetAllDecVie_PlanAccionEjeEstrategico()
        {
            return Get();
        }

        public DecVie_PlanAccionEjeEstrategico GetDecVie_PlanAccionEjeEstrategicoDetails(int id_ejeestrategico)
        {
            return Get(id_ejeestrategico);
        }

        public DecVie_PlanAccionEjeEstrategico GetDecVie_PlanAccionEjeEstrategicoNombre(string cd_ejeestrategico)
        {
            return Get(c => c.ejeestrategico == cd_ejeestrategico).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionEjeEstrategico(DecVie_PlanAccionEjeEstrategico decVie_PlanAccionEjeEstrategico)
        {
            Add(decVie_PlanAccionEjeEstrategico);
            return true;
        }

        public bool UpdateDecVie_PlanAccionEjeEstrategico(DecVie_PlanAccionEjeEstrategico decVie_PlanAccionEjeEstrategico)
        {
            Update(decVie_PlanAccionEjeEstrategico);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionEjeEstrategico> IDecVie_PlanAccionEjeEstrategicoRepository.GetDataTableDecVie_PlanAccionEjeEstrategico(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;
            string columnaorden = model.SortColumn;

            Expression<Func<DecVie_PlanAccionEjeEstrategico, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionEjeEstrategico, string>> orderByFunc = null;
            Expression<Func<DecVie_PlanAccionEjeEstrategico, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.ejeestrategico.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }
            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
                       
            if (model.SortColumn == "descripcionejeestrategicodt")
            {
                columnaorden = "descripcionejeestrategico";
            }

            if (model.SortColumn == "planaccionesestrategicadt")
            {
                columnaorden = "planaccionesestrategica";
            }

            if (columnaorden == "id_ejeestrategico")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PlanAccionEjeEstrategico>(columnaorden);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionEjeEstrategico>(columnaorden);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PlanAccionEjeEstrategico> data = null;
           
            if (columnaorden == "id_ejeestrategico")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionEjeEstrategico> result = new DataTableAdapter<DecVie_PlanAccionEjeEstrategico>();

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