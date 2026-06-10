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
    public class Convocatoria_EstadoCnvRepository : SuperType<Convocatoria_EstadoCnv>
    {
        private ApplicationDbContext _context;

        public Convocatoria_EstadoCnvRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Convocatoria_EstadoCnvRepository()
        {
            _context = new ApplicationDbContext();
        }        
        public IEnumerable<Convocatoria_EstadoCnv> GetAllConvocatoria_EstadoCnv()
        {
            return Get();
        }
        public Convocatoria_EstadoCnv GetConvocatoria_EstadoCnvDetails(int id_estadocnv)
        {
            return Get(id_estadocnv);
        }
        public Convocatoria_EstadoCnv GetConvocatoria_EstadoCnvNombre(string cd_nmestadocnv)
        {
            return Get(c => c.nmestadocnv == cd_nmestadocnv).FirstOrDefault();
        }
        public bool InsertConvocatoria_EstadoCnv(Convocatoria_EstadoCnv convocatoria_EstadoCnv)
        {
            Add(convocatoria_EstadoCnv);
            return true;
        }
        public bool UpdateConvocatoria_EstadoCnv(Convocatoria_EstadoCnv convocatoria_EstadoCnv)
        {
            Update(convocatoria_EstadoCnv);
            return true;
        }
        public bool DeleteConvocatoria_EstadoCnv(int id_estadocnv)
        {
            Delete(id_estadocnv);
            return true;
        }
        public DataTableAdapter<Convocatoria_EstadoCnv> GetDataTableConvocatoria_EstadoCnv(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria_EstadoCnv, bool>> srchByFunc = null;
            Expression<Func<Convocatoria_EstadoCnv, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadocnv.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Convocatoria_EstadoCnv>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria_EstadoCnv> result = new DataTableAdapter<Convocatoria_EstadoCnv>();

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