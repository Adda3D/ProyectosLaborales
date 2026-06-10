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
    public class Investigacion_EstadoProyectoRepository : SuperType<Investigacion_EstadoProyecto>
    {
        private ApplicationDbContext _context;

        public Investigacion_EstadoProyectoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Investigacion_EstadoProyectoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Investigacion_EstadoProyecto> GetAllInvestigacion_EstadoProyecto()
        {
            return Get();
        }
        public Investigacion_EstadoProyecto GetInvestigacion_EstadoProyectoDetails(int id_estado)
        {
            return Get(id_estado);
        }
        public Investigacion_EstadoProyecto GetInvestigacion_EstadoProyectoNombre(string cd_nmestado)
        {
            return Get(c => c.nmestado == cd_nmestado).FirstOrDefault();
        }
        public bool InsertInvestigacion_EstadoProyecto(Investigacion_EstadoProyecto investigacion_EstadoProyecto)
        {
            Add(investigacion_EstadoProyecto);
            return true;
        }
        public bool UpdateInvestigacion_EstadoProyecto(Investigacion_EstadoProyecto investigacion_EstadoProyecto)
        {
            Update(investigacion_EstadoProyecto);
            return true;
        }
        public bool DeleteInvestigacion_EstadoProyecto( int id_estado)
        {
            Delete(id_estado);
            return true;
        }
        public DataTableAdapter<Investigacion_EstadoProyecto> GetDataTableInvestigacion_EstadoProyecto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_EstadoProyecto, bool>> srchByFunc = null;
            Expression<Func<Investigacion_EstadoProyecto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestado.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_EstadoProyecto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_EstadoProyecto> result = new DataTableAdapter<Investigacion_EstadoProyecto>();

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