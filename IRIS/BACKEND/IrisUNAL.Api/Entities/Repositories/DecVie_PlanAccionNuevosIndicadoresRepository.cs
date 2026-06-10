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
    public class DecVie_PlanAccionNuevosIndicadoresRepository : SuperType<DecVie_PlanAccionNuevosIndicadores>, IDecVie_PlanAccionNuevosIndicadoresRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionNuevosIndicadoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionNuevosIndicadoresRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionNuevosIndicadores(int id_nuevosindicadores)
        {
            Delete(id_nuevosindicadores);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionNuevosIndicadores> GetAllDecVie_PlanAccionNuevosIndicadores()
        {
            return Get();
        }

        public DecVie_PlanAccionNuevosIndicadores GetDecVie_PlanAccionNuevosIndicadoresDetails(int id_nuevosindicadores)
        {
            return Get(id_nuevosindicadores);
        }

        public DecVie_PlanAccionNuevosIndicadores GetDecVie_PlanAccionNuevosIndicadoresNombre(string cd_nmnuevosindicadores)
        {
            return Get(c => c.nmnuevosindicadores == cd_nmnuevosindicadores).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionNuevosIndicadores(DecVie_PlanAccionNuevosIndicadores decVie_PlanAccionNuevosIndicadores)
        {
            Add(decVie_PlanAccionNuevosIndicadores);
            return true;
        }

        public bool UpdateDecVie_PlanAccionNuevosIndicadores(DecVie_PlanAccionNuevosIndicadores decVie_PlanAccionNuevosIndicadores)
        {
            Update(decVie_PlanAccionNuevosIndicadores);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionNuevosIndicadores> IDecVie_PlanAccionNuevosIndicadoresRepository.GetDataTableDecVie_PlanAccionNuevosIndicadores(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionNuevosIndicadores, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionNuevosIndicadores, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmnuevosindicadores.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionNuevosIndicadores>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionNuevosIndicadores> result = new DataTableAdapter<DecVie_PlanAccionNuevosIndicadores>();

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