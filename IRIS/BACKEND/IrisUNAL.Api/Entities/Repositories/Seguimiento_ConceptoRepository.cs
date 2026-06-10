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
    public class Seguimiento_ConceptoRepository : SuperType<Seguimiento_Concepto>, ISeguimiento_ConceptoRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_ConceptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_ConceptoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_Concepto(int id_concepto)
        {
            Delete(id_concepto);
            return true;
        }

        public IEnumerable<Seguimiento_Concepto> GetAllSeguimiento_Concepto()
        {
            return Get();
        }

        public IEnumerable<Seguimiento_Concepto> GetSeguimiento_ConceptoCodigo(string cd_codigointernoconcepto)
        {
            return Get(c => c.codigointernoconcepto == cd_codigointernoconcepto);
        }

        public Seguimiento_Concepto GetSeguimiento_ConceptoDetails(int id_concepto)
        {
            return Get(id_concepto);
        }

        public bool InsertSeguimiento_Concepto(Seguimiento_Concepto seguimiento_Concepto)
        {
            Add(seguimiento_Concepto);
            return true;
        }

        public bool UpdateSeguimiento_Concepto(Seguimiento_Concepto seguimiento_Concepto)
        {
            Update(seguimiento_Concepto);
            return true;
        }

        public DataTableAdapter<Seguimiento_Concepto> GetDataTableSeguimiento_Concepto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_Concepto, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_Concepto, string>> orderByFunc = null;
            //Expression<Func<Proyectos_Obligaciones, DateTime>> orderByDateFunc = null;

            Expression<Func<Seguimiento_Concepto, object>> parameter1 = s => s.objPartida;
            Expression<Func<Seguimiento_Concepto, object>> parameter2 = s => s.objRubro;
            Expression<Func<Seguimiento_Concepto, object>>[] parameterArray = new Expression<Func<Seguimiento_Concepto, object>>[] { parameter1,parameter2 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nombreconcepto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Seguimiento_Concepto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Seguimiento_Concepto> result = new DataTableAdapter<Seguimiento_Concepto>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public IEnumerable<Seguimiento_Concepto> GetSeguimiento_ConceptoByRubro(int id_rubro )
        {
            return Get(c => c.id_rubro == id_rubro);            
        }
    }
}