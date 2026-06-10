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
    public class Proyectos_NaturalezaProyectoRepository : SuperType<Proyectos_NaturalezaProyecto>, IProyectos_NaturalezaProyectoRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_NaturalezaProyectoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_NaturalezaProyectoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteProyectos_NaturalezaProyecto(int id_naturalezaproyecto)
        {
            Delete(id_naturalezaproyecto);
            return true;
        }

        public IEnumerable<Proyectos_NaturalezaProyecto> GetAllProyectos_NaturalezaProyecto()
        {
            return Get();
        }

        public Proyectos_NaturalezaProyecto GetProyectos_NaturalezaProyectoDetails(int id_naturalezaproyecto)
        {
            return Get(id_naturalezaproyecto);
        }

        public Proyectos_NaturalezaProyecto GetProyectos_NaturalezaProyectoNaturaleza(string cd_naturalezaproyecto)
        {
            return Get(c=>c.naturalezaproyecto==cd_naturalezaproyecto).FirstOrDefault();
        }

        public bool InsertProyectos_NaturalezaProyecto(Proyectos_NaturalezaProyecto proyectos_NaturalezaProyecto)
        {
            Add(proyectos_NaturalezaProyecto);
            return true;
        }

        public bool UpdateProyectos_NaturalezaProyecto(Proyectos_NaturalezaProyecto proyectos_NaturalezaProyecto)
        {
            Update(proyectos_NaturalezaProyecto);
            return true;
        }
        DataTableAdapter<Proyectos_NaturalezaProyecto> IProyectos_NaturalezaProyectoRepository.GetDataTableProyectos_NaturalezaProyecto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_NaturalezaProyecto, bool>> srchByFunc = null;
            Expression<Func<Proyectos_NaturalezaProyecto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.naturalezaproyecto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_NaturalezaProyecto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_NaturalezaProyecto> result = new DataTableAdapter<Proyectos_NaturalezaProyecto>();

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