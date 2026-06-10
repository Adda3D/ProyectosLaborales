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
    public class Proyectos_EstadoObligacionRepository : SuperType<Proyectos_EstadoObligacion>, IProyectos_EstadoObligacionRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_EstadoObligacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_EstadoObligacionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteProyectos_EstadoObligacion(int id_estadoobligacion)
        {
            Delete(id_estadoobligacion);
            return true;
        }

        public IEnumerable<Proyectos_EstadoObligacion> GetAllProyectos_EstadoObligacion()
        {
            return Get();
        }

        public Proyectos_EstadoObligacion GetProyectos_EstadoObligacionDetails(int id_estadoobligacion)
        {
            return Get(id_estadoobligacion);
        }

        public Proyectos_EstadoObligacion GetProyectos_EstadoObligacionEstado(string cd_estadoobligacion)
        {
            return Get(c=> c.estadoobligacion==cd_estadoobligacion).FirstOrDefault();
        }

        public bool InsertProyectos_EstadoObligacion(Proyectos_EstadoObligacion proyectos_EstadoObligacion)
        {
            Add(proyectos_EstadoObligacion);
            return true;
        }

        public bool UpdateProyectos_EstadoObligacion(Proyectos_EstadoObligacion proyectos_EstadoObligacion)
        {
            Update(proyectos_EstadoObligacion);
            return true;
        }
        DataTableAdapter<Proyectos_EstadoObligacion> IProyectos_EstadoObligacionRepository.GetDataTableProyectos_EstadoObligacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_EstadoObligacion, bool>> srchByFunc = null;
            Expression<Func<Proyectos_EstadoObligacion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.estadoobligacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_EstadoObligacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_EstadoObligacion> result = new DataTableAdapter<Proyectos_EstadoObligacion>();

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