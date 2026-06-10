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
    public class Convocatoria_RequerimientoRequisitoRepository : SuperType<Convocatoria_RequerimientoRequisito>
    {
        private ApplicationDbContext _context;

        public Convocatoria_RequerimientoRequisitoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Convocatoria_RequerimientoRequisitoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Convocatoria_RequerimientoRequisito> GetAllConvocatoria_RequerimientoRequisito()
        {
            return Get();
        }
        public Convocatoria_RequerimientoRequisito GetConvocatoria_RequerimientoRequisitoDetails(int id_requisito)
        {
            return Get(id_requisito);
        }
        public Convocatoria_RequerimientoRequisito GetConvocatoria_RequerimientoRequisitoNombre(string cd_nmrequisito)
        {
            return Get(c => c.nmrequisito == cd_nmrequisito).FirstOrDefault();
        }
        public bool InsertConvocatoria_RequerimientoRequisito(Convocatoria_RequerimientoRequisito convocatoria_RequerimientoRequisito)
        {
            Add(convocatoria_RequerimientoRequisito);
            return true;
        }
        public bool UpdateConvocatoria_RequerimientoRequisito(Convocatoria_RequerimientoRequisito convocatoria_RequerimientoRequisito)
        {
            Update(convocatoria_RequerimientoRequisito);
            return true;
        }
        public bool DeleteConvocatoria_RequerimientoRequisito (int id_requisito)
        {
            Delete(id_requisito);
            return true;
        }
        public DataTableAdapter<Convocatoria_RequerimientoRequisito> GetDataTableConvocatoria_RequerimientoRequisitoByConvocatoria(int id_convocatoria, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria_RequerimientoRequisito, bool>> srchByFunc = null;
            Expression<Func<Convocatoria_RequerimientoRequisito, int>> orderByFunc = null;
            Expression<Func<Convocatoria_RequerimientoRequisito, object>> parameter1 = p => p.Objconvocatoria;
 
            Expression<Func<Convocatoria_RequerimientoRequisito, object>>[] parameterArray = new Expression<Func<Convocatoria_RequerimientoRequisito, object>>[] { parameter1, };
            bool isOrderDesc = false;

            //FILTRA POR Convocatoria
            srchByFunc = d => d.id_convocatoria == id_convocatoria;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_convocatoria == id_convocatoria && d.nmrequisito.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<Convocatoria_RequerimientoRequisito>("id_requisito");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria_RequerimientoRequisito> result = new DataTableAdapter<Convocatoria_RequerimientoRequisito>();

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