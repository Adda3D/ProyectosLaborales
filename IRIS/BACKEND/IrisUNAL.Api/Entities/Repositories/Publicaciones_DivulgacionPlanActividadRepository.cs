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
    public class Publicaciones_DivulgacionPlanActividadRepository : SuperType<Publicaciones_DivulgacionPlanActividad>
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionPlanActividadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionPlanActividadRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Publicaciones_DivulgacionPlanActividad> GetAllPublicaciones_DivulgacionPlanActividad()
        {
            return Get();
        }

        public Publicaciones_DivulgacionPlanActividad GetPublicaciones_DivulgacionPlanActividadDetails(int iddivulgacionplanactividad)
        {
            return Get(iddivulgacionplanactividad);
        }

        public bool InsertPublicaciones_DivulgacionPlanActividad(Publicaciones_DivulgacionPlanActividad _publicaciones_divulgacionplanactividad)
        {
            Add(_publicaciones_divulgacionplanactividad);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionPlanActividad(Publicaciones_DivulgacionPlanActividad _publicaciones_divulgacionplanactividad)
        {
            Update(_publicaciones_divulgacionplanactividad);
            return true;
        }

        public bool DeletePublicaciones_DivulgacionPlanActividad(int iddivulgacionplanactividad)
        {
            Delete(iddivulgacionplanactividad);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionPlanActividad> GetPublicaciones_DivulgacionPlanActividadByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion);
        }

        public DataTableAdapter<Publicaciones_DivulgacionPlanActividad> GetDataTablePublicaciones_DivulgacionPlanActividadByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionPlanActividad, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionPlanActividad, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DivulgacionPlanActividad, DateTime>> orderByDateFunc = null;
            //Expression<Func<Publicaciones_DivulgacionPlanActividad, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DivulgacionPlanActividad>("fecha");
            else
                orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionPlanActividad>(model.SortColumn);


            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
            
            var data = (model.SortColumn.ToLower() == "fecha") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionPlanActividad> result = new DataTableAdapter<Publicaciones_DivulgacionPlanActividad>();

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