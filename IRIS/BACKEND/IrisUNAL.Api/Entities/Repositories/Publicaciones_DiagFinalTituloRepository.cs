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
    public class Publicaciones_DiagFinalTituloRepository : SuperType<Publicaciones_DiagFinalTitulo>, IPublicaciones_DiagFinalTituloRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DiagFinalTituloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DiagFinalTituloRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DiagFinalTitulo(int id_diagfinaltitulo)
        {
            Delete(id_diagfinaltitulo);
            return true;
        }

        public IEnumerable<Publicaciones_DiagFinalTitulo> GetAllPublicaciones_DiagFinalTitulo()
        {
            return Get();
        }

        public Publicaciones_DiagFinalTitulo GetPublicaciones_DiagFinalTituloDetails(int id_diagfinaltitulo)
        {
            return Get(id_diagfinaltitulo);
        }

        public Publicaciones_DiagFinalTitulo GetPublicaciones_DiagFinalTituloNombre(string cd_nmdiagfinaltitulo)
        {
            return Get(c => c.nmdiagfinaltitulo == cd_nmdiagfinaltitulo).FirstOrDefault();
        }

        public bool InsertPublicaciones_DiagFinalTitulo(Publicaciones_DiagFinalTitulo publicaciones_DiagFinalTitulo)
        {
            Add(publicaciones_DiagFinalTitulo);
            return true;
        }

        public bool UpdatePublicaciones_DiagFinalTitulo(Publicaciones_DiagFinalTitulo publicaciones_DiagFinalTitulo)
        {
            Update(publicaciones_DiagFinalTitulo);
            return true;
        }
        DataTableAdapter<Publicaciones_DiagFinalTitulo> IPublicaciones_DiagFinalTituloRepository.GetDataTablePublicaciones_DiagFinalTitulo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DiagFinalTitulo, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DiagFinalTitulo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdiagfinaltitulo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DiagFinalTitulo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DiagFinalTitulo> result = new DataTableAdapter<Publicaciones_DiagFinalTitulo>();

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