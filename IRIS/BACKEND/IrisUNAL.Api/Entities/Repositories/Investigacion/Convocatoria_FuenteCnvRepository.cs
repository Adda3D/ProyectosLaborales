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
    public class Convocatoria_FuenteCnvRepository : SuperType<Convocatoria_FuenteCnv>
    {
        private ApplicationDbContext _context;

        public Convocatoria_FuenteCnvRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Convocatoria_FuenteCnvRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Convocatoria_FuenteCnv> GetAllConvocatoria_FuenteCnv()
        {
            return Get();
        }
        public Convocatoria_FuenteCnv GetConvocatoria_FuenteCnvDetails(int id_fuentecnv)
        {
            return Get(id_fuentecnv);
        }
        public Convocatoria_FuenteCnv GetConvocatoria_FuenteCnvNombre(string cd_nmfuentecnv)
        {
            return Get(c => c.nmfuentecnv == cd_nmfuentecnv).FirstOrDefault();
        }
        public bool InsertConvocatoria_FuenteCnv(Convocatoria_FuenteCnv convocatoria_EstadoCnv)
        {
            Add(convocatoria_EstadoCnv);
            return true;
        }
        public bool UpdateConvocatoria_FuenteCnv(Convocatoria_FuenteCnv convocatoria_EstadoCnv)
        {
            Update(convocatoria_EstadoCnv);
            return true;
        }
        public bool DeleteConvocatoria_FuenteCnv(int id_fuentecnv)
        {
            Delete(id_fuentecnv);
            return true;
        }
        public DataTableAdapter<Convocatoria_FuenteCnv> GetDataTableConvocatoria_FuenteCnv(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria_FuenteCnv, bool>> srchByFunc = null;
            Expression<Func<Convocatoria_FuenteCnv, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmfuentecnv.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Convocatoria_FuenteCnv>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria_FuenteCnv> result = new DataTableAdapter<Convocatoria_FuenteCnv>();

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