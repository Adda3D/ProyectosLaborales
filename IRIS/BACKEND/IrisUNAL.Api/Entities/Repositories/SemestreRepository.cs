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
    public class SemestreRepository : SuperType<Semestre>, ISemestreRepository
    {
        private ApplicationDbContext _context;

        public SemestreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SemestreRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSemestre(int id_semestre)
        {
            Delete(id_semestre);
            return true;            
        }

        public IEnumerable<Semestre> GetAllSemestre()
        {
            return Get();            
        }

        public Semestre GetSemestreDetails(int id_semestre)
        {
            return Get(id_semestre);            
        }
        public Semestre GetSemestreNombre (string cd_nmsemestre)
        {
            return Get(c => c.nmsemestre == cd_nmsemestre).FirstOrDefault();            
        }

        public bool InsertSemestre(Semestre semestre)
        {
            Add(semestre);
            return true;            
        }

        public bool UpdateSemestre(Semestre semestre)
        {
            Update(semestre);

            return true;
        }
        DataTableAdapter<Semestre> ISemestreRepository.GetDataTableSemestre(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Semestre, bool>> srchByFunc = null;
            Expression<Func<Semestre, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmsemestre.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Semestre>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Semestre> result = new DataTableAdapter<Semestre>();

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