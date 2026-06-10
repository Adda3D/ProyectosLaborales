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
    public class Publicaciones_EstadoCorreccionRepository : SuperType<Publicaciones_EstadoCorreccion>, IPublicaciones_EstadoCorreccionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoCorreccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoCorreccionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoCorreccion(int id_estadocorreccion)
        {
            Delete(id_estadocorreccion);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoCorreccion> GetAllPublicaciones_EstadoCorreccion()
        {
            return Get();
        }

        public Publicaciones_EstadoCorreccion GetPublicaciones_EstadoCorreccionDetails(int id_estadocorreccion)
        {
            return Get(id_estadocorreccion);
        }

        public Publicaciones_EstadoCorreccion GetPublicaciones_EstadoCorreccionNombre(string cd_nmestadocorreccion)
        {
            return Get(c => c.nmestadocorreccion == cd_nmestadocorreccion).FirstOrDefault();
        }

        public bool InsertPublicaciones_EstadoCorreccion(Publicaciones_EstadoCorreccion publicaciones_EstadoCorreccion)
        {
            Add(publicaciones_EstadoCorreccion);
            return true;
        }

        public bool UpdatePublicaciones_EstadoCorreccion(Publicaciones_EstadoCorreccion publicaciones_EstadoCorreccion)
        {
            Update(publicaciones_EstadoCorreccion);
            return true;
        }
        DataTableAdapter<Publicaciones_EstadoCorreccion> IPublicaciones_EstadoCorreccionRepository.GetDataTablePublicaciones_EstadoCorreccion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoCorreccion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoCorreccion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadocorreccion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoCorreccion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoCorreccion> result = new DataTableAdapter<Publicaciones_EstadoCorreccion>();

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