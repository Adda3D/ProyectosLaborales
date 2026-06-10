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
    public class Publicaciones_CostosServicioEditorialRepository : SuperType<Publicaciones_CostosServicioEditorial>, IPublicaciones_CostosServicioEditorialRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CostosServicioEditorialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CostosServicioEditorialRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CostosServicioEditorial(int id_servicioeditorial)
        {
            Delete(id_servicioeditorial);
            return true;
        }

        public IEnumerable<Publicaciones_CostosServicioEditorial> GetAllPublicaciones_CostosServicioEditorial()
        {
            return Get();
        }

        public Publicaciones_CostosServicioEditorial GetPublicaciones_CostosServicioEditorialDetails(int id_servicioeditorial)
        {
            return Get(id_servicioeditorial);
        }

        public Publicaciones_CostosServicioEditorial GETPublicaciones_CostosServicioEditorialNombre(string cd_nomservicioeditorial)
        {
            return Get(c => c.nomservicioeditorial == cd_nomservicioeditorial).FirstOrDefault();
        }

        public bool InsertPublicaciones_CostosServicioEditorial(Publicaciones_CostosServicioEditorial publicaciones_CostosServicioEditorial)
        {
            Add(publicaciones_CostosServicioEditorial);
            return true;
        }

        public bool UpdatePublicaciones_CostosServicioEditorial(Publicaciones_CostosServicioEditorial publicaciones_CostosServicioEditorial)
        {
            Update(publicaciones_CostosServicioEditorial);
            return true;
        }
        DataTableAdapter<Publicaciones_CostosServicioEditorial> IPublicaciones_CostosServicioEditorialRepository.GetDataTablePublicaciones_CostosServicioEditorial(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_CostosServicioEditorial, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_CostosServicioEditorial, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nomservicioeditorial.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_CostosServicioEditorial>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_CostosServicioEditorial> result = new DataTableAdapter<Publicaciones_CostosServicioEditorial>();

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