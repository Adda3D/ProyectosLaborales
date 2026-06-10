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
    public class DecVie_PlanAccionObjetivoEstrategicoRepository : SuperType<DecVie_PlanAccionObjetivoEstrategico>, IDecVie_PlanAccionObjetivoEstrategicoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionObjetivoEstrategicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionObjetivoEstrategicoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionObjetivoEstrategico(int id_objetivoestrategico)
        {
            Delete(id_objetivoestrategico);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionObjetivoEstrategico> GetAllDecVie_PlanAccionObjetivoEstrategico()
        {
            return Get();
        }

        public DecVie_PlanAccionObjetivoEstrategico GetDecVie_PlanAccionObjetivoEstrategicoDetails(int id_objetivoestrategico)
        {
            return Get(id_objetivoestrategico);
        }

        public DecVie_PlanAccionObjetivoEstrategico GetDecVie_PlanAccionObjetivoEstrategicoNombre(string cd_objetivoestrategico)
        {
            return Get(c => c.objetivoestrategico == cd_objetivoestrategico).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionObjetivoEstrategico(DecVie_PlanAccionObjetivoEstrategico decVie_PlanAccionObjetivoEstrategico)
        {
            Add(decVie_PlanAccionObjetivoEstrategico);
            return true;
        }

        public bool UpdateDecVie_PlanAccionObjetivoEstrategico(DecVie_PlanAccionObjetivoEstrategico decVie_PlanAccionObjetivoEstrategico)
        {
            Update(decVie_PlanAccionObjetivoEstrategico);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionObjetivoEstrategico> IDecVie_PlanAccionObjetivoEstrategicoRepository.GetDataTableDecVie_PlanAccionObjetivoEstrategico(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionObjetivoEstrategico, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionObjetivoEstrategico, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.objetivoestrategico.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionObjetivoEstrategico>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionObjetivoEstrategico> result = new DataTableAdapter<DecVie_PlanAccionObjetivoEstrategico>();

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