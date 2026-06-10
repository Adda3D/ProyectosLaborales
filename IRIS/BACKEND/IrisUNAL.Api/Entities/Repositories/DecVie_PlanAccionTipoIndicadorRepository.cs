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
    public class DecVie_PlanAccionTipoIndicadorRepository : SuperType<DecVie_PlanAccionTipoIndicador>, IDecVie_PlanAccionTipoIndicadorRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionTipoIndicadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionTipoIndicadorRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionTipoIndicador(int id_tipoindicador)
        {
            Delete(id_tipoindicador);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionTipoIndicador> GetAllDecVie_PlanAccionTipoIndicador()
        {
            return Get();
        }

        public DecVie_PlanAccionTipoIndicador GetDecVie_PlanAccionTipoIndicadorDetails(int id_tipoindicador)
        {
            return Get(id_tipoindicador);
        }

        public DecVie_PlanAccionTipoIndicador GetDecVie_PlanAccionTipoIndicadorNombre(string cd_nmtipoindicador)
        {
            return Get(c => c.nmtipoindicador == cd_nmtipoindicador).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionTipoIndicador(DecVie_PlanAccionTipoIndicador decVie_PlanAccionTipoIndicador)
        {
            Add(decVie_PlanAccionTipoIndicador);
            return true;
        }

        public bool UpdateDecVie_PlanAccionTipoIndicador(DecVie_PlanAccionTipoIndicador decVie_PlanAccionTipoIndicador)
        {
            Update(decVie_PlanAccionTipoIndicador);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionTipoIndicador> IDecVie_PlanAccionTipoIndicadorRepository.GetDataTableDecVie_PlanAccionTipoIndicador(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionTipoIndicador, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionTipoIndicador, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipoindicador.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionTipoIndicador>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionTipoIndicador> result = new DataTableAdapter<DecVie_PlanAccionTipoIndicador>();

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