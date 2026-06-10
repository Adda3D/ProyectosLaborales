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
    public class Proyectos_ProyectosObservacionesRepository : SuperType<Proyectos_ProyectosObservaciones>, IProyectos_ProyectosObservacionesRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_ProyectosObservacionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_ProyectosObservacionesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyectos_ProyectosObservaciones(int id_proyectosobservaciones)
        {
            Delete(id_proyectosobservaciones);
            return true;
        }

        public IEnumerable<Proyectos_ProyectosObservaciones> GetAllProyectos_ProyectosObservaciones()
        {
            return Get();
        }

        public IEnumerable<Proyectos_ProyectosObservaciones> GetProyectos_ProyectosObservacionesDescripcion(string cd_descripcion)
        {
            return Get(c=>c.descripcion==cd_descripcion);
        }

        public Proyectos_ProyectosObservaciones GetProyectos_ProyectosObservacionesDetails(int id_proyectosobservaciones)
        {
            return Get(id_proyectosobservaciones);
        }

        public bool InsertProyectos_ProyectosObservaciones(Proyectos_ProyectosObservaciones proyectos_ProyectosObservaciones)
        {
            Add(proyectos_ProyectosObservaciones);
            return true;
        }

        public bool UpdateProyectos_ProyectosObservaciones(Proyectos_ProyectosObservaciones proyectos_ProyectosObservaciones)
        {
            Update(proyectos_ProyectosObservaciones);
            return true;
        }

        public DataTableAdapter<Proyectos_ProyectosObservaciones> GetDataTableProyectos_Observaciones(int id_asignacionproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_ProyectosObservaciones, bool>> srchByFunc = null;
            Expression<Func<Proyectos_ProyectosObservaciones, string>> orderByFunc = null;
            Expression<Func<Proyectos_ProyectosObservaciones, DateTime>> orderByDateFunc = null;

            //Expression<Func<Propuesta_ModificacionGarantia, object>> parameter1 = m => m.minuta;
            //Expression<Func<Proyectos_ProyectosObservaciones, object>> parameter2 = m => m.estadoObligacion;
            //Expression<Func<Proyectos_ProyectosObservaciones, object>>[] parameterArray = new Expression<Func<Proyectos_ProyectosObservaciones, object>>[] { parameter2 };

            bool isOrderDesc = false;
            
            if (model.SortColumn.ToLower() == "fechaasignacion")
                orderByDateFunc = CreateExpressionOrderByDate<Proyectos_ProyectosObservaciones>("fechaasignacion");
            else
                orderByFunc = CreateExpressionOrderBy<Proyectos_ProyectosObservaciones>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto && d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            //orderByFunc = CreateExpressionOrderBy<Proyectos_ProyectosObservaciones>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fechaasignacion") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_ProyectosObservaciones> result = new DataTableAdapter<Proyectos_ProyectosObservaciones>();

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