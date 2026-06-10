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
    public class DecVie_PlanaccionFuncionesRepository : SuperType<DecVie_PlanaccionFunciones>, IDecVie_PlanaccionFuncionesRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanaccionFuncionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanaccionFuncionesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanaccionFunciones(int id_funciones)
        {
            Delete(id_funciones);
            return true;
        }

        public IEnumerable<DecVie_PlanaccionFunciones> GetAllDecVie_PlanaccionFunciones()
        {
            return Get();
        }

        public DecVie_PlanaccionFunciones GetDecVie_PlanaccionFuncionesDetails(int id_funciones)
        {
            return Get(id_funciones);
        }

        public DecVie_PlanaccionFunciones GetDecVie_PlanaccionFuncionesNombre(string cd_nmfuncion)
        {
            return Get(c => c.nmfuncion == cd_nmfuncion).FirstOrDefault();
        }

        public bool InsertDecVie_PlanaccionFunciones(DecVie_PlanaccionFunciones decVie_PlanaccionFunciones)
        {
            Add(decVie_PlanaccionFunciones);
            return true;
        }

        public bool UpdateDecVie_PlanaccionFunciones(DecVie_PlanaccionFunciones decVie_PlanaccionFunciones)
        {
            Update(decVie_PlanaccionFunciones);
            return true;
        }
        DataTableAdapter<DecVie_PlanaccionFunciones> IDecVie_PlanaccionFuncionesRepository.GetDataTableDecVie_PlanaccionFunciones(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanaccionFunciones, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanaccionFunciones, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmfuncion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanaccionFunciones>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanaccionFunciones> result = new DataTableAdapter<DecVie_PlanaccionFunciones>();

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