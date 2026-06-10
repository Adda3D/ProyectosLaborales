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
    public class Publicaciones_CarProyEditorialRepository : SuperType<Publicaciones_CarProyEditorial>, IPublicaciones_CarProyEditorialRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CarProyEditorialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CarProyEditorialRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CarProyEditorial(int id_carproyeditorial)
        {
            Delete(id_carproyeditorial);
            return true;
        }

        public IEnumerable<Publicaciones_CarProyEditorial> GetAllPublicaciones_CarProyEditorial()
        {
            return Get();
        }

        public Publicaciones_CarProyEditorial GetPublicaciones_CarProyEditorialDetails(int id_carproyeditorial)
        {
            return Get(id_carproyeditorial);
        }

        public Publicaciones_CarProyEditorial GetPublicaciones_CarProyEditorialNombre(string cd_nmcarproyeditorial)
        {
            return Get(c => c.nmcarproyeditorial == cd_nmcarproyeditorial).FirstOrDefault();
        }

        public bool InsertPublicaciones_CarProyEditorial(Publicaciones_CarProyEditorial publicaciones_CarProyEditorial)
        {
            Add(publicaciones_CarProyEditorial);
            return true;
        }

        public bool UpdatePublicaciones_CarProyEditorial(Publicaciones_CarProyEditorial publicaciones_CarProyEditorial)
        {
            Update(publicaciones_CarProyEditorial);
            return true;
        }
        DataTableAdapter<Publicaciones_CarProyEditorial> IPublicaciones_CarProyEditorialRepository.GetDataTablePublicaciones_CarProyEditorial(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_CarProyEditorial, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_CarProyEditorial, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmcarproyeditorial.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_CarProyEditorial>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_CarProyEditorial> result = new DataTableAdapter<Publicaciones_CarProyEditorial>();

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