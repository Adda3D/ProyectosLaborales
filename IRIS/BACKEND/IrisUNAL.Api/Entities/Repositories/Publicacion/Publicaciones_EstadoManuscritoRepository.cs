using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Publicacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Publicacion
{
    public class Publicaciones_EstadoManuscritoRepository : SuperType<Publicaciones_EstadoManuscrito>
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoManuscritoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Publicaciones_EstadoManuscritoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoManuscrito(int idestadomanuscrito)
        {
            Delete(idestadomanuscrito);
            return true;
        }
        public IEnumerable<Publicaciones_EstadoManuscrito> GetAllPublicaciones_EstadoManuscrito()
        {
            return Get();
        }
        public Publicaciones_EstadoManuscrito GetPublicaciones_EstadoManuscritoDetails(int idestadomanuscrito)
        {
            return Get(idestadomanuscrito);
        }
        public Publicaciones_EstadoManuscrito GetPublicaciones_EstadoManuscritoNombre(string cd_estadomanuscrito)
        {
            return Get(c => c.estadomanuscrito == cd_estadomanuscrito).FirstOrDefault();
        }
        public bool InsertPublicaciones_EstadoManuscrito(Publicaciones_EstadoManuscrito Publicaciones_EstadoManuscrito)
        {

            Add(Publicaciones_EstadoManuscrito);
            return true;
        }
        public bool UpdatePublicaciones_EstadoManuscrito(Publicaciones_EstadoManuscrito Publicaciones_EstadoManuscrito)
        {
            Update(Publicaciones_EstadoManuscrito);
            return true;

        }

        public DataTableAdapter<Publicaciones_EstadoManuscrito> GetDataTablePublicaciones_EstadoManuscrito(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoManuscrito, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoManuscrito, string>> orderByFunc = null;

            //  Expression<Func<Publicaciones_EstadoManuscrito, object>> parameter1 = p => p.estadomanuscrito;
            Expression<Func<Publicaciones_EstadoManuscrito, object>>[] parameterArray = new Expression<Func<Publicaciones_EstadoManuscrito, object>>[] { };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.estadomanuscrito.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoManuscrito>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoManuscrito> result = new DataTableAdapter<Publicaciones_EstadoManuscrito>();

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