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
    public class Proyectos_TipoProyectoRepository : SuperType<Proyectos_TipoProyecto>, IProyectos_TipoProyectoRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_TipoProyectoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_TipoProyectoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyectos_TipoProyecto(int id_tipoproyecto)
        {
            Delete(id_tipoproyecto);
            return true;
        }

        public IEnumerable<Proyectos_TipoProyecto> GetAllProyectos_TipoProyecto()
        {
            return Get();
        }

        public Proyectos_TipoProyecto GetProyectos_TipoProyectoDetails(int id_tipoproyecto)
        {
            return Get(id_tipoproyecto);
        }

        public Proyectos_TipoProyecto GetProyectos_TipoProyectoTipo(string cd_tipoproyecto)
        {
            return Get(c=>c.tipoproyecto==cd_tipoproyecto).FirstOrDefault();
        }

        public bool InsertProyectos_TipoProyecto(Proyectos_TipoProyecto proyectos_TipoProyecto)
        {
            Add(proyectos_TipoProyecto);
            return true;
        }

        public bool UpdateProyectos_TipoProyecto(Proyectos_TipoProyecto proyectos_TipoProyecto)
        {
            Update(proyectos_TipoProyecto);
            return true;
        }
        DataTableAdapter<Proyectos_TipoProyecto> IProyectos_TipoProyectoRepository.GetDataTableProyectos_TipoProyecto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_TipoProyecto, bool>> srchByFunc = null;
            Expression<Func<Proyectos_TipoProyecto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.tipoproyecto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_TipoProyecto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_TipoProyecto> result = new DataTableAdapter<Proyectos_TipoProyecto>();

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