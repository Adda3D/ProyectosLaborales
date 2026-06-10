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
    public class DecVie_PlanAccionObjetivoDependenciaRepository : SuperType<DecVie_PlanAccionObjetivoDependencia>, IDecVie_PlanAccionObjetivoDependenciaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionObjetivoDependenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionObjetivoDependenciaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionObjetivoDependencia(int id_objetivodependencia)
        {
            Delete(id_objetivodependencia);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionObjetivoDependencia> GetAllDecVie_PlanAccionObjetivoDependencia()
        {
            return Get();
        }

        public DecVie_PlanAccionObjetivoDependencia GetDecVie_PlanAccionObjetivoDependenciaDetails(int id_objetivodependencia)
        {
            return Get(id_objetivodependencia);
        }

        public DecVie_PlanAccionObjetivoDependencia GetDecVie_PlanAccionObjetivoDependenciaNombre(string cd_nmobjetivodependencia)
        {
            return Get(c => c.nmobjetivodependencia == cd_nmobjetivodependencia).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionObjetivoDependencia(DecVie_PlanAccionObjetivoDependencia decVie_PlanAccionObjetivoDependencia)
        {
            Add(decVie_PlanAccionObjetivoDependencia);
            return true;
        }

        public bool UpdateDecVie_PlanAccionObjetivoDependencia(DecVie_PlanAccionObjetivoDependencia decVie_PlanAccionObjetivoDependencia)
        {
            Update(decVie_PlanAccionObjetivoDependencia);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionObjetivoDependencia> IDecVie_PlanAccionObjetivoDependenciaRepository.GetDataTableDecVie_PlanAccionObjetivoDependencia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionObjetivoDependencia, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionObjetivoDependencia, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmobjetivodependencia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionObjetivoDependencia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionObjetivoDependencia> result = new DataTableAdapter<DecVie_PlanAccionObjetivoDependencia>();

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