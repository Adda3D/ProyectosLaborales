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
    public class Publicaciones_OrigenManuscritoRepository : SuperType<Publicaciones_OrigenManuscrito>, IPublicaciones_OrigenManuscritoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_OrigenManuscritoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_OrigenManuscritoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_OrigenManuscrito(int id_origenmanuscrito)
        {
            Delete(id_origenmanuscrito);
            return true;
        }

        public IEnumerable<Publicaciones_OrigenManuscrito> GetAllPublicaciones_OrigenManuscrito()
        {
            return Get();
        }

        public Publicaciones_OrigenManuscrito GetPublicaciones_OrigenManuscritoDetails(int id_origenmanuscrito)
        {
            return Get(id_origenmanuscrito);
        }

        public Publicaciones_OrigenManuscrito GetPublicaciones_OrigenManuscritoNombre(string cd_nmorigenmanuscrito)
        {
            return Get(c => c.nmorigenmanuscrito == cd_nmorigenmanuscrito).FirstOrDefault();
        }

        public bool InsertPublicaciones_OrigenManuscrito(Publicaciones_OrigenManuscrito publicaciones_OrigenManuscrito)
        {
            Add(publicaciones_OrigenManuscrito);
            return true;
        }

        public bool UpdatePublicaciones_OrigenManuscrito(Publicaciones_OrigenManuscrito publicaciones_OrigenManuscrito)
        {
            Update(publicaciones_OrigenManuscrito);
            return true;
        }
        DataTableAdapter<Publicaciones_OrigenManuscrito> IPublicaciones_OrigenManuscritoRepository.GetDataTablePublicaciones_OrigenManuscrito(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_OrigenManuscrito, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_OrigenManuscrito, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmorigenmanuscrito.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_OrigenManuscrito>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_OrigenManuscrito> result = new DataTableAdapter<Publicaciones_OrigenManuscrito>();

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