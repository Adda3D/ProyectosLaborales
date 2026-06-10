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
    public class Investigacion_ObligacionRepository : SuperType<Investigacion_Obligacion>
    {
        private ApplicationDbContext _context;

        public Investigacion_ObligacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_ObligacionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteInvestigacion_Obligacion(int id_proyectoobligacion)
        {
            Delete(id_proyectoobligacion);
            return true;
        }

        public IEnumerable<Investigacion_Obligacion> GetAllInvestigacion_Obligacion()
        {
            return Get();
        }

        public Investigacion_Obligacion GetInvestigacion_ObligacionDetails(int id_proyectoobligacion)
        {
            return Get(id_proyectoobligacion);
        }

        public bool InsertInvestigacion_Obligacion(Investigacion_Obligacion _investigacion_obligacion)
        {
            Add(_investigacion_obligacion);
            return true;
        }

        public bool UpdateInvestigacion_Obligacion(Investigacion_Obligacion _investigacion_obligacion)
        {
            Update(_investigacion_obligacion);
            return true;
        }

        public IEnumerable<Investigacion_Obligacion> GetAllInvestigacion_ObligacionByProyecto(int id_crearproyecto)
        {
            return Get(c => c.id_crearproyecto == id_crearproyecto);
        }

        public DataTableAdapter<Investigacion_Obligacion> GetDataTableInvestigacion_ObligacionByProyecto(int id_crearproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Obligacion, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Obligacion, string>> orderByFunc = null;
            //Expression<Func<Investigacion_Obligacion, DateTime>> orderByDateFunc = null;

            //Expression<Func<Propuesta_ModificacionGarantia, object>> parameter1 = m => m.minuta;
            Expression<Func<Investigacion_Obligacion, object>> parameter2 = m => m.ObjEstado;
            Expression<Func<Investigacion_Obligacion, object>>[] parameterArray = new Expression<Func<Investigacion_Obligacion, object>>[] { parameter2 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_crearproyecto == id_crearproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearproyecto == id_crearproyecto && d.obligacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_Obligacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Obligacion> result = new DataTableAdapter<Investigacion_Obligacion>();

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