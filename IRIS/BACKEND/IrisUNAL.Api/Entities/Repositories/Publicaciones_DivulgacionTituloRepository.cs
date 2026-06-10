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
    public class Publicaciones_DivulgacionTituloRepository : SuperType<Publicaciones_DivulgacionTitulo>, IPublicaciones_DivulgacionTituloRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionTituloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionTituloRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionTitulo(int id_divtitulo)
        {
            Delete(id_divtitulo);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionTitulo> GetAllPublicaciones_DivulgacionTitulo()
        {
            return Get();
        }

        public Publicaciones_DivulgacionTitulo GetPublicaciones_DivulgacionTituloDetails(int id_divtitulo)
        {
            return Get(id_divtitulo);
        }

        public Publicaciones_DivulgacionTitulo GetPublicaciones_DivulgacionTituloNombre(string cd_nmtitulo)
        {
            return Get(c => c.nmtitulo == cd_nmtitulo).FirstOrDefault();
        }

        public bool InsertPublicaciones_DivulgacionTitulo(Publicaciones_DivulgacionTitulo publicaciones_DivulgacionTitulo)
        {
            Add(publicaciones_DivulgacionTitulo);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionTitulo(Publicaciones_DivulgacionTitulo publicaciones_DivulgacionTitulo)
        {
            Update(publicaciones_DivulgacionTitulo);
            return true;
        }
        DataTableAdapter<Publicaciones_DivulgacionTitulo> IPublicaciones_DivulgacionTituloRepository.GetDataTablePublicaciones_DivulgacionTitulo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionTitulo, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionTitulo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtitulo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionTitulo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionTitulo> result = new DataTableAdapter<Publicaciones_DivulgacionTitulo>();

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