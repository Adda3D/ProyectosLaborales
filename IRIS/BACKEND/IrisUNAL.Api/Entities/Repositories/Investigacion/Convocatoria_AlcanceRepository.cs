using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class Convocatoria_AlcanceRepository : SuperType<Convocatoria_Alcance>
    {
        private ApplicationDbContext _context;

        public Convocatoria_AlcanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Convocatoria_AlcanceRepository()
        {
            _context = new ApplicationDbContext();
        }        
        public IEnumerable<Convocatoria_Alcance> GetAllConvocatoria_Alcance()
        {
            return Get();
        }
        public Convocatoria_Alcance GetConvocatoria_AlcanceDetails(int id_alcance)
        {
            return Get(id_alcance);
        }
        public Convocatoria_Alcance GetConvocatoria_AlcanceNombre(string cd_nmalcance)
        {
            return Get(c => c.nmalcance == cd_nmalcance).FirstOrDefault();
        }
        public bool InsertConvocatoria_Alcance(Convocatoria_Alcance convocatoria_Alcance)
        {
            Add(convocatoria_Alcance);
            return true;
        }
        public bool UpdateConvocatoria_Alcance(Convocatoria_Alcance convocatoria_Alcance)
        {
            Update(convocatoria_Alcance);
            return true;
        }
        public bool DeleteConvocatoria_Alcance (int id_alcance)
        {
            Delete(id_alcance);
            return true;
        }
        public DataTableAdapter<Convocatoria_Alcance> GetDataTableConvocatoria_Alcance(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria_Alcance, bool>> srchByFunc = null;
            Expression<Func<Convocatoria_Alcance, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmalcance.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Convocatoria_Alcance>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria_Alcance> result = new DataTableAdapter<Convocatoria_Alcance>();

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