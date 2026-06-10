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
    public class Publicaciones_IdiomaRepository : SuperType<Publicaciones_Idioma>, IPublicaciones_IdiomaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_IdiomaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_IdiomaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Idioma(int id_idioma)
        {
            Delete(id_idioma);
            return true;
        }

        public IEnumerable<Publicaciones_Idioma> GetAllPublicaciones_Idioma()
        {
            return Get();
        }

        public Publicaciones_Idioma GetPublicaciones_IdiomaDetails(int id_idioma)
        {
            return Get(id_idioma);
        }

        public Publicaciones_Idioma GetPublicaciones_IdiomaNombre(string cd_nmidioma)
        {
            return Get(c => c.nmidioma == cd_nmidioma).FirstOrDefault();
        }

        public bool InsertPublicaciones_Idioma(Publicaciones_Idioma publicaciones_Idioma)
        {
            Add(publicaciones_Idioma);
            return true;
        }

        public bool UpdatePublicaciones_Idioma(Publicaciones_Idioma publicaciones_Idioma)
        {
            Update(publicaciones_Idioma);
            return true;
        }
        DataTableAdapter<Publicaciones_Idioma> IPublicaciones_IdiomaRepository.GetDataTablePublicaciones_Idioma(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Idioma, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Idioma, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmidioma.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_Idioma>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Idioma> result = new DataTableAdapter<Publicaciones_Idioma>();

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