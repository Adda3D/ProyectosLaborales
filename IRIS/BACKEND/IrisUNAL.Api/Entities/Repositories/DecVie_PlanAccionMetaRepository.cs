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
    public class DecVie_PlanAccionMetaRepository : SuperType<DecVie_PlanAccionMeta>, IDecVie_PlanAccionMetaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PlanAccionMetaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PlanAccionMetaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PlanAccionMeta(int id_meta)
        {
            Delete(id_meta);
            return true;
        }

        public IEnumerable<DecVie_PlanAccionMeta> GetAllDecVie_PlanAccionMeta()
        {
            return Get();
        }

        public DecVie_PlanAccionMeta GetDecVie_PlanAccionMetaDetails(int id_meta)
        {
            return Get(id_meta);
        }

        public DecVie_PlanAccionMeta GetDecVie_PlanAccionMetaNombre(string cd_nmmeta)
        {
            return Get(c => c.nmmeta == cd_nmmeta).FirstOrDefault();
        }

        public bool InsertDecVie_PlanAccionMeta(DecVie_PlanAccionMeta decVie_PlanAccionMeta)
        {
            Add(decVie_PlanAccionMeta);
            return true;
        }

        public bool UpdateDecVie_PlanAccionMeta(DecVie_PlanAccionMeta decVie_PlanAccionMeta)
        {
            Update(decVie_PlanAccionMeta);
            return true;
        }
        DataTableAdapter<DecVie_PlanAccionMeta> IDecVie_PlanAccionMetaRepository.GetDataTableDecVie_PlanAccionMeta(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PlanAccionMeta, bool>> srchByFunc = null;
            Expression<Func<DecVie_PlanAccionMeta, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmmeta.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_PlanAccionMeta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PlanAccionMeta> result = new DataTableAdapter<DecVie_PlanAccionMeta>();

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