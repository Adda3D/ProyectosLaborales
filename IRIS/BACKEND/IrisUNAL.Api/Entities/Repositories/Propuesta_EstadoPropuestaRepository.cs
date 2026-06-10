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
    public class Propuesta_EstadoPropuestaRepository : SuperType<Propuesta_EstadoPropuesta>, IPropuesta_EstadoPropuestaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_EstadoPropuestaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_EstadoPropuestaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_EstadoPropuesta(int id_estadopropuesta)
        {
            Delete(id_estadopropuesta);
            return true;            
        }

        public IEnumerable<Propuesta_EstadoPropuesta> GetAllPropuesta_EstadoPropuesta()
        {
            return Get();
        }

        public Propuesta_EstadoPropuesta GetPropuesta_EstadoPropuestaDetails(int id_estadopropuesta)
        {
            return Get(id_estadopropuesta);
        }

        public IEnumerable<Propuesta_EstadoPropuesta> GetPropuesta_EstadoPropuestaDetails(string cd_nmestadopropuesta)
        {
            return Get(c=> c.nmestadopropuesta==cd_nmestadopropuesta);
        }

        public bool InsertPropuesta_EstadoPropuesta(Propuesta_EstadoPropuesta propuesta_EstadoPropuesta)
        {
            Add(propuesta_EstadoPropuesta);
            return true;
        }

        public bool UpdatePropuesta_EstadoPropuesta(Propuesta_EstadoPropuesta propuesta_EstadoPropuesta)
        {
            Update(propuesta_EstadoPropuesta);
            return true;
        }

        public DataTableAdapter<Propuesta_EstadoPropuesta> GetDataTablePropuestaEstado(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_EstadoPropuesta, bool>> srchByFunc = null;
            Expression<Func<Propuesta_EstadoPropuesta, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadopropuesta.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_EstadoPropuesta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_EstadoPropuesta> result = new DataTableAdapter<Propuesta_EstadoPropuesta>();

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