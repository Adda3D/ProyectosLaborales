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
    public class Proyectos_ObligacionesRepository : SuperType<Proyectos_Obligaciones>, IProyectos_ObligacionesRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_ObligacionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_ObligacionesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyectos_Obligaciones(int id_proyectoobligaciones)
        {
            Delete(id_proyectoobligaciones);
            return true;
        }

        public IEnumerable<Proyectos_Obligaciones> GetAllProyectos_Obligaciones()
        {
            return Get();
        }

        public Proyectos_Obligaciones GetProyectos_ObligacionesDetails(int id_proyectoobligaciones)
        {
            return Get(id_proyectoobligaciones);
        }

        public IEnumerable<Proyectos_Obligaciones> GetProyectos_ObligacionesNombre(string cd_obligacion)
        {
            return Get(c => c.obligacion == cd_obligacion);
        }

        public bool InsertProyectos_Obligaciones(Proyectos_Obligaciones proyectos_Obligaciones)
        {
            Add(proyectos_Obligaciones);
            return true;
        }

        public bool UpdateProyectos_Obligaciones(Proyectos_Obligaciones proyectos_Obligaciones)
        {
            Update(proyectos_Obligaciones);
            return true;
        }

        public IEnumerable<Proyectos_Obligaciones> GetAllProyectos_ObligacionesByProyecto(int id_asignacionproyecto)
        {
            return Get(c => c.id_asignacionproyecto == id_asignacionproyecto);
        }

        public DataTableAdapter<Proyectos_Obligaciones> GetDataTableProyectos_Obligaciones(int id_asignacionproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_Obligaciones, bool>> srchByFunc = null;
            Expression<Func<Proyectos_Obligaciones, string>> orderByFunc = null;
            //Expression<Func<Proyectos_Obligaciones, DateTime>> orderByDateFunc = null;

            //Expression<Func<Propuesta_ModificacionGarantia, object>> parameter1 = m => m.minuta;
            Expression<Func<Proyectos_Obligaciones, object>> parameter2 = m => m.estadoObligacion;
            Expression<Func<Proyectos_Obligaciones, object>>[] parameterArray = new Expression<Func<Proyectos_Obligaciones, object>>[] { parameter2 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto && d.obligacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_Obligaciones>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_Obligaciones> result = new DataTableAdapter<Proyectos_Obligaciones>();

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