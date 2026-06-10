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
    public class Proyectos_AlcanceProyectoRepository : SuperType<Proyectos_AlcanceProyecto>, IProyectos_AlcanceProyectoRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_AlcanceProyectoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_AlcanceProyectoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyectos_AlcanceProyecto(int id_alcanceproyecto)
        {
            Delete(id_alcanceproyecto);
            return true;
        }

        public IEnumerable<Proyectos_AlcanceProyecto> GetAllProyectos_AlcanceProyecto()
        {
            return Get();
        }

        public Proyectos_AlcanceProyecto GetProyectos_AlcanceProyectoAlcance(string cd_alcanceproyecto)
        {
            return Get(c=>c.alcanceproyecto==cd_alcanceproyecto).FirstOrDefault();
        }

        public Proyectos_AlcanceProyecto GetProyectos_AlcanceProyectoDetails(int id_alcanceproyecto)
        {
            return Get(id_alcanceproyecto);
        }

        public bool InsertProyectos_AlcanceProyecto(Proyectos_AlcanceProyecto proyectos_AlcanceProyecto)
        {
            Add(proyectos_AlcanceProyecto);
            return true;
        }

        public bool UpdateProyectos_AlcanceProyecto(Proyectos_AlcanceProyecto proyectos_AlcanceProyecto)
        {
            Update(proyectos_AlcanceProyecto);
            return true;
        }
        DataTableAdapter<Proyectos_AlcanceProyecto> IProyectos_AlcanceProyectoRepository.GetDataTableProyectos_AlcanceProyecto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_AlcanceProyecto, bool>> srchByFunc = null;
            Expression<Func<Proyectos_AlcanceProyecto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.alcanceproyecto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_AlcanceProyecto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_AlcanceProyecto> result = new DataTableAdapter<Proyectos_AlcanceProyecto>();

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