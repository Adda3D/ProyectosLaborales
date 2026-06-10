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
    public class DecVie_PlanAccionIndicadoresEstrategicosRepository : SuperType<DecVie_PlanAccionIndicadoresEstrategicos>, IDecVie_PlanAccionIndicadoresEstrategicosRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionIndicadoresEstrategicosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionIndicadoresEstrategicosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionIndicadoresEstrategicos(int id_indicadoresestrategicos)
        {
            Delete(id_indicadoresestrategicos);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionIndicadoresEstrategicos> GetAllDecVie_PlanAccionIndicadoresEstrategicos()
        {
            return Get();
        }

        public DecVie_PlanAccionIndicadoresEstrategicos GetDecVie_PlanAccionIndicadoresEstrategicosDetails(int id_indicadoresestrategicos)
        {
            return Get(id_indicadoresestrategicos);
        }

        public DecVie_PlanAccionIndicadoresEstrategicos GetDecVie_PlanAccionIndicadoresEstrategicosNombre(string cd_nmindicadoresestrategicos)
        {
            return Get(c => c.nmindicadoresestrategicos == cd_nmindicadoresestrategicos).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionIndicadoresEstrategicos(DecVie_PlanAccionIndicadoresEstrategicos decVie_PlanAccionIndicadoresEstrategicos)
        {
            Add(decVie_PlanAccionIndicadoresEstrategicos);
            return true;
        }

        public bool UpdateDecVie_PlanAccionIndicadoresEstrategicos(DecVie_PlanAccionIndicadoresEstrategicos decVie_PlanAccionIndicadoresEstrategicos)
        {
            Update(decVie_PlanAccionIndicadoresEstrategicos);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionIndicadoresEstrategicos> IDecVie_PlanAccionIndicadoresEstrategicosRepository.GetDataTableDecVie_PlanAccionIndicadoresEstrategicos(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionIndicadoresEstrategicos, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionIndicadoresEstrategicos, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmindicadoresestrategicos.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionIndicadoresEstrategicos>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionIndicadoresEstrategicos> result = new DataTableAdapter<DecVie_PlanAccionIndicadoresEstrategicos>();

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