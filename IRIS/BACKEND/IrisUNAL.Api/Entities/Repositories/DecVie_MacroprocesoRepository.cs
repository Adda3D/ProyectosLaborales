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
    public class DecVie_MacroprocesoRepository : SuperType<DecVie_Macroproceso>, IDecVie_MacroprocesoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_MacroprocesoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_MacroprocesoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Macroproceso(int id_decviemacroproceso)
        {
            Delete(id_decviemacroproceso);
            return true;
        }

        public IEnumerable<DecVie_Macroproceso> GetAllDecVie_Macroproceso()
        {
            return Get();
        }

        public DecVie_Macroproceso GetDecVie_MacroprocesoDetails(int id_decviemacroproceso)
        {
            return Get(id_decviemacroproceso);
        }

        public DecVie_Macroproceso GetDecVie_MacroprocesoNombre(string cd_nmdecviemacroproceso)
        {
            return Get(c => c.nmdecviemacroproceso == cd_nmdecviemacroproceso).FirstOrDefault();
        }

        public bool InsertDecVie_Macroproceso(DecVie_Macroproceso decVie_Macroproceso)
        {
            Add(decVie_Macroproceso);
            return true;
        }

        public bool UpdateDecVie_Macroproceso(DecVie_Macroproceso decVie_Macroproceso)
        {
            Update(decVie_Macroproceso);
            return true;
        }
        DataTableAdapter<DecVie_Macroproceso> IDecVie_MacroprocesoRepository.GetDataTableDecVie_Macroproceso(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Macroproceso, bool>> srchByFunc = null;
            Expression<Func<DecVie_Macroproceso, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdecviemacroproceso.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Macroproceso>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Macroproceso> result = new DataTableAdapter<DecVie_Macroproceso>();

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