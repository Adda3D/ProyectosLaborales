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
    public class Propuesta_TipoPropuestaRepository : SuperType<Propuesta_TipoPropuesta>, IPropuesta_TipoPropuestaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_TipoPropuestaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_TipoPropuestaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_TipoPropuesta(int id_tipopropuesta)
        {
            Delete(id_tipopropuesta);
            return true;
        }

        public IEnumerable<Propuesta_TipoPropuesta> GetAllPropuesta_TipoPropuesta()
        {
            return Get();
        }

        public Propuesta_TipoPropuesta GetPropuesta_TipoPropuestaDetails(int id_tipopropuesta)
        {
            return Get(id_tipopropuesta);
        }

        public IEnumerable<Propuesta_TipoPropuesta> GetPropuesta_TipoPropuestaDetails(string cd_nmtipopropuesta)
        {
            return Get(c=> c.nmtipopropuesta ==cd_nmtipopropuesta);
        }

        public bool InsertPropuesta_TipoPropuesta(Propuesta_TipoPropuesta propuesta_TipoPropuesta)
        {
            Add(propuesta_TipoPropuesta);
            return true;
        }

        public bool UpdatePropuesta_TipoPropuesta(Propuesta_TipoPropuesta propuesta_TipoPropuesta)
        {
            Update(propuesta_TipoPropuesta);
            return true;
        }

        public DataTableAdapter<Propuesta_TipoPropuesta> GetDataTablePropuestaTipoPropuesta(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_TipoPropuesta, bool>> srchByFunc = null;
            Expression<Func<Propuesta_TipoPropuesta, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipopropuesta.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_TipoPropuesta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_TipoPropuesta> result = new DataTableAdapter<Propuesta_TipoPropuesta>();

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