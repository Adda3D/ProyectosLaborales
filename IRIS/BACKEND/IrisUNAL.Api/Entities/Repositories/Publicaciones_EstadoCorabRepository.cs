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
    public class Publicaciones_EstadoCorabRepository : SuperType<Publicaciones_EstadoCorab>, IPublicaciones_EstadoCorabRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoCorabRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoCorabRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoCorab(int id_estadocorab)
        {
            Delete(id_estadocorab);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoCorab> GetAllPublicaciones_EstadoCorab()
        {
            return Get();
        }

        public Publicaciones_EstadoCorab GetPublicaciones_EstadoCorabDetails(int id_estadocorab)
        {
            return Get(id_estadocorab);
        }

        public Publicaciones_EstadoCorab GetPublicaciones_EstadoCorabNombre(string cd_nmestadocorab)
        {
            return Get(c => c.nmestadocorab == cd_nmestadocorab).FirstOrDefault();
        }

        public bool InsertPublicaciones_EstadoCorab(Publicaciones_EstadoCorab publicaciones_EstadoCorab)
        {
            Add(publicaciones_EstadoCorab);
            return true;
        }

        public bool UpdatePublicaciones_EstadoCorab(Publicaciones_EstadoCorab publicaciones_EstadoCorab)
        {
            Update(publicaciones_EstadoCorab);
            return true;
        }
        DataTableAdapter<Publicaciones_EstadoCorab> IPublicaciones_EstadoCorabRepository.GetDataTablePublicaciones_EstadoCorab(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoCorab, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoCorab, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadocorab.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoCorab>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoCorab> result = new DataTableAdapter<Publicaciones_EstadoCorab>();

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