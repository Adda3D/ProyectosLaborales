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
    public class Publicaciones_DepositoControlInventarioMovimientosRepository : SuperType<Publicaciones_DepositoControlInventarioMovimientos>, IPublicaciones_DepositoControlInventarioMovimientosRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlInventarioMovimientosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlInventarioMovimientosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControlInventarioMovimientos(int id_movimintos)
        {
            Delete(id_movimintos);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControlInventarioMovimientos> GetAllPublicaciones_DepositoControlInventarioMovimientos()
        {
            return Get();
        }

        public Publicaciones_DepositoControlInventarioMovimientos GetPublicaciones_DepositoControlInventarioMovimientosDetails(int id_movimientos)
        {
            return Get(id_movimientos);
        }

        public bool InsertPublicaciones_DepositoControlInventarioMovimientos(Publicaciones_DepositoControlInventarioMovimientos publicaciones_DepositoControlInventarioMovimientos)
        {
            Add(publicaciones_DepositoControlInventarioMovimientos);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControlInventarioMovimientos(Publicaciones_DepositoControlInventarioMovimientos publicaciones_DepositoControlInventarioMovimientos)
        {
            Update(publicaciones_DepositoControlInventarioMovimientos);
            return true;
        }

        public DataTableAdapter<Publicaciones_DepositoControlInventarioMovimientos> GetDataTablePublicaciones_DepositoControlInventarioMovimientosByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, DateTime>> orderByDateFunc = null;
            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, int>> orderByIntFunc = null;

            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, object>> parameter1 = m => m.ObjBodega;
            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, object>> parameter2 = m => m.ObjTipoMov;
            Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, object>>[] parameterArray = new Expression<Func<Publicaciones_DepositoControlInventarioMovimientos, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "id_movimientos")
                orderByIntFunc = CreateExpressionOrderByInt<Publicaciones_DepositoControlInventarioMovimientos>("id_movimientos");
            else
                if (model.SortColumn.ToLower() == "fecha")
                    orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DepositoControlInventarioMovimientos>("fecha");
                else
                    orderByFunc = CreateExpressionOrderBy<Publicaciones_DepositoControlInventarioMovimientos>(model.SortColumn);

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

            var data = (model.SortColumn.ToLower() == "id_movimientos") ?
                        GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() : (model.SortColumn.ToLower() == "fecha") ?
                        GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                        GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
                
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoControlInventarioMovimientos> result = new DataTableAdapter<Publicaciones_DepositoControlInventarioMovimientos>();

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