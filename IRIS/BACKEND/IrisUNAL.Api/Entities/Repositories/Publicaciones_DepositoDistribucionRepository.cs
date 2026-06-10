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
    public class Publicaciones_DepositoDistribucionRepository : SuperType<Publicaciones_DepositoDistribucion>, IPublicaciones_DepositoDistribucionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoDistribucionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoDistribucionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoDistribucion(int id_distribucion)
        {
            Delete(id_distribucion);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoDistribucion> GetAllPublicaciones_DepositoDistribucion()
        {
            return Get();
        }

        public Publicaciones_DepositoDistribucion GetPublicaciones_DepositoDistribucionDetails(int id_distribucion)
        {
            return Get(id_distribucion);
        }

        public bool InsertPublicaciones_DepositoDistribucion(Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion)
        {
            Add(publicaciones_DepositoDistribucion);
            return true;
        }

        public bool UpdatePublicaciones_DepositoDistribucion(Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion)
        {
            Update(publicaciones_DepositoDistribucion);
            return true;
        }

        public DataTableAdapter<Publicaciones_DepositoDistribucion> GetDataTablePublicaciones_DepositoDistribucionByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoDistribucion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoDistribucion, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DepositoDistribucion, DateTime>> orderByDateFunc = null;
            Expression<Func<Publicaciones_DepositoDistribucion, int>> orderByIntFunc = null;

            Expression<Func<Publicaciones_DepositoDistribucion, object>> parameter1 = m => m.ObjDisposicion;            
            Expression<Func<Publicaciones_DepositoDistribucion, object>>[] parameterArray = new Expression<Func<Publicaciones_DepositoDistribucion, object>>[] { parameter1 };

            bool isOrderDesc = false;

            
            if (model.SortColumn.ToLower() == "id_distribucion")
                orderByIntFunc = CreateExpressionOrderByInt<Publicaciones_DepositoDistribucion>("id_distribucion");
            else
                if (model.SortColumn.ToLower() == "fechaentrega")
                    orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DepositoDistribucion>("fechaentrega");
            

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

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoDistribucion> result = new DataTableAdapter<Publicaciones_DepositoDistribucion>();

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