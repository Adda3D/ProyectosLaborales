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
    public class DecVie_PlanAccionObjetivosPgdVriSedeRepository : SuperType<DecVie_PlanAccionObjetivosPgdVriSede>, IDecVie_PlanAccionObjetivosPgdVriSedeRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionObjetivosPgdVriSedeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionObjetivosPgdVriSedeRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionObjetivosPgdVriSede(int id_objetivopgdvrisede)
        {
            Delete(id_objetivopgdvrisede);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionObjetivosPgdVriSede> GetAllDecVie_PlanAccionObjetivosPgdVriSede()
        {
            return Get();
        }

        public DecVie_PlanAccionObjetivosPgdVriSede GetDecVie_PlanAccionObjetivosPgdVriSedeDetails(int id_objetivopgdvrisede)
        {
            return Get(id_objetivopgdvrisede);
        }

        public DecVie_PlanAccionObjetivosPgdVriSede GetDecVie_PlanAccionObjetivosPgdVriSedeNombre(string cd_nmobjetivopgdvrisede)
        {
            return Get(c => c.nmobjetivopgdvrisede == cd_nmobjetivopgdvrisede).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionObjetivosPgdVriSede(DecVie_PlanAccionObjetivosPgdVriSede decVie_PlanAccionObjetivosPgdVriSede)
        {
            Add(decVie_PlanAccionObjetivosPgdVriSede);
            return true;
        }

        public bool UpdateDecVie_PlanAccionObjetivosPgdVriSede(DecVie_PlanAccionObjetivosPgdVriSede decVie_PlanAccionObjetivosPgdVriSede)
        {
            Update(decVie_PlanAccionObjetivosPgdVriSede);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionObjetivosPgdVriSede> IDecVie_PlanAccionObjetivosPgdVriSedeRepository.GetDataTableDecVie_PlanAccionObjetivosPgdVriSede(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionObjetivosPgdVriSede, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionObjetivosPgdVriSede, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmobjetivopgdvrisede.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionObjetivosPgdVriSede>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionObjetivosPgdVriSede> result = new DataTableAdapter<DecVie_PlanAccionObjetivosPgdVriSede>();

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