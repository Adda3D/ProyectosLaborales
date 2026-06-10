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
    public class Propuesta_TipoModificacionRepository : SuperType<Propuesta_TipoModificacion>, IPropuesta_TipoModificacionRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_TipoModificacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_TipoModificacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_TipoModificacion(int id_tipomodificacion)
        {
            Delete(id_tipomodificacion);
            return true;
        }

        public IEnumerable<Propuesta_TipoModificacion> GetAllPropuesta_TipoModificacion()
        {
            return Get();
        }

        public Propuesta_TipoModificacion GetPropuesta_TipoModificacionDetails(int id_tipomodificacion)
        {
            return Get(id_tipomodificacion);
        }

        public Propuesta_TipoModificacion GetPropuesta_TipoModificacionDetails(string nmtipomodificacion)
        {
            return Get(c=> c.nmtipomodificacion == nmtipomodificacion).FirstOrDefault();
        }

        public bool InsertPropuesta_TipoModificacion(Propuesta_TipoModificacion propuesta_TipoModificacion)
        {
            Add(propuesta_TipoModificacion);
            return true;
        }

        public bool UpdatePropuesta_TipoModificacion(Propuesta_TipoModificacion propuesta_TipoModificacion)
        {
            Update(propuesta_TipoModificacion);
            return true;
        }

        public DataTableAdapter<Propuesta_TipoModificacion> GetDataTablePropuestaSuscripcionMinuta(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_TipoModificacion, bool>> srchByFunc = null;
            Expression<Func<Propuesta_TipoModificacion, string>> orderByFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipomodificacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_TipoModificacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_TipoModificacion> result = new DataTableAdapter<Propuesta_TipoModificacion>();

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