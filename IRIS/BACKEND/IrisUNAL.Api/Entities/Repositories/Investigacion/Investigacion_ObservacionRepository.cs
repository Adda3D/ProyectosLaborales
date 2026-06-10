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
    public class Investigacion_ObservacionRepository : SuperType<Investigacion_Observacion>
    {
        private ApplicationDbContext _context;

        public Investigacion_ObservacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_ObservacionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteInvestigacion_Observacion(int id_proyectoobservacion)
        {
            Delete(id_proyectoobservacion);
            return true;
        }

        public IEnumerable<Investigacion_Observacion> GetAllInvestigacion_Observacion()
        {
            return Get();
        }

        public Investigacion_Observacion GetInvestigacion_ObservacionDetails(int id_proyectoobservacion)
        {
            return Get(id_proyectoobservacion);
        }

        public bool InsertInvestigacion_Observacion(Investigacion_Observacion _investigacion_observacion)
        {
            Add(_investigacion_observacion);
            return true;
        }

        public bool UpdateInvestigacion_Observacion(Investigacion_Observacion _investigacion_observacion)
        {
            Update(_investigacion_observacion);
            return true;
        }

        public IEnumerable<Investigacion_Observacion> GetAllInvestigacion_ObservacionByProyecto(int id_crearproyecto)
        {
            return Get(c => c.id_crearproyecto == id_crearproyecto);
        }

        public DataTableAdapter<Investigacion_Observacion> GetDataTableInvestigacion_ObservacionByProyecto(int id_crearproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Observacion, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Observacion, string>> orderByFunc = null;            

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_crearproyecto == id_crearproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearproyecto == id_crearproyecto && d.observacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_Observacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Observacion> result = new DataTableAdapter<Investigacion_Observacion>();

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