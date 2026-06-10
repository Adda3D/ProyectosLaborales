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
    public class DecVie_PlanAccionActividadesRepository : SuperType<DecVie_PlanAccionActividades>, IDecVie_PlanAccionActividadesRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionActividadesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionActividadesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionActividades(int id_actividades)
        {
            Delete(id_actividades);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionActividades> GetAllDecVie_PlanAccionActividades()
        {
            return Get();
        }

        public DecVie_PlanAccionActividades GetDecVie_PlanAccionActividadesDetails(int id_actividades)
        {
            return Get(id_actividades);
        }

        public DecVie_PlanAccionActividades GetDecVie_PlanAccionActividadesNombre(string cd_nmactividad)
        {
            return Get(c => c.nmactividad == cd_nmactividad).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionActividades(DecVie_PlanAccionActividades decVie_PlanAccionActividades)
        {
            Add(decVie_PlanAccionActividades);
            return true;
        }

        public bool UpdateDecVie_PlanAccionActividades(DecVie_PlanAccionActividades decVie_PlanAccionActividades)
        {
            Update(decVie_PlanAccionActividades);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionActividades> IDecVie_PlanAccionActividadesRepository.GetDataTableDecVie_PlanAccionActividades(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionActividades, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionActividades, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmactividad.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionActividades>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionActividades> result = new DataTableAdapter<DecVie_PlanAccionActividades>();

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