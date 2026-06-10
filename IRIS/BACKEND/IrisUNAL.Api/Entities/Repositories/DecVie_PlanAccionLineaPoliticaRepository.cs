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
    public class DecVie_PlanAccionLineaPoliticaRepository : SuperType<DecVie_PlanAccionLineaPolitica>, IDecVie_PlanAccionLineaPoliticaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionLineaPoliticaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionLineaPoliticaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionLineaPolitica(int id_lineapolitica)
        {
            Delete(id_lineapolitica);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionLineaPolitica> GetAllDecVie_PlanAccionLineaPolitica()
        {
            return Get();
        }

        public DecVie_PlanAccionLineaPolitica GetDecVie_PlanAccionLineaPoliticaDetails(int id_lineapolitica)
        {
            return Get(id_lineapolitica);
        }

        public DecVie_PlanAccionLineaPolitica GetDecVie_PlanAccionLineaPoliticaNombre(string cd_lineapolitica)
        {
            return Get(c => c.lineapolitica == cd_lineapolitica).FirstOrDefault();

        }

        public bool InsertDecVie_PlanAccionLineaPolitica(DecVie_PlanAccionLineaPolitica decVie_PlanAccionLineaPolitica)
        {
            Add(decVie_PlanAccionLineaPolitica);
            return true;
        }

        public bool UpdateDecVie_PlanAccionLineaPolitica(DecVie_PlanAccionLineaPolitica decVie_PlanAccionLineaPolitica)
        {
            Update(decVie_PlanAccionLineaPolitica);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionLineaPolitica> IDecVie_PlanAccionLineaPoliticaRepository.GetDataTableDecVie_PlanAccionLineaPolitica(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionLineaPolitica, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionLineaPolitica, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.lineapolitica.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionLineaPolitica>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionLineaPolitica> result = new DataTableAdapter<DecVie_PlanAccionLineaPolitica>();

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