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
    public class Propuesta_OrigenPropuestaRepository : SuperType<Propuesta_OrigenPropuesta>, IPropuesta_OrigenPropuestaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_OrigenPropuestaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_OrigenPropuestaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_OrigenPropuesta(int id_origenpropuesta)
        {
            Delete(id_origenpropuesta);
            return true;
        }

        public IEnumerable<Propuesta_OrigenPropuesta> GetAllPropuesta_OrigenPropuesta()
        {
            return Get();
        }

        public Propuesta_OrigenPropuesta GetPropuesta_OrigenPropuestaDetails(int id_origenpropuesta)
        {
            return Get(id_origenpropuesta);

        }

        public IEnumerable<Propuesta_OrigenPropuesta> GetPropuesta_OrigenPropuestaDetails(string cd_nmorigenpropuesta)
        {
            return Get(c => c.nmorigenpropuesta == cd_nmorigenpropuesta);
        }

        public bool InsertPropuesta_OrigenPropuesta(Propuesta_OrigenPropuesta propuesta_OrigenPropuesta)
        {
            Add(propuesta_OrigenPropuesta);
            return true;
        }

        public bool UpdatePropuesta_OrigenPropuesta(Propuesta_OrigenPropuesta propuesta_OrigenPropuesta)
        {
            Update(propuesta_OrigenPropuesta);
            return true;
        }

        public DataTableAdapter<Propuesta_OrigenPropuesta> GetDataTablePropuestaOrigen(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_OrigenPropuesta, bool>> srchByFunc = null;
            Expression<Func<Propuesta_OrigenPropuesta, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmorigenpropuesta.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_OrigenPropuesta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_OrigenPropuesta> result = new DataTableAdapter<Propuesta_OrigenPropuesta>();

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